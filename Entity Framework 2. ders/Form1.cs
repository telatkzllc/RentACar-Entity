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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        RentacarEntities1 conn=new RentacarEntities1();

        public bool Login(string username, string password)
        {
            var query = from user in conn.Employees
                        where user.employeeNameSurname== username && user.employeeTitle==password
                        select user;
            if (query.Any())
            {
                return true;
            }
            else { return false; }
        }
        public bool cusLogin(string username,string password) 
        {
            var query = from user in conn.Customers
                        where user.customerPhone == username && user.customerNameSurname==password
                        select user;
            if (query.Any())
            {
                return true;
            }
            else { return false; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rentacar projesi olacak
            //müşteriler,araclar,subeler,personeller
            //personel ve müsteri giris
            //personel tüm sayfalara erisim saglayıp islem yapabilecek
            //müsteri sadece araclar ve subelere erisecek
            //bir de paketleri olacak

            //musteriler          //araclar
            //musterino           //aracno,fyat,adet,marka,model,yıl,motor,paket,renk esc.
            //musteriadsoyad
            //tel                 //subeler
            //yas                   subeno
            //bakiye                subeadı
            //kapora                calısansayısı sube ciro

            //personeller
            //perno,adsoyad,tel,unvan,mail,maas
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            radioButton1.Checked= false;
            radioButton2.Checked = false;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Login(textBox1.Text, textBox2.Text))
            {
                employees go = new employees();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı tekrar deneyiniz");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cusLogin(textBox3.Text,textBox4.Text))
            {
                cuscars go = new cuscars();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı tekrar deneyiniz");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            groupBox1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            personnelregister go = new personnelregister();
            go.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            customerregister go = new customerregister();
            go.Show();
            this.Hide();
        }
    }
}
