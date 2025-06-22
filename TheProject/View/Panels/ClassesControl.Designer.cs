namespace TheProject.View.Panels
{
    partial class ClassesControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            labelId = new Label();
            textBoxId = new TextBox();
            textBoxCenterY = new TextBox();
            textBoxCenterX = new TextBox();
            labelCenter = new Label();
            buttonFindFilm = new Button();
            textBoxFilmRating = new TextBox();
            labelFilmRating = new Label();
            labelFilmGenre = new Label();
            labelFilmYear = new Label();
            labelFilmDuration = new Label();
            labelFilmName = new Label();
            textBoxFilmGenre = new TextBox();
            textBoxFilmYear = new TextBox();
            textBoxFilmDuration = new TextBox();
            textBoxFilmName = new TextBox();
            listBoxFilms = new ListBox();
            buttonFindRect = new Button();
            labelColour = new Label();
            labelWidth = new Label();
            labelLength = new Label();
            textBoxColour = new TextBox();
            textBoxWidth = new TextBox();
            textBoxLength = new TextBox();
            listClassesChoice = new ListBox();
            SuspendLayout();
            // 
            // labelId
            // 
            labelId.AutoSize = true;
            labelId.Location = new Point(182, 3);
            labelId.Name = "labelId";
            labelId.Size = new Size(18, 15);
            labelId.TabIndex = 51;
            labelId.Text = "ID";
            // 
            // textBoxId
            // 
            textBoxId.Location = new Point(182, 19);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(100, 23);
            textBoxId.TabIndex = 50;
            // 
            // textBoxCenterY
            // 
            textBoxCenterY.Location = new Point(182, 224);
            textBoxCenterY.Name = "textBoxCenterY";
            textBoxCenterY.ReadOnly = true;
            textBoxCenterY.Size = new Size(100, 23);
            textBoxCenterY.TabIndex = 49;
            // 
            // textBoxCenterX
            // 
            textBoxCenterX.Location = new Point(182, 195);
            textBoxCenterX.Name = "textBoxCenterX";
            textBoxCenterX.ReadOnly = true;
            textBoxCenterX.Size = new Size(100, 23);
            textBoxCenterX.TabIndex = 48;
            // 
            // labelCenter
            // 
            labelCenter.AutoSize = true;
            labelCenter.Location = new Point(182, 177);
            labelCenter.Name = "labelCenter";
            labelCenter.Size = new Size(76, 15);
            labelCenter.TabIndex = 47;
            labelCenter.Text = "Center (X, Y):";
            // 
            // buttonFindFilm
            // 
            buttonFindFilm.Location = new Point(658, 220);
            buttonFindFilm.Name = "buttonFindFilm";
            buttonFindFilm.Size = new Size(75, 23);
            buttonFindFilm.TabIndex = 46;
            buttonFindFilm.Text = "Find";
            buttonFindFilm.UseVisualStyleBackColor = true;
            buttonFindFilm.Click += buttonFindFilm_Click;
            // 
            // textBoxFilmRating
            // 
            textBoxFilmRating.Location = new Point(552, 221);
            textBoxFilmRating.Name = "textBoxFilmRating";
            textBoxFilmRating.Size = new Size(100, 23);
            textBoxFilmRating.TabIndex = 45;
            textBoxFilmRating.TextChanged += textBoxFilmRating_TextChanged;
            // 
            // labelFilmRating
            // 
            labelFilmRating.AutoSize = true;
            labelFilmRating.Location = new Point(552, 203);
            labelFilmRating.Name = "labelFilmRating";
            labelFilmRating.Size = new Size(44, 15);
            labelFilmRating.TabIndex = 44;
            labelFilmRating.Text = "Rating:";
            // 
            // labelFilmGenre
            // 
            labelFilmGenre.AutoSize = true;
            labelFilmGenre.Location = new Point(552, 159);
            labelFilmGenre.Name = "labelFilmGenre";
            labelFilmGenre.Size = new Size(41, 15);
            labelFilmGenre.TabIndex = 43;
            labelFilmGenre.Text = "Genre:";
            // 
            // labelFilmYear
            // 
            labelFilmYear.AutoSize = true;
            labelFilmYear.Location = new Point(552, 115);
            labelFilmYear.Name = "labelFilmYear";
            labelFilmYear.Size = new Size(58, 15);
            labelFilmYear.TabIndex = 42;
            labelFilmYear.Text = "Film year:";
            // 
            // labelFilmDuration
            // 
            labelFilmDuration.AutoSize = true;
            labelFilmDuration.Location = new Point(552, 71);
            labelFilmDuration.Name = "labelFilmDuration";
            labelFilmDuration.Size = new Size(81, 15);
            labelFilmDuration.TabIndex = 41;
            labelFilmDuration.Text = "Film duration:";
            // 
            // labelFilmName
            // 
            labelFilmName.AutoSize = true;
            labelFilmName.Location = new Point(552, 27);
            labelFilmName.Name = "labelFilmName";
            labelFilmName.Size = new Size(66, 15);
            labelFilmName.TabIndex = 40;
            labelFilmName.Text = "Film name:";
            // 
            // textBoxFilmGenre
            // 
            textBoxFilmGenre.Location = new Point(552, 177);
            textBoxFilmGenre.Name = "textBoxFilmGenre";
            textBoxFilmGenre.Size = new Size(100, 23);
            textBoxFilmGenre.TabIndex = 39;
            textBoxFilmGenre.TextChanged += textBoxFilmGenre_TextChanged;
            // 
            // textBoxFilmYear
            // 
            textBoxFilmYear.Location = new Point(552, 133);
            textBoxFilmYear.Name = "textBoxFilmYear";
            textBoxFilmYear.Size = new Size(100, 23);
            textBoxFilmYear.TabIndex = 38;
            textBoxFilmYear.TextChanged += textBoxFilmYear_TextChanged;
            // 
            // textBoxFilmDuration
            // 
            textBoxFilmDuration.Location = new Point(552, 89);
            textBoxFilmDuration.Name = "textBoxFilmDuration";
            textBoxFilmDuration.Size = new Size(100, 23);
            textBoxFilmDuration.TabIndex = 37;
            textBoxFilmDuration.TextChanged += textBoxFilmDuration_TextChanged;
            // 
            // textBoxFilmName
            // 
            textBoxFilmName.Location = new Point(552, 45);
            textBoxFilmName.Name = "textBoxFilmName";
            textBoxFilmName.Size = new Size(100, 23);
            textBoxFilmName.TabIndex = 36;
            textBoxFilmName.TextChanged += textBoxFilmName_TextChanged;
            // 
            // listBoxFilms
            // 
            listBoxFilms.FormattingEnabled = true;
            listBoxFilms.ItemHeight = 15;
            listBoxFilms.Location = new Point(373, 3);
            listBoxFilms.Name = "listBoxFilms";
            listBoxFilms.Size = new Size(173, 259);
            listBoxFilms.TabIndex = 35;
            // 
            // buttonFindRect
            // 
            buttonFindRect.Location = new Point(288, 106);
            buttonFindRect.Name = "buttonFindRect";
            buttonFindRect.Size = new Size(75, 23);
            buttonFindRect.TabIndex = 34;
            buttonFindRect.Text = "Find";
            buttonFindRect.UseVisualStyleBackColor = true;
            buttonFindRect.Click += buttonFindRect_Click;
            // 
            // labelColour
            // 
            labelColour.AutoSize = true;
            labelColour.Location = new Point(182, 133);
            labelColour.Name = "labelColour";
            labelColour.Size = new Size(46, 15);
            labelColour.TabIndex = 33;
            labelColour.Text = "Colour:";
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(182, 89);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(42, 15);
            labelWidth.TabIndex = 32;
            labelWidth.Text = "Width:";
            // 
            // labelLength
            // 
            labelLength.AutoSize = true;
            labelLength.Location = new Point(182, 45);
            labelLength.Name = "labelLength";
            labelLength.Size = new Size(47, 15);
            labelLength.TabIndex = 31;
            labelLength.Text = "Length:";
            // 
            // textBoxColour
            // 
            textBoxColour.Location = new Point(182, 151);
            textBoxColour.Name = "textBoxColour";
            textBoxColour.Size = new Size(100, 23);
            textBoxColour.TabIndex = 30;
            // 
            // textBoxWidth
            // 
            textBoxWidth.Location = new Point(182, 107);
            textBoxWidth.Name = "textBoxWidth";
            textBoxWidth.Size = new Size(100, 23);
            textBoxWidth.TabIndex = 29;
            // 
            // textBoxLength
            // 
            textBoxLength.Location = new Point(182, 63);
            textBoxLength.Name = "textBoxLength";
            textBoxLength.Size = new Size(100, 23);
            textBoxLength.TabIndex = 28;
            // 
            // listClassesChoice
            // 
            listClassesChoice.FormattingEnabled = true;
            listClassesChoice.ItemHeight = 15;
            listClassesChoice.Location = new Point(3, 3);
            listClassesChoice.Name = "listClassesChoice";
            listClassesChoice.Size = new Size(173, 259);
            listClassesChoice.TabIndex = 27;
            listClassesChoice.SelectedIndexChanged += listClassesChoice_SelectedIndexChanged;
            // 
            // ClassesControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelId);
            Controls.Add(textBoxId);
            Controls.Add(textBoxCenterY);
            Controls.Add(textBoxCenterX);
            Controls.Add(labelCenter);
            Controls.Add(buttonFindFilm);
            Controls.Add(textBoxFilmRating);
            Controls.Add(labelFilmRating);
            Controls.Add(labelFilmGenre);
            Controls.Add(labelFilmYear);
            Controls.Add(labelFilmDuration);
            Controls.Add(labelFilmName);
            Controls.Add(textBoxFilmGenre);
            Controls.Add(textBoxFilmYear);
            Controls.Add(textBoxFilmDuration);
            Controls.Add(textBoxFilmName);
            Controls.Add(listBoxFilms);
            Controls.Add(buttonFindRect);
            Controls.Add(labelColour);
            Controls.Add(labelWidth);
            Controls.Add(labelLength);
            Controls.Add(textBoxColour);
            Controls.Add(textBoxWidth);
            Controls.Add(textBoxLength);
            Controls.Add(listClassesChoice);
            Name = "ClassesControl";
            Size = new Size(746, 270);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelId;
        private TextBox textBoxId;
        private TextBox textBoxCenterY;
        private TextBox textBoxCenterX;
        private Label labelCenter;
        private Button buttonFindFilm;
        private TextBox textBoxFilmRating;
        private Label labelFilmRating;
        private Label labelFilmGenre;
        private Label labelFilmYear;
        private Label labelFilmDuration;
        private Label labelFilmName;
        private TextBox textBoxFilmGenre;
        private TextBox textBoxFilmYear;
        private TextBox textBoxFilmDuration;
        private TextBox textBoxFilmName;
        private ListBox listBoxFilms;
        private Button buttonFindRect;
        private Label labelColour;
        private Label labelWidth;
        private Label labelLength;
        private TextBox textBoxColour;
        private TextBox textBoxWidth;
        private TextBox textBoxLength;
        private ListBox listClassesChoice;
    }
}
