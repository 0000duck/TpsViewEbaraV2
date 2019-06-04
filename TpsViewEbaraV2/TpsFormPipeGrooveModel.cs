using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ABB.Robotics.Tps.Windows.Forms;
using TpsViewEbaraV2NameSpace.Robot;
using TpsViewEbaraV2NameSpace.Ebara;
using ABB.Robotics.Tps.Taf;
using ABB.Robotics.Tps.Resources;

namespace TpsViewEbaraV2NameSpace
{
    public class TpsFormPipeGrooveModel : TpsForm, ITpsViewActivation
    {
        private TpsResourceManager _tpsRm = null;
        private RWSystem rwSystem = null;
        private PipeGrooveModel pipeGrooveModel = null;

        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Refresh;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Apply;
        private ABB.Robotics.Tps.Windows.Forms.PictureBox pictureBox_Logo;
        private NumEditor numEditor_numHeaderDiameter;
        private NumEditor numEditor_numBranchDiameter;
        private TpsLabel tpsLabel_numDiameter;
        private TpsLabel tpsLabel_numLayerNoStart;
        private TpsLabel tpsLabel_numMultiPassTotal;
        private TpsLabel tpsLabel_Rob1Scan;
        private TpsLabel tpsLabel_Rob2Scan;
        private ABB.Robotics.Tps.Windows.Forms.NumericUpDown numericUpDown_numLayerNoStart;
        private ABB.Robotics.Tps.Windows.Forms.NumericUpDown numericUpDown_numMultiPassTotal;
        private TpsLabel tpsLabel_Header;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numScanBranchRob1;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numScanHeaderRob1;
        private TpsLabel tpsLabel_Branch;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numScanBranchRob2;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numScanHeaderRob2;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolKeepLastWobj;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolMoveLSubstituted;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_Pos1;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_Rob2;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolContinuous;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_Rob1;
        private NumEditor numEditor_numSeamNormalAngle;
        private NumEditor numEditor_numSeamCenterX;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numPipeGrooveType;
        private TpsLabel tpsLabel_numPipeGrooveType;
        private TpsLabel tpsLabel_numSeamNormalAngle;
        private TpsLabel tpsLabel_numSeamCenterX;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolUseAlignedSTNbyFixedValue;
        private ABB.Robotics.Tps.Windows.Forms.TabControl tabControl1;
        private ABB.Robotics.Tps.Windows.Forms.TabPage tabPage_Scan;
        private ABB.Robotics.Tps.Windows.Forms.TabPage tabPage_Detail;
        private ABB.Robotics.Tps.Windows.Forms.TabPage tabPage_Debug;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Close;


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public TpsFormPipeGrooveModel(TpsResourceManager rM, RWSystem rwSystem, PipeGrooveModel pipeGrooveModel)
        { 
            try
            {
                InitializeComponent();
                this._tpsRm = rM;
                this.rwSystem = rwSystem;
                this.pipeGrooveModel = pipeGrooveModel;
                InitializeTexts();

             }
            catch (System.Exception ex)
            {
                // If initialization of application fails a message box is shown
                GTPUMessageBox.Show(this.Parent
                    , null
                    , string.Format("An unexpected error occurred while starting up Sample Application. \n\n{0}", ex.Message)
                    , "Sample Application Start-up Error"
                    , MessageBoxIcon.Hand, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Clean up any resources used by this class.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                try
                {
                    if (disposing)
                    {
                        //ToDo: Call the Dispose method of all FP SDK instances that may otherwise cause memory leak

                        if (components != null)
                        {
                            components.Dispose();
                        }
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TpsFormPipeGrooveModel));
            this.menuItem_Refresh = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Apply = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.pictureBox_Logo = new ABB.Robotics.Tps.Windows.Forms.PictureBox();
            this.numEditor_numHeaderDiameter = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numBranchDiameter = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numDiameter = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_Rob1Scan = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_Rob2Scan = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_Header = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.comboBox_numScanBranchRob1 = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.comboBox_numScanHeaderRob1 = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.tpsLabel_Branch = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.comboBox_numScanBranchRob2 = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.comboBox_numScanHeaderRob2 = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.tpsLabel_numLayerNoStart = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numMultiPassTotal = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numericUpDown_numLayerNoStart = new ABB.Robotics.Tps.Windows.Forms.NumericUpDown();
            this.numericUpDown_numMultiPassTotal = new ABB.Robotics.Tps.Windows.Forms.NumericUpDown();
            this.checkBox_boolKeepLastWobj = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.checkBox_boolMoveLSubstituted = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.checkBox_Pos1 = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.checkBox_Rob2 = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.checkBox_boolContinuous = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.checkBox_Rob1 = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.numEditor_numSeamNormalAngle = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numSeamCenterX = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.comboBox_numPipeGrooveType = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.tpsLabel_numPipeGrooveType = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numSeamNormalAngle = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numSeamCenterX = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.checkBox_boolUseAlignedSTNbyFixedValue = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.tabControl1 = new ABB.Robotics.Tps.Windows.Forms.TabControl();
            this.tabPage_Scan = new ABB.Robotics.Tps.Windows.Forms.TabPage();
            this.tabPage_Detail = new ABB.Robotics.Tps.Windows.Forms.TabPage();
            this.tabPage_Debug = new ABB.Robotics.Tps.Windows.Forms.TabPage();
            this.menuItem_Close = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.tabControl1.SuspendLayout();
            this.tabPage_Scan.SuspendLayout();
            this.tabPage_Detail.SuspendLayout();
            this.tabPage_Debug.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItem_Refresh
            // 
            this.menuItem_Refresh.Checked = false;
            this.menuItem_Refresh.DockToRight = true;
            this.menuItem_Refresh.Enabled = true;
            this.menuItem_Refresh.Image = null;
            this.menuItem_Refresh.ImageSelected = null;
            this.menuItem_Refresh.Index = 0;
            this.menuItem_Refresh.Pressed = false;
            this.menuItem_Refresh.Text = "Refresh";
            this.menuItem_Refresh.Width = 128;
            this.menuItem_Refresh.Click += new System.EventHandler(this.menuItem_Refresh_Click);
            // 
            // menuItem_Apply
            // 
            this.menuItem_Apply.Checked = false;
            this.menuItem_Apply.DockToRight = true;
            this.menuItem_Apply.Enabled = true;
            this.menuItem_Apply.Image = null;
            this.menuItem_Apply.ImageSelected = null;
            this.menuItem_Apply.Index = 1;
            this.menuItem_Apply.Pressed = false;
            this.menuItem_Apply.Text = "Apply";
            this.menuItem_Apply.Width = 128;
            this.menuItem_Apply.Click += new System.EventHandler(this.menuItem_Apply_Click);
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pictureBox_Logo.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.pictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logo.Image")));
            this.pictureBox_Logo.Location = new System.Drawing.Point(530, 1);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.pictureBox_Logo.Size = new System.Drawing.Size(108, 32);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 5;
            // 
            // numEditor_numHeaderDiameter
            // 
            this.numEditor_numHeaderDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numHeaderDiameter.CaretVisible = false;
            this.numEditor_numHeaderDiameter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numHeaderDiameter.Location = new System.Drawing.Point(121, 105);
            this.numEditor_numHeaderDiameter.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numHeaderDiameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numEditor_numHeaderDiameter.Multiline = true;
            this.numEditor_numHeaderDiameter.Name = "numEditor_numHeaderDiameter";
            this.numEditor_numHeaderDiameter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numHeaderDiameter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numHeaderDiameter.SelectionLength = 0;
            this.numEditor_numHeaderDiameter.SelectionStart = 0;
            this.numEditor_numHeaderDiameter.SelectionVisible = false;
            this.numEditor_numHeaderDiameter.Size = new System.Drawing.Size(149, 30);
            this.numEditor_numHeaderDiameter.TabIndex = 6;
            this.numEditor_numHeaderDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numHeaderDiameter.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numEditor_numHeaderDiameter.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numBranchDiameter
            // 
            this.numEditor_numBranchDiameter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numBranchDiameter.CaretVisible = false;
            this.numEditor_numBranchDiameter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numBranchDiameter.Location = new System.Drawing.Point(309, 103);
            this.numEditor_numBranchDiameter.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numBranchDiameter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numEditor_numBranchDiameter.Multiline = true;
            this.numEditor_numBranchDiameter.Name = "numEditor_numBranchDiameter";
            this.numEditor_numBranchDiameter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numBranchDiameter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numBranchDiameter.SelectionLength = 0;
            this.numEditor_numBranchDiameter.SelectionStart = 0;
            this.numEditor_numBranchDiameter.SelectionVisible = false;
            this.numEditor_numBranchDiameter.Size = new System.Drawing.Size(147, 30);
            this.numEditor_numBranchDiameter.TabIndex = 6;
            this.numEditor_numBranchDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numBranchDiameter.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numEditor_numBranchDiameter.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numDiameter
            // 
            this.tpsLabel_numDiameter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDiameter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDiameter.Location = new System.Drawing.Point(21, 104);
            this.tpsLabel_numDiameter.Multiline = true;
            this.tpsLabel_numDiameter.Name = "tpsLabel_numDiameter";
            this.tpsLabel_numDiameter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDiameter.Size = new System.Drawing.Size(80, 24);
            this.tpsLabel_numDiameter.TabIndex = 2;
            this.tpsLabel_numDiameter.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDiameter.Title = "Dia";
            // 
            // tpsLabel_Rob1Scan
            // 
            this.tpsLabel_Rob1Scan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_Rob1Scan.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_Rob1Scan.Location = new System.Drawing.Point(21, 142);
            this.tpsLabel_Rob1Scan.Multiline = true;
            this.tpsLabel_Rob1Scan.Name = "tpsLabel_Rob1Scan";
            this.tpsLabel_Rob1Scan.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_Rob1Scan.Size = new System.Drawing.Size(80, 24);
            this.tpsLabel_Rob1Scan.TabIndex = 2;
            this.tpsLabel_Rob1Scan.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_Rob1Scan.Title = "R1 Scan";
            // 
            // tpsLabel_Rob2Scan
            // 
            this.tpsLabel_Rob2Scan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_Rob2Scan.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_Rob2Scan.Location = new System.Drawing.Point(21, 178);
            this.tpsLabel_Rob2Scan.Multiline = true;
            this.tpsLabel_Rob2Scan.Name = "tpsLabel_Rob2Scan";
            this.tpsLabel_Rob2Scan.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_Rob2Scan.Size = new System.Drawing.Size(80, 24);
            this.tpsLabel_Rob2Scan.TabIndex = 2;
            this.tpsLabel_Rob2Scan.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_Rob2Scan.Title = "R2 Scan";
            // 
            // tpsLabel_Header
            // 
            this.tpsLabel_Header.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_Header.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_Header.Location = new System.Drawing.Point(163, 73);
            this.tpsLabel_Header.Multiline = true;
            this.tpsLabel_Header.Name = "tpsLabel_Header";
            this.tpsLabel_Header.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_Header.Size = new System.Drawing.Size(67, 24);
            this.tpsLabel_Header.TabIndex = 2;
            this.tpsLabel_Header.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_Header.Title = "Header";
            // 
            // comboBox_numScanBranchRob1
            // 
            this.comboBox_numScanBranchRob1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numScanBranchRob1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numScanBranchRob1.Items.Add("Scan");
            this.comboBox_numScanBranchRob1.Items.Add("Pre Offset");
            this.comboBox_numScanBranchRob1.Items.Add("Theory");
            this.comboBox_numScanBranchRob1.Items.Add("Not Used");
            this.comboBox_numScanBranchRob1.Location = new System.Drawing.Point(309, 141);
            this.comboBox_numScanBranchRob1.Name = "comboBox_numScanBranchRob1";
            this.comboBox_numScanBranchRob1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numScanBranchRob1.Size = new System.Drawing.Size(147, 30);
            this.comboBox_numScanBranchRob1.TabIndex = 5;
            this.comboBox_numScanBranchRob1.Text = "comboBox1";
            this.comboBox_numScanBranchRob1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // comboBox_numScanHeaderRob1
            // 
            this.comboBox_numScanHeaderRob1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numScanHeaderRob1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numScanHeaderRob1.Items.Add("Scan");
            this.comboBox_numScanHeaderRob1.Items.Add("Pre Offset");
            this.comboBox_numScanHeaderRob1.Items.Add("Theory");
            this.comboBox_numScanHeaderRob1.Items.Add("Not Used");
            this.comboBox_numScanHeaderRob1.Location = new System.Drawing.Point(121, 143);
            this.comboBox_numScanHeaderRob1.Name = "comboBox_numScanHeaderRob1";
            this.comboBox_numScanHeaderRob1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numScanHeaderRob1.Size = new System.Drawing.Size(149, 30);
            this.comboBox_numScanHeaderRob1.TabIndex = 5;
            this.comboBox_numScanHeaderRob1.Text = "comboBox1";
            this.comboBox_numScanHeaderRob1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_Branch
            // 
            this.tpsLabel_Branch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_Branch.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_Branch.Location = new System.Drawing.Point(339, 73);
            this.tpsLabel_Branch.Multiline = true;
            this.tpsLabel_Branch.Name = "tpsLabel_Branch";
            this.tpsLabel_Branch.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_Branch.Size = new System.Drawing.Size(68, 24);
            this.tpsLabel_Branch.TabIndex = 2;
            this.tpsLabel_Branch.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_Branch.Title = "Branch";
            // 
            // comboBox_numScanBranchRob2
            // 
            this.comboBox_numScanBranchRob2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numScanBranchRob2.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numScanBranchRob2.Items.Add("Scan");
            this.comboBox_numScanBranchRob2.Items.Add("Pre Offset");
            this.comboBox_numScanBranchRob2.Items.Add("Theory");
            this.comboBox_numScanBranchRob2.Items.Add("Not Used");
            this.comboBox_numScanBranchRob2.Location = new System.Drawing.Point(309, 177);
            this.comboBox_numScanBranchRob2.Name = "comboBox_numScanBranchRob2";
            this.comboBox_numScanBranchRob2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numScanBranchRob2.Size = new System.Drawing.Size(147, 30);
            this.comboBox_numScanBranchRob2.TabIndex = 5;
            this.comboBox_numScanBranchRob2.Text = "comboBox1";
            this.comboBox_numScanBranchRob2.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // comboBox_numScanHeaderRob2
            // 
            this.comboBox_numScanHeaderRob2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numScanHeaderRob2.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numScanHeaderRob2.Items.Add("Scan");
            this.comboBox_numScanHeaderRob2.Items.Add("Pre Offset");
            this.comboBox_numScanHeaderRob2.Items.Add("Theory");
            this.comboBox_numScanHeaderRob2.Items.Add("Not Used");
            this.comboBox_numScanHeaderRob2.Location = new System.Drawing.Point(121, 177);
            this.comboBox_numScanHeaderRob2.Name = "comboBox_numScanHeaderRob2";
            this.comboBox_numScanHeaderRob2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numScanHeaderRob2.Size = new System.Drawing.Size(149, 30);
            this.comboBox_numScanHeaderRob2.TabIndex = 5;
            this.comboBox_numScanHeaderRob2.Text = "comboBox1";
            this.comboBox_numScanHeaderRob2.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numLayerNoStart
            // 
            this.tpsLabel_numLayerNoStart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numLayerNoStart.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numLayerNoStart.Location = new System.Drawing.Point(28, 29);
            this.tpsLabel_numLayerNoStart.Multiline = true;
            this.tpsLabel_numLayerNoStart.Name = "tpsLabel_numLayerNoStart";
            this.tpsLabel_numLayerNoStart.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numLayerNoStart.Size = new System.Drawing.Size(60, 24);
            this.tpsLabel_numLayerNoStart.TabIndex = 2;
            this.tpsLabel_numLayerNoStart.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numLayerNoStart.Title = "Pass";
            // 
            // tpsLabel_numMultiPassTotal
            // 
            this.tpsLabel_numMultiPassTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numMultiPassTotal.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numMultiPassTotal.Location = new System.Drawing.Point(202, 29);
            this.tpsLabel_numMultiPassTotal.Multiline = true;
            this.tpsLabel_numMultiPassTotal.Name = "tpsLabel_numMultiPassTotal";
            this.tpsLabel_numMultiPassTotal.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numMultiPassTotal.Size = new System.Drawing.Size(29, 24);
            this.tpsLabel_numMultiPassTotal.TabIndex = 2;
            this.tpsLabel_numMultiPassTotal.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numMultiPassTotal.Title = "->";
            // 
            // numericUpDown_numLayerNoStart
            // 
            this.numericUpDown_numLayerNoStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_numLayerNoStart.CaretVisible = false;
            this.numericUpDown_numLayerNoStart.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numericUpDown_numLayerNoStart.Location = new System.Drawing.Point(94, 29);
            this.numericUpDown_numLayerNoStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numLayerNoStart.Multiline = true;
            this.numericUpDown_numLayerNoStart.Name = "numericUpDown_numLayerNoStart";
            this.numericUpDown_numLayerNoStart.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericUpDown_numLayerNoStart.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numericUpDown_numLayerNoStart.SelectionLength = 0;
            this.numericUpDown_numLayerNoStart.SelectionStart = 0;
            this.numericUpDown_numLayerNoStart.SelectionVisible = false;
            this.numericUpDown_numLayerNoStart.Size = new System.Drawing.Size(98, 40);
            this.numericUpDown_numLayerNoStart.TabIndex = 12;
            this.numericUpDown_numLayerNoStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericUpDown_numLayerNoStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numLayerNoStart.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numericUpDown_numMultiPassTotal
            // 
            this.numericUpDown_numMultiPassTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_numMultiPassTotal.CaretVisible = false;
            this.numericUpDown_numMultiPassTotal.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numericUpDown_numMultiPassTotal.Location = new System.Drawing.Point(239, 29);
            this.numericUpDown_numMultiPassTotal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numMultiPassTotal.Multiline = true;
            this.numericUpDown_numMultiPassTotal.Name = "numericUpDown_numMultiPassTotal";
            this.numericUpDown_numMultiPassTotal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericUpDown_numMultiPassTotal.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numericUpDown_numMultiPassTotal.SelectionLength = 0;
            this.numericUpDown_numMultiPassTotal.SelectionStart = 0;
            this.numericUpDown_numMultiPassTotal.SelectionVisible = false;
            this.numericUpDown_numMultiPassTotal.Size = new System.Drawing.Size(98, 40);
            this.numericUpDown_numMultiPassTotal.TabIndex = 12;
            this.numericUpDown_numMultiPassTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericUpDown_numMultiPassTotal.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_numMultiPassTotal.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_boolKeepLastWobj
            // 
            this.checkBox_boolKeepLastWobj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolKeepLastWobj.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolKeepLastWobj.Location = new System.Drawing.Point(28, 105);
            this.checkBox_boolKeepLastWobj.Name = "checkBox_boolKeepLastWobj";
            this.checkBox_boolKeepLastWobj.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolKeepLastWobj.Size = new System.Drawing.Size(242, 24);
            this.checkBox_boolKeepLastWobj.TabIndex = 41;
            this.checkBox_boolKeepLastWobj.Text = "Keep Last Wobj";
            this.checkBox_boolKeepLastWobj.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_boolMoveLSubstituted
            // 
            this.checkBox_boolMoveLSubstituted.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolMoveLSubstituted.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolMoveLSubstituted.Location = new System.Drawing.Point(28, 172);
            this.checkBox_boolMoveLSubstituted.Name = "checkBox_boolMoveLSubstituted";
            this.checkBox_boolMoveLSubstituted.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolMoveLSubstituted.Size = new System.Drawing.Size(242, 24);
            this.checkBox_boolMoveLSubstituted.TabIndex = 40;
            this.checkBox_boolMoveLSubstituted.Text = "MoveL Substituted";
            this.checkBox_boolMoveLSubstituted.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_Pos1
            // 
            this.checkBox_Pos1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_Pos1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_Pos1.Location = new System.Drawing.Point(54, 90);
            this.checkBox_Pos1.Name = "checkBox_Pos1";
            this.checkBox_Pos1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_Pos1.Size = new System.Drawing.Size(80, 24);
            this.checkBox_Pos1.TabIndex = 35;
            this.checkBox_Pos1.Text = "Pos1";
            this.checkBox_Pos1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_Rob2
            // 
            this.checkBox_Rob2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_Rob2.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_Rob2.Location = new System.Drawing.Point(54, 59);
            this.checkBox_Rob2.Name = "checkBox_Rob2";
            this.checkBox_Rob2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_Rob2.Size = new System.Drawing.Size(80, 24);
            this.checkBox_Rob2.TabIndex = 34;
            this.checkBox_Rob2.Text = "Rob2";
            this.checkBox_Rob2.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_boolContinuous
            // 
            this.checkBox_boolContinuous.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolContinuous.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolContinuous.Location = new System.Drawing.Point(54, 120);
            this.checkBox_boolContinuous.Name = "checkBox_boolContinuous";
            this.checkBox_boolContinuous.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolContinuous.Size = new System.Drawing.Size(216, 24);
            this.checkBox_boolContinuous.TabIndex = 37;
            this.checkBox_boolContinuous.Text = "Continuous";
            this.checkBox_boolContinuous.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_Rob1
            // 
            this.checkBox_Rob1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_Rob1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_Rob1.Location = new System.Drawing.Point(54, 29);
            this.checkBox_Rob1.Name = "checkBox_Rob1";
            this.checkBox_Rob1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_Rob1.Size = new System.Drawing.Size(80, 24);
            this.checkBox_Rob1.TabIndex = 36;
            this.checkBox_Rob1.Text = "Rob1";
            this.checkBox_Rob1.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numSeamNormalAngle
            // 
            this.numEditor_numSeamNormalAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numSeamNormalAngle.CaretVisible = false;
            this.numEditor_numSeamNormalAngle.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numSeamNormalAngle.Location = new System.Drawing.Point(469, 19);
            this.numEditor_numSeamNormalAngle.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numSeamNormalAngle.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numSeamNormalAngle.Multiline = true;
            this.numEditor_numSeamNormalAngle.Name = "numEditor_numSeamNormalAngle";
            this.numEditor_numSeamNormalAngle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numSeamNormalAngle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numSeamNormalAngle.SelectionLength = 0;
            this.numEditor_numSeamNormalAngle.SelectionStart = 0;
            this.numEditor_numSeamNormalAngle.SelectionVisible = false;
            this.numEditor_numSeamNormalAngle.Size = new System.Drawing.Size(120, 30);
            this.numEditor_numSeamNormalAngle.TabIndex = 26;
            this.numEditor_numSeamNormalAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numSeamNormalAngle.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numSeamCenterX
            // 
            this.numEditor_numSeamCenterX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numSeamCenterX.CaretVisible = false;
            this.numEditor_numSeamCenterX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numSeamCenterX.Location = new System.Drawing.Point(121, 19);
            this.numEditor_numSeamCenterX.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numSeamCenterX.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numSeamCenterX.Multiline = true;
            this.numEditor_numSeamCenterX.Name = "numEditor_numSeamCenterX";
            this.numEditor_numSeamCenterX.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numSeamCenterX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numSeamCenterX.SelectionLength = 0;
            this.numEditor_numSeamCenterX.SelectionStart = 0;
            this.numEditor_numSeamCenterX.SelectionVisible = false;
            this.numEditor_numSeamCenterX.Size = new System.Drawing.Size(149, 30);
            this.numEditor_numSeamCenterX.TabIndex = 27;
            this.numEditor_numSeamCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numSeamCenterX.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // comboBox_numPipeGrooveType
            // 
            this.comboBox_numPipeGrooveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numPipeGrooveType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numPipeGrooveType.Items.Add("Platoon Container");
            this.comboBox_numPipeGrooveType.Items.Add("Platoon Header");
            this.comboBox_numPipeGrooveType.Items.Add("Saddle");
            this.comboBox_numPipeGrooveType.Location = new System.Drawing.Point(119, 31);
            this.comboBox_numPipeGrooveType.Name = "comboBox_numPipeGrooveType";
            this.comboBox_numPipeGrooveType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numPipeGrooveType.Size = new System.Drawing.Size(218, 33);
            this.comboBox_numPipeGrooveType.TabIndex = 25;
            this.comboBox_numPipeGrooveType.Text = "comboBox1";
            this.comboBox_numPipeGrooveType.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numPipeGrooveType
            // 
            this.tpsLabel_numPipeGrooveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numPipeGrooveType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numPipeGrooveType.Location = new System.Drawing.Point(21, 31);
            this.tpsLabel_numPipeGrooveType.Multiline = true;
            this.tpsLabel_numPipeGrooveType.Name = "tpsLabel_numPipeGrooveType";
            this.tpsLabel_numPipeGrooveType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numPipeGrooveType.Size = new System.Drawing.Size(85, 24);
            this.tpsLabel_numPipeGrooveType.TabIndex = 18;
            this.tpsLabel_numPipeGrooveType.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numPipeGrooveType.Title = "Type";
            // 
            // tpsLabel_numSeamNormalAngle
            // 
            this.tpsLabel_numSeamNormalAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numSeamNormalAngle.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numSeamNormalAngle.Location = new System.Drawing.Point(309, 19);
            this.tpsLabel_numSeamNormalAngle.Multiline = true;
            this.tpsLabel_numSeamNormalAngle.Name = "tpsLabel_numSeamNormalAngle";
            this.tpsLabel_numSeamNormalAngle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numSeamNormalAngle.Size = new System.Drawing.Size(129, 24);
            this.tpsLabel_numSeamNormalAngle.TabIndex = 19;
            this.tpsLabel_numSeamNormalAngle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numSeamNormalAngle.Title = "Normal Angle";
            // 
            // tpsLabel_numSeamCenterX
            // 
            this.tpsLabel_numSeamCenterX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numSeamCenterX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numSeamCenterX.Location = new System.Drawing.Point(21, 19);
            this.tpsLabel_numSeamCenterX.Multiline = true;
            this.tpsLabel_numSeamCenterX.Name = "tpsLabel_numSeamCenterX";
            this.tpsLabel_numSeamCenterX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numSeamCenterX.Size = new System.Drawing.Size(94, 24);
            this.tpsLabel_numSeamCenterX.TabIndex = 17;
            this.tpsLabel_numSeamCenterX.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numSeamCenterX.Title = "Center X";
            // 
            // checkBox_boolUseAlignedSTNbyFixedValue
            // 
            this.checkBox_boolUseAlignedSTNbyFixedValue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolUseAlignedSTNbyFixedValue.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolUseAlignedSTNbyFixedValue.Location = new System.Drawing.Point(54, 151);
            this.checkBox_boolUseAlignedSTNbyFixedValue.Name = "checkBox_boolUseAlignedSTNbyFixedValue";
            this.checkBox_boolUseAlignedSTNbyFixedValue.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolUseAlignedSTNbyFixedValue.Size = new System.Drawing.Size(235, 24);
            this.checkBox_boolUseAlignedSTNbyFixedValue.TabIndex = 34;
            this.checkBox_boolUseAlignedSTNbyFixedValue.Text = "Dynamic STN1";
            this.checkBox_boolUseAlignedSTNbyFixedValue.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControl1.Controls.Add(this.tabPage_Debug);
            this.tabControl1.Controls.Add(this.tabPage_Detail);
            this.tabControl1.Controls.Add(this.tabPage_Scan);
            this.tabControl1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tabControl1.ImageList = null;
            this.tabControl1.Location = new System.Drawing.Point(0, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabControl1.Size = new System.Drawing.Size(640, 271);
            this.tabControl1.TabIndex = 43;
            this.tabControl1.TabPages.Add(this.tabPage_Scan);
            this.tabControl1.TabPages.Add(this.tabPage_Detail);
            this.tabControl1.TabPages.Add(this.tabPage_Debug);
            // 
            // tabPage_Scan
            // 
            this.tabPage_Scan.Controls.Add(this.numEditor_numHeaderDiameter);
            this.tabPage_Scan.Controls.Add(this.numEditor_numSeamNormalAngle);
            this.tabPage_Scan.Controls.Add(this.numEditor_numBranchDiameter);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_numSeamCenterX);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_numDiameter);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_Rob1Scan);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_numSeamNormalAngle);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_Rob2Scan);
            this.tabPage_Scan.Controls.Add(this.numEditor_numSeamCenterX);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_Header);
            this.tabPage_Scan.Controls.Add(this.tpsLabel_Branch);
            this.tabPage_Scan.Controls.Add(this.comboBox_numScanBranchRob1);
            this.tabPage_Scan.Controls.Add(this.comboBox_numScanHeaderRob2);
            this.tabPage_Scan.Controls.Add(this.comboBox_numScanHeaderRob1);
            this.tabPage_Scan.Controls.Add(this.comboBox_numScanBranchRob2);
            this.tabPage_Scan.ImageIndex = -1;
            this.tabPage_Scan.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Scan.Name = "tabPage_Scan";
            this.tabPage_Scan.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabPage_Scan.Size = new System.Drawing.Size(640, 231);
            this.tabPage_Scan.TabIndex = 1;
            this.tabPage_Scan.Text = "Scan";
            // 
            // tabPage_Detail
            // 
            this.tabPage_Detail.Controls.Add(this.checkBox_Rob1);
            this.tabPage_Detail.Controls.Add(this.checkBox_boolContinuous);
            this.tabPage_Detail.Controls.Add(this.checkBox_Rob2);
            this.tabPage_Detail.Controls.Add(this.checkBox_boolUseAlignedSTNbyFixedValue);
            this.tabPage_Detail.Controls.Add(this.checkBox_Pos1);
            this.tabPage_Detail.ImageIndex = -1;
            this.tabPage_Detail.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Detail.Name = "tabPage_Detail";
            this.tabPage_Detail.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabPage_Detail.Size = new System.Drawing.Size(640, 231);
            this.tabPage_Detail.TabIndex = 2;
            this.tabPage_Detail.Text = "Detail";
            // 
            // tabPage_Debug
            // 
            this.tabPage_Debug.Controls.Add(this.numericUpDown_numLayerNoStart);
            this.tabPage_Debug.Controls.Add(this.numericUpDown_numMultiPassTotal);
            this.tabPage_Debug.Controls.Add(this.checkBox_boolKeepLastWobj);
            this.tabPage_Debug.Controls.Add(this.tpsLabel_numLayerNoStart);
            this.tabPage_Debug.Controls.Add(this.tpsLabel_numMultiPassTotal);
            this.tabPage_Debug.Controls.Add(this.checkBox_boolMoveLSubstituted);
            this.tabPage_Debug.ImageIndex = -1;
            this.tabPage_Debug.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Debug.Name = "tabPage_Debug";
            this.tabPage_Debug.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabPage_Debug.Size = new System.Drawing.Size(640, 231);
            this.tabPage_Debug.TabIndex = 3;
            this.tabPage_Debug.Text = "Debug";
            // 
            // menuItem_Close
            // 
            this.menuItem_Close.Checked = false;
            this.menuItem_Close.DockToRight = true;
            this.menuItem_Close.Enabled = true;
            this.menuItem_Close.Image = null;
            this.menuItem_Close.ImageSelected = null;
            this.menuItem_Close.Index = 2;
            this.menuItem_Close.Pressed = false;
            this.menuItem_Close.Text = "Close";
            this.menuItem_Close.Width = 128;
            this.menuItem_Close.Click += new System.EventHandler(this.menuItem_Close_Click);
            // 
            // TpsFormPipeGrooveModel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.comboBox_numPipeGrooveType);
            this.Controls.Add(this.tpsLabel_numPipeGrooveType);
            // 
            // 
            // 
            this.MainMenu.MenuItems.Add(this.menuItem_Refresh);
            this.MainMenu.MenuItems.Add(this.menuItem_Apply);
            this.MainMenu.MenuItems.Add(this.menuItem_Close);
            this.Size = new System.Drawing.Size(640, 390);
            this.Text = "Pipe Groove Model";
            this.Controls.SetChildIndex(this.tpsLabel_numPipeGrooveType, 0);
            this.Controls.SetChildIndex(this.comboBox_numPipeGrooveType, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.pictureBox_Logo, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Scan.ResumeLayout(false);
            this.tabPage_Detail.ResumeLayout(false);
            this.tabPage_Debug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        #region ITpsViewActivation Members

        public void Activate()
        {
            this.Invoke(this.UpdateGUI);
            //throw new NotImplementedException();
        }

        public void Deactivate()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void UpdateGUI(object sender, EventArgs e)
        {
            try
            {
                this.pipeGrooveModel.RefreshData(this.rwSystem);
                this.comboBox_numPipeGrooveType.SelectedIndex = this.pipeGrooveModel.numPipeGrooveType - 1;
                this.numEditor_numSeamCenterX.Value = this.pipeGrooveModel.numSeamCenterX;
                this.numEditor_numSeamNormalAngle.Value = this.pipeGrooveModel.numSeamNormalAngle;

                this.numEditor_numHeaderDiameter.Value = this.pipeGrooveModel.numHeaderDiameter;
                this.numEditor_numBranchDiameter.Value = this.pipeGrooveModel.numBranchDiameter;

                this.numericUpDown_numMultiPassTotal.Value = Convert.ToDecimal(this.pipeGrooveModel.numMultiPassTotal);

                this.checkBox_Rob1.Checked = (this.pipeGrooveModel.numCooperativeRobots & 1) == 1;
                this.checkBox_Rob2.Checked = (this.pipeGrooveModel.numCooperativeRobots & 2) == 2;
                this.checkBox_Pos1.Checked = (this.pipeGrooveModel.numCooperativeRobots & 4) == 4;

                if ((this.pipeGrooveModel.numReviseScanBranchType & 1) == 1)
                {
                    this.comboBox_numScanBranchRob1.SelectedIndex = 0;
                }
                else if ((this.pipeGrooveModel.numReviseScanBranchType & 4) == 4)
                {
                    this.comboBox_numScanBranchRob1.SelectedIndex = 1;
                }
                else if ((this.pipeGrooveModel.numReviseScanBranchType & 16) == 16)
                {
                    this.comboBox_numScanBranchRob1.SelectedIndex = 2;
                }
                else
                {
                    this.comboBox_numScanBranchRob1.SelectedIndex = 3;
                }

                if ((this.pipeGrooveModel.numReviseScanBranchType & 2) == 2)
                {
                    this.comboBox_numScanBranchRob2.SelectedIndex = 0;
                }
                else if ((this.pipeGrooveModel.numReviseScanBranchType & 8) == 8)
                {
                    this.comboBox_numScanBranchRob2.SelectedIndex = 1;
                }
                else if ((this.pipeGrooveModel.numReviseScanBranchType & 32) == 32)
                {
                    this.comboBox_numScanBranchRob2.SelectedIndex = 2;
                }
                else
                {
                    this.comboBox_numScanBranchRob2.SelectedIndex = 3;
                }

                if ((this.pipeGrooveModel.numReviseScanHeaderType & 1) == 1)
                {
                    this.comboBox_numScanHeaderRob1.SelectedIndex = 0;
                }
                else if ((this.pipeGrooveModel.numReviseScanHeaderType & 4) == 4)
                {
                    this.comboBox_numScanHeaderRob1.SelectedIndex = 1;
                }
                else if ((this.pipeGrooveModel.numReviseScanHeaderType & 16) == 16)
                {
                    this.comboBox_numScanHeaderRob1.SelectedIndex = 2;
                }
                else
                {
                    this.comboBox_numScanHeaderRob1.SelectedIndex = 3;
                }

                if ((this.pipeGrooveModel.numReviseScanHeaderType & 2) == 2)
                {
                    this.comboBox_numScanHeaderRob2.SelectedIndex = 0;
                }
                else if ((this.pipeGrooveModel.numReviseScanHeaderType & 8) == 8)
                {
                    this.comboBox_numScanHeaderRob2.SelectedIndex = 1;
                }
                else if ((this.pipeGrooveModel.numReviseScanHeaderType & 32) == 32)
                {
                    this.comboBox_numScanHeaderRob2.SelectedIndex = 2;
                }
                else
                {
                    this.comboBox_numScanHeaderRob2.SelectedIndex = 3;
                }

                this.checkBox_boolContinuous.Checked = this.pipeGrooveModel.boolContinuous;
                this.checkBox_boolUseAlignedSTNbyFixedValue.Checked = this.pipeGrooveModel.boolUseAlignedSTNbyFixedValue;

                ABB.Robotics.Controllers.RapidDomain.RapidData boolMoveLSubstituted = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "boolMoveLSubstituted");
                ABB.Robotics.Controllers.RapidDomain.Bool bMoveLSubstituted = new ABB.Robotics.Controllers.RapidDomain.Bool();
                bMoveLSubstituted.FillFromString(boolMoveLSubstituted.Value.ToString());
                this.checkBox_boolMoveLSubstituted.Checked = bMoveLSubstituted;
                boolMoveLSubstituted.Dispose();

                ABB.Robotics.Controllers.RapidDomain.RapidData boolKeepLastWobj = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "boolKeepLastWobj");
                ABB.Robotics.Controllers.RapidDomain.Bool bKeepLastWobj = new ABB.Robotics.Controllers.RapidDomain.Bool();
                bKeepLastWobj.FillFromString(boolKeepLastWobj.Value.ToString());
                this.checkBox_boolKeepLastWobj.Checked = bKeepLastWobj;
                boolKeepLastWobj.Dispose();

                ABB.Robotics.Controllers.RapidDomain.RapidData numLayerNoStart = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "numLayerNoStart");
                ABB.Robotics.Controllers.RapidDomain.Num nLayerNoStart = new ABB.Robotics.Controllers.RapidDomain.Num();
                nLayerNoStart.FillFromString(numLayerNoStart.Value.ToString());
                this.numericUpDown_numLayerNoStart.Value = Convert.ToDecimal(nLayerNoStart);
                numLayerNoStart.Dispose();

                // ABB.Robotics.Controllers.RapidDomain.Bool bMoveLSubstituted = boolMoveLSubstituted.Value;
                this.menuItem_Apply.Enabled = false;
            }
            catch (Exception ex)
            {
                GTPUMessageBox.Show(this.Parent.Parent, null
                    , string.Format("An unexpected error occurred when reading RAPID data 'rPipeGrooveModel'. Message {0}", ex.ToString())
                    , "System Error"
                    , System.Windows.Forms.MessageBoxIcon.Hand
                    , System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void menuItem_Close_Click(object sender, EventArgs e)
        {
            this.CloseMe();
        }

        private void menuItem_Apply_Click(object sender, EventArgs e)
        {
            try
            {
                this.pipeGrooveModel.numPipeGrooveType = this.comboBox_numPipeGrooveType.SelectedIndex + 1;

                this.pipeGrooveModel.numSeamCenterX = this.numEditor_numSeamCenterX.Value;
                this.pipeGrooveModel.numSeamNormalAngle = this.numEditor_numSeamNormalAngle.Value;

                this.pipeGrooveModel.numHeaderDiameter = this.numEditor_numHeaderDiameter.Value;

                this.pipeGrooveModel.numBranchDiameter = this.numEditor_numBranchDiameter.Value;

                this.pipeGrooveModel.numMultiPassTotal = Convert.ToInt32(this.numericUpDown_numMultiPassTotal.Value);

                this.pipeGrooveModel.numCooperativeRobots = 0;
                if (this.checkBox_Rob1.Checked)
                {
                    this.pipeGrooveModel.numCooperativeRobots = this.pipeGrooveModel.numCooperativeRobots | 1;
                }
                if (this.checkBox_Rob2.Checked)
                {
                    this.pipeGrooveModel.numCooperativeRobots = this.pipeGrooveModel.numCooperativeRobots | 2;
                }
                if (this.checkBox_Pos1.Checked)
                {
                    this.pipeGrooveModel.numCooperativeRobots = this.pipeGrooveModel.numCooperativeRobots | 4;
                }

                this.pipeGrooveModel.numReviseScanBranchType = 0;
                if (this.comboBox_numScanBranchRob1.SelectedIndex == 0)
                {
                    this.pipeGrooveModel.numReviseScanBranchType = this.pipeGrooveModel.numReviseScanBranchType | 1;
                }
                else if (this.comboBox_numScanBranchRob1.SelectedIndex == 1)
                {
                    this.pipeGrooveModel.numReviseScanBranchType = this.pipeGrooveModel.numReviseScanBranchType | 4;
                }
                else if (this.comboBox_numScanBranchRob1.SelectedIndex == 2)
                {
                    this.pipeGrooveModel.numReviseScanBranchType = this.pipeGrooveModel.numReviseScanBranchType | 16;
                }
                if (this.comboBox_numScanBranchRob2.SelectedIndex == 0)
                {
                    this.pipeGrooveModel.numReviseScanBranchType = this.pipeGrooveModel.numReviseScanBranchType | 2;
                }
                else if (this.comboBox_numScanBranchRob2.SelectedIndex == 1)
                {
                    this.pipeGrooveModel.numReviseScanBranchType = this.pipeGrooveModel.numReviseScanBranchType | 8;
                }
                else if (this.comboBox_numScanBranchRob2.SelectedIndex == 2)
                {
                    this.pipeGrooveModel.numReviseScanBranchType = this.pipeGrooveModel.numReviseScanBranchType | 32;
                }

                this.pipeGrooveModel.numReviseScanHeaderType = 0;
                if (this.comboBox_numScanHeaderRob1.SelectedIndex == 0)
                {
                    this.pipeGrooveModel.numReviseScanHeaderType = this.pipeGrooveModel.numReviseScanHeaderType | 1;
                }
                else if (this.comboBox_numScanHeaderRob1.SelectedIndex == 1)
                {
                    this.pipeGrooveModel.numReviseScanHeaderType = this.pipeGrooveModel.numReviseScanHeaderType | 4;
                }
                else if (this.comboBox_numScanHeaderRob1.SelectedIndex == 2)
                {
                    this.pipeGrooveModel.numReviseScanHeaderType = this.pipeGrooveModel.numReviseScanHeaderType | 16;
                }
                if (this.comboBox_numScanHeaderRob2.SelectedIndex == 0)
                {
                    this.pipeGrooveModel.numReviseScanHeaderType = this.pipeGrooveModel.numReviseScanHeaderType | 2;
                }
                else if (this.comboBox_numScanHeaderRob2.SelectedIndex == 1)
                {
                    this.pipeGrooveModel.numReviseScanHeaderType = this.pipeGrooveModel.numReviseScanHeaderType | 8;
                }
                else if (this.comboBox_numScanHeaderRob2.SelectedIndex == 2)
                {
                    this.pipeGrooveModel.numReviseScanHeaderType = this.pipeGrooveModel.numReviseScanHeaderType | 32;
                }

                this.pipeGrooveModel.boolContinuous = this.checkBox_boolContinuous.Checked;
                this.pipeGrooveModel.boolUseAlignedSTNbyFixedValue = this.checkBox_boolUseAlignedSTNbyFixedValue.Checked;


                this.pipeGrooveModel.ApplyData(this.rwSystem);

                ABB.Robotics.Controllers.RapidDomain.RapidData boolMoveLSubstituted = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "boolMoveLSubstituted");
                ABB.Robotics.Controllers.RapidDomain.Bool bMoveLSubstituted = new ABB.Robotics.Controllers.RapidDomain.Bool(this.checkBox_boolMoveLSubstituted.Checked);
                boolMoveLSubstituted.Value = bMoveLSubstituted;
                boolMoveLSubstituted.Dispose();

                ABB.Robotics.Controllers.RapidDomain.RapidData boolKeepLastWobj = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "boolKeepLastWobj");
                ABB.Robotics.Controllers.RapidDomain.Bool bKeepLastWobj = new ABB.Robotics.Controllers.RapidDomain.Bool(this.checkBox_boolKeepLastWobj.Checked);
                boolKeepLastWobj.Value = bKeepLastWobj;
                boolKeepLastWobj.Dispose();

                ABB.Robotics.Controllers.RapidDomain.RapidData numLayerNoStart = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "numLayerNoStart");
                ABB.Robotics.Controllers.RapidDomain.Num nLayerNoStart = new ABB.Robotics.Controllers.RapidDomain.Num(Convert.ToDouble(this.numericUpDown_numLayerNoStart.Value));
                numLayerNoStart.Value = nLayerNoStart;
                numLayerNoStart.Dispose();

                this.menuItem_Apply.Enabled = false;
            }
            catch (Exception ex)
            {
                GTPUMessageBox.Show(this.Parent.Parent, null
                    , string.Format("An unexpected error occurred when applying RAPID data 'rPipeGrooveModel'. Message {0}", ex.ToString())
                    , "System Error"
                    , System.Windows.Forms.MessageBoxIcon.Hand
                    , System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void menuItem_Refresh_Click(object sender, EventArgs e)
        {
            this.Invoke(this.UpdateGUI);
        }

        private void dataControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.menuItem_Apply.Enabled = true;
        }

        void InitializeTexts()
        {
            this.Text = _tpsRm.GetString("TXT_PipeGrooveModelTitle");
            this.tpsLabel_numPipeGrooveType.Text = _tpsRm.GetString("TXT_PipeGrooveType");
            this.tabPage_Detail.Text = _tpsRm.GetString("TXT_tabPage_Detail");
            this.tabPage_Scan.Text = _tpsRm.GetString("TXT_tabPage_Scan");
            this.tabPage_Debug.Text = _tpsRm.GetString("TXT_tabPage_Debug");
            this.tpsLabel_numSeamCenterX.Text = _tpsRm.GetString("TXT_tpsLabel_numSeamCenterX");
            this.tpsLabel_numSeamNormalAngle.Text = _tpsRm.GetString("TXT_tpsLabel_numSeamNormalAngle");
            this.tpsLabel_Header.Text = _tpsRm.GetString("TXT_tpsLabel_Header");
            this.tpsLabel_Branch.Text = _tpsRm.GetString("TXT_tpsLabel_Branch");
            this.tpsLabel_numDiameter.Text = _tpsRm.GetString("TXT_tpsLabel_numDiameter");
            this.tpsLabel_Rob1Scan.Text = _tpsRm.GetString("TXT_tpsLabel_Rob1Scan");
            this.tpsLabel_Rob2Scan.Text = _tpsRm.GetString("TXT_tpsLabel_Rob2Scan");
            this.checkBox_boolContinuous.Text = _tpsRm.GetString("TXT_checkBox_boolContinuous");
            this.checkBox_boolUseAlignedSTNbyFixedValue.Text = _tpsRm.GetString("TXT_checkBox_boolUseAlignedSTNbyFixedValue");
            this.tpsLabel_numLayerNoStart.Text = _tpsRm.GetString("TXT_tpsLabel_numLayerNoStart");
            this.checkBox_boolKeepLastWobj.Text = _tpsRm.GetString("TXT_checkBox_boolKeepLastWobj");
            this.checkBox_boolMoveLSubstituted.Text = _tpsRm.GetString("TXT_checkBox_boolMoveLSubstituted");
        }


    }
}