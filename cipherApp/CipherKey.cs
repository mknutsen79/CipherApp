using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class CipherKey
    {
        Dictionary<string, int> myKey = new Dictionary<string, int>();

        public void myDict()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i = 0; i < alpha.Length; i++)
            {
                myKey.Add(alpha[i].ToString(), i + 1);
            }          
           
        }

        public int value(string key)
        {
            return myKey[key];
        }

        public Dictionary<string, int> getDict()
        {
            return myKey;
        }
        
    }
}
