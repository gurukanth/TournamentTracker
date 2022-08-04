using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary.Models;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class CreateTournamentForm : Form, IPrizeRequestor, ITeamRequestor
    {
        private List<TeamModel> availableTeams = GlobalConfig.Connection.GetTeam_All();
        private List<TeamModel> selectedTeams = new List<TeamModel>();
        private List<PrizeModel> selectedPrizes = new List<PrizeModel>();

        public CreateTournamentForm()
        {
            InitializeComponent();
            WireupTeamList();
        }

        private void WireupTeamList()
        {
            teamsDropDown.DataSource = null;
            teamsDropDown.DataSource = availableTeams;
            teamsDropDown.DisplayMember = "TeamName";
            //teamsDropDown.SelectedIndex = 0;

            tournamentTeamsListBox.DataSource = null;
            tournamentTeamsListBox.DataSource = selectedTeams;
            tournamentTeamsListBox.DisplayMember = "TeamName";

            prizesListBox.DataSource = null;
            prizesListBox.DataSource = selectedPrizes;
            prizesListBox.DisplayMember = "PlaceName";
        }

        private void addTeamButton_Click(object sender, EventArgs e)
        {
            TeamModel selectedTeam = (TeamModel) teamsDropDown.SelectedItem;

            if(selectedTeam != null)
            {
                availableTeams.Remove(selectedTeam);
                selectedTeams.Add(selectedTeam);

                WireupTeamList();
            }
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            //Call the crete Prize form
            CreatePrizeForm prizeForm = new CreatePrizeForm(this);
            prizeForm.Show();
            //Get back the Prizemodel from form 
            //and put it in selected Prizes list

        }

        public void PrizeComplete(PrizeModel receivedPrize)
        {
            selectedPrizes.Add(receivedPrize);
            WireupTeamList();
        }

        public void TeamComplete(TeamModel newTeam)
        {
            selectedTeams.Add(newTeam);
            WireupTeamList();
        }

        private void createTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm teamForm = new CreateTeamForm(this);
            teamForm.Show();
        }

        private void removeSelectedPlayersButton_Click(object sender, EventArgs e)
        {
            var team = (TeamModel)tournamentTeamsListBox.SelectedItem;
            if(team != null)
            {
                selectedTeams.Remove(team);
                availableTeams.Add(team);
                WireupTeamList();
            }
        }

        private void removeSelectedPrizesButton_Click(object sender, EventArgs e)
        {
            var selectedPrizeForRemoval = (PrizeModel)prizesListBox.SelectedItem;

            if(selectedPrizeForRemoval != null)
            {
                selectedPrizes.Remove(selectedPrizeForRemoval);
                WireupTeamList();
            }
        }

        private void createTournamentButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var tournament = new TournamentModel {
                    TournamentName = tournamentNameText.Text,
                    EntryFee = decimal.Parse(entryFeeText.Text),
                    EnteredTeams = new List<TeamModel>(selectedTeams),
                    Prizes = new List<PrizeModel>(selectedPrizes)
                };
                //TODO create matchups
                TournamentMatchups.CreateRounds(tournament);

                
                //Create tournament, prizes and entries
                GlobalConfig.Connection.CreateTournament(tournament);

                tournamentNameText.Text = "";
                entryFeeText.Text = "0";
                selectedTeams = new List<TeamModel>();
                selectedPrizes = new List<PrizeModel>();
                WireupTeamList();

            }
            else
            {
                MessageBox.Show("The tournament name, valid entry fee and atelease two teams and prizes are needed to create tournament");
            }
        }

        private bool ValidateForm()
        {
            bool isValid = true;
            if(tournamentNameText.Text.Length == 0)
                isValid = false;
            if(tournamentTeamsListBox.Items.Count < 2)
                isValid = false;
            if(prizesListBox.Items.Count < 1)
                isValid = false;
            decimal value =0;
            if(!decimal.TryParse(entryFeeText.Text, out value))
                isValid = false;
            return isValid;
        }
    }
}
