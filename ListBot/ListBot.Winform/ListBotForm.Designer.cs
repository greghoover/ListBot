namespace ListBot.Winform
{
	partial class ListBotForm
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
			this.buttonSubmitUrl = new System.Windows.Forms.Button();
			this.textBoxUrl = new System.Windows.Forms.TextBox();
			this.textBoxResponse = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// buttonSubmitUrl
			// 
			this.buttonSubmitUrl.Location = new System.Drawing.Point(826, 12);
			this.buttonSubmitUrl.Name = "buttonSubmitUrl";
			this.buttonSubmitUrl.Size = new System.Drawing.Size(99, 23);
			this.buttonSubmitUrl.TabIndex = 0;
			this.buttonSubmitUrl.Text = "Submit URL";
			this.buttonSubmitUrl.UseVisualStyleBackColor = true;
			this.buttonSubmitUrl.Click += new System.EventHandler(this.buttonSubmitUrl_Click);
			// 
			// textBoxUrl
			// 
			this.textBoxUrl.Location = new System.Drawing.Point(12, 12);
			this.textBoxUrl.Name = "textBoxUrl";
			this.textBoxUrl.Size = new System.Drawing.Size(808, 22);
			this.textBoxUrl.TabIndex = 1;
			this.textBoxUrl.Text = "http://stat.pcanet.org/ac/directory/directory.cfm";
			// 
			// textBoxResponse
			// 
			this.textBoxResponse.Location = new System.Drawing.Point(12, 40);
			this.textBoxResponse.Multiline = true;
			this.textBoxResponse.Name = "textBoxResponse";
			this.textBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxResponse.Size = new System.Drawing.Size(913, 489);
			this.textBoxResponse.TabIndex = 2;
			// 
			// ListBotForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(937, 551);
			this.Controls.Add(this.textBoxResponse);
			this.Controls.Add(this.textBoxUrl);
			this.Controls.Add(this.buttonSubmitUrl);
			this.Name = "ListBotForm";
			this.Text = "ListBot";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonSubmitUrl;
		private System.Windows.Forms.TextBox textBoxUrl;
		private System.Windows.Forms.TextBox textBoxResponse;
	}
}