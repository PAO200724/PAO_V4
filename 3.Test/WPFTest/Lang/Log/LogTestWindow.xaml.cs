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
using PAO;
using PAO.Event;

namespace MainTest.Lang.Log {
    /// <summary>
    /// LogTestWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LogTestWindow : Window {
        public LogTestWindow() {
            InitializeComponent();
        }

        private void Window_Activated(object sender, EventArgs e) {
            EventPublic.Information("Window_Activated");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            EventPublic.Information("Window_Loaded");
        }

        private void Window_Initialized(object sender, EventArgs e) {
            EventPublic.Information("Window_Initialized");
        }

        private void LogExceptionButton_Click(object sender, RoutedEventArgs e) {
            try {
                throw new Exception("TestException").AddExceptionData("测试", "测试信息");
            }
            catch (Exception err) {
                EventPublic.Exception(err);
                MessageBox.Show("异常记录完成");
            }
        }

        private void LogWarningButton_Click(object sender, RoutedEventArgs e) {
            EventPublic.Warning("警告");
            MessageBox.Show("警告记录完成");
        }
    }
}
