namespace TheProject.View.Panels
{
    partial class RectanglesCollisionControl
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
            labelRectanglesPage = new Label();
            listBoxRectanglesPage = new ListBox();
            labelSelectedRect = new Label();
            labelRectId = new Label();
            labelRectX = new Label();
            labelRectY = new Label();
            labelRectWidth = new Label();
            labelRectHeight = new Label();
            textBoxRectID = new TextBox();
            textBoxRectX = new TextBox();
            textBoxRectY = new TextBox();
            textBoxRectWidth = new TextBox();
            textBoxRectHeight = new TextBox();
            panelCanvas = new Panel();
            buttonAddRect = new Button();
            buttonDeleteRect = new Button();
            SuspendLayout();
            // 
            // labelRectanglesPage
            // 
            labelRectanglesPage.AutoSize = true;
            labelRectanglesPage.Location = new Point(3, 0);
            labelRectanglesPage.Name = "labelRectanglesPage";
            labelRectanglesPage.Size = new Size(67, 15);
            labelRectanglesPage.TabIndex = 0;
            labelRectanglesPage.Text = "Rectangles:";
            // 
            // listBoxRectanglesPage
            // 
            listBoxRectanglesPage.FormattingEnabled = true;
            listBoxRectanglesPage.ItemHeight = 15;
            listBoxRectanglesPage.Location = new Point(3, 18);
            listBoxRectanglesPage.Name = "listBoxRectanglesPage";
            listBoxRectanglesPage.Size = new Size(210, 199);
            listBoxRectanglesPage.TabIndex = 1;
            listBoxRectanglesPage.SelectedIndexChanged += listBoxRectanglesPage_SelectedIndexChanged;
            // 
            // labelSelectedRect
            // 
            labelSelectedRect.AutoSize = true;
            labelSelectedRect.Location = new Point(3, 249);
            labelSelectedRect.Name = "labelSelectedRect";
            labelSelectedRect.Size = new Size(109, 15);
            labelSelectedRect.TabIndex = 4;
            labelSelectedRect.Text = "Selected Rectangle:";
            // 
            // labelRectId
            // 
            labelRectId.AutoSize = true;
            labelRectId.Location = new Point(72, 270);
            labelRectId.Name = "labelRectId";
            labelRectId.Size = new Size(21, 15);
            labelRectId.TabIndex = 5;
            labelRectId.Text = "ID:";
            // 
            // labelRectX
            // 
            labelRectX.AutoSize = true;
            labelRectX.Location = new Point(76, 304);
            labelRectX.Name = "labelRectX";
            labelRectX.Size = new Size(17, 15);
            labelRectX.TabIndex = 6;
            labelRectX.Text = "X:";
            // 
            // labelRectY
            // 
            labelRectY.AutoSize = true;
            labelRectY.Location = new Point(76, 333);
            labelRectY.Name = "labelRectY";
            labelRectY.Size = new Size(17, 15);
            labelRectY.TabIndex = 7;
            labelRectY.Text = "Y:";
            // 
            // labelRectWidth
            // 
            labelRectWidth.AutoSize = true;
            labelRectWidth.Location = new Point(51, 362);
            labelRectWidth.Name = "labelRectWidth";
            labelRectWidth.Size = new Size(42, 15);
            labelRectWidth.TabIndex = 8;
            labelRectWidth.Text = "Width:";
            // 
            // labelRectHeight
            // 
            labelRectHeight.AutoSize = true;
            labelRectHeight.Location = new Point(47, 391);
            labelRectHeight.Name = "labelRectHeight";
            labelRectHeight.Size = new Size(46, 15);
            labelRectHeight.TabIndex = 9;
            labelRectHeight.Text = "Height:";
            // 
            // textBoxRectID
            // 
            textBoxRectID.Location = new Point(99, 267);
            textBoxRectID.Name = "textBoxRectID";
            textBoxRectID.ReadOnly = true;
            textBoxRectID.Size = new Size(100, 23);
            textBoxRectID.TabIndex = 10;
            // 
            // textBoxRectX
            // 
            textBoxRectX.Location = new Point(99, 296);
            textBoxRectX.Name = "textBoxRectX";
            textBoxRectX.Size = new Size(100, 23);
            textBoxRectX.TabIndex = 11;
            textBoxRectX.TextChanged += textBoxRectX_TextChanged;
            // 
            // textBoxRectY
            // 
            textBoxRectY.Location = new Point(99, 325);
            textBoxRectY.Name = "textBoxRectY";
            textBoxRectY.Size = new Size(100, 23);
            textBoxRectY.TabIndex = 12;
            textBoxRectY.TextChanged += textBoxRectY_TextChanged;
            // 
            // textBoxRectWidth
            // 
            textBoxRectWidth.Location = new Point(99, 354);
            textBoxRectWidth.Name = "textBoxRectWidth";
            textBoxRectWidth.Size = new Size(100, 23);
            textBoxRectWidth.TabIndex = 13;
            textBoxRectWidth.TextChanged += textBoxRectWidth_TextChanged;
            // 
            // textBoxRectHeight
            // 
            textBoxRectHeight.Location = new Point(99, 383);
            textBoxRectHeight.Name = "textBoxRectHeight";
            textBoxRectHeight.Size = new Size(100, 23);
            textBoxRectHeight.TabIndex = 14;
            textBoxRectHeight.TextChanged += textBoxRectHeight_TextChanged;
            // 
            // panelCanvas
            // 
            panelCanvas.BorderStyle = BorderStyle.FixedSingle;
            panelCanvas.Location = new Point(296, 3);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(800, 537);
            panelCanvas.TabIndex = 15;
            panelCanvas.Paint += panelCanvas_Paint;
            // 
            // buttonAddRect
            // 
            buttonAddRect.Location = new Point(3, 223);
            buttonAddRect.Name = "buttonAddRect";
            buttonAddRect.Size = new Size(75, 23);
            buttonAddRect.TabIndex = 16;
            buttonAddRect.Text = "Add";
            buttonAddRect.UseVisualStyleBackColor = true;
            buttonAddRect.Click += buttonAddRect_Click;
            // 
            // buttonDeleteRect
            // 
            buttonDeleteRect.Location = new Point(138, 223);
            buttonDeleteRect.Name = "buttonDeleteRect";
            buttonDeleteRect.Size = new Size(75, 23);
            buttonDeleteRect.TabIndex = 17;
            buttonDeleteRect.Text = "Delete";
            buttonDeleteRect.UseVisualStyleBackColor = true;
            buttonDeleteRect.Click += buttonDeleteRect_Click;
            // 
            // RectanglesCollisionControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panelCanvas);
            Controls.Add(buttonDeleteRect);
            Controls.Add(labelRectHeight);
            Controls.Add(textBoxRectHeight);
            Controls.Add(textBoxRectWidth);
            Controls.Add(labelRectWidth);
            Controls.Add(buttonAddRect);
            Controls.Add(textBoxRectY);
            Controls.Add(labelRectanglesPage);
            Controls.Add(labelRectY);
            Controls.Add(textBoxRectX);
            Controls.Add(listBoxRectanglesPage);
            Controls.Add(textBoxRectID);
            Controls.Add(labelRectX);
            Controls.Add(labelSelectedRect);
            Controls.Add(labelRectId);
            Name = "RectanglesCollisionControl";
            Size = new Size(1099, 558);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelRectanglesPage;
        private ListBox listBoxRectanglesPage;
        private Label labelSelectedRect;
        private Label labelRectId;
        private Label labelRectX;
        private Label labelRectY;
        private Label labelRectWidth;
        private Label labelRectHeight;
        private TextBox textBoxRectID;
        private TextBox textBoxRectX;
        private TextBox textBoxRectY;
        private TextBox textBoxRectWidth;
        private TextBox textBoxRectHeight;
        private Panel panelCanvas;
        private Button buttonAddRect;
        private Button buttonDeleteRect;
    }
}
