namespace Lab8
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BooksList = new ListBox();
            AddButton = new Button();
            DeleteButton = new Button();
            TitleTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ReleaseYearTextBox = new TextBox();
            label4 = new Label();
            PagesCountTextBox = new TextBox();
            label5 = new Label();
            GenreComboBox = new ComboBox();
            AuthorTextBox = new TextBox();
            SuspendLayout();
            // 
            // BooksList
            // 
            BooksList.FormattingEnabled = true;
            BooksList.Location = new Point(12, 12);
            BooksList.Name = "BooksList";
            BooksList.Size = new Size(194, 364);
            BooksList.TabIndex = 0;
            BooksList.SelectedIndexChanged += BooksList_SelectedIndexChanged;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(12, 403);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(94, 29);
            AddButton.TabIndex = 1;
            AddButton.Text = "Добавить";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(112, 403);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(94, 29);
            DeleteButton.TabIndex = 2;
            DeleteButton.Text = "Удалить";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // TitleTextBox
            // 
            TitleTextBox.Location = new Point(212, 38);
            TitleTextBox.Name = "TitleTextBox";
            TitleTextBox.Size = new Size(125, 27);
            TitleTextBox.TabIndex = 3;
            TitleTextBox.TextChanged += TitleTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(212, 15);
            label1.Name = "label1";
            label1.Size = new Size(38, 20);
            label1.TabIndex = 4;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 76);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 6;
            label2.Text = "Author";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 143);
            label3.Name = "label3";
            label3.Size = new Size(92, 20);
            label3.TabIndex = 8;
            label3.Text = "Release Year";
            // 
            // ReleaseYearTextBox
            // 
            ReleaseYearTextBox.Location = new Point(212, 166);
            ReleaseYearTextBox.Name = "ReleaseYearTextBox";
            ReleaseYearTextBox.Size = new Size(125, 27);
            ReleaseYearTextBox.TabIndex = 7;
            ReleaseYearTextBox.TextChanged += ReleaseYearTextBox_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 211);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 10;
            label4.Text = "Page Count";
            // 
            // PagesCountTextBox
            // 
            PagesCountTextBox.Location = new Point(212, 234);
            PagesCountTextBox.Name = "PagesCountTextBox";
            PagesCountTextBox.Size = new Size(125, 27);
            PagesCountTextBox.TabIndex = 9;
            PagesCountTextBox.TextChanged += PagesCountTextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(212, 273);
            label5.Name = "label5";
            label5.Size = new Size(48, 20);
            label5.TabIndex = 12;
            label5.Text = "Genre";
            // 
            // GenreComboBox
            // 
            GenreComboBox.FormattingEnabled = true;
            GenreComboBox.Location = new Point(212, 296);
            GenreComboBox.Name = "GenreComboBox";
            GenreComboBox.Size = new Size(151, 28);
            GenreComboBox.TabIndex = 13;
            GenreComboBox.SelectedValueChanged += GenreComboBox_SelectedValueChanged;
            // 
            // AuthorTextBox
            // 
            AuthorTextBox.Location = new Point(212, 99);
            AuthorTextBox.Name = "AuthorTextBox";
            AuthorTextBox.Size = new Size(125, 27);
            AuthorTextBox.TabIndex = 14;
            AuthorTextBox.TextChanged += AuthorTextBox_TextChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(800, 450);
            Controls.Add(AuthorTextBox);
            Controls.Add(GenreComboBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(PagesCountTextBox);
            Controls.Add(label3);
            Controls.Add(ReleaseYearTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TitleTextBox);
            Controls.Add(DeleteButton);
            Controls.Add(AddButton);
            Controls.Add(BooksList);
            Name = "MainForm";
            Padding = new Padding(15);
            Text = "BooksDB";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox BooksList;
        private Button AddButton;
        private Button DeleteButton;
        private TextBox TitleTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox ReleaseYearTextBox;
        private Label label4;
        private TextBox PagesCountTextBox;
        private Label label5;
        private ComboBox GenreComboBox;
        private TextBox AuthorTextBox;
    }
}
