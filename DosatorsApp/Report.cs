using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace DosatorsApp
{
    public partial class Report : Form
    {
        private readonly string TemplateFileName = @"C:\Users\79880\source\repos\DosatorsApp\report.docx";
        
        public Report()
        {
            InitializeComponent();
            comboBox1.Items.Add("санитарно-гигиеническая");
            comboBox1.Items.Add("бактериологических и паразитологических инфекций");
            comboBox1.Items.Add("виросологическая");
            comboBox1.Items.Add("обеспечение эпиднадзора за особо опасными инфекциями");
        }
        private void replaceWord(string whatReplace, string text, Word.Document doc)
        {
            var range = doc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: whatReplace, ReplaceWith: text);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var word = new Word.Application();
            word.Visible = false;
            var doc = word.Documents.Open(TemplateFileName);
            replaceWord("{date}", DateTime.Today.ToShortDateString(), doc);
            replaceWord("{lab}", comboBox1.SelectedItem.ToString(), doc);
            replaceWord("{model}", textBox2.Text.ToString(), doc);
            replaceWord("{num}", textBox3.Text.ToString(), doc);
            replaceWord("{obm}", textBox1.Text.ToString(), doc);
            int n = 1;
            foreach (var el in Experience.numbers)
            {
                replaceWord("{v}", Experience.Vdoz.ToString(), doc);
                replaceWord("{m"+n+"}", el.ToString(), doc);
                n++;
            }
            replaceWord("{Vsred}", Experience.Vsred.ToString(), doc);
            replaceWord("{q}", Experience.q.ToString(), doc);
            replaceWord("{S}", Experience.S.ToString(), doc);
            
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = folderBrowserDialog1.SelectedPath;
                doc.SaveAs(path+"\\Лист проверки " +
                DateTime.Today.ToShortDateString() + ".docx");
            }
            else
                MessageBox.Show("Документ не сохранен");
            doc.Close();
            MessageBox.Show("Документ сохранен");
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox3.Focus();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.PerformClick();
        }
    }
}
