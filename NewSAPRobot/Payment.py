class Payment:
    def __init__(self,accountNumber,serviceId,paymentDate,paymentAmount,paymentMode,description):
      self.account_number = accountNumber
      self.service_id = serviceId
      self.payment_date = paymentDate
      self.payment_amount = paymentAmount
      self.payment_mode = paymentMode
      self.payment_description = description
