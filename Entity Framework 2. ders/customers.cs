using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entity_Framework_2.ders
{
    public partial class customers : Form
    {
        public customers()
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
        private void branchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            branches go = new branches();
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
            Customer customer = new Customer();
            customer.customerNameSurname = textBox1.Text;
            customer.customerPhone = textBox2.Text;
            customer.customerAge =int.Parse(textBox3.Text);
            customer.customerBalance =Convert.ToDecimal(textBox4.Text);
            customer.customerDeposit = Convert.ToDecimal(textBox5.Text);
            customer.employeeNo = int.Parse(textBox6.Text);
            conn.Customers.Add(customer);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Customers.ToList();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Customers.ToList();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["customerNo"].Value.ToString();
            textBox1.Text = column.Cells["customerNameSurname"].Value.ToString();
            textBox2.Text = column.Cells["customerPhone"].Value.ToString();
            textBox3.Text = column.Cells["customerAge"].Value.ToString();
            textBox4.Text = column.Cells["customerBalance"].Value.ToString();
            textBox5.Text = column.Cells["customerDeposit"].Value.ToString();
            textBox6.Text = column.Cells["employeeNo"].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = conn.Customers.Where(a => a.customerNo == id).FirstOrDefault();

            conn.Customers.Remove(deleteEmp);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Customers.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = conn.Customers.Where(x => x.customerNo == ID).FirstOrDefault(); //içine ne girersen onu tutar hepsini kapsar.
            update.customerNameSurname = textBox1.Text;
            update.customerPhone = textBox2.Text;
            update.customerAge =int.Parse(textBox3.Text);
            update.customerBalance =Convert.ToDecimal(textBox4.Text);
            update.customerDeposit = Convert.ToDecimal(textBox5.Text);
            update.employeeNo=int.Parse(textBox6.Text);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Customers.ToList();
        }

        private void customers_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Customers.Where
              (x => x.customerNameSurname.Contains(textBox1.Text)).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int max = int.Parse(textBox7.Text);
            int min=int.Parse(textBox8.Text);
            var query = from customer in conn.Customers
                        where customer.customerAge <= max
                        && customer.customerAge >= min
                        select customer;
            dataGridView1.DataSource = query.ToList();
        }
    }
}
