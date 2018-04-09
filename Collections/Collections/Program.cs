using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Cipher> Ciphers = new List<Cipher>
            {
                new CaesarCipher(31),
                new AffineCipher(7, 4),
                new CaesarCipher(22),
                new AffineCipher(3, 8),
                new VigenereChiper("hi")
            };
            Console.WriteLine("Введите сообщение для шифрования");
            String text = Console.ReadLine();
            Console.WriteLine("Сортировка сообщений по уменьшению криптографической стойкости");
            SortCollection(Ciphers, text);
            Console.WriteLine("\nШифр Цезаря: \n");
            PrintCaesars(Ciphers, text);
            Console.WriteLine("\nАффинный шифр: \n");
            PrintAffines(Ciphers, text);
            Console.WriteLine("\nШифр Виженера: \n");
            PrintVigeneres(Ciphers, text);
            Console.ReadKey();
        }


        private static void SortCollection(List<Cipher> Ciphers, string text)
        {
            Ciphers = Ciphers.OrderBy(Cipher => Cipher.CryptographicResistance).ToList();

            foreach (Cipher Cipher in Ciphers)
            {
                Console.WriteLine(Cipher.CryptographicResistance + " : " + Cipher.EncryptMessage(text));
            }
        }


        private static void PrintVigeneres(List<Cipher> Ciphers, string text)
        {
            var Vigeneres =
                from cipher in Ciphers
                where (cipher.CryptographicResistance == 1)
                select cipher;

            foreach (Cipher Cipher in Vigeneres)
            {
                Console.WriteLine(Cipher.EncryptMessage(text));
            }
        }

        private static void PrintAffines(List<Cipher> Ciphers, string text)
        {
            var Affines =
                from cipher in Ciphers
                where (cipher.CryptographicResistance == 2)
                select cipher;

            foreach (Cipher Cipher in Affines)
            {
                Console.WriteLine(Cipher.EncryptMessage(text));
            }
        }

        private static void PrintCaesars(List<Cipher> Ciphers, string text)
        {
            var Caesars =
                from cipher in Ciphers
                where (cipher.CryptographicResistance == 3)
                select cipher;

            foreach (Cipher Cipher in Caesars)
            {
                Console.WriteLine(Cipher.EncryptMessage(text));
            }
        }
    }
}
