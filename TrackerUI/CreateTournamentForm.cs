﻿using System;
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
    public partial class CreateTournamentForm : Form,IPrizeRequester, ITeamRequester
    {
        List<TeamModel> AvailableTeams = GlobalConfig.Connection.GetTeam_ALL();
        List<TeamModel> SelectedTeams = new List<TeamModel>();
        List<PrizeModel> SelectedPrizes = new List<PrizeModel>();
        public CreateTournamentForm()
        {
            InitializeComponent();
            WireUpLists();
        }

        private void CreateTournamentForm_Load(object sender, EventArgs e)
        {

        }

        private void TeamOneScoreLabel_Click(object sender, EventArgs e)
        {

        }
        private void WireUpLists()
        {
            SelectTeamDropdown.DataSource = null;
            SelectTeamDropdown.DataSource = AvailableTeams;
            SelectTeamDropdown.DisplayMember = "TeamName";

            TournamentTeamsListbox.DataSource = null;
            TournamentTeamsListbox.DataSource = SelectedTeams;
            TournamentTeamsListbox.DisplayMember = "TeamName";

            PrizesListbox.DataSource = null;
            PrizesListbox.DataSource = SelectedPrizes;
            PrizesListbox.DisplayMember = "PlaceName";
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            
            TeamModel t = (TeamModel)SelectTeamDropdown.SelectedItem;
            if (t != null)
            {
                AvailableTeams.Remove(t);
                SelectedTeams.Add(t);
                WireUpLists();
            }
        }

        private void CreatePrizeButton_Click(object sender, EventArgs e)
        {
            //Call the Create Prize Form
            CreatePrizeForm frm = new CreatePrizeForm(this);
            frm.Show();
           
        }

        public void PrizeComplete(PrizeModel model)
        {
            //Get Back from the form a PrizeModel
            //Add the PrizeModel and put it to our list of selected Prizes
            SelectedPrizes.Add(model);
            WireUpLists();
        }

       

        private void CreateNewTeamLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateTeamForm frm = new CreateTeamForm(this);
            frm.Show();
        }
        public void TeamComplete(TeamModel model)
        {
            SelectedTeams.Add(model);
            WireUpLists();
        }
    }
}
