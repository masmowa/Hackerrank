using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboGenTest
{
    public class Combinations<T> : ComboGenBase<T>
    {
        public Combinations(List<T> vals, int nKlass) : base(vals, nKlass)
        {
        }

        protected override int[] NextIndeces(bool bReturnDublicate)
        {
            if (!m_bInitialized)
            {
                return FirstIndeces(false);
            }

            // Find the first item that has not reached its maximum value.
            int nIndex = m_count;
            for (int i = m_arrayIndeces.Length - 1; i >= 0; i--)
            {
                if (m_arrayIndeces[i] < m_nMaxIndex - (m_count - 1 - i))
                {
                    nIndex = i;
                    break;
                }
            }

            // No more combinations to be generated. Every item has reached its
            // maximum value.
            if (nIndex == m_count)
                return new int[0];

            // Genereate the next combination in lexographical order.
            m_arrayIndeces[nIndex]++;
            for (int i = nIndex + 1; i < m_arrayIndeces.Length; i++)
            {
                m_arrayIndeces[i] = m_arrayIndeces[i - 1] + 1;
            }

            if (bReturnDublicate)
            {
                // Copy not to allow modification of m_arrayIndeces.
                Array.Copy(m_arrayIndeces, m_arrayIndecesDummy, m_count);
                return m_arrayIndecesDummy;
            }
            else
            {
                return m_arrayIndeces;
            }
        }
    }
}
