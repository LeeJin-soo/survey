namespace SE_4_11
{
    partial class Edit
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.answerView = new System.Windows.Forms.DataGridView();
            this.answerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.answerValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.questionsView = new System.Windows.Forms.DataGridView();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.questionText = new System.Windows.Forms.RichTextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.answerText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.answerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsView)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(579, 546);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Доош";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(498, 546);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Дээш";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // answerView
            // 
            this.answerView.AllowUserToAddRows = false;
            this.answerView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.answerView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answerView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.answerId,
            this.answerValue});
            this.answerView.Location = new System.Drawing.Point(15, 312);
            this.answerView.Name = "answerView";
            this.answerView.Size = new System.Drawing.Size(240, 150);
            this.answerView.TabIndex = 3;
            // 
            // answerId
            // 
            this.answerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.answerId.DataPropertyName = "id";
            this.answerId.HeaderText = "Дугаар";
            this.answerId.Name = "answerId";
            this.answerId.ReadOnly = true;
            this.answerId.Width = 69;
            // 
            // answerValue
            // 
            this.answerValue.DataPropertyName = "value";
            this.answerValue.HeaderText = "Хариулт";
            this.answerValue.Name = "answerValue";
            // 
            // questionsView
            // 
            this.questionsView.AllowUserToAddRows = false;
            this.questionsView.AllowUserToDeleteRows = false;
            this.questionsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.questionsView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.questionsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.questionsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sort,
            this.id,
            this.type_id,
            this.value});
            this.questionsView.Location = new System.Drawing.Point(12, 12);
            this.questionsView.Name = "questionsView";
            this.questionsView.Size = new System.Drawing.Size(642, 185);
            this.questionsView.TabIndex = 4;
            // 
            // sort
            // 
            this.sort.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "Дараалал";
            this.sort.Name = "sort";
            this.sort.Width = 83;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Дугаар";
            this.id.Name = "id";
            this.id.Width = 69;
            // 
            // type_id
            // 
            this.type_id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.type_id.DataPropertyName = "type_id";
            this.type_id.HeaderText = "Төрөл";
            this.type_id.Name = "type_id";
            this.type_id.Width = 63;
            // 
            // value
            // 
            this.value.DataPropertyName = "value";
            this.value.HeaderText = "Асуулт";
            this.value.Name = "value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Асуулт";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Нэг сонголттой",
            "Олон сонголттой",
            "Бичгэн хариулт"});
            this.typeBox.Location = new System.Drawing.Point(56, 206);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 7;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(336, 546);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Засах";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // questionText
            // 
            this.questionText.Location = new System.Drawing.Point(230, 203);
            this.questionText.Name = "questionText";
            this.questionText.Size = new System.Drawing.Size(232, 68);
            this.questionText.TabIndex = 10;
            this.questionText.Text = "";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(255, 546);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Хадгалах";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Төрөл";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 285);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Хариултууд";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(417, 546);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "Устгах";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(579, 517);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 14;
            this.button6.Text = "Нэмэх";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // answerText
            // 
            this.answerText.Location = new System.Drawing.Point(315, 309);
            this.answerText.Name = "answerText";
            this.answerText.Size = new System.Drawing.Size(100, 20);
            this.answerText.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(261, 312);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Хариулт";
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 581);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.answerText);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.questionText);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.questionsView);
            this.Controls.Add(this.answerView);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Edit";
            this.Text = "Асуултууд";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.answerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.questionsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView answerView;
        private System.Windows.Forms.DataGridView questionsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox questionText;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn answerValue;
        private System.Windows.Forms.TextBox answerText;
        private System.Windows.Forms.Label label4;
    }
}