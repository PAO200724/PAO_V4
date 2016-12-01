using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PAO.UI.WinForm.Controls;
using System.Collections;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 列表编辑控件
    /// </summary>
    public partial class ListEditControl : DialogControl
    {
        public ListEditControl() {
            InitializeComponent();
        }

        private List<ListElement> AddonList;
        private IList SourceList;
        public object SelectedObject {
            get {
                if (SourceList == null)
                    return null;

                for(int i=0;i<SourceList.Count;i++) {
                    SourceList[i] = AddonList[i].Element;
                }
                return SourceList;
            }

            set {
                if (value == null) {
                    this.BindingSourceList.DataSource = null;
                }
                else if (!(value is IList)) {
                    throw new Exception("列表编辑器只支持插件列表的编辑。");
                }
                else {
                    SourceList = value as IList;
                    AddonList = new List<ListElement>();
                    int i = 0;
                    foreach (var addon in SourceList) {
                        AddonList.Add(new ListElement()
                        {
                            Index = i,
                            Element = (PaoObject)addon
                        });
                    }
                    this.BindingSourceList.DataSource = AddonList;
                }
            }
        }
    }
    internal class ListElement
    {
        internal int Index { get; set; }
        internal PaoObject Element { get; set; }
        public ListElement() {

        }
    }
}
