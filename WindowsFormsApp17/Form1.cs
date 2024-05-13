using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;
            label3.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    string[] massive_vvod = textBox1.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    int count_numbers = massive_vvod.SelectMany(s => s).Count(char.IsDigit);

                    MessageBox.Show($"Количество цифр в массиве: {count_numbers}");

                    var slova_pered_slash = massive_vvod
                        .TakeWhile(s => s != "/")
                        .ToList();
                    var slova_posle_slash = massive_vvod
                        .SkipWhile(s => s != "/")
                        .Skip(1)
                        .Select(s => s.Select(c => char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c)).ToArray())
                        .Select(s => new string(s))
                        .ToList();

                    string file_name = "text.txt";
                    File.WriteAllLines(file_name, slova_pered_slash);
                    textBox2.Visible = true;
                    textBox3.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;

                    textBox2.Text = string.Join(" ", slova_pered_slash);
                    textBox3.Text = string.Join(" ", slova_posle_slash);
                }
                else
                {
                    MessageBox.Show("Ошибка: В поле ничего не введено.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
                return;
            }
        }
    }
}
