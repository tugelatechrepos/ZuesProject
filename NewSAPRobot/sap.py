from pywinauto import application
from pywinauto.keyboard import send_keys
import time
import pyautogui
import pywinauto
import win32clipboard
from  PaymentInformationFormatter import PaymentInformationFormatter
from PaymentListProcessor import PaymentListProcessor
from tkinter import Tk
import asyncio


class RawPaymentData:
    def __init__(self,accountnumber,rawpaymentdata):
        self.account_number = accountnumber
        self.raw_payment_data = rawpaymentdata

def main():
    app = application.Application()
    app.start("C:\\Program Files (x86)\\SAP\\FrontEnd\\SAPgui\\saplogon.exe")
    app.connect(title_re="SAP Logon 740", class_name="#32770", timeout=15)
    dlg = app['SAP_Logon_740']
    dlg['Log_&On'].click()
    app.connect(title_re="SAP", timeout=15)
    dlg = app["SAP"]
    dlg.type_keys("mahlakom")
    send_keys("{VK_ESCAPE}")
    send_keys("{VK_DOWN}")
    dlg.type_keys("Mabaso@791")
    send_keys("{ENTER}")
    app.connect(title_re=".*SAP Easy Access.*", timeout=15)
    dlg = app["SAP_FRONTEND_SESSION"]
    dlg.type_keys("fpl9")
    send_keys("{ENTER}")
    filepath = "C:\\RobotTest\\accountlist.txt"
    str = open(filepath, 'r').read()
    accountList = str.splitlines()
    # accountList = ["90438"]
    raw_payment_list = []

    start_time = time.time()
    try:
        for account in accountList:
            app.connect(title_re=".*Account Display.*", timeout=15)
            dlg = app["SAP_FRONTEND_SESSION"]
            time.sleep(.5)
            send_keys("{VK_DOWN}")
            dlg.type_keys(account)
            send_keys("{ENTER}")
            app.connect(title_re="Account Display: Basic List", timeout=15)
            dlg = app["SAP_FRONTEND_SESSION"]
            pywinauto.mouse.click(button='left', coords=(409, 300, 0, 0))
            time.sleep(0.5)
            isNoPaymentFound = pyautogui.locateOnScreen("C:\\RobotTest\\NoPaymentFound.PNG", region=(18, 282, 135, 36))
            if isNoPaymentFound != None:
                print(account)
                send_keys("{VK_F3}")
            else:
                send_keys("^/")
                time.sleep(0.5)
                dlg.type_keys("{%}pc")
                send_keys("{ENTER}")
                time.sleep(1)
                send_keys("{VK_UP}")
                send_keys("{ENTER}")
                # win32clipboard.OpenClipboard()
                # paymentData = win32clipboard.GetClipboardData()
                # win32clipboard.EmptyClipboard()
                # win32clipboard.CloseClipboard()
                r = Tk()
                paymentData = r.clipboard_get()
                r.withdraw()
                r.update()
                r.destroy()
                process_raw_payment_data(paymentData,account)
                time.sleep(0.2)
                send_keys("{VK_F3}")
    except Exception as e:
        end_time = time.time()
        total = end_time - start_time
        print(f"Something went wrong after processing {len(accountList)} accounts in {total} seconds, please check the error")
        print(e)

    end_time = time.time()
    total = end_time - start_time
    print(f"Total time taken to complete for {len(accountList)} accounts = {total} seconds")


def process_raw_payment_data(raw_payment_data,accountnumber):
    paymentInformationFormatter = PaymentInformationFormatter(raw_payment_data)
    paymentInformationFormatter.assignPaymentList()
    paymentDataList = paymentInformationFormatter.paymentDataList
    process_payment_data(paymentDataList,accountnumber)


def process_payment_data(payment_data_list,accountnumber):
    paymentListProcessor = PaymentListProcessor(payment_data_list, accountnumber)
    paymentListProcessor.processPaymentList()
    for payment in paymentListProcessor.payment_list:
        print(payment.account_number, payment.service_id, payment.payment_date, payment.payment_amount,
              payment.payment_mode, payment.payment_description)


main()























