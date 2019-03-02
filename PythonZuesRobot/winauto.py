from pywinauto import application
import time
app = application.Application()
app.start("C:\\ZuesProjectSetUp\\NewApplicationSetUp\\SAPGUI\\SAPGUI.exe")
dlg = app['SAP_GUI']
dlg.User_nameEdit2.type_keys('letsholo.thipe')
time.sleep(0.5)
dlg.PasswordEdit.type_keys('letsholo.thipe')
dlg.SubmitButton.click()
app.connect(title_re = "Account Form",timeout=15)
dlg = app["Account_Form"]
dlg.Account_IdEdit.click()

list = ['131613','135216','140022','142238','142502']

for accountId in list:
    dlg.Account_IdEdit.type_keys(accountId)
    time.sleep(0.8)
    dlg.FetchButton.click()
    time.sleep(1)
    dlg.ClearButton.click()
    time.sleep(0.8)

app.kill()