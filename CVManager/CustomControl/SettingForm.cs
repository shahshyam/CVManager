using CVManager.Helper;
using CVManager.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CVManager.CustomControl
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            this.Load += OnSettingFormLoaded;
        }

        private void OnSettingFormLoaded(object sender, EventArgs e)
        {
            string serviceUrl = WebServiceHelper.Instance.GetServieUrl();
            textBoxUrl.Text = serviceUrl;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxUrl.Text))
            {
                MessageBox.Show(CVManagerConstant.URL_INVALID_MESSAGE,CVManagerConstant.APPNAME,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            WebServiceHelper.Instance.InitService(textBoxUrl.Text.Trim());
            ProcessData.SaveData(new SettingOption() { Url = textBoxUrl.Text.Trim() });
            MessageBox.Show(CVManagerConstant.DATA_SAVE_MESSAGE,CVManagerConstant.APPNAME,MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
