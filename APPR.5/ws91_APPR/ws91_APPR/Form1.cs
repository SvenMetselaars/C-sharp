using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws91_APPR
{
    public partial class Form1 : Form
    {
        string ConnectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=ws91_APPR;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            TbxSearch.Text = "";
            fillDatagridvieuw();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (TbxSearch.Text == "" )
            {
                fillDatagridvieuw();
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    using (DataTable datatable = new DataTable("Datatablepropertyname"))
                    {
                        using (SqlCommand command = new SqlCommand("Select * from Ranking where ranking = @ranking", sqlConnection))
                        {
                            command.Parameters.AddWithValue("@ranking", TbxSearch.Text);
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                            sqlDataAdapter.Fill(datatable);
                            DgvInformation.DataSource = datatable;
                        }
                    }
                }
            }
            ResetDgvSize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fillDatagridvieuw();
        }

        private void fillDatagridvieuw()
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
                using (DataTable datatable = new DataTable("Datatablepropryname"))
                {
                    using (SqlCommand command = new SqlCommand("Select * from Ranking", sqlConnection))
                    {
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                        sqlDataAdapter.Fill(datatable);
                        DgvInformation.DataSource = datatable;
                    }
                }
            }
            ResetDgvSize();
        }
        private void ResetDgvSize()
        {
            DgvInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            int totalwidth = DgvInformation.RowHeadersWidth;
            foreach (DataGridViewColumn column in DgvInformation.Columns)
            {
                totalwidth += column.Width;
            }
            DgvInformation.Width = totalwidth + 20;
            this.Width = totalwidth + 50;
        }
    }
}
