﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectServiceClient.DiffFilesInterfaceRef {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DiffFilesInterfaceRef.IDiffFilesInterface")]
    public interface IDiffFilesInterface {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiffFilesInterface/calculateLevenhstein", ReplyAction="http://tempuri.org/IDiffFilesInterface/calculateLevenhsteinResponse")]
        double calculateLevenhstein(string s, string t);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiffFilesInterface/calculateLevenhstein", ReplyAction="http://tempuri.org/IDiffFilesInterface/calculateLevenhsteinResponse")]
        System.Threading.Tasks.Task<double> calculateLevenhsteinAsync(string s, string t);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiffFilesInterface/percentCalculate", ReplyAction="http://tempuri.org/IDiffFilesInterface/percentCalculateResponse")]
        double percentCalculate(double distanceLevenhstein, double firstTextLenght);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDiffFilesInterface/percentCalculate", ReplyAction="http://tempuri.org/IDiffFilesInterface/percentCalculateResponse")]
        System.Threading.Tasks.Task<double> percentCalculateAsync(double distanceLevenhstein, double firstTextLenght);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDiffFilesInterfaceChannel : ProjectServiceClient.DiffFilesInterfaceRef.IDiffFilesInterface, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DiffFilesInterfaceClient : System.ServiceModel.ClientBase<ProjectServiceClient.DiffFilesInterfaceRef.IDiffFilesInterface>, ProjectServiceClient.DiffFilesInterfaceRef.IDiffFilesInterface {
        
        public DiffFilesInterfaceClient() {
        }
        
        public DiffFilesInterfaceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DiffFilesInterfaceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiffFilesInterfaceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DiffFilesInterfaceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double calculateLevenhstein(string s, string t) {
            return base.Channel.calculateLevenhstein(s, t);
        }
        
        public System.Threading.Tasks.Task<double> calculateLevenhsteinAsync(string s, string t) {
            return base.Channel.calculateLevenhsteinAsync(s, t);
        }
        
        public double percentCalculate(double distanceLevenhstein, double firstTextLenght) {
            return base.Channel.percentCalculate(distanceLevenhstein, firstTextLenght);
        }
        
        public System.Threading.Tasks.Task<double> percentCalculateAsync(double distanceLevenhstein, double firstTextLenght) {
            return base.Channel.percentCalculateAsync(distanceLevenhstein, firstTextLenght);
        }
    }
}
