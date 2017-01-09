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
    public partial class Response : Form
    {
        MySqlCommand command;
        MySqlDataReader reader;
        int y = 1, pixel = 50;

        public Response(int id)
        {
            InitializeComponent();

            string connect = "Server = localhost; Database = survey; UserID = root; Password = data;";
            MySqlConnection connection = new MySqlConnection(connect);
            command = connection.CreateCommand();
        }
    }
}
