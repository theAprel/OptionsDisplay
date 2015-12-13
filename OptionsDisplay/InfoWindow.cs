using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsDisplay
{
    interface InfoWindow
    {
        void ClearAll();
        void MoveToHistory();
        void SetWindowText(String text);
        void AppendWindowText(String text);
    }
}
