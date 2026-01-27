namespace Calculator
{
    public partial class Calculator : Form
    {
        CalculatorLogic calcLogic = new CalculatorLogic();

        //declaring variables
        private string currentInput = String.Empty;
        private double result = 0;
        private string operation = String.Empty;
        private bool operationPending = false;


        public Calculator()
        {
            InitializeComponent();
        }

        /* 
          private void button5_Click(object sender, EventArgs e)
          {
              Button button = (Button)sender;
              currentInput += button.Text;
              textBoxResult.Text = currentInput;

          }
        */

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (textBoxResult.Text == "0" || operationPending)
            {
                textBoxResult.Text = btn.Text;
                operationPending = false;
            }
            else
            {
                textBoxResult.Text += btn.Text;
            }
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void buttonParenthesis_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBoxResult.Text = currentInput;
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBoxResult.Text = currentInput;
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {

        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBoxResult.Text = currentInput;
        }
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBoxResult.Text = currentInput;
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBoxResult.Text = currentInput;
        }
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            textBoxResult.Text = currentInput;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {

        }
        private void buttonOff_Click(object sender, EventArgs e)
        {

        }


    }

    public partial class CalculatorLogic: Form
    {

        public void Clear(ref string currentInput, ref double result, ref string operation, ref bool operationPending)
        {
            currentInput = String.Empty;
            result = 0;
            operation = String.Empty;
            operationPending = false;
        }


        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }

   
}
