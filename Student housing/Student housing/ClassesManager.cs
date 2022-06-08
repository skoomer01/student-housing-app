﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace Student_housing
{
    public class ClassesManager
    {
        Cleaning cleaning;
        ComplaintManager complaintManager;
        EventManager eventManager;
        Trash trash;
        ExpenseManager expenseManager;
        NormalExpense normalExpense;
        UserManager userManager;

        public ClassesManager()
        {
            DeSerializeObject();
            this.cleaning = new Cleaning(userManager);
            this.complaintManager = new ComplaintManager();
            this.eventManager = new EventManager();
            this.trash = new Trash(userManager);
            this.expenseManager = new ExpenseManager();
            this.normalExpense = new NormalExpense(userManager);
            
        }

        public void DeSerializeObject()
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                fs = new FileStream("../../../DataFiles/SaveData", FileMode.Open, FileAccess.Read);
                bf = new BinaryFormatter();
                this.userManager = (UserManager)bf.Deserialize(fs);

            }
            catch (Exception ex)
            { //MessageBox.Show(ex.Message);
             }
            finally
            { if (fs != null) fs.Close(); }
        }

        public  Cleaning Cleaning { get { return this.cleaning; } }
        public ComplaintManager ComplaintManager { get { return this.complaintManager; } }
        public EventManager EventManager { get { return this.eventManager; } }
        public Trash Trash { get { return this.trash; } }
        public ExpenseManager ExpenseManager { get { return this.expenseManager; } }
        public NormalExpense NormalExpense { get { return this.normalExpense; } }
        public UserManager UserManager { get { return this.userManager; } }
    }
}