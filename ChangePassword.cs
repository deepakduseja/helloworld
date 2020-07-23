using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace InventoryERPApplication
{
    public partial class ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlConnection connstring;
        SqlDataAdapter da;
        SqlDataReader dr;
        //   DataTable dt = new DataTable();
        int i, no = 0;
        string query;
        SqlConnection con;
        SqlCommand cmd;
        Connection c = new Connection();
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (USERNAME.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, "Enter the User Name !!!", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                USERNAME.Focus();
                return;
            }
            if (NEW.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, "Enter the New Password !!!", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                NEW.Focus();
                return;
            }
            if (OLD.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, "Enter the Confirm Password !!!", ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                OLD.Focus();
                return;
            }
            try
            {
                //c.connopen();
                //query = "select * from UserLog where UserName='" + USERNAME.Text + "' and Password='" + OLD.Text + "'";
                //cmd = new SqlCommand(query, c.conn);
                //dr = cmd.ExecuteReader();
                if (NEW.Text == OLD.Text)
                {
                    c.connopen();
                    query = "Update UserLog set Password=@Password where UserName=@UserName";
                    cmd = new SqlCommand(query, c.conn);
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = NEW.Text;
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = USERNAME.Text;
                    cmd.ExecuteNonQuery();
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Passoword Reset Successfully.", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NEW.Text = "";
                    OLD.Text = "";
                    USERNAME.Text = "";
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(this, "Password Mismastch !!!", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, "Error:" + ex.ToString(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                c.coonclose();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void USERNAME_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.KeyChar = (e.KeyChar.ToString()).ToUpper().ToCharArray()[0];
        }
        private void NEW_Validating(object sender, CancelEventArgs e)
        {
            //Regex regex = new Regex("^[A-Z][0-9]*$");
            //if (regex.IsMatch(NEW.Text))
            //{
            //    errorProvider1.SetError(NEW, String.Empty);
            //}
            //else
            //{
            //    errorProvider1.SetError(NEW,
            //        "Both Alphabet and numbers may be entered here");
            //}
        }

        private void CHANGEPASSWORD_Load(object sender, EventArgs e)
        {
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            NEW.Text = "";
            OLD.Text = "";
            USERNAME.Text = "";

        }
    }
}