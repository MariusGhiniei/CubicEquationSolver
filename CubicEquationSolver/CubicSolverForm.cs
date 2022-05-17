using System;
using System.Numerics;
using System.Windows.Forms;

namespace CubicEquationSolver
{
    public partial class CubicSolverForm : Form
    {
        readonly Cubic _cubic = new Cubic();
        Complex[] _solutions;

        double A
        {
            get => double.Parse(textBox2.Text);
            set => textBox2.Text = value.ToString();
        }

        double B
        {
            get => double.Parse(textBox3.Text);
            set => textBox3.Text = value.ToString();
        }

        double C
        {
            get => double.Parse(textBox4.Text);
            set => textBox4.Text = value.ToString();
        }

        double D
        {
            get => double.Parse(textBox5.Text);
            set => textBox5.Text = value.ToString();
        }

        string X1
        {
            get => textBox6.Text;
            set => textBox6.Text = value;
        }
        string X2
        {
            get => textBox7.Text;
            set => textBox7.Text = value;
        }
        string X3
        {
            get => textBox8.Text;
            set => textBox8.Text = value;
        }


        public CubicSolverForm()
        {
            InitializeComponent();
            button1.Click += (s, e) => Execute();
        }
        private void Execute()
        {
            _solutions = _cubic.Solve(A, B, C, D);
            if (_solutions != null)
            {
                X1 = ComplexToString(_solutions[0]);
                X2 = ComplexToString(_solutions[1]);
                X3 = ComplexToString(_solutions[2]);
            }
            else
            {
                X1 = "null";
                X2 = "null";
                X3 = "null";
            }

        }

        string ComplexToString(Complex z)
        {
            int len = 5;
            string s = $"N{len}"; // 5 decimals for solutions
            if (z.Imaginary == 0)
            {
                return z.Real.ToString(s);
            }

            if (z.Real == 0)
            {
                return z.Imaginary.ToString(s) + "i";
            }

            return (z.Real == 0 ? "" : z.Real.ToString(s)) +
                   (z.Imaginary >= 0 ? " + " : " - ") +
                   Math.Abs(z.Imaginary).ToString(s) + "i";
        }
       

        private void CubicSolverForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
