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
using System.Management;

namespace SE_4_11
{
    public partial class list : Form
    {
        static MySqlConnection connection = new MySqlConnection("Server = localhost; Database = survey; Uid = root; Password = data;");
        MySqlCommand command = connection.CreateCommand();
        public list()
        {
            InitializeComponent();

            data();
        }

        public string cpu()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach(ManagementObject mo in moc)
            {
                if(cpuInfo == "")
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }

            return cpuInfo;
        }

        public void data()
        {
            string query = String.Format("SELECT * FROM {0}", "surveys");
            connection.Open();
            command.CommandText = query;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);

            for(int i = 0; i < data.Rows.Count; i ++)
            {
                if (data.Rows[i]["user_id"].ToString() == cpu())
                    data.Rows[i]["user_id"] = "Надаас";
                else
                {
                    if (Convert.ToBoolean(data.Rows[i]["publish"]))
                        data.Rows[i]["user_id"] = "Бусдаас";
                    else
                        data.Rows.RemoveAt(i);
                }
            }
            
            surveys.DataSource = data;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill form = new fill(Convert.ToInt32(surveys.CurrentRow.Cells["id"].Value));
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(surveys.CurrentRow.Cells["id"].Value);
            connection.Open();
            command.CommandText = "DELETE FROM surveys WHERE id = " + id;
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Амжилттай устгалаа.");
            data();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(surveys.CurrentRow.Cells["id"].Value);
            View view = new View(id, 0);
            view.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
