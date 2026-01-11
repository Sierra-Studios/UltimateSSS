using System;

namespace UltimateSSS.SSS.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
public class OptionalSetting : Attribute
{
    
}