using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PAO.UI.MVC
{
    /// <summary>
    /// 接口：IDocumentContainer
    /// 文档容器
    /// 文档容器，用于容纳并显示文档
    /// 作者：PAO
    /// </summary>
    [Addon]
    [Name("文档容器")]
    [Description("文档容器，用于容纳并显示文档")]
    public interface IDocumentContainer
    {
        /// <summary>
        /// 打开文档
        /// </summary>
        /// <param name="document">文档</param>
        void OpenDocument(IDocument document);
    }
}
