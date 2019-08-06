using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LazyCMS.WeChat
{
    /// <summary>
    /// 微信菜单应用服务
    /// </summary>
    public interface IWxMenuAppService :
        IAsyncCrudAppService< //定义了CRUD方法
            WxMenuDto, //用来展示数据
            Guid, //实体的主键
            PagedAndSortedResultRequestDto, //获取数据的时候用于分页和排序
            CreateUpdateWxMenuDto, //用于创建
            CreateUpdateWxMenuDto> //用于更新
    {
        List<WxMenuDto> GetAggregateRoot();
    }
}
