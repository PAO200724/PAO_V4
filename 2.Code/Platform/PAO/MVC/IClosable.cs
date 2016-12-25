using PAO.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.MVC
{
    /// <summary>
    /// 接口：IClosable
    /// 可关闭
    /// 可关闭接口
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("可关闭")]
    [Description("可关闭接口")]
    public interface IClosable
    {
        bool Close(DialogReturn dialogReturn);
    }
}
