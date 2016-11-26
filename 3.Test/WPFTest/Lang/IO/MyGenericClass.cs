using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using PAO;

namespace MainTest.Lang.IO {
    [DataContract(Namespace = "")]
    public class MyGenericClass<T> : PaoObject {
        [DataMember(EmitDefaultValue = false)]
        public T Member1 {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false)]
        public string StringMember {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false)]
        public object ObjectMember {
            get;
            set;
        }

        [DataMember(EmitDefaultValue = false)]
        public Ref<object> LazyMember {
            get;
            set;
        }

        public string NotMember {
            get;
            set;
        }
    }
}
