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
    /// Interaction logic for Doctor.xaml
    /// </summary>
    public partial class Doctor : UserControl
    {

        public Doctor(string username)
        {
            InitializeComponent();

            //string username = ((MainWindow)Application.Current.MainWindow).txtDotorLoginUserName.Text;


            string path = @"D:\MedPadProject\MedPadProject\Data\doctors.xml";
            IEnumerable<string> docName = from Doctors in XDocument.Load(path).Descendants("Doctor")
                                          where (string)Doctors.Element("Username") == username
                                          select Doctors.Element("Name").Value;

            foreach (string s in docName)
                txtdocName.Text = s;
            txtusername.Text = username;

            string path1 = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";

            IEnumerable<string> patientList = from Patients in XDocument.Load(path1).Descendants("Patient")
                                              where (string)Patients.Element("DoctorName") == txtdocName.Text
                                              select Patients.Element("Name").Value;

            foreach (string st in patientList)
                pList.Items.Add(st);



        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            if(pList.SelectedItem.ToString() == null)
            {
                MessageBox.Show("Please Select A Patient");

            }

            else
            {
                string patientN = pList.SelectedItem.ToString();
                string docName = txtusername.Text;
                PatientInfo patient = new PatientInfo(patientN, docName);
                doctorGrid.Children.Clear();
                doctorGrid.Children.Add(patient);

            }

        }

    }
}
