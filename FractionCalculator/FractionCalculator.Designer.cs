namespace FractionCalculator
{
    partial class FractionCalculator
    {
        public static FractionCalculator Instance { get; private set; }
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
            this.components = new System.ComponentModel.Container();
            this.button0 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.buttonFraction = new System.Windows.Forms.Button();
            this.labelCurrentFraction = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSubtract = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.labelEquation = new System.Windows.Forms.Label();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonOpenParenthesis = new System.Windows.Forms.Button();
            this.buttonCloseParenthesis = new System.Windows.Forms.Button();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonUndoLast = new System.Windows.Forms.Button();
            this.fractionToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.clearToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.solveToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openParenthesisToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.closeParenthesisToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.undoLastToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(133, 138);
            this.button0.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(69, 61);
            this.button0.TabIndex = 2;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 138);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(53, 213);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 61);
            this.button2.TabIndex = 4;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(133, 213);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 61);
            this.button3.TabIndex = 5;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(215, 213);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 61);
            this.button4.TabIndex = 6;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(53, 286);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 61);
            this.button5.TabIndex = 7;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(133, 286);
            this.button6.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(69, 61);
            this.button6.TabIndex = 8;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(215, 286);
            this.button7.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(69, 61);
            this.button7.TabIndex = 9;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(53, 362);
            this.button8.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(69, 61);
            this.button8.TabIndex = 10;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(133, 362);
            this.button9.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(69, 61);
            this.button9.TabIndex = 11;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // buttonFraction
            // 
            this.buttonFraction.Location = new System.Drawing.Point(53, 138);
            this.buttonFraction.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonFraction.Name = "buttonFraction";
            this.buttonFraction.Size = new System.Drawing.Size(69, 61);
            this.buttonFraction.TabIndex = 12;
            this.buttonFraction.Text = "x/y";
            this.buttonFraction.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.fractionToolTip.SetToolTip(this.buttonFraction, "Adds the divisor making the number already entered into a numerator, and the next" +
        " number entered into a denominator..");
            this.buttonFraction.UseVisualStyleBackColor = true;
            this.buttonFraction.Click += new System.EventHandler(this.buttonFraction_Click);
            // 
            // labelCurrentFraction
            // 
            this.labelCurrentFraction.AutoSize = true;
            this.labelCurrentFraction.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelCurrentFraction.Location = new System.Drawing.Point(6, 50);
            this.labelCurrentFraction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCurrentFraction.Name = "labelCurrentFraction";
            this.labelCurrentFraction.Size = new System.Drawing.Size(162, 28);
            this.labelCurrentFraction.TabIndex = 15;
            this.labelCurrentFraction.Text = "Current Fraction: ";
            // 
            // buttonClear
            // 
            this.buttonClear.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonClear.Location = new System.Drawing.Point(538, 213);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(69, 61);
            this.buttonClear.TabIndex = 16;
            this.buttonClear.Text = "🗑";
            this.clearToolTip.SetToolTip(this.buttonClear, "Clears the entire equation and resets the calculator.");
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonAdd.Location = new System.Drawing.Point(348, 138);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(69, 61);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSubtract
            // 
            this.buttonSubtract.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonSubtract.Location = new System.Drawing.Point(348, 213);
            this.buttonSubtract.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSubtract.Name = "buttonSubtract";
            this.buttonSubtract.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.buttonSubtract.Size = new System.Drawing.Size(69, 61);
            this.buttonSubtract.TabIndex = 18;
            this.buttonSubtract.Text = "-";
            this.buttonSubtract.UseVisualStyleBackColor = true;
            this.buttonSubtract.Click += new System.EventHandler(this.buttonSubtract_Click);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonMultiply.Location = new System.Drawing.Point(348, 286);
            this.buttonMultiply.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(69, 61);
            this.buttonMultiply.TabIndex = 19;
            this.buttonMultiply.Text = "*";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            this.buttonMultiply.Click += new System.EventHandler(this.buttonMultiply_Click);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonDivide.Location = new System.Drawing.Point(348, 355);
            this.buttonDivide.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(69, 61);
            this.buttonDivide.TabIndex = 20;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new System.EventHandler(this.buttonDivide_Click);
            // 
            // labelEquation
            // 
            this.labelEquation.AutoSize = true;
            this.labelEquation.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelEquation.Location = new System.Drawing.Point(65, 20);
            this.labelEquation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEquation.Name = "labelEquation";
            this.labelEquation.Size = new System.Drawing.Size(99, 28);
            this.labelEquation.TabIndex = 21;
            this.labelEquation.Text = "Equation: ";
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonSolve.Location = new System.Drawing.Point(441, 138);
            this.buttonSolve.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(69, 61);
            this.buttonSolve.TabIndex = 22;
            this.buttonSolve.Text = "=";
            this.solveToolTip.SetToolTip(this.buttonSolve, "Solve the current equation");
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.buttonSolve_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.labelResult.Location = new System.Drawing.Point(88, 82);
            this.labelResult.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(73, 28);
            this.labelResult.TabIndex = 23;
            this.labelResult.Text = "Result: ";
            // 
            // buttonOpenParenthesis
            // 
            this.buttonOpenParenthesis.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonOpenParenthesis.Location = new System.Drawing.Point(441, 213);
            this.buttonOpenParenthesis.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonOpenParenthesis.Name = "buttonOpenParenthesis";
            this.buttonOpenParenthesis.Size = new System.Drawing.Size(69, 61);
            this.buttonOpenParenthesis.TabIndex = 24;
            this.buttonOpenParenthesis.Text = "(";
            this.openParenthesisToolTip.SetToolTip(this.buttonOpenParenthesis, "Add an open parenthesis to control order of operations.");
            this.buttonOpenParenthesis.UseVisualStyleBackColor = true;
            this.buttonOpenParenthesis.Click += new System.EventHandler(this.buttonOpenParenthesis_Click);
            // 
            // buttonCloseParenthesis
            // 
            this.buttonCloseParenthesis.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonCloseParenthesis.Location = new System.Drawing.Point(441, 282);
            this.buttonCloseParenthesis.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonCloseParenthesis.Name = "buttonCloseParenthesis";
            this.buttonCloseParenthesis.Size = new System.Drawing.Size(69, 61);
            this.buttonCloseParenthesis.TabIndex = 25;
            this.buttonCloseParenthesis.Text = ")";
            this.closeParenthesisToolTip.SetToolTip(this.buttonCloseParenthesis, "Add a close parenthesis to control order of operations.");
            this.buttonCloseParenthesis.UseVisualStyleBackColor = true;
            this.buttonCloseParenthesis.Click += new System.EventHandler(this.buttonCloseParenthesis_Click);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(50, 450);
            this.labelError.MaximumSize = new System.Drawing.Size(550, 100);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(0, 21);
            this.labelError.TabIndex = 26;
            // 
            // buttonUndoLast
            // 
            this.buttonUndoLast.Font = new System.Drawing.Font("Segoe UI", 20F);
            this.buttonUndoLast.Location = new System.Drawing.Point(538, 138);
            this.buttonUndoLast.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.buttonUndoLast.Name = "buttonUndoLast";
            this.buttonUndoLast.Size = new System.Drawing.Size(69, 61);
            this.buttonUndoLast.TabIndex = 27;
            this.buttonUndoLast.Text = "⟲";
            this.undoLastToolTip.SetToolTip(this.buttonUndoLast, "Undo the last-added piece of equation and clear a pending fraction.");
            this.buttonUndoLast.UseVisualStyleBackColor = true;
            this.buttonUndoLast.Click += new System.EventHandler(this.buttonUndoLast_Click);
            // 
            // FractionCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 518);
            this.Controls.Add(this.buttonUndoLast);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.buttonCloseParenthesis);
            this.Controls.Add(this.buttonOpenParenthesis);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.labelEquation);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.buttonMultiply);
            this.Controls.Add(this.buttonSubtract);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelCurrentFraction);
            this.Controls.Add(this.buttonFraction);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "FractionCalculator";
            this.Text = "FractionCalculator";
            this.Load += new System.EventHandler(this.FractionCalculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
        private Button button0;
        private Button buttonFraction;
        public Label labelCurrentFraction;
        private Button buttonClear;
        private Button buttonAdd;
        private Button buttonSubtract;
        private Button buttonMultiply;
        private Button buttonDivide;
        public Label labelEquation;
        private Button buttonSolve;
        public Label labelResult;
        private Button buttonOpenParenthesis;
        private Button buttonCloseParenthesis;
        private Label labelError;
        private Button buttonUndoLast;
        private ToolTip fractionToolTip;
        private ToolTip clearToolTip;
        private ToolTip solveToolTip;
        private ToolTip openParenthesisToolTip;
        private ToolTip closeParenthesisToolTip;
        private ToolTip undoLastToolTip;
    }
}