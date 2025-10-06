using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws92_APPR
{
    public partial class Form1 : Form
    {
        string item = "";

        string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=database;Integrated Security=True;TrustServerCertificate=True";
        DataTable dataTable = null;
        int row = 0;
        string addName = "";
        int newItemcount = 0;
        string deleteItemname;
        string selectedItem = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addName = textBox1.Text;
            if (addName == "")
            {
                MessageBox.Show("Bitte geben Sie einen Namen ein.");
                return;
            }

            FillDatatable("SELECT Amount FROM ws92_APPR WHERE Name = '" + addName + "'");

            if (dataTable.Rows.Count > 0)
            {
                newItemcount = Convert.ToInt32(dataTable.Rows[0][0]);
                newItemcount += 1;

                ExecuteQuery("UPDATE ws92_APPR SET Amount ='" + newItemcount + "'Where Name='" + addName + "';");
            }
            else
            {
                ExecuteQuery("INSERT INTO [dbo].[ws92_APPR] (Name, Amount) VALUES (N'" + addName + "', 1);");
            }
        }

        private void UpdateListBox()
        {
            listBox1.Items.Clear();
            row = 0;

            FillDatatable("SELECT * FROM ws92_APPR");

            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    listBox1.Items.Add((dataTable.Rows[row][0] + " " + dataTable.Rows[row][1]).ToString());
                    row++;
                }
            }
            else
            {
                MessageBox.Show("Keine Einträge vorhanden.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        public void ExecuteQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (dataTable = new DataTable())
                {
                    using (SqlCommand cmd = new SqlCommand(query,conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            UpdateListBox();    
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                selectedItem = listBox1.SelectedItem.ToString();
                selectedItem = Regex.Replace(selectedItem, @"\d", "");
                selectedItem.Trim();
                textBox1.Text = selectedItem;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            deleteItemname = selectedItem;

            FillDatatable("SELECT Amount FROM ws92_APPR WHERE Name = '" + deleteItemname + "'");

            if(dataTable.Rows.Count > 0)
            {
                newItemcount = Convert.ToInt32(dataTable.Rows[0][0]);
                if(newItemcount == 1)
                {
                    ExecuteQuery("DELETE FROM ws92_APPR WHERE Name = '" + deleteItemname + "';");
                }
                else
                {
                    newItemcount -= 1;
                    ExecuteQuery("UPDATE ws92_APPR SET Amount ='" + newItemcount + "'Where Name='" + deleteItemname + "';");
                }
                UpdateListBox();
            }
        }

        public void FillDatatable(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                using (dataTable = new DataTable("Groceries"))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dataTable);
                    }
                }
            }
        }   
    }
}
