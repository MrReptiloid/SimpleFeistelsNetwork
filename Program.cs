using System.Collections;

namespace FeistelsNetwork
{
    public class Program
    {
        static void Main(string[] args)
        {

            BitArray block1 = new BitArray(new bool[8] { true, false, true, false, true, false, true, false });
            BitArray block2 = new BitArray(new bool[8] { true, true, true, true, false, false, false, false });
            BitArray key = new BitArray(new bool[8] { false, false, false, false, true, true, true, true });

            ShowBits(block1);
            Console.Write(" - Лівий блок\n");
            ShowBits(block2);
            Console.Write(" - Правий блок\n");
            ShowBits(key);
            Console.Write(" - Ключ \n\n");

            List<BitArray> result = new List<BitArray>();
            result = Rounds(block1, block2, key);

            ShowBits(result[0]);
            Console.Write(" - Зашифрований Лівий блок\n");
            ShowBits(result[1]);
            Console.Write(" - Зашифрований Правий блок\n\n");

            result = Rounds(result[0], result[1], key);


            ShowBits(result[0]);
            Console.Write(" - Розшифрований Лівий блок\n");
            ShowBits(result[1]);
            Console.Write(" - Розшифрований Правий блок\n\n");
        }

        static List<BitArray> Rounds(BitArray block1, BitArray block2, BitArray key, int rounds = 10)
        {
            List<BitArray> result = new List<BitArray> { block1, block2 };
            for (int i = 0; i < rounds; i++)
                result = Round(result[0], result[1], key); //result = Round(block1, block2, key); так не треба робити

            return new List<BitArray> { result[1], result[0] };
        }

        static List<BitArray> Round(BitArray block1, BitArray block2, BitArray key)
        {
            BitArray encodedLeftBlock = new BitArray(block1);

            /* Тут можна творити все що завгодно */

            encodedLeftBlock.LeftShift(3);
            encodedLeftBlock.Xor(key);

            /*----------------------*/

            encodedLeftBlock.Xor(block2);

            return new List<BitArray> { encodedLeftBlock, block1 };
        }

        static void ShowBits(BitArray bits)
        {
            foreach (var bit in bits)
                if (bit.Equals(true))
                    Console.Write("1");
                else Console.Write("0");
        }
    }
}
