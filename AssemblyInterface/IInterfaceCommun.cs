using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInterface
{
    public interface IInterfaceCommun
    {
        void InitMethod(int iValue, double dValue, string sValue);

        string StringProperty { get; set; }
    }
}
