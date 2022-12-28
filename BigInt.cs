using System;
using System.Text;
using System.Collections.Generic;

namespace BigInts
{
    internal class BigInt
    {
        // --------------------------------------------- DATA ----------------------------------------------
        
        private string data;
        private int sign;
        List<byte> digits;

        // ------------------------------------------ CONSTRUCTORS ------------------------------------------

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
            data = v;
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

        // TODO: ???
        // Byte Array Constructor
        public BigInt(List<byte> v)
        {
            digits = v;

            data = digits.ToString();
            if (!isValid(data))
                throw new FormatException();

            sign = 1;
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

        // ------------------------------------------ OPERATIONS ------------------------------------------

        /// <summary> Adunarea a 2 numere mari </summary>
        /// <param name="b1"> Primul termen al adunarii </param>
        /// <param name="b2"> Al doilea termen al adunarii </param>
        /// <returns> Suma celor 2 numere mari </returns>
        public static BigInt operator + (BigInt b1, BigInt b2)
        {
            BigInt result = new BigInt();

            if (b1.sign == b2.sign)
            {
                result.sign = b1.sign;

                for (int i = 0, carry = 0; i < b1.digits.Count || i < b2.digits.Count; i++)
                {
                    // TODO: Digit_i if it exists, 0 otherwise
                    int digit1 = i < b1.digits.Count ? b1.digits[i] : 0;
                    int digit2 = i < b1.digits.Count ? b1.digits[i] : 0;

                    result.digits.Add((byte)((digit1 + digit2 + carry) % 10));
                    carry = (digit1 + digit2 + carry) / 10;
                }
            }
            else
            {
                
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

            if (b1 > b2)
            {
                BigInt aux = b1;
                b1 = b2;
                b2 = aux;
                result.sign = -1;
            }

            for (int i = 0; i < b1.digits.Count; i++)
            {
                // TODO: Digit_i if it exists, 0 otherwise
                int digit1 = i < b1.digits.Count ? b1.digits[i] : 0;
                int digit2 = i < b1.digits.Count ? b1.digits[i] : 0;

                if (digit1 >= digit2)
                    result.digits.Add((byte)(digit1 - digit2));
                else
                {
                    // TODO: Find first non-0 & replace all others w/ 9
                    int j = i+1;
                    while (b1.digits[j] == 0)
                    {
                        b1.digits[j] = 9;
                        j++;
                    }

                    result.digits.Add((byte)(10 + digit1 - digit2));
                }
            }



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

        /// <summary> Impartirea intreaga a 2 numere mari </summary>
        /// <param name="b1"> Primul termen al impartirii </param>
        /// <param name="b2"> Al doilea termen al impartirii </param>
        /// <returns> Rezultatul impartirii intregi a celor 2 numere mari </returns>
        public static BigInt operator / (BigInt b1, BigInt b2)
        {
            BigInt result = new BigInt();

            

            return result;
        }

        /// <summary> Impartirea cu rest a 2 numere mari </summary>
        /// <param name="b1"> Primul termen al impartirii </param>
        /// <param name="b2"> Al doilea termen al impartirii </param>
        /// <returns> Restul impartirii celor 2 numere mari </returns>
        public static BigInt operator % (BigInt b1, BigInt b2)
        {
            BigInt result = new BigInt();

            

            return result;
        }

        /// <summary> Determina daca 2 numere mari sunt egale </summary>
        /// <param name="b1"> Primul termen al comparatiei </param>
        /// <param name="b2"> Al doilea termen al comparatiei </param>
        /// <returns> Adevarat daca sunt egale, fals daca nu </returns>
        public static bool operator == (BigInt b1, BigInt b2)
        {
            int evaluare = b1.data.CompareTo(b2.data);

            if (evaluare == 0)
                return true;
            return false;
        }

        /// <summary> Determina daca 2 numere mari sunt diferite </summary>
        /// <param name="b1"> Primul termen al comparatiei </param>
        /// <param name="b2"> Al doilea termen al comparatiei </param>
        /// <returns> Adevarat daca sunt diferite, fals daca nu </returns>
        public static bool operator != (BigInt b1, BigInt b2)
        {
            int evaluare = b1.data.CompareTo(b2.data);

            if (evaluare != 0)
                return true;
            return false;
        }

        /// <summary> Determina daca primul numar mare este mai mic decat al doilea </summary>
        /// <param name="b1"> Primul termen al comparatiei </param>
        /// <param name="b2"> Al doilea termen al comparatiei </param>
        /// <returns> Adevarat daca b1 < b2, fals altfel </returns>
        public static bool operator < (BigInt b1, BigInt b2)
        {
            int evaluare = b1.data.CompareTo(b2.data);

            if (evaluare < 0)
                return true;
            return false;
        }

        /// <summary> Determina daca primul numar este mai mare decat al doilea </summary>
        /// <param name="b1"> Primul termen al comparatiei </param>
        /// <param name="b2"> Al doilea termen al comparatiei </param>
        /// <returns> Adevarat daca b1 > b2, fals altfel </returns>
        public static bool operator > (BigInt b1, BigInt b2)
        {
            int evaluare = b1.data.CompareTo(b2.data);

            if (evaluare > 0)
                return true;
            return false;
        }

        /// <summary> Determina daca primul numar este mai mic sau egal cu al doilea </summary>
        /// <param name="b1"> Primul termen al comparatiei </param>
        /// <param name="b2"> Al doilea termen al comparatiei </param>
        /// <returns> Adevarat daca b1 < b2 sau b1 == b2, fals altfel </returns>
        public static bool operator <= (BigInt b1, BigInt b2)
        {
            int evaluare = b1.data.CompareTo(b2.data);

            if (evaluare <= 0)
                return true;
            return false;
        }

        /// <summary> Determina daca primul numar este mai mare sau egal cu al doilea </summary>
        /// <param name="b1"> Primul termen al comparatiei </param>
        /// <param name="b2"> Al doilea termen al comparatiei </param>
        /// <returns> Adevarat daca b1 > b2 sau b1 == b2, fals altfel </returns>
        public static bool operator >= (BigInt b1, BigInt b2)
        {
            int evaluare = b1.data.CompareTo(b2.data);

            if (evaluare >= 0)
                return true;
            return false;
        }

        /// <summary> Ridica un numar mare la puterea specificata, numar real </summary>
        /// <param name="baza"> Numarul care trebuie ridicat la putere </param>
        /// <param name="exponent"> Exponentul la care trebuie ridicata baza </param>
        /// <returns> Baza ridicata la exponent </returns>
        public static int Pow(BigInt baza, int exponent)
        {
            int result = 0;

            return result;
        }

        /// <summary> Ridica un numar mare la puterea specificata, tot numar mare </summary>
        /// <param name="baza"> Numarul care trebuie ridicat la putere </param>
        /// <param name="exponent"> Exponentul la care trebuie ridicata baza </param>
        /// <returns> Baza ridicata la exponent </returns>
        public static BigInt Pow(BigInt baza, BigInt exponent)
        {
            BigInt result = new BigInt();

            return result;
        }

        /// <summary> Calculeaza radacina patrata a unui numar mare </summary>
        /// <param name="numar"> Numarul al carui radacina patrata va fi calculata </param>
        /// <returns> Radacina patrata a numarului mare </returns>
        public static BigInt Sqrt(BigInt numar)
        {
            BigInt result = new BigInt();

            return result;
        }
    
        // ------------------------------------------ OVERRIDES ------------------------------------------

        /// <summary> Transforma tabloul de bytes intr-un string </summary>
        /// <returns> Un string care reprezinta tabloul de bytes </returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = digits.Count - 1; i >= 0; i--)
                sb.Append(digits[i].ToString());

            return sb.ToString();
        }

        // TODO: ???
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        // TODO: ???
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}