namespace SE_4_11
{
    partial class list
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.surveys = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.users = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Нийтэлсэн = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.surveys)).BeginInit();
            this.SuspendLayout();
            // 
            // surveys
            // 
            this.surveys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.surveys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.surveys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.surveys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.users,
            this.Нийтэлсэн,
            this.title,
            this.description});
            this.surveys.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.surveys.Location = new System.Drawing.Point(12, 12);
            this.surveys.Name = "surveys";
            this.surveys.Size = new System.Drawing.Size(402, 179);
            this.surveys.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(339, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Бөглөх";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(258, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Устгах";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(177, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Үзэх";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(96, 372);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Шинэ";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.id.DataPropertyName = "id";
            this.id.FillWeight = 38.07107F;
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.Width = 25;
            // 
            // users
            // 
            this.users.DataPropertyName = "user_id";
            this.users.FillWeight = 115.4822F;
            this.users.HeaderText = "Хэнээс";
            this.users.Name = "users";
            // 
            // Нийтэлсэн
            // 
            this.Нийтэлсэн.DataPropertyName = "publish";
            this.Нийтэлсэн.FillWeight = 115.4822F;
            this.Нийтэлсэн.HeaderText = "Нийтэлсэн";
            this.Нийтэлсэн.Name = "Нийтэлсэн";
            this.Нийтэлсэн.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Нийтэлсэн.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.FillWeight = 115.4822F;
            this.title.HeaderText = "Сэдэв";
            this.title.Name = "title";
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.FillWeight = 115.4822F;
            this.description.HeaderText = "Тайлбар";
            this.description.Name = "description";
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 407);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.surveys);
            this.Name = "list";
            this.Text = "list";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.surveys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView surveys;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn users;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Нийтэлсэн;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
    }
}