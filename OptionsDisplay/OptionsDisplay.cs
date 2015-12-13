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
            Hearthstone_Deck_Tracker.API.LogEvents.OnPowerLogLine.Add(ProcessPowerLogLine);
        }

        public static void ProcessPowerLogLine(String line)
        {
            if(line.Contains("tag=NUM_OPTIONS "))
            {
                String entity = GetValueInLogEntry(line, "Entity");
                String value = GetValueInLogEntry(line, "value");
                window.SetWindowText(entity + " has " + value + " options.");
            }
        }

        private static String GetValueInLogEntry(String entry, String key)
        {
            int keyIndex = entry.IndexOf(key);
            String afterEqualsSign = entry.Substring(keyIndex + key.Length + 1); // +1 is the equals sign
            if(!afterEqualsSign.Contains("="))
            {
                return afterEqualsSign; // no more key-value pairs on log line; return this last value
            }
            int nextEquals = afterEqualsSign.IndexOf("=");
            String valueAndNextKey = afterEqualsSign.Substring(0, nextEquals);
            int lastSpaceIndex = valueAndNextKey.LastIndexOf(" ");
            return valueAndNextKey.Substring(0, lastSpaceIndex);
        }
    }
}
