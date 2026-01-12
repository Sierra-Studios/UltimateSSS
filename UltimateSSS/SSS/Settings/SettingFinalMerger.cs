using UserSettings.ServerSpecific;

namespace UltimateSSS.SSS.Settings;

public abstract class SettingFinalMerger<T> : SettingMerger where T : ServerSpecificSettingBase
{
    private T _base;
    
    public T Base
    {
        get => _base;
        set
        {
            PreBase = value;
            _base = value;
        } 
    }
    
    public sealed override ServerSpecificSettingBase PreBase
    {
        get => _base;
        set => _base = value as T;
    }
}