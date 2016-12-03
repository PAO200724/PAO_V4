using PAO;
using PAO.IO;
using PAO.IO.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace MainTest.Lang.IO {
    /// <summary>
    /// IOTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class IOTestWindow : Window {
        public IOTestWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var myObj = new MyGenericClass<int>()
            {
                Member1 = 993,
                StringMember = "Test Member",
                ObjectMember = new MyGenericClass<string>()
                {
                    Member1 = "Child Member"
                },
                NotMember = "Not Member",
                LazyMember = new MyGenericClass<string>()
                {
                    Member1 = "Lazy Member"
                }.ToRef()
            };
            TextBlock.Text = TextPublic.ObjectToText(myObj);

            var clonObj = TextPublic.TextToObject(TextBlock.Text) as MyGenericClass<int>;
            MessageBox.Show(clonObj.LazyMember.ToString());
        }
    }
}
