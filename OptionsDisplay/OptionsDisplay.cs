using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsDisplay
{
    public class TagPrinter
    {
        private static LogWindow window;

        public static void Load()
        {
            window = new LogWindow();
            window.Show();
            Hearthstone_Deck_Tracker.API.LogEvents.OnPowerLogLine.Add(processPowerLogLine);
        }

        public static void processPowerLogLine(String line)
        {
            if(line.Contains("tag=NUM_OPTIONS "))
            {
                String entity = line.Split("Entity=".ToCharArray())[1].Split(" ".ToCharArray())[0];
                String value = line.Split("Value=".ToCharArray())[1];
                window.SetWindowText(entity + " has " + value + " options.");
            }
        }
    }
}
