namespace Calculator
{
    partial class Calculator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            buttonNum6 = new Button();
            buttonNum5 = new Button();
            buttonNum4 = new Button();
            buttonNum9 = new Button();
            buttonNum8 = new Button();
            buttonNum7 = new Button();
            buttonParenthesis = new Button();
            buttonMinus = new Button();
            buttonAdd = new Button();
            buttonBackspace = new Button();
            buttonMultiply = new Button();
            buttonDivide = new Button();
            buttonEquals = new Button();
            buttonClear = new Button();
            textBoxResult = new TextBox();
            buttonDot = new Button();
            button0 = new Button();
            pictureArrowRight = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureArrowRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(26, 240);
            button1.Name = "button1";
            button1.Size = new Size(100, 40);
            button1.TabIndex = 0;
            button1.Text = "1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += NumButton_Click;
            // 
            // button2
            // 
            button2.Location = new Point(132, 240);
            button2.Name = "button2";
            button2.Size = new Size(100, 40);
            button2.TabIndex = 1;
            button2.Text = "2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += NumButton_Click;
            // 
            // button3
            // 
            button3.Location = new Point(238, 240);
            button3.Name = "button3";
            button3.Size = new Size(100, 40);
            button3.TabIndex = 2;
            button3.Text = "3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += NumButton_Click;
            // 
            // buttonNum6
            // 
            buttonNum6.Location = new Point(238, 286);
            buttonNum6.Name = "buttonNum6";
            buttonNum6.Size = new Size(100, 40);
            buttonNum6.TabIndex = 5;
            buttonNum6.Text = "6";
            buttonNum6.UseVisualStyleBackColor = true;
            buttonNum6.Click += NumButton_Click;
            // 
            // buttonNum5
            // 
            buttonNum5.Location = new Point(132, 286);
            buttonNum5.Name = "buttonNum5";
            buttonNum5.Size = new Size(100, 40);
            buttonNum5.TabIndex = 4;
            buttonNum5.Text = "5";
            buttonNum5.UseVisualStyleBackColor = true;
            buttonNum5.Click += NumButton_Click;
            // 
            // buttonNum4
            // 
            buttonNum4.Location = new Point(26, 286);
            buttonNum4.Name = "buttonNum4";
            buttonNum4.Size = new Size(100, 40);
            buttonNum4.TabIndex = 3;
            buttonNum4.Text = "4";
            buttonNum4.UseVisualStyleBackColor = true;
            buttonNum4.Click += NumButton_Click;
            // 
            // buttonNum9
            // 
            buttonNum9.Location = new Point(238, 332);
            buttonNum9.Name = "buttonNum9";
            buttonNum9.Size = new Size(100, 40);
            buttonNum9.TabIndex = 8;
            buttonNum9.Text = "9";
            buttonNum9.UseVisualStyleBackColor = true;
            buttonNum9.Click += NumButton_Click;
            // 
            // buttonNum8
            // 
            buttonNum8.Location = new Point(132, 332);
            buttonNum8.Name = "buttonNum8";
            buttonNum8.Size = new Size(100, 40);
            buttonNum8.TabIndex = 7;
            buttonNum8.Text = "8";
            buttonNum8.UseVisualStyleBackColor = true;
            buttonNum8.Click += NumButton_Click;
            // 
            // buttonNum7
            // 
            buttonNum7.Location = new Point(26, 332);
            buttonNum7.Name = "buttonNum7";
            buttonNum7.Size = new Size(100, 40);
            buttonNum7.TabIndex = 6;
            buttonNum7.Text = "7";
            buttonNum7.UseVisualStyleBackColor = true;
            buttonNum7.Click += NumButton_Click;
            // 
            // buttonParenthesis
            // 
            buttonParenthesis.Location = new Point(26, 204);
            buttonParenthesis.Name = "buttonParenthesis";
            buttonParenthesis.Size = new Size(180, 30);
            buttonParenthesis.TabIndex = 9;
            buttonParenthesis.Text = "( )";
            buttonParenthesis.UseVisualStyleBackColor = true;
            buttonParenthesis.Click += buttonParenthesis_Click;
            // 
            // buttonMinus
            // 
            buttonMinus.Location = new Point(361, 316);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(50, 30);
            buttonMinus.TabIndex = 10;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += operation_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(361, 280);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(50, 30);
            buttonAdd.TabIndex = 11;
            buttonAdd.Text = "+";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += operation_Click;
            // 
            // buttonBackspace
            // 
            buttonBackspace.BackColor = Color.FromArgb(255, 224, 192);
            buttonBackspace.ForeColor = SystemColors.ControlText;
            buttonBackspace.Location = new Point(212, 204);
            buttonBackspace.Name = "buttonBackspace";
            buttonBackspace.Size = new Size(199, 30);
            buttonBackspace.TabIndex = 12;
            buttonBackspace.Text = "←";
            buttonBackspace.UseVisualStyleBackColor = false;
            buttonBackspace.Click += buttonOff_Click;
            // 
            // buttonMultiply
            // 
            buttonMultiply.Location = new Point(361, 352);
            buttonMultiply.Name = "buttonMultiply";
            buttonMultiply.Size = new Size(50, 30);
            buttonMultiply.TabIndex = 13;
            buttonMultiply.Text = "*";
            buttonMultiply.UseVisualStyleBackColor = true;
            buttonMultiply.Click += operation_Click;
            // 
            // buttonDivide
            // 
            buttonDivide.Location = new Point(361, 388);
            buttonDivide.Name = "buttonDivide";
            buttonDivide.Size = new Size(50, 30);
            buttonDivide.TabIndex = 14;
            buttonDivide.Text = "/";
            buttonDivide.UseVisualStyleBackColor = true;
            buttonDivide.Click += operation_Click;
            // 
            // buttonEquals
            // 
            buttonEquals.Location = new Point(188, 378);
            buttonEquals.Name = "buttonEquals";
            buttonEquals.Size = new Size(150, 40);
            buttonEquals.TabIndex = 15;
            buttonEquals.Text = "=";
            buttonEquals.UseVisualStyleBackColor = true;
            buttonEquals.Click += buttonEquals_Click;
            // 
            // buttonClear
            // 
            buttonClear.BackColor = Color.LightCoral;
            buttonClear.Location = new Point(361, 240);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(50, 30);
            buttonClear.TabIndex = 16;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = false;
            buttonClear.Click += buttonClear_Click;
            // 
            // textBoxResult
            // 
            textBoxResult.BorderStyle = BorderStyle.FixedSingle;
            textBoxResult.Font = new Font("Lucida Sans Unicode", 30F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxResult.Location = new Point(26, 38);
            textBoxResult.MaximumSize = new Size(500, 200);
            textBoxResult.Name = "textBoxResult";
            textBoxResult.Size = new Size(385, 69);
            textBoxResult.TabIndex = 17;
            textBoxResult.TextAlign = HorizontalAlignment.Right;
            textBoxResult.TextChanged += textBoxResult_TextChanged;
            // 
            // buttonDot
            // 
            buttonDot.Location = new Point(132, 378);
            buttonDot.Name = "buttonDot";
            buttonDot.Size = new Size(50, 40);
            buttonDot.TabIndex = 19;
            buttonDot.Text = ".";
            buttonDot.UseVisualStyleBackColor = true;
            buttonDot.Click += buttonDot_Click;
            // 
            // button0
            // 
            button0.Location = new Point(26, 378);
            button0.Name = "button0";
            button0.Size = new Size(100, 40);
            button0.TabIndex = 18;
            button0.Text = "0";
            button0.UseVisualStyleBackColor = true;
            button0.Click += NumButton_Click;
            // 
            // pictureArrowRight
            // 
            pictureArrowRight.Image = CalculatorApp.Properties.Resources.arrow_calc_removebg_preview_removebg_preview;
            pictureArrowRight.Location = new Point(238, 142);
            pictureArrowRight.Margin = new Padding(0);
            pictureArrowRight.Name = "pictureArrowRight";
            pictureArrowRight.Size = new Size(39, 39);
            pictureArrowRight.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureArrowRight.TabIndex = 20;
            pictureArrowRight.TabStop = false;
            pictureArrowRight.MouseEnter += pictureArrowRight_MouseEnter;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(160, 141);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 39);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click_1;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(199, 164);
            pictureBox2.Margin = new Padding(0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(39, 39);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 22;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(199, 122);
            pictureBox3.Margin = new Padding(0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(39, 39);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 23;
            pictureBox3.TabStop = false;
            pictureBox3.MouseClick += pictureBox3_MouseClick;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(441, 431);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureArrowRight);
            Controls.Add(buttonDot);
            Controls.Add(button0);
            Controls.Add(textBoxResult);
            Controls.Add(buttonClear);
            Controls.Add(buttonEquals);
            Controls.Add(buttonDivide);
            Controls.Add(buttonMultiply);
            Controls.Add(buttonBackspace);
            Controls.Add(buttonAdd);
            Controls.Add(buttonMinus);
            Controls.Add(buttonParenthesis);
            Controls.Add(buttonNum9);
            Controls.Add(buttonNum8);
            Controls.Add(buttonNum7);
            Controls.Add(buttonNum6);
            Controls.Add(buttonNum5);
            Controls.Add(buttonNum4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Calculator";
            Text = "Calculator";
            Load += Calculator_Load;
            ((System.ComponentModel.ISupportInitialize)pictureArrowRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button buttonNum6;
        private Button buttonNum5;
        private Button buttonNum4;
        private Button buttonNum9;
        private Button buttonNum8;
        private Button buttonNum7;
        private Button buttonParenthesis;
        private Button buttonMinus;
        private Button buttonAdd;
        private Button buttonBackspace;
        private Button buttonMultiply;
        private Button buttonDivide;
        private Button buttonEquals;
        private Button buttonClear;
        private TextBox textBoxResult;
        private Button buttonDot;
        private Button button0;
        private PictureBox pictureArrowRight;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
    }
}
