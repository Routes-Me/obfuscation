using System;
using System.Collections.Generic;
using System.Text;

namespace RoutesSecurity
{
    public class Obfuscation
    {
        private class Primes
        {
            public int Prime { get; set; }
            public int Inverse { get; set; }
        }
        private static Dictionary<char, Primes> Indices = new Dictionary<char, Primes>()
        {
            {'A', new Primes(){ Prime= 1580030173, Inverse= 59260789}},
            {'B', new Primes(){ Prime= 2123809381, Inverse= 1885413229}},
            {'C', new Primes(){ Prime= 2103809385, Inverse= 1603554009}},
            {'D', new Primes(){ Prime= 2017909589, Inverse= 62278141}},
            {'E', new Primes(){ Prime= 1580030179, Inverse= 923184331}},
            {'F', new Primes(){ Prime= 2016109589, Inverse= 1555778365}},
            {'G', new Primes(){ Prime= 2014719583, Inverse= 134065567}},
            {'H', new Primes(){ Prime= 2013909385, Inverse= 1416230073}},
            {'I', new Primes(){ Prime= 2034719583, Inverse= 809091231}},
            {'J', new Primes(){ Prime= 2123809383, Inverse= 1003305303}},
            {'K', new Primes(){ Prime= 1780030179, Inverse= 951253707}},
            {'L', new Primes(){ Prime= 1934719743, Inverse= 2023064831}},
            {'M', new Primes(){ Prime= 1874519547, Inverse= 1797807411}},
            {'N', new Primes(){ Prime= 1674519741, Inverse= 919271061}},
            {'O', new Primes(){ Prime= 1614519749, Inverse= 1008326925}},
            {'P', new Primes(){ Prime= 1774519741, Inverse= 1259756949}},
            {'Q', new Primes(){ Prime= 2123809385, Inverse= 53145049}},
            {'R', new Primes(){ Prime= 1010517749, Inverse= 412923229}},
            {'S', new Primes(){ Prime= 1010519947, Inverse= 1412456483}},
            {'T', new Primes(){ Prime= 1118511947, Inverse= 643944035}},
            {'U', new Primes(){ Prime= 1854719749, Inverse= 1174531533}},
            {'V', new Primes(){ Prime= 1719515941, Inverse= 302246061}},
            {'W', new Primes(){ Prime= 1219585543, Inverse= 116598711}},
            {'X', new Primes(){ Prime= 1119511947, Inverse= 1696340515}},
            {'Y', new Primes(){ Prime= 1954719749, Inverse= 851436749}},
            {'Z', new Primes(){ Prime= 2015109589, Inverse= 1059590013}}
        };
        private static char RandomIndex()
        {
            // return (char)(new Random().Next('A', 'Z' + 1));
            return 'A';
        }
        public static string Encode(int input)
        {
            char randomIndex = RandomIndex();

            return randomIndex + ((input * Indices[randomIndex].Prime) & int.MaxValue).ToString();
        }

        public static int Decode(string input)
        {
            string inputWithoutIndex = input.Substring(1);

            // use old inverse for deobfuscation if encoded value does not start with a letter
            if (!Char.IsLetter(input[0]))
                return (Convert.ToInt32(input) * 59260789) & int.MaxValue;

            return (Convert.ToInt32(inputWithoutIndex) * Indices[input[0]].Inverse) & int.MaxValue;
        }
    }
}
