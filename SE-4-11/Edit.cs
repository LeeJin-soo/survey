using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SE_4_11
{
    public partial class Edit : Form
    {
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        DataTable dataTable;
        int y = 1, pixel = 50;
        int surveyId;

        public Edit(int surveyId)
        {
            InitializeComponent();

            this.surveyId = surveyId;
            string connect = "Server = localhost; Database = survey; UserID = root; Password = data;";
            connection = new MySqlConnection(connect);
            command = connection.CreateCommand();
            data(surveyId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = questionsView.CurrentRow.Index;

            if(index + 1 < questionsView.Rows.Count)
            {
                int prev = Convert.ToInt32(questionsView.CurrentRow.Cells["id"].Value);
                int next = Convert.ToInt32(questionsView.Rows[index + 1].Cells["id"].Value);
                string query = "UPDATE questions a INNER JOIN questions b ON a.id <> b.id SET a.sort = b.sort";
                query += " WHERE a.id IN (" + prev + ", " + next + ") AND b.id IN ("+ prev +", "+ next +");";
                connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                data(surveyId);
            }
            else
            {
                MessageBox.Show("Илүү асуулт алга.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = questionsView.CurrentRow.Index;

            if(index - 1 >= 0)
            {
                int prev = Convert.ToInt32(questionsView.Rows[index - 1].Cells["id"].Value);
                int curr = Convert.ToInt32(questionsView.CurrentRow.Cells["id"].Value);
                string query = "UPDATE questions a INNER JOIN questions b ON a.id <> b.id SET a.sort = b.sort ";
                query += "WHERE a.id IN ("+ prev +", "+ curr +") AND b.id IN ("+ prev +", "+ curr +");";
                connection.Open();
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                data(surveyId);
            }else
            {
                MessageBox.Show("Илүү асуулт алга.");
            }
            answerData();
        }

        public void data(int surveyId)
        {
            string query = String.Format("SELECT * FROM {0} WHERE survey_id = " + surveyId, "questions");
            connection.Open();
            command.CommandText = query;
            reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            dataTable.Columns.Remove("survey_id");
            questionsView.DataSource = dataTable;
            questionsView.Sort(questionsView.Columns["sort"], ListSortDirection.Ascending);
            connection.Close();
        }

        public void answerData()
        {
            int questionId = Convert.ToInt32(questionsView.CurrentRow.Cells["id"].Value);
            string query = String.Format("SELECT * FROM answers WHERE question_id = {0}", questionId);
            connection.Open();
            command.CommandText = query;
            reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }
    }
}
