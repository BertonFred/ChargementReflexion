using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblySample
{
    internal class ClassePrivate 
    {
        public ClassePrivate() 
        {
            InitMethod(1, 2, "Trois");
        }

        public ClassePrivate(int iValue, double dValue, string sValue)
        {
            InitMethod(iValue, dValue, sValue);
        }

        public void InitMethod(int iValue, double dValue, string sValue)
        {
            this.IntValue = iValue;
            this.DoubleValue = dValue;
            this.StringValue = sValue;
        }

        public int IntValue;
        public double DoubleValue;
        public string StringValue;

        public string StringProperty
        {
            get => StringValue;
            set => StringValue = value;
        }
    }
}
