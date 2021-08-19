using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class ArrayAlphabete
    {
        HashSet<string> alphabete = new HashSet<string>();

        public void myNormHash()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i = 0; i < alpha.Length; i++)
            {
                if (alphabete.Contains(alpha[i].ToString()))
                {
                    continue;
                }
                else
                {
                    alphabete.Add(alpha[i].ToString());
                }
                
            }
                     
        }

        public void myAltHash(string word)
        {
            for(int i = 0; i<word.Length; i++)
            {
                alphabete.Add(word[i].ToString());
            }
            myNormHash();
        }

        public HashSet<string> getHash()
        {
            return alphabete;
        }

        public void removeLetter(string a)
        {
            alphabete.Remove(a);
        }
    }
}
