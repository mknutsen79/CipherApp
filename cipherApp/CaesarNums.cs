using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class CaesarNums
    {
        Dictionary<string, int> nums = new Dictionary<string, int>();

        public void myDict()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for(int i = 0; i < alpha.Length; i++)
            {
                nums.Add(alpha[i].ToString(), i);
            }
            

        }
        public Dictionary<string, int> getDict()
        {
            return nums;
        }



    }
}
