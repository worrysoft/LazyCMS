using System;
using System.Collections.Generic;
using System.Text;
using LazyCMS.Localization;
using Volo.Abp.Application.Services;

namespace LazyCMS
{
    /* Inherit your application services from this class.
     */
    public abstract class LazyCMSAppService : ApplicationService
    {
        protected LazyCMSAppService()
        {
            LocalizationResource = typeof(LazyCMSResource);
        }
    }
}
