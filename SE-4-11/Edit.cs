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
        int questionId;

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

        private void button3_Click(object sender, EventArgs e)
        {
            questionText.Text = questionsView.CurrentRow.Cells["value"].Value.ToString();
            questionId = (int) questionsView.CurrentRow.Cells["id"].Value;

            switch(Convert.ToInt32(questionsView.CurrentRow.Cells["type_id"].Value))
            {
                case 1:
                    typeBox.SelectedIndex = 0;
                    break;
                case 2:
                    typeBox.SelectedIndex = 1;
                    break;
                case 3:
                    typeBox.SelectedIndex = 2;
                    break;
            }

            if (Convert.ToInt32(questionsView.CurrentRow.Cells["type_id"].Value) != 3)
            {
                answerView.Enabled = true;
                answerData();
            }
            else
            {
                answerView.Enabled = false;
                dataTable = new DataTable();
                answerView.DataSource = dataTable;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "UPDATE questions SET value = '"+ questionText.Text +"',";
            connection.Open();

            switch (typeBox.Text)
            {
                case "Нэг сонголттой":
                    query += "type_id = 1 ";
                    break;
                case "Олон сонголттой":
                    query += "type_id = 2 ";
                    break;
                case "Бичгэн хариулт":
                    query += "type_id = 3 ";
                    command.CommandText = "SELECT type_id FROM questions WHERE id = "+ questionId;
                    reader = command.ExecuteReader();
                    reader.Read();

                    if(Convert.ToInt32(reader[0]) != 3)
                    {
                        reader.Close();
                        command.CommandText = "DELETE FROM question_response WHERE question_id = " + questionId;
                        command.ExecuteNonQuery();
                        command.CommandText = "DELETE FROM answers WHERE question_id = "+ questionId;
                        command.ExecuteNonQuery();
                    }

                    break;
            }

            query += "WHERE id = "+ questionId;
            command.CommandText = query;
            command.ExecuteNonQuery();
            query = "SELECT * FROM answers WHERE question_id = " + questionId;
            command.CommandText = query;
            reader = command.ExecuteReader();
            dataTable.Load(reader);
            //dataTable.Columns.Remove("question_id");
            //dataTable.PrimaryKey = new DataColumn[]{ dataTable.Columns["id"]};

            foreach (DataGridViewRow row in answerView.Rows)
            {
                query = "UPDATE answers SET value = '"+ row.Cells["answerValue"].Value +"' WHERE id = "+ row.Cells["answerId"].Value;
                command.CommandText = query;
                command.ExecuteNonQuery();
                
                foreach(DataRow data in dataTable.Rows)
                {
                    if (row.Cells["answerId"].Value == data["id"])
                    {
                        dataTable.Rows.Remove(data);
                        break;
                    }
                }
            }
            
            /*foreach (DataRow row in dataTable.Rows)
            {
                MessageBox.Show(row["id"].ToString());
            }*/

            if(answerText.Text != "")
            {
                query = "INSERT INTO answers(value, question_id) VALUES('" + answerText.Text + "'," + questionId + ")";
                command.CommandText = query;
                command.ExecuteNonQuery();
            }

            connection.Close();
            //answerData();
            data(surveyId);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Энэ асуултыг устгах уу?", "Устгах", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string query = "DELETE FROM question_response WHERE question_id = "+ questionsView.CurrentRow.Cells["id"].Value;
                command.CommandText = query;
                connection.Open();
                command.ExecuteNonQuery();
                query = "DELETE FROM questions WHERE id = " + questionsView.CurrentRow.Cells["id"].Value;
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
                data(surveyId);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string value = questionText.Text;
            string query = "SELECT MAX(sort) FROM questions WHERE survey_id = "+ surveyId;
            connection.Open();
            command.CommandText = query;
            reader = command.ExecuteReader();
            reader.Read();
            int sort = Convert.ToInt32(reader[0]) + 1;
            reader.Close();
            query = "INSERT INTO questions(survey_id, type_id, value, sort) VALUES(" + surveyId + ",";
            
            switch(typeBox.Text)
            {
                case "Нэг сонголттой":
                    query += "1,";
                    break;
                case "Олон сонголттой":
                    query += "2,";
                    break;
                case "Бичгэн хариулт":
                    query += "3,";
                    break;
            }

            query += "'"+ value +"', "+ sort +")";
            command.CommandText = query;
            command.ExecuteNonQuery();
            connection.Close();
            data(surveyId);
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
            dataTable.Columns.Remove("question_id");
            answerView.DataSource = dataTable;
            connection.Close();
        }
    }
}
