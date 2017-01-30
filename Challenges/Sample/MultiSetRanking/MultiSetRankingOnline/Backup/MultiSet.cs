// Please use and distribute under LGPL
// http://zamboch.blogspot.com/
// 2007 Pavel Savara
using System;

namespace Zamboch.Ranking
{
    public class MultiSetRank
    {
        /// <summary>
        /// Constructor. Each instance is initialized for permutation specific set
        /// </summary>
        /// <param name="baseSet">Expected ordered multiset. Set of members, including repetitions.</param>
        /// <example>
        /// MultiSetRank m = new MultiSetRank(new byte[] { 0, 0, 1, 1, 2, 3 });
        /// </example>
        public MultiSetRank(byte[] baseSet)
        {
            length = baseSet.Length;

            //count types, minchar
            int last = 0;
            types = 1;
            for (int i = 0; i < baseSet.Length; i++)
            {
                if (last != baseSet[i])
                {
                    last = baseSet[i];
                    types++;
                }
            }
            //count each type
            typeCount = new int[types];
            last = baseSet[0];
            for (int i = 0; i < baseSet.Length; i++)
            {
                int type = baseSet[i];
                if (last != baseSet[i])
                {
                    last = baseSet[i];
                }
                typeCount[type]++;
                if (maxTypeLength < typeCount[type]) maxTypeLength = typeCount[type];
            }
            ComputePotential();
        }

        /// <summary>
        /// Method will return permutation of multiset on given index
        /// </summary>
        /// <param name="permutationIndex">Index of permutation</param>
        /// <returns>Multiset</returns>
        /// <example>
        /// byte[] perm = m.UnRank(60);
        /// </example>
        public byte[] UnRank(int permutationIndex)
        {
            // just assertion
            if (permutationIndex < 0 || permutationIndex >= maxPotential) throw new ArgumentOutOfRangeException();
            
            byte[] result = new byte[length];
            int[] currentCounts = (int[])typeCount.Clone();
            int currentPotential = maxPotential;
            int currentLength = length;

            // for each position
            for (int position = 0; position < length; position++, currentLength--)
            {
                //compute selector, which is just rank reduced to be in range of current length of multiset
                int selector = ((permutationIndex * currentLength) / currentPotential);
                int offset = 0;
                byte type = 0;

                // note that 
                //  - sum of count of all currenttly remaining types is length of multiset
                //  - current potential is sum of potentials of sub-multisets

                // scanning for offset of sub-multiset in which range selector could be found
                while ((offset + currentCounts[type]) <= selector)
                {
                    offset += currentCounts[type];
                    type++;
                }

                // remove consumed offset
                permutationIndex -= (currentPotential * offset) / currentLength;

                // compute potential of sub-multiset
                currentPotential = currentPotential * currentCounts[type] / currentLength;

                // consume type
                currentCounts[type]--;
                
                // store chosen type
                result[position] = type;
            }
            return result;
        }

        /// <summary>
        /// Method will return index of permutation
        /// </summary>
        /// <param name="multiset">Any valid permutation of multiset for which was instance initialized</param>
        /// <returns>index of permutation</returns>
        /// <example>
        /// int permutationIndex = m.Rank(new byte[] { 0, 1, 0, 1, 2, 3 }); 
        /// </example>
        public int Rank(byte[] multiset)
        {
            // just assertion
            if (multiset.Length != length) throw new ArgumentOutOfRangeException();

            int result = 0;
            int currentPotential = maxPotential;
            int currentLength = length;
            int[] currentCounts = (int[])typeCount.Clone();

            // for each position
            for (int position = 0; position < length - 1 && currentPotential > 1; position++, currentLength--)
            {
                int offset = 0;
                byte type = (multiset[position]);

                // computing sum of potentials for each sub-multiset which has lower index than selected type
                for (int i = 0; i < type; i++) offset += currentCounts[i];

                // add offset to the rank/result
                result += (currentPotential * offset) / currentLength;
                
                // compute potential of sub-multiset
                currentPotential *= currentCounts[type];
                currentPotential /= currentLength;
                
                // consume type
                currentCounts[type]--;
            }
            return result;
        }

        #region Helpers & Variables

        private int[] typeCount;
        private int types;
        private int length;
        private int maxPotential;
        private int maxTypeLength;

        public int Potential
        {
            get
            {
                return maxPotential;
            }
        }
        
        private static decimal Factor(int f)
        {
            int res = 1;
            for (int i = 2; i <= f; i++)
            {
                res *= i;
            }
            return res;
        }

        private void ComputePotential()
        {
            //   factorial(len)
            // -------div---------
            //(factorial(inTypes[0]) * factorial(inTypes[1]) * .. * factorial(typesCount-1))
            decimal res = Factor(length);
            for (int t = 0; t < types; t++)
            {
                res /= Factor(typeCount[t]);
            }
            maxPotential = (int)res;
        }

        #endregion
    }
}