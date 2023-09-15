using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity_Framework_2.ders
{
    public partial class branches : Form
    {
        public branches()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn = new RentacarEntities1();
        private void carsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carsstaff go = new carsstaff();
            go.Show();
            this.Hide();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customers go = new customers();
            go.Show();
            this.Hide();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employees go = new employees();
            go.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Branches.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Branch branch = new Branch();
            branch.branchName = textBox1.Text;
            branch.branchEmpCount =int.Parse(textBox2.Text);
            branch.branchIncome = Convert.ToDecimal(textBox3.Text);
            branch.branchCarstock =int.Parse(textBox4.Text);
            conn.Branches.Add(branch);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Branches.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = conn.Branches.Where(a => a.branchNo == id).FirstOrDefault();

            conn.Branches.Remove(deleteEmp);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Branches.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["branchNo"].Value.ToString();
            textBox1.Text = column.Cells["branchName"].Value.ToString();
            textBox2.Text = column.Cells["branchEmpCount"].Value.ToString();
            textBox3.Text = column.Cells["branchIncome"].Value.ToString();
            textBox4.Text = column.Cells["branchCarstock"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = conn.Branches.Where(x => x.branchNo == ID).FirstOrDefault(); //içine ne girersen onu tutar hepsini kapsar.

            update.branchName = textBox1.Text;
            update.branchEmpCount =int.Parse( textBox2.Text);
            update.branchIncome =Convert.ToDecimal(textBox3.Text);
            update.branchCarstock =int.Parse(textBox4.Text);

            conn.SaveChanges();
            dataGridView1.DataSource = conn.Branches.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Branches.Where
              (x => x.branchName.Contains(textBox1.Text)).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var query = from income in conn.Branches
                        orderby income.branchIncome descending
                        select income;
            dataGridView1.DataSource = query.ToList();
        }
    }
}
