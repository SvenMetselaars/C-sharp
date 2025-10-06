using DragRacerPrep;
using System;
//FileHandling
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

//libs 2023

namespace APPR_TheRace_23SD_BPRJ_S2
{
	public partial class Form1 : Form
	{
		//objects
		csRacerBase obRacerOne = new csRacerBase();
		csRacerBase obRacerTwo = new csRacerBase();
		csRacerBase obRacerThree = new csRacerBase();
		csRacerBase obRacerFour = new csRacerBase();

		//globals average position calculation, modify to class properties
		double racerOneTotalPositions = 0;//store total of all races
		double racerTwoTotalPositions = 0;
		double racerThreeTotalPositions = 0;
		double racerFourTotalPositions = 0;
		double thisRacerAveragerRacePosition = 0; //used for all racers once finished
		int nrOfRaces = 1;//start with the first race, this is not zero

		//globals race
		int laneLength = 0;
		int finishedPosition = 0;
		bool positionsReset = false;
		int raceTime = 0;
		int raceNumber = 0;
		int minSpeed = 0;
		int maxSpeed = 0;

		//globals fileHandling
		string relativeFileDirectory = "";
		string storedFileName = "";

		//graph init
		System.Drawing.Pen DrawingPen = new System.Drawing.Pen(System.Drawing.Color.Black, 0.1f);
		System.Drawing.Graphics formGraphics;

		//graph variables
		int xStartPosRacerOne;
		int yStartPosRacerOne;
		int xStartPosRacerTwo;
		int yStartPosRacerTwo;
		int xStartPosRacerThree;
		int yStartPosRacerThree;
		int xStartPosRacerFour;
		int yStartPosRacerFour;
		int xEndPos;
		int yEndPos;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InitApplication();

			InitGraph();
			InitDrawingGlobals();
		}

		private void InitApplication()
		{
			this.Text = "The Race - BPRJ - by TrickyTronix" + " - " + obRacerOne.version + " - " + Application.ProductVersion;

			//setup the tabcontrol that the tabs will not show, dirty trick but..
			tbcMainDkal.Appearance = TabAppearance.FlatButtons;
			tbcMainDkal.ItemSize = new Size(0, 1);
			tbcMainDkal.SizeMode = TabSizeMode.Fixed;
			tbcMainDkal.SelectedIndex = 0;


			//first get the location of the .doc directory
			relativeFileDirectory = Application.StartupPath + "\\...\\..\\doc\\";

			ResetPositions();
		}

