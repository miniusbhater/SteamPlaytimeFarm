using SteamPlaytimeFarmLauncher.Game;
using System.Diagnostics;
using System.Security.Policy;
namespace SteamPlaytimeFarmLauncher
{
    public partial class Form1 : Form
    {
        private List<SteamPlaytimeFarmLauncher.Game.Game> runningGames = new List<SteamPlaytimeFarmLauncher.Game.Game>();

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            listBoxGames.Font = new Font("Consolas", 10);
            RefreshGameList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = Application.ProductVersion.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int appId))
            {
                MessageBox.Show("Please enter a valid AppID.");
                return;
            }

            if (runningGames.Any(g => g.AppId == appId)) // prevent duplicates
            {
                MessageBox.Show("This AppID is already running.");
                return;
            }

            var process = new Process();
            process.StartInfo.FileName = "libs\\SteamPlaytimeFarm.exe";
            process.StartInfo.Arguments = appId.ToString();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;
            process.Exited += Process_Exited;

            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to start process: " + ex.Message);
                return;
            }

            var game = new Game.Game
            {
                AppId = appId,
                Process = process,
                StartedAt = DateTime.Now
            };

            runningGames.Add(game);
            RefreshGameList();
        }

        private void RefreshGameList() // refresh the game list
        {
            listBoxGames.Items.Clear();
            listBoxGames.Items.Add("AppID     PID       Started");
            listBoxGames.Items.Add("-----     -----     -------");

            foreach (var game in runningGames)
            {
                listBoxGames.Items.Add(game);
            }
        }

        private void Process_Exited(object sender, EventArgs e) // remove game from list when exited
        {
            var process = (Process)sender;
            var game = runningGames.FirstOrDefault(g => g.Process.Id == process.Id);
            if (game != null)
            {
                runningGames.Remove(game);
                Invoke(new Action(RefreshGameList));
            }
        }

        private void button3_Click(object sender, EventArgs e) // stop selected game  
        {
            if (listBoxGames.SelectedItem is Game.Game selectedGame)
            {
                if (!selectedGame.Process.HasExited)
                    selectedGame.Process.Kill();

                runningGames.Remove(selectedGame);
                RefreshGameList();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // kill the processes when SPF is exited
        {
            foreach (var game in runningGames.ToList())
            {
                try
                {
                    if (!game.Process.HasExited)
                    {
                        game.Process.Kill();
                        game.Process.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to kill AppID {game.AppId}: {ex.Message}"); // log error even tho your not normally gonna see it :3
                }
            }

            runningGames.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var psi = new ProcessStartInfo
            {
                FileName = "https://steamdb.info",
                UseShellExecute = true
            };
            Process.Start(psi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var form = new SaveEntries())
            {
                if (form.ShowDialog() == DialogResult.OK && form.SelectedAppId.HasValue)
                {
                    textBox1.Text = form.SelectedAppId.Value.ToString();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
    

