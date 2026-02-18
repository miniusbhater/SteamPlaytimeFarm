using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SteamPlaytimeFarmLauncher.Game
{
    internal class Game
    {
        public int AppId { get; set; }             // appID
        public Process Process { get; set; }       // process running the "game"
        public DateTime StartedAt { get; set; }    // start time

        public override string ToString()
        {
            return $"{AppId,-10}{Process.Id,-10}{StartedAt:HH:mm:ss}";
        }
    }
}
