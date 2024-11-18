using System.Data;
using Microsoft.Data.SqlClient;

namespace DBMS_SQL_QueryData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter da;

        public void connect()
        {
            string server = @".\SQLEXPRESS";
            string db = "Minimart";
            string strConn = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True ;Encrypt=False", server, db);
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public void disconnect()
        {
            conn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            //string sql = "SELECT * FROM Products";
            //da = new SqlDataAdapter(sql, conn);
            //DataSet ds = new DataSet();
            //da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void showData(string sql)
        {
            //string sql = "SELECT * FROM Products";
            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showData("SELECT EmployeeID, Title+FirstName+' '+LastName as fullname, [Position] FROM Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            showData("SELECT * FROM Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showData("SELECT * FROM Products");
        }
    }
}
