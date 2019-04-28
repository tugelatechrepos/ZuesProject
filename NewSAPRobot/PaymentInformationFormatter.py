class PaymentInformationFormatter:
    def __init__(self,rawPaymentdata, paymentDataList = []):
        self.raw_payment_data=rawPaymentdata
        self.paymentDataList = paymentDataList

    def assignPaymentList(self):
        self.paymentDataList = []
        self.raw_payment_data = [i for i in self.raw_payment_data.splitlines() if i]
        rawPaymentLines = list(filter(lambda x: ("ZAR" in x) or ("General ledger items total" in x),self.raw_payment_data))
        for rawPaymentdata in rawPaymentLines:
            if "General ledger items total" in rawPaymentdata:
                break
            updatedData = rawPaymentdata.replace("|", "")
            updatedData = updatedData.replace("-", "")
            dataColumnList = [i for i in updatedData.split(" ") if i]
            self.paymentDataList.append(dataColumnList)
