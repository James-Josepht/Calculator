using System.Data;
using System.Drawing.Design;
using System.Linq.Expressions;

namespace Calculator
{
    public partial class Calculator : Form
    {

        //declaring variables
        private double currentNumber = 0;
        private double result = 0;
        private string operation = String.Empty;
        private string expression = String.Empty;
        private bool newNumberAlert = true;


        public Calculator()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (newNumberAlert)
            {
                expression += btn.Text;
                currentNumber = Double.Parse(expression);
                textBoxResult.Text = expression;
 
            }
            else
            {
                expression += btn.Text;
                textBoxResult.Text = expression;
            }

        }
        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //if it is empty just add the operator
            if (expression.Length == 0)
            {
                expression += btn.Text;
                textBoxResult.Text = expression;
                return;
            }

            //check last char, then if its an operator, replace it by the current one
            char lastChar = expression[^1];
            if ("+-*/".Contains(lastChar))
            {
                expression = expression.Substring(0, expression.Length - 1) + btn.Text;
                textBoxResult.Text = expression;
                currentNumber = 0;
                newNumberAlert = false;
                return;
            }

            expression += btn.Text;
            currentNumber = 0;
            newNumberAlert = false;
            textBoxResult.Text = expression;
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            var table = new DataTable();
            object result;
            try
            {
                if (expression.Contains("/0"))
                    throw new DivideByZeroException();
                result = table.Compute(expression, "");
            }
            catch (Exception ex)
            {
                textBoxResult.Text = "Error";
                expression = "";
                return;
            }

            textBoxResult.Text = result.ToString();
            expression = result.ToString();
        }



        private void Calculator_Load(object sender, EventArgs e)
        {

        }


        private void buttonCloseParen_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expression += button.Text;
            textBoxResult.Text = expression;
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expression += button.Text;
            textBoxResult.Text = expression;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            expression = "";
            textBoxResult.Text = expression;
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(expression))
            {
                expression = expression.Substring(0, expression.Length - 1);
            }

            textBoxResult.Text = expression;

        }

        private void buttonPosOrNeg_Click(object sender, EventArgs e)
        {
            if (currentNumber.ToString().Contains("-"))
            {
                currentNumber = Math.Abs(currentNumber);
                expression = currentNumber.ToString();
                textBoxResult.Text = expression;
                return;
            }

            currentNumber = -Double.Parse(expression); // flip sign
            expression = currentNumber.ToString();
            textBoxResult.Text = expression;  // update display
        }

        private void buttonOpenParen_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expression += button.Text;
            textBoxResult.Text = expression;
        }


        private void pictureArrowRight_MouseEnter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void textBoxResult_TextChanged(object sender, EventArgs e)
        {

        }

        
    }

    public partial class PictureCalc
    {
        
    }
}
