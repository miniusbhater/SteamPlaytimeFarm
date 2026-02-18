using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SteamPlaytimeFarmLauncher.Game;

namespace SteamPlaytimeFarmLauncher.Game
{
    public partial class SaveEntries : Form
    {
        private string filePath = "saved.txt";
        private List<LaunchItem> savedItems;

        public int? SelectedAppId { get; private set; } = null;
        public SaveEntries()
        {
            InitializeComponent();
            LoadSavedGames();
            button1.Click += Button1_Click; // don't ask. im a bit of an idiot and was too lazy to correct it properly
            button2.Click += Button2_Click;
            listBox1.DoubleClick += ListBox1_DoubleClick;
        }

        private void SaveEntries_Load(object sender, EventArgs e)
        {

        }

        private void LoadSavedGames()
        {
            savedItems = new List<LaunchItem>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int id))
                    {
                        savedItems.Add(new LaunchItem{Name = parts[0],Id = id});
                    }
                }
            }

            RefreshListBox();
        }

        private void SaveItems() // save the items
        {
            File.WriteAllLines(filePath, savedItems.Select(i => $"{i.Name}|{i.Id}"));
        }

        private void RefreshListBox() // refresh the list so they actually show!!!
        {
            listBox1.Items.Clear();
            foreach (var item in savedItems) listBox1.Items.Add(item);
        }

        private void Button1_Click(object sender, EventArgs e) // add new items
        {
            string name = textBox1.Text.Trim();
            if (!int.TryParse(textBox2.Text.Trim(), out int id) || string.IsNullOrEmpty(name)) // so we dont explode
            {
                MessageBox.Show("Please enter a valid name and AppID.");
                return;
            }
          
            if (savedItems.Any(i => i.Id == id)) // prevent duplicates
            {
                MessageBox.Show("This AppID is already saved.");
                return;
            }

            savedItems.Add(new LaunchItem { Name = name, Id = id });
            SaveItems();
            RefreshListBox();

            textBox1.Clear();
            textBox2.Clear();
        }

        private void Button2_Click(object sender, EventArgs e) // remove items
        {
            if (listBox1.SelectedItem is LaunchItem selected)
            {
                savedItems.Remove(selected);
                SaveItems();
                RefreshListBox();
            }
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e) // select by double clicking
        {
            if (listBox1.SelectedItem is LaunchItem selected)
            {
                SelectedAppId = selected.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }

}

