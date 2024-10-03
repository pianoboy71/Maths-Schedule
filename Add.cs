using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maths_Schedule
{
    public partial class Add : Form
    {
        private MainPage _mainPage;
        public Add(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        public void btnSubmit_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Would you like to add this assignment?", "Add assignment?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (confirmation == DialogResult.Yes)
            {
                Dictionary<string, string> assignment = new Dictionary<string, string>();
                assignment["date"] = txtDate.Text;
                assignment["teacherCode"] = txtTeacherCode.Text;
                assignment["assignmentCode"] = txtAssignmentCode.Text;
                assignment["assignmentText"] = txtAssignmentTitle.Text;
                _mainPage.AddItemToRemaining(assignment);
                this.Close();
            }
            else
            {
                MessageBox.Show("Aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
