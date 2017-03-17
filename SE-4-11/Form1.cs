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
    public partial class Form1 : Form
    {
        static Connection constr = new Connection();
        static MySqlConnection connection = new MySqlConnection(constr.database);
        MySqlCommand command = connection.CreateCommand();
        List<string> list = new List<string>();
        List<TextBox> questions = new List<TextBox>();
        List<List<Object>> answers = new List<List<Object>>();
        List<Object> answer;
        DataTable table = new DataTable();
        int count = -1, surveyid;
        MySqlDataReader reader;
        list form;
        public Form1()
        {
            InitializeComponent();
            table.Columns.Add("survey_id");
            table.Columns.Add("type_id");
            table.Columns.Add("value");
        }

        int y = 1;

        // Асуулт button event
        private void create_Click(object sender, EventArgs e)
        {
            count++;
            if (type.Text == "Нэг сонголттой")
            {
                addtextbox();
                addradiobutton();
                addradiobutton();
            }
            if (type.Text == "Олон сонголттой")
            {
                addtextbox();
                addcheckbox();
                addcheckbox();
            }
            if (type.Text == "Бичгэн хариулт")
            {
                addtextbox();
                addtextbox(true);
                type.Text = "";
            }
        }

        public void addlabel()
        {
            Label label = new Label();
            label.Location = new System.Drawing.Point(50, 50 * y);
            label.Text = "variable";
            this.Controls.Add(label);
            y++;
        }

        public void addtextbox(bool text = false)
        {
            System.Windows.Forms.TextBox textbox = new System.Windows.Forms.TextBox();
            this.Controls.Add(textbox);
            textbox.Top = y * 50;
            textbox.Left = 50;
            
            if(text)
            {
                textbox.Enabled = false;
                answer = new List<Object>();
                int temp = count;
                answer.Add(temp);
                answer.Add(textbox);
                answers.Add(answer);
            }
            else
                questions.Add(textbox);
            y++;
        }

        public void addcheckbox()
        {
            lists();
            CheckBox checkbox = new CheckBox();
            TextBox text = new TextBox();
            ComboBox drop = new ComboBox();
            this.Controls.Add(text);
            this.Controls.Add(checkbox);
            text.Top = 50 * y;
            text.Left = 70;
            checkbox.Top = 50 * y;
            checkbox.Left = 50;
            checkbox.Enabled = false;
            drop.Top = 50 * y;
            drop.Left = text.Right + 15;
            drop.Items.AddRange(list.ToArray());
            list.Clear();
            y++;

            int temp = count;
            answer = new List<Object>();
            answer.Add(temp);
            answer.Add(checkbox);
            answer.Add(text);
            answer.Add(drop);
            answers.Add(answer);
        }

        public void addradiobutton()
        {
            lists();
            RadioButton radio = new RadioButton();
            TextBox text = new TextBox();
            ComboBox drop = new ComboBox();
            this.Controls.Add(text);
            this.Controls.Add(radio);
            radio.Top = 50 * y;
            radio.Left = 50;
            radio.Enabled = false;
            text.Top = 50 * y;
            text.Left = 70;
            drop.Top = 50 * y;
            drop.Left = text.Right + 15;
            drop.Items.AddRange(list.ToArray());
            list.Clear();
            y++;

            int temp = count;
            answer = new List<Object>();
            answer.Add(temp);
            answer.Add(radio);
            answer.Add(text);
            answer.Add(drop);
            answers.Add(answer);
        }

        public void lists()
        {
            command.CommandText = "SELECT value FROM questions WHERE survey_id IS NULL;";
            connection.Open();
            reader = command.ExecuteReader();

            while (reader.Read())
                list.Add(reader["value"].ToString());

            reader.Close();
            connection.Close();
        }

        // Хариулт button event
        private void add_Click(object sender, EventArgs e)
        {
            if(type.Text == "Нэг сонголттой")
                addradiobutton();
            if (type.Text == "Олон сонголттой")
                addcheckbox();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string query;
            connection.Open();
            form = new list();

            query = "INSERT INTO surveys(user_id, title, description) VALUES('"+ form.cpu() +"', '"+ title.Text +"', '"+ desc.Text +"')";
            command.CommandText = query;
            command.ExecuteNonQuery();

            query = "SELECT MAX(id) FROM surveys";
            command.CommandText = query;
            reader = command.ExecuteReader();
            reader.Read();
            surveyid = (int) reader[0];
            reader.Close();

            for (int i = 0; i < questions.Count; i++)
            {
                query = "INSERT INTO questions(survey_id, type_id, value) VALUES(";
                query += surveyid + ",";
                for (int index = 0; index < answers.Count; index++)
                {
                    if(Convert.ToInt32(answers[index][0]) == i)
                    {
                        if (answers[index][1] is RadioButton)
                            query += "1,";
                        if (answers[index][1] is CheckBox)
                            query += "2,";
                        if(answers[index][1] is TextBox)
                            query += "3,";
                        break;
                    }
                }

                query += "'" + questions[i].Text + "');";
                command.CommandText = query;
                command.ExecuteNonQuery();
                command.CommandText = "SELECT MAX(id) FROM questions;";
                reader = command.ExecuteReader();
                reader.Read();
                int qid = (int) reader[0];
                reader.Close();

                for (int index = 0; index < answers.Count; index++)
                {
                    query = "INSERT INTO answers(value, logic_id, question_id) VALUES(";
                    if (Convert.ToInt32(answers[index][0]) == i && !(answers[index][1] is TextBox))
                    {
                        query += "'" + ((TextBox) answers[index][2]).Text + "',";
                        query += "NULL,";
                        query += qid + ");";
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }
            }
            connection.Close();

            if (DialogResult.OK == MessageBox.Show("Санал асуулгыг хадгаллаа.", ""))
            {
                form = new list();
                form.data();
                this.Close();
            }
        }
    }
}
