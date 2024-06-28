using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS2UML
{
    public class FileSystem
    {
        public FileSystem() 
        {
        }
        public string GetFile()
        {
            return @"
namespace Arena
{

    /// <summary>
    /// Třída reprezentuje hrací kostku
    /// </summary>
    public class Kostka
    {
        public abstract class Trida
        {
        }
        public int Hod()
        {
            return random.Next(1, pocetSten + 1);
        }

    }
    class Bojovnik
    {
        
    }
}
            "; 
        }
    }
    public class Kostka
    {
        public abstract class Trida
        {
        }
        public int Hod()
        {
            return 0;
        }

    }
}
