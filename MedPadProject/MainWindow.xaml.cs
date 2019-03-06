using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace MedPadProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menuItemHome_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            //grid2.Children.Clear();
            //grid2.Children.Add(main);
            main.Show();
            this.Close();
        }

      

        private void btnDoctorEnter_Click(object sender, RoutedEventArgs e)
        {

            string path = @"D:\MedPadProject\MedPadProject\Data\doctors.xml";
            IEnumerable<string> tempPassword = from Doctors in XDocument.Load(path).Descendants("Doctor")
                                               where (string)Doctors.Element("Username") == txtDotorLoginUserName.Text
                                               select Doctors.Element("Password").Value;
            if ((int)tempPassword.Count() == 0)
            {
                MessageBox.Show("Invalid username");
            }
            else
            {
                foreach (string st in tempPassword)
                    if (st == txtDoctorLoginPassword.Password.ToString())
                    {
                        Doctor doctors = new Doctor(txtDotorLoginUserName.Text);
                        grid2.Children.Clear();
                        grid2.Children.Add(doctors);
                        //MessageBox.Show("sucessful log in");
                    }
                    else
                    {
                        MessageBox.Show("invalid password");
                    }
            }



        }

        private void btnStaffEnter_Click(object sender, RoutedEventArgs e)
        {
            string path = @"D:\MedPadProject\MedPadProject\Data\staff.xml";
            IEnumerable<string> tempPassword = from Staff in XDocument.Load(path).Descendants("Employee")
                                               where (string)Staff.Element("Username") == txtStaffLoginUserName.Text
                                               select Staff.Element("Password").Value;
            if ((int)tempPassword.Count() == 0)
            {
                MessageBox.Show("Invalid username");
            }
            else
            {
                foreach (string st in tempPassword)
                    if (st == txtStaffLoginPassword.Password.ToString())
                    {
                        Staff staff = new Staff();
                        grid2.Children.Clear();
                        grid2.Children.Add(staff);
                        //MessageBox.Show("sucessful log in");
                    }
                    else
                    {
                        MessageBox.Show("invalid password");
                    }
            }
               
        }

        private void btnDoctorRegister_Click(object sender, RoutedEventArgs e)
        {
            string path = @"D:\MedPadProject\MedPadProject\Data\doctors.xml";

            IEnumerable<string> usernames = from Doctors in XDocument.Load(path).Descendants("Doctor")
                                            select Doctors.Element("Username").Value;

            bool check = false;

            foreach (string st in usernames)
                if (st == txtBoxDoctorUsername.Text)
                    check = true;

            if (!check)
            {
                try
                {
                    if (txtBoxDoctorPassword.Password.ToString() == txtBoxDoctorConfirmPassword.Password.ToString())
                    {

                        XDocument xmlDocument = XDocument.Load(path);



                        xmlDocument.Element("Doctors").Add(
                             new XElement("Doctor", new XAttribute("name", txtBoxDoctorFisrtName.Text + " " + txtBoxDoctorLastName.Text),
                                new XElement("Name", txtBoxDoctorFisrtName.Text + " " + txtBoxDoctorLastName.Text),
                                new XElement("Username", txtBoxDoctorUsername.Text),
                                new XElement("Password", txtBoxDoctorPassword.Password.ToString()),
                                new XElement("Email", txtDoctorEmail.Text),
                                new XElement("PhoneNumber", txtBoxDoctorPhoneNumber.Text),
                                new XElement("ConfirmPasssword", txtBoxDoctorConfirmPassword.Password.ToString()))

                            );
                        xmlDocument.Save(path);
                        MessageBox.Show("Thank you for registering with MedPad+");
                    }
                    else
                    {
                        MessageBox.Show("Confirmed password does not match password, make sure they match");
                    }
                }

                catch (Exception er)
                {
                    MessageBox.Show("XML file could not be loaded.");

                }
            }
            else
            {
                MessageBox.Show("Username taken! Try again");
            }

            txtBoxDoctorFisrtName.Text = "";
            txtBoxDoctorLastName.Text = "";
            txtBoxDoctorPassword.Password = "";
            txtBoxDoctorPhoneNumber.Text = "";
            txtBoxDoctorConfirmPassword.Password = "";
            txtBoxDoctorUsername.Text = "";
            txtDoctorEmail.Text = "";
        }

        private void btnStaffRegister_Click(object sender, RoutedEventArgs e)
        {
            string path = @"D:\MedPadProject\MedPadProject\Data\staff.xml";

            IEnumerable<string> usernames = from Staff in XDocument.Load(path).Descendants("Employee")
                                            select Staff.Element("Username").Value;

            bool check = false;

            foreach (string st in usernames)
                if (st == txtBoxStaffUsername.Text)
                    check = true;

            if (!check)
            {

                try
                {
                    if (txtBoxStaffPassword.Password.ToString() == txtBoxStaffConfirmPassword.Password.ToString())
                    {

                        XDocument xmlDocument = XDocument.Load(path);


                        xmlDocument.Element("Staff").Add(
                             new XElement("Employee", new XAttribute("name", txtBoxStaffFisrtName.Text + " " + txtBoxStaffLastName.Text),
                                new XElement("Username", txtBoxStaffUsername.Text),
                                new XElement("Password", txtBoxStaffPassword.Password.ToString()),
                                new XElement("Email", txtBoxStaffEmail.Text),
                                new XElement("PhoneNumber", txtBoxStaffPhoneNumber.Text),
                                new XElement("ConfirmPasssword", txtBoxStaffConfirmPassword.Password.ToString()))

                            );
                        xmlDocument.Save(path);
                        MessageBox.Show("Thank you for registering with MedPad");
                    }

                    else
                    {
                        MessageBox.Show("Confirmed password does not match password, make sure they match");
                    }
                }

                catch (Exception er)
                {
                    MessageBox.Show("XML file could not be loaded.");
                }
            }
            else
            {
                MessageBox.Show("Username taken! Try again");
            }

            txtBoxStaffFisrtName.Text = "";
            txtBoxStaffLastName.Text = "";
            txtBoxStaffEmail.Text = "";
            txtBoxStaffPhoneNumber.Text = "";
            txtBoxStaffPassword.Password = "";
            txtBoxStaffConfirmPassword.Password = "";

    }

        private void btnLogInAdmin_Click(object sender, RoutedEventArgs e)
        {
            if(txtAdminName.Text=="admin"&&txtAdminPassword.Password.ToString() == "password")
            {
                adminPage loginadmin = new adminPage();
                grid2.Children.Clear();
                grid2.Children.Add(loginadmin);
                //MessageBox.Show("sucessful log in");
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

       
    }
}
