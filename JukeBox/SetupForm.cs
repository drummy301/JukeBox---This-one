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
    public partial class SetupForm : Form  
    {
        //PUBLIC VARS///////////////////////////////////////////////////

        public string applicationPath = Directory.GetCurrentDirectory() + "\\";    //using this variables means we can use the same directory when creating all files... this variable will not change.
        public string[,] genreArray = new String[50, 50];   // Array to contain genre  and their songs [x,y] x = 0 Genre name x = 1,2,3,4... Songs within that genre. y is used to add new genres and their songs.
        public int totalgenrenumber = 0; //total number of genres

        //VARS///////////////////////////////////////////////////

        int genreselected = 0;
        int totalgenre;

        JukeBoxForm JukeBox = new JukeBoxForm(); // required so that public variable from jukeboxform can be used

        public SetupForm()
        {
            InitializeComponent();
        }

        //METHODS/////////////////////////////////////////////////// - I had to create the methods again - I couldnt figure out how to use the methods from the previous form and decided to just create the GenreArray and Methods again

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
        public void GenresLoad(int genre)
        {
            //adds genres and their songs to the tracklistbox box

            trackListBox.Items.Clear(); //clears any old songs

            GenreTitleTxtBox.Text = genreArray[0, genre]; // adds genre title to title text box for the corresponding genre

            int count = 2; // counter starts at 2 becuse thats where the first song is stored within the array
            int numberOfSongs = Convert.ToInt16(genreArray[1, genre]); // decalres variable with the number of songs geld within the genre


            while (count <= numberOfSongs + 1) //loop to add songs to the genrearray loop as many times as there are songs
            {
                trackListBox.Items.Add(genreArray[count, genre]); //adds the song from the array into the listbox
                count++;
            }

        }
        //FORM SHOWN///////////////////////////////////////////////////

        private void SetupForm_Shown(object sender, EventArgs e)
        {

            FileToArray();

            totalgenre = 0;

            string checker = "";
            int count = -1;

            while(checker != null)
            {
                count++;
                checker = genreArray[0, count];
            }
            totalgenre = count;

            //Loads genres and their songs into the the tracklist
            GenresLoad(0);
            leftGenreSelectorBtn.Enabled = false;

        }
      
        //EVENTS///////////////////////////////////////////////////


        private void okBtn_Click(object sender, EventArgs e)
        {
            //Need to add data to file and load onto the array
            

            // need to write changes to file
             
           
            
            this.Close();
        }

        private void rightGenreSelectorBtn_Click(object sender, EventArgs e)
        {
            leftGenreSelectorBtn.Enabled = true;
            rightGenreSelectorBtn.Enabled = false; // dont let the user use this again until verified that there is another genre to select
                                                       
            //select genre to the right of this one
            if (genreselected < totalgenre-1) //checks wether theres a genre to the right
            {
                genreselected++; // inc genre selected to next genre
                GenresLoad(genreselected); // loads according genre

                if (genreselected != totalgenre)  // this will mean that when you get to the last genre the user can tell because the selector will be shadowed
                {
                    rightGenreSelectorBtn.Enabled = true; //enable the button to be clicked again as there is another 
                }
            }
        }

        private void deleteGenreBtn_Click(object sender, EventArgs e)
        {
            //delete a genre and its songs
        }

        private void importListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //Close without saving
            this.Close();
        }

        private void leftGenreSelectorBtn_Click(object sender, EventArgs e)
        {
            //chose genre to the left
            rightGenreSelectorBtn.Enabled = true; // resets opposing button
            leftGenreSelectorBtn.Enabled = false; // dont let the user use this again until verified that there is another genre to select

            //select genre to the right of this one
            if (genreselected > 0)
            {
                genreselected--; // inc genre selected to next genre
                GenresLoad(genreselected);

                if (genreselected != 0)  // this will mean that when you get to the last genre the user can tell because the selector will be shadowed
                {
                    leftGenreSelectorBtn.Enabled = true;
                }
                
            }
        }

        private void addGenreBtn_Click(object sender, EventArgs e)
        {
            //add new genre
        }

        private void copyBtn_Click(object sender, EventArgs e)
        {
            //copy track from directory to media directory and add to genre selected
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            //move track from directory to media directory and add to genre selected
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            //import tracks from selected directory

        }

        private void clearImportsBtn_Click(object sender, EventArgs e)
        {
            //clear directory selection/ the track imported
        }

        
    }
}
