﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsTest.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 interfaceName 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateInterfaceRealtimeInfoService", ReplyAction="*")]
        WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponse UpdateInterfaceRealtimeInfoService(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateInterfaceRealtimeInfoService", ReplyAction="*")]
        System.Threading.Tasks.Task<WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponse> UpdateInterfaceRealtimeInfoServiceAsync(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest request);
        
        // CODEGEN: 命名空间 http://tempuri.org/ 的元素名称 interfaceName 以后生成的消息协定未标记为 nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateInterfaceRealtimeInfoWithExceptionService", ReplyAction="*")]
        WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponse UpdateInterfaceRealtimeInfoWithExceptionService(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateInterfaceRealtimeInfoWithExceptionService", ReplyAction="*")]
        System.Threading.Tasks.Task<WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponse> UpdateInterfaceRealtimeInfoWithExceptionServiceAsync(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateInterfaceRealtimeInfoServiceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateInterfaceRealtimeInfoService", Namespace="http://tempuri.org/", Order=0)]
        public WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequestBody Body;
        
        public UpdateInterfaceRealtimeInfoServiceRequest() {
        }
        
        public UpdateInterfaceRealtimeInfoServiceRequest(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateInterfaceRealtimeInfoServiceRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string interfaceName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string applicationName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string server;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int stateCode;
        
        public UpdateInterfaceRealtimeInfoServiceRequestBody() {
        }
        
        public UpdateInterfaceRealtimeInfoServiceRequestBody(string interfaceName, string applicationName, string server, int stateCode) {
            this.interfaceName = interfaceName;
            this.applicationName = applicationName;
            this.server = server;
            this.stateCode = stateCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateInterfaceRealtimeInfoServiceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateInterfaceRealtimeInfoServiceResponse", Namespace="http://tempuri.org/", Order=0)]
        public WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponseBody Body;
        
        public UpdateInterfaceRealtimeInfoServiceResponse() {
        }
        
        public UpdateInterfaceRealtimeInfoServiceResponse(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UpdateInterfaceRealtimeInfoServiceResponseBody {
        
        public UpdateInterfaceRealtimeInfoServiceResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateInterfaceRealtimeInfoWithExceptionServiceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateInterfaceRealtimeInfoWithExceptionService", Namespace="http://tempuri.org/", Order=0)]
        public WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody Body;
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceRequest() {
        }
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceRequest(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string interfaceName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string applicationName;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string server;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int stateCode;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string exceptionInfo;
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody() {
        }
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo) {
            this.interfaceName = interfaceName;
            this.applicationName = applicationName;
            this.server = server;
            this.stateCode = stateCode;
            this.exceptionInfo = exceptionInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UpdateInterfaceRealtimeInfoWithExceptionServiceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UpdateInterfaceRealtimeInfoWithExceptionServiceResponse", Namespace="http://tempuri.org/", Order=0)]
        public WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponseBody Body;
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceResponse() {
        }
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceResponse(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class UpdateInterfaceRealtimeInfoWithExceptionServiceResponseBody {
        
        public UpdateInterfaceRealtimeInfoWithExceptionServiceResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : WindowsFormsTest.ServiceReference1.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<WindowsFormsTest.ServiceReference1.WebService1Soap>, WindowsFormsTest.ServiceReference1.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponse WindowsFormsTest.ServiceReference1.WebService1Soap.UpdateInterfaceRealtimeInfoService(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest request) {
            return base.Channel.UpdateInterfaceRealtimeInfoService(request);
        }
        
        public void UpdateInterfaceRealtimeInfoService(string interfaceName, string applicationName, string server, int stateCode) {
            WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest inValue = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest();
            inValue.Body = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequestBody();
            inValue.Body.interfaceName = interfaceName;
            inValue.Body.applicationName = applicationName;
            inValue.Body.server = server;
            inValue.Body.stateCode = stateCode;
            WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponse retVal = ((WindowsFormsTest.ServiceReference1.WebService1Soap)(this)).UpdateInterfaceRealtimeInfoService(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponse> WindowsFormsTest.ServiceReference1.WebService1Soap.UpdateInterfaceRealtimeInfoServiceAsync(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest request) {
            return base.Channel.UpdateInterfaceRealtimeInfoServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceResponse> UpdateInterfaceRealtimeInfoServiceAsync(string interfaceName, string applicationName, string server, int stateCode) {
            WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest inValue = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequest();
            inValue.Body = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoServiceRequestBody();
            inValue.Body.interfaceName = interfaceName;
            inValue.Body.applicationName = applicationName;
            inValue.Body.server = server;
            inValue.Body.stateCode = stateCode;
            return ((WindowsFormsTest.ServiceReference1.WebService1Soap)(this)).UpdateInterfaceRealtimeInfoServiceAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponse WindowsFormsTest.ServiceReference1.WebService1Soap.UpdateInterfaceRealtimeInfoWithExceptionService(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest request) {
            return base.Channel.UpdateInterfaceRealtimeInfoWithExceptionService(request);
        }
        
        public void UpdateInterfaceRealtimeInfoWithExceptionService(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo) {
            WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest inValue = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest();
            inValue.Body = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody();
            inValue.Body.interfaceName = interfaceName;
            inValue.Body.applicationName = applicationName;
            inValue.Body.server = server;
            inValue.Body.stateCode = stateCode;
            inValue.Body.exceptionInfo = exceptionInfo;
            WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponse retVal = ((WindowsFormsTest.ServiceReference1.WebService1Soap)(this)).UpdateInterfaceRealtimeInfoWithExceptionService(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponse> WindowsFormsTest.ServiceReference1.WebService1Soap.UpdateInterfaceRealtimeInfoWithExceptionServiceAsync(WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest request) {
            return base.Channel.UpdateInterfaceRealtimeInfoWithExceptionServiceAsync(request);
        }
        
        public System.Threading.Tasks.Task<WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceResponse> UpdateInterfaceRealtimeInfoWithExceptionServiceAsync(string interfaceName, string applicationName, string server, int stateCode, string exceptionInfo) {
            WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest inValue = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequest();
            inValue.Body = new WindowsFormsTest.ServiceReference1.UpdateInterfaceRealtimeInfoWithExceptionServiceRequestBody();
            inValue.Body.interfaceName = interfaceName;
            inValue.Body.applicationName = applicationName;
            inValue.Body.server = server;
            inValue.Body.stateCode = stateCode;
            inValue.Body.exceptionInfo = exceptionInfo;
            return ((WindowsFormsTest.ServiceReference1.WebService1Soap)(this)).UpdateInterfaceRealtimeInfoWithExceptionServiceAsync(inValue);
        }
    }
}