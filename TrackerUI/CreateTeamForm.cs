using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableMembersForTeamSelection = GlobalConfig.Connection.GetPersons_All();
        private List<PersonModel> selectedTeamMembers = new List<PersonModel>();

        public CreateTeamForm()
        {
            InitializeComponent();
            WireupListBoxes();
        }

        private void CreateSampleData()
        {
            availableMembersForTeamSelection.Add(new PersonModel { FirstName = "Hall", LastName = "David" });
            availableMembersForTeamSelection.Add(new PersonModel { FirstName = "Sahu", LastName = "Chandra" });

            selectedTeamMembers.Add(new PersonModel { FirstName = "Stren", LastName = "Eric" });
            selectedTeamMembers.Add(new PersonModel { FirstName = "Gopal", LastName = "Venu" });
        }

        private void WireupListBoxes()
        {
            teamMembersDropDown.DataSource = null; //allows list updates re applied on modification
            teamMembersDropDown.DataSource = availableMembersForTeamSelection;
            teamMembersDropDown.DisplayMember = "FullName";
            teamMembersDropDown.ValueMember = "Id";

            teamMembersListBox.DataSource = null;
            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = "FullName";
            teamMembersListBox.ValueMember = "Id";
        }

        private void CreateTeamForm_Load(object sender, EventArgs e)
        {

        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PersonModel personModel = new PersonModel();
                personModel.FirstName = firstNameText.Text;
                personModel.LastName = lastNameText.Text;
                personModel.EmailAddress = emailText.Text;
                personModel.CellPhoneNumber = cellPhoneText.Text;

                personModel = GlobalConfig.Connection.CreatePerson(personModel);
                selectedTeamMembers.Add(personModel);
                WireupListBoxes();

                firstNameText.Text = "";
                lastNameText.Text = "";
                emailText.Text = "";
                cellPhoneText.Text = "";
            }
            else
            {
                MessageBox.Show("You need to fill in all the member fields");
            }

        }

        private bool ValidateForm()
        {
            bool output = true;

            if(firstNameText.Text.Length == 0)
                output = false;
            if (lastNameText.Text.Length == 0)
                output = false;
            if (emailText.Text.Length == 0)
                output = false;
            if (cellPhoneText.Text.Length == 0)
                output = false;

            return output;
        }

        private void addTeamMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel selectedTeamMember = (PersonModel)teamMembersDropDown.SelectedItem;

            if (selectedTeamMember != null)
            {
                availableMembersForTeamSelection.Remove(selectedTeamMember);
                selectedTeamMembers.Add(selectedTeamMember);

                WireupListBoxes(); 
            }
        }

        private void removeSelectedTeamMemberButton_Click(object sender, EventArgs e)
        {
            PersonModel memberToBeRemovedFromTeam = (PersonModel)teamMembersListBox.SelectedItem;

            if(memberToBeRemovedFromTeam != null)
            {
                selectedTeamMembers.Remove(memberToBeRemovedFromTeam);
                availableMembersForTeamSelection.Add(memberToBeRemovedFromTeam);

                WireupListBoxes();
            }
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            if (ValidateTeamForm())
            {
                var team = new TeamModel { Name = teamNameText.Text };
                team.Members = selectedTeamMembers;

                GlobalConfig.Connection.CreateTeam(team);

                teamNameText.Text = "";
                selectedTeamMembers = new List<PersonModel>();
                WireupListBoxes();
            }
            else
            {
                MessageBox.Show("Team Name and Team Members are needed for Team Creation");
            }

        }

        private bool ValidateTeamForm()
        {
            bool output = true;

            if(teamNameText.Text.Length == 0)
                output = false;

            if (teamMembersListBox.Items.Count == 0)
                output = false;

            return output;
        }
    }
}
