using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsDisplay
{
    public class TagPrinter
    {

        public static void Load()
        {
            LogWindow window = new LogWindow();
            window.Show();
            Hearthstone_Deck_Tracker.API.LogEvents.OnPowerLogLine.Add(window.SetWindowText);
        }
    }
}
