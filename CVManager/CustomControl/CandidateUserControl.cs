using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CVManager.Helper;

namespace CVManager.CustomControl
{
    public partial class CandidateUserControl : UserControl
    {
        public CandidateUserControl()
        {
            InitializeComponent();
            this.Load += OnCandidateUserControlLoaded;
            Globals.ThisAddIn.CandidateHandler.OnRefreshCandidateData += OnRefreshCandidateData;
        }

        private void OnRefreshCandidateData(object sender, string e)
        {
            LoadCandidateData();
        }

        private void OnCandidateUserControlLoaded(object sender, EventArgs e)
        {
           //TODO:
        }

        private void LoadCandidateData()
        {
            string statusMessage = string.Empty;
            ReSetCandidateData();
            var candidate = WebServiceHelper.Instance.EnquiryEmailAddressCall(out statusMessage);
            if (candidate.id > 0)
            {
                labelID.Text = candidate.id.ToString();
                string fullname = string.Format("{0} {1}", candidate.firstName, candidate.lastName);
                labelFullName.Text = fullname;
                labelContact.Text = string.Join(",", candidate.contact);
                var ageyear = DateTime.Now.Year - candidate.dateOfBirth.Year;
                labelDob.Text = string.Format("{0} - ({1})", candidate.dateOfBirth.ToString("dd/MM/yyy"), ageyear);
                labelNationality.Text = candidate.nationality;
                labelLeB.Text = string.Format("{0}\n{1}\n{2}", candidate.lastEditedBy.ToString(), candidate.lastEditedAt.ToString("dd/MM/yyy"), candidate.lastEditedAt.ToString("HH:MM"));
                // labelLeAt.Text = candidate.lastEditedAt.ToString();
                labelEUrl.Text = candidate.editURL;
                var data = fullname.Split(' ');
                string resultdata = string.Empty;
                resultdata = data.Length > 2 ? string.Format("{0} {1}", data[0], data[data.Length - 1]) : fullname;
                labelDetail.Text = string.Format("{0} - CV - {1} - 2", candidate.id, resultdata);
            }
            else
            {
                MessageBox.Show("Candidate does not exists", CVManagerConstant.APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonID_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("ID: {0}", labelID.Text));
        }

        private void buttonFullName_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("Name: {0}", labelFullName.Text));
        }

        private void buttonCantact_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("Contact: {0}", labelContact.Text));
        }

        private void buttonBirthday_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("DOB: {0}", labelDob.Text));
        }

        private void buttonNationality_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("Nationality: {0}", labelNationality.Text));
        }

        private void buttonLastEdit_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("Last Edited: {0}", labelLeB.Text));
        }

        private void buttonEditUrl_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("URL: {0}", labelEUrl.Text));
        }

        private void buttonDetail_Click(object sender, EventArgs e)
        {
            CopyData(string.Format("File: {0}", labelDetail.Text));
        }
        private void ReSetCandidateData()
        {
            labelID.Text = string.Empty;
            labelFullName.Text = string.Empty;
            labelContact.Text = string.Empty;
            labelDob.Text = string.Empty;
            labelNationality.Text = string.Empty;
            labelLeB.Text = string.Empty;
            labelEUrl.Text = string.Empty;
            labelDetail.Text = string.Empty;
        }
        private void CopyData(string data)
        {
            Clipboard.SetText(data);
        }
    }
}
