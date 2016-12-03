using PAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLibrary
{
    public class TestService : PaoObject, ITestService
    {
        public string GetString(string source) {
            if (source == "Exception")
                throw new Exception("服务端测试异常");
            return String.Format("源字符串: {0}", source);
        }
    }
}
