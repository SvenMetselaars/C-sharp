using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPR_ArduinoConnect_Worksheet_Template2
{
    public partial class Gameform : Form
    {
        int horizontal, vertical, rotation;
        string locationtype = "";
        Arduinoform arduinoform = null;
        Location newlocation = null;
        List<Location> locationlist = null;
        int movearduinoCounter = 0;
        string commando = "";
        Location currentLocation = null;
        int currentlocationCount = 0;
        bool moveBuisy = false;

        public Gameform()
        {
            InitializeComponent();
        }

        private void Gameform_Load(object sender, EventArgs e)
        {
            arduinoform = new Arduinoform(this);
            locationlist = new List<Location>();
            arduinoform.Top = this.Top;
        }
        private void btnConnectArduino_Click(object sender, EventArgs e)
        {
            arduinoform.Show();
            arduinoform.Left = this.Left + this.Width + 10;
            arduinoform.Top = this.Top;
        }

        private void btnSaveLocation_Click(object sender, EventArgs e)
        {
            try
            {
                horizontal = Convert.ToInt32(txbHorizontal.Text);
                vertical = Convert.ToInt32(txbVertical.Text);
                rotation = Convert.ToInt32(txbRotation.Text);

                horizontal = CheckNumber(horizontal);
                vertical = CheckNumber(vertical);
                rotation = CheckNumber(rotation);

                if(horizontal != -1 && vertical != -1 && rotation != -1)
                {
                    newlocation = new Location(horizontal, vertical, rotation, locationtype);
                    locationlist.Add(newlocation);
                    lbxLocationList.Items.Add(newlocation.GetHorizontal() + " " + newlocation.GetVertical() + " " + newlocation.GetRotation() + " " + newlocation.GetLocationtype());
                    SwitchLocationtype();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Only numbers are allowed.");
            }
        }

        public int CheckNumber(int number)
        {
            if (number < 0 || number > 1500)
            {
                MessageBox.Show("numbers must be between 0 and 1500");
                number = - 1;
            }
            return number;
        }

        private void tmrArduino_Tick(object sender, EventArgs e)
        {
            lblArduinoBuisy.Text = "yes";
            if (movearduinoCounter == 0) 
            {
                commando = $"RS:{currentLocation.GetRotation()}";
            }
            else if (movearduinoCounter == 1) 
            {
                commando = $"HS:{currentLocation.GetHorizontal()}";
            }
            else if (movearduinoCounter  == 2)
            {
                commando = $"VS:{currentLocation.GetVertical()}";
            }
            if (currentLocation.GetLocationtype() == "PickUp")
            {
                if (movearduinoCounter == 3)
                {
                    commando = "CS:1";
                }
                else if (movearduinoCounter == 4)
                {
                    commando = "SS:1";
                }
            }
            else if (currentLocation.GetLocationtype() == "DropOff")
            {
                if (movearduinoCounter == 5)
                {
                    commando = "CS:0";
                }
                else if (movearduinoCounter == 6)
                {
                    commando = "SS:0";
                }
            }
            else if (movearduinoCounter == 7)
            {
                commando = "ZS:1";
            }

            if(moveBuisy == false)
            {
                moveBuisy = true;
                arduinoform.WriteArduino(commando);
            }
        }

        public void ArduinoConnected()
        {
            btnRunApplication.Enabled = true;
            lblConnected.Text = "yes";
            lblCurrentLocationtype.Text = "PickUp";
            locationtype = lblCurrentLocationtype.Text;
        }

        private void btnRunApplication_Click(object sender, EventArgs e)
        {
            if(lbxLocationList.Items.Count != 0)
            {
                moveBuisy = false;
                currentlocationCount = 0;
                currentLocation = locationlist[currentlocationCount];
                lbxLocationList.SelectedIndex = currentlocationCount;
                movearduinoCounter = 0;
                tmrArduino.Start();
            }
            else
            {
                MessageBox.Show("There are no steps saved for the arduino");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            locationlist.Clear();
        }

        public void SwitchLocationtype()
        {
            if(locationtype == "PickUp")
            {
                locationtype = "Hold";
            }
            else if (locationtype == "Hold")
            {
                locationtype = "DropOff";
            }
            else
            {
                locationtype = "PickUp";
            }
            lblCurrentLocationtype.Text = locationtype;
        }

        public void NextArduinoStep()
        {
            moveBuisy = false;
            movearduinoCounter++;
            if(movearduinoCounter == 8)
            {
                movearduinoCounter = 0;
                currentlocationCount++;
                if (currentlocationCount <= locationlist.Count - 1)
                {
                    currentLocation = locationlist[currentlocationCount];
                    lbxLocationList.SelectedIndex = currentlocationCount;
                }
                else
                {
                    arduinoform.WriteArduino("ZS:0");
                    MessageBox.Show("The arduino is finnished and will now reset.");
                    lbxLocationList.ClearSelected();
                    tmrArduino.Stop();
                }
            }
        }


    }
}
