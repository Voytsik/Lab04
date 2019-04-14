using System;
using System.Text;

namespace Lab02.Manager
{
    class RandomDateTime
    {
        public DateTime GenRandomDateTime(DateTime from, DateTime to, Random random = null)
        {
            if (from >= to)
            {
                throw new Exception("Параметр \"from\" має бути меншим параметра \"to\"!");
            }
            if (random == null)
            {
                random = new Random();
            }
            TimeSpan range = to - from;
            var randts = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return from + randts;
        }

        public string GenRandomString(int temp)
        {
            Random rnd = new Random(temp);
            string Alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            int Length = rnd.Next(4, 12);
            StringBuilder sb = new StringBuilder(Length - 1);
            int Position = 0;

            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length - 1);
                sb.Append(Alphabet[Position]);
            }
            return sb.ToString();
        }
    }
}