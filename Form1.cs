using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudentTmpl11
{
    public partial class Form1 : Form
    {
        int HOSI; //Highset Oldest Student Index
        Student student = new Student();
        int NS = 0;
        FileStream[] studInf = new FileStream[300];
        int[] ATC = new int[300];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NS++;
            System.IO.Directory.CreateDirectory("C:\\Students\\");
            string path = "C:\\Students\\" + NameS.Text + ".txt";
            studInf[NS - 1] = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(studInf[NS - 1]);
            if (NameS.Text != "")
            {
                student.NameSt = NameS.Text;
                writer.WriteLine(System.Convert.ToString(student.NameSt));
            }
            else
            {
                MessageBox.Show("Please, write name of student.", "error");
                
            }
            if (Gender.Text == "male" || Gender.Text == "female")
            {
                student.Gender = Gender.Text;
                writer.WriteLine(System.Convert.ToString(student.Gender));
            }
            else
            {
                MessageBox.Show("Please, write right gender of student.", "error");
            }
            int n;
            bool isNumber = int.TryParse(YearsOld.Text, out n);
            if (isNumber && YearsOld.Text != "")
            {
                student.YearsOld = Convert.ToInt32(YearsOld.Text);
                ATC[NS - 1] = student.YearsOld;
                writer.WriteLine(System.Convert.ToString(student.YearsOld));
            }
            else
            {
                MessageBox.Show("Please, write how old is student.", "error");
            }
            student.Group = Group.Text;
            if (Group.Text == "A1" || Group.Text == "A2" || Group.Text == "A3" || Group.Text == "B1" || Group.Text == "B2" || Group.Text == "B3" || Group.Text == "C1" || Group.Text == "C2" || Group.Text == "C3")
            {
                writer.WriteLine(System.Convert.ToString(student.Group));
            }
            else
            {
                MessageBox.Show("Please, write at what group is student.", "error");
            }
            writer.Close();
            
            if (ATC != null)
            {
                int max = ATC.Max();
                int index = -1;
                for (int i = 0; i < ATC.Length; i++)
                {
                    if (ATC[i] == max)
                    {
                        HOSI = i;
                    }
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowStudent(student.NameSt, student.Gender, student.YearsOld, student.Group, HOSI);
        }

        private void ShowStudent(string name, string gender, int yearsOld, string group, int i)
        {
            StreamReader reader = new StreamReader(studInf[i]);
            name = reader.ReadLine();
            gender = reader.ReadLine();
            yearsOld = Int32.Parse(reader.ReadLine());
            group = reader.ReadLine();
            NameS.Text = name;
            Gender.Text = gender;
            YearsOld.Text = yearsOld + "";
            Group.Text = group;
            reader.Close();
            studInf[i].Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", "C:\\Students\\");
        }
    }
}

