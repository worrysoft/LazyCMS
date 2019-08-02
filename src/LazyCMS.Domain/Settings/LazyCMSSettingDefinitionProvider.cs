using Volo.Abp.Settings;

namespace LazyCMS.Settings
{
    public class LazyCMSSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LazyCMSSettings.MySetting1));
        }
    }
}
