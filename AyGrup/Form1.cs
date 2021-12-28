using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Windows.Forms;
namespace AyGrup
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Kısayollar
           


            //

            this.IsMdiContainer = true;

            string[] firmalar = System.IO.File.ReadAllLines(@"Data\\sirket.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in firmalar)
            {
                SirketList.Items.Add(str);
            }

            string[] kullanici = System.IO.File.ReadAllLines(@"Data\\kullanici.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in kullanici)
            {
                KullaniciList.Items.Add(str);
            }

            string[] kod = System.IO.File.ReadAllLines(@"Data\\kod.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in kod)
            {
                kodList.Items.Add(str);
            }
            string[] sistem = System.IO.File.ReadAllLines(@"Data\\sistem.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in sistem)
            {
                sistemList.Items.Add(str);
            }
            string[] isveren = System.IO.File.ReadAllLines(@"Data\\isveren.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in isveren)
            {
                isverenList.Items.Add(str);
            }
            string[] araci = System.IO.File.ReadAllLines(@"Data\\araci.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in araci)
            {
                ListAraci.Items.Add(str);
            }
            string[] sirketSifre = System.IO.File.ReadAllLines(@"Data\\sirket.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in sirketSifre)
            {
                SifreDegistirFirma.Items.Add(str);
            }
            string[] sistemSifre = System.IO.File.ReadAllLines(@"Data\\sistem.txt", System.Text.Encoding.GetEncoding("UTF-8"));
            foreach (string str in sistemSifre)
            {
                SifreDegistirSistem.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SirketList.Text == "")
            {
                MessageBox.Show("Lütfen Bir Şirket Seçin");
            }
            else if (SirketList.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://ebildirge.sgk.gov.tr/EBildirgeV2");
                var InputElement = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_username"));
                InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
                var IsyeriKontrol = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_isyeri_kod"));
                IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
                var IsyeriPass = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_password"));
                IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
                var IsyeriGuvenlik = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_isyeri_sifre"));
                IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
                Console.WriteLine("Çalışıyorum.");
            }

            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kontrol_Click(object sender, EventArgs e)
        {

        }

        private void SirketList_SelectedIndexChanged(object sender, EventArgs e)
        {
            KullaniciList.SelectedIndex = SirketList.SelectedIndex;
            kodList.SelectedIndex = SirketList.SelectedIndex;
            sistemList.SelectedIndex = SirketList.SelectedIndex;
            isverenList.SelectedIndex = SirketList.SelectedIndex;
            ListAraci.SelectedIndex = SirketList.SelectedIndex;
        }

       

        private void ebildirgeButton_Click(object sender, EventArgs e)
        {
            if (SirketList.Text == "")
            {
                MessageBox.Show("Lütfen Bir Şirket Seçin");
            }
            else if (SirketList.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://ebildirge.sgk.gov.tr/WPEB/amp/loginldap");
                var InputElement = driver.FindElement(By.Name("j_username"));
                InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
                var IsyeriKontrol = driver.FindElement(By.Name("isyeri_kod"));
                IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
                var IsyeriPass = driver.FindElement(By.Name("j_password"));
                IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
                var IsyeriGuvenlik = driver.FindElement(By.Name("isyeri_sifre"));
                IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
                Console.WriteLine("Çalışıyorum.");
            }


            
        }

        private void emanetButton_Click(object sender, EventArgs e)
        {
            if (SirketList.Text == "")
            {
                MessageBox.Show("Lütfen Bir Şirket Seçin");
            }
            else if (SirketList.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://uyg.sgk.gov.tr/IsverenBorcSorgu/borc/donemselBorc.action");
                var InputElement = driver.FindElement(By.Name("basvuru.tcKimlikNo"));
                InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
                var IsyeriKontrol = driver.FindElement(By.Name("basvuru.isyeriKodu"));
                IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
                var IsyeriPass = driver.FindElement(By.Name("basvuru.sistemSifre"));
                IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
                var IsyeriGuvenlik = driver.FindElement(By.Name("basvuru.isyeriSifre"));
                IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
                Console.WriteLine("Çalışıyorum.");
            }

            
        }

        private void girisCikisButton_Click(object sender, EventArgs e)
        {
            if (SirketList.Text == "")
            {
                MessageBox.Show("Lütfen Bir Şirket Seçin");
            }
            else if (SirketList.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://uyg.sgk.gov.tr/SigortaliTescil/amp/loginldap");
                var InputElement = driver.FindElement(By.Name("j_username"));
                InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
                var IsyeriKontrol = driver.FindElement(By.Name("isyeri_kod"));
                IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
                var IsyeriPass = driver.FindElement(By.Name("j_password"));
                IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
                var IsyeriGuvenlik = driver.FindElement(By.Name("isyeri_sifre"));
                IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
                Console.WriteLine("Çalışıyorum.");
            }

            
        }

        private void engelliTesvik_Click(object sender, EventArgs e)
        {
            if (SirketList.Text == "")
            {
                MessageBox.Show("Lütfen Bir Şirket Seçin");
            }
            else if (SirketList.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://uyg.sgk.gov.tr/Sigortali_Tesvik_4a/login.jsp");
                var InputElement = driver.FindElement(By.Name("j_username"));
                InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
                var IsyeriKontrol = driver.FindElement(By.Name("isyeri_kod"));
                IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
                var IsyeriPass = driver.FindElement(By.Name("j_password"));
                IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
                var IsyeriGuvenlik = driver.FindElement(By.Name("isyeri_sifre"));
                IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
                Console.WriteLine("Çalışıyorum.");
            }

            
        }

        private void aylikSgk_Click(object sender, EventArgs e)
        {
            aylikSgkForm sgkForm = new aylikSgkForm();
            sgkForm.Show();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void sirketEkleButton_Click(object sender, EventArgs e)
        {
            SirketList.Items.Add(firmalarTextBox.Text);
            KullaniciList.Items.Add(kullaniciTextBox.Text);
            kodList.Items.Add(kodTextBox.Text);
            sistemList.Items.Add(sistemTextBox.Text);
            isverenList.Items.Add(isverenTextB.Text);
            ListAraci.Items.Add(araciTextBox.Text);
            //Dosya İşlemleri Başlangıç
            StreamWriter sirketText = File.AppendText(Application.StartupPath + "\\Data\\sirket.txt");
            string sirket = firmalarTextBox.Text;
            sirketText.WriteLine(sirket);
            sirketText.Close();
                //
            StreamWriter kullaniciText = File.AppendText(Application.StartupPath + "\\Data\\kullanici.txt");
            string kullanici = kullaniciTextBox.Text;
            kullaniciText.WriteLine(kullanici);
            kullaniciText.Close();
            //
            StreamWriter kodText = File.AppendText(Application.StartupPath + "\\Data\\kod.txt");
            string kod = kodTextBox.Text;
            kodText.WriteLine(kod);
            kodText.Close();
            //
            StreamWriter sistemText = File.AppendText(Application.StartupPath + "\\Data\\sistem.txt");
            string sistem = sistemTextBox.Text;
            sistemText.WriteLine(sistem);
            sistemText.Close();
            //
            StreamWriter isverenText = File.AppendText(Application.StartupPath + "\\Data\\isveren.txt");
            string isveren = isverenTextB.Text;
            isverenText.WriteLine(isveren);
            isverenText.Close();
            //
            StreamWriter araciList = File.AppendText(Application.StartupPath + "\\Data\\araci.txt");
            string araci = araciTextBox.Text;
            araciList.WriteLine(araci);
            araciList.Close();
            //

            MessageBox.Show("Kayıt Başarılı");
            firmalarTextBox.Text = String.Empty;
            kullaniciTextBox.Text = String.Empty;
            kodTextBox.Text = String.Empty;
            sistemTextBox.Text = String.Empty;
            isverenTextB.Text = String.Empty;
            araciTextBox.Text = String.Empty;

        }

        private void kullaniciTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sistemList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sistemTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SirketEkleScreen_Click(object sender, EventArgs e)
        {
            this.Width = Convert.ToInt32(1083);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Width = Convert.ToInt32(543);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SifreDegistirSistem.SelectedIndex = SifreDegistirFirma.SelectedIndex;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void guncelleButton_Click(object sender, EventArgs e)
        {
            String strFile = File.ReadAllText(@"Data\\sistem.txt");

            strFile = strFile.Replace(SifreDegistirSistem.Text, newPass.Text);

            File.WriteAllText(@"Data\\sistem.txt", strFile);

            MessageBox.Show("Şifre Değiştirildi Lütfen Veritabanını Güncelleyin");
        }

        private void veriTabaniUpdate_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F1)
            {
                isverenbt.PerformClick();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F2)
            {
                ebildirgev2Button.PerformClick();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F3)
            {
                ebildirgeButton.PerformClick();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F4)
            {
                emanetButton.PerformClick();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F5)
            {
                girisCikisButton.PerformClick();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.F6)
            {
                engelliTesvik.PerformClick();
            }
        }

        private void IsverenButton_Click_1(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://uyg.sgk.gov.tr/IsverenSistemi");
            var InputElement = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_username"));
            InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
            var IsyeriKontrol = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_isyeri_kod"));
            IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
            var IsyeriPass = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_password"));
            IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
            var IsyeriGuvenlik = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_isyeri_sifre"));
            IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
            Console.WriteLine("Çalışıyorum.");
        }

        private void isverenbt_Click(object sender, EventArgs e)
        {
            if (SirketList.Text == "")
            {
                MessageBox.Show("Lütfen Şirket Seçin");
            }

            else if (SirketList.Text != "")
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://uyg.sgk.gov.tr/IsverenSistemi");
                var InputElement = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_username"));
                InputElement.SendKeys(this.KullaniciList.GetItemText(this.KullaniciList.SelectedItem));
                var IsyeriKontrol = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_isyeri_kod"));
                IsyeriKontrol.SendKeys(this.kodList.GetItemText(this.kodList.SelectedItem));
                var IsyeriPass = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_password"));
                IsyeriPass.SendKeys(this.sistemList.GetItemText(this.sistemList.SelectedItem));
                var IsyeriGuvenlik = driver.FindElement(By.Id("kullaniciIlkKontrollerGiris_isyeri_sifre"));
                IsyeriGuvenlik.SendKeys(this.isverenList.GetItemText(this.isverenList.SelectedItem));
                Console.WriteLine("Çalışıyorum.");
            }

            
        }
    }
}
