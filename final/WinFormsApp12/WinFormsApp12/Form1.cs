using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TextAdventureGame
{
    public partial class Form1 : Form
    {
        private int health = 100;
        private string location = "Forest";
        private string description = "You find yourself in a dense forest. Trees surround you, a path leads deeper into the woods.";
        private List<string> inventory = new List<string>();

        private enum GameState
        {
            Introduction,
            Forest,
            River,
            Cave,
            CaveAdditional,
            Mountain,
            End,
            MountainTurnBack
        }

        private GameState gameState = GameState.Introduction;

        public Form1()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile(@"C:\Users\imdri\Desktop\R.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size = new Size(1000, 600);

            // Adjust control positions and sizes
            lblNarration.Location = new Point(20, 20);
            lblNarration.Size = new Size(700, 50);
            lblHealth.Location = new Point(20, 80);
            lblLocation.Location = new Point(20, 110);
            lblDescription.Location = new Point(20, 140);
            lblDescription.Size = new Size(300, 100);
            lstInventory.Location = new Point(20, 270);
            lstInventory.Size = new Size(150, 100);
            txtCommand.Location = new Point(250, 450);
            txtCommand.Size = new Size(150, 20);
            btnSubmit.Location = new Point(420, 448);
            txtOutput.Location = new Point(600, 80);
            txtOutput.Size = new Size(350, 470);

            ShowInitialMessage();
            DisplayGameOutput();
        }

        private void ShowInitialMessage()
        {
            AppendResponse("Welcome to Lost in the Woods!");
            AppendResponse("You wake up in the midst of a dense forest, disoriented and confused. You have no memory of how you got here or why. All you know is that you must find a way out of this unfamiliar place.");
            AppendResponse("What will you do?");
            AppendResponse("A) Explore the forest");
            AppendResponse("B) Rest for a while");
        }

        private void DisplayGameOutput()
        {
            lblNarration.Text = GetNarration();
            lblHealth.Text = $"Health: {health}";
            lblLocation.Text = $"Location: {location}";
            lblDescription.Text = $"Description: {description}";
            DisplayInventory();
            DisplayChoices();
            txtCommand.Focus();
        }

        private string GetNarration()
        {
            switch (gameState)
            {
                case GameState.Forest:
                    return "How did this happen?";
                case GameState.River:
                    return "You come across a swift river blocking your path. What's your next move?";
                case GameState.Cave:
                    return "From the bridge you look up, seeing the entrance to a small cave.";
                case GameState.CaveAdditional:
                    return "You light a nearby torch and enter the cave.\nWhat will you do?";
                case GameState.Mountain:
                    return "Is this heaven?";
                case GameState.End:
                    return "You have reached the end of your journey.\nWould you like to play again? (Y/N)";
                case GameState.MountainTurnBack:
                    return "You decide to turn back and explore other paths.\nWould you like to turn back and explore other paths? (Y/N)";
                default:
                    return "";
            }
        }

        private void DisplayInventory()
        {
            lstInventory.Items.Clear();
            foreach (var item in inventory)
            {
                lstInventory.Items.Add($"· {item}");
            }
        }

        private void DisplayChoices()
        {
            switch (gameState)
            {
                case GameState.Forest:
                    DisplayForestChoices();
                    break;
                case GameState.River:
                    DisplayRiverChoices();
                    break;
                case GameState.Cave:
                    DisplayCaveChoices();
                    break;
                case GameState.CaveAdditional:
                    DisplayCaveAdditionalChoices();
                    break;
                case GameState.Mountain:
                    DisplayMountainChoices();
                    break;
                case GameState.End:
                    DisplayEndChoices();
                    break;
                case GameState.MountainTurnBack:
                    DisplayMountainTurnBackChoices();
                    break;
            }
        }

        private void DisplayForestChoices()
        {
            AppendResponse("A) Follow the path deeper into the woods");
            AppendResponse("B) Climb a tree to get a better view");
        }

        private void DisplayRiverChoices()
        {
            AppendResponse("A) Try to swim across the river");
            AppendResponse("B) Look for a bridge upstream");
        }

        private void DisplayCaveChoices()
        {
            AppendResponse("A) Light a torch and enter the cave");
            AppendResponse("B) Stay outside and find another path");
        }

        private void DisplayCaveAdditionalChoices()
        {
            AppendResponse("A) Continue going deeper, climbing up through the seemingly expanding cave system");
            AppendResponse("B) Turn around and exit the cave");
        }

        private void DisplayMountainChoices()
        {
            AppendResponse("A) Keep climbing to reach the top");
            AppendResponse("B) Descend and explore the foothills");
        }

        private void DisplayEndChoices()
        {
            AppendResponse("Would you like to play again? (Y/N)");
        }

        private void DisplayMountainTurnBackChoices()
        {
            AppendResponse("Would you like to turn back and explore other paths? (Y/N)");
        }

        private void AppendResponse(string response)
        {
            txtOutput.AppendText(response + Environment.NewLine + Environment.NewLine);
        }

        private void ProcessCommand(string command)
        {
            command = command.ToLower();
            switch (gameState)
            {
                case GameState.Introduction:
                    ProcessIntroductionCommand(command);
                    break;
                case GameState.Forest:
                    ProcessForestCommand(command);
                    break;
                case GameState.River:
                    ProcessRiverCommand(command);
                    break;
                case GameState.Cave:
                    ProcessCaveCommand(command);
                    break;
                case GameState.CaveAdditional:
                    ProcessCaveAdditionalCommand(command);
                    break;
                case GameState.Mountain:
                    ProcessMountainCommand(command);
                    break;
                case GameState.End:
                    ProcessEndCommand(command);
                    break;
                case GameState.MountainTurnBack:
                    ProcessMountainTurnBackCommand(command);
                    break;
            }
        }

        private void ProcessIntroductionCommand(string command)
        {
            if (command == "a")
            {
                gameState = GameState.Forest;
                description = "You find yourself in a dense forest. Trees surround you, a path leads deeper into the woods.";
            }
            else if (command == "b")
            {
                health += 10; // Assuming resting increases health
                AppendResponse("You decide to rest for a while, recuperating your strength.");
                gameState = GameState.Forest;
                description = "You find yourself in a dense forest. Trees surround you, a path leads deeper into the woods.";
            }
            else
            {
                AppendResponse("Please choose between A and B.");
                return;
            }

            DisplayGameOutput();
        }

        private void ProcessForestCommand(string command)
        {
            if (command.StartsWith("a"))
            {
                gameState = GameState.River;
                description = "You follow the path deeper into the woods, hoping to find a way out.";
            }
            else if (command.StartsWith("b"))
            {
                inventory.Add("Map");
                AppendResponse("You climb a tree, scanning the surroundings you mentally map out the area.");
            }
            else
            {
                AppendResponse("Please choose between A and B.");
                return;
            }

            DisplayGameOutput();
        }

        private void ProcessRiverCommand(string command)
        {
            if (command == "a")
            {
                health = 0;
                gameState = GameState.End;
                description = "You try to swim across the river but get caught in the strong current. You drown.";
            }
            else if (command == "b")
            {
                inventory.Add("Rope");
                AppendResponse("You look for a bridge upstream and find a sturdy rope tied to the railing of the bridge.");
                gameState = GameState.Cave;
                description = "You decide to look for a bridge upstream.";
            }
            else
            {
                AppendResponse("Please choose between A and B.");
                return;
            }

            DisplayGameOutput();
        }

        private void ProcessCaveCommand(string command)
        {
            if (command == "a")
            {
                inventory.Add("Torch");
                AppendResponse("You light a nearby torch and enter the cave.");
                gameState = GameState.CaveAdditional;
                description = "You light a nearby torch and enter the cave.";
            }
            else if (command == "b")
            {
                AppendResponse("You decide to stay outside and find another path.");
                gameState = GameState.Forest;
                description = "You find yourself in a dense forest. Trees surround you, a path leads deeper into the woods.";
            }
            else
            {
                AppendResponse("Please choose between A and B.");
                return;
            }

            DisplayGameOutput();
        }

        private void ProcessCaveAdditionalCommand(string command)
        {
            if (command.StartsWith("a"))
            {
                gameState = GameState.Mountain;
                description = "You climb toward a faint light. You come out on a mountainside.";
            }
            else if (command.StartsWith("b"))
            {
                health = 0;
                gameState = GameState.End;
                description = "While exiting the cave, a snake bites you. You perish.";
            }
            else
            {
                AppendResponse("Please choose between A and B.");
                return;
            }

            DisplayGameOutput();
        }

        private void ProcessMountainCommand(string command)
        {
            if (!inventory.Contains("Rope") || !inventory.Contains("Map") || !inventory.Contains("Torch"))
            {
                AppendResponse("You don't have all the necessary items to proceed.");

                // Offer the player the option to turn back and explore other paths
                AppendResponse("Would you like to turn back and explore other paths? (Y/N)");
                gameState = GameState.MountainTurnBack;
                return;
            }

            if (command.StartsWith("a"))
            {
                // Proceed with climbing to reach the top
                health -= 70;
                AppendResponse("You keep climbing but slip and fall down the mountain, severely injuring yourself.");
                gameState = GameState.End;
            }
            else if (command.StartsWith("b"))
            {
                AppendResponse("You descend and explore the foothills, eventually finding a way out of the forest. Congratulations! You have successfully escaped!");
                gameState = GameState.End;
            }
            else
            {
                AppendResponse("Please choose between A and B.");
                return;
            }

            DisplayGameOutput();
        }

        private void ProcessEndCommand(string command)
        {
            command = command.ToLower();
            if (command == "y")
            {
                ResetGame();
            }
            else if (command == "n")
            {
                Close();
            }
            else
            {
                AppendResponse("Please choose between Y and N.");
            }
        }

        private void ProcessMountainTurnBackCommand(string command)
        {
            command = command.ToLower();
            if (command == "y")
            {
                ResetGame();
            }
            else if (command == "n")
            {
                gameState = GameState.Mountain;
                DisplayMountainChoices();
            }
            else
            {
                AppendResponse("Please choose between Y and N.");
            }
        }

        private void ResetGame()
        {
            health = 100;
            location = "Forest";
            description = "You find yourself in a dense forest. Trees surround you, a path leads deeper into the woods.";
            inventory.Clear(); // Clear the inventory
            gameState = GameState.Introduction;
            ShowInitialMessage();
            DisplayGameOutput();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string command = txtCommand.Text.Trim();
            txtCommand.Clear();
            ProcessCommand(command);
        }
    }
}
