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

        public HearthWindow()
        {
            info = new HearthstoneTextBlock();
            info.Text = "";
            info.FontSize = 12;
            var canvas = Hearthstone_Deck_Tracker.API.Core.OverlayCanvas;
            var fromTop = canvas.Height / 2;
            var fromLeft = canvas.Width / 2;
            Canvas.SetTop(info, fromTop);
            Canvas.SetLeft(info, fromLeft);
            canvas.Children.Add(info);
        }

        public void AppendWindowText(string text)
        {
            info.Text = info.Text + text;
        }

        public void ClearAll()
        {
            info.Text = "";
        }

        public void MoveToHistory()
        {
            info.Text = "";
        }

        public void SetWindowText(string text)
        {
            info.Text = text;
        }
    }
}
