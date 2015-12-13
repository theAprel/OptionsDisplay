using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;

namespace OptionsDisplay
{
    /// <summary>
    /// Interaction logic for LogWindow.xaml
    /// </summary>
    public partial class LogWindow
    {
        public LogWindow()
        {
            InitializeComponent();
        }

        public void ClearAll()
        {
            historyLabel.Content = "";
            logLabel.Content = "";
        }

        public void MoveToHistory()
        {
            historyLabel.Content = logLabel.Content;
            logLabel.Content = "";
        }

        public void SetWindowText(String text)
        {
            logLabel.Content = text;
        }

        public void AppendWindowText(String text)
        {
            logLabel.Content = (String.IsNullOrEmpty(logLabel.Content.ToString()) ? "" : " " ) + logLabel.Content.ToString() + text;
        }
    }
}
