namespace WinFormsGUIComponentsRPG
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.Load += Main_Load;
        }

        private void UpdateStats()
        {
            // This updates stuff on our gui for us
            //lblStats.Text = "Health: " + playerHealth.ToString() + " | Credits: " + spaceCredits.ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateStats();
        }
    }
}
