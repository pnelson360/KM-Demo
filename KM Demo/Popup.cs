using EllieMae.Encompass.Automation;
using EllieMae.Encompass.BusinessObjects.Loans.Logging;
using KM_Demo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KM_Demo
{
    public partial class Popup : Form
    {
        public Popup()
        {
            InitializeComponent();

            PopulateData();
        }
        public void PopulateData()
        {
            var source = new BindingSource();
            List<MilestonesSource> list = new List<MilestonesSource>();
           
            foreach (MilestoneEvent evn in EncompassApplication.CurrentLoan.Log.MilestoneEvents)
            {
                if (evn.LoanAssociate.User != null)
                {
                    MilestonesSource src = new MilestonesSource(evn.MilestoneName, evn.LoanAssociate.User.ID);
                    list.Add(src);
                }
            }

            source.DataSource = list;
            dataGridView1.DataSource = source;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.Columns[0].HeaderText = "Milestone Name";
            dataGridView1.Columns[1].HeaderText = "Assigned UserId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
