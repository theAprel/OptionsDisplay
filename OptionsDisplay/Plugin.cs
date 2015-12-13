using System;
using System.Windows.Controls;

using Hearthstone_Deck_Tracker.Plugins;
using MahApps.Metro.Controls.Dialogs;

namespace OptionsDisplay
{
    public class Plugin : IPlugin
    {
		public string Author
		{
			get { return "Aprel"; }
		}

		public string ButtonText
		{
			get { return "OptionsDisplay"; }
		}

		public string Description
		{
			get { return "Prints the NUM_OPTIONS tag to overlay."; }
		}

		public MenuItem MenuItem
		{
			get { return null; }
		}

		public string Name
		{
			get { return "OptionsDisplay"; }
		}

		public void OnButtonPress()
		{
		}

		public void OnLoad()
		{
            TagPrinter.Load();
		}

		public void OnUnload()
		{
		}

		public void OnUpdate()
		{
		}

		public Version Version
		{
			get { return new Version(0, 0, 1); }
		}
    }
}
