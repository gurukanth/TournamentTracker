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
    public partial class TournamentViewerForm : Form
    {
        public TournamentViewerForm(TournamentModel tournament)
        {
            LoadTorunamentFully(tournament);
            InitializeComponent();
        }

        private void LoadTorunamentFully(TournamentModel tournament)
        {
            GlobalConfig.Connection.Load_Tournament(tournament);
        }

        private void TournamentViewerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
