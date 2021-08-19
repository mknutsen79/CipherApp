using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class CaesarAlphabete
    {
        Dictionary<int, string> myAlph = new Dictionary<int, string>();

        public void myDict()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i = 0; i < alpha.Length; i++)
            {
                myAlph.Add(i, alpha[i].ToString());
            }
            
        }

        public Dictionary<int, string> getDict()
        {
            return myAlph;
        }
    }
}
