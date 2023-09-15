using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Entity_Framework_2.ders
{
    public partial class carsstaff : Form
    {
        public carsstaff()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn = new RentacarEntities1();
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employees go = new employees();
            go.Show();
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Car carr = new Car();
            carr.carPrice =Convert.ToDecimal(textBox1.Text);
            carr.carPlate = textBox2.Text;
            carr.carBrand = textBox3.Text;
            carr.carModel = textBox4.Text;
            DateTime time = Convert.ToDateTime(dateTimePicker1.Text);
            carr.carYear = time;
            carr.carEngine = int.Parse(textBox6.Text);
            carr.carPac = textBox7.Text;
            carr.carColor = textBox8.Text;
            carr.carTransmission = textBox9.Text;
            carr.branchNo =int.Parse(textBox10.Text);
            conn.Cars.Add(carr);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Cars.ToList();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Cars.ToList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Tag);
            var deleteEmp = conn.Cars.Where(a => a.carNo == id).FirstOrDefault();

            conn.Cars.Remove(deleteEmp);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Cars.ToList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(textBox1.Tag);
            var update = conn.Cars.Where(x => x.carNo == ID).FirstOrDefault(); //içine ne girersen onu tutar hepsini kapsar.
            //sıkıntılı
            update.carPrice =Convert.ToDecimal(textBox1.Text);
            update.carPlate = textBox2.Text;
            update.carBrand = textBox3.Text;
            update.carModel = textBox4.Text;
            DateTime time = Convert.ToDateTime(dateTimePicker1.Text);
            update.carYear = time;
            update.carEngine =int.Parse(textBox6.Text);
            update.carPac = textBox7.Text;
            update.carColor = textBox8.Text;
            update.carTransmission = textBox9.Text;
            update.branchNo = int.Parse(textBox10.Text);
            conn.SaveChanges();
            dataGridView1.DataSource = conn.Cars.ToList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow column = dataGridView1.CurrentRow;
            textBox1.Tag = column.Cells["carNo"].Value.ToString();
            textBox1.Text = column.Cells["carPrice"].Value.ToString();
            textBox2.Text = column.Cells["carPlate"].Value.ToString();
            textBox3.Text = column.Cells["carBrand"].Value.ToString();
            textBox4.Text = column.Cells["carModel"].Value.ToString();
            dateTimePicker1.Text = column.Cells["carYear"].Value.ToString();
            textBox6.Text = column.Cells["carEngine"].Value.ToString();
            textBox7.Text = column.Cells["carPac"].Value.ToString();
            textBox8.Text = column.Cells["carColor"].Value.ToString();
            textBox9.Text = column.Cells["carTransmission"].Value.ToString();
            textBox10.Text = column.Cells["branchNo"].Value.ToString();
        }
        private void branchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            branches go = new branches();
            go.Show();
            this.Hide();
        }
        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customers go = new customers();
            go.Show();
            this.Hide();
        }
        private void carsstaff_Load(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Cars.Where
             (x => x.carBrand.Contains(textBox3.Text)).ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var query = from urun in conn.Cars
                        orderby urun.carYear descending
                        select new { urun.carPrice, urun.carBrand, urun.carYear, urun.carEngine };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
