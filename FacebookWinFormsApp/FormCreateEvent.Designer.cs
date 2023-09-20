namespace FacebookAppForDesktopInterface
{
    partial class FormCreateEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateEvent));
            this.pickDateLabel = new System.Windows.Forms.Label();
            this.askWhereEventBeLabel = new System.Windows.Forms.Label();
            this.dateTimePickerDateEvent = new System.Windows.Forms.DateTimePicker();
            this.textBoxCityOfEvent = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pickDateLabel
            // 
            this.pickDateLabel.AutoSize = true;
            this.pickDateLabel.BackColor = System.Drawing.SystemColors.Info;
            this.pickDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.pickDateLabel.Location = new System.Drawing.Point(12, 61);
            this.pickDateLabel.Name = "pickDateLabel";
            this.pickDateLabel.Size = new System.Drawing.Size(187, 25);
            this.pickDateLabel.TabIndex = 0;
            this.pickDateLabel.Text = "Pick a date and time";
            // 
            // askWhereEventBeLabel
            // 
            this.askWhereEventBeLabel.AutoSize = true;
            this.askWhereEventBeLabel.BackColor = System.Drawing.SystemColors.Info;
            this.askWhereEventBeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.askWhereEventBeLabel.Location = new System.Drawing.Point(12, 162);
            this.askWhereEventBeLabel.Name = "askWhereEventBeLabel";
            this.askWhereEventBeLabel.Size = new System.Drawing.Size(323, 25);
            this.askWhereEventBeLabel.TabIndex = 1;
            this.askWhereEventBeLabel.Text = "Which city the event will take place?";
            // 
            // dateTimePickerDateEvent
            // 
            this.dateTimePickerDateEvent.CustomFormat = "MM/dd/yyyy hh:mm:ss";
            this.dateTimePickerDateEvent.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerDateEvent.Location = new System.Drawing.Point(17, 92);
            this.dateTimePickerDateEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerDateEvent.MinDate = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            this.dateTimePickerDateEvent.Name = "dateTimePickerDateEvent";
            this.dateTimePickerDateEvent.Size = new System.Drawing.Size(237, 22);
            this.dateTimePickerDateEvent.TabIndex = 2;
            this.dateTimePickerDateEvent.Value = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            // 
            // textBoxCityOfEvent
            // 
            this.textBoxCityOfEvent.Location = new System.Drawing.Point(17, 192);
            this.textBoxCityOfEvent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCityOfEvent.Name = "textBoxCityOfEvent";
            this.textBoxCityOfEvent.Size = new System.Drawing.Size(200, 22);
            this.textBoxCityOfEvent.TabIndex = 3;
            // 
            // buttonCreate
            // 
            this.buttonCreate.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonCreate.Location = new System.Drawing.Point(87, 264);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(220, 45);
            this.buttonCreate.TabIndex = 4;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = false;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::BasicFacebookFeatures.Properties.Resources.ballons_rose_gold;
            this.ClientSize = new System.Drawing.Size(392, 350);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxCityOfEvent);
            this.Controls.Add(this.dateTimePickerDateEvent);
            this.Controls.Add(this.askWhereEventBeLabel);
            this.Controls.Add(this.pickDateLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pickDateLabel;
        private System.Windows.Forms.Label askWhereEventBeLabel;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateEvent;
        private System.Windows.Forms.TextBox textBoxCityOfEvent;
        private System.Windows.Forms.Button buttonCreate;
    }
}