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
using ABB.Robotics.ProductionScreen.Base;
using ABB.Robotics.Controllers.RapidDomain;

namespace TpsViewEbaraV2NameSpace
{
    public class TpsFormSetting : TpsForm, ITpsViewActivation
    {
        private TpsResourceManager _tpsRm = null;
        private RWSystem rwSystem = null;

        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolBlocksiFr1ArcStable;
        private NumEditor numEditor_numBlocksiArcStableLength;
        private TpsLabel tpsLabel_numBlocksiArcStableLength;
        private TpsLabel tpsLabel_numIsometricalSaddleCoefficient;
        private NumEditor numEditor_numIsometricalSaddleCoefficient;
        private TpsLabel tpsLabel_numShoulderGrooveCoefficient;
        private NumEditor numEditor_numShoulderGrooveCoefficient;
        private TpsLabel tpsLabel_numTorchCleanIntervalCount;
        private NumEditor numEditor_numTorchCleanIntervalCount;
        private ABB.Robotics.Tps.Windows.Forms.Button button_limitSTN1Axis1;
        private ABB.Robotics.Tps.Windows.Forms.Button button_unLimitSTN1Axis1;

        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Refresh;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Apply;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Close;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public TpsFormSetting(TpsResourceManager rM, RWSystem rwSystem)
        {
            try
            {
                InitializeComponent();
                this._tpsRm = rM;
                this.rwSystem = rwSystem;
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
            this.checkBox_boolBlocksiFr1ArcStable = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.numEditor_numBlocksiArcStableLength = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numBlocksiArcStableLength = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.menuItem_Refresh = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Apply = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.tpsLabel_numIsometricalSaddleCoefficient = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numIsometricalSaddleCoefficient = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numShoulderGrooveCoefficient = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numShoulderGrooveCoefficient = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numTorchCleanIntervalCount = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numTorchCleanIntervalCount = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.menuItem_Close = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.button_limitSTN1Axis1 = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.button_unLimitSTN1Axis1 = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_boolBlocksiFr1ArcStable
            // 
            this.checkBox_boolBlocksiFr1ArcStable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolBlocksiFr1ArcStable.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolBlocksiFr1ArcStable.Location = new System.Drawing.Point(22, 53);
            this.checkBox_boolBlocksiFr1ArcStable.Name = "checkBox_boolBlocksiFr1ArcStable";
            this.checkBox_boolBlocksiFr1ArcStable.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolBlocksiFr1ArcStable.Size = new System.Drawing.Size(188, 24);
            this.checkBox_boolBlocksiFr1ArcStable.TabIndex = 43;
            this.checkBox_boolBlocksiFr1ArcStable.Text = "Block Arc Stable";
            this.checkBox_boolBlocksiFr1ArcStable.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numBlocksiArcStableLength
            // 
            this.numEditor_numBlocksiArcStableLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numBlocksiArcStableLength.CaretVisible = false;
            this.numEditor_numBlocksiArcStableLength.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numBlocksiArcStableLength.Location = new System.Drawing.Point(225, 99);
            this.numEditor_numBlocksiArcStableLength.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numBlocksiArcStableLength.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numBlocksiArcStableLength.Multiline = true;
            this.numEditor_numBlocksiArcStableLength.Name = "numEditor_numBlocksiArcStableLength";
            this.numEditor_numBlocksiArcStableLength.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numBlocksiArcStableLength.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numBlocksiArcStableLength.SelectionLength = 0;
            this.numEditor_numBlocksiArcStableLength.SelectionStart = 0;
            this.numEditor_numBlocksiArcStableLength.SelectionVisible = false;
            this.numEditor_numBlocksiArcStableLength.Size = new System.Drawing.Size(96, 24);
            this.numEditor_numBlocksiArcStableLength.TabIndex = 42;
            this.numEditor_numBlocksiArcStableLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numBlocksiArcStableLength.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numBlocksiArcStableLength
            // 
            this.tpsLabel_numBlocksiArcStableLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numBlocksiArcStableLength.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numBlocksiArcStableLength.Location = new System.Drawing.Point(22, 99);
            this.tpsLabel_numBlocksiArcStableLength.Multiline = true;
            this.tpsLabel_numBlocksiArcStableLength.Name = "tpsLabel_numBlocksiArcStableLength";
            this.tpsLabel_numBlocksiArcStableLength.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numBlocksiArcStableLength.Size = new System.Drawing.Size(151, 24);
            this.tpsLabel_numBlocksiArcStableLength.TabIndex = 41;
            this.tpsLabel_numBlocksiArcStableLength.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numBlocksiArcStableLength.Title = "Block Arc Length";
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
            // tpsLabel_numIsometricalSaddleCoefficient
            // 
            this.tpsLabel_numIsometricalSaddleCoefficient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numIsometricalSaddleCoefficient.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numIsometricalSaddleCoefficient.Location = new System.Drawing.Point(22, 141);
            this.tpsLabel_numIsometricalSaddleCoefficient.Multiline = true;
            this.tpsLabel_numIsometricalSaddleCoefficient.Name = "tpsLabel_numIsometricalSaddleCoefficient";
            this.tpsLabel_numIsometricalSaddleCoefficient.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numIsometricalSaddleCoefficient.Size = new System.Drawing.Size(200, 24);
            this.tpsLabel_numIsometricalSaddleCoefficient.TabIndex = 41;
            this.tpsLabel_numIsometricalSaddleCoefficient.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numIsometricalSaddleCoefficient.Title = "Isometrical Saddle";
            // 
            // numEditor_numIsometricalSaddleCoefficient
            // 
            this.numEditor_numIsometricalSaddleCoefficient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numIsometricalSaddleCoefficient.CaretVisible = false;
            this.numEditor_numIsometricalSaddleCoefficient.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numIsometricalSaddleCoefficient.Location = new System.Drawing.Point(225, 141);
            this.numEditor_numIsometricalSaddleCoefficient.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numIsometricalSaddleCoefficient.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numIsometricalSaddleCoefficient.Multiline = true;
            this.numEditor_numIsometricalSaddleCoefficient.Name = "numEditor_numIsometricalSaddleCoefficient";
            this.numEditor_numIsometricalSaddleCoefficient.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numIsometricalSaddleCoefficient.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numIsometricalSaddleCoefficient.SelectionLength = 0;
            this.numEditor_numIsometricalSaddleCoefficient.SelectionStart = 0;
            this.numEditor_numIsometricalSaddleCoefficient.SelectionVisible = false;
            this.numEditor_numIsometricalSaddleCoefficient.Size = new System.Drawing.Size(96, 24);
            this.numEditor_numIsometricalSaddleCoefficient.TabIndex = 42;
            this.numEditor_numIsometricalSaddleCoefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numIsometricalSaddleCoefficient.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numShoulderGrooveCoefficient
            // 
            this.tpsLabel_numShoulderGrooveCoefficient.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numShoulderGrooveCoefficient.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numShoulderGrooveCoefficient.Location = new System.Drawing.Point(22, 185);
            this.tpsLabel_numShoulderGrooveCoefficient.Multiline = true;
            this.tpsLabel_numShoulderGrooveCoefficient.Name = "tpsLabel_numShoulderGrooveCoefficient";
            this.tpsLabel_numShoulderGrooveCoefficient.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numShoulderGrooveCoefficient.Size = new System.Drawing.Size(200, 24);
            this.tpsLabel_numShoulderGrooveCoefficient.TabIndex = 41;
            this.tpsLabel_numShoulderGrooveCoefficient.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numShoulderGrooveCoefficient.Title = "Shoulder Coeff.";
            // 
            // numEditor_numShoulderGrooveCoefficient
            // 
            this.numEditor_numShoulderGrooveCoefficient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numShoulderGrooveCoefficient.CaretVisible = false;
            this.numEditor_numShoulderGrooveCoefficient.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numShoulderGrooveCoefficient.Location = new System.Drawing.Point(225, 185);
            this.numEditor_numShoulderGrooveCoefficient.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numShoulderGrooveCoefficient.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numShoulderGrooveCoefficient.Multiline = true;
            this.numEditor_numShoulderGrooveCoefficient.Name = "numEditor_numShoulderGrooveCoefficient";
            this.numEditor_numShoulderGrooveCoefficient.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numShoulderGrooveCoefficient.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numShoulderGrooveCoefficient.SelectionLength = 0;
            this.numEditor_numShoulderGrooveCoefficient.SelectionStart = 0;
            this.numEditor_numShoulderGrooveCoefficient.SelectionVisible = false;
            this.numEditor_numShoulderGrooveCoefficient.Size = new System.Drawing.Size(96, 24);
            this.numEditor_numShoulderGrooveCoefficient.TabIndex = 42;
            this.numEditor_numShoulderGrooveCoefficient.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numShoulderGrooveCoefficient.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numTorchCleanIntervalCount
            // 
            this.tpsLabel_numTorchCleanIntervalCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numTorchCleanIntervalCount.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numTorchCleanIntervalCount.Location = new System.Drawing.Point(22, 231);
            this.tpsLabel_numTorchCleanIntervalCount.Multiline = true;
            this.tpsLabel_numTorchCleanIntervalCount.Name = "tpsLabel_numTorchCleanIntervalCount";
            this.tpsLabel_numTorchCleanIntervalCount.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numTorchCleanIntervalCount.Size = new System.Drawing.Size(200, 24);
            this.tpsLabel_numTorchCleanIntervalCount.TabIndex = 41;
            this.tpsLabel_numTorchCleanIntervalCount.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numTorchCleanIntervalCount.Title = "TSC Interval";
            // 
            // numEditor_numTorchCleanIntervalCount
            // 
            this.numEditor_numTorchCleanIntervalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numTorchCleanIntervalCount.CaretVisible = false;
            this.numEditor_numTorchCleanIntervalCount.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numTorchCleanIntervalCount.Location = new System.Drawing.Point(225, 231);
            this.numEditor_numTorchCleanIntervalCount.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numTorchCleanIntervalCount.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numTorchCleanIntervalCount.Multiline = true;
            this.numEditor_numTorchCleanIntervalCount.Name = "numEditor_numTorchCleanIntervalCount";
            this.numEditor_numTorchCleanIntervalCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numTorchCleanIntervalCount.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numTorchCleanIntervalCount.SelectionLength = 0;
            this.numEditor_numTorchCleanIntervalCount.SelectionStart = 0;
            this.numEditor_numTorchCleanIntervalCount.SelectionVisible = false;
            this.numEditor_numTorchCleanIntervalCount.Size = new System.Drawing.Size(96, 24);
            this.numEditor_numTorchCleanIntervalCount.TabIndex = 42;
            this.numEditor_numTorchCleanIntervalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numTorchCleanIntervalCount.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
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
            // button_limitSTN1Axis1
            // 
            this.button_limitSTN1Axis1.BackColor = System.Drawing.Color.White;
            this.button_limitSTN1Axis1.BackgroundImage = null;
            this.button_limitSTN1Axis1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_limitSTN1Axis1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_limitSTN1Axis1.Image = null;
            this.button_limitSTN1Axis1.Location = new System.Drawing.Point(420, 95);
            this.button_limitSTN1Axis1.Name = "button_limitSTN1Axis1";
            this.button_limitSTN1Axis1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_limitSTN1Axis1.Size = new System.Drawing.Size(140, 70);
            this.button_limitSTN1Axis1.TabIndex = 44;
            this.button_limitSTN1Axis1.Text = "Limit Axis 1";
            this.button_limitSTN1Axis1.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_limitSTN1Axis1.Click += new System.EventHandler(this.button_limitSTN1Axis1_Click);
            // 
            // button_unLimitSTN1Axis1
            // 
            this.button_unLimitSTN1Axis1.BackColor = System.Drawing.Color.White;
            this.button_unLimitSTN1Axis1.BackgroundImage = null;
            this.button_unLimitSTN1Axis1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_unLimitSTN1Axis1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_unLimitSTN1Axis1.Image = null;
            this.button_unLimitSTN1Axis1.Location = new System.Drawing.Point(420, 185);
            this.button_unLimitSTN1Axis1.Name = "button_unLimitSTN1Axis1";
            this.button_unLimitSTN1Axis1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_unLimitSTN1Axis1.Size = new System.Drawing.Size(140, 70);
            this.button_unLimitSTN1Axis1.TabIndex = 44;
            this.button_unLimitSTN1Axis1.Text = "Unlimit Axis 1";
            this.button_unLimitSTN1Axis1.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_unLimitSTN1Axis1.Click += new System.EventHandler(this.button_unLimitSTN1Axis1_Click);
            // 
            // TpsFormSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.button_unLimitSTN1Axis1);
            this.Controls.Add(this.button_limitSTN1Axis1);
            this.Controls.Add(this.checkBox_boolBlocksiFr1ArcStable);
            this.Controls.Add(this.numEditor_numTorchCleanIntervalCount);
            this.Controls.Add(this.numEditor_numShoulderGrooveCoefficient);
            this.Controls.Add(this.numEditor_numIsometricalSaddleCoefficient);
            this.Controls.Add(this.numEditor_numBlocksiArcStableLength);
            this.Controls.Add(this.tpsLabel_numTorchCleanIntervalCount);
            this.Controls.Add(this.tpsLabel_numShoulderGrooveCoefficient);
            this.Controls.Add(this.tpsLabel_numIsometricalSaddleCoefficient);
            this.Controls.Add(this.tpsLabel_numBlocksiArcStableLength);
            // 
            // 
            // 
            this.MainMenu.MenuItems.Add(this.menuItem_Refresh);
            this.MainMenu.MenuItems.Add(this.menuItem_Apply);
            this.MainMenu.MenuItems.Add(this.menuItem_Close);
            this.Size = new System.Drawing.Size(640, 390);
            this.Text = "Setting";
            this.Controls.SetChildIndex(this.tpsLabel_numBlocksiArcStableLength, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numIsometricalSaddleCoefficient, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numShoulderGrooveCoefficient, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numTorchCleanIntervalCount, 0);
            this.Controls.SetChildIndex(this.numEditor_numBlocksiArcStableLength, 0);
            this.Controls.SetChildIndex(this.numEditor_numIsometricalSaddleCoefficient, 0);
            this.Controls.SetChildIndex(this.numEditor_numShoulderGrooveCoefficient, 0);
            this.Controls.SetChildIndex(this.numEditor_numTorchCleanIntervalCount, 0);
            this.Controls.SetChildIndex(this.checkBox_boolBlocksiFr1ArcStable, 0);
            this.Controls.SetChildIndex(this.button_limitSTN1Axis1, 0);
            this.Controls.SetChildIndex(this.button_unLimitSTN1Axis1, 0);
            this.ResumeLayout(false);

        }

        #endregion


        void InitializeTexts()
        {
            this.Text = _tpsRm.GetString("TXT_TpsFormSettingTitle");
            this.checkBox_boolBlocksiFr1ArcStable.Text = _tpsRm.GetString("TXT_checkBox_boolBlocksiFr1ArcStable");
            this.tpsLabel_numBlocksiArcStableLength.Text = _tpsRm.GetString("TXT_tpsLabel_numBlocksiArcStableLength");
            this.tpsLabel_numIsometricalSaddleCoefficient.Text = _tpsRm.GetString("TXT_tpsLabel_numIsometricalSaddleCoefficient");
            this.tpsLabel_numShoulderGrooveCoefficient.Text = _tpsRm.GetString("TXT_tpsLabel_numShoulderGrooveCoefficient");
            this.tpsLabel_numTorchCleanIntervalCount.Text = _tpsRm.GetString("TXT_tpsLabel_numTorchCleanIntervalCount");
            this.button_limitSTN1Axis1.Text = _tpsRm.GetString("TXT_button_limitSTN1Axis1");
            this.button_unLimitSTN1Axis1.Text = _tpsRm.GetString("TXT_button_unLimitSTN1Axis1");
        }

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
                ABB.Robotics.Controllers.RapidDomain.RapidData boolBlocksiFr1ArcStable = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "boolBlocksiFr1ArcStable");
                ABB.Robotics.Controllers.RapidDomain.Bool bBlocksiFr1ArcStable = new ABB.Robotics.Controllers.RapidDomain.Bool();
                bBlocksiFr1ArcStable.FillFromString(boolBlocksiFr1ArcStable.Value.ToString());
                this.checkBox_boolBlocksiFr1ArcStable.Checked = bBlocksiFr1ArcStable;
                boolBlocksiFr1ArcStable.Dispose();

