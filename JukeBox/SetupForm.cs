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
using Microsoft.VisualBasic;


namespace JukeBox
{
    public partial class SetupForm : Form  
    {
        //PUBLIC VARS///////////////////////////////////////////////////

        public string applicationPath = Directory.GetCurrentDirectory() + "\\";    //using this variables means we can use the same directory when creating all files... this variable will not change.
        public string[,] genreArray = new String[50, 50];   // Array to contain genre  and their songs [x,y] x = 0 Genre name x = 1,2,3,4... Songs within that genre. y is used to add new genres and their songs.
        public int genreselected = 0;
        public int totalgenre = 0; //total number of genres

        //VARS///////////////////////////////////////////////////

       
       

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
        public void CountGenres() 
        {
            //// count genres total number of genres is required in other methods and required when new genres are added

            totalgenre = -1;  //resets the count so that the genres can be counted again

            string checker = genreArray[0, totalgenre+1];
            

            while (checker != null)
            {
                totalgenre++;
                checker = genreArray[0, totalgenre];
            }
            
        }

        //FORM SHOWN///////////////////////////////////////////////////

        private void SetupForm_Shown(object sender, EventArgs e)
        {

            FileToArray();

            CountGenres(); 

            //Loads genres and their songs into the the tracklist
            GenresLoad(0);
            

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
            //select genre to the right of this one
            if (genreselected <= totalgenre-1) //checks wether theres a genre to the right
            {
                genreselected++; // inc genre selected to next genre
                GenresLoad(genreselected); // loads according genre
            }
        }

        private void deleteGenreBtn_Click(object sender, EventArgs e)
        {
            //delete a genre and its songs
            int genreNum = genreselected;

            string check = genreArray[0, genreNum]; //check = genre title; first element within a genre

            while (check != null) //loop stops when we reach the end o the genres
            {
                int numOfSongs = Convert.ToInt16(genreArray[1, genreNum]); // number of songs within this genre

                int Count = 0; //used to count number of songs

                genreArray[0, genreNum] = genreArray[0, genreNum + 1];  //Switches the next genre to the current genre - shifting genres to the left 
                genreArray[1, genreNum] = genreArray[1, genreNum + 1];

                genreArray[0, genreNum+1] = null;   // Sets the next genre title to null
                genreArray[1, genreNum+1] = null;  // sets the next genre song count to null

                while (genreArray[Count + 2, genreNum + 1]!= null || genreArray[Count + 2, genreNum] != null)
                {
                   genreArray[Count + 2, genreNum] = genreArray[Count + 2, genreNum + 1];
                    genreArray[Count + 2, genreNum+1] = null;
                    
                    Count++;
                }

                check = genreArray[0, genreNum + 1];
            }

            int numberOfSongs = Convert.ToInt16(genreArray[1, genreselected]);//number of songs in the genre
            
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
            

            //select genre to the right of this one
            if (genreselected > 0)
            {
                genreselected--; // inc genre selected to next genre
                GenresLoad(genreselected);
                
            }
        }

        private void addGenreBtn_Click(object sender, EventArgs e)
        {
            //add new genre
            string newGenre = Interaction.InputBox("Add your new genre here:", "Add Genre", "");

            CountGenres();

            genreArray[0, totalgenre] = newGenre;
            genreArray[1, totalgenre] = "0";
            genreselected = totalgenre;
            GenresLoad(totalgenre);

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
