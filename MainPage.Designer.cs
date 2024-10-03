namespace Maths_Schedule
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            lblNext = new Label();
            lstRemaining = new ListBox();
            lstCompleted = new ListBox();
            label1 = new Label();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // lblNext
            // 
            lblNext.AutoSize = true;
            lblNext.Font = new Font("Segoe UI", 19F);
            lblNext.Location = new Point(93, 386);
            lblNext.Name = "lblNext";
            lblNext.Size = new Size(0, 36);
            lblNext.TabIndex = 0;
            // 
            // lstRemaining
            // 
            lstRemaining.Font = new Font("Segoe UI", 12F);
            lstRemaining.FormattingEnabled = true;
            lstRemaining.ItemHeight = 21;
            lstRemaining.Location = new Point(143, 66);
            lstRemaining.Name = "lstRemaining";
            lstRemaining.Size = new Size(311, 277);
            lstRemaining.TabIndex = 1;
            lstRemaining.Click += lstRemaining_Click;
            lstRemaining.MouseDoubleClick += lstRemaining_MouseDoubleClick;
            // 
            // lstCompleted
            // 
            lstCompleted.Font = new Font("Segoe UI", 12F);
            lstCompleted.FormattingEnabled = true;
            lstCompleted.ItemHeight = 21;
            lstCompleted.Location = new Point(460, 66);
            lstCompleted.Name = "lstCompleted";
            lstCompleted.Size = new Size(328, 277);
            lstCompleted.TabIndex = 2;
            lstCompleted.Click += lstCompleted_Click;
            lstCompleted.MouseDoubleClick += lstCompleted_MouseDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19F);
            label1.Location = new Point(12, 386);
            label1.Name = "label1";
            label1.Size = new Size(75, 36);
            label1.TabIndex = 3;
            label1.Text = "Next:";
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(12, 195);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add Assignment";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(label1);
            Controls.Add(lstCompleted);
            Controls.Add(lstRemaining);
            Controls.Add(lblNext);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainPage";
            Text = "Assignments";
            FormClosing += MainPage_FormClosing;
            Load += MainPage_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNext;
        private ListBox lstRemaining;
        private ListBox lstCompleted;
        private Label label1;
        private Button btnAdd;
    }
}
