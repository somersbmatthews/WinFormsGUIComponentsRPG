using System.Data;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsGUIComponentsRPG
{
    public partial class statsDisplay : Form
    {
        // player's health
        int playerHealth = 100;

        // player's gold
        int playerGold = 0;

        // A Dictionary to hold the area as a (string) and the number of goblins alive (int) in that area.
        Dictionary<String, int> goblinDict = new Dictionary<String, int>();
        public statsDisplay()
        {
            InitializeComponent();

            // Some WinForms settings to help keep the components where I put them in Design.
            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private async void UpdateStats()
        {
            // This updates stuff on our gui for us

            //await Task.Run(() =>
            //{
            //    Invoke(() =>
            //    {
            //        // This updates stuff on our gui for us
            //        statsLabel.Text = "Health: " + playerHealth.ToString() + " | Gold: " + playerGold.ToString();
            //    });

            //});
            statsLabel.Text = "Health: " + playerHealth.ToString() + " | Gold: " + playerGold.ToString();
            if (playerHealth >= 0)
            {
                // The progress bar was looking weird so I tried this update thread istead of UI thread method, which worked out well.
                await Task.Run(() =>
                {
                    Invoke(() =>
                    {
                        // sets the progress bar value equal to the player health
                        progressBar.Value = playerHealth;              
                    });

                });
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            UpdateStats();

            // Now let's set the first location of our dropdown locations
            comboLocations.Items.Add("Dark Wood");
            goblinDict.Add("Dark Wood", 7);

            // Let's add another location our user can go to
            comboLocations.Items.Add("Dead Tree");
            goblinDict.Add("Dead Tree", 7);

            // Now let's make our combobox select a default location so it is not empty
            comboLocations.SelectedIndex = 0;

            // Now let's let our user know what is going on in the SIM
            lblStory.Text = "Welcome to the Scary Dark Forest, where Forest Goblins have been sighted crawling about.";

            statsLabel.Width = 300;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Let's use a random number gen to simulate a dice roll in RPG
            Random chance = new Random();

            // Let's generate a number between 1 and 10
            int eventRoll = chance.Next(1, 11);

            //MessageBox.Show(comboLocations.SelectedItem.ToString() + " " + goblinDict[comboLocations.SelectedItem.ToString()].ToString());

            // now let's check if our random number is greater than 4 and if there are any goblins in the area.
            if (eventRoll > 4 && goblinDict[comboLocations.SelectedItem.ToString()] >= 1)
            {
                // Display's message to the user in the Story label
                lblStory.Text = "You struck and killed a Forest Goblin. You take his 20 gold coins.";

                // Adds gold to the players gold
                playerGold = playerGold + 20;

                // Sets image as player striking a goblin to the display panel
                displayPanel.BackgroundImage = Properties.Resources.StrikingForestGoblin;
                // Makes sure the image is set to stretch
                displayPanel.BackgroundImageLayout = ImageLayout.Stretch;

                // Reduces goblins in this area by one
                goblinDict[comboLocations.SelectedItem.ToString()]--;

                // Initializes bool if all goblins in this area are killed
                bool allGoblinsKilled = true;

                // for loop to check if all goblins in all the areas are dead.
                foreach (int value in goblinDict.Values)
                {
                    if (value > 0)
                    {
                        allGoblinsKilled = false;
                        break;
                    }
                }

                UpdateStats();
                if (allGoblinsKilled)
                {
                    lblStory.Text = "You have killed all the Forest Goblins in all the areas in the entire forest and have won the game.";

                    MessageBox.Show("You have killed all the Forest Goblins in all the areas in the entire forest and have won the game.");

                    // Close the app
                    Application.Exit();

                }
                // checks to see if all goblins are killed in only the area the player is in.
                else if (goblinDict[comboLocations.SelectedItem.ToString()] < 1)
                {
                    lblStory.Text = "You have killed all Forest Goblins in this area. Please select another area to kill the rest.";
         
                }
            }
            // checks if our random number is less than or equal to 4 and if there are any goblins in the area.
            else if (eventRoll <= 4 && goblinDict[comboLocations.SelectedItem.ToString()] >= 1)
            {
                // something negative happens to our user
                lblStory.Text = "A Forest Goblin struck you. You lose 15 health.";
                // Now it costs our user some of their health
                playerHealth = playerHealth - 15;

                // Sets image as player striking a goblin to the display panel
                displayPanel.BackgroundImage = Properties.Resources.GoblinStrikingPlayer;
                // Makes sure the image is set to stretch
                displayPanel.BackgroundImageLayout = ImageLayout.Stretch;

                // refresh the display of our user
                UpdateStats();
                

                if (playerHealth <= 0)
                {
                    // Show a messagebox if our player has expired.
                    MessageBox.Show("Your adventure is over because you have died.");

                    // Close the app
                    Application.Exit();
                }
            }
        }

        private void comboLocations_SelectedIndexChanged(object sender, EventArgs e)
        {   
            // Let's check and see what value is now selected
            if (comboLocations.SelectedItem.ToString() == "Dark Wood")
            {
                // So let's change the background image to the user's newly selected location
                this.BackgroundImage = Properties.Resources.DarkWood;

                // Update our story so the user knows what is going on
                lblStory.Text = "You are now at the infamous and scary Dark Wood.";
            }
            else if (comboLocations.SelectedItem.ToString() == "Dead Tree")
            {
                // So let's change the background image to the user's newly selected location
                this.BackgroundImage = Properties.Resources.DeadTree;

                // Update our story so the user knows what is going on
                lblStory.Text = "You are now at the mysterious and mystical Dead Tree.";

            }
        }
    }
}
