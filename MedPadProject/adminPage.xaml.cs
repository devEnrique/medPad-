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
    /// Interaction logic for adminPage.xaml
    /// </summary>
    public partial class adminPage : UserControl
    {
        string path = @"D:\MedPadProject\MedPadProject\Data\doctors.xml";
        string path1 = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";
        string path2 = @"D:\MedPadProject\MedPadProject\Data\staff.xml";

        public adminPage()
        {
            InitializeComponent();
            

            IEnumerable<string> docs = from Doctors in XDocument.Load(path).Descendants("Doctor")
                                       select Doctors.Element("Name").Value;

            IEnumerable<string> pats = from Patients in XDocument.Load(path1).Descendants("Patient")
                                       select Patients.Element("Name").Value;

            IEnumerable<string> staf = from Staff in XDocument.Load(path2).Descendants("Employee")
                                       select Staff.Attribute("name").Value;

            

            foreach (string d in docs)
            {
                lstOfDocs.Items.Add(d);
            }
            foreach (string p in pats)
            {
                lstOfPats.Items.Add(p);
            }
            foreach (string s in staf)
            {
                lstOfStaff.Items.Add(s);
            }
        }

        private void btnDeleteStaff_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlDocument = XDocument.Load(path2);

            xmlDocument.Root.Elements().Where(x => x.Attribute("name").Value == lstOfStaff.SelectedItem.ToString()).Remove();
            xmlDocument.Save(path2);

            adminPage loginadmin = new adminPage();
            adminGrid.Children.Clear();
            adminGrid.Children.Add(loginadmin);
        }

        private void btnDeletePatient_Click(object sender, RoutedEventArgs e)
        {
            XDocument xmlDocument = XDocument.Load(path1);

            xmlDocument.Root.Elements().Where(x => x.Element("Name").Value == lstOfPats.SelectedItem.ToString()).Remove();
            xmlDocument.Save(path1);

            adminPage loginadmin = new adminPage();
            adminGrid.Children.Clear();
            adminGrid.Children.Add(loginadmin);

        }

        private void btnDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> findPatient = from Patients in XDocument.Load(path1).Descendants("Patient")
                                              where (string)Patients.Element("DoctorName") == lstOfDocs.SelectedItem.ToString()
                                              select Patients.Element("Name").Value;

            if ((int)findPatient.Count() == 0)
            {
                XDocument xmlDocument = XDocument.Load(path);

                xmlDocument.Root.Elements().Where(x => x.Element("Name").Value == lstOfDocs.SelectedItem.ToString()).Remove();
                xmlDocument.Save(path);

                adminPage loginadmin = new adminPage();
                adminGrid.Children.Clear();
                adminGrid.Children.Add(loginadmin);
            }
            else
            {
                MessageBox.Show("Sorry! Cannot delete doctor who has patients!");
            }

           
            

        }
    }
}
