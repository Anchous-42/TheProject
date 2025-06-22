namespace TheProject
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
            tabControl1 = new TabControl();
            Rectangles = new TabPage();
            rectanglesCollisionControl1 = new TheProject.View.Panels.RectanglesCollisionControl();
            Classes = new TabPage();
            Enums = new TabPage();
            enumerations1 = new TheProject.View.Panels.EnumerationsControl();
            classesControl1 = new TheProject.View.Panels.ClassesControl();
            tabControl1.SuspendLayout();
            Rectangles.SuspendLayout();
            Classes.SuspendLayout();
            Enums.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Rectangles);
            tabControl1.Controls.Add(Classes);
            tabControl1.Controls.Add(Enums);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(3, 2, 3, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1087, 644);
            tabControl1.TabIndex = 0;
            // 
            // Rectangles
            // 
            Rectangles.Controls.Add(rectanglesCollisionControl1);
            Rectangles.Location = new Point(4, 24);
            Rectangles.Name = "Rectangles";
            Rectangles.Size = new Size(1079, 616);
            Rectangles.TabIndex = 2;
            Rectangles.Text = "Rectangles";
            Rectangles.UseVisualStyleBackColor = true;
            // 
            // rectanglesCollisionControl1
            // 
            rectanglesCollisionControl1.AutoSize = true;
            rectanglesCollisionControl1.Dock = DockStyle.Fill;
            rectanglesCollisionControl1.Location = new Point(0, 0);
            rectanglesCollisionControl1.Name = "rectanglesCollisionControl1";
            rectanglesCollisionControl1.Size = new Size(1079, 616);
            rectanglesCollisionControl1.TabIndex = 0;
            // 
            // Classes
            // 
            Classes.Controls.Add(classesControl1);
            Classes.Location = new Point(4, 24);
            Classes.Name = "Classes";
            Classes.Size = new Size(1079, 616);
            Classes.TabIndex = 1;
            Classes.Text = "Classes";
            Classes.UseVisualStyleBackColor = true;
            // 
            // Enums
            // 
            Enums.Controls.Add(enumerations1);
            Enums.Location = new Point(4, 24);
            Enums.Margin = new Padding(3, 2, 3, 2);
            Enums.Name = "Enums";
            Enums.Padding = new Padding(3, 2, 3, 2);
            Enums.Size = new Size(1079, 616);
            Enums.TabIndex = 0;
            Enums.Text = "Enums";
            Enums.UseVisualStyleBackColor = true;
            // 
            // enumerations1
            // 
            enumerations1.Dock = DockStyle.Fill;
            enumerations1.Location = new Point(3, 2);
            enumerations1.Name = "enumerations1";
            enumerations1.Size = new Size(1073, 612);
            enumerations1.TabIndex = 0;
            // 
            // classesControl1
            // 
            classesControl1.Dock = DockStyle.Fill;
            classesControl1.Location = new Point(0, 0);
            classesControl1.Name = "classesControl1";
            classesControl1.Size = new Size(1079, 616);
            classesControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 644);
            Controls.Add(tabControl1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Enumeration Choice";
            tabControl1.ResumeLayout(false);
            Rectangles.ResumeLayout(false);
            Rectangles.PerformLayout();
            Classes.ResumeLayout(false);
            Enums.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Enums;
        private TextBox textValueChoice;
        private TabPage Classes;
        private TabPage Rectangles;
        private View.Panels.RectanglesCollisionControl rectanglesCollisionControl1;
        private View.Panels.EnumerationsControl enumerations1;
        private View.Panels.ClassesControl classesControl1;
    }
}
