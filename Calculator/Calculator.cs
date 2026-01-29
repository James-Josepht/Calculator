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
            expression += btn.Text;
            textBoxResult.Text = expression;
        }
        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] seperatedNum;

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
                newNumberAlert = false;
                return;
            }

            expression += btn.Text;

            newNumberAlert = false;
            textBoxResult.Text = expression;
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            var table = new DataTable();

            if (!expression.Any(char.IsDigit))
            {
                textBoxResult.Text = "Error";
                return;
            }

            // Build computation string with implicit multiplication
            string computation = "";
            for (int i = 0; i < expression.Length; i++)
            {
                char current = expression[i];

                if (i > 0)
                {
                    char prev = expression[i - 1];

                    // Insert '*' in these cases:
                    // 1) ')' followed by '(' or a digit
                    // 2) digit followed by '('
                    if ((prev == ')' && (current == '(' || char.IsDigit(current))) ||
                        (char.IsDigit(prev) && current == '('))
                    {
                        computation += "*";
                    }
                }

                computation += current;
            }

            try
            {
                if (computation.Contains("/0"))
                    throw new DivideByZeroException();

                var result = table.Compute(computation, "");
                textBoxResult.Text = result.ToString();

                // -------------------------
                // Save to history BEFORE overwriting expression
                history.Add(expression);
                historyIndex = history.Count; // reset index to after the last element
                                              // -------------------------

                // Update expression with result (displayed) 
                expression = result.ToString();
            }
            catch
            {
                textBoxResult.Text = "Error";
                expression = "";
            }
        }


        private void buttonPosOrNeg_Click(object sender, EventArgs e)
        {
            ToggleLastNumberSign();
        }

        private void ToggleLastNumberSign()
        {
            if (string.IsNullOrEmpty(expression))
                return;

            int i = expression.Length - 1;

            // Move left while digit or dot
            while (i >= 0 && (char.IsDigit(expression[i]) || expression[i] == '.'))
                i--;

            // Check for unary minus
            if (i >= 0 && expression[i] == '-' &&
                (i == 0 || "+-*/(".Contains(expression[i - 1])))
            {
                // Remove the minus
                expression = expression.Remove(i, 1);
            }
            else
            {
                // Insert minus
                expression = expression.Insert(i + 1, "-");
            }

            textBoxResult.Text = expression;
        }




        private void Calculator_Load(object sender, EventArgs e)
        {

        }

        private void buttonOpenParen_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            expression += button.Text;
            textBoxResult.Text = expression;
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



        private List<string> history = new List<string>();
        private int historyIndex = -1; // Tracks where we are in the history

        private void pictureArrowDown_Click(object sender, EventArgs e)
        {

            if (history.Count == 0) return;

            historyIndex++;
            if (historyIndex >= history.Count) historyIndex = history.Count - 1;

            expression = history[historyIndex];
            textBoxResult.Text = expression;
        }

        private void pictureArrowLeft_Click(object sender, EventArgs e)
        {
            // Ensure the cursor doesn't go past the start
            if (textBoxResult.SelectionStart > 0)
            {
                textBoxResult.SelectionStart--;
                textBoxResult.SelectionLength = 0; // just move cursor, no selection
            }
        }

        private void pictureArrowUp_Click(object sender, EventArgs e)
        {
            if (history.Count == 0) return;

            historyIndex--;
            if (historyIndex < 0) historyIndex = 0;

            expression = history[historyIndex];
            textBoxResult.Text = expression;
        }

        private void pictureArrowRight_Click(object sender, EventArgs e)
        {
            if (textBoxResult.SelectionStart < textBoxResult.Text.Length)
            {
                textBoxResult.SelectionStart++;
                textBoxResult.SelectionLength = 0;
            }
        }
    }


}
