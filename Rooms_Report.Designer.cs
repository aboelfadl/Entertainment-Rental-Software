﻿namespace ERS
{
    partial class Rooms_Report
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
            this.reporttype_grp = new System.Windows.Forms.GroupBox();
            this.oneroom_radio = new System.Windows.Forms.RadioButton();
            this.allrooms_radio = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.rooms_combo = new System.Windows.Forms.ComboBox();
            this.print_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.from_date = new System.Windows.Forms.DateTimePicker();
            this.to_date = new System.Windows.Forms.DateTimePicker();
            this.reporttype_grp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reporttype_grp
            // 
            this.reporttype_grp.Controls.Add(this.allrooms_radio);
            this.reporttype_grp.Controls.Add(this.oneroom_radio);
            this.reporttype_grp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.reporttype_grp.Location = new System.Drawing.Point(27, 80);
            this.reporttype_grp.Name = "reporttype_grp";
            this.reporttype_grp.Size = new System.Drawing.Size(200, 100);
            this.reporttype_grp.TabIndex = 0;
            this.reporttype_grp.TabStop = false;
            this.reporttype_grp.Text = "Report Type";
            // 
            // oneroom_radio
            // 
            this.oneroom_radio.AutoSize = true;
            this.oneroom_radio.ForeColor = System.Drawing.Color.Black;
            this.oneroom_radio.Location = new System.Drawing.Point(29, 35);
            this.oneroom_radio.Name = "oneroom_radio";
            this.oneroom_radio.Size = new System.Drawing.Size(91, 20);
            this.oneroom_radio.TabIndex = 0;
            this.oneroom_radio.TabStop = true;
            this.oneroom_radio.Text = "One Room";
            this.oneroom_radio.UseVisualStyleBackColor = true;
            // 
            // allrooms_radio
            // 
            this.allrooms_radio.AutoSize = true;
            this.allrooms_radio.ForeColor = System.Drawing.Color.Black;
            this.allrooms_radio.Location = new System.Drawing.Point(29, 61);
            this.allrooms_radio.Name = "allrooms_radio";
            this.allrooms_radio.Size = new System.Drawing.Size(88, 20);
            this.allrooms_radio.TabIndex = 1;
            this.allrooms_radio.TabStop = true;
            this.allrooms_radio.Text = "All Rooms";
            this.allrooms_radio.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(276, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room";
            // 
            // rooms_combo
            // 
            this.rooms_combo.Enabled = false;
            this.rooms_combo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rooms_combo.ForeColor = System.Drawing.Color.Black;
            this.rooms_combo.FormattingEnabled = true;
            this.rooms_combo.Location = new System.Drawing.Point(355, 122);
            this.rooms_combo.Name = "rooms_combo";
            this.rooms_combo.Size = new System.Drawing.Size(121, 24);
            this.rooms_combo.TabIndex = 2;
            // 
            // print_btn
            // 
            this.print_btn.ForeColor = System.Drawing.Color.Black;
            this.print_btn.Location = new System.Drawing.Point(215, 200);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(75, 23);
            this.print_btn.TabIndex = 3;
            this.print_btn.Text = "Print";
            this.print_btn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.to_date);
            this.groupBox1.Controls.Add(this.from_date);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(27, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(56, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "From";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(243, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "To";
            // 
            // from_date
            // 
            this.from_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from_date.Location = new System.Drawing.Point(111, 24);
            this.from_date.Name = "from_date";
            this.from_date.Size = new System.Drawing.Size(99, 22);
            this.from_date.TabIndex = 8;
            this.from_date.Value = new System.DateTime(2015, 4, 13, 1, 39, 57, 0);
            // 
            // to_date
            // 
            this.to_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to_date.Location = new System.Drawing.Point(285, 24);
            this.to_date.Name = "to_date";
            this.to_date.Size = new System.Drawing.Size(99, 22);
            this.to_date.TabIndex = 9;
            this.to_date.Value = new System.DateTime(2015, 4, 13, 1, 39, 57, 0);
            // 
            // Rooms_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 234);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.rooms_combo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reporttype_grp);
            this.Name = "Rooms_Report";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room(s) Report";
            this.reporttype_grp.ResumeLayout(false);
            this.reporttype_grp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox reporttype_grp;
        private System.Windows.Forms.RadioButton allrooms_radio;
        private System.Windows.Forms.RadioButton oneroom_radio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox rooms_combo;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker to_date;
        private System.Windows.Forms.DateTimePicker from_date;
    }
}