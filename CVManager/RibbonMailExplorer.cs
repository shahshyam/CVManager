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
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

namespace CVManager
{
    [ComVisible(true)]
    public class RibbonMailExplorer : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

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
        public void ShowCVPanel(Office.IRibbonControl control)
        {
            if (IsValidateConfigUrl())
                Globals.ThisAddIn.ProcessSideBarPanel();
        }
        public void SearchCandidate(Office.IRibbonControl control)
        {
            if (IsValidateConfigUrl())
            {
                var mailItem = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1];
                OutlookHelper.SetCustomProperty(mailItem, "Yes");
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
