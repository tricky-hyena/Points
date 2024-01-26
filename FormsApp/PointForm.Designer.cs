namespace FormsApp
{
	partial class PointForm
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
			this.listBox = new System.Windows.Forms.ListBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.btnSort = new System.Windows.Forms.Button();
			this.btnSerialize = new System.Windows.Forms.Button();
			this.btnDeserialize = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox
			// 
			this.listBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listBox.FormattingEnabled = true;
			this.listBox.ItemHeight = 23;
			this.listBox.Location = new System.Drawing.Point(28, 12);
			this.listBox.Name = "listBox";
			this.listBox.Size = new System.Drawing.Size(702, 303);
			this.listBox.TabIndex = 0;
			// 
			// btnCreate
			// 
			this.btnCreate.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.btnCreate.Location = new System.Drawing.Point(63, 347);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(115, 58);
			this.btnCreate.TabIndex = 1;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// btnSort
			// 
			this.btnSort.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.btnSort.Location = new System.Drawing.Point(229, 347);
			this.btnSort.Name = "btnSort";
			this.btnSort.Size = new System.Drawing.Size(115, 58);
			this.btnSort.TabIndex = 2;
			this.btnSort.Text = "Sort";
			this.btnSort.UseVisualStyleBackColor = true;
			this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
			// 
			// btnSerialize
			// 
			this.btnSerialize.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.btnSerialize.Location = new System.Drawing.Point(385, 347);
			this.btnSerialize.Name = "btnSerialize";
			this.btnSerialize.Size = new System.Drawing.Size(145, 58);
			this.btnSerialize.TabIndex = 3;
			this.btnSerialize.Text = "Serialize";
			this.btnSerialize.UseVisualStyleBackColor = true;
			this.btnSerialize.Click += new System.EventHandler(this.btnSerialize_Click);
			// 
			// btnDeserialize
			// 
			this.btnDeserialize.Font = new System.Drawing.Font("Century Gothic", 12F);
			this.btnDeserialize.Location = new System.Drawing.Point(566, 347);
			this.btnDeserialize.Name = "btnDeserialize";
			this.btnDeserialize.Size = new System.Drawing.Size(151, 58);
			this.btnDeserialize.TabIndex = 4;
			this.btnDeserialize.Text = "Deserialize";
			this.btnDeserialize.UseVisualStyleBackColor = true;
			this.btnDeserialize.Click += new System.EventHandler(this.btnDeserialize_Click);
			// 
			// PointForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(763, 437);
			this.Controls.Add(this.btnDeserialize);
			this.Controls.Add(this.btnSerialize);
			this.Controls.Add(this.btnSort);
			this.Controls.Add(this.btnCreate);
			this.Controls.Add(this.listBox);
			this.Name = "PointForm";
			this.Text = "PointsForm";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBox;
		private System.Windows.Forms.Button btnCreate;
		private System.Windows.Forms.Button btnSort;
		private System.Windows.Forms.Button btnSerialize;
		private System.Windows.Forms.Button btnDeserialize;
	}
}

