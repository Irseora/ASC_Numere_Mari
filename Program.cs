using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BigInts;

// Implementati operatii cu numere naturale mari.
// Operatii: Adunare, scadere, inmultire, impartire, ridicare la putere, radacina patrata.
// Operatorii relationali: <, >, <=, >=, operatorii de egalitate/inegalitate. 
// Precizari: Numar mare = un numar care nu poate fi reprezentat pe int/long etc.
//            Numarul poate avea sute/mii/... de cifre.

namespace ASC_Numere_Mari
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BigInt b1 = new BigInt("12345678901234567890");
                BigInt b2 = new BigInt("11111111111111111111");

                Console.WriteLine($"{b1} + {b2} = {b1 + b2}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}