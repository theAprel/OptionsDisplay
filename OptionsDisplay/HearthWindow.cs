using Hearthstone_Deck_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OptionsDisplay
{
    class HearthWindow : InfoWindow
    {

        private HearthstoneTextBlock info;
        private HearthstoneTextBlock history;

        public HearthWindow()
        {
            info = new HearthstoneTextBlock();
            history = new HearthstoneTextBlock();
            foreach (HearthstoneTextBlock htb in new HearthstoneTextBlock[] { info, history }) {
                htb.Text = "";
                htb.FontSize = 12;
            }
            var canvas = Hearthstone_Deck_Tracker.API.Core.OverlayCanvas;
            var fromTop = canvas.Height / 2;
            var fromLeft = canvas.Width / 2;
            Canvas.SetTop(history, fromTop);
            Canvas.SetLeft(history, fromLeft);
            Canvas.SetTop(info, fromTop + 20);
            Canvas.SetLeft(info, fromLeft);
            canvas.Children.Add(info);
            canvas.Children.Add(history);
        }

        public void AppendWindowText(string text)
        {
            info.Text = info.Text + text;
        }

        public void ClearAll()
        {
            info.Text = "";
            history.Text = "";
        }

        public void MoveToHistory()
        {
            history.Text = info.Text;
            info.Text = "";
        }

        public void SetWindowText(string text)
        {
            info.Text = text;
        }
    }
}
