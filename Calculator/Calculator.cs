using System.Data;
using System.Linq.Expressions;

namespace Calculator
{
    public partial class Calculator : Form
    {

        //declaring variables
        private string currentInput = String.Empty;
        private double result = 0;
        private string operation = String.Empty;
        private string expression = String.Empty;


        public Calculator()
        {
            InitializeComponent();
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            expression += btn.Text;
            textBoxResult.Text = expression;
        }
        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Prevent double operators like ++ or **
            /*if (expression.Length == 0)
                return;*/

            char lastChar = expression[^1];
            if ("+-*/".Contains(lastChar))
                return;

            expression += btn.Text;
            textBoxResult.Text = expression;
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            var table = new DataTable();
            var result = table.Compute(expression, "");
            textBoxResult.Text = result.ToString();
            expression = result.ToString();
        }
      


        private void Calculator_Load(object sender, EventArgs e)
        {

        }


        private void buttonParenthesis_Click(object sender, EventArgs e)
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
        private void buttonOff_Click(object sender, EventArgs e)
        {

        }


    }

 
}
