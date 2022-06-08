using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student_housing
{
    public partial class STUDENT : Form
    {
        //attributes that are objects
        private User currentUser;
        UserManager userManager;
        ExpenseManager expenseManager;
        ManageAgreements studentAgreement = ManageAgreements.Instance;
        Trash trash;
        Cleaning cleaning;
        NormalExpense normalExpenses; 
        private List<User> expenseMembers;
        EventManager eventManager = new EventManager();
        ComplaintManager complaintManager;

        //initialization for indexes for cleaning
        int indexUserKitchen = 0;
        int indexUserBathroom = 0;
        int indexUserToilet = 0;
        int indexUserSharedSpace = 0;

        //initialization for indexes for expenses
        int indexSharedKitchenItems = 0;
        int indexSharedBathroomItems = 0;
        int indexSharedToiletPaper = 0;
        int indexSharedDishSoap = 0;


        //Constructor(s)
        public STUDENT()
        {
            InitializeComponent();
            this.currentUser = userManager.getCurrentStudent();
            
            UpdateUI();
        }

        public STUDENT(UserManager userManager, User currentUser, ExpenseManager expenseManager, Trash trash, Cleaning cleaning, NormalExpense normalExpense, EventManager eventManager, ComplaintManager compla)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.userManager = userManager;
            this.trash = new Trash(userManager);
            this.cleaning = new Cleaning(userManager);
            this.normalExpenses = new NormalExpense(userManager);
            this.expenseManager = new ExpenseManager();
            this.complaintManager = new ComplaintManager();
            UpdateUI();
        }

        private void STUDENT_Load(object sender, EventArgs e)
        {
            //Design code
            tcStudent.Appearance = TabAppearance.FlatButtons;
            tcStudent.ItemSize = new Size(0, 1);
            tcStudent.SizeMode = TabSizeMode.Fixed;
            buttonPannel.Height = btnRulesTab.Height;
            buttonPannel.Top = btnRulesTab.Top;


            //Initialize the turn based lists 
            tbxUserTrash.Text = trash.GetUser();

            tbxCleaningBathroom.Text = cleaning.AddUsers(0);
            tbxCleaningKitchen.Text = cleaning.AddUsers(0);
            tbxCleaningShared.Text = cleaning.AddUsers(0);
            tbxCleaningToilet.Text = cleaning.AddUsers(0);

            cbxItemsSoap.Text = normalExpenses.AddTenants(0);
            cbxItemsToilet.Text = normalExpenses.AddTenants(0);
            cbxItemsBathroom.Text = normalExpenses.AddTenants(0);
            cbxItemsKitchen.Text = normalExpenses.AddTenants(0);

            foreach (User u in userManager.GetUsers())
            {
                cbExpenseMembers.Items.Add(u.Username);
            }

            lblTitle.Text = "Welcome back, " + currentUser.Username + "!";

            LoadFromFile("Rules");
            LoadFromFile("Guidelines");
        }

        public void UpdateUI()//mai eficient sa le apelezi fara sa creezi metoda update ui?
        {
            // Show agreements
            UpdateAgreementsDgv();
            RefreshComboboxNames();
            FillComplaintCbx();
        }

        #region <Rules and guidelines>

        public void LoadFromFile(string filename)
        {
            FileStream fs = null;
            StreamReader sr = null;

            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
                fs.Seek(0, SeekOrigin.Begin);
                sr = new StreamReader(fs);
                if (filename == "Rules")
                {
                    rtbStudentRules.Text = sr.ReadToEnd();
                }
                else
                {
                    rtbStudentGuidelines.Text = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
        }

        #endregion

        #region <Agreements>
        private void UpdateAgreementsDgv()
        {
            List<Agreement> agreements = studentAgreement.GetAgreementsList();
            dgvAgreementsStudent.Rows.Clear();

            foreach (var agreement in agreements)
            {
                if (agreement.StudentsInvolved.Contains(currentUser.Username) || agreement.StudentsInvolved.Contains("Everyone"))
                {
                    DataGridViewRow row = (DataGridViewRow)dgvAgreementsStudent.Rows[0].Clone();

                    row.Cells[0].Value = agreement.Id.ToString();
                    row.Cells[1].Value = (agreement.DateCreated.ToString("dd/MM/yyyy")).ToString();
                    row.Cells[2].Value = agreement.StudentsInvolved;
                    row.Cells[3].Value = agreement.AgreementDescription;
                    row.Cells[4].Value = agreement.Status;

                    dgvAgreementsStudent.Rows.Add(row);
                }

                dgvAgreementsStudent.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvAgreementsStudent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void btn_AgreementAcceptSelected_Click_1(object sender, EventArgs e)
        {
            if (dgvAgreementsStudent.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Please select an agreement.");
            }
            else
            {
                string status = dgvAgreementsStudent.CurrentRow.Cells[4].Value.ToString();
                if (status == "Pending" || status.Contains("voters"))
                {
                    string involvedStudents = dgvAgreementsStudent.CurrentRow.Cells[2].Value.ToString();
                    int selectedAgreementId = Convert.ToInt32(dgvAgreementsStudent.CurrentRow.Cells[0].Value);

                    if (involvedStudents.Contains("& " + currentUser.Username))
                    {
                        studentAgreement.SendAcceptToPrivateAgreement(selectedAgreementId);
                        UpdateAgreementsDgv();
                        MessageBox.Show("Successfully agreed to the agreement request.");
                    }
                    if (involvedStudents.Contains("& Everyone"))
                    {
                        int oldVoterAmount = studentAgreement.GetAgreementVoters(selectedAgreementId);
                        studentAgreement.SendAcceptToPublicAgreement(selectedAgreementId, currentUser.Username);
                        int newVoterAmount = studentAgreement.GetAgreementVoters(selectedAgreementId);

                        if (oldVoterAmount < newVoterAmount)
                        {
                            UpdateAgreementsDgv();
                            MessageBox.Show("Successfully agreed to the agreement request.");
                        }
                        if (oldVoterAmount == newVoterAmount)
                        {
                            MessageBox.Show("You already voted for this agreement.");
                        }
                    }
                    if (involvedStudents.Contains(currentUser.Username + " &") && !involvedStudents.Contains("Everyone"))
                    {
                        MessageBox.Show("You can't accept an agreement initiated by yourself.");
                    }
                }
                if (status == "Accepted")
                {
                    MessageBox.Show("This agreement has already been accepted.");
                }
                if (status == "Rejected")
                {
                    MessageBox.Show("This agreement has already been rejected.");
                }
            }
        }

        private void RefreshComboboxNames()
        {
            cbAgreement.Items.Clear();

            foreach (User user in userManager.GetUsers())
            {
                if (user.Username != currentUser.Username)
                {
                    cbAgreement.Items.Add(user.Username);
                }

            }

            cbAgreement.Items.Add("Everyone");
        }

        private void btn_AgreementRejectSelected_Click(object sender, EventArgs e)
        {
            if (dgvAgreementsStudent.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Please select an agreement.");
            }
            else
            {
                string status = dgvAgreementsStudent.CurrentRow.Cells[4].Value.ToString();
                if (status == "Pending" || status.Contains("voters"))
                {
                    string involvedStudents = dgvAgreementsStudent.CurrentRow.Cells[2].Value.ToString();
                    int selectedAgreementId = Convert.ToInt32(dgvAgreementsStudent.CurrentRow.Cells[0].Value);

                    if (involvedStudents.Contains("& " + currentUser.Username))
                    {
                        studentAgreement.SendRejectToPrivateAgreement(selectedAgreementId);
                        UpdateAgreementsDgv();
                        MessageBox.Show("Successfully rejected the agreement request.");
                    }
                    if (involvedStudents.Contains("& Everyone"))
                    {
                        int oldVoterAmount = studentAgreement.GetAgreementVoters(selectedAgreementId);
                        studentAgreement.SendRejectToPublicAgreement(selectedAgreementId, currentUser.Username);
                        int newVoterAmount = studentAgreement.GetAgreementVoters(selectedAgreementId);

                        if (oldVoterAmount < newVoterAmount)
                        {
                            UpdateAgreementsDgv();
                            MessageBox.Show("Successfully rejected the agreement request.");
                        }
                        if (oldVoterAmount == newVoterAmount)
                        {
                            MessageBox.Show("You already voted for this agreement.");
                        }
                    }
                    if (involvedStudents.Contains(currentUser.Username + " &") && !involvedStudents.Contains("Everyone"))
                    {
                        MessageBox.Show("You can't reject an agreement initiated by yourself.");
                    }
                }
                if (status == "Accepted")
                {
                    MessageBox.Show("This agreement has already been accepted.");
                }
                if (status == "Rejected")
                {
                    MessageBox.Show("This agreement has already been rejected.");
                }
            }
        }

        private void btn_AgreementEditSelected_Click(object sender, EventArgs e)
        {
            if (dgvAgreementsStudent.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Please select an agreement to be edited");
            }
            else
            {
                string status = dgvAgreementsStudent.CurrentRow.Cells[4].Value.ToString();
                string involvedStudents = dgvAgreementsStudent.CurrentRow.Cells[2].Value.ToString();
                int selectedAgreementId = Convert.ToInt32(dgvAgreementsStudent.CurrentRow.Cells[0].Value);
                int voterAmount = studentAgreement.GetAgreementVoters(selectedAgreementId);

                if (status == "Pending" || status == "Rejected" || status.Contains("voters"))
                {
                    if (involvedStudents.Contains(currentUser.Username + " &") && voterAmount == 0)
                    {
                        studentAgreement.EditAgreementDescription(selectedAgreementId, tbNewAgreementDescription.Text);
                        MessageBox.Show("Your agreement was successfully edited.");
                        UpdateAgreementsDgv();
                    }
                    if (involvedStudents.Contains(currentUser.Username + " &") && voterAmount > 0)
                    {
                        MessageBox.Show("You can't edit an agreement that has one or more votes.");
                    }
                    if (!involvedStudents.Contains(currentUser.Username + " &"))
                    {
                        MessageBox.Show("You can't edit someone else's agreement.");
                    }
                }
                if (status == "Accepted")
                {
                    MessageBox.Show("You can't edit an agreement that has already been accepted.");
                }
            }
        }

        private void btn_AgreementDeleteSelected_Click(object sender, EventArgs e)
        {
            if (dgvAgreementsStudent.SelectedCells.Count <= 0)
            {
                MessageBox.Show("Please select a agreement to be removed");
            }
            else
            {
                string status = dgvAgreementsStudent.CurrentRow.Cells[4].Value.ToString();
                string involvedStudents = dgvAgreementsStudent.CurrentRow.Cells[2].Value.ToString();
                int selectedAgreementId = Convert.ToInt32(dgvAgreementsStudent.CurrentRow.Cells[0].Value);

                if (status == "Pending" || status == "Rejected")
                {
                    if (involvedStudents.Contains(currentUser.Username + " &"))
                    {
                        studentAgreement.RemoveAgreementById(selectedAgreementId);
                        MessageBox.Show("Your agreement was successfully removed.");
                        UpdateAgreementsDgv();
                    }
                    else
                    {
                        MessageBox.Show("You can't remove someone else's agreement.");
                    }
                }
                if (status.Contains("voters"))
                {
                    int percentageAgreed = studentAgreement.GetAgreementVotesPercentage(selectedAgreementId);
                    if (involvedStudents.Contains(currentUser.Username + " &") && percentageAgreed >= 50)
                    {
                        MessageBox.Show("You can't remove an agreement that has over 50% of the votes.");
                    }
                    if (!involvedStudents.Contains(currentUser.Username + " &"))
                    {
                        MessageBox.Show("You can't remove someone else's agreement.");
                    }
                    if (involvedStudents.Contains(currentUser.Username + " &") && percentageAgreed <= 49)
                    {
                        studentAgreement.RemoveAgreementById(selectedAgreementId);
                        MessageBox.Show("Your agreement was successfully removed.");
                        UpdateAgreementsDgv();
                    }
                }
                if (status == "Accepted")
                {
                    MessageBox.Show("Can't remove an agreement that has already been accepted.");
                }
            }
        }

        private void btnAgreementSubmit_Click(object sender, EventArgs e)
        {
            string agreementDescription = tbNewAgreementDescription.Text;
            DateTime date = DateTime.Now;
            string otherStudent = (string)cbAgreement.SelectedItem;
            string involvedStudents = currentUser.Username + " & " + otherStudent;

            if ((otherStudent == "") && (agreementDescription == ""))
            {
                MessageBox.Show("Please fill in a description and select the person involved first.");
            }
            if ((otherStudent != "") && (agreementDescription == ""))
            {
                MessageBox.Show("Please fill in a description.");
            }
            if ((otherStudent == "") && (agreementDescription != ""))
            {
                MessageBox.Show("Select the person to have an agreement with first.");
            }
            if ((otherStudent != "") && (agreementDescription != ""))
            {
                if (otherStudent != currentUser.Username)
                {
                    studentAgreement.CreateAgreement(date, involvedStudents, agreementDescription);
                    UpdateAgreementsDgv();
                    MessageBox.Show("Successfully added new pending agreement.");
                }
                else
                {
                    MessageBox.Show("You can't make an agreement with yourself."); // might delete.
                }
            }

        }
        private void dgvAgreementsStudent_CurrentCellChanged1(object sender, EventArgs e)
        {
            try
            {
                string description = dgvAgreementsStudent.CurrentRow.Cells[3].Value.ToString();
                tbNewAgreementDescription.Text = description;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        #endregion <Agreements>

        #region <Trash task>
        //All the buttons for the trash task
        private void btn_TrashThrown_Click(object sender, EventArgs e)
        {
            if (currentUser.Username == tbxUserTrash.Text)
            {
                tbxUserTrash.Text = trash.GetUser();
            }
            else
            {
                if (cbx_TrashForSomeoneElse.Checked)
                {
                    tbxUserTrash.Text = trash.GetUser();
                    cbx_TrashForSomeoneElse.Checked = false;
                }
                else
                {

                }
            }
        }

        private void btn_NotifyTrash_Click(object sender, EventArgs e)
        {
            User user = new User(Convert.ToString(tbxUserTrash.Text), "");
            //creates an object for the notification
        }
        #endregion <Trash task>

        #region <Cleaning task>
        //All the buttons for the cleaning task
        private void btnTaskComplete_Click(object sender, EventArgs e)
        {
            if (cbxCleaningBathroom.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningBathroom.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    cbxCleaningForSmnElse.Checked = false;
                    cbxCleaningBathroom.Checked = false;
                    indexUserBathroom++;
                    tbxCleaningBathroom.Text = cleaning.AddUsers(indexUserBathroom);
                    lblCleaningBathroom.Text = "Bathroom";
                }
            }

            if (cbxCleaningKitchen.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningKitchen.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    cbxCleaningForSmnElse.Checked = false;
                    cbxCleaningKitchen.Checked = false;
                    indexUserKitchen++;
                    tbxCleaningKitchen.Text = cleaning.AddUsers(indexUserKitchen);
                    lblCleaningKitchen.Text = "Kitchen";
                }
            }

            if (cbxCleaningToilet.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningToilet.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    cbxCleaningForSmnElse.Checked = false;
                    cbxCleaningToilet.Checked = false;
                    indexUserToilet++;
                    tbxCleaningToilet.Text = cleaning.AddUsers(indexUserToilet);
                    lblCleaningToilet.Text = "Toilet";
                }
            }

            if (cbxCleaningShared.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningShared.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    cbxCleaningForSmnElse.Checked = false;
                    cbxCleaningShared.Checked = false;
                    indexUserSharedSpace++;
                    tbxCleaningShared.Text = cleaning.AddUsers(indexUserSharedSpace);
                    lblCleaningShared.Text = "Shared space";
                }
            }
        }

        private void btnTaskPending_Click(object sender, EventArgs e)
        {
            if (cbxCleaningBathroom.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningBathroom.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    if (cbxCleaningForSmnElse.Checked == true)
                    {
                        //notification to be added
                    }
                    else
                    {
                        User user = new User(Convert.ToString(tbxCleaningBathroom.Text), "");
                        //notification to be added
                    }

                    lblCleaningBathroom.Text = "Bathroom (pending)";

                }
            }

            if (cbxCleaningKitchen.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningKitchen.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    if (cbxCleaningKitchen.Checked == true)
                    {
                        //notification to be added
                    }
                    else
                    {
                        User user = new User(Convert.ToString(tbxCleaningKitchen.Text), "");
                        //notification to be added
                    }

                    lblCleaningKitchen.Text = "Kitchen (pending)";

                }
            }

            if (cbxCleaningToilet.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningToilet.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    if (cbxCleaningToilet.Checked == true)
                    {
                        //notification to be added
                    }
                    else
                    {
                        User user = new User(Convert.ToString(tbxCleaningToilet.Text), "");
                        //notification to be added
                    }

                    lblCleaningToilet.Text = "Toilet (pending)";

                }
            }

            if (cbxCleaningShared.Checked == true)
            {
                if ((currentUser.Username == tbxCleaningShared.Text) || (cbxCleaningForSmnElse.Checked == true))
                {
                    if (cbxCleaningShared.Checked == true)
                    {
                        //notification to be added
                    }
                    else
                    {
                        User user = new User(Convert.ToString(tbxCleaningShared.Text), "");
                        //notification to be added

                    }

                    lblCleaningShared.Text = "Shared Space (pending)";

                }
            }
        }
        #endregion <Cleaning task>

        #region <Normal Expenses>
        //Methods

        private void UpdateListBox()
        {
            lbExpenses.Items.Clear();
            foreach (User u in expenseMembers)
            {
                lbExpenseMembers.Items.Add(u.Username);
            }
            foreach (NormalExpense e in expenseManager.GetExpenses())
            {
                if (e.Members.Contains(currentUser) && !e.MembersWhoPaid.Contains(currentUser))
                {
                    lbExpenses.Items.Add($"{e.Title}, Total: {e.Total}, You owe: {e.AmountToBePaidPerMember}");
                }
            }
            var expenses = expenseManager.GetExpenses();
        }
        private void ClearExpenseInputs()
        {
            txtBoxExpenseTitle.Clear();
            txtBoxTotal.Clear();
            lbExpenseMembers.Items.Clear();
            expenseMembers.Clear();
        }

        //All the buttons for the normal expenses
        private void btn_Bought_Click(object sender, EventArgs e)
        {
            if (cbxItemsSoap.Checked == true)
            {
                indexSharedDishSoap++;
                tbxSharedItemsSoap.Text = normalExpenses.AddTenants(indexSharedDishSoap);
            }
            if (cbxItemsToilet.Checked == true)
            {
                indexSharedToiletPaper++;
                tbxSharedItemsToilet.Text = normalExpenses.AddTenants(indexSharedToiletPaper);
            }
            if (cbxItemsBathroom.Checked == true)
            {
                indexSharedBathroomItems++;
                tbxSharedItemsBath.Text = normalExpenses.AddTenants(indexSharedBathroomItems);
            }
            if (cbxItemsKitchen.Checked == true)
            {
                indexSharedKitchenItems++;
                tbxSharedItemsKitchen.Text = normalExpenses.AddTenants(indexSharedKitchenItems);
            }
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            expenseMembers = new List<User>();
            User[] users = userManager.GetUsers();
            string username = cbExpenseMembers.SelectedItem.ToString();
            User foundUser = userManager.getUser(username);
            if (!expenseMembers.Contains(foundUser))
                expenseMembers.Add(foundUser);
            UpdateListBox();
        }

        private void btn_BoughtReport_Click(object sender, EventArgs e)
        {
            //notification to be added
        }

        private void btnRemoveMember_Click(object sender, EventArgs e)
        {
            expenseMembers = new List<User>();
            User[] users = userManager.GetUsers();
            string username = cbExpenseMembers.Text;
            User foundUser = userManager.getUser(username);
            if (!expenseMembers.Contains(foundUser))
                expenseMembers.Remove(foundUser);
            lbExpenseMembers.Items.Clear();
            UpdateListBox();
        }
        private void btnCreateExpense_Click(object sender, EventArgs e)
        {
            var total = double.Parse(txtBoxTotal.Text);
            var title = txtBoxExpenseTitle.Text;

            expenseMembers.Add(currentUser);
            var expense = new NormalExpense(expenseManager.GetExpenses().Count, total, currentUser, title, new List<User>(expenseMembers));
            expenseManager.AddExpense(expense);
            lbExpenseMembers.Items.Clear();
            ClearExpenseInputs();
            UpdateListBox();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            NormalExpense expense = expenseManager.GetExpenses()[lbExpenses.SelectedIndex];
            expense.Pay(currentUser);
            var index = expenseManager.GetExpenses().FindIndex(exp => exp.expenseID == expense.expenseID);
            expenseManager.GetExpenses()[index] = expense;
            expenseManager.SetExpenses(expenseManager.GetExpenses());
            MessageBox.Show("Success!");
        }

        #endregion <Normal Expenses>

        #region <Events>
        private void ShowEvents()
        {
            lbxShowUpcomingEvents.Items.Clear();
            foreach (Events newEvent in eventManager.GetEvents())
            {
                lbxShowUpcomingEvents.Items.Add(newEvent.GetEventInfo());
            }
        }

        private void AddEvent()
        {
            foreach (Events newEvent in eventManager.GetEvents())
            {
                lbxShowUpcomingEvents.Items.Add(newEvent.GetEventInfo());
            }
        }

        private void btnPlanTheParty_Click(object sender, EventArgs e)
        {
            int day = Convert.ToInt32(dudPartyDay.Text);
            int month = Convert.ToInt32(dudPartyMonth.Text);
            int year = Convert.ToInt32(dudPartyYear.Text);
            string description = Convert.ToString(rtxDescription.Text);

            if (month == 2 && day > 28)
            {
                MessageBox.Show("Please select a valid date");
            }
            else if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
            {
                MessageBox.Show("Please select a valid date");
            }
            else
            {
                DateTime date = new DateTime(year, month, day);
                Events newEvent;
                if (description == "")
                {
                    newEvent = new Events(date, currentUser);
                }
                else
                {
                    newEvent = new Events(date, currentUser, description);
                }
                eventManager.AddEvent(newEvent);
            }
            ShowEvents();
        }

        private void btnTodayEvent_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            Events newEvent;
            string description = Convert.ToString(rtxDescription.Text);

            if (description == "")
            {
                newEvent = new Events(date, currentUser);
            }
            else
            {
                newEvent = new Events(date, currentUser, description);
            }
            eventManager.AddEvent(newEvent);
            ShowEvents();
        }

        private void btnRemoveParty_Click(object sender, EventArgs e)
        {
            int selectedIndex = lbxShowUpcomingEvents.SelectedIndex;
            if (selectedIndex > -1)
            {
                eventManager.RemoveEvent(selectedIndex);
            }
            else
            {
                MessageBox.Show("Please select the party you want removed");
            }
            ShowEvents();
        }

        async void DisableButtons(int seconds)
        {
            btnPlanTheParty.Enabled = false;
            btnRemoveParty.Enabled = false;
            btnTodayEvent.Enabled = false;
            btnNoEventThisWeek.Enabled = false;
            await Task.Delay(1000 * seconds);
            btnPlanTheParty.Enabled = true;
            btnRemoveParty.Enabled = true;
            btnTodayEvent.Enabled = true;
            btnNoEventThisWeek.Enabled = true;
        }

        private void btnNoEventThisWeek_Click(object sender, EventArgs e)
        {
            Events noEvent = new Events("No event today");
            eventManager.AddEvent(noEvent);
            ShowEvents();
            DisableButtons(100);
        }
        #endregion <Events>

        #region <TabControl Design>
        private void btnRulesTab_Click(object sender, EventArgs e)
        {
            tcStudent.SelectedTab = tpRules;
            buttonPannel.Height = btnRulesTab.Height;
            buttonPannel.Top = btnRulesTab.Top;
        }

        private void btnTasksTab_Click(object sender, EventArgs e)
        {
            tcStudent.SelectedTab = tpTasks;
            buttonPannel.Height = btnTasksTab.Height;
            buttonPannel.Top = btnTasksTab.Top;
        }

        private void btnAgreementsTab_Click(object sender, EventArgs e)
        {
            tcStudent.SelectedTab = tpAgreements;
            buttonPannel.Height = btnAgreementsTab.Height;
            buttonPannel.Top = btnAgreementsTab.Top;
        }

        private void btnComplaintsTab_Click(object sender, EventArgs e)
        {
            tcStudent.SelectedTab = tpComplaint;
            buttonPannel.Height = btnComplaintsTab.Height;
            buttonPannel.Top = btnComplaintsTab.Top;
        }

        private void btnEventsTab_Click(object sender, EventArgs e)
        {
            tcStudent.SelectedTab = tpEvents;
            buttonPannel.Height = btnEventsTab.Height;
            buttonPannel.Top = btnEventsTab.Top;
        }

        private void btnTechnicalTab_Click(object sender, EventArgs e)
        {
            tcStudent.SelectedTab = tpTechnical;
            buttonPannel.Height = btnTechnicalTab.Height;
            buttonPannel.Top = btnTechnicalTab.Top;
        }

        #endregion <TabControl Design>

        #region <Complaints>
        private void btnPostComplaint_Click(object sender, EventArgs e)
        {
            string complaintText = rtxComplaintText.Text.ToString();
            if(complaintText == "" )
            {
                MessageBox.Show("You can't send an empty complaint");
            }
            else
            {
                User complaintUser = userManager.getUser(cbxComplaintUser.Text.ToString());
                Complaint newComplaint = new Complaint(complaintUser, complaintText,currentUser, userManager);
                complaintManager.AddNewComplaint(newComplaint);
                MessageBox.Show("Complaint sent to Administrator");
            }
            rtxComplaintText.Clear();

        }

        public void FillComplaintCbx()
        {
            foreach(User user in userManager.GetUsers())
            {
                if(user.Username != currentUser.Username)
                {
                    cbxComplaintUser.Items.Add(user.Username);
                }
            }
        }
        #endregion <Complaints>
        private void pbLogOut_Click(object sender, EventArgs e)
        {
            LOGIN loginform = new LOGIN(currentUser, userManager, complaintManager, eventManager, cleaning, trash, expenseManager, normalExpenses);
            loginform.Show();
            this.Close();
        }

    }
}