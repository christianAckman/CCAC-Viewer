namespace CCAC_Scraper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnGetSubjects = new System.Windows.Forms.Button();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.listBox_Subjects = new System.Windows.Forms.ListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.btnGetClasses = new System.Windows.Forms.Button();
            this.btnGetSyllabus = new System.Windows.Forms.Button();
            this.dtg_Courses = new System.Windows.Forms.DataGridView();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Courses)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetSubjects
            // 
            this.btnGetSubjects.Location = new System.Drawing.Point(932, 51);
            this.btnGetSubjects.Name = "btnGetSubjects";
            this.btnGetSubjects.Size = new System.Drawing.Size(89, 23);
            this.btnGetSubjects.TabIndex = 0;
            this.btnGetSubjects.Text = "Get Subjects";
            this.btnGetSubjects.UseVisualStyleBackColor = true;
            this.btnGetSubjects.Click += new System.EventHandler(this.getSubjects_Click);
            // 
            // webBrowser
            // 
            this.webBrowser.Location = new System.Drawing.Point(3, 3);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(904, 808);
            this.webBrowser.TabIndex = 1;
            // 
            // listBox_Subjects
            // 
            this.listBox_Subjects.FormattingEnabled = true;
            this.listBox_Subjects.Location = new System.Drawing.Point(932, 80);
            this.listBox_Subjects.Name = "listBox_Subjects";
            this.listBox_Subjects.Size = new System.Drawing.Size(215, 745);
            this.listBox_Subjects.TabIndex = 2;
            // 
            // panel
            // 
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.webBrowser);
            this.panel.Location = new System.Drawing.Point(12, 12);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(914, 818);
            this.panel.TabIndex = 3;
            // 
            // btnGetClasses
            // 
            this.btnGetClasses.Location = new System.Drawing.Point(1153, 51);
            this.btnGetClasses.Name = "btnGetClasses";
            this.btnGetClasses.Size = new System.Drawing.Size(75, 23);
            this.btnGetClasses.TabIndex = 5;
            this.btnGetClasses.Text = "Get Classes";
            this.btnGetClasses.UseVisualStyleBackColor = true;
            this.btnGetClasses.Click += new System.EventHandler(this.btnGetClasses_Click);
            // 
            // btnGetSyllabus
            // 
            this.btnGetSyllabus.Location = new System.Drawing.Point(1360, 51);
            this.btnGetSyllabus.Name = "btnGetSyllabus";
            this.btnGetSyllabus.Size = new System.Drawing.Size(75, 23);
            this.btnGetSyllabus.TabIndex = 6;
            this.btnGetSyllabus.Text = "Get Syllabus";
            this.btnGetSyllabus.UseVisualStyleBackColor = true;
            this.btnGetSyllabus.Click += new System.EventHandler(this.btnGetSyllabus_Click);
            // 
            // dtg_Courses
            // 
            this.dtg_Courses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtg_Courses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtg_Courses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_Courses.Location = new System.Drawing.Point(1153, 80);
            this.dtg_Courses.MultiSelect = false;
            this.dtg_Courses.Name = "dtg_Courses";
            this.dtg_Courses.ReadOnly = true;
            this.dtg_Courses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtg_Courses.Size = new System.Drawing.Size(492, 745);
            this.dtg_Courses.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1657, 831);
            this.Controls.Add(this.dtg_Courses);
            this.Controls.Add(this.btnGetSyllabus);
            this.Controls.Add(this.btnGetClasses);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.listBox_Subjects);
            this.Controls.Add(this.btnGetSubjects);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CCAC Master Syllabi";
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_Courses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetSubjects;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ListBox listBox_Subjects;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button btnGetClasses;
        private System.Windows.Forms.Button btnGetSyllabus;
        private System.Windows.Forms.DataGridView dtg_Courses;
    }
}

