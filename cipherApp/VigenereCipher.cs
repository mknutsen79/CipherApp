using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class VigenereCipher
    {
        Dictionary<int, string> alph;
        Dictionary<string, int> ciphKey;
        StringBuilder s = new StringBuilder();
        StringBuilder t = new StringBuilder();
        public VigenereCipher(Dictionary<int, string> a, Dictionary<string, int> b)
        {
            this.alph = a;
            this.ciphKey = b;
        }

        public void clearString()
        {
            s.Clear();
            t.Clear();
        }

        public string cipher(string message, string key)
        {
            //where we are on the key
            int pos = 0;
            //the amount we shift our letter
            int shift = 0;
            //the letter we are currently
            int curLet;
            //the new shifted letter
            int newLet;
            //the message we are making
            string newMessage = "";
            //letter of our key
            string let = "";
            //letter of our message
            string let2 = "";
            //check the key length
            int check = key.Length;
           
            for (int i = 0; i < message.Length; i++)
            {
                //Grab the letter of our key we are currently at
                let = key[pos].ToString();
                //check for whitespace
                char wp = Char.Parse(message[i].ToString());
                if (Char.IsWhiteSpace(wp))
                {
                    s.Append(" ");
                }
                else if (pos < check - 1)
                {
                    //get the value of how much we will be shifting
                    shift = ciphKey[let];
                    //icnrease our position
                    pos++;
                    //get the letter we are at in our message
                    let2 = message[i].ToString();
                    //get the value of the letter so we know its start value
                    curLet = ciphKey[let2];
                    //shift our messages letter by the key letter to get our new letter in our cipher
                    newLet = shift + curLet;
                    //if the added value is greater than 26 make sure to get the over flow value at the start of the alphabette (28 would be B since overflow is 2)
                    if (newLet > 26)
                    {
                        newLet = newLet - 26;
                    }
                    //Add the new letter to our encrypted message
                    s.Append(alph[newLet]);
                }
                else
                {
                    pos = 0;
                    shift = ciphKey[let];
                    let2 = message[i].ToString();
                    curLet = ciphKey[let2];
                    newLet = shift + curLet;
                    if (newLet > 26)
                    {
                        newLet = newLet - 26;
                    }
                    s.Append(alph[newLet]);
                }
            }
            //concert our message to a string and return
            newMessage = s.ToString();
            return newMessage;
        }

        public string translate(string message, string key)
        {
            string translation = "";
            int pos = 0;
            int shift = 0;
            int curLet;
            int newLet;
            string let = "";
            string let2 = "";
            int check = key.Length;
            //check to see if we should uppercase a letter
            bool upper = true;
            for(int i = 0; i < message.Length; i++)
            {
                let = key[pos].ToString();
                char wp = Char.Parse(message[i].ToString());
                if (Char.IsWhiteSpace(wp))
                {
                    //if we hit white space it means we are moving to a new word and should uppercase
                    t.Append(" ");
                    upper = true;
                }
                else if (pos < check - 1)
                {
                    shift = ciphKey[let];
                    pos++;
                    let2 = message[i].ToString();
                    curLet = ciphKey[let2];
                    newLet = curLet - shift;
                    if(newLet < 0)
                    {
                        newLet = 26 + newLet;
                    }
                    //if we need ot upper case we set the letter to an uppercase other wise we make sure its lower case
                    if (upper)
                    {
                        t.Append(alph[newLet].ToUpper());
                        upper = false;
                    }
                    else
                    {
                        t.Append(alph[newLet].ToLower());
                    }
                }
                else
                {
                    pos = 0;
                    shift = ciphKey[let];
                    let2 = message[i].ToString();
                    curLet = ciphKey[let2];
                    newLet = curLet - shift;
                    if (newLet < 0)
                    {
                        newLet = 26 + newLet;
                    }
                    if (upper)
                    {
                        t.Append(alph[newLet].ToUpper());
                        upper = false;
                    }
                    else
                    {
                        t.Append(alph[newLet].ToLower());
                    }
                }

            }
            translation = t.ToString();
            return translation;

        }
    }
}
