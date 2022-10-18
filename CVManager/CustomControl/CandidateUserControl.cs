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
        }

        private void OnCandidateUserControlLoaded(object sender, EventArgs e)
        {
           //TODO:
        }

        public void LoadCandidateData()
        {
            string statusMessage = string.Empty;
            var candidate = WebServiceHelper.Instance.EnquiryEmailAddressCall(out statusMessage);
            if (candidate != null)
            {
                labelID.Text = candidate.id.ToString();
                string fullname = string.Format("{0} {1}", candidate.firstName, candidate.lastName);
                labelFullName.Text = fullname;
                labelContact.Text = string.Join(",",candidate.contact);
                var ageyear = DateTime.Now.Year - candidate.dateOfBirth.Year;
                labelDob.Text = string.Format("{0} ({1})", candidate.dateOfBirth.ToShortDateString(), ageyear);               
                labelNationality.Text = candidate.nationality;
                labelLeB.Text = string.Format("{0}\n{1}\n{2}",candidate.lastEditedBy.ToString(), candidate.lastEditedAt.ToShortDateString(), candidate.lastEditedAt.ToShortTimeString());
               // labelLeAt.Text = candidate.lastEditedAt.ToString();
                labelEUrl.Text = candidate.editURL;
                var data = fullname.Split(' ');
                string resultdata = string.Empty;
                resultdata = data.Length > 2 ? string.Format("{0} {1}", data[0], data[data.Length - 1]) : fullname;
                labelDetail.Text = string.Format("{0} - CV - {1} - 2", candidate.id, resultdata);
                
            }
            else
            {
                MessageBox.Show(statusMessage, CVManagerConstant.APPNAME, MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
       
    }
}
