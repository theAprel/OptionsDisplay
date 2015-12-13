using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;

namespace OptionsDisplay
{
    public class TagPrinter
    {
        private static InfoWindow window;
        private static bool disableLogParsing = false;

        public static void Load()
        {
            window = new HearthWindow();
            Hearthstone_Deck_Tracker.API.LogEvents.OnPowerLogLine.Add(ProcessPowerLogLine);
            Hearthstone_Deck_Tracker.API.GameEvents.OnTurnStart.Add(PrepareForStartOfTurn);
            Hearthstone_Deck_Tracker.API.GameEvents.OnGameStart.Add(window.ClearAll);
        }

        public static void PrepareForStartOfTurn(ActivePlayer ap)
        {
            window.MoveToHistory();
            if (ap == ActivePlayer.Player)
            {
                disableLogParsing = true;
            }
            else
            {
                disableLogParsing = false;
            }
        }

        public static void ProcessPowerLogLine(String line)
        {
            if (disableLogParsing) return;
            if(line.Contains("tag=NUM_OPTIONS "))
            {
                String entity = GetValueInLogEntry(line, "Entity");
                String value = GetValueInLogEntry(line, "value");
                window.AppendWindowText(entity + " has " + value + " options.");
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
