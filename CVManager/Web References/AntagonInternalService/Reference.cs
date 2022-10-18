﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace CVManager.AntagonInternalService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="AntagonInternalServicesSOAP", Namespace="http://antagon.com/AntagonInternalServices/")]
    public partial class AntagonInternalServices : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback updateCandidateCvWindowOperationCompleted;
        
        private System.Threading.SendOrPostCallback handleCandidateEmailOperationCompleted;
        
        private System.Threading.SendOrPostCallback addEmailAddressToJunkListOperationCompleted;
        
        private System.Threading.SendOrPostCallback removeEmailAddressFromJunkListOperationCompleted;
        
        private System.Threading.SendOrPostCallback enquiryEmailAddressOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AntagonInternalServices() {
            this.Url = global::CVManager.Properties.Settings.Default.CVManager_AntagonInternalService_AntagonInternalServices;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event updateCandidateCvWindowCompletedEventHandler updateCandidateCvWindowCompleted;
        
        /// <remarks/>
        public event handleCandidateEmailCompletedEventHandler handleCandidateEmailCompleted;
        
        /// <remarks/>
        public event addEmailAddressToJunkListCompletedEventHandler addEmailAddressToJunkListCompleted;
        
        /// <remarks/>
        public event removeEmailAddressFromJunkListCompletedEventHandler removeEmailAddressFromJunkListCompleted;
        
        /// <remarks/>
        public event enquiryEmailAddressCompletedEventHandler enquiryEmailAddressCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://antagon.com/AntagonInternalServices/updateCandidateCvWindow", RequestNamespace="http://antagon.com/AntagonInternalServicesTypes", ResponseNamespace="http://antagon.com/AntagonInternalServicesTypes", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("statusCode")]
        public int updateCandidateCvWindow(int candidateId, string cvWindowContent, out string statusMessage) {
            object[] results = this.Invoke("updateCandidateCvWindow", new object[] {
                        candidateId,
                        cvWindowContent});
            statusMessage = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void updateCandidateCvWindowAsync(int candidateId, string cvWindowContent) {
            this.updateCandidateCvWindowAsync(candidateId, cvWindowContent, null);
        }
        
        /// <remarks/>
        public void updateCandidateCvWindowAsync(int candidateId, string cvWindowContent, object userState) {
            if ((this.updateCandidateCvWindowOperationCompleted == null)) {
                this.updateCandidateCvWindowOperationCompleted = new System.Threading.SendOrPostCallback(this.OnupdateCandidateCvWindowOperationCompleted);
            }
            this.InvokeAsync("updateCandidateCvWindow", new object[] {
                        candidateId,
                        cvWindowContent}, this.updateCandidateCvWindowOperationCompleted, userState);
        }
        
        private void OnupdateCandidateCvWindowOperationCompleted(object arg) {
            if ((this.updateCandidateCvWindowCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.updateCandidateCvWindowCompleted(this, new updateCandidateCvWindowCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://antagon.com/AntagonInternalServices/handleCandidateEmail", RequestElementName="handleCandidateEmailRequest", RequestNamespace="http://antagon.com/AntagonInternalServicesTypes", ResponseNamespace="http://antagon.com/AntagonInternalServicesTypes", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("statusCode")]
        public int handleCandidateEmail(User currentUser, string senderEmailAddress, string senderName, [System.Xml.Serialization.XmlElementAttribute("attachments")] EmailAttachment[] attachments, string emailBody, string emailSubject, HandleCandidateEmailRequestTypeCandidateStatus candidateStatus, HandleCandidateEmailRequestTypeHandlingMode handlingMode, out string statusMessage, out DuplicationStatus duplicationStatus, out HandlingStatus handlindStatus, out ParsingStatus parsingStatus) {
            object[] results = this.Invoke("handleCandidateEmail", new object[] {
                        currentUser,
                        senderEmailAddress,
                        senderName,
                        attachments,
                        emailBody,
                        emailSubject,
                        candidateStatus,
                        handlingMode});
            statusMessage = ((string)(results[1]));
            duplicationStatus = ((DuplicationStatus)(results[2]));
            handlindStatus = ((HandlingStatus)(results[3]));
            parsingStatus = ((ParsingStatus)(results[4]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void handleCandidateEmailAsync(User currentUser, string senderEmailAddress, string senderName, EmailAttachment[] attachments, string emailBody, string emailSubject, HandleCandidateEmailRequestTypeCandidateStatus candidateStatus, HandleCandidateEmailRequestTypeHandlingMode handlingMode) {
            this.handleCandidateEmailAsync(currentUser, senderEmailAddress, senderName, attachments, emailBody, emailSubject, candidateStatus, handlingMode, null);
        }
        
        /// <remarks/>
        public void handleCandidateEmailAsync(User currentUser, string senderEmailAddress, string senderName, EmailAttachment[] attachments, string emailBody, string emailSubject, HandleCandidateEmailRequestTypeCandidateStatus candidateStatus, HandleCandidateEmailRequestTypeHandlingMode handlingMode, object userState) {
            if ((this.handleCandidateEmailOperationCompleted == null)) {
                this.handleCandidateEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnhandleCandidateEmailOperationCompleted);
            }
            this.InvokeAsync("handleCandidateEmail", new object[] {
                        currentUser,
                        senderEmailAddress,
                        senderName,
                        attachments,
                        emailBody,
                        emailSubject,
                        candidateStatus,
                        handlingMode}, this.handleCandidateEmailOperationCompleted, userState);
        }
        
        private void OnhandleCandidateEmailOperationCompleted(object arg) {
            if ((this.handleCandidateEmailCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.handleCandidateEmailCompleted(this, new handleCandidateEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://antagon.com/AntagonInternalServices/addEmailAddressToJunkList", RequestNamespace="http://antagon.com/AntagonInternalServicesTypes", ResponseNamespace="http://antagon.com/AntagonInternalServicesTypes", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("statusCode")]
        public int addEmailAddressToJunkList(User currentUser, string emailAddress, out string statusMessage) {
            object[] results = this.Invoke("addEmailAddressToJunkList", new object[] {
                        currentUser,
                        emailAddress});
            statusMessage = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void addEmailAddressToJunkListAsync(User currentUser, string emailAddress) {
            this.addEmailAddressToJunkListAsync(currentUser, emailAddress, null);
        }
        
        /// <remarks/>
        public void addEmailAddressToJunkListAsync(User currentUser, string emailAddress, object userState) {
            if ((this.addEmailAddressToJunkListOperationCompleted == null)) {
                this.addEmailAddressToJunkListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnaddEmailAddressToJunkListOperationCompleted);
            }
            this.InvokeAsync("addEmailAddressToJunkList", new object[] {
                        currentUser,
                        emailAddress}, this.addEmailAddressToJunkListOperationCompleted, userState);
        }
        
        private void OnaddEmailAddressToJunkListOperationCompleted(object arg) {
            if ((this.addEmailAddressToJunkListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.addEmailAddressToJunkListCompleted(this, new addEmailAddressToJunkListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://antagon.com/AntagonInternalServices/removeEmailAddressFromJunkList", RequestNamespace="http://antagon.com/AntagonInternalServicesTypes", ResponseNamespace="http://antagon.com/AntagonInternalServicesTypes", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("statusCode")]
        public int removeEmailAddressFromJunkList(User currentUser, string emailAddress, out string statusMessage) {
            object[] results = this.Invoke("removeEmailAddressFromJunkList", new object[] {
                        currentUser,
                        emailAddress});
            statusMessage = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void removeEmailAddressFromJunkListAsync(User currentUser, string emailAddress) {
            this.removeEmailAddressFromJunkListAsync(currentUser, emailAddress, null);
        }
        
        /// <remarks/>
        public void removeEmailAddressFromJunkListAsync(User currentUser, string emailAddress, object userState) {
            if ((this.removeEmailAddressFromJunkListOperationCompleted == null)) {
                this.removeEmailAddressFromJunkListOperationCompleted = new System.Threading.SendOrPostCallback(this.OnremoveEmailAddressFromJunkListOperationCompleted);
            }
            this.InvokeAsync("removeEmailAddressFromJunkList", new object[] {
                        currentUser,
                        emailAddress}, this.removeEmailAddressFromJunkListOperationCompleted, userState);
        }
        
        private void OnremoveEmailAddressFromJunkListOperationCompleted(object arg) {
            if ((this.removeEmailAddressFromJunkListCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.removeEmailAddressFromJunkListCompleted(this, new removeEmailAddressFromJunkListCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://antagon.com/AntagonInternalServices/enquiryEmailAddress", RequestNamespace="http://antagon.com/AntagonInternalServicesTypes", ResponseNamespace="http://antagon.com/AntagonInternalServicesTypes", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("statusCode")]
        public int enquiryEmailAddress(User currentUser, string emailAddress, out string statusMessage, out bool isCandidate, out bool isClient, out bool isJunk, out bool isJobBoard, out Candidate candidate) {
            object[] results = this.Invoke("enquiryEmailAddress", new object[] {
                        currentUser,
                        emailAddress});
            statusMessage = ((string)(results[1]));
            isCandidate = ((bool)(results[2]));
            isClient = ((bool)(results[3]));
            isJunk = ((bool)(results[4]));
            isJobBoard = ((bool)(results[5]));
            candidate = ((Candidate)(results[6]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void enquiryEmailAddressAsync(User currentUser, string emailAddress) {
            this.enquiryEmailAddressAsync(currentUser, emailAddress, null);
        }
        
        /// <remarks/>
        public void enquiryEmailAddressAsync(User currentUser, string emailAddress, object userState) {
            if ((this.enquiryEmailAddressOperationCompleted == null)) {
                this.enquiryEmailAddressOperationCompleted = new System.Threading.SendOrPostCallback(this.OnenquiryEmailAddressOperationCompleted);
            }
            this.InvokeAsync("enquiryEmailAddress", new object[] {
                        currentUser,
                        emailAddress}, this.enquiryEmailAddressOperationCompleted, userState);
        }
        
        private void OnenquiryEmailAddressOperationCompleted(object arg) {
            if ((this.enquiryEmailAddressCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.enquiryEmailAddressCompleted(this, new enquiryEmailAddressCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public partial class User {
        
        private string emailAddressField;
        
        /// <remarks/>
        public string emailAddress {
            get {
                return this.emailAddressField;
            }
            set {
                this.emailAddressField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public partial class Candidate {
        
        private long idField;
        
        private bool idFieldSpecified;
        
        private string firstNameField;
        
        private string lastNameField;
        
        private string[] contactField;
        
        private string addressField;
        
        private string postalCodeField;
        
        private string cityField;
        
        private string countryField;
        
        private System.DateTime dateOfBirthField;
        
        private bool dateOfBirthFieldSpecified;
        
        private string nationalityField;
        
        private string lastEditedByField;
        
        private System.DateTime lastEditedAtField;
        
        private bool lastEditedAtFieldSpecified;
        
        private string editURLField;
        
        /// <remarks/>
        public long id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool idSpecified {
            get {
                return this.idFieldSpecified;
            }
            set {
                this.idFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string firstName {
            get {
                return this.firstNameField;
            }
            set {
                this.firstNameField = value;
            }
        }
        
        /// <remarks/>
        public string lastName {
            get {
                return this.lastNameField;
            }
            set {
                this.lastNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("contact")]
        public string[] contact {
            get {
                return this.contactField;
            }
            set {
                this.contactField = value;
            }
        }
        
        /// <remarks/>
        public string address {
            get {
                return this.addressField;
            }
            set {
                this.addressField = value;
            }
        }
        
        /// <remarks/>
        public string postalCode {
            get {
                return this.postalCodeField;
            }
            set {
                this.postalCodeField = value;
            }
        }
        
        /// <remarks/>
        public string city {
            get {
                return this.cityField;
            }
            set {
                this.cityField = value;
            }
        }
        
        /// <remarks/>
        public string country {
            get {
                return this.countryField;
            }
            set {
                this.countryField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime dateOfBirth {
            get {
                return this.dateOfBirthField;
            }
            set {
                this.dateOfBirthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dateOfBirthSpecified {
            get {
                return this.dateOfBirthFieldSpecified;
            }
            set {
                this.dateOfBirthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string nationality {
            get {
                return this.nationalityField;
            }
            set {
                this.nationalityField = value;
            }
        }
        
        /// <remarks/>
        public string lastEditedBy {
            get {
                return this.lastEditedByField;
            }
            set {
                this.lastEditedByField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime lastEditedAt {
            get {
                return this.lastEditedAtField;
            }
            set {
                this.lastEditedAtField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool lastEditedAtSpecified {
            get {
                return this.lastEditedAtFieldSpecified;
            }
            set {
                this.lastEditedAtFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string editURL {
            get {
                return this.editURLField;
            }
            set {
                this.editURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public partial class ParsingStatus {
        
        private Candidate candidateField;
        
        private string candidateEditURLField;
        
        /// <remarks/>
        public Candidate candidate {
            get {
                return this.candidateField;
            }
            set {
                this.candidateField = value;
            }
        }
        
        /// <remarks/>
        public string candidateEditURL {
            get {
                return this.candidateEditURLField;
            }
            set {
                this.candidateEditURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public partial class HandlingStatus {
        
        private bool candidateCreatedField;
        
        private string candidateEditURLField;
        
        /// <remarks/>
        public bool candidateCreated {
            get {
                return this.candidateCreatedField;
            }
            set {
                this.candidateCreatedField = value;
            }
        }
        
        /// <remarks/>
        public string candidateEditURL {
            get {
                return this.candidateEditURLField;
            }
            set {
                this.candidateEditURLField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public partial class DuplicationStatus {
        
        private bool isDuplicateField;
        
        private string[] duplicateCandidatesEditURLsField;
        
        /// <remarks/>
        public bool isDuplicate {
            get {
                return this.isDuplicateField;
            }
            set {
                this.isDuplicateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("duplicateCandidatesEditURLs")]
        public string[] duplicateCandidatesEditURLs {
            get {
                return this.duplicateCandidatesEditURLsField;
            }
            set {
                this.duplicateCandidatesEditURLsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public partial class EmailAttachment {
        
        private byte[] attachmentField;
        
        private bool isPrimaryAttachmentField;
        
        private EmailAttachmentAttachmentType attachmentTypeField;
        
        private string fileNameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] attachment {
            get {
                return this.attachmentField;
            }
            set {
                this.attachmentField = value;
            }
        }
        
        /// <remarks/>
        public bool isPrimaryAttachment {
            get {
                return this.isPrimaryAttachmentField;
            }
            set {
                this.isPrimaryAttachmentField = value;
            }
        }
        
        /// <remarks/>
        public EmailAttachmentAttachmentType attachmentType {
            get {
                return this.attachmentTypeField;
            }
            set {
                this.attachmentTypeField = value;
            }
        }
        
        /// <remarks/>
        public string fileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public enum EmailAttachmentAttachmentType {
        
        /// <remarks/>
        CV,
        
        /// <remarks/>
        CERTIFICATE,
        
        /// <remarks/>
        PASSPORT,
        
        /// <remarks/>
        ID,
        
        /// <remarks/>
        OTHER,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public enum HandleCandidateEmailRequestTypeCandidateStatus {
        
        /// <remarks/>
        EXISTING,
        
        /// <remarks/>
        NON_EXISTING,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://antagon.com/AntagonInternalServicesTypes")]
    public enum HandleCandidateEmailRequestTypeHandlingMode {
        
        /// <remarks/>
        NEW,
        
        /// <remarks/>
        EDIT,
        
        /// <remarks/>
        CopyAllAndEmail,
        
        /// <remarks/>
        CopyAll,
        
        /// <remarks/>
        CopyCV,
        
        /// <remarks/>
        CopyCVAndEmail,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void updateCandidateCvWindowCompletedEventHandler(object sender, updateCandidateCvWindowCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class updateCandidateCvWindowCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal updateCandidateCvWindowCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string statusMessage {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void handleCandidateEmailCompletedEventHandler(object sender, handleCandidateEmailCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class handleCandidateEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal handleCandidateEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string statusMessage {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public DuplicationStatus duplicationStatus {
            get {
                this.RaiseExceptionIfNecessary();
                return ((DuplicationStatus)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public HandlingStatus handlindStatus {
            get {
                this.RaiseExceptionIfNecessary();
                return ((HandlingStatus)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public ParsingStatus parsingStatus {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ParsingStatus)(this.results[4]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void addEmailAddressToJunkListCompletedEventHandler(object sender, addEmailAddressToJunkListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class addEmailAddressToJunkListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal addEmailAddressToJunkListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string statusMessage {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void removeEmailAddressFromJunkListCompletedEventHandler(object sender, removeEmailAddressFromJunkListCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class removeEmailAddressFromJunkListCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal removeEmailAddressFromJunkListCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string statusMessage {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void enquiryEmailAddressCompletedEventHandler(object sender, enquiryEmailAddressCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class enquiryEmailAddressCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal enquiryEmailAddressCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string statusMessage {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public bool isCandidate {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public bool isClient {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[3]));
            }
        }
        
        /// <remarks/>
        public bool isJunk {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[4]));
            }
        }
        
        /// <remarks/>
        public bool isJobBoard {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[5]));
            }
        }
        
        /// <remarks/>
        public Candidate candidate {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Candidate)(this.results[6]));
            }
        }
    }
}

#pragma warning restore 1591