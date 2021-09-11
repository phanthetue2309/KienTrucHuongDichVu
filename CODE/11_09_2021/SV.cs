using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace _11_09_2021
{
    public class SV
    {
        public string MSSV { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString() {
            return "MSSV =" + MSSV + " ,Name = " + Name + " ,Age = " + Age; 
        }
        
        
    }
}