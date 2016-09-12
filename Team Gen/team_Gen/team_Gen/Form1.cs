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

namespace team_Gen
{
    public partial class Form1 : Form
    {
        Class createClass = new Class();
        public List<string> players = new List<string>();
        public List<string> Tempplayers = new List<string>();

        public Random rnd = new Random();
        public bool teams = true;
        public Form1()
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Test();
            InitializeComponent();
        }

        private void Test()
        {
            //MyListView team1 = new MyListView();

            //team1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //team1.Location = new System.Drawing.Point(257, 170);
            //team1.Name = "listViewTeam2";
            //team1.Size = new System.Drawing.Size(250, 240);
            //team1.TabIndex = 6;
            //team1.UseCompatibleStateImageBehavior = false;
            //team1.View = System.Windows.Forms.View.List;

            //this.Controls.Add(team1);
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string player = textBox1.Text;
            Tempplayers.Add(player);
            listViewPlayers.Items.Add(player);
            textBox1.Clear();
            //listViewPlayers(comboBoxClass.SelectedItem);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //createClassList();
            //making listview cols
            listViewPlayers.Columns.Add("GamerTag", 90);
            listViewPlayers.Columns.Add("Class", 90);
            listViewTeam1.Columns.Add("GamerTag", 90);
            listViewTeam1.Columns.Add("SubClass", 90);
            listViewTeam2.Columns.Add("GamerTag", 90);
            listViewTeam2.Columns.Add("SubClass", 90);
            //end of listview cols
            //textbox starting text
            textBox1.Text = "Enter Gamertag";

        }

        private void createClassList()
        {
            //List<string> tempClass = createClass.createClassList();
           // List<string> tempsubClass = createClass.createSubClassList();
        }

        public void sortTeams()
        {
            while(players.Count != 0)
            {
                if (teams == true)
                {
                    int player = rnd.Next(players.Count);
                    listViewTeam1.Items.Add(players[player]);
                    players.RemoveAt(player);
                    teams = false;
                }
                else
                {
                    int player = rnd.Next(players.Count);
                    listViewTeam2.Items.Add(players[player]);
                    players.RemoveAt(player);
                    teams = true;
                }

            }


        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            foreach(string player in Tempplayers)
            {
                players.Add(player);
            }
            listViewTeam1.Clear();
            listViewTeam2.Clear();
            sortTeams();
            sortSubClass();
            
        }

        private void sortSubClass()
        {
            if(comboBoxClass.Text == "Titan")
            {

            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem player in listViewPlayers.CheckedItems)
            {
                string item = player.Text;
                listViewPlayers.Items.Remove(player);
                Tempplayers.Remove(item);

            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            DialogResult result = openfile.ShowDialog();
            openfile.Filter = "TXT files|*.txt";
            if(result == DialogResult.OK)
            {
                string file = openfile.FileName;
                try
                {
                    StreamReader reader = new StreamReader(openfile.FileName);
                    while(!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        listViewPlayers.Items.Add(line);
                        Tempplayers.Add(line);
                    }
                }
                catch
                {

                }
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            listViewPlayers.Clear();
            Tempplayers.Clear();
        }
    }
}
