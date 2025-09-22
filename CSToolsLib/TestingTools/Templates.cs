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
    /// <summary>
    /// Test
    /// </summary>
    
    public abstract class Customer2
    {
        private string name;
        public string BillingAdress {  get; private set; }
        private string defaultShippingAddress;
        public string DefaultShippingAddress
        {
            get
            {
                return defaultShippingAddress;
            }
            private set
            {
                defaultShippingAddress = value;
            }
        }
        public void SignUp(string name)
        {
            
        }

        public abstract bool Login(string name, string password);
    }

}
