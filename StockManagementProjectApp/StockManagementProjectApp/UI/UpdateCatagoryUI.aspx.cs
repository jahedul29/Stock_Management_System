using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementProjectApp.DAL.Modals;
using Convert = System.Convert;

namespace StockManagementProjectApp.UI
{
    public partial class UpdateCatagoryUI : System.Web.UI.Page
    {
        CatagoryManager catagoryManager = new CatagoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)                                        //Condition for executing the code only only First load
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);        //Retriving Id from Query string
                Catagory catagory = catagoryManager.GetCatagoryById(id);
                idHiddenField.Value = catagory.Id.ToString();
                catagoryTextBox.Text = catagory.CatagoryName;   
            }
            
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (catagoryTextBox.Text!= null)                                //Restricting Inserting NULL value
            {
                Catagory catagory = new Catagory();
                catagory.Id = Convert.ToInt32(idHiddenField.Value);
                catagory.CatagoryName = catagoryTextBox.Text;
                outputLabel.Text = catagoryManager.UpdateCatagoryById(catagory);
                catagoryTextBox.Text = String.Empty;
            }
            else
            {
                outputLabel.Text = "Enter a valid catagory please";
            }

        }
    }
}