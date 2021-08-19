using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class VigenereBreak
    {
        string cipher = "";
        VigenereCipher vc;
        public VigenereBreak(string cipher, VigenereCipher vc)
        {
            this.cipher = cipher;
            this.vc = vc;
        }

    }
}
