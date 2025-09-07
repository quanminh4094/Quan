namespace BTL.Views
{
    partial class FrmStudentClass
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvClasses = new System.Windows.Forms.DataGridView();
            this.btnShowClasses = new System.Windows.Forms.Button();
            this.btnShowCourses = new System.Windows.Forms.Button();
            this.cbStudents = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(627, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách Lớp và Môn sinh viên đã tham gia";
            // 
            // dgvClasses
            // 
            this.dgvClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasses.Location = new System.Drawing.Point(138, 350);
            this.dgvClasses.Name = "dgvClasses";
            this.dgvClasses.Size = new System.Drawing.Size(724, 471);
            this.dgvClasses.TabIndex = 1;
            // 
            // btnShowClasses
            // 
            this.btnShowClasses.Location = new System.Drawing.Point(425, 244);
            this.btnShowClasses.Name = "btnShowClasses";
            this.btnShowClasses.Size = new System.Drawing.Size(136, 47);
            this.btnShowClasses.TabIndex = 2;
            this.btnShowClasses.Text = "Tìm Lớp";
            this.btnShowClasses.UseVisualStyleBackColor = true;
            this.btnShowClasses.Click += new System.EventHandler(this.btnShowClasses_Click);
            // 
            // btnShowCourses
            // 
            this.btnShowCourses.Location = new System.Drawing.Point(1406, 244);
            this.btnShowCourses.Name = "btnShowCourses";
            this.btnShowCourses.Size = new System.Drawing.Size(136, 47);
            this.btnShowCourses.TabIndex = 3;
            this.btnShowCourses.Text = "Tìm Môn";
            this.btnShowCourses.UseVisualStyleBackColor = true;
            this.btnShowCourses.Click += new System.EventHandler(this.btnShowCourses_Click);
            // 
            // cbStudents
            // 
            this.cbStudents.FormattingEnabled = true;
            this.cbStudents.Location = new System.Drawing.Point(895, 101);
            this.cbStudents.Name = "cbStudents";
            this.cbStudents.Size = new System.Drawing.Size(121, 21);
            this.cbStudents.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(731, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chọn một sinh viên";
            // 
            // dgvCourses
            // 
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(1069, 350);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(715, 471);
            this.dgvCourses.TabIndex = 6;
            // 
            // FrmStudentClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.dgvCourses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbStudents);
            this.Controls.Add(this.btnShowCourses);
            this.Controls.Add(this.btnShowClasses);
            this.Controls.Add(this.dgvClasses);
            this.Controls.Add(this.label1);
            this.Name = "FrmStudentClass";
            this.Text = "FrmStudentClass";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvClasses;
        private System.Windows.Forms.Button btnShowClasses;
        private System.Windows.Forms.Button btnShowCourses;
        private System.Windows.Forms.ComboBox cbStudents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCourses;
    }
}