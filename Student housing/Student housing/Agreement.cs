﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class Agreement
    {
        private static int autoIncId = 1;
        private int votes = 0;
        private int voters = 0;

        //constructor
        public Agreement(DateTime dateCreated, string studentsInvolved, string agreement)
        {
            this.Id = autoIncId;
            this.DateCreated = dateCreated;
            this.StudentsInvolved = studentsInvolved;
            this.AgreementDescription = agreement;
            this.Status = "Pending";
            this.VoterList = "->";
            autoIncId++;
        }

        //constructors for testdata
        public Agreement(DateTime dateCreated, string studentsInvolved, string agreement, string status)
        {
            this.Id = autoIncId;
            this.DateCreated = dateCreated;
            this.StudentsInvolved = studentsInvolved;
            this.AgreementDescription = agreement;
            this.Status = status;
            autoIncId++;
        }
        public Agreement(DateTime dateCreated, string studentsInvolved, string agreement, string status, int votes, int voters, string voterNames)
        {
            this.Id = autoIncId;
            this.DateCreated = dateCreated;
            this.StudentsInvolved = studentsInvolved;
            this.AgreementDescription = agreement;
            this.Status = status;
            this.votes = votes;
            this.voters = voters;
            this.VoterList = "->" + voterNames;
            autoIncId++;
            UpdateStatusVotes();
        }

        //properties
        public int Id { get; private set; }
        public DateTime DateCreated { get; private set; }
        public string StudentsInvolved { get; private set; }
        public string AgreementDescription { get; private set; }
        public string Status { get; private set; }
        public string VoterList { get; private set; }

        //methods
        public int GetVoters()
        {
            return this.voters;
        }

        public void UpdateStatus(string newStatus)
        {
            this.Status = newStatus;
        }

        public void IncreaseVotes(string voterName)
        {
            this.votes = this.votes + 1;
            this.voters = this.voters + 1;
            this.VoterList = this.VoterList + voterName;
        }

        public void DecreaseVotes(string voterName)
        {
            this.VoterList = this.VoterList + voterName;
            this.voters = this.voters + 1;
        }

        public void UpdateStatusVotes()
        {
            if (voters > 0)
            {
                this.Status = $"{CalculatePercentageVotes()}% agreed ({voters} voters)";
            }
        }

        public int CalculatePercentageVotes()
        {
            int percentage = (votes * 100) / voters;
            return percentage;
        }

        public void UpdateDescription(string newDescription)
        {
            this.AgreementDescription = newDescription;
        }



    }
}

