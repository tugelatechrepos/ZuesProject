using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Winium;
using Quellatalo.Nin.TheHands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public class SAPRobotApplication : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private DesktopOptions _DesktopOptions;
        private WiniumDriver _WiniumDriver;
        private WiniumDriverService _Service;
        private KeyboardHandler _keyboadHandler;

        private ICollection<int> _AccountIdList = new List<int> { 135216, 131613, 142502, 142238, 140022 };
        private RemoteWebDriver _RemoteWebDriver;

        public SAPRobotApplication()
        {
            var fileName = $@"{ConfigurationManager.AppSettings["RobotImagePath"]}";
            trayIcon = new NotifyIcon()
            {
                Icon = new System.Drawing.Icon(fileName),
                Text = "Zues",
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };

            Thread.Sleep(2000);
            Execute();
        }

        public void Execute()
        {
            try
            {
                startWinium();
                start();
            }
            catch(Exception ex)            {
               
                trayIcon.Visible = false;
                Application.Exit();
            }          
        }

        private void startWinium()
        {
            //var winiumdriver = (byte[])Zues.Properties.Resources.ResourceManager.GetObject("winiumdriver");
            var applicationPath = $@"{ConfigurationManager.AppSettings["ApplicationPath"]}";
            _DesktopOptions = new DesktopOptions();
            _DesktopOptions.ApplicationPath = applicationPath;
            var driverPath = $@"{ConfigurationManager.AppSettings["WiniumDriverPath"]}";
            _Service = WiniumDriverService.CreateDefaultService(driverPath, "Winium.Desktop.Driver.exe");
            _Service.Port = 9999;
            _Service.HideCommandPromptWindow = true;

            
            _WiniumDriver = new WiniumDriver(_Service, _DesktopOptions);
            //_WiniumDriver = new WiniumDriver(driverPath, _DesktopOptions);
            Thread.Sleep(3000);
        }



        private void start()
        {
            int count = 0;
            _Service.Start();
            var element = _WiniumDriver.FindElement(By.Id("btnSubmit"));
            while (!_WiniumDriver.FindElementById("btnSubmit").Enabled)
            {
                Thread.Sleep(2000);
                count++;
                if (count == 10) return;
            }

            _keyboadHandler = new KeyboardHandler();
            _keyboadHandler.StringInput("mahalakom");
            //Thread.Sleep(1000);
            _keyboadHandler.KeyTyping(System.Windows.Forms.Keys.Tab);
            //Thread.Sleep(1000);
            _keyboadHandler.StringInput("mahalakom");
            Thread.Sleep(500);

            //_WiniumDriver.FindElementById("txtUserName").SendKeys("mahalakom");
            //Thread.Sleep(1000);
            //_WiniumDriver.FindElementById("txtPassword").SendKeys("mahalakom");
            //Thread.Sleep(1000);
            _WiniumDriver.FindElementById("btnSubmit").Click();

            Thread.Sleep(2000);
            //while (!_WiniumDriver.FindElementById("txtAccountId").Displayed)
            //{
            //    Thread.Sleep(2000);
            //    count++;
            //    if (count == 5) return;
            //}

            var sleepTime = 100;
            foreach (var accountId in _AccountIdList)
            {
                var accountIdString = Convert.ToString(accountId);
                _WiniumDriver.FindElementById("txtAccountId").SendKeys(accountIdString);

                Thread.Sleep(sleepTime);

                _WiniumDriver.FindElementById("btnFetch").Click();

                Thread.Sleep(sleepTime);

                _WiniumDriver.FindElementByName("Top Left Header Cell").Click();

                //_WiniumDriver.FindElementById("dgvAccountPaymentHistory").Click();

                Thread.Sleep(sleepTime);

                _WiniumDriver.FindElementById("btnClear").Click();

                Thread.Sleep(sleepTime);
            }

            _Service.Dispose();
            _WiniumDriver.Close();
            
        }

        private void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }
    }
}
