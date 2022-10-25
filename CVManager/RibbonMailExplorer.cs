using CVManager.Helper;
using CVManager.Options;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CVManager
{
    [ComVisible(true)]
    public class RibbonMailExplorer : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;
        private bool isPressed;
        private bool isAlreadyProcessingEmail = false;
        public RibbonMailExplorer()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            if (ribbonID == "Microsoft.Outlook.Explorer")
                return GetResourceText("CVManager.RibbonMailExplorer.xml");
            return null;
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }
        private bool IsValidateConfigUrl()
        {
            string serviceUrl = WebServiceHelper.Instance.GetServieUrl();
            string saveUrl = ProcessData.GetData().Url;
            if (string.Compare(serviceUrl, saveUrl, true) != 0)
            {
                MessageBox.Show(CVManagerConstant.URL_INVALID_CONFIG_MESSAGE,CVManagerConstant.APPNAME,MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public Bitmap GetImages(Office.IRibbonControl control)
        {
            switch (control.Id)
            {
                case "btnSetting":
                    return Properties.Resources.settings;                    
                case "btnViewCV":
                    return Properties.Resources.ViewCV;
                case "btnVerify":
                    return Properties.Resources.Verifycandidate;
            }
            return null;
        }
        public void GetSetting(Office.IRibbonControl control)
        {
            new CustomControl.SettingForm().ShowDialog();
        }
        public void ShowCVPanel(Office.IRibbonControl control,bool isPressed)
        {
            this.isPressed = isPressed;
            if (IsValidateConfigUrl())
                Globals.ThisAddIn.ProcessSideBarPanel(this.isPressed);
        }
        public bool GetPressItem(Office.IRibbonControl control)
        {
            return isPressed;
        }
        public string GetAppVersion(Office.IRibbonControl control)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return string.Format("Ver: {0}.{1}.{2}", version.Major , version.Minor , version.Build);
        }
        public async void SearchCandidate(Office.IRibbonControl control)
        {
            if (IsValidateConfigUrl())
            {
                var dialog = MessageBox.Show("Email Processing will take long time.\nDo you want to process it?", CVManagerConstant.APPNAME, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    isAlreadyProcessingEmail = true;
                    if (Globals.ThisAddIn.Application.Version.Contains("14"))
                    {
                        ProcessFolderItems();
                    }
                    else
                    {
                        await Task.Run(() =>
                        {
                            ProcessFolderItems();
                        });
                    }
                    isAlreadyProcessingEmail = false;
                    MessageBox.Show("Email(s) validation completed", CVManagerConstant.APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ProcessFolderItems()
        {
            Outlook.Folder folder = Globals.ThisAddIn.explorer.CurrentFolder as Outlook.Folder;
            Outlook.Items items = folder.Items;
            int itemsCount = items.Count;
            for (int i = 1; i <= itemsCount; i++)
            {
                var item = items[i];
                try
                {
                    if (item is Outlook.MailItem)
                    {
                        Outlook.MailItem mailItem = item as Outlook.MailItem;
                        string emailAddress = OutlookHelper.GetEmailAddress(mailItem);
                        if (WebServiceHelper.Instance.IsCandidateAvailable(emailAddress))
                            OutlookHelper.SetUserDefineProperty(mailItem, DateTime.Now.ToString("dd/MM/yyy"));
                        
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    OutlookHelper.ReleaseComObject(item);
                }
            }
        }
        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
