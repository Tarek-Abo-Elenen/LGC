using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LCG
{
    public class Generator
    {
        private long seed, multiplier, increment, modulus;

        public Generator(long seed, long multiplier, long increment, long modulus)
        {
            this.seed = seed;
            this.multiplier = multiplier;
            this.increment = increment;
            this.modulus = modulus;
        }

        public long Next()
        {
            seed = (multiplier * seed + increment) % modulus;
            return seed;
        }

        bool isPowerOfTwo(long m)
        {
            return (m > 0) && ((m & (m - 1)) == 0);
        }

        bool isPrime(long m)
        {
            if (m <= 1)
                return false;

            for (int i = 2; i * i <= m; i++)
                if (m % i == 0)
                    return false;

            return true;
        }

        bool GCD(long  a, long b)
        {
            BigInteger g = BigInteger.GreatestCommonDivisor(a, b);
            return g == 1;
        }

        public long CycleLength()
        {

            if ((isPowerOfTwo(this.modulus) && this.increment != 0) && (multiplier == (1 + 4 * (modulus - 1))) && GCD(increment, modulus))
                return modulus;
            else if ((isPowerOfTwo(this.modulus) && this.increment == 0) && (seed % 2 != 0 && (multiplier == (5 + 8 * (modulus - 1)) || multiplier == (3 + 8 * (modulus - 1)))))
                return modulus / 4;
            else if ((isPrime(this.modulus) && this.increment == 0) && (Math.Pow(multiplier, modulus - 2)) % modulus == 0)
                return modulus - 1;
            else
            {
                HashSet<long> generatedNumbers = new HashSet<long>();
                long randomNumber = this.Next();

                while (!generatedNumbers.Contains(randomNumber))
                {
                    generatedNumbers.Add(randomNumber);
                    randomNumber = this.Next();
                }

                return generatedNumbers.Count;
            }
        }
    }
}
