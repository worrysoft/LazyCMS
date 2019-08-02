using LazyCMS.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LazyCMS.Permissions
{
    public class LazyCMSPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LazyCMSPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(LazyCMSPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LazyCMSResource>(name);
        }
    }
}
