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
    /// Interaction logic for PatientInfoStaff.xaml
    /// </summary>
    public partial class PatientInfoStaff : UserControl
    {
        public PatientInfoStaff(string pName)
        {
            InitializeComponent();
            txtPatientName.Text = pName;

            string path = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";
            IEnumerable<Patient> patName = from Patients in XDocument.Load(path).Descendants("Patient")
                                           where (string)Patients.Element("Name") == pName
                                           select new Patient
                                           {
                                               Name = Patients.Element("Name").Value,
                                               address = Patients.Element("Address").Value,
                                               pNumber = Patients.Element("Phone").Value,
                                               email = Patients.Element("Email").Value,
                                               DOB = Patients.Element("DOB").Value,
                                               medHistory = Patients.Element("MedicalHistory").Value,
                                               DoctorName = Patients.Element("DoctorName").Value

                                           };
            foreach (Patient p in patName)
            {
                txtAddress.Text = p.address;
                txtPhone.Text = p.pNumber;
                txtEmail.Text = p.email;
                txtDOB.Text = p.DOB;
                txtmedicalHistory.Text = p.medHistory;
                txtDocName.Text = p.DoctorName;

            }
        }

        private void btnBackStaff_Click(object sender, RoutedEventArgs e)
        {
            Staff st = new Staff();
            gridPatientStaff.Children.Clear();
            gridPatientStaff.Children.Add(st);
        }
    }
}
