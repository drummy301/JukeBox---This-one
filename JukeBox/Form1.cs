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

namespace JukeBox
{
    public partial class JukeBoxForm : Form
    {
        string applicationPath = Directory.GetCurrentDirectory() + "\\";    //using this variables means we can use the same directory when creating all files... this variable will not change.
        string[,] genreArray = new String[50, 50];   // Array to contain genre  and their songs [x,y] x = 0 Genre name x = 1,2,3,4... Songs within that genre. y is used to add new genres and their songs.

        public JukeBoxForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForm SetupForm = new SetupForm();
            SetupForm.Show();

        }

        private void GenreListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void JukeBoxForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists(applicationPath + "configuration.txt"))
            {
                StreamWriter createfile = File.CreateText(applicationPath + "configuration.txt");   // Creates text file in the current directory; called 'configuration' i it doesnt already exist
                createfile.Close();
            }

            fileToArray();
        }



        private void fileToArray()
        {
            StreamReader readfile = File.OpenText(applicationPath + "configuration.txt"); //open file

            string lineOfText;            lineOfText = readfile.ReadLine(); //decalare to use with while loop

            string numberOfSongs;   //will contain number of songs within a genre -- this was to help format data for read/write

            while (lineOfText != null)
            {
                int genrenumber;    //used to assign values to array and format the array
                genrenumber = 0;

                numberOfSongs = lineOfText; //Used to create loop for reading songs from the file

                lineOfText = readfile.ReadLine();
                genreArray[0,genrenumber] = lineOfText; //Adds the genre name to the Array
                int count = 1;

                while (count <= Convert.ToInt16(numberOfSongs)) //loop to add songs
                {
                    lineOfText = readfile.ReadLine();
                    genreArray[count, genrenumber] = lineOfText; // add song name to array
                }

                lineOfText = readfile.ReadLine();

            }

            readfile.Close();

        }
    }
}
