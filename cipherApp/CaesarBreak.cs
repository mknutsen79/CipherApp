using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class CaesarBreak
    {
        string cipher = "";
        CaesarCipher cc;
        public CaesarBreak(string cipher, CaesarCipher cc)
        {
            this.cipher = cipher;
            this.cc = cc;
        }

        public void bruteForce()
        {
            string message = "";
            for(int i = 1; i <= 26; i++)
            {
               message = cc.translate(cipher, i);
                Console.WriteLine(message);
                cc.clearString();
            }
        }





    }
}
