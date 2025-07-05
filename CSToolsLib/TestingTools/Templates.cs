using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSToolsLib
{


    internal class EmptyClass
    {

        public EmptyClass() 
        { 
        }

    }
    namespace Test2
    {

    }
}

namespace CSToolsLib
{
    public class Customer
    {
        private string name;
        private string billingAdress;
        private string defaultShippingAddress;
        
        public Customer()
        {
            
        }
        public bool SignUp()
        {
            return false;
        }
        public bool Login()
        {
            return false;
        }
    }
    public class Customer2
    {
        private string name, name2, name3;
        private string billingAdress;
        private string defaultShippingAddress;
        public Customer2()
        {

        }
        public bool SignUp(string name)
        {
            return false;
        }
        public bool Login(string name, string password)
        {
            return false;
        }
    }
}
