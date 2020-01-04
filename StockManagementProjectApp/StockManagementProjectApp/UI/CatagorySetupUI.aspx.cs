using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.UI
{
    public partial class CatagorySetupUI : System.Web.UI.Page
    {
        CatagoryManager catagoryManager = new CatagoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            catagoryListGridView.DataSource = catagoryManager.GetAllCatagories();   //Loading the GridView
            catagoryListGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {

            if (catagoryTextBox.Text != "")                                  //Restricting Inserting NULL value
            {
                Catagory catagory = new Catagory();
                catagory.CatagoryName = catagoryTextBox.Text;
                outputLabel.Text = catagoryManager.SaveCatagory(catagory);
                catagoryTextBox.Text = String.Empty;
                Response.Redirect("CatagorySetupUI.aspx");                     //Redirecting to CatagorySetupUI
            }
            else
            {
                outputLabel.Text = "Enter a Valid Catagory Please...";
            }
        }

        protected void catagoryUpdateLinkButton_OnClick(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;                         //(Next 4 Line) To retrive a row from linkButton
            DataControlFieldCell cell = (DataControlFieldCell)linkButton.Parent;
            GridViewRow row = (GridViewRow)cell.Parent;
            HiddenField catagoryIdHiddenField =(HiddenField)row.FindControl("catagoryIdHiddenField");

            int id = Convert.ToInt32(catagoryIdHiddenField.Value);

            Response.Redirect("UpdateCatagoryUI.aspx?Id="+id);                  //Redirecting & Sending Query string
        }
    }
}