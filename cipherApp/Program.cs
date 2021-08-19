using System;

namespace cipherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            CipherKey cKey = new CipherKey();
            Alphabete alph = new Alphabete();
            cKey.myDict();
            alph.myDict();
            VigenereCipher vig = new VigenereCipher(alph.getDict(), cKey.getDict());
            while (run)
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Vigenere Cipher");
                Console.WriteLine("2. Caesar Cipher");
                Console.WriteLine("3. Playfair Cipher");
                Console.WriteLine("4. Modified Playfair Cipher");
                Console.WriteLine("5. Exit");
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Vcipher();
                        break;
                    case 2:
                        Ccipher();
                        break;
                    case 3:
                        Pcipher();
                        break;
                    case 4:
                        modPCipher();
                        break;
                    case 5:
                        run = false;
                        break;

                }

            }

        }
        //Run the Vigenere Cipher 
        public static void Vcipher()
        {
            bool run = true;
            CipherKey cKey = new CipherKey();
            Alphabete alph = new Alphabete();
            cKey.myDict();
            alph.myDict();
            VigenereCipher vig = new VigenereCipher(alph.getDict(), cKey.getDict());
            while (run)
            {
                Console.WriteLine("1. Apply Cipher");
                Console.WriteLine("2. Translate Cipher");
                Console.WriteLine("3. Exit");
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter your key");
                        string key = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter your message");
                        string message = Console.ReadLine().ToUpper();
                        message = vig.cipher(message, key);
                        Console.WriteLine(message);
                        vig.clearString();
                        break;

                    case 2:
                        Console.WriteLine("Enter your key");
                        key = Console.ReadLine().ToUpper();
                        Console.WriteLine("Enter your encrypted message");
                        message = Console.ReadLine().ToUpper();
                        message = vig.translate(message, key);
                        Console.WriteLine(message);
                        vig.clearString();
                        break;
                    case 3:
                        run = false;
                        break;
                }
            }            

        }

        public static void Ccipher()
        {
            bool run = true;
            CaesarAlphabete alph = new CaesarAlphabete();
            CaesarNums nums = new CaesarNums();
            alph.myDict();
            nums.myDict();
            CaesarCipher cae = new CaesarCipher(alph.getDict(), nums.getDict());
            while (run)
            {
                Console.WriteLine("1. Apply Cipher");
                Console.WriteLine("2. Translate Cipher");
                Console.WriteLine("3. Break Cipher");
                Console.WriteLine("4. Exit");
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter your key");
                        int key;
                        key = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your message");
                        string message = Console.ReadLine().ToUpper();                       
                        message = cae.cipher(message, key);
                        Console.WriteLine(message);
                        cae.clearString();
                        break;
                    case 2:
                        Console.WriteLine("Enter your key");
                        key = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter your encrypted message");
                        message = Console.ReadLine().ToUpper();
                        message = cae.translate(message, key);
                        Console.WriteLine(message);
                        cae.clearString();
                        break;
                    case 3:
                        Console.WriteLine("Enter your encrypted message");
                        message = Console.ReadLine().ToUpper();
                        CaesarBreak breakC = new CaesarBreak(message, cae);
                        breakC.bruteForce();
                        break;
                    case 4:
                        run = false;
                        break;
                }

            }
        }

        public static void Pcipher()
        {
            bool run = true;
            ArrayAlphabete alph = new ArrayAlphabete();
            alph.myNormHash();
            while (run)
            {
                Console.WriteLine("1. Apply Cipher");
                Console.WriteLine("2. Translate Cipher");
                Console.WriteLine("3. Exit");
                int option;
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter the letter you wish to remove");
                        string letter = Console.ReadLine().ToUpper();
                        alph.removeLetter(letter);
                        ArrayBuilder matrix = new ArrayBuilder(alph.getHash());
                        matrix.buildMatrix();
                        PlayfairCipher play = new PlayfairCipher(matrix.getMatrix());
                        Console.WriteLine("Enter your message");
                        string message = Console.ReadLine().ToUpper();
                        message = message.Replace(" ", "");
                        message = play.cipher(message);
                        Console.WriteLine(message);
                        play.clearString();
                        
                        break;
                    case 2:
                        Console.WriteLine("Enter the letter you wish to remove");
                        letter = Console.ReadLine().ToUpper();
                        alph.removeLetter(letter);
                        matrix = new ArrayBuilder(alph.getHash());
                        matrix.buildMatrix();
                        play = new PlayfairCipher(matrix.getMatrix());
                        Console.WriteLine("Enter your message");
                        message = Console.ReadLine().ToUpper();
                        message = play.translate(message);
                        Console.WriteLine(message);
                        play.clearString();
                        break;
                    case 3:
                        run = false;
                        break;
                }
            }
        }

        public static void modPCipher()
        {
            bool run = true;
            ArrayAlphabete alph = new ArrayAlphabete();
            while (run)
            {
                Console.WriteLine("1. Apply Cipher");
                Console.WriteLine("2. Translate Cipher");
                Console.WriteLine("3. Exit");
                int option;
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter decided word");
                        string word = Console.ReadLine().ToUpper();
                        alph.myAltHash(word);
                        ArrayBuilder matrix = new ArrayBuilder(alph.getHash());
                        matrix.buildMatrix();
                        PlayfairCipher play = new PlayfairCipher(matrix.getMatrix());
                        Console.WriteLine("Enter your message");
                        string message = Console.ReadLine().ToUpper();
                        message = message.Replace(" ", "");
                        message = play.cipher(message);
                        Console.WriteLine(message);
                        play.clearString();
                        break;
                    case 2:
                        Console.WriteLine("Enter decided word");
                        word = Console.ReadLine().ToUpper();
                        alph.myAltHash(word);
                        matrix = new ArrayBuilder(alph.getHash());
                        matrix.buildMatrix();
                        play = new PlayfairCipher(matrix.getMatrix());
                        Console.WriteLine("Enter your message");
                        message = Console.ReadLine().ToUpper();
                        message = play.translate(message);
                        Console.WriteLine(message);
                        play.clearString();
                        break;
                    case 3:
                        run = false;
                        break;
                }

            }

        }
    }
}
