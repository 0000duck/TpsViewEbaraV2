using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ABB.Robotics.Tps.Windows.Forms;
using ABB.Robotics.Tps.Taf;
using ABB.Robotics.Tps.Resources;
using ABB.Robotics.ProductionScreen.Base;
using ABB.Robotics.Controllers.RapidDomain;
using TpsViewEbaraV2NameSpace.Robot;
using TpsViewEbaraV2NameSpace.Ebara;

namespace TpsViewEbaraV2NameSpace
{
    public class TpsFormWobjCurrent : TpsForm, ITpsViewActivation
    {
        private TpsResourceManager _tpsRm = null;
        private RWSystem rwSystem = null;
        private WobjData wobjCurrent = new WobjData();
        private PipeGrooveModel pipeGrooveModel = null;

        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Refresh;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Apply;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Close;
        private TpsLabel tpsLabel_oframeX;
        private NumEditor numEditor_oframeX;
        private NumEditor numEditor_oframeY;
        private TpsLabel tpsLabel_oframeY;
        private NumEditor numEditor_oframeZ;
        private TpsLabel tpsLabel_oframeZ;
        private NumEditor numEditor_WorldYOffset;
        private TpsLabel tpsLabel_WorldYOffset;
        private NumEditor numEditor_WorldZOffset;
        private TpsLabel tpsLabel_WorldZOffset;
        private NumEditor numEditor_numSeamNormalAngle;
        private TpsLabel tpsLabel_numSeamNormalAngle;
        private ABB.Robotics.Tps.Windows.Forms.Button button_UpdatebyWorldOffset;
        private ABB.Robotics.Tps.Windows.Forms.PictureBox pictureBox_Logo;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numPipeGrooveType;
        private TpsLabel tpsLabel_numPipeGrooveType;
        private NumEditor numEditor_WorldXOffset;
        private TpsLabel tpsLabel_WorldXOffset;
        private TpsLabel tpsLabel_numSeamCenterX;
        private NumEditor numEditor_numSeamCenterX;
        private ABB.Robotics.Tps.Windows.Forms.Button button_UpdatebyOframeOffset;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public TpsFormWobjCurrent(TpsResourceManager rM, RWSystem rwSystem, PipeGrooveModel pipeGrooveModel)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TpsFormWobjCurrent));
            this.menuItem_Refresh = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Apply = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Close = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.tpsLabel_oframeX = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_oframeX = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_oframeY = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_oframeY = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_oframeZ = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_oframeZ = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_WorldYOffset = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_WorldYOffset = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_WorldZOffset = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_WorldZOffset = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numSeamNormalAngle = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numSeamNormalAngle = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.button_UpdatebyWorldOffset = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.pictureBox_Logo = new ABB.Robotics.Tps.Windows.Forms.PictureBox();
            this.comboBox_numPipeGrooveType = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.tpsLabel_numPipeGrooveType = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_WorldXOffset = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_WorldXOffset = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numSeamCenterX = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numSeamCenterX = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.button_UpdatebyOframeOffset = new ABB.Robotics.Tps.Windows.Forms.Button();
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
            // tpsLabel_oframeX
            // 
            this.tpsLabel_oframeX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_oframeX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_oframeX.Location = new System.Drawing.Point(32, 170);
            this.tpsLabel_oframeX.Multiline = true;
            this.tpsLabel_oframeX.Name = "tpsLabel_oframeX";
            this.tpsLabel_oframeX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_oframeX.Size = new System.Drawing.Size(94, 24);
            this.tpsLabel_oframeX.TabIndex = 28;
            this.tpsLabel_oframeX.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_oframeX.Title = "oframe X";
            // 
            // numEditor_oframeX
            // 
            this.numEditor_oframeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_oframeX.CaretVisible = false;
            this.numEditor_oframeX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_oframeX.Location = new System.Drawing.Point(132, 170);
            this.numEditor_oframeX.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_oframeX.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_oframeX.Multiline = true;
            this.numEditor_oframeX.Name = "numEditor_oframeX";
            this.numEditor_oframeX.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_oframeX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_oframeX.SelectionLength = 0;
            this.numEditor_oframeX.SelectionStart = 0;
            this.numEditor_oframeX.SelectionVisible = false;
            this.numEditor_oframeX.Size = new System.Drawing.Size(102, 30);
            this.numEditor_oframeX.TabIndex = 29;
            this.numEditor_oframeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_oframeX.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_oframeY
            // 
            this.numEditor_oframeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_oframeY.CaretVisible = false;
            this.numEditor_oframeY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_oframeY.Location = new System.Drawing.Point(132, 206);
            this.numEditor_oframeY.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_oframeY.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_oframeY.Multiline = true;
            this.numEditor_oframeY.Name = "numEditor_oframeY";
            this.numEditor_oframeY.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_oframeY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_oframeY.SelectionLength = 0;
            this.numEditor_oframeY.SelectionStart = 0;
            this.numEditor_oframeY.SelectionVisible = false;
            this.numEditor_oframeY.Size = new System.Drawing.Size(102, 30);
            this.numEditor_oframeY.TabIndex = 29;
            this.numEditor_oframeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_oframeY.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_oframeY
            // 
            this.tpsLabel_oframeY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_oframeY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_oframeY.Location = new System.Drawing.Point(32, 206);
            this.tpsLabel_oframeY.Multiline = true;
            this.tpsLabel_oframeY.Name = "tpsLabel_oframeY";
            this.tpsLabel_oframeY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_oframeY.Size = new System.Drawing.Size(94, 24);
            this.tpsLabel_oframeY.TabIndex = 28;
            this.tpsLabel_oframeY.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_oframeY.Title = "oframe Y";
            // 
            // numEditor_oframeZ
            // 
            this.numEditor_oframeZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_oframeZ.CaretVisible = false;
            this.numEditor_oframeZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_oframeZ.Location = new System.Drawing.Point(132, 242);
            this.numEditor_oframeZ.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_oframeZ.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_oframeZ.Multiline = true;
            this.numEditor_oframeZ.Name = "numEditor_oframeZ";
            this.numEditor_oframeZ.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_oframeZ.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_oframeZ.SelectionLength = 0;
            this.numEditor_oframeZ.SelectionStart = 0;
            this.numEditor_oframeZ.SelectionVisible = false;
            this.numEditor_oframeZ.Size = new System.Drawing.Size(102, 30);
            this.numEditor_oframeZ.TabIndex = 29;
            this.numEditor_oframeZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_oframeZ.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_oframeZ
            // 
            this.tpsLabel_oframeZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_oframeZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_oframeZ.Location = new System.Drawing.Point(32, 242);
            this.tpsLabel_oframeZ.Multiline = true;
            this.tpsLabel_oframeZ.Name = "tpsLabel_oframeZ";
            this.tpsLabel_oframeZ.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_oframeZ.Size = new System.Drawing.Size(94, 24);
            this.tpsLabel_oframeZ.TabIndex = 28;
            this.tpsLabel_oframeZ.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_oframeZ.Title = "oframe Z";
            // 
            // numEditor_WorldYOffset
            // 
            this.numEditor_WorldYOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_WorldYOffset.CaretVisible = false;
            this.numEditor_WorldYOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_WorldYOffset.Location = new System.Drawing.Point(499, 206);
            this.numEditor_WorldYOffset.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_WorldYOffset.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_WorldYOffset.Multiline = true;
            this.numEditor_WorldYOffset.Name = "numEditor_WorldYOffset";
            this.numEditor_WorldYOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_WorldYOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_WorldYOffset.SelectionLength = 0;
            this.numEditor_WorldYOffset.SelectionStart = 0;
            this.numEditor_WorldYOffset.SelectionVisible = false;
            this.numEditor_WorldYOffset.Size = new System.Drawing.Size(102, 30);
            this.numEditor_WorldYOffset.TabIndex = 29;
            this.numEditor_WorldYOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tpsLabel_WorldYOffset
            // 
            this.tpsLabel_WorldYOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_WorldYOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_WorldYOffset.Location = new System.Drawing.Point(411, 206);
            this.tpsLabel_WorldYOffset.Multiline = true;
            this.tpsLabel_WorldYOffset.Name = "tpsLabel_WorldYOffset";
            this.tpsLabel_WorldYOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_WorldYOffset.Size = new System.Drawing.Size(81, 24);
            this.tpsLabel_WorldYOffset.TabIndex = 28;
            this.tpsLabel_WorldYOffset.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_WorldYOffset.Title = "World Y";
            // 
            // numEditor_WorldZOffset
            // 
            this.numEditor_WorldZOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_WorldZOffset.CaretVisible = false;
            this.numEditor_WorldZOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_WorldZOffset.Location = new System.Drawing.Point(499, 242);
            this.numEditor_WorldZOffset.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_WorldZOffset.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_WorldZOffset.Multiline = true;
            this.numEditor_WorldZOffset.Name = "numEditor_WorldZOffset";
            this.numEditor_WorldZOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_WorldZOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_WorldZOffset.SelectionLength = 0;
            this.numEditor_WorldZOffset.SelectionStart = 0;
            this.numEditor_WorldZOffset.SelectionVisible = false;
            this.numEditor_WorldZOffset.Size = new System.Drawing.Size(102, 30);
            this.numEditor_WorldZOffset.TabIndex = 29;
            this.numEditor_WorldZOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tpsLabel_WorldZOffset
            // 
            this.tpsLabel_WorldZOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_WorldZOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_WorldZOffset.Location = new System.Drawing.Point(411, 242);
            this.tpsLabel_WorldZOffset.Multiline = true;
            this.tpsLabel_WorldZOffset.Name = "tpsLabel_WorldZOffset";
            this.tpsLabel_WorldZOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_WorldZOffset.Size = new System.Drawing.Size(81, 24);
            this.tpsLabel_WorldZOffset.TabIndex = 28;
            this.tpsLabel_WorldZOffset.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_WorldZOffset.Title = "World Z";
            // 
            // numEditor_numSeamNormalAngle
            // 
            this.numEditor_numSeamNormalAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numSeamNormalAngle.CaretVisible = false;
            this.numEditor_numSeamNormalAngle.Enabled = false;
            this.numEditor_numSeamNormalAngle.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numSeamNormalAngle.Location = new System.Drawing.Point(499, 96);
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
            this.numEditor_numSeamNormalAngle.Size = new System.Drawing.Size(102, 30);
            this.numEditor_numSeamNormalAngle.TabIndex = 31;
            this.numEditor_numSeamNormalAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tpsLabel_numSeamNormalAngle
            // 
            this.tpsLabel_numSeamNormalAngle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numSeamNormalAngle.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numSeamNormalAngle.Location = new System.Drawing.Point(411, 96);
            this.tpsLabel_numSeamNormalAngle.Multiline = true;
            this.tpsLabel_numSeamNormalAngle.Name = "tpsLabel_numSeamNormalAngle";
            this.tpsLabel_numSeamNormalAngle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numSeamNormalAngle.Size = new System.Drawing.Size(81, 24);
            this.tpsLabel_numSeamNormalAngle.TabIndex = 30;
            this.tpsLabel_numSeamNormalAngle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numSeamNormalAngle.Title = "Angle";
            // 
            // button_UpdatebyWorldOffset
            // 
            this.button_UpdatebyWorldOffset.BackColor = System.Drawing.Color.White;
            this.button_UpdatebyWorldOffset.BackgroundImage = null;
            this.button_UpdatebyWorldOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_UpdatebyWorldOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_UpdatebyWorldOffset.Image = null;
            this.button_UpdatebyWorldOffset.Location = new System.Drawing.Point(278, 140);
            this.button_UpdatebyWorldOffset.Name = "button_UpdatebyWorldOffset";
            this.button_UpdatebyWorldOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_UpdatebyWorldOffset.Size = new System.Drawing.Size(94, 70);
            this.button_UpdatebyWorldOffset.TabIndex = 32;
            this.button_UpdatebyWorldOffset.Text = "<=";
            this.button_UpdatebyWorldOffset.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_UpdatebyWorldOffset.Click += new System.EventHandler(this.button_UpdatebyWorldOffset_Click);
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
            this.pictureBox_Logo.TabIndex = 33;
            // 
            // comboBox_numPipeGrooveType
            // 
            this.comboBox_numPipeGrooveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numPipeGrooveType.Enabled = false;
            this.comboBox_numPipeGrooveType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numPipeGrooveType.Items.Add("Platoon Container");
            this.comboBox_numPipeGrooveType.Items.Add("Platoon Header");
            this.comboBox_numPipeGrooveType.Items.Add("Saddle");
            this.comboBox_numPipeGrooveType.Location = new System.Drawing.Point(132, 48);
            this.comboBox_numPipeGrooveType.Name = "comboBox_numPipeGrooveType";
            this.comboBox_numPipeGrooveType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numPipeGrooveType.Size = new System.Drawing.Size(218, 33);
            this.comboBox_numPipeGrooveType.TabIndex = 35;
            this.comboBox_numPipeGrooveType.Text = "comboBox1";
            // 
            // tpsLabel_numPipeGrooveType
            // 
            this.tpsLabel_numPipeGrooveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numPipeGrooveType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numPipeGrooveType.Location = new System.Drawing.Point(32, 48);
            this.tpsLabel_numPipeGrooveType.Multiline = true;
            this.tpsLabel_numPipeGrooveType.Name = "tpsLabel_numPipeGrooveType";
            this.tpsLabel_numPipeGrooveType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numPipeGrooveType.Size = new System.Drawing.Size(85, 24);
            this.tpsLabel_numPipeGrooveType.TabIndex = 34;
            this.tpsLabel_numPipeGrooveType.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numPipeGrooveType.Title = "Type";
            // 
            // numEditor_WorldXOffset
            // 
            this.numEditor_WorldXOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_WorldXOffset.CaretVisible = false;
            this.numEditor_WorldXOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_WorldXOffset.Location = new System.Drawing.Point(499, 170);
            this.numEditor_WorldXOffset.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_WorldXOffset.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_WorldXOffset.Multiline = true;
            this.numEditor_WorldXOffset.Name = "numEditor_WorldXOffset";
            this.numEditor_WorldXOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_WorldXOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_WorldXOffset.SelectionLength = 0;
            this.numEditor_WorldXOffset.SelectionStart = 0;
            this.numEditor_WorldXOffset.SelectionVisible = false;
            this.numEditor_WorldXOffset.Size = new System.Drawing.Size(102, 30);
            this.numEditor_WorldXOffset.TabIndex = 29;
            this.numEditor_WorldXOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // tpsLabel_WorldXOffset
            // 
            this.tpsLabel_WorldXOffset.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_WorldXOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_WorldXOffset.Location = new System.Drawing.Point(411, 170);
            this.tpsLabel_WorldXOffset.Multiline = true;
            this.tpsLabel_WorldXOffset.Name = "tpsLabel_WorldXOffset";
            this.tpsLabel_WorldXOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_WorldXOffset.Size = new System.Drawing.Size(81, 24);
            this.tpsLabel_WorldXOffset.TabIndex = 28;
            this.tpsLabel_WorldXOffset.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_WorldXOffset.Title = "World X";
            // 
            // tpsLabel_numSeamCenterX
            // 
            this.tpsLabel_numSeamCenterX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numSeamCenterX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numSeamCenterX.Location = new System.Drawing.Point(32, 96);
            this.tpsLabel_numSeamCenterX.Multiline = true;
            this.tpsLabel_numSeamCenterX.Name = "tpsLabel_numSeamCenterX";
            this.tpsLabel_numSeamCenterX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numSeamCenterX.Size = new System.Drawing.Size(94, 24);
            this.tpsLabel_numSeamCenterX.TabIndex = 36;
            this.tpsLabel_numSeamCenterX.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numSeamCenterX.Title = "Center X";
            // 
            // numEditor_numSeamCenterX
            // 
            this.numEditor_numSeamCenterX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numSeamCenterX.CaretVisible = false;
            this.numEditor_numSeamCenterX.Enabled = false;
            this.numEditor_numSeamCenterX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numSeamCenterX.Location = new System.Drawing.Point(132, 96);
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
            this.numEditor_numSeamCenterX.Size = new System.Drawing.Size(102, 30);
            this.numEditor_numSeamCenterX.TabIndex = 37;
            this.numEditor_numSeamCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button_UpdatebyOframeOffset
            // 
            this.button_UpdatebyOframeOffset.BackColor = System.Drawing.Color.White;
            this.button_UpdatebyOframeOffset.BackgroundImage = null;
            this.button_UpdatebyOframeOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_UpdatebyOframeOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_UpdatebyOframeOffset.Image = null;
            this.button_UpdatebyOframeOffset.Location = new System.Drawing.Point(278, 216);
            this.button_UpdatebyOframeOffset.Name = "button_UpdatebyOframeOffset";
            this.button_UpdatebyOframeOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_UpdatebyOframeOffset.Size = new System.Drawing.Size(94, 70);
            this.button_UpdatebyOframeOffset.TabIndex = 38;
            this.button_UpdatebyOframeOffset.Text = ">=";
            this.button_UpdatebyOframeOffset.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_UpdatebyOframeOffset.Click += new System.EventHandler(this.button_UpdatebyOframeOffset_Click);
            // 
            // TpsFormWobjCurrent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.button_UpdatebyOframeOffset);
            this.Controls.Add(this.tpsLabel_numSeamCenterX);
            this.Controls.Add(this.numEditor_numSeamCenterX);
            this.Controls.Add(this.comboBox_numPipeGrooveType);
            this.Controls.Add(this.tpsLabel_numPipeGrooveType);
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.button_UpdatebyWorldOffset);
            this.Controls.Add(this.numEditor_numSeamNormalAngle);
            this.Controls.Add(this.tpsLabel_numSeamNormalAngle);
            this.Controls.Add(this.tpsLabel_oframeZ);
            this.Controls.Add(this.numEditor_oframeZ);
            this.Controls.Add(this.tpsLabel_oframeY);
            this.Controls.Add(this.tpsLabel_WorldXOffset);
            this.Controls.Add(this.tpsLabel_WorldYOffset);
            this.Controls.Add(this.numEditor_oframeY);
            this.Controls.Add(this.tpsLabel_WorldZOffset);
            this.Controls.Add(this.numEditor_WorldXOffset);
            this.Controls.Add(this.numEditor_WorldYOffset);
            this.Controls.Add(this.numEditor_WorldZOffset);
            this.Controls.Add(this.tpsLabel_oframeX);
            this.Controls.Add(this.numEditor_oframeX);
            // 
            // 
            // 
            this.MainMenu.MenuItems.Add(this.menuItem_Refresh);
            this.MainMenu.MenuItems.Add(this.menuItem_Apply);
            this.MainMenu.MenuItems.Add(this.menuItem_Close);
            this.Size = new System.Drawing.Size(640, 390);
            this.Text = "Wobj Current";
            this.Controls.SetChildIndex(this.numEditor_oframeX, 0);
            this.Controls.SetChildIndex(this.tpsLabel_oframeX, 0);
            this.Controls.SetChildIndex(this.numEditor_WorldZOffset, 0);
            this.Controls.SetChildIndex(this.numEditor_WorldYOffset, 0);
            this.Controls.SetChildIndex(this.numEditor_WorldXOffset, 0);
            this.Controls.SetChildIndex(this.tpsLabel_WorldZOffset, 0);
            this.Controls.SetChildIndex(this.numEditor_oframeY, 0);
            this.Controls.SetChildIndex(this.tpsLabel_WorldYOffset, 0);
            this.Controls.SetChildIndex(this.tpsLabel_WorldXOffset, 0);
            this.Controls.SetChildIndex(this.tpsLabel_oframeY, 0);
            this.Controls.SetChildIndex(this.numEditor_oframeZ, 0);
            this.Controls.SetChildIndex(this.tpsLabel_oframeZ, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numSeamNormalAngle, 0);
            this.Controls.SetChildIndex(this.numEditor_numSeamNormalAngle, 0);
            this.Controls.SetChildIndex(this.button_UpdatebyWorldOffset, 0);
            this.Controls.SetChildIndex(this.pictureBox_Logo, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numPipeGrooveType, 0);
            this.Controls.SetChildIndex(this.comboBox_numPipeGrooveType, 0);
            this.Controls.SetChildIndex(this.numEditor_numSeamCenterX, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numSeamCenterX, 0);
            this.Controls.SetChildIndex(this.button_UpdatebyOframeOffset, 0);
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


        void InitializeTexts()
        {
        }

        private void UpdateGUI(object sender, EventArgs e)
        {
            try
            {
                this.pipeGrooveModel.RefreshData(this.rwSystem);
                this.comboBox_numPipeGrooveType.SelectedIndex = this.pipeGrooveModel.numPipeGrooveType - 1;
                this.numEditor_numSeamCenterX.Value = this.pipeGrooveModel.numSeamCenterX;
                this.numEditor_numSeamNormalAngle.Value = this.pipeGrooveModel.numSeamNormalAngle;

                RapidData rapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "CalibDataModule", "wobjCurrent");
                this.wobjCurrent.FillFromString(rapidData.Value.ToString());

                this.numEditor_oframeX.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.X,1);
                this.numEditor_oframeY.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.Y,1);
                this.numEditor_oframeZ.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.Z, 1);

                if (this.pipeGrooveModel.numPipeGrooveType >= 3)
                {
                    this.numEditor_WorldXOffset.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.Z,1);

                    double dSeamNormalAngle = 0-Math.PI * ((double)this.numEditor_numSeamNormalAngle.Value) / 180;

                    double doframeX = this.wobjCurrent.Oframe.Trans.X;
                    double doframeY = this.wobjCurrent.Oframe.Trans.Y;

                    this.numEditor_WorldYOffset.Value = (decimal)Math.Round(doframeX * Math.Cos(dSeamNormalAngle) + doframeY * Math.Sin(dSeamNormalAngle),1);
                    this.numEditor_WorldZOffset.Value = (decimal)Math.Round(0 - doframeX * Math.Sin(dSeamNormalAngle) + doframeY * Math.Cos(dSeamNormalAngle),1);
                }
                else
                {
                    this.numEditor_WorldXOffset.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.X,1);
                    this.numEditor_WorldYOffset.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.Y,1);
                    this.numEditor_WorldZOffset.Value = (Decimal)Math.Round(this.wobjCurrent.Oframe.Trans.Z,1);
                }      

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
                this.wobjCurrent.Oframe.Trans.X =(float) this.numEditor_oframeX.Value;
                this.wobjCurrent.Oframe.Trans.Y = (float)this.numEditor_oframeY.Value;
                this.wobjCurrent.Oframe.Trans.Z = (float)this.numEditor_oframeZ.Value;

                RapidData rapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "CalibDataModule", "wobjCurrent");
                rapidData.Value = this.wobjCurrent;

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

        private void button_UpdatebyWorldOffset_Click(object sender, EventArgs e)
        {
            double dWorldXOffset = (double)this.numEditor_WorldXOffset.Value;
            double dWorldYOffset = (double)this.numEditor_WorldYOffset.Value;
            double dWorldZOffset = (double)this.numEditor_WorldZOffset.Value;
            double dSeamNormalAngle = Math.PI * ((double)this.numEditor_numSeamNormalAngle.Value) / 180;
            if (this.pipeGrooveModel.numPipeGrooveType >= 3)
            {
                double doframeX = dWorldYOffset * Math.Cos(dSeamNormalAngle) + dWorldZOffset * Math.Sin(dSeamNormalAngle);
                double doframeY = 0 - dWorldYOffset * Math.Sin(dSeamNormalAngle) + dWorldZOffset * Math.Cos(dSeamNormalAngle);
                this.numEditor_oframeX.Value = (decimal)Math.Round(doframeX, 1);
                this.numEditor_oframeY.Value = (decimal)Math.Round(doframeY, 1);
                this.numEditor_oframeZ.Value = (decimal)Math.Round(dWorldXOffset, 1);
            }
            else
            {
                this.numEditor_oframeX.Value = (decimal)Math.Round(dWorldXOffset, 1);
                this.numEditor_oframeY.Value = (decimal)Math.Round(dWorldYOffset, 1);
                this.numEditor_oframeZ.Value = (decimal)Math.Round(dWorldZOffset, 1);
            }
            this.menuItem_Apply.Enabled = true;
        }

        private void button_UpdatebyOframeOffset_Click(object sender, EventArgs e)
        {
            if (this.pipeGrooveModel.numPipeGrooveType >= 3)
            {
                this.numEditor_WorldXOffset.Value = this.numEditor_oframeZ.Value;

                double dSeamNormalAngle = 0 - Math.PI * ((double)this.numEditor_numSeamNormalAngle.Value) / 180;

                double doframeX = (double)this.numEditor_oframeX.Value;
                double doframeY = (double)this.numEditor_oframeY.Value;

                this.numEditor_WorldYOffset.Value = (decimal)Math.Round(doframeX * Math.Cos(dSeamNormalAngle) + doframeY * Math.Sin(dSeamNormalAngle), 1);
                this.numEditor_WorldZOffset.Value = (decimal)Math.Round(0 - doframeX * Math.Sin(dSeamNormalAngle) + doframeY * Math.Cos(dSeamNormalAngle), 1);
            }
            else
            {
                this.numEditor_WorldXOffset.Value = this.numEditor_oframeX.Value;
                this.numEditor_WorldYOffset.Value = this.numEditor_oframeY.Value;
                this.numEditor_WorldZOffset.Value = this.numEditor_oframeZ.Value;
            }     
        }

    }
}