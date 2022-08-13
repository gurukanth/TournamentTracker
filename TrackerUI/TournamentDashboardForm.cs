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
    public partial class TournamentDashboardForm : Form
    {
        private List<TournamentModel> existingTournaments = GlobalConfig.Connection.GetTournament_All();
        public TournamentDashboardForm()
        {
            InitializeComponent();
            WireupListBox();
        }

        private void WireupListBox()
        {
            existingTournamentsDropDown.DataSource = null;
            existingTournamentsDropDown.DataSource = existingTournaments;
            existingTournamentsDropDown.DisplayMember = "TournamentName";
        }

        private void TournamentDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel selectedTournament = (TournamentModel)existingTournamentsDropDown.SelectedItem;
            var tournamentViewer = new TournamentViewerForm(selectedTournament);
        }
    }
}
