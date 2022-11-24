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

        // Adunare
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

        // Transforma tabloul de bytes intr-un string
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = digits.Count - 1; i >= 0; i--)
                sb.Append(digits[i].ToString());

            return sb.ToString();
        }

        // TODO:
        // public static BigInt operator * (); // algoritmii de pe hartie
        // public static BigInt operator - ();
        // public static BigInt operator / ();
        // public static BigInt operator = ();
        // public static BigInt operator < ();
        // public static BigInt operator <= ();
        // public static BigInt operator > ();
        // public static BigInt operator >= ();
    }
}