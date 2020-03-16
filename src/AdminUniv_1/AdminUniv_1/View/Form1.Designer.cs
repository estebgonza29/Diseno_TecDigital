namespace AdminUniv_1
{
    partial class Main
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
            this.cmboxCourse = new System.Windows.Forms.ComboBox();
            this.cmboxGroup = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmboxCourse
            // 
            this.cmboxCourse.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboxCourse.FormattingEnabled = true;
            this.cmboxCourse.ItemHeight = 19;
            this.cmboxCourse.Location = new System.Drawing.Point(178, 99);
            this.cmboxCourse.Name = "cmboxCourse";
            this.cmboxCourse.Size = new System.Drawing.Size(342, 27);
            this.cmboxCourse.TabIndex = 0;
            // 
            // cmboxGroup
            // 
            this.cmboxGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmboxGroup.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmboxGroup.FormattingEnabled = true;
            this.cmboxGroup.Location = new System.Drawing.Point(591, 99);
            this.cmboxGroup.Name = "cmboxGroup";
            this.cmboxGroup.Size = new System.Drawing.Size(342, 27);
            this.cmboxGroup.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSearch.BackgroundImage = global::AdminUniv_1.Properties.Resources.button;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Gadugi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearch.Location = new System.Drawing.Point(955, 91);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 41);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(121, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Curso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Gadugi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(526, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grupo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Gadugi", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(462, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(294, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tabla de Evaluaciones";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grid.ColumnHeadersHeight = 30;
            this.grid.Location = new System.Drawing.Point(34, 147);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1150, 672);
            this.grid.TabIndex = 7;
            this.grid.Paint += new System.Windows.Forms.PaintEventHandler(this.grid_Paint);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::AdminUniv_1.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1221, 831);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmboxGroup);
            this.Controls.Add(this.cmboxCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabla de evaluaciones";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmboxCourse;
        private System.Windows.Forms.ComboBox cmboxGroup;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grid;
    }
}

