using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsAppHW3
{
    public partial class Form1 : Form
    {
        public string xmlPath { get; set; }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Worker>));
        List<Worker> workers = new List<Worker>();

        public List<string> Workers
        {
            get
            {
                listBoxWorkers.Items.Clear();
                foreach (var item in workers)
                {
                    listBoxWorkers.Items.Add($"{item.Name} {item.Surname} {item.DadName}");
                }
                return (List<string>)listBoxWorkers.DataSource;
            }
            set
            {
                listBoxWorkers.Items.Clear();
                foreach (var item in workers)
                {
                    listBoxWorkers.Items.Add($"{item.Name} {item.Surname} {item.DadName}");
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumberField_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse((sender as TextBox).Text);
            }
            catch (Exception)
            {
                (sender as TextBox).Text = "";
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workers.Clear();
            Workers = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                DefaultExt = "xml",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlPath = saveFileDialog.FileName;
                using (var ser = new StreamWriter(xmlPath))
                {
                    xmlSerializer.Serialize(ser, workers);
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = $"All files(*.*)|*.*| XML files (*.xml)|*.xml"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlPath = openFileDialog.FileName;
                using(var ser = new StreamReader(xmlPath))
                {
                    workers = (List<Worker>)xmlSerializer.Deserialize(ser);
                }
            }
            Workers = null; 
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ser = new StreamWriter(xmlPath))
            {
                xmlSerializer.Serialize(ser, workers);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "XML files (*.xml)|*.xml",
                DefaultExt = "xml",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                xmlPath = saveFileDialog.FileName;
                using (var ser = new StreamWriter(xmlPath))
                {
                    xmlSerializer.Serialize(ser, workers);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                workers.Add(new Worker(textBoxName.Text, textBoxSurname.Text, textBoxDadName.Text, dateTimePickerBirth.Value, Int32.Parse(textBoxPhone.Text), textBoxAddress.Text, textBoxStreet.Text, Int32.Parse(textBoxHomeNumber.Text), Int32.Parse(textBoxApartmentNumber.Text)));
                Workers = null;
            }
            catch (Exception)
            {

            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            workers[listBoxWorkers.SelectedIndex] = new Worker(textBoxName.Text, textBoxSurname.Text, textBoxDadName.Text, dateTimePickerBirth.Value, Int32.Parse(textBoxPhone.Text), textBoxAddress.Text, textBoxStreet.Text, Int32.Parse(textBoxHomeNumber.Text), Int32.Parse(textBoxApartmentNumber.Text));
            Workers = null;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            workers.RemoveAt(listBoxWorkers.SelectedIndex);
        }

        private void listBoxWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            Worker worker = workers[listBoxWorkers.SelectedIndex];
            textBoxName.Text = worker.Name;
            textBoxSurname.Text = worker.Surname;
            textBoxDadName.Text = worker.DadName;
            dateTimePickerBirth.Value = worker.BirthDay;
            textBoxPhone.Text = worker.Phone.ToString();
            textBoxAddress.Text = worker.Address;
            textBoxStreet.Text = worker.Street;
            textBoxHomeNumber.Text = worker.Home.ToString();
            textBoxApartmentNumber.Text = worker.Apartment.ToString();
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
            double d = 0;
            List<Worker> workersTask = new List<Worker>();
            listBox1.Items.Clear();
            foreach (var item in workers)
            {
                if(item.Home%2==0 && item.Street == textBox1.Text)
                {
                    workersTask.Add(item);
                    listBox1.Items.Add($"{item.Name} {item.Surname} {item.DadName}");
                    d += (DateTime.Now - item.BirthDay).TotalDays / 365;
                }
            }
            label1.Text = d.ToString("F2") + " years";
        }
    }
}
