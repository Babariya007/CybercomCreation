using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace queue_or_stack
{
    public partial class queue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TokenQueue"] == null)
            {
                Queue<int> queueTokens = new Queue<int>();
                Session["TokenQueue"] = queueTokens;
            }
        }

        protected void btnPrintToken_Click(object sender, EventArgs e)
        {
            Queue<int> tokenQueue = (Queue<int>)Session["TokenQueue"];
            lblStatus.Text = "There are " + tokenQueue.Count.ToString() + " customers in queue";

            if (Session["LastTokenNumberIssued"] == null)
            {
                Session["LastTokenNumberIssued"] = 0;
            }

            int nextToken = (int)Session["LastTokenNumberIssued"] + 1;
            Session["LastTokenNumberIssued"] = nextToken;
            tokenQueue.Enqueue(nextToken);
            AddTokenToList(tokenQueue);
        }

        private void AddTokenToList(Queue<int> tokenQueue)
        {
            listToken.Items.Clear();
            foreach (int token in tokenQueue)
            {
                listToken.Items.Add(token.ToString());
            }
        }

        private void ServeNextCustomer(TextBox txtbox, int counterNumber)
        {
            Queue<int> tokenQueue = (Queue<int>)Session["TokenQueue"];
            if(tokenQueue.Count == 0)
            {
                txtbox.Text = "No customer in Queue";
            }
            else
            {
                int tokenNumberToSave = tokenQueue.Dequeue();
                txtbox.Text = tokenNumberToSave.ToString();
                txtDisplay.Text = "Token Number " + tokenNumberToSave.ToString() + "Please goto Counter " + counterNumber.ToString();
                AddTokenToList(tokenQueue);
            }
        }

        protected void btnCounter1_Click(object sender, EventArgs e)
        {
            ServeNextCustomer(txtCounter1, 1);
        }

        protected void btnCounter2_Click(object sender, EventArgs e)
        {
            ServeNextCustomer(txtCounter2, 2);
        }

        protected void btnCounter3_Click(object sender, EventArgs e)
        {
            ServeNextCustomer(txtCounter3, 3);
        }
    }
}