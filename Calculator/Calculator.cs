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
            SmartInsert(btn.Text);
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
            catch (DivideByZeroException)
            {
                textBoxResult.Text = "Cannot divide by zero";
                expression = "";
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
            SmartInsert("(");
        }

        private void buttonCloseParen_Click(object sender, EventArgs e)
        {
            SmartInsert(")");
        }
        private void buttonDot_Click(object sender, EventArgs e)
        {
            SmartInsert(".");
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            expression = "";
            textBoxResult.Text = expression;
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            ResetCaret();

            int pos = textBoxResult.SelectionStart;

            if (pos == 0) return;

            expression = expression.Remove(pos - 1, 1);
            textBoxResult.Text = expression;
            textBoxResult.SelectionStart = pos - 1;

            historyIndex = history.Count;

        }
        /*
         *  THIS PART IS FOR HANDLING THE ARROW BUTTONS
         *  TO NAVIGATE THROUGH THE EXPRESSION AND HISTORY
         *  HUHUHU LISODA DIAY
         * 
         * 
         * 
         */



        private List<string> history = new List<string>();
        private int historyIndex = -1; // Tracks where we are in the history
        private bool caretInitialized = false;



        private void pictureArrowLeft_Click(object sender, EventArgs e)
        {
            textBoxResult.Focus();
            textBoxResult.SelectionLength = 0;

            if (!caretInitialized)
            {
                // First RIGHT → jump to end
                textBoxResult.SelectionStart = textBoxResult.Text.Length;
                caretInitialized = true;
                return;
            }
            

            if (textBoxResult.SelectionStart > 0)
            {
                textBoxResult.SelectionStart--;
            }
        }

        private void pictureArrowRight_Click(object sender, EventArgs e)
        {
            textBoxResult.Focus();
            textBoxResult.SelectionLength = 0;

            if (!caretInitialized)
            {
                // First LEFT → jump to start
                textBoxResult.SelectionStart = 0;
                caretInitialized = true;
                return;
            }


            if (textBoxResult.SelectionStart < textBoxResult.Text.Length)
            {
                textBoxResult.SelectionStart++;
            }
        }

        private void SmartInsert(string value)
        {
            ResetCaret(); // editing resets jump behavior

            int start = textBoxResult.SelectionStart;
            int length = textBoxResult.SelectionLength;

            if (length > 0)
                expression = expression.Remove(start, length);

            expression = expression.Insert(start, value);

            textBoxResult.Text = expression;
            textBoxResult.SelectionStart = start + value.Length;
            textBoxResult.SelectionLength = 0;

            // Editing detaches from history navigation
            historyIndex = history.Count;
        }


        private void ResetCaret()
        {
            caretInitialized = false;
        }


        private void pictureArrowUp_Click(object sender, EventArgs e)
        {
            if (history.Count == 0) return;

            historyIndex--;
            if (historyIndex < 0) historyIndex = 0;

            expression = history[historyIndex];
            textBoxResult.Text = expression;
            ResetCaret();
            textBoxResult.SelectionStart = expression.Length;

        }
        private void pictureArrowDown_Click(object sender, EventArgs e)
        {

            if (history.Count == 0) return;

            historyIndex++;
            if (historyIndex >= history.Count) historyIndex = history.Count - 1;

            expression = history[historyIndex];
            textBoxResult.Text = expression;
            ResetCaret();
            textBoxResult.SelectionStart = expression.Length;

        }

    }


}