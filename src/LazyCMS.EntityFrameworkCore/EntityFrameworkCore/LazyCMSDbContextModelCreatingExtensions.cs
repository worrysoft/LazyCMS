using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.Users;
using System.Linq;
using System.Linq.Expressions;
using System;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LazyCMS.EntityFrameworkCore
{
    public static class LazyCMSDbContextModelCreatingExtensions
    {
        public static void ConfigureLazyCMS(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(LazyCMSConsts.DbTablePrefix + "YourEntities", LazyCMSConsts.DbSchema);

            //    //...
            //});

            /*
             * 从当前程序集中注册指定接口的实体实例
             * IAutoBuildEntity 实例
             */
            var domainAssemblies = System.AppDomain.CurrentDomain.GetAssemblies().Where(t => t.FullName.StartsWith("LazyCMS."));
            var autoBuildEntities = domainAssemblies.SelectMany(s => s.ExportedTypes).Where(t => typeof(Interface.IAutoBuildEntity).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

            foreach (Type entityType in autoBuildEntities)
            {
                builder.Entity(entityType, (b) =>
                {
                    b.ToTable($"{LazyCMSConsts.DbTablePrefix}_{entityType.Name}", LazyCMSConsts.DbSchema);
                    b.TryConfigureFullAudited();
                    b.TryConfigureExtraProperties();
                    b.TryConfigureConcurrencyStamp();
                });
            }
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}