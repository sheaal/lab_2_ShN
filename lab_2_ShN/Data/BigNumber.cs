using System;
using System.Collections.Generic;
using System.Text;

namespace lab_2_ShN.Data
{
    public class BigNumber
    {
        private const int Base = 1000;
        private const int BlockDigits = 3;
        private readonly int[] number;

        // конструктор нормализация
        private BigNumber(int[] blocks)
        {
            int start = 0;
            while (start < blocks.Length - 1 && blocks[start] == 0)
                start++;

            if (start == 0)
            {
                number = blocks;
            }
            else
            {
                int[] trimmed = new int[blocks.Length - start];
                Array.Copy(blocks, start, trimmed, 0, trimmed.Length);
                number = trimmed;
            }
        }

        // int
        public BigNumber(int value)
        {
            if (value == 0)
            {
                number = new int[] { 0 };
                return;
            }

            var blocks = new List<int>();
            int v = value;
            while (v > 0)
            {
                blocks.Add(v % Base);
                v /= Base;
            }
            blocks.Reverse();
            number = blocks.ToArray();
        }

        // строка
        public BigNumber(string value)
        {
            value = value.Trim();
            if (value.Length == 0) value = "0";

            var blocks = new List<int>();

            int firstLen = value.Length % BlockDigits;
            if (firstLen == 0) firstLen = BlockDigits;

            blocks.Add(int.Parse(value.Substring(0, firstLen)));

            int pos = firstLen;
            while (pos < value.Length)
            {
                blocks.Add(int.Parse(value.Substring(pos, BlockDigits)));
                pos += BlockDigits;
            }

            int start = 0;
            while (start < blocks.Count - 1 && blocks[start] == 0)
                start++;

            if (start > 0)
                blocks.RemoveRange(0, start);

            number = blocks.ToArray();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < number.Length; i++)
            {
                if (i == 0)
                    sb.Append(number[i].ToString());
                else
                    sb.Append(number[i].ToString("D3"));
            }

            return sb.ToString();
        }

        public static BigNumber Zero => new BigNumber(0);
    }
}