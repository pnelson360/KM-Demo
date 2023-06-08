using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans;
using EllieMae.Encompass.ComponentModel;

namespace KM_Demo
{
    [Plugin]
    public class KM_Demo
    {
        public KM_Demo()
        {
            EncompassApplication.LoanOpened += new EventHandler(LoanOpen);
            EncompassApplication.LoanClosing -= new EventHandler(LoanClose);
        }
        private void LoanOpen(object sender, EventArgs e)
        {
            EncompassApplication.CurrentLoan.FieldChange += new FieldChangeEventHandler(FieldChange);
        }
        private void LoanClose(object sender, EventArgs e)
        {
            EncompassApplication.CurrentLoan.FieldChange -= new FieldChangeEventHandler(FieldChange);
        }
        private void FieldChange(object sender, FieldChangeEventArgs e)
        {
            Loan l = EncompassApplication.CurrentLoan;

            if(e.FieldID == "CX.KM.1" && e.NewValue == "show")
            {
                Popup pop = new Popup();
                pop.Show();
                l.Fields["CX.KM.1"].Value = "";
            }
            if(e.FieldID == "CX.KM.2" && e.NewValue != "")
            {
                List<string> borrower = new List<string>();

                foreach(BorrowerPair bp in l.BorrowerPairs)
                {
                    borrower.Add(bp.Borrower.FirstName);
                    if (bp.CoBorrower.FirstName != "")
                        borrower.Add(bp.CoBorrower.FirstName);
                }
                string borrowers = string.Join(", ", borrower);
                MessageBox.Show(borrowers);
            }
        }
    }
}