		private void mspMainQuit_Click(object sender, EventArgs e)
		{
			if (DialogResult.Yes == MessageBox.Show("You are about the quit the appliction, unsaved work might be lost. Continue?", "Quit?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
			{
				Application.Exit();
			}
		}

		private void mspMainViewTheRaceDkal_Click(object sender, EventArgs e)
		{
			tbcMainDkal.SelectedTab = tbpTheRaceDkal;
		}

		private void mspMainViewStatsDkal_Click(object sender, EventArgs e)
		{
			tbcMainDkal.SelectedTab = tbpSetupAndStatisticsDkal;
		}

		private void mspMainViewLoggingDkal_Click(object sender, EventArgs e)
		{
			tbcMainDkal.SelectedTab = tbpLoggingDkal;
		}

		private void btnSetUpRacers_Click(object sender, EventArgs e)
		{
			laneLength = pnlStartPositionsDkal.Left + pnlStartPositionsDkal.Width + pnlFinishLineDkal.Left + pnlFinishLineDkal.Width;

			tmrMain.Interval = Convert.ToInt32(txbTrackSpeed.Text);

			minSpeed = Convert.ToInt32(txbMinSpeed.Text);
			maxSpeed = Convert.ToInt32(txbMaxSpeed.Text);

			SetUpRacersDkal();
		}

		private void SetUpRacersDkal()
		{
			obRacerOne.setSpeed(minSpeed, maxSpeed);
			obRacerTwo.setSpeed(minSpeed, maxSpeed);
			obRacerThree.setSpeed(minSpeed, maxSpeed);
			obRacerFour.setSpeed(minSpeed, maxSpeed);

			obRacerOne.calculateStepSize(laneLength);
			obRacerTwo.calculateStepSize(laneLength);
			obRacerThree.calculateStepSize(laneLength);
			obRacerFour.calculateStepSize(laneLength);

			lblRacerOneSpeed.Text = obRacerOne.GetTunedRacerSpeed.ToString();
			lblRacerTwoSpeed.Text = obRacerTwo.GetTunedRacerSpeed.ToString();//ERROR EXAMPLE, set to racer one
			lblRacerThreeSpeed.Text = obRacerThree.GetTunedRacerSpeed.ToString();
			lblRacerFourSpeed.Text = obRacerFour.GetTunedRacerSpeed.ToString();

			lblRacerOneStep.Text = obRacerOne.GetStepSizePerTick.ToString();
			lblRacerTwoStep.Text = obRacerTwo.GetStepSizePerTick.ToString();
			lblRacerThreeStep.Text = obRacerThree.GetStepSizePerTick.ToString();
			lblRacerFourStep.Text = obRacerFour.GetStepSizePerTick.ToString();

			obRacerOne.racerName = "reesbeest1";
			obRacerTwo.racerName = "reesbeest2";
			obRacerThree.racerName = "reesbeest3";
			obRacerFour.racerName = "reesbeest4";

			UpdateSettings();
		}

		private void mspMainViewSetupDkal_Click(object sender, EventArgs e)
		{
			tbcMainDkal.SelectedTab = tbpSetupAndStatisticsDkal;

			this.Height = Convert.ToInt32(455 * 0.75) + 21;
			this.Width = Convert.ToInt32(1191 * 0.75) + 10;
		}

		private void tmrMain_Tick(object sender, EventArgs e)
		{
			raceTime++;

			if (raceTime > 666)
			{
				raceTime = 0;
			}
			else
			{
				lblRaceTime.Text = raceTime.ToString();
			}

			UpdatePositionsDkal();

			ModifySpeedDynamically();

			DrawGraphHorizontally();
		}

		private void UpdatePositionsDkal()
		{
			UpdatePosAndFinishRacerOne();

			UpdatePosAndFinishRacerTwo();

			UpdatePosAndFinishRacerThree();

			UpdatePosAndFinishRacerFour();

			FinalizeRace();
		}

		private void FinalizeRace()
		{
			if (obRacerOne.racerFinished == true &&
				obRacerTwo.racerFinished == true &&
				obRacerThree.racerFinished == true &&
				obRacerFour.racerFinished == true)
			{
				tmrMain.Enabled = false; //ERROR EXAMPLE, set to true
				positionsReset = false;
				rtbRaceResults.AppendText("\n");

				nrOfRaces++;//ERROR example, remove; keep the slashes
				lblNrOfRaces.Text = nrOfRaces.ToString();
			}
		}

		/// <summary>
		/// only this method with comment, in One, Two and Three this in not provided
		/// </summary>
		private void UpdatePosAndFinishRacerFour()
		{
			double m_prevRacerAveragePosition = 0;

			if (pbxRacerFourDkal.Left > pnlFinishLineDkal.Left + 10)
			{
				if (obRacerFour.racerFinished == false)
				{
					//handle finishing, 'checkered flag' when finished, update rank en do not come back here
					// 5,1
					obRacerFour.racerFinished = true;
					finishedPosition++;
					lblRacerFourFinishedPosition.Text = finishedPosition.ToString();

					//average ranking and positions in up/down listing
					racerFourTotalPositions = racerFourTotalPositions + finishedPosition;
					m_prevRacerAveragePosition = thisRacerAveragerRacePosition; //save prev result and compare later
					thisRacerAveragerRacePosition = Math.Round(racerFourTotalPositions / nrOfRaces, 1);
					lblRacerFourAverage.Text = thisRacerAveragerRacePosition.ToString();

					//set up/down based on results
					if (thisRacerAveragerRacePosition != m_prevRacerAveragePosition)
					{
						lblRacerFourRankUpDown.Text = "up";
						lblRacerFourRankUpDown.ForeColor = Color.Lime;
					}
					else if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
					{
						lblRacerFourRankUpDown.Text = "down";
						lblRacerFourRankUpDown.ForeColor = Color.Red;
					}
					else
					{
						lblRacerFourRankUpDown.Text = "same";
						lblRacerFourRankUpDown.ForeColor = Color.Blue;
					}

					//add average to log
					rtbRaceResults.AppendText("Race: " + raceNumber.ToString() + " > position: " + finishedPosition.ToString() + " > racer 4 " + " > race time: " + raceTime.ToString() + "\n");
				}
			}
			else
			{
				//execute until finished
				obRacerFour.calculateCurrentPosition();
				pbxRacerFourDkal.Left = obRacerFour.GetActualPositionInLaneRounded;

				lblRacerFourStepActual.Text = obRacerFour.GetTunedRacerSpeed.ToString();
			}
		}

		/// <summary>
		/// check out comment in handling of racer four!
		/// </summary>
		private void UpdatePosAndFinishRacerThree()
		{
			double m_prevRacerAveragePosition = 0;

			if (pbxRacerThreeDkal.Left > pnlFinishLineDkal.Left + 10)
			{
				if (obRacerThree.racerFinished == false)
				{
					obRacerThree.racerFinished = true;
					finishedPosition++;
					lblRacerThreeFinishedPosition.Text = finishedPosition.ToString();

					racerThreeTotalPositions = racerThreeTotalPositions + finishedPosition;
					m_prevRacerAveragePosition = thisRacerAveragerRacePosition; //save prev result and compare later
					thisRacerAveragerRacePosition = Math.Round(racerThreeTotalPositions / nrOfRaces, 1);
					lblRacerThreeAverage.Text = thisRacerAveragerRacePosition.ToString();

					if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
					{
						lblRacerThreeRankUpDown.Text = "up";
						lblRacerThreeRankUpDown.ForeColor = Color.Lime;
					}
					else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
					{
						lblRacerThreeRankUpDown.Text = "down";
						lblRacerThreeRankUpDown.ForeColor = Color.Red;
					}
					else
					{
						lblRacerThreeRankUpDown.Text = "same";
						lblRacerThreeRankUpDown.ForeColor = Color.Blue;
					}

					rtbRaceResults.AppendText("Race: " + raceNumber.ToString() + " > position: " + finishedPosition.ToString() + " > racer 3 " + " > race time: " + raceTime.ToString() + "\n");
				}
			}
			else
			{
				obRacerThree.calculateCurrentPosition();
				pbxRacerThreeDkal.Left = obRacerThree.GetActualPositionInLaneRounded;

				lblRacerThreeStepActual.Text = obRacerThree.GetTunedRacerSpeed.ToString();
			}
		}

		/// <summary>
		/// check out comment in handling of racer four!
		/// </summary>
		private void UpdatePosAndFinishRacerTwo()
		{
			double m_prevRacerAveragePosition = 0;

			if (pbxRacerTwoDkal.Left > pnlFinishLineDkal.Left + 10)
			{
				if (obRacerTwo.racerFinished == false)
				{
					// 5,1
					obRacerTwo.racerFinished = true;
					finishedPosition++;
					lblRacerTwoFinishedPosition.Text = finishedPosition.ToString();

					racerTwoTotalPositions = racerTwoTotalPositions + finishedPosition;
					m_prevRacerAveragePosition = thisRacerAveragerRacePosition;//save prev result and compare later
					thisRacerAveragerRacePosition = Math.Round(racerTwoTotalPositions / nrOfRaces, 1);
					lblRacerTwoAverage.Text = thisRacerAveragerRacePosition.ToString();

					if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
					{
						lblRacerTwoRankUpDown.Text = "up";
						lblRacerTwoRankUpDown.ForeColor = Color.Lime;
					}
					else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
					{
						lblRacerTwoRankUpDown.Text = "down";
						lblRacerTwoRankUpDown.ForeColor = Color.Red;
					}
					else
					{
						lblRacerTwoRankUpDown.Text = "same";
						lblRacerTwoRankUpDown.ForeColor = Color.Blue;
					}


					rtbRaceResults.AppendText("Race: " + raceNumber.ToString() + " > position: " + finishedPosition.ToString() + " > racer 2 " + " > race time: " + raceTime.ToString() + "\n");
				}
			}
			else
			{
				obRacerTwo.calculateCurrentPosition();
				pbxRacerTwoDkal.Left = obRacerTwo.GetActualPositionInLaneRounded;

				lblRacerTwoStepActual.Text = obRacerTwo.GetTunedRacerSpeed.ToString();
			}
		}

		/// <summary>
		/// check out comment in handling of racer four!
		/// </summary>
		private void UpdatePosAndFinishRacerOne()
		{
			double m_prevRacerAveragePosition = 0;

			if (pbxRacerOneDkal.Left > pnlFinishLineDkal.Left + 10)
			{
				if (obRacerOne.racerFinished == false)
				{
					obRacerOne.racerFinished = true;
					finishedPosition++;
					lblRacerOneFinishedPosition.Text = finishedPosition.ToString();

					racerOneTotalPositions = racerOneTotalPositions + finishedPosition;
					m_prevRacerAveragePosition = thisRacerAveragerRacePosition;//save prev result and compare later
					thisRacerAveragerRacePosition = Math.Round(racerOneTotalPositions / nrOfRaces, 1);
					lblRacerOneAverage.Text = thisRacerAveragerRacePosition.ToString();

					if (thisRacerAveragerRacePosition > m_prevRacerAveragePosition)
					{
						lblRacerOneRankUpDown.Text = "up";
						lblRacerOneRankUpDown.ForeColor = Color.Lime;
					}
					else if (thisRacerAveragerRacePosition < m_prevRacerAveragePosition)
					{
						lblRacerOneRankUpDown.Text = "down";
						lblRacerOneRankUpDown.ForeColor = Color.Red;
					}
					else
					{
						lblRacerOneRankUpDown.Text = "same";
						lblRacerOneRankUpDown.ForeColor = Color.Blue;
					}


					rtbRaceResults.AppendText("Race: " + raceNumber.ToString() + " > position: " + finishedPosition.ToString() + " > racer 1 " + " > race time: " + raceTime.ToString() + "\n");
				}
			}
			else
			{
				obRacerOne.calculateCurrentPosition();
				pbxRacerOneDkal.Left = obRacerOne.GetActualPositionInLaneRounded;

				lblRacerOneStepActual.Text = obRacerOne.GetTunedRacerSpeed.ToString();
			}
		}

		private void ModifySpeedDynamically()
		{
			//when selected, the dynamic speed mode is active
			if (cbxDynamicSpeed.Checked == true)
			{
				//change the speed on the checked racetime
				if (raceTime == 200)
				{
					//re-initialize the racer settings, just like reset
					SetUpRacersDkal();
				}
			}
		}

		private void btnStartDkal_Click(object sender, EventArgs e)
		{
			//when the racers finished the timer was disabled,
			//the finish position was on the last finished ranking
			//the next race is started so this is the Xth race
			//a new drawing will appear so the drawing must be reset
			if (positionsReset == true)
			{
				tmrMain.Enabled = true;

				finishedPosition = 0;

				raceNumber++;

				InitDrawingGlobals();//lesson week 16
			}
		}

		private void btnResetPositions_Click(object sender, EventArgs e)
		{
			//not only the picturbox must be on the start line
			//also the racer object values must be reset
			ResetPositions();

			//the trail the racer leaves behind must be reset as well
			ResetTrace();

			//this will force the screen to redraw everything,
			//if only is available in the screen buffer it will be cleared
			Refresh();
		}

		private void ResetPositions()
		{
			//when finished the racer bools are true and must be reset
			obRacerOne.racerFinished = false;
			obRacerTwo.racerFinished = false;
			obRacerThree.racerFinished = false;
			obRacerFour.racerFinished = false;

			//no ranking value shall appear in the ranking labels
			lblRacerOneFinishedPosition.Text = "---";
			lblRacerTwoFinishedPosition.Text = "---";
			lblRacerThreeFinishedPosition.Text = "---";
			lblRacerFourFinishedPosition.Text = "---";

			//reset the values in the racer objects, pnlGetSet is the starting plate
			obRacerOne.resetPosition(pnlGetSet.Left);
			obRacerTwo.resetPosition(pnlGetSet.Left);
			obRacerThree.resetPosition(pnlGetSet.Left);
			obRacerFour.resetPosition(pnlGetSet.Left);

			pbxRacerOneDkal.Left = pnlGetSet.Left;
			pbxRacerTwoDkal.Left = pnlGetSet.Left;
			pbxRacerThreeDkal.Left = pnlGetSet.Left;
			pbxRacerFourDkal.Left = pnlGetSet.Left;

			//if reset is executed it must prohibited to reset again
			positionsReset = true;
			raceTime = 0;
		}

		private void ResetTrace()
		{
			pbxRacerOneTrace.Width = 0;
			pbxRacerTwoTrace.Width = 0;
			pbxRacerThreeTrace.Width = 0;
			pbxRacerFourTrace.Width = 0;
		}

		private void btnClearRaceResults_Click(object sender, EventArgs e)
		{
			rtbRaceResults.Clear();
		}

		private void btnDefaultSetup_Click(object sender, EventArgs e)
		{
			txbTrackSpeed.Text = "1";
			txbMinSpeed.Text = "500";
			txbMaxSpeed.Text = "800";
			cbxDynamicSpeed.Checked = true;
		}

		private void mspFileSaveAsDkal_Click(object sender, EventArgs e)//workshop week 15
		{
			diaFileSave.FileName = "TheRace - Racervalues.txt"; //default file name in the dialogbox
			diaFileSave.Filter = "Text file|*.txt"; //show the file format preferences
			diaFileSave.ShowDialog();
			relativeFileDirectory = diaFileSave.FileName; //save for later use
			rtbLoggingDkal.AppendText("Location and filename: " + relativeFileDirectory + "\n" + "\n");

			storedFileName = Path.GetFileName(relativeFileDirectory); //only file name
			rtbLoggingDkal.AppendText("Filename only: " + storedFileName + "\n");

			//append adds text to the existing file contents
			WriteTheRaceSettingsFile();
		}

		private void WriteTheRaceSettingsFile()//workshop week 15
		{
			StreamWriter SettingsRecorder = new StreamWriter(relativeFileDirectory, false);

			//write the lines, only the number of written lines can be read
			SettingsRecorder.WriteLine(obRacerOne.racerName);
			SettingsRecorder.WriteLine(obRacerTwo.racerName);
			SettingsRecorder.WriteLine(obRacerThree.racerName);
			SettingsRecorder.WriteLine(obRacerFour.racerName);

			SettingsRecorder.Close();
		}

		private void mspFileOpenDkal_Click(object sender, EventArgs e)//workshop week 15
		{
			string m_filenameAndLocation;

			diaFileOpen.Filter = "Text file|*.txt|All files(*.*)|*.*";
			diaFileOpen.ShowDialog();
			m_filenameAndLocation = diaFileOpen.FileName;

			ReadTheRaceSettingsFile(m_filenameAndLocation);

			//send read values to the GUI
			UpdateSettings();
		}

		private void ReadTheRaceSettingsFile(string m_filenameAndLocation)
		{
			StreamReader SettingsLoader = new StreamReader(m_filenameAndLocation);

			//read only the lines which were written
			obRacerOne.racerName = SettingsLoader.ReadLine();
			obRacerTwo.racerName = SettingsLoader.ReadLine();
			obRacerThree.racerName = SettingsLoader.ReadLine();
			obRacerFour.racerName = SettingsLoader.ReadLine();

			SettingsLoader.Close();
		}

		private void UpdateSettings()//workshop week 15
		{
			txbRacerOneName.Text = obRacerOne.racerName;
			txbRacerTwoName.Text = obRacerTwo.racerName;
			txbRacerThreeName.Text = obRacerThree.racerName;
			txbRacerFourName.Text = obRacerFour.racerName;

			lblRacerOneName.Text = obRacerOne.racerName;
			lblRacerTwoName.Text = obRacerTwo.racerName;
			lblRacerThreeName.Text = obRacerThree.racerName;
			lblRacerFourName.Text = obRacerFour.racerName;
		}

		private void mspHelpUserManualDkal_Click(object sender, EventArgs e)//workshop week 15
		{

		}

		//IPC4
		private void btnUpdateNames_Click(object sender, EventArgs e)//workshop week 15
		{
			obRacerOne.racerName = txbRacerOneName.Text;
			obRacerTwo.racerName = txbRacerTwoName.Text;
			obRacerThree.racerName = txbRacerThreeName.Text;
			obRacerFour.racerName = txbRacerFourName.Text;
		}

		private void InitGraph()//lesson week 16
		{
			formGraphics = pnlGraphDkal.CreateGraphics();
			DrawingPen.Width = 1;
		}

		private void InitDrawingGlobals()//workshop week 16
		{
			//xStartPos = 0;//pbxRacerOneDkal.Left - pbxRacerOneDkal.Width;// 0;// pnlGraphDkal.Left; // + pnlGraphDkal.Width;
			yStartPosRacerOne = pnlGraphDkal.Height;
			yStartPosRacerTwo = pnlGraphDkal.Height;
			yStartPosRacerThree = pnlGraphDkal.Height;
			yStartPosRacerFour = pnlGraphDkal.Height;
			xStartPosRacerOne = 0;
			xStartPosRacerTwo = 0;
			xStartPosRacerThree = 0;
			xStartPosRacerFour = 0;

			xEndPos = 0;// pnlGraphDkal.Left;//pbxRacerOneDkal.Left - pbxRacerOneDkal.Width;//0;// pnlGraphDkal.Left;//pnlGraphDkal.Left + 
			yEndPos = pnlGraphDkal.Top + pnlGraphDkal.Height;
		}
		private void DrawGraphHorizontally()
		{
			DrawRacerOneSpeedSettings();
		}

		private void DrawRacerOneSpeedSettings()//workshop week 16
		{
			int m_offset;

			DrawingPen.Color = System.Drawing.Color.Red;

			m_offset = pnlGraphDkal.Height + (pnlGraphDkal.Height / 2) - (obRacerOne.GetTunedRacerSpeed / 5); //since the result is an integer, it is automatically rounded

			xEndPos = pbxRacerOneDkal.Left;
			yEndPos = Convert.ToInt32(m_offset);

			formGraphics.DrawLine(DrawingPen, xStartPosRacerOne, yStartPosRacerOne, xEndPos, yEndPos);

			xStartPosRacerOne = pbxRacerOneDkal.Left;
			yStartPosRacerOne = Convert.ToInt32(m_offset);
		}

		private void mspMainAboutDkal_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Created by: Dick van Kalsbeek 18oct2022", "About");
		}

		private void msiTheRaceLocate_Click(object sender, EventArgs e)
		{
			MessageBox.Show(Application.StartupPath, "Location of application", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

        private void mspFileSaveAsCsvDkal_Click(object sender, EventArgs e)
        {

        }
    }
}
