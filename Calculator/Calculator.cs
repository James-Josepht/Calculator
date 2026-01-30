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
            textBoxResult.ReadOnly = true;
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SmartInsert(btn.Text);
        }
        private void operation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // If the user has moved the caret with the arrow buttons (caretInitialized == true)
            // then insert at the caret. Otherwise (default) append at the end.
            bool userMovedCaret = caretInitialized;

            int start = textBoxResult.SelectionStart;
            int length = textBoxResult.SelectionLength;

            // Decide insertion position: caret (if user moved) or end (default)
            int pos = userMovedCaret ? start : expression.Length;

            // If user moved caret and there is a selection, remove it first.
            if (userMovedCaret && length > 0)
                expression = expression.Remove(start, length);

            // If there's an operator immediately to the left of insertion position, replace it.
            if (pos > 0 && pos - 1 < expression.Length && "+-*/".Contains(expression[pos - 1]))
            {
                expression = expression.Remove(pos - 1, 1).Insert(pos - 1, btn.Text);
                textBoxResult.Text = expression;

                // caret: keep it right after the operator. If appending, keep at end.
                textBoxResult.SelectionStart = userMovedCaret ? pos : expression.Length;
                textBoxResult.SelectionLength = 0;

                newNumberAlert = false;
                historyIndex = history.Count;
                return;
            }

            // Normal insert at chosen position
            expression = expression.Insert(pos, btn.Text);
            textBoxResult.Text = expression;

            if (userMovedCaret)
            {
                // place caret after the inserted operator at the caret position
                textBoxResult.SelectionStart = pos + btn.Text.Length;
            }
            else
            {
                // default behavior: show operator at the end and keep caret at end
                textBoxResult.SelectionStart = expression.Length;
            }

            textBoxResult.SelectionLength = 0;
            newNumberAlert = false;
            historyIndex = history.Count;
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

                // Put caret at the end so new typing appends to the result (not at start)
                textBoxResult.SelectionStart = textBoxResult.Text.Length;
                textBoxResult.SelectionLength = 0;
                textBoxResult.Focus();

                // keep caret/jump behavior consistent
                ResetCaret();
            }
            catch (DivideByZeroException)
            {
                textBoxResult.Text = "Error";
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
            // preserve caret position (use end of selection if text is selected)
            int caret = textBoxResult.SelectionStart + textBoxResult.SelectionLength;
            // keep existing caret/jump behavior in sync
            ResetCaret();
            ToggleLastNumberSign(caret);
        }

        // Toggle the sign of the number that contains (or is immediately left of) caretPos.
        private void ToggleLastNumberSign(int caretPos)
        {
            if (string.IsNullOrEmpty(expression))
                return;

            // clamp caretPos to expression length
            if (caretPos < 0) caretPos = 0;
            if (caretPos > expression.Length) caretPos = expression.Length;

            // choose a starting scan position: if there's a digit to the left of caret use that,
            // otherwise try the char at caret (covers caret at start of a number).
            int scan = caretPos - 1;
            if (scan < 0 && expression.Length > 0 && (char.IsDigit(expression[0]) || expression[0] == '.'))
                scan = 0;

            // If caret isn't within or adjacent to a number, fall back to last number in expression
            if (scan < 0 || !(char.IsDigit(expression[scan]) || expression[scan] == '.'))
            {
                scan = expression.Length - 1;
                while (scan >= 0 && !(char.IsDigit(expression[scan]) || expression[scan] == '.')) scan--;
                if (scan < 0) return; // no number found
            }

            // Move left while digit or dot to find the number's left boundary
            int left = scan;
            while (left >= 0 && (char.IsDigit(expression[left]) || expression[left] == '.')) left--;

            // left now points to the char before the number (or -1)
            int insertPos = left + 1;

            // Check for unary minus immediately before number
            if (left >= 0 && expression[left] == '-' &&
                (left == 0 || "+-*/(".Contains(expression[left - 1])))
            {
                // Remove the minus and adjust caret if needed
                expression = expression.Remove(left, 1);
                if (caretPos > left) caretPos = Math.Max(0, caretPos - 1);
            }
            else
            {
                // Insert a minus before the number and adjust caret if needed
                expression = expression.Insert(insertPos, "-");
                if (caretPos > insertPos) caretPos = Math.Min(expression.Length, caretPos + 1);
            }

            textBoxResult.Text = expression;

            // restore caret to a sensible position (clamped)
            textBoxResult.SelectionStart = Math.Clamp(caretPos, 0, expression.Length);
            textBoxResult.SelectionLength = 0;
        }

        private void ToggleLastNumberSign()
        {
            // kept for backward compatibility if called elsewhere without caret info
            int caret = textBoxResult.SelectionStart + textBoxResult.SelectionLength;
            ToggleLastNumberSign(caret);
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

            // Remove selection first (existing behavior)
            if (length > 0)
                expression = expression.Remove(start, length);

            // If user requests a dot, ensure the current number doesn't already contain one.
            if (value == ".")
            {
                // Find the bounds of the number at the insertion point (digits and dots)
                int left = start - 1;
                while (left >= 0 && (char.IsDigit(expression[left]) || expression[left] == '.')) left--;
                int right = start;
                while (right < expression.Length && (char.IsDigit(expression[right]) || expression[right] == '.')) right++;

                string currentNumber = expression.Substring(left + 1, right - (left + 1)); // may be empty

                // If the number already has a dot, ignore the insertion.
                if (currentNumber.Contains("."))
                    return;

                // If inserting dot at a position that should start a number (start of expression
                // or after an operator or '('), prefer inserting "0." instead of just "."
                bool needLeadingZero = (start == 0) || (start > 0 && "+-*/(".Contains(expression[start - 1]));
                if (needLeadingZero)
                    value = "0.";
            }

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