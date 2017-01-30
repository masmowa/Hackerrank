using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

namespace howto_calculate_n_choose_k
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get N and K.
            decimal N = decimal.Parse(txtN.Text);
            decimal K = decimal.Parse(txtK.Text);

            // Calculate using factorials.
            try
            {
                txtWFactorials.Text = MChooseNFactorial(N, K).ToString();
            }
            catch
            {
                txtWFactorials.Text = "Error";
            }

            // Calculate using the more direct method.
            try
            {
                txtDirect.Text = NChooseK(N, K).ToString();
            }
            catch
            {
                txtDirect.Text = "Error";
            }
        }

        // Return N choose K calculated directly.
        // For a description of the algorithm, see:
        //      http://csharphelper.com/blog/2014/08/calculate-the-binomial-coefficient-n-choose-k-efficiently-in-c/
        private decimal NChooseK(decimal N, decimal K)
        {
            Debug.Assert(N >= 0);
            Debug.Assert(K >= 0);
            Debug.Assert(N >= K);

            decimal result = 1;
            for (int i = 1; i <= K; i++)
            {
                result *= N - (K - i);
                result /= i;
            }
            return result;
        }

        // Use the Factorial function to calculate M choose N.
        private decimal MChooseNFactorial(decimal M, decimal N)
        {
            Debug.Assert(M >= 0);
            Debug.Assert(N >= 0);
            Debug.Assert(M >= N);

            return Factorial(M) / Factorial(N) / Factorial(M - N);
        }

        // Calculate N!
        private decimal Factorial(decimal N)
        {
            Debug.Assert(N >= 0);

            decimal result = 1;
            for (decimal i = 2; i <= N; i++) result *= i;
            return result;
        }
    }
}
