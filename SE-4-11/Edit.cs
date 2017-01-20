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

        public Edit(int surveyId)
        {
            InitializeComponent();

            string connect = "Server = localhost; Database = survey; UserID = root; Password = data;";
            connection = new MySqlConnection(connect);
            command = connection.CreateCommand();
            data(surveyId);
        }

        public void data(int surveyId)
        {
            string query = String.Format("SELECT * FROM {0} WHERE survey_id = " + surveyId, "questions");
            connection.Open();
            command.CommandText = query;
            reader = command.ExecuteReader();
            dataTable = new DataTable();
            dataTable.Load(reader);
            questionsView.DataSource = dataTable;
            connection.Close();
        }
    }
}
