using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos點餐
{
    internal class EventHandlers
    {
        public static event EventHandler<(FlowLayoutPanel, string)> panelHandler; 

        public static void Notify(FlowLayoutPanel panel, string sum)
        {
            panelHandler.Invoke(null, (panel, sum));
        }
    }
}
