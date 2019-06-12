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
            this.tpsLabel_oframeX.Location = new System.Drawing.Point(32, 78);
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
            this.numEditor_oframeX.Location = new System.Drawing.Point(132, 78);
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
            this.numEditor_oframeX.Size = new System.Drawing.Size(149, 30);
            this.numEditor_oframeX.TabIndex = 29;
            this.numEditor_oframeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_oframeX.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_oframeY
            // 
            this.numEditor_oframeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_oframeY.CaretVisible = false;
            this.numEditor_oframeY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_oframeY.Location = new System.Drawing.Point(132, 130);
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
            this.numEditor_oframeY.Size = new System.Drawing.Size(149, 30);
            this.numEditor_oframeY.TabIndex = 29;
            this.numEditor_oframeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_oframeY.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_oframeY
            // 
            this.tpsLabel_oframeY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_oframeY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_oframeY.Location = new System.Drawing.Point(32, 130);
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
            this.numEditor_oframeZ.Location = new System.Drawing.Point(132, 182);
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
            this.numEditor_oframeZ.Size = new System.Drawing.Size(149, 30);
            this.numEditor_oframeZ.TabIndex = 29;
            this.numEditor_oframeZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_oframeZ.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_oframeZ
            // 
            this.tpsLabel_oframeZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_oframeZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_oframeZ.Location = new System.Drawing.Point(32, 182);
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
            this.numEditor_WorldYOffset.Location = new System.Drawing.Point(500, 78);
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
            this.tpsLabel_WorldYOffset.Location = new System.Drawing.Point(353, 78);
            this.tpsLabel_WorldYOffset.Multiline = true;
            this.tpsLabel_WorldYOffset.Name = "tpsLabel_WorldYOffset";
            this.tpsLabel_WorldYOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_WorldYOffset.Size = new System.Drawing.Size(128, 24);
            this.tpsLabel_WorldYOffset.TabIndex = 28;
            this.tpsLabel_WorldYOffset.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_WorldYOffset.Title = "World Y Offset";
            // 
            // numEditor_WorldZOffset
            // 
            this.numEditor_WorldZOffset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_WorldZOffset.CaretVisible = false;
            this.numEditor_WorldZOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_WorldZOffset.Location = new System.Drawing.Point(500, 130);
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
            this.tpsLabel_WorldZOffset.Location = new System.Drawing.Point(353, 130);
            this.tpsLabel_WorldZOffset.Multiline = true;
            this.tpsLabel_WorldZOffset.Name = "tpsLabel_WorldZOffset";
            this.tpsLabel_WorldZOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_WorldZOffset.Size = new System.Drawing.Size(128, 24);
            this.tpsLabel_WorldZOffset.TabIndex = 28;
            this.tpsLabel_WorldZOffset.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_WorldZOffset.Title = "World Z Offset";
            // 
            // numEditor_numSeamNormalAngle
            // 
            this.numEditor_numSeamNormalAngle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numSeamNormalAngle.CaretVisible = false;
            this.numEditor_numSeamNormalAngle.Enabled = false;
            this.numEditor_numSeamNormalAngle.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numSeamNormalAngle.Location = new System.Drawing.Point(500, 182);
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
            this.tpsLabel_numSeamNormalAngle.Location = new System.Drawing.Point(352, 182);
            this.tpsLabel_numSeamNormalAngle.Multiline = true;
            this.tpsLabel_numSeamNormalAngle.Name = "tpsLabel_numSeamNormalAngle";
            this.tpsLabel_numSeamNormalAngle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numSeamNormalAngle.Size = new System.Drawing.Size(129, 24);
            this.tpsLabel_numSeamNormalAngle.TabIndex = 30;
            this.tpsLabel_numSeamNormalAngle.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numSeamNormalAngle.Title = "Normal Angle";
            // 
            // button_UpdatebyWorldOffset
            // 
            this.button_UpdatebyWorldOffset.BackColor = System.Drawing.Color.White;
            this.button_UpdatebyWorldOffset.BackgroundImage = null;
            this.button_UpdatebyWorldOffset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_UpdatebyWorldOffset.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_UpdatebyWorldOffset.Image = null;
            this.button_UpdatebyWorldOffset.Location = new System.Drawing.Point(353, 261);
            this.button_UpdatebyWorldOffset.Name = "button_UpdatebyWorldOffset";
            this.button_UpdatebyWorldOffset.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_UpdatebyWorldOffset.Size = new System.Drawing.Size(140, 70);
            this.button_UpdatebyWorldOffset.TabIndex = 32;
            this.button_UpdatebyWorldOffset.Text = "Offset";
            this.button_UpdatebyWorldOffset.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_UpdatebyWorldOffset.Click += new System.EventHandler(this.button_UpdatebyWorldOffset_Click);
            // 
            // TpsFormWobjCurrent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.button_UpdatebyWorldOffset);
            this.Controls.Add(this.numEditor_numSeamNormalAngle);
            this.Controls.Add(this.tpsLabel_numSeamNormalAngle);
            this.Controls.Add(this.tpsLabel_oframeZ);
            this.Controls.Add(this.numEditor_oframeZ);
            this.Controls.Add(this.tpsLabel_oframeY);
            this.Controls.Add(this.tpsLabel_WorldYOffset);
            this.Controls.Add(this.numEditor_oframeY);
            this.Controls.Add(this.tpsLabel_WorldZOffset);
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
            this.Controls.SetChildIndex(this.tpsLabel_WorldZOffset, 0);
            this.Controls.SetChildIndex(this.numEditor_oframeY, 0);
            this.Controls.SetChildIndex(this.tpsLabel_WorldYOffset, 0);
            this.Controls.SetChildIndex(this.tpsLabel_oframeY, 0);
            this.Controls.SetChildIndex(this.numEditor_oframeZ, 0);
            this.Controls.SetChildIndex(this.tpsLabel_oframeZ, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numSeamNormalAngle, 0);
            this.Controls.SetChildIndex(this.numEditor_numSeamNormalAngle, 0);
            this.Controls.SetChildIndex(this.button_UpdatebyWorldOffset, 0);
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
                this.numEditor_numSeamNormalAngle.Value = this.pipeGrooveModel.numSeamNormalAngle;

                RapidData rapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "CalibDataModule", "wobjCurrent");
                this.wobjCurrent.FillFromString(rapidData.Value.ToString());

                this.numEditor_oframeX.Value = (Decimal)this.wobjCurrent.Oframe.Trans.X;
                this.numEditor_oframeY.Value = (Decimal)this.wobjCurrent.Oframe.Trans.Y;
                this.numEditor_oframeZ.Value = (Decimal)this.wobjCurrent.Oframe.Trans.Z;

                this.numEditor_WorldYOffset.Value = 0;
                this.numEditor_WorldZOffset.Value = 0;

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
            double dWorldYOffset = (double)this.numEditor_WorldYOffset.Value;
            double dWorldZOffset = (double)this.numEditor_WorldZOffset.Value;
            double dSeamNormalAngle =Math.PI* ((double)this.numEditor_numSeamNormalAngle.Value)/180 ;
            double doframeX = dWorldYOffset * Math.Cos(dSeamNormalAngle) + dWorldZOffset * Math.Sin(dSeamNormalAngle);
            double doframeY = 0 - dWorldYOffset * Math.Sin(dSeamNormalAngle) + dWorldZOffset * Math.Cos(dSeamNormalAngle);
            this.numEditor_oframeX.Value = (decimal)Math.Round(doframeX, 1);
            this.numEditor_oframeY.Value = (decimal)Math.Round(doframeY, 1);
            this.menuItem_Apply.Enabled = true;
        }
    }
}