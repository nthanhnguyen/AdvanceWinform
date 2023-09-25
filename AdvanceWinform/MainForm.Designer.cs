namespace AdvanceWinform
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnExcute = new C1.Win.C1Input.C1Button();
            this.c1MainMenu1 = new C1.Win.C1Command.C1MainMenu();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.winFormDbDataSet = new AdvanceWinform.WinFormDbDataSet();
            this.btnClose = new C1.Win.C1Input.C1Button();
            this.btnHelp = new C1.Win.C1Input.C1Button();
            this.c1ContextMenu1 = new C1.Win.C1Command.C1ContextMenu();
            this.c1CommandLink1 = new C1.Win.C1Command.C1CommandLink();
            this.btnAdd = new C1.Win.C1Command.C1Command();
            this.c1CommandLink2 = new C1.Win.C1Command.C1CommandLink();
            this.btnEdit = new C1.Win.C1Command.C1Command();
            this.c1CommandLink3 = new C1.Win.C1Command.C1CommandLink();
            this.btnDetail = new C1.Win.C1Command.C1Command();
            this.c1CommandLink4 = new C1.Win.C1Command.C1CommandLink();
            this.btnDelete = new C1.Win.C1Command.C1Command();
            this.c1CommandHolder1 = new C1.Win.C1Command.C1CommandHolder();
            this.userTableAdapter = new AdvanceWinform.WinFormDbDataSetTableAdapters.userTableAdapter();
            this.tableAdapterManager = new AdvanceWinform.WinFormDbDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winFormDbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHelp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcute
            // 
            this.c1CommandHolder1.SetC1ContextMenu(this.btnExcute, this.c1ContextMenu1);
            this.btnExcute.Location = new System.Drawing.Point(277, 359);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(122, 41);
            this.btnExcute.TabIndex = 0;
            this.btnExcute.Text = "Thực hiện";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.UseVisualStyleForeColor = true;
            // 
            // c1MainMenu1
            // 
            this.c1MainMenu1.AccessibleName = "Menu Bar";
            this.c1MainMenu1.CommandHolder = null;
            this.c1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c1MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.c1MainMenu1.Name = "c1MainMenu1";
            this.c1MainMenu1.Size = new System.Drawing.Size(800, 25);
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.ColumnInfo = resources.GetString("c1FlexGrid1.ColumnInfo");
            this.c1FlexGrid1.DataSource = this.userBindingSource;
            this.c1FlexGrid1.Location = new System.Drawing.Point(62, 31);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.Count = 1;
            this.c1FlexGrid1.Size = new System.Drawing.Size(670, 297);
            this.c1FlexGrid1.TabIndex = 3;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "user";
            this.userBindingSource.DataSource = this.winFormDbDataSet;
            // 
            // winFormDbDataSet
            // 
            this.winFormDbDataSet.DataSetName = "WinFormDbDataSet";
            this.winFormDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(425, 359);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(122, 41);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.UseVisualStyleForeColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(572, 359);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(122, 41);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "Trợ giúp";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.UseVisualStyleForeColor = true;
            // 
            // c1ContextMenu1
            // 
            this.c1ContextMenu1.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.c1CommandLink1,
            this.c1CommandLink2,
            this.c1CommandLink3,
            this.c1CommandLink4});
            this.c1ContextMenu1.Name = "c1ContextMenu1";
            this.c1ContextMenu1.ShortcutText = "";
            // 
            // c1CommandLink1
            // 
            this.c1CommandLink1.Command = this.btnAdd;
            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.ShortcutText = "Crtl+E";
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new C1.Win.C1Command.ClickEventHandler(this.btnAdd_Click);
            // 
            // c1CommandLink2
            // 
            this.c1CommandLink2.Command = this.btnEdit;
            this.c1CommandLink2.SortOrder = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ShortcutText = "";
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new C1.Win.C1Command.ClickEventHandler(this.btnEdit_Click);
            // 
            // c1CommandLink3
            // 
            this.c1CommandLink3.Command = this.btnDetail;
            this.c1CommandLink3.SortOrder = 2;
            // 
            // btnDetail
            // 
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.ShortcutText = "";
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.Click += new C1.Win.C1Command.ClickEventHandler(this.btnDetail_Click);
            // 
            // c1CommandLink4
            // 
            this.c1CommandLink4.Command = this.btnDelete;
            this.c1CommandLink4.SortOrder = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ShortcutText = "";
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new C1.Win.C1Command.ClickEventHandler(this.btnDelete_Click);
            // 
            // c1CommandHolder1
            // 
            this.c1CommandHolder1.Commands.Add(this.c1ContextMenu1);
            this.c1CommandHolder1.Commands.Add(this.btnAdd);
            this.c1CommandHolder1.Commands.Add(this.btnEdit);
            this.c1CommandHolder1.Commands.Add(this.btnDetail);
            this.c1CommandHolder1.Commands.Add(this.btnDelete);
            this.c1CommandHolder1.Owner = this;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = AdvanceWinform.WinFormDbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.userTableAdapter = this.userTableAdapter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.c1FlexGrid1);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.c1MainMenu1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnExcute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winFormDbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHelp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Input.C1Button btnExcute;
        private C1.Win.C1Command.C1MainMenu c1MainMenu1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private C1.Win.C1Input.C1Button btnHelp;
        private C1.Win.C1Input.C1Button btnClose;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder1;
        private C1.Win.C1Command.C1ContextMenu c1ContextMenu1;
        private C1.Win.C1Command.C1CommandLink c1CommandLink1;
        private C1.Win.C1Command.C1Command btnAdd;
        private C1.Win.C1Command.C1CommandLink c1CommandLink2;
        private C1.Win.C1Command.C1Command btnEdit;
        private C1.Win.C1Command.C1CommandLink c1CommandLink3;
        private C1.Win.C1Command.C1Command btnDetail;
        private C1.Win.C1Command.C1CommandLink c1CommandLink4;
        private C1.Win.C1Command.C1Command btnDelete;
        private WinFormDbDataSet winFormDbDataSet;
        private System.Windows.Forms.BindingSource userBindingSource;
        private WinFormDbDataSetTableAdapters.userTableAdapter userTableAdapter;
        private WinFormDbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
    }
}

