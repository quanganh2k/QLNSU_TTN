namespace quanlynhansu
{
    partial class frmHuongdan
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
            this.treeview_ItemList = new System.Windows.Forms.TreeView();
            this.richtextbox_Display = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // treeview_ItemList
            // 
            this.treeview_ItemList.BackColor = System.Drawing.SystemColors.Control;
            this.treeview_ItemList.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeview_ItemList.Location = new System.Drawing.Point(12, 12);
            this.treeview_ItemList.Name = "treeview_ItemList";
            this.treeview_ItemList.Size = new System.Drawing.Size(210, 381);
            this.treeview_ItemList.TabIndex = 0;
            this.treeview_ItemList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeview_ItemList_AfterSelect);
            // 
            // richtextbox_Display
            // 
            this.richtextbox_Display.BackColor = System.Drawing.SystemColors.Control;
            this.richtextbox_Display.Location = new System.Drawing.Point(229, 13);
            this.richtextbox_Display.Name = "richtextbox_Display";
            this.richtextbox_Display.Size = new System.Drawing.Size(554, 380);
            this.richtextbox_Display.TabIndex = 1;
            this.richtextbox_Display.Text = "";
            // 
            // frmHuongdan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 406);
            this.Controls.Add(this.richtextbox_Display);
            this.Controls.Add(this.treeview_ItemList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmHuongdan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHuongdan";
            this.Load += new System.EventHandler(this.frmHuongdan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeview_ItemList;
        private System.Windows.Forms.RichTextBox richtextbox_Display;
    }
}