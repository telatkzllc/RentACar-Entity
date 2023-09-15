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
    public partial class customerregister : Form
    {
        public customerregister()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn = new RentacarEntities1();
        private void customerregister_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Customer customer = new Customer();
                customer.customerNameSurname = textBox1.Text;
                customer.customerPhone = textBox2.Text;
                customer.customerAge = int.Parse(textBox3.Text);
                customer.customerBalance = Convert.ToDecimal(textBox4.Text);
                customer.customerDeposit = Convert.ToDecimal(textBox5.Text);
                customer.employeeNo = int.Parse(textBox6.Text);
                conn.Customers.Add(customer);
                conn.SaveChanges();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                Form1 go = new Form1();
                go.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("adam akıllı gir ");
            }
        }
    }
}
