using _89661_astriodsShooter_APPR_bpjw.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace _89661_astriodsShooter_APPR_bpjw
{
    public partial class Form1 : Form
    {
        // Declare variables to store the initial positions of the panels
        int pnlPlayerY;
        int pnlPlayerGunY;

        bool sprint = false;

        int max_astriods = 20;
        int prevSpawnY = 0;

        int Construct_Id = 0;
        int Construct_Health;
        Image Construct_Image;
        string Construct_Name;

        int nextBulletId = 1;

        private List<astriods> astriods = new List<astriods>();

        public Form1()
        {
            InitializeComponent();

            // Store the initial positions of the panels
            pnlPlayerY = pnlPlayerSlin.Location.Y;
            pnlPlayerGunY = pnlPlayerGunSlin.Location.Y;

            tmrMovement.Enabled = true;
        }

        private HashSet<Keys> pressedKeys = new HashSet<Keys>(); // Collection to track pressed keys

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode); // Add pressed key to the collection

            HandleKeys(); // Handle all pressed keys
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode); // Remove released key from the collection

            HandleKeys(); // Handle remaining pressed keys
        }

        private void HandleKeys()
        {
            sprint = pressedKeys.Contains(Keys.Shift); // Check if Shift key is pressed

            int speed = sprint ? 12 : 6; // Determine speed based on sprint state

            if (pressedKeys.Contains(Keys.W))
            {
                MovePanels(-speed); // Move panels up
            }
            else if (pressedKeys.Contains(Keys.S))
            {
                MovePanels(speed); // Move panels down
            }

            if (pressedKeys.Contains(Keys.Enter))
            {
                AstriodMaker(); // Handle Enter key press
            }

            if (pressedKeys.Contains(Keys.E))
            {
                bulletReactor(); // Handle Space key press
            }

            if (pressedKeys.Contains(Keys.Tab))
            {
                ToggleTimer(); // Handle Tab key press to toggle timer
            }
        }

        private void MovePanels(int deltaY)
        {
            // Calculate the new position of each player panel
            int pnlPlayerY = pnlPlayerSlin.Location.Y + deltaY;
            int pnlGunY = pnlPlayerGunSlin.Location.Y + deltaY;

            int maxTop = pnlPlayerRailSlin.Top;
            int maxBottom = pnlPlayerRailSlin.Bottom - pnlPlayerSlin.Height;

            // Check if moving up will go beyond the top boundary
            if (pnlPlayerY < maxTop)
            {
                return;
            }
            else if (pnlPlayerY > maxBottom)
            {
                return;
            }

            // Update the position of each player panel
            pnlPlayerSlin.Location = new System.Drawing.Point(pnlPlayerSlin.Location.X, pnlPlayerY);
            pnlPlayerGunSlin.Location = new System.Drawing.Point(pnlPlayerGunSlin.Location.X, pnlGunY);
        }

        #region Timer

        private bool timerEnabled = false;
        private int timerInterval = 100;

        private void ToggleTimer()
        {
            timerEnabled = !timerEnabled; // Toggle the timer state

            if (timerEnabled)
            {
                // Start the timer
                tmrMovement.Interval = timerInterval; // Set the timer interval
                tmrMovement.Start();
            }
            else
            {
                // Stop the timer
                tmrMovement.Stop();
            }
        }

        private void tmrMovement_Tick(object sender, EventArgs e)
        {
            flyingAstriod();

            flyingBullets();

            handleCollision();
            checkAndRemoveAsteroids();

            repositionAsteroids();
        }

        private void handleCollision()
        {
            // Check for collisions between asteroids and bullets
            foreach (var asteroid in astriods.ToList()) // Iterate over a copy to allow removal of elements
            {
                foreach (var bullet in bulletPictureBoxes.ToList()) // Iterate over a copy to allow removal of elements
                {
                    if (asteroid.pictureBox.Bounds.IntersectsWith(bullet.Bounds))
                    {
                        // Damage the asteroid by 1
                        asteroid.Health -= 1;

                        // Remove the bullet
                        Controls.Remove(bullet);
                        bulletPictureBoxes.Remove(bullet);

                        // If the asteroid's health is now 0, mark it for removal
                        if (asteroid.Health <= 0)
                        {
                            astriods.Remove(asteroid);
                            Controls.Remove(asteroid.pictureBox);
                        }
                    }
                }
            }
        }

        private void checkAndRemoveAsteroids()
        {
            // Create a list to store asteroids that need to be removed
            List<astriods> asteroidsToRemove = new List<astriods>();

            // Check if asteroid's health is below 0 and mark it for removal
            foreach (var asteroid in astriods)
            {
                if (asteroid.Health <= 0)
                {
                    asteroidsToRemove.Add(asteroid);
                }
            }

            // Remove the marked asteroids from the list and from the Controls
            foreach (var asteroidToRemove in asteroidsToRemove)
            {
                astriods.Remove(asteroidToRemove);
                Controls.Remove(asteroidToRemove.pictureBox);
            }
        }


        #endregion

        #region astriods

        private void repositionAsteroids()
        {
            foreach (var asteroid in astriods)
            {
                // Check if the asteroid is outside the visible area (right side of the form)
                if (asteroid.pictureBox.Left > this.ClientSize.Width)
                {
                    // Reposition the asteroid to the left side of the form
                    asteroid.pictureBox.Left = -asteroid.pictureBox.Width;

                    // You may also want to randomize the Y position to prevent asteroids from following the same path
                    Random rand = new Random();
                    asteroid.pictureBox.Top = rand.Next(0, this.pnlAstriodSpawnSlin.Height - asteroid.pictureBox.Height);
                }
            }
        }

        private void flyingAstriod()
        {
            if (astriods.Count != 0)
            {
                InitAstriods();

                foreach (astriods astriods in astriods)
                {
                    astriods.pictureBox.Left += 5;
                }
            }
        }

        private void AstriodMaker()
        {
            if (astriods.Count <= max_astriods)
            {
                // Call the method to gather resources and create asteroids
                AstriodsResourcer();
            }
            else
            {
                return;
            }
        }

        private void AstriodsResourcer()
        {
            // Generate a random rank for the asteroid
            Random _rank = new Random();
            int rank = GetBiasedRandom(_rank, 5);
            int spawnY = GetBaisedY();

            // Call the method to shape the asteroid based on the selected rank
            AstriodsShaper(rank);

            // Create a PictureBox for the new asteroid
            PictureBox asteroidPictureBox = new PictureBox();
            asteroidPictureBox.Size = new Size(30, 30);
            asteroidPictureBox.Image = Construct_Image;
            asteroidPictureBox.Location = new Point(2, spawnY);
            asteroidPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            asteroidPictureBox.Name = "pbxAstriod_" + Construct_Id;

            // Add the PictureBox to the form
            this.Controls.Add(asteroidPictureBox);

            astriods newAsteroid = new astriods(Construct_Id, Construct_Name, Construct_Image, rank, Construct_Health);
            newAsteroid.pictureBox = asteroidPictureBox; // Link the PictureBox to the asteroid
            astriods.Add(newAsteroid);

            rtbLoggingSlin.ScrollToCaret();
            rtbLoggingSlin.AppendText($"{asteroidPictureBox.Name} / {newAsteroid.Name} \n");

            asteroidPictureBox.BringToFront();
        }
        
        private int GetBaisedY()
        {
            Random _randY = new Random();
            int spawnY = _randY.Next(0, pnlAstriodSpawnSlin.Height - prevSpawnY);

            prevSpawnY = spawnY;
            return spawnY;
        }

        private void AstriodsShaper(int rank)
        {

            // Set attributes based on the selected rank
            switch (rank)
            {
                case 0:
                    Construct_Health = 1;
                    Construct_Image = Resources.astriod;
                    Construct_Name = AstriodsNamer("Z");
                    break;
                case 1:
                    Construct_Health = 2;
                    Construct_Image = Resources.astriod_blue;
                    Construct_Name = AstriodsNamer("Y");
                    break;
                case 2:
                    Construct_Health = 3;
                    Construct_Image = Resources.astriod_green;
                    Construct_Name = AstriodsNamer("X");
                    break;
                case 3:
                    Construct_Health = 4;
                    Construct_Image = Resources.astriod_red;
                    Construct_Name = AstriodsNamer("W");
                    break;
                case 4:
                    Construct_Health = 5;
                    Construct_Image = Resources.astriods_white;
                    Construct_Name = AstriodsNamer("V");
                    break;
            }

            Construct_Id++;
        }

        private string AstriodsNamer(string XYZ_index)
        {
            // Logic to generate a name for the asteroid, combining a random name from a list with the XYZ index
            // For simplicity, let's assume you have a list of names stored somewhere
            List<string> asteroidNames = new List<string>() { "Alpha", "Beta", "Gamma", "Delta", "Lucas van Hest", "Broekpoep", "Lucas Knaapen" };
            Random rand = new Random();
            string randomName = asteroidNames[rand.Next(0, asteroidNames.Count)];
            string asteroidName = randomName + " " + XYZ_index; // Concatenate random name with XYZ index
            return asteroidName;
        }

        private void InitAstriods()
        {
            foreach (astriods astriods in astriods)
            {
                PictureBox astriod_pbx = Controls.Find($"pbxAstriod_{astriods.Id}", true).FirstOrDefault() as PictureBox;

                if (astriod_pbx != null)
                {
                    astriods.pictureBox = astriod_pbx;
                }
            }
        }

        static int GetBiasedRandom(Random rand, int range)
        {
            // Generate a random number with biased probabilities
            int result = rand.Next(11); // Adjust the factor as needed

            // If the random number is less than 6, return 0
            // Otherwise, return a random value from 1 to range - 1
            return result < 6 ? 0 : rand.Next(1, range);
        }

        #endregion

        #region bullets

        private void flyingBullets()
        {
            foreach (Control control in Controls)
            {
                if (control is PictureBox pictureBox && pictureBox.Name.StartsWith("pbxBullet_"))
                {
                    pictureBox.Left += - 6;
                }
            }
        }

        private const int MaxBulletCount = 10;
        private List<PictureBox> bulletPictureBoxes = new List<PictureBox>(); // List to store bullet PictureBoxes

        private void bulletReactor()
        {
            if (bulletPictureBoxes.Count >= MaxBulletCount)
            {
                // If the maximum number of bullets is reached, destroy the oldest bullet
                DestroyOldestBullet();
            }

            // Create a new bullet PictureBox
            PictureBox bulletPictureBox = new PictureBox();
            bulletPictureBox.Size = new Size(20, pnlPlayerGunSlin.Height / 2);
            bulletPictureBox.BackColor = Color.MediumPurple;
            bulletPictureBox.Location = new Point(pnlPlayerGunSlin.Left - 5, pnlPlayerGunSlin.Location.Y + 5);
            bulletPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            bulletPictureBox.Name = bulletIdConstructor();

            this.Controls.Add(bulletPictureBox);
            bulletPictureBoxes.Add(bulletPictureBox);

            rtbLoggingSlin.ScrollToCaret();
            rtbLoggingSlin.AppendText($"{bulletPictureBox.Name} \n");
        }

        private void DestroyOldestBullet()
        {
            // Find the oldest bullet PictureBox
            PictureBox oldestBullet = bulletPictureBoxes.First();

            // Remove it from the list of bullet PictureBoxes and from the form's Controls collection
            bulletPictureBoxes.Remove(oldestBullet);
            Controls.Remove(oldestBullet);
        }
        public string bulletIdConstructor()
        {
            // Find the lowest available bullet ID
            int lowestId = 1;
            while (bulletPictureBoxes.Any(pb => pb.Name == "pbxBullet_" + lowestId))
            {
                lowestId++;
            }

            string bulletId = "pbxBullet_" + lowestId;
            return bulletId;
        }

        #endregion
    }
}