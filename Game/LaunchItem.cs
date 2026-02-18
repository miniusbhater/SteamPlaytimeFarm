using System;
using System.Collections.Generic;
using System.Text;

namespace SteamPlaytimeFarmLauncher.Game
{
    public class LaunchItem // fuck you, no more comments for you
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Id})";
        }
    }
}
