using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMandatory.Items
{
    public class ShieldF
    {
        public string ShieldName
        {
            get { return "Wooden sheield"; }
        }

        public double DefenseModifier
        {
            get { return 40; }
            set => throw new NotImplementedException();
        }


        public ShieldF()
        {

        }
    }
}
