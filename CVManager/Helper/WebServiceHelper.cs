using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVManager.Helper
{
    public sealed class WebServiceHelper
    {
        private static readonly WebServiceHelper instance = new WebServiceHelper();
        private AntagonInternalService.AntagonInternalServices _antagonWs;

        static WebServiceHelper()
        {
        }

        private WebServiceHelper()
        {
        }

        public static WebServiceHelper Instance
        {
            get
            {
                return instance;
            }
        }

        public string GetServieUrl()
        {
            return _antagonWs != null ? _antagonWs.Url : string.Empty;
        }
        public void InitService(string url = null)
        {
            if (_antagonWs == null)
                _antagonWs = new AntagonInternalService.AntagonInternalServices();
            if (!string.IsNullOrEmpty(url))
                _antagonWs.Url = url;           
        }
        public AntagonInternalService.Candidate EnquiryEmailAddressCall(out string statusMessage)
        {           
            var candidate = new AntagonInternalService.Candidate();
           
            bool isCandidate = false, isClient = false, isJunk = false, isJobBoard = false;
            int statusCode = 0; statusMessage = string.Empty;
            try
            {
                string emailAddress = OutlookHelper.GetSenderEmailAddress(); //"senthilbtech2002@gmail.com";
                statusCode = _antagonWs.enquiryEmailAddress(GetUser(emailAddress), emailAddress,
                    out statusMessage, out isCandidate, out isClient, out isJunk, out isJobBoard, out candidate);

                if (statusCode == 1)
                {
                    //ErrorBox eb = new ErrorBox(statusMessage);
                    //eb.ShowDialog();
                    return candidate;
                }
            }
            catch(Exception ex)
            {

            }
            return candidate;
            
        }
        public bool IsCandidateAvailable(string emailAddress)
        {
            var candidate = new AntagonInternalService.Candidate();

            bool isCandidate = false, isClient = false, isJunk = false, isJobBoard = false;            
            int statusCode = 0; string statusMessage = null;
            try
            {
                statusCode = _antagonWs.enquiryEmailAddress(GetUser(emailAddress), emailAddress,
                    out statusMessage, out isCandidate, out isClient, out isJunk, out isJobBoard, out candidate);

                return statusCode == 0 && isCandidate;
            }
            catch(Exception ex)
            {

            }
            return false;
        }
        private AntagonInternalService.User GetUser(string emailAddress)
        {
            try
            {
                var aUser = new AntagonInternalService.User();
                aUser.emailAddress = emailAddress;
                return aUser;
            }
            catch { return null; }
        }
        public bool IsCandidateExist(string emailAdress)
        {
            return false;
        }
    }
}
