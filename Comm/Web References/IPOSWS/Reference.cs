﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.5477
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.CompactFramework.Design.Data 2.0.50727.5477 版自动生成。
// 
namespace Comm.IPOSWS {
    using System.Diagnostics;
    using System.Web.Services;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="POSWSSoap", Namespace="http://tempuri.org/")]
    public partial class POSWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        /// <remarks/>
        public POSWS() {
            this.Url = "http://localhost:18295/POSWS.asmx";
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginHelloWorld(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("HelloWorld", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndHelloWorld(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Trade", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Trade(string saleJson, string salePayJson, string salePluJson) {
            object[] results = this.Invoke("Trade", new object[] {
                        saleJson,
                        salePayJson,
                        salePluJson});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginTrade(string saleJson, string salePayJson, string salePluJson, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Trade", new object[] {
                        saleJson,
                        salePayJson,
                        salePluJson}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndTrade(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Logon", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Logon(string userCode, string mpassword) {
            object[] results = this.Invoke("Logon", new object[] {
                        userCode,
                        mpassword});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLogon(string userCode, string mpassword, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Logon", new object[] {
                        userCode,
                        mpassword}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndLogon(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetGoods", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetGoods(string code) {
            object[] results = this.Invoke("GetGoods", new object[] {
                        code});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetGoods(string code, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetGoods", new object[] {
                        code}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetGoods(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPayType", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetPayType() {
            object[] results = this.Invoke("GetPayType", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetPayType(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetPayType", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndGetPayType(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
    }
}