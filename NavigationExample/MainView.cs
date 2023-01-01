using NavigationExample.Navigation;

namespace NavigationExample
{
    public partial class MainView : Form
    {
        public MainView()
        {
            
            InitializeComponent();
            NavManger = new NavigationManger(panel1);
            NavManger.AddPage(new Page1(),button1,"page1");
            NavManger.AddPage(new Page2(),button2,"page2");
            NavManger.AddPage(new Page3(NavManger),null,"page3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavManger.NavigateTo("page1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NavManger.NavigateTo("page2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            NavManger.NavigateTo("page3");
            NavManger.CanNavigate = false;
        }
        public INavigationManger<UserControl,Button> NavManger { get; set; }
    }
}