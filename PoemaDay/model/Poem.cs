﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PoemaDay.services;
using SQLite;

namespace PoemaDay.model
{
    public class Poem : INotifyPropertyChanged
    {


        public int id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string author;

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");

            }
        }

        
        public List<string> lines;

        [Ignore]
        public List<string> Lines
        {
            get { return lines; }
            set
            {
                lines = value;
                OnPropertyChanged("Lines");
            }
        }

        public String concatLines;

        public string ConcatLines
        {
            get { return concatLines;  }
            set
            {
                concatLines = value;
                OnPropertyChanged("ConcatLines");
            }
        }

        public string linecount;

        public string LineCount
        {
            get { return linecount; }
            set
            {
                linecount = value;
                OnPropertyChanged("LineCount");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {


            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static async Task<Poem> GetPoem()
        {
            Poem poem = await PoemAPI.GetPoemAsync();
            string lines = "";
            foreach (string pline in poem.lines)
            {
                lines += pline + "\n";
            }
            poem.ConcatLines = lines;
            return poem; 
        }

        public static bool SavePoem(Poem poem)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var rows = 0;
                if (poem != null)
                {
                    conn.CreateTable<Poem>();
                    rows = conn.Insert(poem);
                }
                else
                {
                    //DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
                    return false;
                }

                if (rows > 0)
                {
                    //DisplayAlert("Success", "Poem saved: \n " + poem.concatLines.ToString(), "OK");
                    return true;
                }
                else
                {
                    //DisplayAlert("Something Went Wrong", "Poem not saved", "OK");
                    return false;
                }
            }
        }
    }

    public class Line
    {
        public string PoemLine { get; set; }
    }

}
