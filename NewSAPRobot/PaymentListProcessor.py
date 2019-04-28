from Payment import Payment
import datetime
from decimal import Decimal


class PaymentListProcessor:
    # payment_list = []
    def __init__(self,formattedPaymentList ,AccountNumber,PaymentList = []):
        self.formatted_payment_list = formattedPaymentList
        self.account_number = AccountNumber
        self.payment_list = PaymentList


    def processPaymentList(self):
        self.payment_list = []
        for formattedPaymentArray in self.formatted_payment_list:
            account_number = self.account_number
            service_id = formattedPaymentArray[0]
            payment_date = self.__getFormattedDate(formattedPaymentArray[1])
            zarIndex = formattedPaymentArray.index("ZAR")
            paymentAmountIndex = zarIndex - 1
            paymentAmount = formattedPaymentArray[paymentAmountIndex]
            payment_amount = self.__getFormattedPaymentAmount(paymentAmount)
            payment_mode = self.__getFormattedPaymentType(formattedPaymentArray)
            payment_description = self.__getFormattedDescription(formattedPaymentArray)
            payment = Payment(account_number,service_id,payment_date,payment_amount,payment_mode,payment_description)
            self.payment_list.append(payment)

    def __getFormattedDate(self, date):
        dateArray = date.split('.');
        day = int(dateArray[0]);
        month = int(dateArray[1]);
        year = int(dateArray[2]);
        paymentDate = datetime.date(year, month, day)
        return paymentDate;

    def __getFormattedPaymentAmount(self,paymentAmount):
        amount = ""
        if "." in paymentAmount:
            amount = paymentAmount.replace(".", "")

        if "," in paymentAmount:
            if amount == "":
                amount = paymentAmount
            amount = amount.replace(",",".")        

        return Decimal(amount)
    

    def __getFormattedPaymentType(self,paymentArrayItem):
        startIndex = 2
        amountIndex = paymentArrayItem.index("ZAR") -1
        paymentMethodArray = paymentArrayItem[2:amountIndex]
        paymentMethod = " ".join(paymentMethodArray)
        return paymentMethod

    def __getFormattedDescription(self,paymentArrayItem):
        zarIndex = paymentArrayItem.index("ZAR")
        if len(paymentArrayItem) - 1 == zarIndex:
            return ""

        else:
         return paymentArrayItem[-1]












