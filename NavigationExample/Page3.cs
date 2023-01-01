using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NavigationExample.Navigation;

namespace NavigationExample
{
    public partial class Page3 : UserControl
    {
        private INavigationManger<UserControl, Button> NavManger { set; get; }
        public Page3(INavigationManger<UserControl, Button> navManger)
        {
            InitializeComponent();
            NavManger = navManger;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavManger.CanNavigate = true;
        }
    }
}
