public BigInteger BinToDec(string bitString)
        {
            BigInteger integer = 0;
            foreach (char bit in bitString)
            {
                integer <<= 1;
                integer += bit == '1' ? 1 : 0;
            }
            return integer;
        }
