using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosatorsApp
{
    public partial class Main : System.Windows.Forms.Form
    {
        Model1 db = new Model1();
        private double S;
        private double g;
        private int k;
        private double Vnom;
        public Main()
        {
            InitializeComponent();
            comboBox1.DataSource = db.dosators.ToList();
            comboBox1.DisplayMember = "canal";
            comboBox1.ValueMember = "id";
            textBox1.Validating += TextBox1_Validating;
            textBox2.Validating += TextBox2_Validating;
            textBox3.Validating += TextBox3_Validating;
            textBox4.Validating += TextBox4_Validating;
            textBox5.Validating += TextBox5_Validating;
            textBox6.Validating += TextBox6_Validating;
            textBox7.Validating += TextBox7_Validating;
            textBox8.Validating += TextBox8_Validating;
            textBox9.Validating += TextBox9_Validating;
            textBox10.Validating += TextBox10_Validating;
            textBox11.ReadOnly = true;
            
        }

        private void TextBox10_Validating(object sender, CancelEventArgs e)
        {
            if (textBox10.Text.Contains("."))
            {
                errorProvider2.SetError(textBox10, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox9_Validating(object sender, CancelEventArgs e)
        {
            if (textBox9.Text.Contains("."))
            {
                errorProvider2.SetError(textBox9, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox8_Validating(object sender, CancelEventArgs e)
        {
            if (textBox8.Text.Contains("."))
            {
                errorProvider2.SetError(textBox8, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox7_Validating(object sender, CancelEventArgs e)
        {
            if (textBox7.Text.Contains("."))
            {
                errorProvider2.SetError(textBox7, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox6_Validating(object sender, CancelEventArgs e)
        {
            if (textBox6.Text.Contains("."))
            {
                errorProvider2.SetError(textBox6, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox5_Validating(object sender, CancelEventArgs e)
        {
            
            if (textBox5.Text.Contains("."))
            {
                errorProvider2.SetError(textBox5, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox4_Validating(object sender, CancelEventArgs e)
        {
           
            if (textBox4.Text.Contains("."))
            {
                errorProvider2.SetError(textBox4, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox3_Validating(object sender, CancelEventArgs e)
        {
            
            if (textBox3.Text.Contains("."))
            {
                errorProvider2.SetError(textBox3, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            
            if (textBox2.Text.Contains("."))
            {
                errorProvider2.SetError(textBox2, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            
            if (textBox1.Text.Contains("."))
            {
                errorProvider2.SetError(textBox1, "Введите запятую вместо точки");
            }
            else
                errorProvider2.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            label2.Visible = true;
            int id = int.Parse(comboBox1.SelectedValue.ToString());
            var value = db.norma.Where(x => x.codeDos == id).
                Select(p => new {volume = p.volume });
            comboBox2.DataSource = value.ToList();
            comboBox2.DisplayMember = "volume";
            comboBox2.ValueMember = "volume";
            
        }
        private bool textBoxNull()
        {
            bool flag = false;
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {
                if (textBox.Text == "")
                {
                    flag = true;
                    MessageBox.Show("Не хватает данных для расчета");
                    break;
                }
            }
            return flag;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {                
                 textBox.BackColor = Color.White;
            }
            if (textBoxNull() == false && comboBox2.SelectedValue!=null)
            {
                double num = double.Parse(textBox1.Text) + double.Parse(textBox2.Text) + double.Parse(textBox3.Text) + double.Parse(textBox4.Text) +
                double.Parse(textBox5.Text) + double.Parse(textBox6.Text) + double.Parse(textBox7.Text) + double.Parse(textBox8.Text) +
                double.Parse(textBox9.Text) + double.Parse(textBox10.Text);
                double Vsred = num / 9.98;
                Vnom = double.Parse(comboBox2.SelectedValue.ToString()) / 1000;

                g = (Vsred - Vnom) / Vnom * 100;
                g = Math.Round(g, 2);
                var list = Experience.numbers = new List<double>();
                list.AddRange(new double[]
                {
                double.Parse(textBox1.Text),
                double.Parse(textBox2.Text),
                double.Parse(textBox3.Text),
                double.Parse(textBox4.Text),
                double.Parse(textBox5.Text),
                double.Parse(textBox6.Text),
                double.Parse(textBox7.Text),
                double.Parse(textBox8.Text),
                double.Parse(textBox9.Text),
                double.Parse(textBox10.Text),
                });
                Experience.Vdoz = int.Parse(comboBox2.SelectedValue.ToString());
                double summa = 0;

                foreach (double el in list)
                {
                    summa += Math.Pow(el - Vsred, 2);
                }

                S = Math.Sqrt(summa / 9) * 100 / Vsred;
                S = Math.Round(S, 2);
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                int volume = int.Parse(comboBox2.SelectedValue.ToString());
                var q = db.norma.Where(x => x.codeDos == id &&
                x.volume == volume).FirstOrDefault().precis;
                var vospr = db.norma.Where(x => x.codeDos == id &&
                x.volume == volume).FirstOrDefault().reproducibility;


                if (Math.Abs(g - q) <= q)
                {
                    if (S <= vospr)
                    {
                        //MessageBox.Show("Точность: " + g.ToString()+"%; \n\nВоспроизводимость: " + S.ToString() + "%");
                        k = 1;
                        textBox11.Text = "Точность: " + g.ToString() + "%; \n\nВоспроизводимость: " + S.ToString() + "%";
                        Experience.Vsred = Math.Round(Vsred, 4); ;
                        Experience.q = g;
                        Experience.S = S;
                    }
                    else
                    {
                        MessageBox.Show("Воспроизводимость больше нормы, повторите измерения");
                        k = 0;
                        foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
                        {
                            if (double.Parse(textBox.Text) - Vsred > vospr / 1000)
                                textBox.BackColor = Color.MistyRose;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Требуется калибровка");
                    k = 0;
                    foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
                    {
                        if (double.Parse(textBox.Text) - Vsred > vospr / 1000)
                            textBox.BackColor = Color.MistyRose;
                    }
                }
            }
            
                

        }
        
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox4.Focus();
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox5.Focus();
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox6.Focus();
        }

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox10.Focus();
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox7.Focus();
        }

        private void textBox7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox8.Focus();
        }

        private void textBox8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox9.Focus();
        }

        private void textBox10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                Report page = new Report();
                page.Show();
            }
            else
            {
                MessageBox.Show("Невозможно сформировать отчет. Сделайте повторные измерения");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            OutPut page = new OutPut();
            page.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != ',' && number != '.' && number != 8)
                e.Handled = true;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            if (k == 1)
            {
                db = new Model1();
                int id = int.Parse(comboBox1.SelectedValue.ToString());
                int volume = int.Parse(comboBox2.SelectedValue.ToString());
                string result = Microsoft.VisualBasic.Interaction.InputBox("Введите ФИО оператора");
                db.result.Add(new result
                {
                    codeDos = id,
                    objem = volume,
                    procent = Convert.ToSingle(g),
                    vosproizv = Convert.ToSingle(S),
                    operators = result,
                    dateTest = DateTime.Today.Date
                });
                db.SaveChanges();
                MessageBox.Show("Запись сохранена");
            }
            else
            {
                MessageBox.Show("Невозможно добавить запись, так как требуется калибровка");
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;
            textBox11.Clear();
            foreach (TextBox textBox in groupBox1.Controls.OfType<TextBox>())
            {
                textBox.BackColor = Color.White;
                textBox.Clear();
            }
        }
    }
}
