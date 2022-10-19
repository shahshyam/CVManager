using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using CVManager.CustomControl;
using CVManager.Helper;
using CVManager.Options;
using CVManager.CustomEvents;

namespace CVManager
{
    public partial class ThisAddIn
    {
        private CandidateUserControl candidateControl;
        private Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane;
        public Outlook.Explorer explorer;
        private string EntryId;
        public CandidateHandler CandidateHandler { get; set; }
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            var settngOption = ProcessData.GetData();
            CandidateHandler = new CandidateHandler();
            explorer = this.Application.ActiveExplorer();
            if (explorer != null)
            {
                explorer.SelectionChange += OnExplorerSelectionChange;
            }
            WebServiceHelper.Instance.InitService(settngOption.Url);
        }

        private void OnExplorerSelectionChange()
        {
            Outlook.MailItem mailItem = OutlookHelper.GetCurrentEmail();
            if (mailItem != null)
            {
                if (string.IsNullOrEmpty(EntryId) || EntryId != mailItem.EntryID)
                {
                    EntryId = mailItem.EntryID;
                    if (CustomTaskPanes.Count > 0)
                    {
                        CandidateHandler.OnEmailItemChanged(EntryId);
                        //candidateControl.LoadCandidateData();
                    }
                }
            }
        }

        protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new RibbonMailExplorer();
        }
        public void ProcessSideBarPanel(bool isVisible)
        {
            if (candidateControl == null)
            {
                candidateControl = new CandidateUserControl();
            }
            if (CustomTaskPanes.Count == 0)
            {
                myCustomTaskPane = this.CustomTaskPanes.Add(candidateControl, "CV Manager", this.Application.ActiveWindow());
                myCustomTaskPane.Width = 400;
            }
            if (isVisible)
                CandidateHandler.OnEmailItemChanged(EntryId);
            myCustomTaskPane.Visible = isVisible;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
