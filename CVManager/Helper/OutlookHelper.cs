using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CVManager.Helper
{
    class OutlookHelper
    {
        const string PR_SMTP_ADDRESS = @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
        private static string _culumnName = "Customer";
        public static void SetCustomProperty(Outlook.MailItem mailItem, string values = "")
        {
            Outlook.Folder folder = Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder as Outlook.Folder;
            try
            {
                Microsoft.Office.Interop.Outlook.UserProperty up = mailItem.UserProperties[_culumnName];

                if (up == null)
                {
                    //Add UserProperty to PostItem 
                    mailItem.UserProperties.Add(_culumnName,
                        Outlook.OlUserPropertyType.olText,
                        false, Outlook.OlFormatEnumeration.olFormatEnumText);
                }
                mailItem.UserProperties[_culumnName].Value = values;
                mailItem.Save();
                var folderprop = folder.UserDefinedProperties[_culumnName];
                if (folderprop == null)
                {
                    folder.UserDefinedProperties.Add(_culumnName,
                           Outlook.OlUserPropertyType.olText,
                           Type.Missing, Type.Missing);

                    Outlook.TableView CurView = ((Outlook.TableView)folder.CurrentView);
                    var viewField = CurView.ViewFields.Add(_culumnName);
                    var columnFormat = viewField.ColumnFormat;
                    columnFormat.Align = Outlook.OlAlign.olAlignLeft;
                    //columnFormat.Width = 10;                    
                    columnFormat.Label = _culumnName;
                    CurView.Apply();
                    CurView.Save();
                }
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex.Message);
            }
        }
        public static Outlook.MailItem GetCurrentEmail()
        {
            var explorer = Globals.ThisAddIn.Application.ActiveExplorer();
            if (explorer != null && explorer.Selection.Count>0)
            {
                var mailItem = explorer.Selection[1];
                return mailItem;
            }
            return null;
        }
       
        public static string GetSenderEmailAddress()
        {
            string emailAddress = string.Empty;
            Outlook.MailItem mailItem = null;
            try
            {
                mailItem = GetCurrentEmail();
                if (mailItem == null)
                    return emailAddress;

                emailAddress = GetEmailAddress(mailItem);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                ReleaseComObject(mailItem);
            }
            return emailAddress;
        }
        public static string GetEmailAddress(Outlook.MailItem mailItem)
        {
            string emailAddress = string.Empty;
            try
            {
               
                if (mailItem == null)
                    return emailAddress;
                if (mailItem.SenderEmailType == "EX")
                {
                    Outlook.AddressEntry sender = mailItem.Sender;
                    if (sender != null)
                    {
                        //Now we have an AddressEntry representing the Sender
                        if (sender.AddressEntryUserType ==
                            Outlook.OlAddressEntryUserType.
                            olExchangeUserAddressEntry
                            || sender.AddressEntryUserType ==
                            Outlook.OlAddressEntryUserType.
                            olExchangeRemoteUserAddressEntry)
                        {
                            //Use the ExchangeUser object PrimarySMTPAddress
                            Outlook.ExchangeUser exchUser =
                                sender.GetExchangeUser();
                            if (exchUser != null)
                            {
                                return exchUser.PrimarySmtpAddress;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return sender.PropertyAccessor.GetProperty(
                                PR_SMTP_ADDRESS) as string;
                        }
                    }

                }
                else
                {
                    emailAddress = mailItem.SenderEmailAddress;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ReleaseComObject(mailItem);
            }
            return emailAddress;
        }
        public static void ReleaseComObject(object o)
        {
            if (o != null && Marshal.IsComObject(o))
                Marshal.ReleaseComObject(o);
        }
    }
}