                ABB.Robotics.Controllers.RapidDomain.RapidData numBlocksiArcStableLength = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "numBlocksiArcStableLength");
                ABB.Robotics.Controllers.RapidDomain.Num nBlocksiArcStableLength = new ABB.Robotics.Controllers.RapidDomain.Num();
                nBlocksiArcStableLength.FillFromString(numBlocksiArcStableLength.Value.ToString());
                this.numEditor_numBlocksiArcStableLength.Value = Convert.ToDecimal(nBlocksiArcStableLength);
                numBlocksiArcStableLength.Dispose();

                this.rwSystem.RefreshTpsControl("T_ROB1", "GlobalDataModule", "numIsometricalSaddleCoefficient", this.numEditor_numIsometricalSaddleCoefficient);
                this.rwSystem.RefreshTpsControl("T_ROB1", "GlobalDataModule", "numShoulderGrooveCoefficient", this.numEditor_numShoulderGrooveCoefficient);
                this.rwSystem.RefreshTpsControl("T_ROB1", "GlobalDataModule", "numTorchCleanIntervalCount", this.numEditor_numTorchCleanIntervalCount);

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
                ABB.Robotics.Controllers.RapidDomain.RapidData boolBlocksiFr1ArcStable = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "boolBlocksiFr1ArcStable");
                ABB.Robotics.Controllers.RapidDomain.Bool bBlocksiFr1ArcStable = new ABB.Robotics.Controllers.RapidDomain.Bool(this.checkBox_boolBlocksiFr1ArcStable.Checked);
                boolBlocksiFr1ArcStable.Value = bBlocksiFr1ArcStable;
                boolBlocksiFr1ArcStable.Dispose();

                ABB.Robotics.Controllers.RapidDomain.RapidData numBlocksiArcStableLength = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "GlobalDataModule", "numBlocksiArcStableLength");
                ABB.Robotics.Controllers.RapidDomain.Num nBlocksiArcStableLength = new ABB.Robotics.Controllers.RapidDomain.Num(Convert.ToDouble(this.numEditor_numBlocksiArcStableLength.Value));
                numBlocksiArcStableLength.Value = nBlocksiArcStableLength;
                numBlocksiArcStableLength.Dispose();

                this.rwSystem.ApplyTpsControl("T_ROB1", "GlobalDataModule", "numIsometricalSaddleCoefficient", this.numEditor_numIsometricalSaddleCoefficient);
                this.rwSystem.ApplyTpsControl("T_ROB1", "GlobalDataModule", "numShoulderGrooveCoefficient", this.numEditor_numShoulderGrooveCoefficient);
                this.rwSystem.ApplyTpsControl("T_ROB1", "GlobalDataModule", "numTorchCleanIntervalCount", this.numEditor_numTorchCleanIntervalCount);

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

        private void button_limitSTN1Axis1_Click(object sender, EventArgs e)
        {
            this.rwSystem.Controller.Configuration.Write("0","MOC", "Arm", "M8DM2", "upper_joint_bound");
            this.rwSystem.Controller.Configuration.Write("0", "MOC", "Arm", "M8DM2", "lower_joint_bound");
            GTPUMessageBox.Show(this.Parent
                , RestartController
                , "The changes will not take effect until the controller is restarted.\n\nDo you want to restart now?"
                , "Restart"
                , MessageBoxIcon.Asterisk, MessageBoxButtons.YesNo);
            //this.rwSystem.Controller.Restart();
        }

        private void button_unLimitSTN1Axis1_Click(object sender, EventArgs e)
        {
            this.rwSystem.Controller.Configuration.Write("3.159", "MOC", "Arm", "M8DM2", "upper_joint_bound");
            this.rwSystem.Controller.Configuration.Write("-3.159", "MOC", "Arm", "M8DM2", "lower_joint_bound");
            GTPUMessageBox.Show(this.Parent
                , RestartController
                , "The changes will not take effect until the controller is restarted.\n\nDo you want to restart now?"
                , "Restart"
                , MessageBoxIcon.Asterisk, MessageBoxButtons.YesNo);
            //this.rwSystem.Controller.Restart();
        }

        private void RestartController( Object sender, MessageBoxEventArgs e)
        {
            if (e.DialogResult == DialogResult.Yes)
            {
                this.rwSystem.Controller.Restart();
            }
            //ErrorHandler.AddErrorMessage("MichaelLog",string.Format("{0},{1},{2}",e.ButtonText,e.DialogResult,e.State));
        }

    }
}