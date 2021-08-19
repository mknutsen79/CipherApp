using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class Alphabete
    {
        Dictionary<int, string> myAlph = new Dictionary<int, string>();

        public void myDict()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i = 0; i < alpha.Length; i++)
            {
                myAlph.Add(i + 1, alpha[i].ToString());
            }
           
        }

        public Dictionary<int, string> getDict()
        {
            return myAlph;
        }


        public string value(int key)
        {
            return myAlph[key];
        }

    }
}
