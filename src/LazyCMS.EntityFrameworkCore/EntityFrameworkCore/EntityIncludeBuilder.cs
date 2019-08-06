using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LazyCMS.EntityFrameworkCore
{
    /// <summary>
    /// 实体导航包含构建器
    /// </summary>
    public class EntityIncludeBuilder
    {
        private static EntityIncludeBuilder _instance;
        public static EntityIncludeBuilder Instance
        {
            get
            {
                if (_instance == null) _instance = new EntityIncludeBuilder();
                return _instance;
            }
        }

        /// <summary>
        /// 通过反射创建委托
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public Delegate Create(Type entityType)
        {
            var EntityOptions = typeof(EntityOptions<>).MakeGenericType(entityType);
            var optionsAction = typeof(Action<>).MakeGenericType(EntityOptions);

            var method = (typeof(EntityIncludeBuilder) as System.Reflection.TypeInfo).DeclaredMethods.FirstOrDefault(t => t.Name.Equals("EntityAutoInclude"))
                .MakeGenericMethod(entityType);

            return Delegate.CreateDelegate(optionsAction, this, method);
        }

        /// <summary>
        /// 实体自动导航包含方法
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="options"></param>
        void EntityAutoInclude<TEntity>(EntityOptions<TEntity> options)
            where TEntity : class, Volo.Abp.Domain.Entities.IEntity
        {
            options.DefaultWithDetailsFunc = p =>
            {
                var ti = typeof(TEntity) as System.Reflection.TypeInfo;

                var proList = ti.DeclaredProperties.Where(t => t.GetMethod.IsPublic && t.GetMethod.IsVirtual);

                foreach (PropertyInfo pi in proList)
                {
                    p = p.Include(pi.Name);
                }
                return p;
            };
        }
    }
}
