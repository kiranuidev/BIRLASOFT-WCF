﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="MathService")]
public interface MathService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MathService/AddNumber", ReplyAction="http://tempuri.org/MathService/AddNumberResponse")]
    int AddNumber(int dblX, int dblY);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/MathService/AddNumber", ReplyAction="http://tempuri.org/MathService/AddNumberResponse")]
    System.Threading.Tasks.Task<int> AddNumberAsync(int dblX, int dblY);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface MathServiceChannel : MathService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MathServiceClient : System.ServiceModel.ClientBase<MathService>, MathService
{
    
    public MathServiceClient()
    {
    }
    
    public MathServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public MathServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MathServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MathServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int AddNumber(int dblX, int dblY)
    {
        return base.Channel.AddNumber(dblX, dblY);
    }
    
    public System.Threading.Tasks.Task<int> AddNumberAsync(int dblX, int dblY)
    {
        return base.Channel.AddNumberAsync(dblX, dblY);
    }
}
