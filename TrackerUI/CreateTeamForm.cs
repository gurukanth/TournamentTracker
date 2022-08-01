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
        public CreateTeamForm()
        {
            InitializeComponent();
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

                GlobalConfig.Connection.CreatePerson(personModel);

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
    }
}
