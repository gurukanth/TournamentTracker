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
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequestor callingFrom;
        List<PrizeModel> existingPrizes = GlobalConfig.Connection.GetPrizes_All();
        public CreatePrizeForm(IPrizeRequestor caller)
        {
            InitializeComponent();
            callingFrom = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                PrizeModel model = new PrizeModel(
                    placeNumbertext.Text, 
                    placeNameText.Text, 
                    prizeAmountText.Text, 
                    prizePercentageText.Text);

                GlobalConfig.Connection.CreatePrize(model);
                callingFrom.PrizeComplete(model);

                this.Close();

/*                placeNumbertext.Text = "";
                placeNameText.Text = "";
                prizeAmountText.Text = "0";
                prizePercentageText.Text = "0";*/
            }
            else
            {
                MessageBox.Show("The form has invalid information!!.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            int placeNumber = 0;
            bool placeNumberValid = int.TryParse(placeNumbertext.Text, out placeNumber);

            if(! placeNumberValid)
                output = false;
            if(placeNumber < 1)
                output = false;

            if( placeNameText.Text.Length == 0 )
                output = false;

            decimal prizeAmount = 0;
            int prizePercentage = 0;
            bool prizeAmountValid = decimal.TryParse(prizeAmountText.Text, out prizeAmount);
            bool prizePercentageValid = int.TryParse(prizePercentageText.Text, out prizePercentage);

            if (prizeAmount < 0 && prizePercentage < 0)
                output = false;
            if (prizePercentage < 0 || prizePercentage > 100)
                output = false;


                return output;
        }

        private void CreatePrizeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
