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
using System.Windows.Forms.DataVisualization.Charting;

namespace SE_4_11
{
    public partial class View : Form
    {
        MySqlConnection connection;
        MySqlCommand command;
        MySqlDataReader reader;
        int y = 1, pixel = 50;
        int id, reid;
        Control last;
        static Connection constr = new Connection();

        public View(int surveyid, int responseid)
        {
            InitializeComponent();

            DataTable questions = new DataTable();
            DataTable answers = new DataTable();
            DataTable responses = new DataTable();
            DataTable re = new DataTable();

            id = surveyid; reid = responseid;
            connection = new MySqlConnection(constr.database);
            command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM responses WHERE survey_id = " + id;
            connection.Open();
            reader = command.ExecuteReader();
            re.Load(reader);
            re.Columns.Remove("survey_id");
            response.DataSource = re;
            connection.Close();
            command.CommandText = "SELECT * FROM surveys WHERE id = " + id;
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            label(reader["title"].ToString());
            label(reader["description"].ToString());

            if (Convert.ToBoolean(reader["publish"]))
                publish.Text = "Болих";
            else
                publish.Text = "Нийтлэх";

            reader.Close();
            command.CommandText = "SELECT * FROM questions WHERE survey_id = " + id;
            reader = command.ExecuteReader();
            questions.Load(reader);

            if(reid > 0)
            {
                response.Hide();
                button1.Hide();
            }
            Chart chart;
            ChartArea area;
            Series series1;
            for (int i = 0; i < questions.Rows.Count; i++)
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
                        chart = new Chart();
                        area = new ChartArea();
                        chart.ChartAreas.Add(area);
                        chart.Width = pixel * 3;
                        chart.Height = pixel * 3;

                        series1 = new Series
                        {
                            Name = "Series1",
                            ChartType = SeriesChartType.Column,
                        };
                        chart.Series.Add(series1);

                        if (reid == 0)
                        {
                            this.Controls.Add(chart);
                            label(questions.Rows[i]["value"].ToString() + " Нийт хариулт: " + responses.Rows.Count);
                        }
                        else
                            label(questions.Rows[i]["value"].ToString());

                        chart.Top = last.Top;
                        chart.Left = last.Right + pixel;

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
                            {
                                if (count == 0)
                                    radio(answers.Rows[j]["value"].ToString(), "Тоо: 0 Хувь: 0%");
                                else
                                    radio(answers.Rows[j]["value"].ToString(), "Тоо: " + count + " Хувь: " + count * 100 / responses.Rows.Count + "%");
                                series1.Points.AddXY(answers.Rows[j]["value"].ToString(), count);
                            }

                            if (reid != 0 && count == 0)
                                radio(answers.Rows[j]["value"].ToString(), "");
                        }
                        break;
                    case 2:
                        chart = new Chart();
                        area = new ChartArea();
                        area.AxisY.Maximum = 100;
                        chart.ChartAreas.Add(area);
                        chart.Width = pixel * 3;
                        chart.Height = pixel * 3;
                        series1 = new Series
                        {
                            Name = "Series1",
                            ChartType = SeriesChartType.Column,
                        };
                        chart.Series.Add(series1);

                        DataView view = new DataView(responses);
                        DataTable table = view.ToTable(true, "response_id");

                        if (reid == 0)
                        {
                            label(questions.Rows[i]["value"].ToString() + " Нийт хариулт: " + table.Rows.Count.ToString());
                            this.Controls.Add(chart);
                        }
                        else
                            label(questions.Rows[i]["value"].ToString());

                        chart.Left = last.Right + pixel;
                        chart.Top = last.Top;

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
                            {
                                if (count == 0)
                                {
                                    check(answers.Rows[j]["value"].ToString(), "Тоо: 0 Хувь: 0%");
                                    series1.Points.AddXY(answers.Rows[j]["value"].ToString(), count);
                                }
                                else
                                {
                                    check(answers.Rows[j]["value"].ToString(), "Тоо: " + count + " Хувь: " + count * 100 / table.Rows.Count + "%");
                                    series1.Points.AddXY(answers.Rows[j]["value"].ToString(), count * 100 / table.Rows.Count);
                                }
                            }

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

                            if (responses.Rows.Count == 0)
                                text("Хариулт байхгүй байна");
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
            last = label;
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
            last = text;
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
            last = radio;
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
            last = check;
            return check;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = string.Empty;

            if(publish.Text == "Нийтлэх")
            {
                query = "UPDATE surveys SET publish = 1 WHERE id = " + id;
                publish.Text = "Болих";
            }else
            {
                query = "UPDATE surveys SET publish = 0 WHERE id = " + id;
                publish.Text = "Нийтлэх";
            }

            command.CommandText = query;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            list l = new SE_4_11.list();
            l.data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int go = Convert.ToInt32(response.CurrentRow.Cells["Column1"].Value);
            View form = new View(id, go);
            form.Show();

        }

        private void View_Load(object sender, EventArgs e)
        {
        }
    }
}
