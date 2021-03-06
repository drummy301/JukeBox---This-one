﻿using System;
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
        public string[] importedTracks = new String[31];
        public string mediaLocation = Directory.GetCurrentDirectory() + "/media/";


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

            StreamWriter overwrite = new StreamWriter(applicationPath + "configuration.txt"); // overwrite file with new configurations
            overwrite.Close();

            StreamWriter stream = new StreamWriter(applicationPath + "configuration.txt", true);

            string check = "";
            int count = 0;  //measure genre

             while (check != null)
            {
                int loops = Convert.ToInt16(genreArray[1, count]);

                stream.WriteLine(genreArray[1, count]); //writes number of songs in genre
                stream.WriteLine(genreArray[0, count]); //writes title of genre
                
                for (int i = 2; i < loops +2 ;) // i measures the song
                {
                    stream.WriteLine(genreArray[i, count]); //writes songs
                    i++;
                }

                count++;
                check = genreArray[0, count];
               
            }
            stream.Close();

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

                while (genreArray[Count + 2, genreNum + 1]!= null || genreArray[Count + 2, genreNum] != null) //checks to see if both genres are emptt
                {
                    genreArray[Count + 2, genreNum] = genreArray[Count + 2, genreNum + 1]; // switches the song from next element to current element
                    genreArray[Count + 2, genreNum+1] = null;
                    
                    Count++;
                }
                genreNum++;
                check = genreArray[0, genreNum + 1]; // checks the next genre -- looking for the end of the genre
            }

            int numberOfSongs = Convert.ToInt16(genreArray[1, genreselected]);//number of songs in the genre

            GenresLoad(0); //reloads first genre into listbox
            
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
       
            //select genre to the left of this one
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

            string SelectedTrack = Convert.ToString(importListBox.SelectedItem);
            int count = 1;
            string check = "";

            while (check != null)
                {
                count++;
                check = genreArray[count, genreselected];
                
                }

            string result = Path.GetFileName(SelectedTrack); //converts into just filename

            int value = Convert.ToInt16(genreArray[1, genreselected]);      //adds value to genres song total
            value++;
            genreArray[1, genreselected] = Convert.ToString(value);

            genreArray[count, genreselected] = result;  //adds song name to genre

            System.IO.File.Copy(SelectedTrack, mediaLocation+result, true); //copys file into media file

            trackListBox.Items.Add(result);

        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            //move track from directory to media directory and add to genre selected
            //copy track from directory to media directory and add to genre selected

            string SelectedTrack = Convert.ToString(importListBox.SelectedItem);
            int count = 1;
            string check = "";

            while (check != null)
            {
                count++;
                check = genreArray[count, genreselected];

            }

            string result = Path.GetFileName(SelectedTrack); //converts into just filename

            int value = Convert.ToInt16(genreArray[1, genreselected]);      //adds value to genres song total
            value++;
            genreArray[1, genreselected] = Convert.ToString(value);

            genreArray[count, genreselected] = result;  //adds song name to genre

            System.IO.File.Move(SelectedTrack, mediaLocation + result); //copys file into media file

            trackListBox.Items.Add(result);
        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            //IMport tracks from directory into list box where paths can be selected and moved into media file if chosen to
       
            importListBox.Items.Clear();

            FolderBrowserDialog importDir = new FolderBrowserDialog();

            if (importDir.ShowDialog() == DialogResult.OK)
            {
                importedTracks = Directory.GetFiles(importDir.SelectedPath);

                int count = 0;
                
               

                while (count < importedTracks.Length)  // Adds the elements to the list -- the elements contain the file path this can be later removed to look more apealing
                {
                    importListBox.Items.Add(importedTracks[count]);
                    count++;
                    

                }
            }
        }

        private void clearImportsBtn_Click(object sender, EventArgs e)
        {
            //clear directory selection/ the track imported
            importListBox.Items.Clear();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //delete track from genre
            string delSelect = Convert.ToString(trackListBox.SelectedItem);

            int value = Convert.ToInt16(genreArray[1, genreselected]);
            value--;
            genreArray[1, genreselected] = Convert.ToString(value);

            int count = 2;
            string check = "";

            while (check != null) 
            {
               check = genreArray[count, genreselected];
                if (check == delSelect)
                {
                    string check2 = "";
                    int count2 = count;
                    while (check2 != null)
                    {
                        genreArray[count2, genreselected] = genreArray[count2 + 1, genreselected];
                        genreArray[count2+ 1, genreselected] = null;

                       
                        count2++;
                        check2 = genreArray[count2 + 1, genreselected];
                    }

                }
                count++;
                check = genreArray[count + 1, genreselected];
            }
            trackListBox.Items.Remove(delSelect);

        }
    }
}
