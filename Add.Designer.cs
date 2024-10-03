namespace Maths_Schedule
{
    partial class Add
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtDate = new TextBox();
            txtTeacherCode = new TextBox();
            label2 = new Label();
            txtAssignmentCode = new TextBox();
            label3 = new Label();
            txtAssignmentTitle = new TextBox();
            label4 = new Label();
            btnSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 89);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Date Due (DD/MM/YY)";
            // 
            // txtDate
            // 
            txtDate.Location = new Point(239, 107);
            txtDate.Name = "txtDate";
            txtDate.Size = new Size(253, 23);
            txtDate.TabIndex = 1;
            // 
            // txtTeacherCode
            // 
            txtTeacherCode.Location = new Point(239, 176);
            txtTeacherCode.Name = "txtTeacherCode";
            txtTeacherCode.Size = new Size(253, 23);
            txtTeacherCode.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(239, 158);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 2;
            label2.Text = "Teacher Code";
            // 
            // txtAssignmentCode
            // 
            txtAssignmentCode.Location = new Point(239, 248);
            txtAssignmentCode.Name = "txtAssignmentCode";
            txtAssignmentCode.Size = new Size(253, 23);
            txtAssignmentCode.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(239, 230);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 4;
            label3.Text = "Assignment Code";
            // 
            // txtAssignmentTitle
            // 
            txtAssignmentTitle.Location = new Point(239, 312);
            txtAssignmentTitle.Name = "txtAssignmentTitle";
            txtAssignmentTitle.Size = new Size(253, 23);
            txtAssignmentTitle.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(239, 294);
            label4.Name = "label4";
            label4.Size = new Size(95, 15);
            label4.TabIndex = 6;
            label4.Text = "Assignment Title";
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(239, 369);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(253, 23);
            btnSubmit.TabIndex = 8;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubmit);
            Controls.Add(txtAssignmentTitle);
            Controls.Add(label4);
            Controls.Add(txtAssignmentCode);
            Controls.Add(label3);
            Controls.Add(txtTeacherCode);
            Controls.Add(label2);
            Controls.Add(txtDate);
            Controls.Add(label1);
            Name = "Add";
            Text = "Add";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtDate;
        private TextBox txtTeacherCode;
        private Label label2;
        private TextBox txtAssignmentCode;
        private Label label3;
        private TextBox txtAssignmentTitle;
        private Label label4;
        private Button btnSubmit;
    }
}