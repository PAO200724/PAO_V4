using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PAO.Test
{
    public class TestService : ITestService
    {
        public string GetString(string source) {
            return String.Format("源字符串: {0}", source);
        }
    }
}
