using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    public class ComplaintManager
    {
        //attributes
        private List<Complaint> complaints;
        private List<Complaint> revisedComplaints;

        //constructor
        public ComplaintManager()
        {
            this.complaints = new List<Complaint>();
            this.revisedComplaints = new List<Complaint>();
        }

        //properties
        public List<Complaint> Complaints
        {
            get { return this.complaints; }
        }

        public List<Complaint> RevisedComplaints
        {
            get { return this.revisedComplaints; }
        }

        //methods
        public void AddNewComplaint(Complaint complaint)
        {
            complaints.Add(complaint);
        }

        public void AddRevisedComplaint(Complaint complaint)
        {
            revisedComplaints.Add(complaint);
        }

        public void RemoveComplaint(Complaint complaint)
        {
            foreach (Complaint complaint1 in complaints)
            {
                if (complaint == complaint1)
                {
                    complaints.Remove(complaint);
                }
            }
        }

    }
}
