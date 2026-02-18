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
    }
}
