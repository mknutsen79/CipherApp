using System;
using System.Collections.Generic;
using System.Text;

namespace cipherApp
{
    class PlayfairCipher
    {
        string[,] matrix = new string[5, 5];
        int fRow;
        int fCol;
        int sRow;
        int sCol;
        StringBuilder s = new StringBuilder();
        StringBuilder t = new StringBuilder();

        public PlayfairCipher(string[,] m)
        {
            this.matrix = m;
        }

        public void clearString()
        {
            s.Clear();
            t.Clear();
        }

        public string cipher(string message)
        {
            string newMessage = "";
            string subMessage = "";
            while (message != "")
            {
                if (message.Length > 1)
                {
                    //get first 2 letters of the message
                    subMessage = message.Substring(0, 2);
                    //adjust the message to have the first two letters removed
                    message = message.Substring(2);
                    string pos1 = subMessage[0].ToString();
                    string pos2 = subMessage[1].ToString();
                    //check if the letters are the same and need one replaced with "X"
                    if(pos1 == pos2)
                    {
                        subMessage = subMessage.Substring(0, 1);
                        subMessage = subMessage + "X";
                        cipherHelper(subMessage);
                    }
                    else
                    {
                        cipherHelper(subMessage);
                    }

                }
                else
                {
                    //our message is odd length so add an X at the end
                    subMessage = message.Substring(0);
                    message = message.Substring(0, 0);
                    subMessage = subMessage + "X";
                    cipherHelper(subMessage);
                }

            }
            newMessage = s.ToString();
            return newMessage;
        }

        public void cipherHelper(string subMessage)
        {
            string fLetter = subMessage[0].ToString();
            string sLetter = subMessage[1].ToString();
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            //check what position in the matrix our letters are in
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if(matrix[i,j] == fLetter)
                    {
                        fRow = i;
                        fCol = j;
                    }
                    if(matrix[i,j] == sLetter)
                    {
                        sRow = i;
                        sCol = j;
                    }

                }
            }
            //based on the letters position to one another, apply the cipher
            if(fRow == sRow)
            {
                if(fCol == 4)
                {
                    fLetter = matrix[fRow, 0];
                    sLetter = matrix[sRow, sCol + 1];

                }
                else if (sCol == 4)
                {
                    fLetter = matrix[fRow, fCol + 1];
                    sLetter = matrix[sRow, 0];
                }
                else
                {
                    fLetter = matrix[fRow, fCol + 1];
                    sLetter = matrix[sRow, sCol + 1];

                }

            }
            else if (fCol == sCol)
            {
                if(fRow == 4)
                {
                    fLetter = matrix[0, fCol];
                    sLetter = matrix[sRow + 1, sCol];
                }
                else if (sRow == 4)
                {
                    fLetter = matrix[fRow + 1, fCol];
                    sLetter = matrix[0, sCol];
                }
                else
                {
                    fLetter = matrix[fRow + 1, fCol];
                    sLetter = matrix[sRow + 1, sCol];
                }

            }
            else
            {
                fLetter = matrix[fRow, sCol];
                sLetter = matrix[sRow, fCol];
            }
            s.Append(fLetter);
            s.Append(sLetter);

        }

        public string translate(string message)
        {
            string newMessage = "";
            string subMessage = "";
            while (message != "")
            {
                subMessage = message.Substring(0, 2);
                message = message.Substring(2);
                translateHelper(subMessage);
            }
            newMessage = t.ToString();
            string lstLetter = newMessage.Substring(newMessage.Length - 1);
            if (lstLetter == "X")
            {
                newMessage = newMessage.Remove(newMessage.Length - 1);
            }
            return newMessage;

        }

        public void translateHelper(string subMessage)
        {
            string fLetter = subMessage[0].ToString();
            string sLetter = subMessage[1].ToString();
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);
            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    if (matrix[i, j] == fLetter)
                    {
                        fRow = i;
                        fCol = j;
                    }
                    if (matrix[i, j] == sLetter)
                    {
                        sRow = i;
                        sCol = j;
                    }

                }
            }

            if (fRow == sRow)
            {
                if (fCol == 0)
                {
                    fLetter = matrix[fRow, 4];
                    sLetter = matrix[sRow, sCol - 1];

                }
                else if (sCol == 0)
                {
                    fLetter = matrix[fRow, fCol - 1];
                    sLetter = matrix[sRow, 4];
                }
                else
                {
                    fLetter = matrix[fRow, fCol - 1];
                    sLetter = matrix[sRow, sCol - 1];

                }

            }
            else if (fCol == sCol)
            {
                if (fRow == 0)
                {
                    fLetter = matrix[4, fCol];
                    sLetter = matrix[sRow - 1, sCol];
                }
                else if (sRow == 0)
                {
                    fLetter = matrix[fRow - 1, fCol];
                    sLetter = matrix[4, sCol];
                }
                else
                {
                    fLetter = matrix[fRow - 1, fCol];
                    sLetter = matrix[sRow - 1, sCol];
                }

            }
            else
            {
                fLetter = matrix[fRow, sCol];
                sLetter = matrix[sRow, fCol];
            }
            t.Append(fLetter);
            t.Append(sLetter);


        }
    }
}
