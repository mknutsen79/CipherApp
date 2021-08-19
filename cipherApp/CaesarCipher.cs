using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class CaesarCipher
    {
        Dictionary<int, string> alph;
        Dictionary<string, int> nums;
        StringBuilder s = new StringBuilder();
        StringBuilder t = new StringBuilder();

        public CaesarCipher(Dictionary<int,string> a, Dictionary<string, int> b)
        {
            this.alph = a;
            this.nums = b;
        }

        public void clearString()
        {
            s.Clear();
            t.Clear();
        }

        public string cipher(string message, int key)
        {
            //The location of our new letter
            int shift = 0;
            //the message we are making
            string newMessage = "";
            //the letter we are on
            string let = "";
            for (int i = 0; i < message.Length; i++)
            {
                char wp = Char.Parse(message[i].ToString());
                if (Char.IsWhiteSpace(wp))
                {
                    s.Append(" ");
                }
                else
                {
                    //(letter num + key)mod26 = shift
                    let = message[i].ToString();
                    shift = (nums[let] + key) % 26;
                    if(shift> 25)
                    {
                        shift = shift - 25;
                    }
                    s.Append(alph[shift]);

                }

            }
            newMessage = s.ToString();
            return newMessage;
        }

        public string translate(string message, int key)
        {
            int shift = 0;
            string translation = "";
            string let = "";
            bool upper = true;
            for(int i = 0; i < message.Length; i++)
            {
                char wp = Char.Parse(message[i].ToString());
                if (Char.IsWhiteSpace(wp))
                {
                    t.Append(" ");
                    upper = true;
                }
                else
                {
                    let = message[i].ToString();
                    shift = (nums[let] - key) % 26;
                    if(shift < 0)
                    {
                        shift = shift + 26;
                    }
                    if (upper)
                    {
                        t.Append(alph[shift].ToUpper());
                        upper = false;
                    }
                    else
                    {
                        t.Append(alph[shift].ToLower());
                    }
                    
                }
            }
            translation = t.ToString();
            return translation;
        }
    }
}
