// Please use and distribute under LGPL
// http://zamboch.blogspot.com/
// 2007 Pavel Savara
using System;
using System.Text;


namespace Zamboch.Ranking
{
    class Program
    {
        static void Main()
        {
            MultiSetRank m = new MultiSetRank(new byte[] { 0, 0, 1, 1, 2, 3 });
            Console.WriteLine(m.Potential);

            for(int i=0;i<m.Potential;i++)
            {
                byte[] perm = m.UnRank(i);
                int j = m.Rank(perm);
                Console.WriteLine("{0:000} -> {1} -> {2:000}", i, BytesToString(perm), j);
                
                // should never happen
                if (j != i)
                    throw new InvalidProgramException();
            }
        }
        
        private static string BytesToString(byte[] perm)
        {
            StringBuilder sb=new StringBuilder();
            foreach (byte b in perm)
            {
                sb.Append(b);
                sb.Append(',');
            }
            sb.Length--;
            return sb.ToString();
        }
    }
}
