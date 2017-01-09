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
    public partial class View : Form
    {
        MySqlCommand command;
        MySqlDataReader reader;
        int y = 1, pixel = 50;
        int id, reid;

        public View(int surveyid, int responseid)
        {
            InitializeComponent();
            
            DataTable questions = new DataTable();
            questions.Columns.Add("id");
            questions.Columns.Add("survey_id");
            questions.Columns.Add("type_id");
            questions.Columns.Add("value");
            DataTable answers = new DataTable();
            answers.Columns.Add("id");
            answers.Columns.Add("value");
            answers.Columns.Add("logic_id");
            answers.Columns.Add("question_id");
            DataTable responses = new DataTable();
            responses.Columns.Add("id");
            responses.Columns.Add("response_id");
            responses.Columns.Add("question_id");
            responses.Columns.Add("answer");
            DataTable re = new DataTable();
            re.Columns.Add("id");
            re.Columns.Add("survey_id");

            id = surveyid; reid = responseid;
            string connect = "Server = localhost; Database = survey; UserID = root; Password = data;";
            MySqlConnection connection = new MySqlConnection(connect);
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM responses WHERE survey_id = " + id;
            connection.Open();
            reader = command.ExecuteReader();
            re.Load(reader);
            response.DataSource = re;
            connection.Close();
            command.CommandText = "SELECT * FROM surveys WHERE id = " + id;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            label(reader["title"].ToString());
            label(reader["description"].ToString());
            reader.Close();
            command.CommandText = "SELECT * FROM questions WHERE survey_id = " + id;
            reader = command.ExecuteReader();
            questions.Load(reader);

            if(reid > 0)
            {
                response.Hide();
                button1.Hide();
            }

            for(int i = 0; i < questions.Rows.Count; i++)
            {
                command.CommandText = "SELECT * FROM answers WHERE question_id = " + Convert.ToInt32(questions.Rows[i]["id"]);
                reader = command.ExecuteReader();
                answers.Load(reader);

                if(reid == 0)
                    command.CommandText = "SELECT * FROM question_response WHERE question_id = " + Convert.ToInt32(questions.Rows[i]["id"]);
                else
                    command.CommandText = "SELECT * FROM question_response WHERE question_id = " + Convert.ToInt32(questions.Rows[i]["id"]) + " AND response_id = " + reid;

                reader = command.ExecuteReader();
                responses.Load(reader);

                switch (Convert.ToInt32(questions.Rows[i]["type_id"]))
                {
                    case 1:
                        if (reid == 0)
                            label(questions.Rows[i]["value"].ToString() + " Нийт хариулт: " + responses.Rows.Count);
                        else
                            label(questions.Rows[i]["value"].ToString());

                        for (int j = 0; j < answers.Rows.Count; j++)
                        {
                            int count = 0;
                            for(int k = 0; k < responses.Rows.Count; k++)
                            {
                                if (Convert.ToInt32(responses.Rows[k]["answer"]) == Convert.ToInt32(answers.Rows[j]["id"]))
                                {
                                    count++;
                                    if (reid != 0)
                                        radio(answers.Rows[j]["value"].ToString(), "").Checked = true;
                                }
                            }
                            
                            if(reid == 0)
                                radio(answers.Rows[j]["value"].ToString(), "Тоо: " + count + " Хувь: " + count * 100 / responses.Rows.Count + "%");

                            if (reid != 0 && count == 0)
                                radio(answers.Rows[j]["value"].ToString(), "");
                        }
                        break;
                    case 2:
                        DataView view = new DataView(responses);
                        DataTable table = view.ToTable(true, "response_id");

                        if (reid == 0)
                            label(questions.Rows[i]["value"].ToString() + " Нийт хариулт: " + table.Rows.Count.ToString());
                        else
                            label(questions.Rows[i]["value"].ToString());

                        for (int j = 0; j < answers.Rows.Count; j++)
                        {
                            int count = 0;
                            for(int k = 0; k < responses.Rows.Count; k++)
                            {
                                if (Convert.ToInt32(responses.Rows[k]["answer"]) == Convert.ToInt32(answers.Rows[j]["id"]))
                                {
                                    count++;
                                    if (reid != 0)
                                        check(answers.Rows[j]["value"].ToString(), "").Checked = true;
                                }
                            }

                            if(reid == 0)
                                check(answers.Rows[j]["value"].ToString(), "Тоо: " + count + " Хувь: " + count * 100 / table.Rows.Count + "%");

                            if (reid != 0 && count == 0)
                                check(answers.Rows[j]["value"].ToString(), "");
                        }
                        break;
                    case 3:
                        if (reid == 0)
                        {
                            label(questions.Rows[i]["value"].ToString() + " Нийт хариулт: " + responses.Rows.Count);

                            for (int j = 0; j < responses.Rows.Count; j++)
                                text(responses.Rows[j]["answer"].ToString());
                        }
                        else
                        {
                            label(questions.Rows[i]["value"].ToString());

                            for (int j = 0; j < responses.Rows.Count; j++)
                                if (Convert.ToInt32(responses.Rows[j]["response_id"]) == reid)
                                    text(responses.Rows[j]["answer"].ToString());
                        }

                        break;
                }
                answers.Clear();
                responses.Clear();
            }
            connection.Close();
        }

        private void label(string text)
        {
            Label label = new Label();
            label.Text = text;
            label.Left = pixel;
            label.Top = pixel * y;
            label.AutoSize = true;
            this.Controls.Add(label);
            y++;
        }

        private void text(string txt)
        {
            TextBox text = new TextBox();
            this.Controls.Add(text);
            text.Text = txt;
            text.Top = pixel * y;
            text.Left = pixel;
            text.Enabled = false;
            y++;
        }

        private RadioButton radio(string txt, string stats)
        {
            RadioButton radio = new RadioButton();
            this.Controls.Add(radio);
            radio.Text = txt;
            radio.Top = pixel * y;
            radio.Left = pixel;
            radio.Enabled = false;

            if (reid == 0)
            {
                Label label = new Label();
                this.Controls.Add(label);
                label.Text = stats;
                label.AutoSize = true;
                label.Top = pixel * y;
                label.Left = radio.Right + pixel;
            }
            
            y++;
            return radio;
        }

        private CheckBox check(string txt, string stats)
        {
            CheckBox check = new CheckBox();
            this.Controls.Add(check);
            check.Text = txt;
            check.Top = pixel * y;
            check.Left = pixel;
            check.Enabled = false;

            if (reid == 0)
            {
                Label label = new Label();
                this.Controls.Add(label);
                label.Text = stats;
                label.Top = pixel * y;
                label.Left = check.Right + pixel;
            }
            
            y++;
            return check;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int go = Convert.ToInt32(response.CurrentRow.Cells["id"].Value);
            View form = new View(id, go);
            form.Show();

        }

        private void View_Load(object sender, EventArgs e)
        {
        }
    }
}
