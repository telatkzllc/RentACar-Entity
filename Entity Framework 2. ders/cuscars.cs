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
    public partial class cuscars : Form
    {
        public cuscars()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn = new RentacarEntities1();
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
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = conn.Cars.ToList();
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem=="Plate")
            {
                dataGridView1.DataSource = conn.Cars.Where
             (x => x.carPlate.Contains(textBox2.Text)).ToList();
            }
            else if (comboBox1.SelectedItem == "Brand")
            {
                dataGridView1.DataSource = conn.Cars.Where
             (x => x.carBrand.Contains(textBox3.Text)).ToList();
            }
            else if (comboBox1.SelectedItem == "Model")
            {
                dataGridView1.DataSource = conn.Cars.Where
             (x => x.carModel.Contains(textBox4.Text)).ToList();
            }
            else if (comboBox1.SelectedItem == "Pac")
            {
                dataGridView1.DataSource = conn.Cars.Where
             (x => x.carPac.Contains(textBox7.Text)).ToList();
            }
            else if (comboBox1.SelectedItem == "Color")
            {
                dataGridView1.DataSource = conn.Cars.Where
             (x => x.carBrand.Contains(textBox8.Text)).ToList();
            }
            else if (comboBox1.SelectedItem == "Transmission")
            {
                dataGridView1.DataSource = conn.Cars.Where
             (x => x.carTransmission.Contains(textBox9.Text)).ToList();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = from urun in conn.Cars
                        where urun.carBrand==textBox5.Text
                        orderby urun.carPrice descending
                        select new { urun.carPrice,urun.carBrand, urun.carYear, urun.carEngine };
            dataGridView1.DataSource = query.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var query = (from car in conn.Cars
                         orderby car.carYear descending
                         select new
                         {
                             car.carNo,
                             car.carPrice,
                             car.carPlate,
                             car.carBrand,
                             car.carModel,
                             car.carYear,
                             car.carEngine,
                             car.carPac,
                             car.carColor,
                             car.carTransmission,
                             car.branchNo
                         }).Take(2);

            dataGridView1.DataSource = query.ToList();
        }
    }
} 
