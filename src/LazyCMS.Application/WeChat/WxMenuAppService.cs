using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 应用服务实例
    /// </summary>
    public class WxMenuAppService : AsyncCrudAppService<//定义了CRUD方法
        WxMenu, //数据实体
        WxMenuDto, //用来展示的dto对象
        Guid, //实体的主键
        PagedAndSortedResultRequestDto, //获取数据的时候用于分页和排序
        CreateUpdateWxMenuDto, //用于创建
        CreateUpdateWxMenuDto //用于更新
        >, IWxMenuAppService //自定义的应用服务
    {
        public WxMenuAppService(IRepository<WxMenu, Guid> repository)
            : base(repository)
        {

        }

        public List<WxMenuDto> GetAggregateRoot()
        {
            var list = Repository.GetList(true);
            return list.Select(MapToGetListOutputDto).ToList();
        }
    }
}
