namespace RevitWallMaterialManager.UI
{
    partial class FormSetCompoundStructureFinish
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvWalls = new System.Windows.Forms.DataGridView();
            this.ColumnWalls = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvInterior = new System.Windows.Forms.DataGridView();
            this.ColumnInterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThicknessInterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvExterior = new System.Windows.Forms.DataGridView();
            this.ColumnExterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThicknessExterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvStructure = new System.Windows.Forms.DataGridView();
            this.ColumnStructure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnThicknessStructure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbMaterial = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbbChooseLayers = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_DeleteLayerMaterial = new System.Windows.Forms.Button();
            this.btn_ChangeMaterial = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxInputThickness = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Overwrite = new System.Windows.Forms.Button();
            this.btn_SaveTemplate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalls)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterior)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExterior)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructure)).BeginInit();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(707, 468);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.75655F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.24345F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 204F));
            this.tableLayoutPanel2.Controls.Add(this.dgvWalls, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel13, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(701, 412);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // dgvWalls
            // 
            this.dgvWalls.AllowUserToAddRows = false;
            this.dgvWalls.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvWalls.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWalls.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnWalls});
            this.dgvWalls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWalls.Location = new System.Drawing.Point(3, 3);
            this.dgvWalls.Name = "dgvWalls";
            this.dgvWalls.RowHeadersVisible = false;
            this.dgvWalls.Size = new System.Drawing.Size(216, 406);
            this.dgvWalls.TabIndex = 0;
            // 
            // ColumnWalls
            // 
            this.ColumnWalls.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnWalls.HeaderText = "Walll Type Name";
            this.ColumnWalls.Name = "ColumnWalls";
            this.ColumnWalls.ReadOnly = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel7, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(225, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(268, 406);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.05202F));
            this.tableLayoutPanel7.Controls.Add(this.dgvInterior, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 245);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(262, 158);
            this.tableLayoutPanel7.TabIndex = 2;
            // 
            // dgvInterior
            // 
            this.dgvInterior.AllowUserToAddRows = false;
            this.dgvInterior.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvInterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInterior.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInterior,
            this.ColumnThicknessInterior});
            this.dgvInterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInterior.Location = new System.Drawing.Point(3, 3);
            this.dgvInterior.Name = "dgvInterior";
            this.dgvInterior.RowHeadersVisible = false;
            this.dgvInterior.Size = new System.Drawing.Size(256, 152);
            this.dgvInterior.TabIndex = 1;
            // 
            // ColumnInterior
            // 
            this.ColumnInterior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnInterior.HeaderText = "Interrior Layer";
            this.ColumnInterior.Name = "ColumnInterior";
            this.ColumnInterior.ReadOnly = true;
            // 
            // ColumnThicknessInterior
            // 
            this.ColumnThicknessInterior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnThicknessInterior.HeaderText = "Thickness (mm)";
            this.ColumnThicknessInterior.Name = "ColumnThicknessInterior";
            this.ColumnThicknessInterior.ReadOnly = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.86913F));
            this.tableLayoutPanel5.Controls.Add(this.dgvExterior, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(262, 157);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // dgvExterior
            // 
            this.dgvExterior.AllowUserToAddRows = false;
            this.dgvExterior.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvExterior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExterior.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExterior,
            this.ColumnThicknessExterior});
            this.dgvExterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExterior.Location = new System.Drawing.Point(3, 3);
            this.dgvExterior.Name = "dgvExterior";
            this.dgvExterior.RowHeadersVisible = false;
            this.dgvExterior.Size = new System.Drawing.Size(256, 151);
            this.dgvExterior.TabIndex = 0;
            // 
            // ColumnExterior
            // 
            this.ColumnExterior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnExterior.HeaderText = "Exterior Layer";
            this.ColumnExterior.Name = "ColumnExterior";
            this.ColumnExterior.ReadOnly = true;
            // 
            // ColumnThicknessExterior
            // 
            this.ColumnThicknessExterior.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnThicknessExterior.HeaderText = "Thickness (mm)";
            this.ColumnThicknessExterior.Name = "ColumnThicknessExterior";
            this.ColumnThicknessExterior.ReadOnly = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.76301F));
            this.tableLayoutPanel6.Controls.Add(this.dgvStructure, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 166);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(262, 73);
            this.tableLayoutPanel6.TabIndex = 3;
            // 
            // dgvStructure
            // 
            this.dgvStructure.AllowUserToAddRows = false;
            this.dgvStructure.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStructure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStructure,
            this.ColumnThicknessStructure});
            this.dgvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStructure.Location = new System.Drawing.Point(3, 3);
            this.dgvStructure.Name = "dgvStructure";
            this.dgvStructure.RowHeadersVisible = false;
            this.dgvStructure.Size = new System.Drawing.Size(256, 67);
            this.dgvStructure.TabIndex = 1;
            // 
            // ColumnStructure
            // 
            this.ColumnStructure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnStructure.HeaderText = "Structure Layer";
            this.ColumnStructure.Name = "ColumnStructure";
            this.ColumnStructure.ReadOnly = true;
            // 
            // ColumnThicknessStructure
            // 
            this.ColumnThicknessStructure.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnThicknessStructure.HeaderText = "Thickness (mm)";
            this.ColumnThicknessStructure.Name = "ColumnThicknessStructure";
            this.ColumnThicknessStructure.ReadOnly = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.cbbMaterial, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel14, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.tableLayoutPanel8, 0, 3);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(499, 3);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 6;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.58025F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.444445F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.91358F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.08642F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.12346F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(199, 406);
            this.tableLayoutPanel13.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Material Layer";
            // 
            // cbbMaterial
            // 
            this.cbbMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMaterial.FormattingEnabled = true;
            this.cbbMaterial.Location = new System.Drawing.Point(3, 76);
            this.cbbMaterial.Name = "cbbMaterial";
            this.cbbMaterial.Size = new System.Drawing.Size(193, 21);
            this.cbbMaterial.TabIndex = 2;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.cbbChooseLayers, 0, 1);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.93103F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.06897F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(193, 49);
            this.tableLayoutPanel9.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Layer type";
            // 
            // cbbChooseLayers
            // 
            this.cbbChooseLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbChooseLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChooseLayers.FormattingEnabled = true;
            this.cbbChooseLayers.Location = new System.Drawing.Point(3, 21);
            this.cbbChooseLayers.Name = "cbbChooseLayers";
            this.cbbChooseLayers.Size = new System.Drawing.Size(187, 21);
            this.cbbChooseLayers.TabIndex = 4;
            this.cbbChooseLayers.SelectedIndexChanged += new System.EventHandler(this.cbbChooseLayers_SelectedIndexChanged);
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 2;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Controls.Add(this.btn_DeleteLayerMaterial, 1, 0);
            this.tableLayoutPanel14.Controls.Add(this.btn_ChangeMaterial, 0, 0);
            this.tableLayoutPanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel14.Location = new System.Drawing.Point(3, 157);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 1;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(193, 39);
            this.tableLayoutPanel14.TabIndex = 8;
            // 
            // btn_DeleteLayerMaterial
            // 
            this.btn_DeleteLayerMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_DeleteLayerMaterial.Location = new System.Drawing.Point(96, 0);
            this.btn_DeleteLayerMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.btn_DeleteLayerMaterial.Name = "btn_DeleteLayerMaterial";
            this.btn_DeleteLayerMaterial.Size = new System.Drawing.Size(97, 39);
            this.btn_DeleteLayerMaterial.TabIndex = 2;
            this.btn_DeleteLayerMaterial.Text = "Delete Material";
            this.btn_DeleteLayerMaterial.UseVisualStyleBackColor = true;
            this.btn_DeleteLayerMaterial.Click += new System.EventHandler(this.btn_DeleteLayerMaterial_Click);
            // 
            // btn_ChangeMaterial
            // 
            this.btn_ChangeMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ChangeMaterial.Location = new System.Drawing.Point(0, 0);
            this.btn_ChangeMaterial.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ChangeMaterial.Name = "btn_ChangeMaterial";
            this.btn_ChangeMaterial.Size = new System.Drawing.Size(96, 39);
            this.btn_ChangeMaterial.TabIndex = 3;
            this.btn_ChangeMaterial.Text = "Change material";
            this.btn_ChangeMaterial.UseVisualStyleBackColor = true;
            this.btn_ChangeMaterial.Click += new System.EventHandler(this.btn_ChangeMaterial_Click);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.tboxInputThickness, 0, 1);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 104);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(193, 47);
            this.tableLayoutPanel8.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thickness (mm)";
            // 
            // tboxInputThickness
            // 
            this.tboxInputThickness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxInputThickness.Location = new System.Drawing.Point(0, 18);
            this.tboxInputThickness.Margin = new System.Windows.Forms.Padding(0);
            this.tboxInputThickness.Name = "tboxInputThickness";
            this.tboxInputThickness.Size = new System.Drawing.Size(193, 20);
            this.tboxInputThickness.TabIndex = 3;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel10, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 421);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(701, 44);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel10.Controls.Add(this.btn_OK, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.btn_Cancel, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(504, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(194, 38);
            this.tableLayoutPanel10.TabIndex = 2;
            // 
            // btn_OK
            // 
            this.btn_OK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_OK.Location = new System.Drawing.Point(99, 0);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(0);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(95, 38);
            this.btn_OK.TabIndex = 3;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Cancel.Location = new System.Drawing.Point(0, 0);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(99, 38);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 2;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.77612F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.22388F));
            this.tableLayoutPanel11.Controls.Add(this.tableLayoutPanel12, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 1;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(495, 38);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 2;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Controls.Add(this.btn_Overwrite, 1, 0);
            this.tableLayoutPanel12.Controls.Add(this.btn_SaveTemplate, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 1;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(215, 32);
            this.tableLayoutPanel12.TabIndex = 0;
            // 
            // btn_Overwrite
            // 
            this.btn_Overwrite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Overwrite.Location = new System.Drawing.Point(107, 0);
            this.btn_Overwrite.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Overwrite.Name = "btn_Overwrite";
            this.btn_Overwrite.Size = new System.Drawing.Size(108, 32);
            this.btn_Overwrite.TabIndex = 1;
            this.btn_Overwrite.Text = "Overwrite";
            this.btn_Overwrite.UseVisualStyleBackColor = true;
            // 
            // btn_SaveTemplate
            // 
            this.btn_SaveTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SaveTemplate.Location = new System.Drawing.Point(0, 0);
            this.btn_SaveTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btn_SaveTemplate.Name = "btn_SaveTemplate";
            this.btn_SaveTemplate.Size = new System.Drawing.Size(107, 32);
            this.btn_SaveTemplate.TabIndex = 0;
            this.btn_SaveTemplate.Text = "Save Template";
            this.btn_SaveTemplate.UseVisualStyleBackColor = true;
            // 
            // FormSetCompoundStructureFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 468);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormSetCompoundStructureFinish";
            this.Text = "FormSetSetMaterialLayer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWalls)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInterior)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExterior)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStructure)).EndInit();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvWalls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.DataGridView dgvInterior;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.DataGridView dgvExterior;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.DataGridView dgvStructure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel13;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbMaterial;
        private System.Windows.Forms.ComboBox cbbChooseLayers;
        private System.Windows.Forms.Button btn_DeleteLayerMaterial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnExterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThicknessExterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThicknessInterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStructure;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnThicknessStructure;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel12;
        private System.Windows.Forms.Button btn_Overwrite;
        private System.Windows.Forms.Button btn_SaveTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnWalls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxInputThickness;
        private System.Windows.Forms.Button btn_ChangeMaterial;
    }
}