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
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : UserControl
    {


        public Staff()
        {
            InitializeComponent();

            string path = @"D:\MedPadProject\MedPadProject\Data\doctors.xml";

            IEnumerable<string> docs = from Doctors in XDocument.Load(path).Descendants("Doctor")
                                       select Doctors.Element("Name").Value;

            foreach(string str in docs)
            {
                selectDocCB.Items.Add(str);
                comboBoxDoctors.Items.Add(str);
                docList.Items.Add(str);
            }
            

            


        }






        private void buttonCBD_Click(object sender, RoutedEventArgs e)
        {
            listViewDPL.Items.Clear();

            string selectDDL = comboBoxDoctors.SelectedValue.ToString();

            string path = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";
            /*
            IEnumerable<string> patients = from Patients in XDocument.Load(path).Descendants("Patient")
                                           where (string)Patients.Element("DoctorName") == selectDDL
                                           select Patients.Element("Name").Value;

            foreach(string str in patients)
            {
                listViewDPL.Items.Add(str);
            }
                                            //<--- HERE is where i want to select The Docotor's List of Patients ASK HOW
             */
            XDocument xmlDocument = XDocument.Load(path);

            //Patient ptn = new Patient();

            IEnumerable<Patient> patient = from Patients in xmlDocument.Descendants("Patient")
                                           where (string)Patients.Element("DoctorName") == selectDDL
                                           select new
                                           Patient()
                                           {
                                               Name = (string)Patients.Element("Name"),
                                               address = (string)Patients.Element("Address")
                                               
                                           };



            foreach (Patient p in patient )
            {
                listViewDPL.Items.Add(p);
            }


        }
      

        private void addPatientButton_Click(object sender, RoutedEventArgs e)
        {
            string path = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";

            Patient p = new Patient();


            //p.fName = pFNametxt.Text;
            //p.lName = pLNametxt.Text;
            p.Name = pFNametxt.Text + " " + pLNametxt.Text;
            string namey = p.Name; 

            p.address = pAddresstxt.Text;
            p.pNumber = pPhonetxt.Text;
            p.email = pEmail.Text;
            p.DOB = pDOB.Text;
            p.medHistory = medHistoryCB.Text;
            p.DoctorName = selectDocCB.SelectedItem.ToString();


            IEnumerable<string> existingPatients = from Patients in XDocument.Load(path).Descendants("Patient")
                                                   where (string)Patients.Element("Address") == pAddresstxt.Text
                                                   select Patients.Element("Name").Value;

            bool check = false;

            foreach (string st in existingPatients)
                if (st == namey)
                    check = true;

            if (!check)
            {

                try
                {


                    XDocument xmlDocument = XDocument.Load(path);


                    xmlDocument.Element("Patients").Add(
                         new XElement("Patient", new XAttribute("Name", namey),
                            new XElement("Name", p.Name),
                            new XElement("Address", p.address),
                            new XElement("Phone", p.pNumber),
                            new XElement("Email", p.email),
                            new XElement("DOB", p.DOB),
                            new XElement("MedicalHistory", p.medHistory),
                            new XElement("DoctorName", p.DoctorName))

                        );

                    xmlDocument.Save(path);
                    MessageBox.Show("Thank You, Patient has now been recorded in our system.");

                }

                catch (Exception err)
                {
                    MessageBox.Show("XML file could not be loaded." + err);
                }
            }
            else
            {
                MessageBox.Show("Duplicate Patient Information!");
            }

        }

        private void buttonView_Click_1(object sender, RoutedEventArgs e)
        {

            Patient pName = (Patient)listViewDPL.SelectedItems[0];
            string name = pName.Name;
            
            PatientInfoStaff patient = new PatientInfoStaff(name);
            grid4.Children.Clear();
            grid4.Children.Add(patient);
        }

        private void docList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            patList.Items.Clear();
            string docName = docList.SelectedItem.ToString();

            if (docName != null)
            {
                string patientPath = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";
                IEnumerable<string> patient = from Patients in XDocument.Load(patientPath).Descendants("Patient")
                                              where (string)Patients.Element("DoctorName") == docName
                                              select Patients.Element("Name").Value;
                foreach (string str in patient)
                {
                    
                    patList.Items.Add(str);
                    
                }

            }



        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string path = @"D:\MedPadProject\MedPadProject\Data\Patients.xml";
                string patientName = patList.SelectedItem.ToString();
                DateTime appDate = (DateTime)appointCalendar.SelectedDate;
                string appointDate = appDate.ToString("MMMM dd, yyyy");
                string time = this.cmbTime.SelectionBoxItem.ToString();
                if (time != null)
                { 
                    appointDate = appointDate + " " + time;
                    XDocument xmlDocument = XDocument.Load(path);
                    xmlDocument.Element("Patients").Elements("Patient")
                                                   .Where(x => x.Element("Name").Value == patientName).FirstOrDefault()
                                                   .SetElementValue("AppointmentDate", appointDate);
                    xmlDocument.Save(path);

                    MessageBox.Show("Appointment has been set!");
                }
                else
                {
                    MessageBox.Show("Please choose a time!");
                }
                
            }
            catch(Exception nope)
            {
                MessageBox.Show("Sorry,your appointment could not be processed at this time!");
            }
        }
    }
}
