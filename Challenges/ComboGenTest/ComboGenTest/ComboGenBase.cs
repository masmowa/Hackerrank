using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboGenTest
{
    abstract public class ComboGenBase<T> 
    {
        protected List<T> m_items;
        protected int m_count;
        protected int m_nMaxIndex;

        // Because we use m_arrayIndeces internally to store the current combination
        // we need the DUMMY array to be returned to the user so that he cannot modify
        // the internal state of the COMBINATION which will be possible if 
        // we return direcly m_arrayIndeces. This is one of the weaknesses of the 
        // C# & CLI -> There is no const-nes over arrays in the sence of C++, too bad :-(
        // this array is a "map" into the item list; 
        // the program will copy the contents of the original list from indicy location to 
        // an "ordinal" location; which is a permutation of the original list, with 
        // the position of one item shifted to a new position.
        protected int[] m_arrayIndeces;
        protected int[] m_arrayIndecesDummy;

        protected List<T> m_currentCombination;
        protected bool m_bInitialized;

        public ComboGenBase (List<T> vals, int nKlass)
        {
            m_items = vals;
            m_count = vals.Count;
            DoArgumentCheck(vals.Count, nKlass);

            m_nMaxIndex = vals.Count - 1;

            m_arrayIndeces = new int[m_count];
            m_arrayIndecesDummy = new int[m_count];

            m_items = new List<T>(vals);
        }

        protected void DoArgumentCheck(int nItems, int nKlass)
        {
            if (nKlass <= 0)
                throw new ArgumentOutOfRangeException("nKlass", nKlass,
                "Second parameter (nKlass) to ComboGenBase constructor must be > 0");

            if (nItems < nKlass)
                throw new ArgumentOutOfRangeException("nKlass", nKlass,
                    "Less than needed objects supplied. Second " +
                    "parameter of ComboGenBase cannot be greater that the number " +
                    "of objects");

        }
        public void Reset()
        {
            m_bInitialized = false;
        }
        protected int[] FirstIndeces()
        {
            return FirstIndeces(true);
        }
        // This one is made virtual. If you need a different initializing
        // sequence than the default {0, 1, 2, ..., N} then override it.
        virtual protected int[] FirstIndeces(bool bReturnDublicate)
        {
            // each element in m_arrayIndeces references an element in m_items;
            for (int i = 0; i < m_arrayIndeces.Length; i++)
                m_arrayIndeces[i] = i;

            m_bInitialized = true;

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
        } // End of FirstIndeces
        abstract protected int[] NextIndeces(bool bReturnDublicate);

        /// <summary>
        /// return the next combination
        /// </summary>
        /// <returns>List of items arranged into next combination</returns>
        protected List<T> NextItems()
        {

            // Generate the indeces of the elements that are going to
            // take part in the next combination.
            int[] res = NextIndeces(false);

            if (res == null) return null;

            for (int j = 0; j < m_arrayIndeces.Length; j++)
            {
                int nIndex = m_arrayIndeces[j];
                m_currentCombination[j] = m_items[nIndex];
            }

            return m_currentCombination;
        }


        public int[] CurrentIndeces
        {

            get
            {
                if (!m_bInitialized)
                    throw new InvalidOperationException("CombinatorialBase collection must be Reset() before usage");

                // Copy not to allow modification of m_arrayIndeces.
                Array.Copy(m_arrayIndeces, m_arrayIndecesDummy, m_count);
                return m_arrayIndecesDummy;
            }
        }
        protected List<T> CurrentItems()
        {

            if (!m_bInitialized)
                throw new InvalidOperationException("CombinatorialBase collection must be Reset() before usage");

            // Fill the return array properly.
            for (int j = 0; j < m_arrayIndeces.Length; j++)
            {
                int nIndex = m_arrayIndeces[j];
                m_currentCombination[j] = m_items[nIndex];
            }

            // And return it.
            return m_currentCombination;
        }
    }
}
