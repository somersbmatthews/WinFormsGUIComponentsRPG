using System.Data;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsGUIComponentsRPG
{
    public partial class statsDisplay : Form
    {
        // Players health
        int playerHealth = 100;

        int playerGold = 0;

        Dictionary<String, int> goblinDict = new Dictionary<String, int>();
        public statsDisplay()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private async void UpdateStats()
        {
            // This updates stuff on our gui for us
            statsLabel.Text = "Health: " + playerHealth.ToString() + " | Gold: " + playerGold.ToString();

            if (playerHealth >= 0)
            {
                await Task.Run(() =>
                {
                    Invoke(() =>
                    {
                        progressBar.Value = playerHealth;
                        if (playerHealth <= 70)
                        {
                            progressBar.ForeColor = Color.Yellow;
                        } else if (playerHealth <= 30)
                        {
                            progressBar.ForeColor = Color.Red;
                        }
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

            // now let check if our random number
            if (eventRoll > 4 && goblinDict[comboLocations.SelectedItem.ToString()] >= 1)
            {
                lblStory.Text = "You struck and killed a Forest Goblin. You take his 20 gold coins.";

                playerGold = playerGold + 20;

                displayPanel.BackgroundImage = Properties.Resources.StrikingForestGoblin;
                displayPanel.BackgroundImageLayout = ImageLayout.Stretch;

                goblinDict[comboLocations.SelectedItem.ToString()]--;

                bool allGoblinsKilled = true;

                foreach (int value in goblinDict.Values)
                {
                    if (value != 0)
                    {
                        allGoblinsKilled = false;
                        break;
                    }
                }
                if (allGoblinsKilled)
                {
                    lblStory.Text = "You have killed all Forest Goblins in all the areas in the entire forest and have won the game.";

                    MessageBox.Show("You have killed all the Forest Goblins in all the areas in the entire forest and have won the game.");

                    // Close the app
                    Application.Exit();

                }
                else if (goblinDict[comboLocations.SelectedItem.ToString()] < 1)
                {
                    lblStory.Text = "You have killed all Forest Goblins in this area. Please select another area to kill the rest.";
         
                }
            }
            else if (eventRoll <= 4 && goblinDict[comboLocations.SelectedItem.ToString()] >= 1)
            {
                // something negative happens to our user
                lblStory.Text = "A Forest Goblin struck you. You lose 15 health.";
                // Now it costs our user some of their health
                playerHealth = playerHealth - 15;

                displayPanel.BackgroundImage = Properties.Resources.GoblinStrikingPlayer;
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
            // set or reset number of enemyGoblins
            
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
