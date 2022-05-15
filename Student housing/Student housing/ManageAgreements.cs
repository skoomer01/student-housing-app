using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class ManageAgreements
    {
        private List<Agreement> agreements = new List<Agreement>();
        private List<User> users = new List<User>();
        private Agreement agreement;
        private User student;
        private static ManageAgreements instance = null;

        public static ManageAgreements Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ManageAgreements();
                }
                return instance;
            }
        }
        public void CreateAgreement(DateTime currentDate, string involvedStudents, string agreementDesc)
        {
            agreement = new Agreement(currentDate, involvedStudents, agreementDesc);
            AddAgreementToList(agreement);
        }

        private void AddAgreementToList(Agreement agreement)
        {
            agreements.Add(agreement);
        }

        public List<Agreement> GetAgreementsList()
        {
            return agreements;
        }

    
        // Remove agreement
        public void RemoveAgreementById(int id)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements.Remove(agreements[i]);
                }
            }
        }

        // Accepting / Rejecting agreements
        public void SendAcceptToPrivateAgreement(int id) // where involved is currentuser only.
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements[i].UpdateStatus("Accepted");
                }
            }
        }

        public void SendRejectToPrivateAgreement(int id) // where involved is currentuser only.
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements[i].UpdateStatus("Rejected");
                }
            }
        }

        public void SendAcceptToPublicAgreement(int id, string studentWhoVoted) // where involved is "Everyone".
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    string voters = agreements[i].VoterList;
                    if (!voters.Contains(studentWhoVoted))
                    {
                        agreements[i].IncreaseVotes(studentWhoVoted);
                        agreements[i].UpdateStatusVotes();
                    }
                }
            }
        }

        public void SendRejectToPublicAgreement(int id, string studentWhoVoted) // where involved is "Everyone".
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    string voters = agreements[i].VoterList;
                    if (!voters.Contains(studentWhoVoted))
                    {
                        agreements[i].DecreaseVotes(studentWhoVoted);
                        agreements[i].UpdateStatusVotes();
                    }
                }
            }
        }

        // Get amount of voters for checking if voting passed or failed.
        public int GetAgreementVoters(int id)
        {
            int voters = 0;
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    voters = agreements[i].GetVoters();
                }
            }
            return voters;
        }

        // Get percentage of voters
        public int GetAgreementVotesPercentage(int id)
        {
            int percentage = 0;
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    percentage = agreements[i].CalculatePercentageVotes();
                }
            }
            return percentage;
        }

        public void EditAgreementDescription(int id, string newDescription)
        {
            for (int i = 0; i < agreements.Count; i++)
            {
                if (agreements[i].Id == id)
                {
                    agreements[i].UpdateDescription(newDescription);
                }
            }
        }
        public List<string> getNames()
        {
            List<string> usernames = new List<string>();
            foreach (User user in users)
            {
                usernames.Add(user.GetUsername());
            }
            return usernames;
        }
    }
}

