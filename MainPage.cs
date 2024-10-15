using Microsoft.VisualBasic;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Maths_Schedule
{
    public partial class MainPage : Form
    {
        static List<Dictionary<string, string>> _assignmentsRemaining = new List<Dictionary<string, string>>();
        static List<Dictionary<string, string>> _assignmentsCompleted = new List<Dictionary<string, string>>();
        static readonly char[] separator = ['\n', '\r'];
        public MainPage()
        {
            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            string completedPath = "completed.txt";
            string remainingPath = "remaining.txt";
            using (Stream stream = new FileStream(completedPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                if (!File.Exists(completedPath) || stream.Length <= 0)
                {
                    Dictionary<string, string> assignment = new Dictionary<string, string>();
                    JsonSerializer.Serialize(stream, assignment);
                }
                else
                {
                    string text;
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        text = sr.ReadToEnd();
                    }

                    string[] lines = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        try
                        {
                            Dictionary<string, string> assignment = JsonSerializer.Deserialize<Dictionary<string, string>>(line);
                            if (assignment != null)
                            {
                                _assignmentsCompleted.Add(assignment);
                            }
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }

            using (Stream stream = new FileStream(remainingPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                if (!File.Exists(remainingPath) || stream.Length <= 0)
                {
                    Dictionary<string, string> assignment = new Dictionary<string, string>();
                    JsonSerializer.Serialize(stream, assignment);
                }
                else
                {
                    string text;
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        text = sr.ReadToEnd();
                    }

                    string[] lines = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        try
                        {
                            Dictionary<string, string> assignment = JsonSerializer.Deserialize<Dictionary<string, string>>(line);
                            if (assignment != null)
                            {
                                _assignmentsRemaining.Add(assignment);
                            }
                        }
                        catch (JsonException)
                        {
                            MessageBox.Show($"Error with deserialising line `{line}`", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        }
                    }
                }
            }
            foreach (var item in _assignmentsCompleted)
            {
                try
                {
                    lstCompleted.Items.Add($"{item["date"]} {item["teacherCode"]} {item["assignmentCode"]}: {item["assignmentText"]}");
                }
                catch
                {
                    continue;
                }
            }

            foreach (var item in _assignmentsRemaining)
            {
                try
                {
                    lstRemaining.Items.Add($"{item["date"]} {item["teacherCode"]} {item["assignmentCode"]}: {item["assignmentText"]}");
                }
                catch
                {
                    continue;
                }
            }

            try
            {
                Sort(lstRemaining);
                Sort(lstCompleted);
                string text = lstRemaining.Items[0].ToString();
                lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
            }
            catch
            {
                lblNext.Text = string.Empty;
            }
        }

        private void lstRemaining_Click(object sender, EventArgs e)
        {
            if (lstRemaining.SelectedItem != null)
            {
                string selectedText = lstRemaining.SelectedItem.ToString();
                string date = selectedText.Substring(0, 8);
                DateTime selectedDate = DateTime.Parse(date);
                string teacherCode = selectedText.Substring(9, 2);
                string assignmentCode = selectedText.Substring(12, 6);
                string assignmentText = selectedText.Substring(20);
                DialogResult confirmation = MessageBox.Show($"Would you like to mark {assignmentCode} as completed?", "Mark as completed?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    lstRemaining.Items.RemoveAt(lstRemaining.SelectedIndex);
                    lstCompleted.Items.Add($"{date} {teacherCode} {assignmentCode}: {assignmentText}");
                    MessageBox.Show($"{assignmentCode} marked as completed, hand in to {((teacherCode == "HW") ? "Harley" : "Ella")} by {selectedDate}", "Completed assignment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    try
                    {
                        Sort(lstRemaining);
                        Sort(lstCompleted);
                        string text = lstRemaining.Items[0].ToString();
                        lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                    }
                    catch
                    {
                        lblNext.Text = string.Empty;
                    }
                    
                }
                else
                {
                    MessageBox.Show("Aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    try
                    {
                        Sort(lstRemaining);
                        Sort(lstCompleted);
                        string text = lstRemaining.Items[0].ToString();
                        lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                    }
                    catch
                    {
                        lblNext.Text = string.Empty;
                    }
                }
            }
        }

        private void lstCompleted_Click(object sender, EventArgs e)
        {
            if (lstCompleted.SelectedItem != null)
            {
                string selectedText = lstCompleted.SelectedItem.ToString();
                string date = selectedText.Substring(0, 8);
                DateTime selectedDate = DateTime.Parse(date);
                string teacherCode = selectedText.Substring(9, 2);
                string teacher = (teacherCode == "HW") ? "Harley" : "Ella";
                string assignmentCode = selectedText.Substring(12, 6);
                string assignmentText = selectedText.Substring(20);
                DialogResult confirmation = MessageBox.Show($"Would you like to mark {assignmentCode} as not completed?", "Mark as not completed?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    lstCompleted.Items.RemoveAt(lstCompleted.SelectedIndex);
                    lstRemaining.Items.Add($"{date} {teacherCode} {assignmentCode}: {assignmentText}");
                    MessageBox.Show($"{assignmentCode} marked as not completed", "Completed assignment", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    try
                    {
                        Sort(lstRemaining);
                        Sort(lstCompleted);
                        string text = lstRemaining.Items[0].ToString();
                        lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                    }
                    catch
                    {
                        lblNext.Text = string.Empty;
                    }
                }
                else
                {
                    MessageBox.Show("Aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    try
                    {
                        Sort(lstRemaining);
                        Sort(lstCompleted);
                        string text = lstRemaining.Items[0].ToString();
                        lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                    }
                    catch
                    {
                        lblNext.Text = string.Empty;
                    }
                }
            }
        }

        private void MainPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            _assignmentsCompleted.Clear();
            foreach (var temp in lstCompleted.Items)
            {
                string item = temp.ToString();
                Dictionary<string, string> assignment = new Dictionary<string, string>
                {
                    {"date",  item.Substring(0, 8)},
                    {"teacherCode", item.Substring(9, 2)},
                    {"assignmentCode", item.Substring(12, 6)},
                    {"assignmentText", item.Substring(20)}
                };
                _assignmentsCompleted.Add(assignment);
            }
            _assignmentsRemaining.Clear();
            foreach (var temp in lstRemaining.Items)
            {
                string item = temp.ToString();
                Dictionary<string, string> assignment = new Dictionary<string, string>
                {
                    {"date",  item.Substring(0, 8)},
                    {"teacherCode", item.Substring(9, 2)},
                    {"assignmentCode", item.Substring(12, 6)},
                    {"assignmentText", item.Substring(20)}
                };
                _assignmentsRemaining.Add(assignment);
            }

            File.Delete("completed.txt");
            using (StreamWriter file = new("completed.txt"))
            {
                foreach (var assignment in _assignmentsCompleted)
                {
                    file.WriteLine(JsonSerializer.Serialize(assignment));
                }
            }
            File.Delete("remaining.txt");
            using (StreamWriter file = new("remaining.txt"))
            {
                foreach (var assignment in _assignmentsRemaining)
                {
                    file.WriteLine(JsonSerializer.Serialize(assignment));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Would you like to add an assignment?", "Add assignment?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (confirmation == DialogResult.Yes)
            {
                Add add = new Add(this);
                this.Hide();
                add.ShowDialog();
                this.Show();
                try
                {
                    Sort(lstRemaining);
                    Sort(lstCompleted);
                    string text = lstRemaining.Items[0].ToString();
                    lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                }
                catch
                {
                    lblNext.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                try
                {
                    Sort(lstRemaining);
                    Sort(lstCompleted);
                    string text = lstRemaining.Items[0].ToString();
                    lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                }
                catch
                {
                    lblNext.Text = string.Empty;
                }
            }
        }

        private string Delete(ListBox listBox, int index)
        {
            string item = listBox.Items[index].ToString();
            DialogResult confirmation = MessageBox.Show("Would you like to delete this assignment?", "Delete assignment?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (confirmation == DialogResult.Yes)
            {
                listBox.Items.RemoveAt(index);
                try
                {
                    Sort(lstRemaining);
                    Sort(lstCompleted);
                    string text = lstRemaining.Items[0].ToString();
                    lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                }
                catch
                {
                    lblNext.Text = string.Empty;
                }
                return item;
            }
            else
            {
                MessageBox.Show("Aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1); string text = lstRemaining.Items[0].ToString();
                lblNext.Text = $"{text.Substring(12, 6)}: {text.Substring(20)}, due in to {((text.Substring(9, 2) == "HW") ? "Harley" : "Ella")} on {text.Substring(0, 8)}";
                return string.Empty;            
            }
        }

        private void lstRemaining_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string item = Delete(lstRemaining, lstRemaining.SelectedIndex);

            if (item == string.Empty)
            {
                return;
            }

            _assignmentsRemaining.Remove(new Dictionary<string, string>
            {
                {"date",  item.Substring(0, 8)},
                {"teacherCode", item.Substring(9, 2)},
                {"assignmentCode", item.Substring(12, 6)},
                {"assignmentText", item.Substring(20)}
            });
        }

        private void lstCompleted_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string item = Delete(lstCompleted, lstCompleted.SelectedIndex);

            if (item == string.Empty)
            {
                return;
            }

            _assignmentsCompleted.Remove(new Dictionary<string, string>
            {
                {"date",  item.Substring(0, 8)},
                {"teacherCode", item.Substring(9, 2)},
                {"assignmentCode", item.Substring(12, 6)},
                {"assignmentText", item.Substring(20)}
            });
        }

        public void AddItemToRemaining(Dictionary<string, string> item)
        {
            lstRemaining.Items.Add($"{item["date"]} {item["teacherCode"]} {item["assignmentCode"]}: {item["assignmentText"]}");
            _assignmentsRemaining.Add(item);
        }

        private void Sort(ListBox list)
        {
            List<string> items = new List<string>();

            foreach (string item in list.Items)
            {
                items.Add(item.ToString());
            }

            items.Sort((x, y) =>
            {
                // Extract the relevant parts from the strings
                string dateX = x.Substring(0, 8);
                string dateY = y.Substring(0, 8);
                string teacherCodeX = x.Substring(9, 2);
                string teacherCodeY = y.Substring(9, 2);
                string assignmentCodeX = x.Substring(12, 6);
                string assignmentCodeY = y.Substring(12, 6);

                // First, compare the dates
                int dateComparison = DateTime.ParseExact(dateX, "dd/MM/yy", null).CompareTo(DateTime.ParseExact(dateY, "dd/MM/yy", null));

                // If the dates are different, use that comparison
                if (dateComparison != 0)
                {
                    return dateComparison;
                }

                // If the dates are the same, compare the teacher codes
                int teacherComparison = string.Compare(teacherCodeX, teacherCodeY);
                if (teacherComparison != 0)
                {
                    // Ensure "EF" comes before "HW"
                    if (teacherCodeX == "EF") return -1;
                    if (teacherCodeX == "HW") return 1;
                }

                // If the teacher codes are also the same, compare the assignment codes
                // Ensure assignment codes starting with "A" come before those starting with "2"
                if (assignmentCodeX.StartsWith('A') && assignmentCodeY.StartsWith('2'))
                {
                    return -1;
                }
                else if (assignmentCodeX.StartsWith('2') && assignmentCodeY.StartsWith('A'))
                {
                    return 1;
                }

                // Otherwise, just compare the assignment codes lexicographically
                return string.Compare(assignmentCodeX, assignmentCodeY);
            });

            // Clear the list and re-add the sorted items
            list.Items.Clear();
            foreach (string item in items)
            {
                list.Items.Add(item);
            }
        }
    }
}