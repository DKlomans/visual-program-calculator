using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;
        private Button btnAdd, btnSubtract, btnMultiply, btnDivide, btnPow, btnSqrt, btnCos, btnSin, btnClear;

        public Form1()
        {
            InitializeComponent();
            InitializeCalculatorControls();
        }

        private void InitializeCalculatorControls()
        {
            textBox1 = new TextBox { Location = new System.Drawing.Point(12, 12), Width = 210 };
            Controls.Add(textBox1);

            btnAdd = CreateButton("+", new System.Drawing.Point(12, 40), btnAdd_Click);
            btnSubtract = CreateButton("-", new System.Drawing.Point(62, 40), btnSubtract_Click);
            btnMultiply = CreateButton("*", new System.Drawing.Point(112, 40), btnMultiply_Click);
            btnDivide = CreateButton("/", new System.Drawing.Point(162, 40), btnDivide_Click);
            btnPow = CreateButton("Pow", new System.Drawing.Point(12, 70), btnPow_Click);
            btnSqrt = CreateButton("Sqrt", new System.Drawing.Point(62, 70), btnSqrt_Click);
            btnCos = CreateButton("Cos", new System.Drawing.Point(112, 70), btnCos_Click);
            btnSin = CreateButton("Sin", new System.Drawing.Point(162, 70), btnSin_Click);
            btnClear = CreateButton("Clear", new System.Drawing.Point(12, 100), btnClear_Click);
        }

        private Button CreateButton(string text, System.Drawing.Point location, EventHandler clickEvent)
        {
            Button button = new Button { Text = text, Location = location, Size = new System.Drawing.Size(50, 28) };
            button.Click += clickEvent;
            Controls.Add(button);
            return button;
        }

        private void btnAdd_Click(object sender, EventArgs e) => PerformOperation("+");
        private void btnSubtract_Click(object sender, EventArgs e) => PerformOperation("-");
        private void btnMultiply_Click(object sender, EventArgs e) => PerformOperation("*");
        private void btnDivide_Click(object sender, EventArgs e) => PerformOperation("/");
        private void btnPow_Click(object sender, EventArgs e) => PerformOperation("Pow");
        private void btnSqrt_Click(object sender, EventArgs e) => PerformOperation("Sqrt");
        private void btnCos_Click(object sender, EventArgs e) => PerformOperation("Cos");
        private void btnSin_Click(object sender, EventArgs e) => PerformOperation("Sin");
        private void btnClear_Click(object sender, EventArgs e) => textBox1.Text = "";

        private void PerformOperation(string operation)
        {
            try
            {
                double result = 0;
                double number = double.Parse(textBox1.Text);

                switch (operation)
                {
                    case "+": result = number + number; break;
                    case "-": result = number - number; break;
                    case "*": result = number * number; break;
                    case "/": result = number != 0 ? number / number : 0; break;
                    case "Pow": result = Math.Pow(number, 2); break;
                    case "Sqrt": result = Math.Sqrt(number); break;
                    case "Cos": result = Math.Cos(number); break;
                    case "Sin": result = Math.Sin(number); break;
                }

                textBox1.Text = result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
