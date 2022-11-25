using System;
using System.Text;
using System.Collections.Generic;

namespace BigInts
{
    internal class BigInt
    {
        private string data;
        private int sign;
        List<byte> digits;

        // Empty Constructor
        public BigInt()
        {
            this.data = "";
            sign = 1;
            digits = new List<byte>();
        }

        // String Consrtuctor
        public BigInt(string v)
        {
            this.data = v;
            if (!isValid(v))
                throw new FormatException();

            // Salveaza semnul
            sign = 1;
            if (data[0] == '-')
                sign = -1;

            // Elimina semnul din string
            if (data[0] == '+' || data[0] == '-')
                data = data.Substring(1);

            // Sub forma de tablou de bytes, in ordine inversa
            digits = new List<byte>();
            for (int i = data.Length - 1; i >= 0; i--)
                digits.Add((byte)(data[i] - '0'));
        }

        // TODO: Byte Array Constructor

        // Validare
        private bool isValid(string v)
        {
            // Numarul este format din alte caractere inafara de cifre
            string cifreAcceptate = "0123456789";
            foreach (var item in v)
                if (cifreAcceptate.IndexOf(item) == -1)
                    return false;

            // Semnul apare de mai multe ori / apare in interiorul numarului
            string semneAcceptate = "+-";
            foreach (var item in semneAcceptate)
                if (v.LastIndexOf(item) > 0)
                    return false;
            
            return true;
        }

        // Transforma tabloul de bytes intr-un string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = digits.Count - 1; i >= 0; i--)
                sb.Append(digits[i].ToString());

            return sb.ToString();
        }

        /// <summary> Adunarea a 2 numere mari </summary>
        /// <param name="b1"> Primul termen al adunarii </param>
        /// <param name="b2"> Al doilea termen al adunarii </param>
        /// <returns> Suma celor 2 numere mari </returns>
        public static BigInt operator + (BigInt b1, BigInt b2)
        {
            BigInt result = new BigInt();

            for (int i = 0, carry = 0; i < b1.digits.Count || i < b2.digits.Count; i++)
            {
                int digit1 = i < b1.digits.Count ? b1.digits[i] : 0;
                int digit2 = i < b1.digits.Count ? b1.digits[i] : 0;

                result.digits.Add((byte)((digit1 + digit2 + carry) % 10));
                carry = (digit1 + digit2 + carry) / 10;
            }

            result.data = result.digits.ToString();
            return result;
        }

        /// <summary> Scaderea a 2 numere mari </summary>
        /// <param name="b1"> Primul termen al scaderii </param>
        /// <param name="b2"> Al doilea termen al scaderii </param>
        /// <returns> Diferenta celor 2 numere mari </returns>
        public static BigInt operator - (BigInt b1, BigInt b2)
        {
            BigInt result = new BigInt();

            int maxLength;
            if (b1.digits.Count > b2.digits.Count)
                maxLength = b1.digits.Count - 1;
            else
                maxLength = b2.digits.Count - 1;

            for (int i = maxLength; i >= 0; i--)
            {
                int digit1 = i < b1.digits.Count ? b1.digits[i] : 0;
                int digit2 = i < b1.digits.Count ? b1.digits[i] : 0;

                if (digit1 > digit2)
                    result.digits.Add((byte)(digit1 - digit2));
                else
                    result.digits.Add((byte)((digit1 + 10) - digit2));
            }

            result.data = result.digits.ToString();
            return result;
        }

        /// <summary> Inmultirea a 2 numere mari </summary>
        /// <param name="b1"> Primul termen al inmultirii </param>
        /// <param name="b2"> Al doilea termen al inmultirii </param>
        /// <returns> Rezultatul inmultirii celor 2 numere mari </returns>
        public static BigInt operator * (BigInt b1, BigInt b2)
        {
            BigInt result = new BigInt();

            

            return result;
        }

        // TODO:
        // algoritmii de pe hartie
        // public static BigInt operator * ();
        // public static BigInt operator / ();
        // public static BigInt operator % ();
        // public static BigInt operator == ();
        // public static BigInt operator != ();
        // public static BigInt operator < ();
        // public static BigInt operator <= ();
        // public static BigInt operator > ();
        // public static BigInt operator >= ();
        // Ridicare la putere
        // Radacina patrata
    }
}