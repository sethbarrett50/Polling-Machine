using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polling_Station
{
    class Voter
    {
        private string _name;
        //String for name, private so confidential
        public int _age
        {
            set;get;
        }
        //Property to represent the voter's age.
        public Voter(string name)
        {
            _name = name;
        }
        //Creator for Voter class
    }
}
