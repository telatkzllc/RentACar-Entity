using System ;
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
    public partial class employees : Form
    {
        public employees()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn = new RentacarEntities1();
        private void button1_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.employeeNameSurname = textBox1.Text;
            employee.employeePhone = textBox2.Text;
            employee.employeeTitle = textBox3.Text;
            employee.employeeMail = textBox4.Text;
            employee.employeeSalary =Convert.ToDecimal(textBox5.Text);
            employee.branchNo =int.Parse(textBox6.Text);
            conn.Employees.Add(employee);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Employees.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Employees.ToList();   
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["employeeNo"].Value.ToString();
            textBox1.Text = column.Cells["employeeNameSurname"].Value.ToString();
            textBox2.Text = column.Cells["employeePhone"].Value.ToString();
            textBox3.Text = column.Cells["employeeTitle"].Value.ToString();
            textBox4.Text = column.Cells["employeeMail"].Value.ToString();
            textBox5.Text = column.Cells["employeeSalary"].Value.ToString();
            textBox6.Text = column.Cells["branchNo"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = conn.Employees.Where(a => a.employeeNo == id).FirstOrDefault();

            conn.Employees.Remove(deleteEmp);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Employees.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = conn.Employees.Where(x => x.employeeNo == ID).FirstOrDefault(); //içine ne girersen onu tutar hepsini kapsar.

            update.employeeNameSurname = textBox1.Text;
            update.employeePhone = textBox2.Text;
            update.employeeTitle = textBox3.Text;
            update.employeeMail = textBox4.Text;
            update.employeeSalary =Convert.ToDecimal(textBox5.Text);
            update.branchNo =int.Parse(textBox6.Text);



            conn.SaveChanges();
            dataGridView1.DataSource = conn.Employees.ToList();
        }

        private void arabalarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            carsstaff go=new carsstaff();
            go.Show();
            this.Hide();
        }
        private void şubelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            branches go = new branches();
            go.Show();
            this.Hide();
        }

        private void müşterilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customers go = new customers();
            go.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Employees.Where
               (x => x.employeeNameSurname.Contains(textBox1.Text)).ToList();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //var query = from worker in conn.Employees
            //            where worker.employeeSalary <= Convert.ToDecimal(textBox7.Text)
            //            && worker.employeeSalary >= Convert.ToDecimal(textBox8.Text)
            //            select worker;
            //dataGridView1.DataSource = query.ToList();

            Decimal max =Convert.ToInt32(textBox7.Text);
            Decimal min = Convert.ToInt32(textBox8.Text);

            var query = conn.Employees.Where(worker => worker.employeeSalary <= max
            && worker.employeeSalary >= min);
            dataGridView1.DataSource = query.ToList();

            //var query = conn.Employees.Where(worker => worker.employeeSalary <= 40000
            //&& worker.employeeSalary >= 15000);
            //dataGridView1.DataSource = query.ToList();

        }
    } 
}
