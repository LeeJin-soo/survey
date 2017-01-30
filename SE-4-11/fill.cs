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
    public partial class fill : Form
    {
        MySqlDataReader reader;
        DataTable questions = new DataTable();
        struct Saving
        {
            public int questionid;
            public int? answerid;
            public Control obj;
        }
        List<Saving> saving = new List<Saving>();
        Saving save = new Saving();
        int surveyid;
        public fill(int id)
        {
            surveyid = id;
            InitializeComponent();
            command.CommandText = "SELECT * FROM surveys WHERE id =" + id;
            connection.Open();
            MySqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                label(read["title"].ToString());
                label(read["description"].ToString());
            }
            connection.Close();
            connection.Open();

            command.CommandText = "SELECT * FROM questions WHERE survey_id =" + id + " ORDER BY sort ASC";
            reader = command.ExecuteReader();
            questions.Columns.Add("id");
            questions.Columns.Add("survey_id");
            questions.Columns.Add("type_id");
            questions.Columns.Add("value");
            questions.Load(reader);
            
            for(int i = 0; i < questions.Rows.Count; i++)
            {
                label(questions.Rows[i]["value"].ToString());
                command.CommandText = "SELECT * FROM answers WHERE question_id = " + questions.Rows[i]["id"];
                reader = command.ExecuteReader();
                DataTable answers = new DataTable();
                answers.Columns.Add("id");
                answers.Columns.Add("value");
                answers.Columns.Add("logic_id");
                answers.Columns.Add("question_id");
                answers.Load(reader);
                GroupBox group = new GroupBox();
                save.questionid = Convert.ToInt32(questions.Rows[i]["id"]);

                if (Convert.ToInt32(questions.Rows[i]["type_id"]) == 3)
                {
                    save.answerid = null;
                    save.obj = text();
                    saving.Add(save);
                }
                if (Convert.ToInt32(questions.Rows[i]["type_id"]) == 1)
                {
                    group.Top = y * 50;
                    group.Left = 50;
                    this.Controls.Add(group);
                }
                for (int index = 0; index < answers.Rows.Count; index++)
                {
                    switch (Convert.ToInt32(questions.Rows[i]["type_id"]))
                    {
                        case 1:
                            save.answerid = Convert.ToInt32(answers.Rows[index]["id"]);
                            save.obj = radio(answers.Rows[index]["value"].ToString(), group);
                            saving.Add(save);
                            break;
                        case 2:
                            save.answerid = Convert.ToInt32(answers.Rows[index]["id"]);
                            save.obj = check(answers.Rows[index]["value"].ToString());
                            saving.Add(save);
                            break;
                    }
                }
                group.AutoSize = true;
            }
            connection.Close();
        }

        static MySqlConnection connection = new MySqlConnection("Server = localhost; Database = survey; Uid = root; Password = data;");
        MySqlCommand command = connection.CreateCommand();
        int y = 1;

        public void label(string text)
        {
            Label label = new Label();
            label.Top = y * 50;
            label.Left = 50;
            label.Text = text;
            label.AutoSize = true;
            this.Controls.Add(label);
            y++;
        }

        public TextBox text()
        {
            TextBox text = new TextBox();
            text.Top = y * 50;
            text.Left = 50;
            this.Controls.Add(text);
            y++;
            return text;
        }
        int groupy = 1;
        public RadioButton radio(String text, GroupBox group)
        {
            RadioButton radio = new RadioButton();
            radio.Text = text;
            radio.Top = groupy * 25;
            radio.Left = 50;
            group.Controls.Add(radio);
            groupy++;
            y++;
            return radio;
        }

        public CheckBox check(String text)
        {
            CheckBox check = new CheckBox();
            check.Top = y * 50;
            check.Left = 50;
            check.Text = text;
            this.Controls.Add(check);
            y++;
            return check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            command.CommandText = "INSERT INTO responses(survey_id) VALUES(" + surveyid + ")";
            command.ExecuteNonQuery();
            command.CommandText = "SELECT MAX(id) FROM responses";
            reader = command.ExecuteReader();
            reader.Read();
            int responseid = Convert.ToInt32(reader[0]);
            reader.Close();

            foreach (Saving temporary in saving)
            {
                command.CommandText = "INSERT INTO question_response(response_id, question_id, answer) VALUES(";
                command.CommandText += responseid + ",";
                command.CommandText += temporary.questionid + ",";

                if(temporary.obj is TextBox)
                {
                    command.CommandText += "'" + temporary.obj.Text + "')";
                    command.ExecuteNonQuery();
                }
                if(temporary.obj is RadioButton && ((RadioButton) temporary.obj).Checked)
                {
                    command.CommandText += temporary.answerid + ")";
                    command.ExecuteNonQuery();
                }
                if(temporary.obj is CheckBox && ((CheckBox) temporary.obj).Checked)
                {
                    command.CommandText += temporary.answerid + ")";
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
            if (DialogResult.OK == MessageBox.Show("Амжилттай бөглөлөө."))
                this.Close();
        }
    }
}
