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
using PAO.App;

namespace PAO.Config.Controls
{
    /// <summary>
    /// 类型选择控件
    /// </summary>
    public partial class TypeSelectControl : DialogControl
    {
        const int ImageIndex_Selected = 0;
        const int ImageIndex_Ref = 1;
        const int ImageIndex_Class = 2;
        const int ImageIndex_Interface = 3;
        const int ImageIndex_Abstract = 4;

        public TypeSelectControl() {
            InitializeComponent();
            Text = "类型选择";
            ShowCancelButton = true;
        }

        /// <summary>
        /// 根据类型过滤器初始化
        /// </summary>
        /// <param name="typeFilter">类型过滤器</param>
        public void Initialize(Func<Type, bool> typeFilter = null) {
            if (typeFilter == null)
                Initialize(AddonPublic.AddonTypeList);
            else
                Initialize(AddonPublic.AddonTypeList.Where(typeFilter));
        }

        /// <summary>
        /// 根据类型结构初始化
        /// </summary>
        /// <param name="typeList">类型列表</param>
        public void Initialize(IEnumerable<Type> typeList) {
            var types = typeList.Select(p => {
                int imageIndex = ImageIndex_Class;
                if (p.IsInterface) {
                    imageIndex = ImageIndex_Interface;
                }
                else if (p.IsAbstract) {
                    imageIndex = ImageIndex_Abstract;
                }
                else if (p.IsDerivedFrom(typeof(Ref<>))) {
                    imageIndex = ImageIndex_Ref;
                }
                var displayAttr = p.GetAttribute<DisplayNameAttribute>(false);
                return new
                {
                    TypeName = p.GetTypeString(),
                    Type = p,
                    ParentTypeName = p.BaseType == null? null : p.BaseType.GetTypeString(),
                    ImageIndex = imageIndex,
                    DisplayName = displayAttr==null? p.GetTypeString() : displayAttr.DisplayName,
                    Namespace = p.Namespace
                };
            });
            this.BindingSourceTypes.DataSource = types;
        }

        public Type SelectedType {
            get {
                if(this.TressListType.FocusedNode == null) {
                    return null;
                }

                return (Type)this.TressListType.FocusedNode.GetValue("Type");
            }
        }
        
        public override void SetFormState(Form form) {
            form.WindowState = FormWindowState.Maximized;
        }
    }
}
