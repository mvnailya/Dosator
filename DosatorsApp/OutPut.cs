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
    public partial class OutPut : Form
    {
        Model1 db = new Model1();
        public OutPut()
        {
            InitializeComponent();
        }

        private void OutPut_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; ;
            var res = db.result.Select(x => new
            {
                type = x.dosators.canal.Trim(),
                objem = x.objem,
                precis = x.procent,
                vospr = x.vosproizv,
                date = x.dateTest,
                operators = x.operators.Trim()
            });
            dataGridView1.Columns.Add("type", "Тип дозатора");
            dataGridView1.Columns.Add("objem", "Номинальный объем");
            dataGridView1.Columns.Add("precis", "Точность");
            dataGridView1.Columns.Add("vospr", "Воспроизводимость");
            dataGridView1.Columns.Add("date", "Дата проведения");
            dataGridView1.Columns.Add("operators", "Ответственный");
            int i = 0;
            foreach (var el in res)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = el.type;
                dataGridView1.Rows[i].Cells[1].Value = el.objem.ToString();
                dataGridView1.Rows[i].Cells[2].Value = el.precis.ToString() + "%";
                dataGridView1.Rows[i].Cells[3].Value = el.vospr.ToString() + "%";
                dataGridView1.Rows[i].Cells[4].Value = el.date.ToShortDateString();
                dataGridView1.Rows[i].Cells[5].Value = el.operators;
                i++;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            if (dateTimePicker1.Text != "" && dateTimePicker2.Text != "")
            {
                var res = db.result.Where(w=>w.dateTest>=dateTimePicker1.Value && w.dateTest<=dateTimePicker2.Value).
                    Select(x => new
                {
                        type = x.dosators.canal.Trim(),
                        objem = x.objem,
                        precis = x.procent,
                        vospr = x.vosproizv,
                        date = x.dateTest,
                        operators = x.operators.Trim()
                    });
                dataGridView1.Columns.Add("type", "Тип дозатора");
                dataGridView1.Columns.Add("objem", "Номинальный объем");
                dataGridView1.Columns.Add("precis", "Точность");
                dataGridView1.Columns.Add("vospr", "Воспроизводимость");
                dataGridView1.Columns.Add("date", "Дата проведения");
                dataGridView1.Columns.Add("operators", "Ответственный");
                int i = 0;
                foreach (var el in res)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = el.type;
                    dataGridView1.Rows[i].Cells[1].Value = el.objem.ToString();
                    dataGridView1.Rows[i].Cells[2].Value = el.precis.ToString() + "%";
                    dataGridView1.Rows[i].Cells[3].Value = el.vospr.ToString() + "%";
                    dataGridView1.Rows[i].Cells[4].Value = el.date.ToShortDateString();
                    dataGridView1.Rows[i].Cells[5].Value = el.operators;
                    i++;
                }
            }
            if (dateTimePicker1.Text != "" && dateTimePicker2.Text == "")
            {                
                var res = db.result.Where(w => w.dateTest >= dateTimePicker1.Value).
                    Select(x => new
                    {
                        type = x.dosators.canal.Trim(),
                        objem = x.objem,
                        precis = x.procent,
                        vospr = x.vosproizv,
                        date = x.dateTest,
                        operators = x.operators.Trim()
                    });
                dataGridView1.Columns.Add("type", "Тип дозатора");
                dataGridView1.Columns.Add("objem", "Номинальный объем");
                dataGridView1.Columns.Add("precis", "Точность");
                dataGridView1.Columns.Add("vospr", "Воспроизводимость");
                dataGridView1.Columns.Add("date", "Дата проведения");
                dataGridView1.Columns.Add("operators", "Ответственный");
                int i = 0;
                foreach (var el in res)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = el.type;
                    dataGridView1.Rows[i].Cells[1].Value = el.objem.ToString();
                    dataGridView1.Rows[i].Cells[2].Value = el.precis.ToString() + "%";
                    dataGridView1.Rows[i].Cells[3].Value = el.vospr.ToString() + "%";
                    dataGridView1.Rows[i].Cells[4].Value = el.date.ToShortDateString();
                    dataGridView1.Rows[i].Cells[5].Value = el.operators;
                    i++;
                }
            }
            if (dateTimePicker1.Text == "" && dateTimePicker2.Text != "")
            {
                var res = db.result.Where(w => w.dateTest <= dateTimePicker2.Value).
                    Select(x => new
                    {
                        type = x.dosators.canal.Trim(),
                        objem = x.objem,
                        precis = x.procent,
                        vospr = x.vosproizv,
                        date = x.dateTest,
                        operators = x.operators.Trim()
                    });
                dataGridView1.Columns.Add("type", "Тип дозатора");
                dataGridView1.Columns.Add("objem", "Номинальный объем");
                dataGridView1.Columns.Add("precis", "Точность");
                dataGridView1.Columns.Add("vospr", "Воспроизводимость");
                dataGridView1.Columns.Add("date", "Дата проведения");
                dataGridView1.Columns.Add("operators", "Ответственный");
                int i = 0;
                foreach (var el in res)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = el.type;
                    dataGridView1.Rows[i].Cells[1].Value = el.objem.ToString();
                    dataGridView1.Rows[i].Cells[2].Value = el.precis.ToString() + "%";
                    dataGridView1.Rows[i].Cells[3].Value = el.vospr.ToString() + "%";
                    dataGridView1.Rows[i].Cells[4].Value = el.date.ToShortDateString();
                    dataGridView1.Rows[i].Cells[5].Value = el.operators;
                    i++;
                }
            }
        }
    }
}
