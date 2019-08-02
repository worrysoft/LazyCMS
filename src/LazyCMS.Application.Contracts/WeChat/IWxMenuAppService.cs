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
            WxMenuDto, //用来展示书籍
            Guid, //Book实体的主键
            PagedAndSortedResultRequestDto, //获取书籍的时候用于分页和排序
            CreateUpdateWxMenuDto, //用于创建书籍
            CreateUpdateWxMenuDto> //用于更新书籍
    {

    }
}
