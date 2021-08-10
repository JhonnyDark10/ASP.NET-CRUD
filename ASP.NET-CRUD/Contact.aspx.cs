using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP.NET_CRUD
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection sqlCon = new SqlConnection(@"Data Source=BARCELONA;Initial Catalog=ASPCRUD;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                btn_delete.Enabled = false;
                FillGridView();
            }
        }

        protected void bnt_clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear(){
            hfContactID.Value = "";
            txt_name.Text = "";
            lblSuccefullMessagge.Text = lblerrorMessagge.Text = "";
            txt_mobile.Text = "";
            txt_address.Text = "";
            btn_save.Text = "Save";
            btn_delete.Enabled = false;
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ContactCreateOrUpdate",sqlCon);
           
            sqlCmd.CommandType = CommandType.StoredProcedure;
            
            sqlCmd.Parameters.AddWithValue("@ContactID", (hfContactID.Value==""?0:Convert.ToInt32(hfContactID.Value)));
            sqlCmd.Parameters.AddWithValue("@Name", txt_name.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Mobile", txt_mobile.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Adress", txt_address.Text.Trim());



            sqlCmd.ExecuteNonQuery();

            sqlCon.Close();

            string contacID = hfContactID.Value;

            Clear();

            if (contacID == "")
                lblSuccefullMessagge.Text = "Save Succefull";
            else
                lblerrorMessagge.Text = "Update";
            FillGridView();



        }


        void FillGridView() {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewAll", sqlCon);
            
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable dt = new DataTable();

            sqlDa.Fill(dt);
            sqlCon.Close();
            gvContact.DataSource = dt;
            gvContact.DataBind();

        }



        protected void lbl_clickV(object sender, EventArgs e) {

            int contacID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("ContactViewByID", sqlCon);

            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@ContactID", contacID);
            DataTable dt = new DataTable();

            sqlDa.Fill(dt);
            sqlCon.Close();


            hfContactID.Value = contacID.ToString();
            txt_name.Text = dt.Rows[0]["Name"].ToString();
            txt_mobile.Text = dt.Rows[0]["Mobile"].ToString();
            txt_address.Text = dt.Rows[0]["Adress"].ToString();

            btn_save.Text = "Updated";
            btn_delete.Enabled = true;
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ContactDeleteByID",sqlCon);

            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.AddWithValue("@ContactID",Convert.ToInt32(hfContactID.Value));

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            lblSuccefullMessagge.Text = "Delete Successufull";
        }
    }
}