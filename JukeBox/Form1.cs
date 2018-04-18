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
        //PUBLIC VARS///////////////////////////////////////////////////

        public string applicationPath = Directory.GetCurrentDirectory() + "\\";    //using this variables means we can use the same directory when creating all files... this variable will not change.
        public string[,] genreArray = new String[50, 50];   // Array to contain genre  and their songs [x,y] x = 0 Genre name x = 1,2,3,4... Songs within that genre. y is used to add new genres and their songs.
        public int totalgenrenumber = 0; //total number of genres

        //VARS///////////////////////////////////////////////////

        string[] playlist = new String[15]; //playlist of songs max 16 songs
        bool currentlyplayingBoolean = false;
        string currentlyplayingString;


        public JukeBoxForm()
        {
            InitializeComponent();
        }

        //METHODS///////////////////////////////////////////////////

        public void GenresLoad(int genre)
        {
            FileToArray(); // loads new array
            //adds genres and their songs to the genrelist box

            GenreListBox.Items.Clear(); //clears any old songs

            GenreTitleTxtBox.Text = genreArray[0, genre]; // adds genre title to title text box for the corresponding genre

            int count = 2; // counter starts at 2 becuse thats where the first song is stored within the array
            int numberOfSongs = Convert.ToInt16(genreArray[1, genre]); // decalres variable with the number of songs geld within the genre


            while (count <= numberOfSongs + 1) //loop to add songs to the genrearray loop as many times as there are songs
            {
                GenreListBox.Items.Add(genreArray[count, genre]); //adds the song from the array into the listbox
                count++;
            }
        }
        public void FileToArray()
        {
            //reads file into array used on load and when new songs are added 

            StreamReader readfile = File.OpenText(applicationPath + "configuration.txt"); //open file

            string lineOfText;
            lineOfText = readfile.ReadLine(); //used to initilise and exit loop

            int numberOfSongs;   //will contain number of songs within a genre -- this was to help format data for read/write
            int genrenumber = 0;

            while (lineOfText != null)
            {


                numberOfSongs = Convert.ToInt16(lineOfText); //Used to create loop for reading songs from the file

                lineOfText = readfile.ReadLine();
                genreArray[0, genrenumber] = lineOfText; //Adds the genre name to the genreArray
                genreArray[1, genrenumber] = Convert.ToString(numberOfSongs);
                int count = 2;

                while (count <= numberOfSongs + 1) //loop to add songs to the genrearray
                {
                    lineOfText = readfile.ReadLine();
                    genreArray[count, genrenumber] = lineOfText;
                    count++;

                }

                lineOfText = readfile.ReadLine();
                genrenumber++;
            }

            readfile.Close(); //need to close file
        }

        private void Nextsong()
        {
            WMPLib.WindowsMediaPlayer wmp = new WMPLib.WindowsMediaPlayer();

            //adds song from playlist to currently playling and creates the new playlist



            if (currentlyplayingBoolean == false)
            {
                currentlyplayingString = playlist[0];
                wmp.URL = applicationPath + "/media/" + currentlyplayingString;
                currentlyplayingBoolean = true; //sets the boolean to true to inform the system that a song i currently being played
                PresentlyPlayTxtBox.Text = currentlyplayingString; //Adds the song first on the paylist to currently playing textbox and var

                PlayListBox.Items.RemoveAt(0); //Removes first item from playlist box

                // Now to remove the first item on the playlist and shift the elements up in the array

                int count = 0;      //used to count
                string check = ""; //can be used to terminate loop when theres no more elements to shift up

                while (check != null)    //loop until we come accross a null element in the next cell
                {
                    playlist[count] = playlist[count + 1]; //copies the cell beneath
                    playlist[count + 1] = null; //clears the cell beneath

                    count++;    //increment count
                    check = playlist[count + 1];    //change checker to next element in the list
                }

            }

        }

        //FORM LOAD///////////////////////////////////////////////////

        private void JukeBoxForm_Load(object sender, EventArgs e)
        {

            if (!File.Exists(applicationPath + "configuration.txt"))
            {
                // Creates text file in the current directory; called 'configuration' if it doesnt already exist
                StreamWriter createfile = File.CreateText(applicationPath + "configuration.txt");
                createfile.Close();
            }

            FileToArray(); // reads the file and formats to an genreArray
            GenresLoad(0); // loads array into genrelist box
        }

        //EVENTS///////////////////////////////////////////////////

        private void setupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // opens up th setup form
            SetupForm SetupForm = new SetupForm(); //shows the setup orm
            SetupForm.Show();
        }

        private void GenreListBox_DoubleClick(object sender, EventArgs e)
        {
            // add song selected to the playlist and add to currently playing if a song is not already currently playing 

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

        private void GenreSelecHScroll_ValueChanged(object sender, EventArgs e)
        {
            //selectinG genres

            GenresLoad(GenreSelecHScroll.Value);
        }

        private void WinMedPlayer_Enter(object sender, EventArgs e)
        {
            currentlyplayingBoolean = false;
            Nextsong();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.Show();
        }
    }
}
