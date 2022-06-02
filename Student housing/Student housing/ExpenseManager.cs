using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_housing
{
    internal class ExpenseManager
    {
        List<NormalExpense> expenses;

        public ExpenseManager()
        {
            expenses = new List<NormalExpense>();
        }

        public void AddExpense(NormalExpense e)
        {
            this.expenses.Add(e);
        }

        public List<NormalExpense> GetExpenses()
        {
            return this.expenses;
        }

        public void SetExpenses(List<NormalExpense> expenses)
        {
            this.expenses = expenses;
        }
    }
}
