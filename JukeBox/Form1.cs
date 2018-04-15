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
        string[] playlist = new String[15]; //playlist of songs max 16 songs
        int genrenumber = 0; //total number of genres

        bool currentlyplayingBoolean = false;
        string currentlyplayingString;


        public JukeBoxForm()
        {
            InitializeComponent();
        }

      

        

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForm SetupForm = new SetupForm(); //shows the setup orm
            SetupForm.Show();

        }

      

        

        private void JukeBoxForm_Load(object sender, EventArgs e)
        {


            if (! File.Exists(applicationPath + "configuration.txt"))
            {
                StreamWriter createfile = File.CreateText(applicationPath + "configuration.txt");   // Creates text file in the current directory; called 'configuration' i it doesnt already exist
                createfile.Close();
            }

            FileToArray();
            GenresLoad(0);
            
        }

        private void GenresLoad(int genre)
        {
            GenreListBox.Items.Clear();
        
            GenreTitleTxtBox.Text = genreArray[0, genre];

            int count = 2;
            int numberOfSongs = Convert.ToInt16(genreArray[1, genre]);


            while (count <= numberOfSongs + 1) //loop to add songs to the genrearray
            {
                GenreListBox.Items.Add(genreArray[count, genre]);
                count++;
            }
        }


        private void FileToArray()
        {
            StreamReader readfile = File.OpenText(applicationPath + "configuration.txt"); //open file

            string lineOfText;
            lineOfText = readfile.ReadLine(); //used to initilise and exit loop

            int numberOfSongs;   //will contain number of songs within a genre -- this was to help format data for read/write

            while (lineOfText != null)
            {
                

                numberOfSongs = Convert.ToInt16(lineOfText); //Used to create loop for reading songs from the file

                lineOfText = readfile.ReadLine();
                genreArray[0,genrenumber] = lineOfText; //Adds the genre name to the genreArray
                genreArray[1, genrenumber] = Convert.ToString(numberOfSongs);
                int count = 2;

                while (count <= numberOfSongs+1) //loop to add songs to the genrearray
                {
                    lineOfText = readfile.ReadLine();
                    genreArray[count, genrenumber] = lineOfText;
                    count++ ;
                 
                }

                lineOfText = readfile.ReadLine();
                genrenumber++;
            }

            readfile.Close(); //need to close file

        }

        private void GenreListBox_DoubleClick(object sender, EventArgs e)
        {
            string SelectedSong;    //stores the user's selected song
            SelectedSong = Convert.ToString(GenreListBox.SelectedItem);

            string checker;     //used to initiate the loop and end the loop --
            checker = "";

            int count;  //counter keep track of position in the playlist
            count = 0;


            while (checker != null) //cycle through the playlist and adds the selected song to the end 
            {
                checker = playlist[count]; //when null element is found exit loop and then add seleceted song to playlist
                count = count + 1;
            }

            playlist[count - 1] = SelectedSong; //add selected song to the playlist
            PlayListBox.Items.Add(SelectedSong);

           Nextsong();

            

        }

        private void Nextsong()
        {
            if(currentlyplayingBoolean == false)
            {
                currentlyplayingString = playlist[0];
                currentlyplayingBoolean  = true; //sets the boolean to true to inform the system that a song i currently being played
                PresentlyPlayTxtBox.Text = currentlyplayingString; //Adds the song first on the paylist to currently playing textbox and var

                PlayListBox.Items.RemoveAt(0);

                // Now to remove the first item on the playlist and shift the elements up in the array

                int count = 0;      //used to count
                string check = "" ; //can be used to terminate loop when theres no more elements to shift up

                while(check != null)    //loop until we come accross a null element in the next cell
                {
                    playlist[count] = playlist[count + 1]; //copies the cell beneath
                    playlist[count + 1] = null; //clears the cell beneath

                    count++;    //increment count
                    check = playlist[count + 1];    //change checker to next element in the list
                }
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
          if (currentlyplayingBoolean == true)  //used for testing 
            {
                currentlyplayingBoolean = false;
                
            
            }
          else
            {
                currentlyplayingBoolean = true;
            }
        }

        

        private void GenreSelecHScroll_ValueChanged(object sender, EventArgs e)
        { 
        
            GenresLoad(GenreSelecHScroll.Value);
        }
    }
}
