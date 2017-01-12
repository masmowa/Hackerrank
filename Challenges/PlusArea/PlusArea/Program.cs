using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusArea
{
    public class Cell
    {
        public int R { get; protected set; }  // row
        public int C { get; protected set; }  // column

        public Cell(int r, int c)
        {
            R = r;
            C = c;
        }
        public bool equals(Cell o)
        {
            if (o == null)
            {
                return false;
            }
            return (R == o.R && C == o.C);
        }
    }
    public class Plus
    {
        // TODO: Is this the top or the center?
        public int R { get; protected set; }  // row
        public int C { get; protected set; }  // column
        protected HashSet<Cell> cells;
        public HashSet<Cell> Cells { get; }
        protected bool[][] g;   // good 'G' not 'B'

        public Plus(int r, int c, bool [,] g)
        {
            R = r;
            C = c;
            Cells = new HashSet<Cell>();
            Cells.Add(new Cell(r, c));
            this.g = g;
        }

        public int Size() { return Cells.Count; }
        public int Count { get { return Cells.Count; } }
        public List<Plus> Grow()
        {
            List<Plus> pluses = new List<Plus>();
            return Grow(0, pluses, this);
        }
        public List<Plus> Grow(int len, List<Plus> pluses, Plus last)
        {
            Plus clone = new Plus(R, C, g);
            clone.cells = new HashSet<Cell>(last.Cells);
            pluses.Add(clone);
            ++len;
            if (!(R - len < 0
                || C - len < 0
                || g[R - len][C]
                || g[R][C - len]
                ))
            {
                return pluses;
            }
            Plus newP = last;
            newP.cells.Add(new Cell((R - len), C));
            newP.cells.Add(new Cell((R + len), C));
            newP.cells.Add(new Cell(R, (C - len)));
            newP.cells.Add(new Cell(R, (C + len)));
            pluses.Add(newP);

            return Grow(len, pluses, newP);
        }

        public bool IsCrossed(Plus plus)
        {
            bool result = true;
            int dx = Math.Abs(R - plus.R);
            int dy = Math.Abs(C - plus.C);
            result = ((dx == 0 && dy <= (Count / 2 + plus.Count / 2))
                || (dy == 0 && dx <= (Count / 2 + plus.Count / 2)));
            if (result)
            {
                return true;
            }
            result = (((dx <= Count / 2) && (dy <= plus.Count / 2))
                    || ((dy <= Count / 2) && (dx <= plus.Count / 2)));

            return result;
        }
        public bool IsOverlapping(Plus p1, Plus p2)
        {
            foreach (Cell cell in p1.Cells)
            {
                foreach (Cell c in p2.Cells)
                {
                    if (p1.Equals(c)) return true;
                }
            }
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // get the dimensions of the "game-board"
            // Split to array of strings, seperated by spaces
            // convert each value to Int32
            // store in integer array
            int[] MN = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int r = MN[0];
            int c = MN[1];
            // read the G B values for each row of the board
            List<string> board = new List<string>();
            bool[,] grid = new bool[MN[0], MN[1]];
            for (int ir=0; ir < r; ++ir)
            {
                string row = Console.ReadLine();
                board.Add(row);
                // prime the grid with 'true' for each 'G' cell
                // I guess that the default is 'false' (?)
                for (int jc = 0; jc < c; ++jc)
                {
                    grid[ir, jc] = row[jc] == 'G';
                }
            }

            // TODO: CREATE A LIST / HASH LIST (?) of all the plusses on the board
            for (int ir=0; ir < r; ++ir )
            {

            }

        }
    }
}
