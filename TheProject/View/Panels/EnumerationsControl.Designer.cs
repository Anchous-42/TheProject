namespace TheProject.View.Panels
{
    partial class EnumerationsControl
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
            buttonSeason = new Button();
            labelSeason = new Label();
            comboBoxSeason = new ComboBox();
            labelParseResult = new Label();
            buttonParse = new Button();
            textBoxParse = new TextBox();
            labelParsing = new Label();
            labelIntValue = new Label();
            labelValueChoice = new Label();
            labelEnumChoice = new Label();
            listValueChoice = new ListBox();
            textBoxIntChoice = new TextBox();
            listEnumChoice = new ListBox();
            SuspendLayout();
            // 
            // buttonSeason
            // 
            buttonSeason.Location = new Point(276, 264);
            buttonSeason.Margin = new Padding(3, 2, 3, 2);
            buttonSeason.Name = "buttonSeason";
            buttonSeason.Size = new Size(82, 22);
            buttonSeason.TabIndex = 26;
            buttonSeason.Text = "Go!";
            buttonSeason.UseVisualStyleBackColor = true;
            buttonSeason.Click += buttonSeason_Click;
            // 
            // labelSeason
            // 
            labelSeason.AutoSize = true;
            labelSeason.Location = new Point(276, 198);
            labelSeason.Name = "labelSeason";
            labelSeason.Size = new Size(98, 15);
            labelSeason.TabIndex = 25;
            labelSeason.Text = "Choose a season!";
            // 
            // comboBoxSeason
            // 
            comboBoxSeason.FormattingEnabled = true;
            comboBoxSeason.Location = new Point(276, 215);
            comboBoxSeason.Margin = new Padding(3, 2, 3, 2);
            comboBoxSeason.Name = "comboBoxSeason";
            comboBoxSeason.Size = new Size(268, 23);
            comboBoxSeason.TabIndex = 24;
            // 
            // labelParseResult
            // 
            labelParseResult.AutoSize = true;
            labelParseResult.Location = new Point(3, 238);
            labelParseResult.Name = "labelParseResult";
            labelParseResult.Size = new Size(16, 15);
            labelParseResult.TabIndex = 23;
            labelParseResult.Text = "...";
            // 
            // buttonParse
            // 
            buttonParse.Location = new Point(3, 264);
            buttonParse.Margin = new Padding(3, 2, 3, 2);
            buttonParse.Name = "buttonParse";
            buttonParse.Size = new Size(82, 22);
            buttonParse.TabIndex = 22;
            buttonParse.Text = "Parse!";
            buttonParse.UseVisualStyleBackColor = true;
            buttonParse.Click += buttonParse_Click;
            // 
            // textBoxParse
            // 
            textBoxParse.Location = new Point(3, 216);
            textBoxParse.Margin = new Padding(3, 2, 3, 2);
            textBoxParse.Name = "textBoxParse";
            textBoxParse.Size = new Size(268, 23);
            textBoxParse.TabIndex = 21;
            // 
            // labelParsing
            // 
            labelParsing.AutoSize = true;
            labelParsing.Location = new Point(3, 198);
            labelParsing.Name = "labelParsing";
            labelParsing.Size = new Size(125, 15);
            labelParsing.TabIndex = 20;
            labelParsing.Text = "Type value for parsing!";
            // 
            // labelIntValue
            // 
            labelIntValue.AutoSize = true;
            labelIntValue.Location = new Point(276, 0);
            labelIntValue.Name = "labelIntValue";
            labelIntValue.Size = new Size(55, 15);
            labelIntValue.TabIndex = 19;
            labelIntValue.Text = "Int value:";
            // 
            // labelValueChoice
            // 
            labelValueChoice.AutoSize = true;
            labelValueChoice.Location = new Point(140, 0);
            labelValueChoice.Name = "labelValueChoice";
            labelValueChoice.Size = new Size(81, 15);
            labelValueChoice.TabIndex = 18;
            labelValueChoice.Text = "Choose value:";
            // 
            // labelEnumChoice
            // 
            labelEnumChoice.AutoSize = true;
            labelEnumChoice.Location = new Point(3, 0);
            labelEnumChoice.Name = "labelEnumChoice";
            labelEnumChoice.Size = new Size(121, 15);
            labelEnumChoice.TabIndex = 17;
            labelEnumChoice.Text = "Choose enumeration:";
            // 
            // listValueChoice
            // 
            listValueChoice.FormattingEnabled = true;
            listValueChoice.ItemHeight = 15;
            listValueChoice.Location = new Point(140, 17);
            listValueChoice.Margin = new Padding(3, 2, 3, 2);
            listValueChoice.Name = "listValueChoice";
            listValueChoice.Size = new Size(132, 169);
            listValueChoice.TabIndex = 16;
            listValueChoice.SelectedIndexChanged += listValueChoice_SelectedIndexChanged;
            // 
            // textBoxIntChoice
            // 
            textBoxIntChoice.Location = new Point(276, 17);
            textBoxIntChoice.Margin = new Padding(3, 2, 3, 2);
            textBoxIntChoice.Name = "textBoxIntChoice";
            textBoxIntChoice.Size = new Size(132, 23);
            textBoxIntChoice.TabIndex = 15;
            // 
            // listEnumChoice
            // 
            listEnumChoice.FormattingEnabled = true;
            listEnumChoice.ItemHeight = 15;
            listEnumChoice.Location = new Point(3, 17);
            listEnumChoice.Margin = new Padding(3, 2, 3, 2);
            listEnumChoice.Name = "listEnumChoice";
            listEnumChoice.Size = new Size(132, 169);
            listEnumChoice.TabIndex = 14;
            listEnumChoice.SelectedIndexChanged += listEnumChoice_SelectedIndexChanged;
            // 
            // Enumerations
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonSeason);
            Controls.Add(labelSeason);
            Controls.Add(comboBoxSeason);
            Controls.Add(labelParseResult);
            Controls.Add(buttonParse);
            Controls.Add(textBoxParse);
            Controls.Add(labelParsing);
            Controls.Add(labelIntValue);
            Controls.Add(labelValueChoice);
            Controls.Add(labelEnumChoice);
            Controls.Add(listValueChoice);
            Controls.Add(textBoxIntChoice);
            Controls.Add(listEnumChoice);
            Name = "Enumerations";
            Size = new Size(565, 302);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonSeason;
        private Label labelSeason;
        private ComboBox comboBoxSeason;
        private Label labelParseResult;
        private Button buttonParse;
        private TextBox textBoxParse;
        private Label labelParsing;
        private Label labelIntValue;
        private Label labelValueChoice;
        private Label labelEnumChoice;
        private ListBox listValueChoice;
        private TextBox textBoxIntChoice;
        private ListBox listEnumChoice;
    }
}
