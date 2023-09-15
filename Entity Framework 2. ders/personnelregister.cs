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
    public partial class personnelregister : Form
    {
        public personnelregister()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn = new RentacarEntities1();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            Employee employee = new Employee();
            employee.employeeNameSurname = textBox1.Text;
            employee.employeePhone = textBox2.Text;
            employee.employeeTitle = textBox3.Text;
            employee.employeeMail = textBox4.Text;
            employee.employeeSalary = Convert.ToDecimal(textBox5.Text);
            employee.branchNo = int.Parse(textBox6.Text);
            conn.Employees.Add(employee);
            conn.SaveChanges();
            Form1 go = new Form1();
            go.Show();
            this.Hide();
            }
            catch
            {
                MessageBox.Show("adam akıllı gir");
            }
           
        }
    }
}
