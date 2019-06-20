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
    public class TpsFormWeldingParameter : TpsForm, ITpsViewActivation
    {
        private TpsResourceManager _tpsRm = null;
        private RWSystem rwSystem = null;
        private WeldProcedure weldProcedure = null;

        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Refresh;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Apply;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Close;
        private ABB.Robotics.Tps.Windows.Forms.TabControl tabControl_WeldingParameter;
        private ABB.Robotics.Tps.Windows.Forms.TabPage tabPage_Weld;
        private ABB.Robotics.Tps.Windows.Forms.TabPage tabPage_Weave;
        private TpsLabel tpsLabel_intGroupIndex;
        private ABB.Robotics.Tps.Windows.Forms.NumericUpDown numericUpDown_intGroupIndex;
        private TpsLabel tpsLabel_intIndex;
        private ABB.Robotics.Tps.Windows.Forms.NumericUpDown numericUpDown_intIndex;
        private DataEditor dataEditor_strWeldProcedureID;
        private TpsLabel tpsLabel_strWeldProcedureID;
        private TpsLabel tpsLabel_numWeldSpeed;
        private NumEditor numEditor_numWeldSpeed;
        private TpsLabel tpsLabel_numPostFlow;
        private TpsLabel tpsLabel_numSche;
        private TpsLabel tpsLabel_numPreFlow;
        private NumEditor numEditor_numPostFlow;
        private NumEditor numEditor_numSche;
        private NumEditor numEditor_numPreFlow;
        private TpsLabel tpsLabel_numWeaveLength;
        private TpsLabel tpsLabel_numWeaveType;
        private TpsLabel tpsLabel_numWeaveShape;
        private NumEditor numEditor_numWeaveLength;
        private TpsLabel tpsLabel_numWeaveHeigth;
        private TpsLabel tpsLabel_numWeaveWidth;
        private NumEditor numEditor_numWeaveHeigth;
        private NumEditor numEditor_numWeaveWidth;
        private TpsLabel tpsLabel_numDwellRight;
        private TpsLabel tpsLabel_numDwellCenter;
        private TpsLabel tpsLabel_numDwellLeft;
        private NumEditor numEditor_numDwellRight;
        private NumEditor numEditor_numDwellCenter;
        private NumEditor numEditor_numDwellLeft;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numWeaveType;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numWeaveShape;
        private TpsLabel tpsLabel_numWeaveOri;
        private TpsLabel tpsLabel_numWeaveTilt;
        private TpsLabel tpsLabel_numWeaveDir;
        private NumEditor numEditor_numWeaveOri;
        private NumEditor numEditor_numWeaveTilt;
        private NumEditor numEditor_numWeaveDir;
        private TpsLabel tpsLabel_numWeaveBias;
        private NumEditor numEditor_numWeaveBias;
        private TpsLabel tpsLabel_numWeaveWidth90;
        private NumEditor numEditor_numWeaveWidth90;
        private ABB.Robotics.Tps.Windows.Forms.TabPage tabPage_Track;
        private ABB.Robotics.Tps.Windows.Forms.ComboBox comboBox_numTrackType;
        private TpsLabel tpsLabel_numGainY;
        private TpsLabel tpsLabel_numTrackType;
        private NumEditor numEditor_numGainY;
        private TpsLabel tpsLabel_numGainZ;
        private TpsLabel tpsLabel_numPenetration;
        private NumEditor numEditor_numGainZ;
        private NumEditor numEditor_numPenetration;
        private TpsLabel tpsLabel_numTrackBias;
        private NumEditor numEditor_numTrackBias;
        private TpsLabel tpsLabel_numTrackCurrent;
        private NumEditor numEditor_numTrackCurrent;
        private TpsLabel tpsLabel_strRemark;
        private DataEditor dataEditor_strRemark;
        private TpsLabel tpsLabel3;
        private TpsLabel tpsLabel2;
        private TpsLabel tpsLabel1;
        private ABB.Robotics.Tps.Windows.Forms.Button button_UpdateID;
        private ABB.Robotics.Tps.Windows.Forms.PictureBox pictureBox_Logo;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public TpsFormWeldingParameter(TpsResourceManager rM, RWSystem rwSystem, WeldProcedure weldProcedure)
        {
            try
            {
                InitializeComponent();
                this._tpsRm = rM;
                this.rwSystem = rwSystem;
                this.weldProcedure = weldProcedure;
                this.numericUpDown_intGroupIndex.Value = this.weldProcedure.intGroupIndex;
                this.numericUpDown_intIndex.Value = this.weldProcedure.intIndex;
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
                        if (this.weldProcedure != null)
                        {
                            this.weldProcedure.Dispose();
                            this.weldProcedure = null;
                        }

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TpsFormWeldingParameter));
            this.menuItem_Refresh = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Apply = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Close = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.tabControl_WeldingParameter = new ABB.Robotics.Tps.Windows.Forms.TabControl();
            this.tabPage_Weld = new ABB.Robotics.Tps.Windows.Forms.TabPage();
            this.button_UpdateID = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.tpsLabel3 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel2 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel1 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.dataEditor_strRemark = new ABB.Robotics.Tps.Windows.Forms.DataEditor();
            this.dataEditor_strWeldProcedureID = new ABB.Robotics.Tps.Windows.Forms.DataEditor();
            this.tpsLabel_strWeldProcedureID = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numPostFlow = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_strRemark = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numSche = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numPreFlow = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeldSpeed = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numPostFlow = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numSche = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numPreFlow = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeldSpeed = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tabPage_Weave = new ABB.Robotics.Tps.Windows.Forms.TabPage();
            this.tpsLabel_numWeaveOri = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveTilt = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveDir = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numWeaveOri = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeaveTilt = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeaveDir = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numDwellRight = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numDwellCenter = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numDwellLeft = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numDwellRight = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numDwellCenter = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numDwellLeft = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.comboBox_numWeaveType = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.comboBox_numWeaveShape = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.tpsLabel_numWeaveWidth90 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveBias = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveHeigth = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveWidth = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveLength = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveType = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numWeaveShape = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numWeaveWidth90 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeaveBias = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeaveHeigth = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeaveWidth = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWeaveLength = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tabPage_Track = new ABB.Robotics.Tps.Windows.Forms.TabPage();
            this.tpsLabel_numTrackCurrent = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numTrackCurrent = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.comboBox_numTrackType = new ABB.Robotics.Tps.Windows.Forms.ComboBox();
            this.tpsLabel_numGainZ = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numTrackBias = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numPenetration = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numGainZ = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numTrackBias = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numGainY = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numPenetration = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numTrackType = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_numGainY = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_intGroupIndex = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numericUpDown_intGroupIndex = new ABB.Robotics.Tps.Windows.Forms.NumericUpDown();
            this.tpsLabel_intIndex = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numericUpDown_intIndex = new ABB.Robotics.Tps.Windows.Forms.NumericUpDown();
            this.pictureBox_Logo = new ABB.Robotics.Tps.Windows.Forms.PictureBox();
            this.tabControl_WeldingParameter.SuspendLayout();
            this.tabPage_Weld.SuspendLayout();
            this.tabPage_Weave.SuspendLayout();
            this.tabPage_Track.SuspendLayout();
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
            // tabControl_WeldingParameter
            // 
            this.tabControl_WeldingParameter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabControl_WeldingParameter.Controls.Add(this.tabPage_Weld);
            this.tabControl_WeldingParameter.Controls.Add(this.tabPage_Weave);
            this.tabControl_WeldingParameter.Controls.Add(this.tabPage_Track);
            this.tabControl_WeldingParameter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tabControl_WeldingParameter.ImageList = null;
            this.tabControl_WeldingParameter.Location = new System.Drawing.Point(0, 75);
            this.tabControl_WeldingParameter.Name = "tabControl_WeldingParameter";
            this.tabControl_WeldingParameter.SelectedIndex = 0;
            this.tabControl_WeldingParameter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabControl_WeldingParameter.Size = new System.Drawing.Size(640, 275);
            this.tabControl_WeldingParameter.TabIndex = 2;
            this.tabControl_WeldingParameter.TabPages.Add(this.tabPage_Weld);
            this.tabControl_WeldingParameter.TabPages.Add(this.tabPage_Weave);
            this.tabControl_WeldingParameter.TabPages.Add(this.tabPage_Track);
            // 
            // tabPage_Weld
            // 
            this.tabPage_Weld.Controls.Add(this.button_UpdateID);
            this.tabPage_Weld.Controls.Add(this.tpsLabel3);
            this.tabPage_Weld.Controls.Add(this.tpsLabel2);
            this.tabPage_Weld.Controls.Add(this.tpsLabel1);
            this.tabPage_Weld.Controls.Add(this.dataEditor_strRemark);
            this.tabPage_Weld.Controls.Add(this.dataEditor_strWeldProcedureID);
            this.tabPage_Weld.Controls.Add(this.tpsLabel_strWeldProcedureID);
            this.tabPage_Weld.Controls.Add(this.tpsLabel_numPostFlow);
            this.tabPage_Weld.Controls.Add(this.tpsLabel_strRemark);
            this.tabPage_Weld.Controls.Add(this.tpsLabel_numSche);
            this.tabPage_Weld.Controls.Add(this.tpsLabel_numPreFlow);
            this.tabPage_Weld.Controls.Add(this.tpsLabel_numWeldSpeed);
            this.tabPage_Weld.Controls.Add(this.numEditor_numPostFlow);
            this.tabPage_Weld.Controls.Add(this.numEditor_numSche);
            this.tabPage_Weld.Controls.Add(this.numEditor_numPreFlow);
            this.tabPage_Weld.Controls.Add(this.numEditor_numWeldSpeed);
            this.tabPage_Weld.ImageIndex = -1;
            this.tabPage_Weld.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Weld.Name = "tabPage_Weld";
            this.tabPage_Weld.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabPage_Weld.Size = new System.Drawing.Size(640, 235);
            this.tabPage_Weld.TabIndex = 1;
            this.tabPage_Weld.Text = "Weld";
            // 
            // button_UpdateID
            // 
            this.button_UpdateID.BackColor = System.Drawing.Color.White;
            this.button_UpdateID.BackgroundImage = null;
            this.button_UpdateID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_UpdateID.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_UpdateID.Image = null;
            this.button_UpdateID.Location = new System.Drawing.Point(301, 19);
            this.button_UpdateID.Name = "button_UpdateID";
            this.button_UpdateID.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_UpdateID.Size = new System.Drawing.Size(140, 42);
            this.button_UpdateID.TabIndex = 33;
            this.button_UpdateID.Text = "Update ID";
            this.button_UpdateID.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_UpdateID.Click += new System.EventHandler(this.button_UpdateID_Click);
            // 
            // tpsLabel3
            // 
            this.tpsLabel3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel3.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel3.Location = new System.Drawing.Point(581, 125);
            this.tpsLabel3.Multiline = true;
            this.tpsLabel3.Name = "tpsLabel3";
            this.tpsLabel3.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel3.Size = new System.Drawing.Size(32, 24);
            this.tpsLabel3.TabIndex = 32;
            this.tpsLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel3.Title = "s";
            // 
            // tpsLabel2
            // 
            this.tpsLabel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel2.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel2.Location = new System.Drawing.Point(581, 77);
            this.tpsLabel2.Multiline = true;
            this.tpsLabel2.Name = "tpsLabel2";
            this.tpsLabel2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel2.Size = new System.Drawing.Size(32, 24);
            this.tpsLabel2.TabIndex = 32;
            this.tpsLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel2.Title = "s";
            // 
            // tpsLabel1
            // 
            this.tpsLabel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel1.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel1.Location = new System.Drawing.Point(301, 77);
            this.tpsLabel1.Multiline = true;
            this.tpsLabel1.Name = "tpsLabel1";
            this.tpsLabel1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel1.Size = new System.Drawing.Size(61, 24);
            this.tpsLabel1.TabIndex = 31;
            this.tpsLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel1.Title = "mm/s";
            // 
            // dataEditor_strRemark
            // 
            this.dataEditor_strRemark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataEditor_strRemark.CaretVisible = false;
            this.dataEditor_strRemark.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.dataEditor_strRemark.Location = new System.Drawing.Point(130, 167);
            this.dataEditor_strRemark.Multiline = true;
            this.dataEditor_strRemark.Name = "dataEditor_strRemark";
            this.dataEditor_strRemark.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataEditor_strRemark.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.dataEditor_strRemark.SelectionLength = 0;
            this.dataEditor_strRemark.SelectionStart = 0;
            this.dataEditor_strRemark.SelectionVisible = false;
            this.dataEditor_strRemark.Size = new System.Drawing.Size(445, 30);
            this.dataEditor_strRemark.TabIndex = 30;
            this.dataEditor_strRemark.Text = "";
            this.dataEditor_strRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.dataEditor_strRemark.Click += new System.EventHandler(this.dataEditor_strRemark_Click);
            // 
            // dataEditor_strWeldProcedureID
            // 
            this.dataEditor_strWeldProcedureID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataEditor_strWeldProcedureID.CaretVisible = false;
            this.dataEditor_strWeldProcedureID.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.dataEditor_strWeldProcedureID.Location = new System.Drawing.Point(130, 25);
            this.dataEditor_strWeldProcedureID.Multiline = true;
            this.dataEditor_strWeldProcedureID.Name = "dataEditor_strWeldProcedureID";
            this.dataEditor_strWeldProcedureID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataEditor_strWeldProcedureID.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.dataEditor_strWeldProcedureID.SelectionLength = 0;
            this.dataEditor_strWeldProcedureID.SelectionStart = 0;
            this.dataEditor_strWeldProcedureID.SelectionVisible = false;
            this.dataEditor_strWeldProcedureID.Size = new System.Drawing.Size(160, 30);
            this.dataEditor_strWeldProcedureID.TabIndex = 30;
            this.dataEditor_strWeldProcedureID.Text = "";
            this.dataEditor_strWeldProcedureID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.dataEditor_strWeldProcedureID.Click += new System.EventHandler(this.dataEditor_strWeldProcedureID_Click);
            // 
            // tpsLabel_strWeldProcedureID
            // 
            this.tpsLabel_strWeldProcedureID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_strWeldProcedureID.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_strWeldProcedureID.Location = new System.Drawing.Point(12, 27);
            this.tpsLabel_strWeldProcedureID.Multiline = true;
            this.tpsLabel_strWeldProcedureID.Name = "tpsLabel_strWeldProcedureID";
            this.tpsLabel_strWeldProcedureID.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_strWeldProcedureID.Size = new System.Drawing.Size(94, 24);
            this.tpsLabel_strWeldProcedureID.TabIndex = 28;
            this.tpsLabel_strWeldProcedureID.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_strWeldProcedureID.Title = "ID";
            // 
            // tpsLabel_numPostFlow
            // 
            this.tpsLabel_numPostFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numPostFlow.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numPostFlow.Location = new System.Drawing.Point(378, 125);
            this.tpsLabel_numPostFlow.Multiline = true;
            this.tpsLabel_numPostFlow.Name = "tpsLabel_numPostFlow";
            this.tpsLabel_numPostFlow.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numPostFlow.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numPostFlow.TabIndex = 28;
            this.tpsLabel_numPostFlow.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numPostFlow.Title = "Post Flow";
            // 
            // tpsLabel_strRemark
            // 
            this.tpsLabel_strRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_strRemark.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_strRemark.Location = new System.Drawing.Point(12, 173);
            this.tpsLabel_strRemark.Multiline = true;
            this.tpsLabel_strRemark.Name = "tpsLabel_strRemark";
            this.tpsLabel_strRemark.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_strRemark.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_strRemark.TabIndex = 28;
            this.tpsLabel_strRemark.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_strRemark.Title = "Remark";
            // 
            // tpsLabel_numSche
            // 
            this.tpsLabel_numSche.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numSche.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numSche.Location = new System.Drawing.Point(12, 125);
            this.tpsLabel_numSche.Multiline = true;
            this.tpsLabel_numSche.Name = "tpsLabel_numSche";
            this.tpsLabel_numSche.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numSche.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numSche.TabIndex = 28;
            this.tpsLabel_numSche.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numSche.Title = "Sche";
            // 
            // tpsLabel_numPreFlow
            // 
            this.tpsLabel_numPreFlow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numPreFlow.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numPreFlow.Location = new System.Drawing.Point(378, 77);
            this.tpsLabel_numPreFlow.Multiline = true;
            this.tpsLabel_numPreFlow.Name = "tpsLabel_numPreFlow";
            this.tpsLabel_numPreFlow.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numPreFlow.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numPreFlow.TabIndex = 28;
            this.tpsLabel_numPreFlow.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numPreFlow.Title = "Pre Flow";
            // 
            // tpsLabel_numWeldSpeed
            // 
            this.tpsLabel_numWeldSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeldSpeed.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeldSpeed.Location = new System.Drawing.Point(12, 77);
            this.tpsLabel_numWeldSpeed.Multiline = true;
            this.tpsLabel_numWeldSpeed.Name = "tpsLabel_numWeldSpeed";
            this.tpsLabel_numWeldSpeed.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeldSpeed.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numWeldSpeed.TabIndex = 28;
            this.tpsLabel_numWeldSpeed.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeldSpeed.Title = "Weld Speed";
            // 
            // numEditor_numPostFlow
            // 
            this.numEditor_numPostFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numPostFlow.CaretVisible = false;
            this.numEditor_numPostFlow.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numPostFlow.Location = new System.Drawing.Point(487, 119);
            this.numEditor_numPostFlow.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numPostFlow.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numPostFlow.Multiline = true;
            this.numEditor_numPostFlow.Name = "numEditor_numPostFlow";
            this.numEditor_numPostFlow.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numPostFlow.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numPostFlow.SelectionLength = 0;
            this.numEditor_numPostFlow.SelectionStart = 0;
            this.numEditor_numPostFlow.SelectionVisible = false;
            this.numEditor_numPostFlow.Size = new System.Drawing.Size(88, 30);
            this.numEditor_numPostFlow.TabIndex = 29;
            this.numEditor_numPostFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numPostFlow.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numSche
            // 
            this.numEditor_numSche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numSche.CaretVisible = false;
            this.numEditor_numSche.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numSche.Location = new System.Drawing.Point(130, 119);
            this.numEditor_numSche.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numEditor_numSche.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numEditor_numSche.Multiline = true;
            this.numEditor_numSche.Name = "numEditor_numSche";
            this.numEditor_numSche.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numSche.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numSche.SelectionLength = 0;
            this.numEditor_numSche.SelectionStart = 0;
            this.numEditor_numSche.SelectionVisible = false;
            this.numEditor_numSche.ShowDecimalPoint = false;
            this.numEditor_numSche.Size = new System.Drawing.Size(160, 30);
            this.numEditor_numSche.TabIndex = 29;
            this.numEditor_numSche.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numSche.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numPreFlow
            // 
            this.numEditor_numPreFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numPreFlow.CaretVisible = false;
            this.numEditor_numPreFlow.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numPreFlow.Location = new System.Drawing.Point(487, 73);
            this.numEditor_numPreFlow.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numPreFlow.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numPreFlow.Multiline = true;
            this.numEditor_numPreFlow.Name = "numEditor_numPreFlow";
            this.numEditor_numPreFlow.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numPreFlow.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numPreFlow.SelectionLength = 0;
            this.numEditor_numPreFlow.SelectionStart = 0;
            this.numEditor_numPreFlow.SelectionVisible = false;
            this.numEditor_numPreFlow.Size = new System.Drawing.Size(88, 30);
            this.numEditor_numPreFlow.TabIndex = 29;
            this.numEditor_numPreFlow.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numPreFlow.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeldSpeed
            // 
            this.numEditor_numWeldSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeldSpeed.CaretVisible = false;
            this.numEditor_numWeldSpeed.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeldSpeed.Location = new System.Drawing.Point(130, 71);
            this.numEditor_numWeldSpeed.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeldSpeed.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeldSpeed.Multiline = true;
            this.numEditor_numWeldSpeed.Name = "numEditor_numWeldSpeed";
            this.numEditor_numWeldSpeed.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeldSpeed.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeldSpeed.SelectionLength = 0;
            this.numEditor_numWeldSpeed.SelectionStart = 0;
            this.numEditor_numWeldSpeed.SelectionVisible = false;
            this.numEditor_numWeldSpeed.Size = new System.Drawing.Size(160, 30);
            this.numEditor_numWeldSpeed.TabIndex = 29;
            this.numEditor_numWeldSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeldSpeed.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tabPage_Weave
            // 
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveOri);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveTilt);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveDir);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveOri);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveTilt);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveDir);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numDwellRight);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numDwellCenter);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numDwellLeft);
            this.tabPage_Weave.Controls.Add(this.numEditor_numDwellRight);
            this.tabPage_Weave.Controls.Add(this.numEditor_numDwellCenter);
            this.tabPage_Weave.Controls.Add(this.numEditor_numDwellLeft);
            this.tabPage_Weave.Controls.Add(this.comboBox_numWeaveType);
            this.tabPage_Weave.Controls.Add(this.comboBox_numWeaveShape);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveWidth90);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveBias);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveHeigth);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveWidth);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveLength);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveType);
            this.tabPage_Weave.Controls.Add(this.tpsLabel_numWeaveShape);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveWidth90);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveBias);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveHeigth);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveWidth);
            this.tabPage_Weave.Controls.Add(this.numEditor_numWeaveLength);
            this.tabPage_Weave.ImageIndex = -1;
            this.tabPage_Weave.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Weave.Name = "tabPage_Weave";
            this.tabPage_Weave.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabPage_Weave.Size = new System.Drawing.Size(640, 235);
            this.tabPage_Weave.TabIndex = 2;
            this.tabPage_Weave.Text = "Weave";
            // 
            // tpsLabel_numWeaveOri
            // 
            this.tpsLabel_numWeaveOri.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveOri.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveOri.Location = new System.Drawing.Point(222, 143);
            this.tpsLabel_numWeaveOri.Multiline = true;
            this.tpsLabel_numWeaveOri.Name = "tpsLabel_numWeaveOri";
            this.tpsLabel_numWeaveOri.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveOri.Size = new System.Drawing.Size(45, 24);
            this.tpsLabel_numWeaveOri.TabIndex = 45;
            this.tpsLabel_numWeaveOri.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveOri.Title = "Ori";
            // 
            // tpsLabel_numWeaveTilt
            // 
            this.tpsLabel_numWeaveTilt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveTilt.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveTilt.Location = new System.Drawing.Point(222, 101);
            this.tpsLabel_numWeaveTilt.Multiline = true;
            this.tpsLabel_numWeaveTilt.Name = "tpsLabel_numWeaveTilt";
            this.tpsLabel_numWeaveTilt.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveTilt.Size = new System.Drawing.Size(45, 24);
            this.tpsLabel_numWeaveTilt.TabIndex = 44;
            this.tpsLabel_numWeaveTilt.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveTilt.Title = "Tilt";
            // 
            // tpsLabel_numWeaveDir
            // 
            this.tpsLabel_numWeaveDir.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveDir.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveDir.Location = new System.Drawing.Point(222, 59);
            this.tpsLabel_numWeaveDir.Multiline = true;
            this.tpsLabel_numWeaveDir.Name = "tpsLabel_numWeaveDir";
            this.tpsLabel_numWeaveDir.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveDir.Size = new System.Drawing.Size(45, 24);
            this.tpsLabel_numWeaveDir.TabIndex = 43;
            this.tpsLabel_numWeaveDir.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveDir.Title = "Dir";
            // 
            // numEditor_numWeaveOri
            // 
            this.numEditor_numWeaveOri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveOri.CaretVisible = false;
            this.numEditor_numWeaveOri.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveOri.Location = new System.Drawing.Point(273, 143);
            this.numEditor_numWeaveOri.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveOri.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveOri.Multiline = true;
            this.numEditor_numWeaveOri.Name = "numEditor_numWeaveOri";
            this.numEditor_numWeaveOri.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveOri.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveOri.SelectionLength = 0;
            this.numEditor_numWeaveOri.SelectionStart = 0;
            this.numEditor_numWeaveOri.SelectionVisible = false;
            this.numEditor_numWeaveOri.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveOri.TabIndex = 48;
            this.numEditor_numWeaveOri.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveOri.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeaveTilt
            // 
            this.numEditor_numWeaveTilt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveTilt.CaretVisible = false;
            this.numEditor_numWeaveTilt.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveTilt.Location = new System.Drawing.Point(273, 101);
            this.numEditor_numWeaveTilt.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveTilt.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveTilt.Multiline = true;
            this.numEditor_numWeaveTilt.Name = "numEditor_numWeaveTilt";
            this.numEditor_numWeaveTilt.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveTilt.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveTilt.SelectionLength = 0;
            this.numEditor_numWeaveTilt.SelectionStart = 0;
            this.numEditor_numWeaveTilt.SelectionVisible = false;
            this.numEditor_numWeaveTilt.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveTilt.TabIndex = 47;
            this.numEditor_numWeaveTilt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveTilt.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeaveDir
            // 
            this.numEditor_numWeaveDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveDir.CaretVisible = false;
            this.numEditor_numWeaveDir.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveDir.Location = new System.Drawing.Point(273, 59);
            this.numEditor_numWeaveDir.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveDir.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveDir.Multiline = true;
            this.numEditor_numWeaveDir.Name = "numEditor_numWeaveDir";
            this.numEditor_numWeaveDir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveDir.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveDir.SelectionLength = 0;
            this.numEditor_numWeaveDir.SelectionStart = 0;
            this.numEditor_numWeaveDir.SelectionVisible = false;
            this.numEditor_numWeaveDir.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveDir.TabIndex = 46;
            this.numEditor_numWeaveDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveDir.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numDwellRight
            // 
            this.tpsLabel_numDwellRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDwellRight.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDwellRight.Location = new System.Drawing.Point(398, 143);
            this.tpsLabel_numDwellRight.Multiline = true;
            this.tpsLabel_numDwellRight.Name = "tpsLabel_numDwellRight";
            this.tpsLabel_numDwellRight.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDwellRight.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numDwellRight.TabIndex = 39;
            this.tpsLabel_numDwellRight.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDwellRight.Title = "Dwell Right";
            // 
            // tpsLabel_numDwellCenter
            // 
            this.tpsLabel_numDwellCenter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDwellCenter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDwellCenter.Location = new System.Drawing.Point(398, 101);
            this.tpsLabel_numDwellCenter.Multiline = true;
            this.tpsLabel_numDwellCenter.Name = "tpsLabel_numDwellCenter";
            this.tpsLabel_numDwellCenter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDwellCenter.Size = new System.Drawing.Size(123, 24);
            this.tpsLabel_numDwellCenter.TabIndex = 38;
            this.tpsLabel_numDwellCenter.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDwellCenter.Title = "Dwell Center";
            // 
            // tpsLabel_numDwellLeft
            // 
            this.tpsLabel_numDwellLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDwellLeft.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDwellLeft.Location = new System.Drawing.Point(398, 59);
            this.tpsLabel_numDwellLeft.Multiline = true;
            this.tpsLabel_numDwellLeft.Name = "tpsLabel_numDwellLeft";
            this.tpsLabel_numDwellLeft.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDwellLeft.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numDwellLeft.TabIndex = 37;
            this.tpsLabel_numDwellLeft.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDwellLeft.Title = "Dwell Left";
            // 
            // numEditor_numDwellRight
            // 
            this.numEditor_numDwellRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numDwellRight.CaretVisible = false;
            this.numEditor_numDwellRight.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numDwellRight.Location = new System.Drawing.Point(527, 137);
            this.numEditor_numDwellRight.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numDwellRight.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numDwellRight.Multiline = true;
            this.numEditor_numDwellRight.Name = "numEditor_numDwellRight";
            this.numEditor_numDwellRight.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numDwellRight.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numDwellRight.SelectionLength = 0;
            this.numEditor_numDwellRight.SelectionStart = 0;
            this.numEditor_numDwellRight.SelectionVisible = false;
            this.numEditor_numDwellRight.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numDwellRight.TabIndex = 42;
            this.numEditor_numDwellRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numDwellRight.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numDwellCenter
            // 
            this.numEditor_numDwellCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numDwellCenter.CaretVisible = false;
            this.numEditor_numDwellCenter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numDwellCenter.Location = new System.Drawing.Point(527, 95);
            this.numEditor_numDwellCenter.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numDwellCenter.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numDwellCenter.Multiline = true;
            this.numEditor_numDwellCenter.Name = "numEditor_numDwellCenter";
            this.numEditor_numDwellCenter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numDwellCenter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numDwellCenter.SelectionLength = 0;
            this.numEditor_numDwellCenter.SelectionStart = 0;
            this.numEditor_numDwellCenter.SelectionVisible = false;
            this.numEditor_numDwellCenter.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numDwellCenter.TabIndex = 41;
            this.numEditor_numDwellCenter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numDwellCenter.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numDwellLeft
            // 
            this.numEditor_numDwellLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numDwellLeft.CaretVisible = false;
            this.numEditor_numDwellLeft.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numDwellLeft.Location = new System.Drawing.Point(527, 59);
            this.numEditor_numDwellLeft.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numDwellLeft.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numDwellLeft.Multiline = true;
            this.numEditor_numDwellLeft.Name = "numEditor_numDwellLeft";
            this.numEditor_numDwellLeft.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numDwellLeft.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numDwellLeft.SelectionLength = 0;
            this.numEditor_numDwellLeft.SelectionStart = 0;
            this.numEditor_numDwellLeft.SelectionVisible = false;
            this.numEditor_numDwellLeft.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numDwellLeft.TabIndex = 40;
            this.numEditor_numDwellLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numDwellLeft.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // comboBox_numWeaveType
            // 
            this.comboBox_numWeaveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numWeaveType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numWeaveType.Items.Add("Geometric (0)");
            this.comboBox_numWeaveType.Items.Add("Geometric Wrist (1)");
            this.comboBox_numWeaveType.Items.Add("Frequency Geometric (2)");
            this.comboBox_numWeaveType.Items.Add("Frequency Wrist (3)");
            this.comboBox_numWeaveType.Location = new System.Drawing.Point(412, 17);
            this.comboBox_numWeaveType.Name = "comboBox_numWeaveType";
            this.comboBox_numWeaveType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numWeaveType.Size = new System.Drawing.Size(205, 30);
            this.comboBox_numWeaveType.TabIndex = 36;
            this.comboBox_numWeaveType.Text = "comboBox1";
            this.comboBox_numWeaveType.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // comboBox_numWeaveShape
            // 
            this.comboBox_numWeaveShape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numWeaveShape.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numWeaveShape.Items.Add("No Weaving (0)");
            this.comboBox_numWeaveShape.Items.Add("Zig-zag (1)");
            this.comboBox_numWeaveShape.Items.Add("V-shaped (2)");
            this.comboBox_numWeaveShape.Items.Add("Triangular (3)");
            this.comboBox_numWeaveShape.Items.Add("Circular (4)");
            this.comboBox_numWeaveShape.Location = new System.Drawing.Point(97, 17);
            this.comboBox_numWeaveShape.Name = "comboBox_numWeaveShape";
            this.comboBox_numWeaveShape.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numWeaveShape.Size = new System.Drawing.Size(207, 30);
            this.comboBox_numWeaveShape.TabIndex = 36;
            this.comboBox_numWeaveShape.Text = "comboBox1";
            this.comboBox_numWeaveShape.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numWeaveWidth90
            // 
            this.tpsLabel_numWeaveWidth90.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveWidth90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveWidth90.Location = new System.Drawing.Point(14, 143);
            this.tpsLabel_numWeaveWidth90.Multiline = true;
            this.tpsLabel_numWeaveWidth90.Name = "tpsLabel_numWeaveWidth90";
            this.tpsLabel_numWeaveWidth90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveWidth90.Size = new System.Drawing.Size(77, 24);
            this.tpsLabel_numWeaveWidth90.TabIndex = 32;
            this.tpsLabel_numWeaveWidth90.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveWidth90.Title = "Width90";
            // 
            // tpsLabel_numWeaveBias
            // 
            this.tpsLabel_numWeaveBias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveBias.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveBias.Location = new System.Drawing.Point(398, 185);
            this.tpsLabel_numWeaveBias.Multiline = true;
            this.tpsLabel_numWeaveBias.Name = "tpsLabel_numWeaveBias";
            this.tpsLabel_numWeaveBias.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveBias.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numWeaveBias.TabIndex = 32;
            this.tpsLabel_numWeaveBias.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveBias.Title = "Bias";
            // 
            // tpsLabel_numWeaveHeigth
            // 
            this.tpsLabel_numWeaveHeigth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveHeigth.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveHeigth.Location = new System.Drawing.Point(14, 185);
            this.tpsLabel_numWeaveHeigth.Multiline = true;
            this.tpsLabel_numWeaveHeigth.Name = "tpsLabel_numWeaveHeigth";
            this.tpsLabel_numWeaveHeigth.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveHeigth.Size = new System.Drawing.Size(77, 24);
            this.tpsLabel_numWeaveHeigth.TabIndex = 32;
            this.tpsLabel_numWeaveHeigth.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveHeigth.Title = "Heigth";
            // 
            // tpsLabel_numWeaveWidth
            // 
            this.tpsLabel_numWeaveWidth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveWidth.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveWidth.Location = new System.Drawing.Point(14, 101);
            this.tpsLabel_numWeaveWidth.Multiline = true;
            this.tpsLabel_numWeaveWidth.Name = "tpsLabel_numWeaveWidth";
            this.tpsLabel_numWeaveWidth.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveWidth.Size = new System.Drawing.Size(77, 24);
            this.tpsLabel_numWeaveWidth.TabIndex = 32;
            this.tpsLabel_numWeaveWidth.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveWidth.Title = "Width";
            // 
            // tpsLabel_numWeaveLength
            // 
            this.tpsLabel_numWeaveLength.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveLength.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveLength.Location = new System.Drawing.Point(14, 59);
            this.tpsLabel_numWeaveLength.Multiline = true;
            this.tpsLabel_numWeaveLength.Name = "tpsLabel_numWeaveLength";
            this.tpsLabel_numWeaveLength.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveLength.Size = new System.Drawing.Size(77, 24);
            this.tpsLabel_numWeaveLength.TabIndex = 32;
            this.tpsLabel_numWeaveLength.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveLength.Title = "Length";
            // 
            // tpsLabel_numWeaveType
            // 
            this.tpsLabel_numWeaveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveType.Location = new System.Drawing.Point(341, 19);
            this.tpsLabel_numWeaveType.Multiline = true;
            this.tpsLabel_numWeaveType.Name = "tpsLabel_numWeaveType";
            this.tpsLabel_numWeaveType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveType.Size = new System.Drawing.Size(65, 24);
            this.tpsLabel_numWeaveType.TabIndex = 31;
            this.tpsLabel_numWeaveType.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveType.Title = "Type";
            // 
            // tpsLabel_numWeaveShape
            // 
            this.tpsLabel_numWeaveShape.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWeaveShape.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWeaveShape.Location = new System.Drawing.Point(14, 23);
            this.tpsLabel_numWeaveShape.Multiline = true;
            this.tpsLabel_numWeaveShape.Name = "tpsLabel_numWeaveShape";
            this.tpsLabel_numWeaveShape.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWeaveShape.Size = new System.Drawing.Size(77, 24);
            this.tpsLabel_numWeaveShape.TabIndex = 30;
            this.tpsLabel_numWeaveShape.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWeaveShape.Title = "Shape";
            // 
            // numEditor_numWeaveWidth90
            // 
            this.numEditor_numWeaveWidth90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveWidth90.CaretVisible = false;
            this.numEditor_numWeaveWidth90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveWidth90.Location = new System.Drawing.Point(97, 143);
            this.numEditor_numWeaveWidth90.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveWidth90.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveWidth90.Multiline = true;
            this.numEditor_numWeaveWidth90.Name = "numEditor_numWeaveWidth90";
            this.numEditor_numWeaveWidth90.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveWidth90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveWidth90.SelectionLength = 0;
            this.numEditor_numWeaveWidth90.SelectionStart = 0;
            this.numEditor_numWeaveWidth90.SelectionVisible = false;
            this.numEditor_numWeaveWidth90.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveWidth90.TabIndex = 35;
            this.numEditor_numWeaveWidth90.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveWidth90.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeaveBias
            // 
            this.numEditor_numWeaveBias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveBias.CaretVisible = false;
            this.numEditor_numWeaveBias.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveBias.Location = new System.Drawing.Point(527, 179);
            this.numEditor_numWeaveBias.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveBias.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveBias.Multiline = true;
            this.numEditor_numWeaveBias.Name = "numEditor_numWeaveBias";
            this.numEditor_numWeaveBias.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveBias.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveBias.SelectionLength = 0;
            this.numEditor_numWeaveBias.SelectionStart = 0;
            this.numEditor_numWeaveBias.SelectionVisible = false;
            this.numEditor_numWeaveBias.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveBias.TabIndex = 35;
            this.numEditor_numWeaveBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveBias.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeaveHeigth
            // 
            this.numEditor_numWeaveHeigth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveHeigth.CaretVisible = false;
            this.numEditor_numWeaveHeigth.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveHeigth.Location = new System.Drawing.Point(97, 185);
            this.numEditor_numWeaveHeigth.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveHeigth.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveHeigth.Multiline = true;
            this.numEditor_numWeaveHeigth.Name = "numEditor_numWeaveHeigth";
            this.numEditor_numWeaveHeigth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveHeigth.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveHeigth.SelectionLength = 0;
            this.numEditor_numWeaveHeigth.SelectionStart = 0;
            this.numEditor_numWeaveHeigth.SelectionVisible = false;
            this.numEditor_numWeaveHeigth.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveHeigth.TabIndex = 35;
            this.numEditor_numWeaveHeigth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveHeigth.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeaveWidth
            // 
            this.numEditor_numWeaveWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveWidth.CaretVisible = false;
            this.numEditor_numWeaveWidth.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveWidth.Location = new System.Drawing.Point(97, 101);
            this.numEditor_numWeaveWidth.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveWidth.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveWidth.Multiline = true;
            this.numEditor_numWeaveWidth.Name = "numEditor_numWeaveWidth";
            this.numEditor_numWeaveWidth.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveWidth.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveWidth.SelectionLength = 0;
            this.numEditor_numWeaveWidth.SelectionStart = 0;
            this.numEditor_numWeaveWidth.SelectionVisible = false;
            this.numEditor_numWeaveWidth.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveWidth.TabIndex = 35;
            this.numEditor_numWeaveWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveWidth.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numWeaveLength
            // 
            this.numEditor_numWeaveLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWeaveLength.CaretVisible = false;
            this.numEditor_numWeaveLength.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWeaveLength.Location = new System.Drawing.Point(97, 59);
            this.numEditor_numWeaveLength.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWeaveLength.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWeaveLength.Multiline = true;
            this.numEditor_numWeaveLength.Name = "numEditor_numWeaveLength";
            this.numEditor_numWeaveLength.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWeaveLength.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWeaveLength.SelectionLength = 0;
            this.numEditor_numWeaveLength.SelectionStart = 0;
            this.numEditor_numWeaveLength.SelectionVisible = false;
            this.numEditor_numWeaveLength.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numWeaveLength.TabIndex = 35;
            this.numEditor_numWeaveLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWeaveLength.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tabPage_Track
            // 
            this.tabPage_Track.Controls.Add(this.tpsLabel_numTrackCurrent);
            this.tabPage_Track.Controls.Add(this.numEditor_numTrackCurrent);
            this.tabPage_Track.Controls.Add(this.comboBox_numTrackType);
            this.tabPage_Track.Controls.Add(this.tpsLabel_numGainZ);
            this.tabPage_Track.Controls.Add(this.tpsLabel_numTrackBias);
            this.tabPage_Track.Controls.Add(this.tpsLabel_numPenetration);
            this.tabPage_Track.Controls.Add(this.numEditor_numGainZ);
            this.tabPage_Track.Controls.Add(this.numEditor_numTrackBias);
            this.tabPage_Track.Controls.Add(this.tpsLabel_numGainY);
            this.tabPage_Track.Controls.Add(this.numEditor_numPenetration);
            this.tabPage_Track.Controls.Add(this.tpsLabel_numTrackType);
            this.tabPage_Track.Controls.Add(this.numEditor_numGainY);
            this.tabPage_Track.ImageIndex = -1;
            this.tabPage_Track.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Track.Name = "tabPage_Track";
            this.tabPage_Track.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tabPage_Track.Size = new System.Drawing.Size(640, 235);
            this.tabPage_Track.TabIndex = 3;
            this.tabPage_Track.Text = "Track";
            // 
            // tpsLabel_numTrackCurrent
            // 
            this.tpsLabel_numTrackCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numTrackCurrent.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numTrackCurrent.Location = new System.Drawing.Point(28, 65);
            this.tpsLabel_numTrackCurrent.Multiline = true;
            this.tpsLabel_numTrackCurrent.Name = "tpsLabel_numTrackCurrent";
            this.tpsLabel_numTrackCurrent.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numTrackCurrent.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numTrackCurrent.TabIndex = 41;
            this.tpsLabel_numTrackCurrent.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numTrackCurrent.Title = "Current";
            // 
            // numEditor_numTrackCurrent
            // 
            this.numEditor_numTrackCurrent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numTrackCurrent.CaretVisible = false;
            this.numEditor_numTrackCurrent.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numTrackCurrent.Location = new System.Drawing.Point(137, 65);
            this.numEditor_numTrackCurrent.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numTrackCurrent.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numTrackCurrent.Multiline = true;
            this.numEditor_numTrackCurrent.Name = "numEditor_numTrackCurrent";
            this.numEditor_numTrackCurrent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numTrackCurrent.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numTrackCurrent.SelectionLength = 0;
            this.numEditor_numTrackCurrent.SelectionStart = 0;
            this.numEditor_numTrackCurrent.SelectionVisible = false;
            this.numEditor_numTrackCurrent.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numTrackCurrent.TabIndex = 42;
            this.numEditor_numTrackCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numTrackCurrent.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // comboBox_numTrackType
            // 
            this.comboBox_numTrackType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comboBox_numTrackType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.comboBox_numTrackType.Items.Add("Centerline Auto Volt ref (0)");
            this.comboBox_numTrackType.Location = new System.Drawing.Point(137, 19);
            this.comboBox_numTrackType.Name = "comboBox_numTrackType";
            this.comboBox_numTrackType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.comboBox_numTrackType.Size = new System.Drawing.Size(411, 30);
            this.comboBox_numTrackType.TabIndex = 40;
            this.comboBox_numTrackType.Text = "comboBox3";
            this.comboBox_numTrackType.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numGainZ
            // 
            this.tpsLabel_numGainZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numGainZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numGainZ.Location = new System.Drawing.Point(28, 155);
            this.tpsLabel_numGainZ.Multiline = true;
            this.tpsLabel_numGainZ.Name = "tpsLabel_numGainZ";
            this.tpsLabel_numGainZ.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numGainZ.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numGainZ.TabIndex = 38;
            this.tpsLabel_numGainZ.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numGainZ.Title = "Gain Z";
            // 
            // tpsLabel_numTrackBias
            // 
            this.tpsLabel_numTrackBias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numTrackBias.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numTrackBias.Location = new System.Drawing.Point(359, 107);
            this.tpsLabel_numTrackBias.Multiline = true;
            this.tpsLabel_numTrackBias.Name = "tpsLabel_numTrackBias";
            this.tpsLabel_numTrackBias.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numTrackBias.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numTrackBias.TabIndex = 38;
            this.tpsLabel_numTrackBias.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numTrackBias.Title = "Bias";
            // 
            // tpsLabel_numPenetration
            // 
            this.tpsLabel_numPenetration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numPenetration.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numPenetration.Location = new System.Drawing.Point(359, 65);
            this.tpsLabel_numPenetration.Multiline = true;
            this.tpsLabel_numPenetration.Name = "tpsLabel_numPenetration";
            this.tpsLabel_numPenetration.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numPenetration.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numPenetration.TabIndex = 38;
            this.tpsLabel_numPenetration.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numPenetration.Title = "Penetration";
            // 
            // numEditor_numGainZ
            // 
            this.numEditor_numGainZ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numGainZ.CaretVisible = false;
            this.numEditor_numGainZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numGainZ.Location = new System.Drawing.Point(137, 155);
            this.numEditor_numGainZ.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numGainZ.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numGainZ.Multiline = true;
            this.numEditor_numGainZ.Name = "numEditor_numGainZ";
            this.numEditor_numGainZ.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numGainZ.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numGainZ.SelectionLength = 0;
            this.numEditor_numGainZ.SelectionStart = 0;
            this.numEditor_numGainZ.SelectionVisible = false;
            this.numEditor_numGainZ.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numGainZ.TabIndex = 39;
            this.numEditor_numGainZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numGainZ.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_numTrackBias
            // 
            this.numEditor_numTrackBias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numTrackBias.CaretVisible = false;
            this.numEditor_numTrackBias.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numTrackBias.Location = new System.Drawing.Point(468, 107);
            this.numEditor_numTrackBias.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numTrackBias.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numTrackBias.Multiline = true;
            this.numEditor_numTrackBias.Name = "numEditor_numTrackBias";
            this.numEditor_numTrackBias.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numTrackBias.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numTrackBias.SelectionLength = 0;
            this.numEditor_numTrackBias.SelectionStart = 0;
            this.numEditor_numTrackBias.SelectionVisible = false;
            this.numEditor_numTrackBias.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numTrackBias.TabIndex = 39;
            this.numEditor_numTrackBias.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numTrackBias.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numGainY
            // 
            this.tpsLabel_numGainY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numGainY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numGainY.Location = new System.Drawing.Point(28, 113);
            this.tpsLabel_numGainY.Multiline = true;
            this.tpsLabel_numGainY.Name = "tpsLabel_numGainY";
            this.tpsLabel_numGainY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numGainY.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numGainY.TabIndex = 38;
            this.tpsLabel_numGainY.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numGainY.Title = "Gain Y";
            // 
            // numEditor_numPenetration
            // 
            this.numEditor_numPenetration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numPenetration.CaretVisible = false;
            this.numEditor_numPenetration.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numPenetration.Location = new System.Drawing.Point(468, 59);
            this.numEditor_numPenetration.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numPenetration.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numPenetration.Multiline = true;
            this.numEditor_numPenetration.Name = "numEditor_numPenetration";
            this.numEditor_numPenetration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numPenetration.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numPenetration.SelectionLength = 0;
            this.numEditor_numPenetration.SelectionStart = 0;
            this.numEditor_numPenetration.SelectionVisible = false;
            this.numEditor_numPenetration.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numPenetration.TabIndex = 39;
            this.numEditor_numPenetration.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numPenetration.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numTrackType
            // 
            this.tpsLabel_numTrackType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numTrackType.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numTrackType.Location = new System.Drawing.Point(28, 23);
            this.tpsLabel_numTrackType.Multiline = true;
            this.tpsLabel_numTrackType.Name = "tpsLabel_numTrackType";
            this.tpsLabel_numTrackType.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numTrackType.Size = new System.Drawing.Size(103, 24);
            this.tpsLabel_numTrackType.TabIndex = 37;
            this.tpsLabel_numTrackType.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numTrackType.Title = "Type";
            // 
            // numEditor_numGainY
            // 
            this.numEditor_numGainY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numGainY.CaretVisible = false;
            this.numEditor_numGainY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numGainY.Location = new System.Drawing.Point(137, 113);
            this.numEditor_numGainY.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numGainY.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numGainY.Multiline = true;
            this.numEditor_numGainY.Name = "numEditor_numGainY";
            this.numEditor_numGainY.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numGainY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numGainY.SelectionLength = 0;
            this.numEditor_numGainY.SelectionStart = 0;
            this.numEditor_numGainY.SelectionVisible = false;
            this.numEditor_numGainY.Size = new System.Drawing.Size(80, 30);
            this.numEditor_numGainY.TabIndex = 39;
            this.numEditor_numGainY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numGainY.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_intGroupIndex
            // 
            this.tpsLabel_intGroupIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_intGroupIndex.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_intGroupIndex.Location = new System.Drawing.Point(28, 29);
            this.tpsLabel_intGroupIndex.Multiline = true;
            this.tpsLabel_intGroupIndex.Name = "tpsLabel_intGroupIndex";
            this.tpsLabel_intGroupIndex.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_intGroupIndex.Size = new System.Drawing.Size(89, 24);
            this.tpsLabel_intGroupIndex.TabIndex = 3;
            this.tpsLabel_intGroupIndex.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_intGroupIndex.Title = "Group";
            // 
            // numericUpDown_intGroupIndex
            // 
            this.numericUpDown_intGroupIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_intGroupIndex.CaretVisible = false;
            this.numericUpDown_intGroupIndex.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numericUpDown_intGroupIndex.Location = new System.Drawing.Point(123, 29);
            this.numericUpDown_intGroupIndex.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_intGroupIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intGroupIndex.Multiline = true;
            this.numericUpDown_intGroupIndex.Name = "numericUpDown_intGroupIndex";
            this.numericUpDown_intGroupIndex.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericUpDown_intGroupIndex.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numericUpDown_intGroupIndex.SelectionLength = 0;
            this.numericUpDown_intGroupIndex.SelectionStart = 0;
            this.numericUpDown_intGroupIndex.SelectionVisible = false;
            this.numericUpDown_intGroupIndex.Size = new System.Drawing.Size(132, 40);
            this.numericUpDown_intGroupIndex.TabIndex = 4;
            this.numericUpDown_intGroupIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericUpDown_intGroupIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intGroupIndex.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.numericUpDown_intGroupIndex_PropertyChanged);
            // 
            // tpsLabel_intIndex
            // 
            this.tpsLabel_intIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_intIndex.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_intIndex.Location = new System.Drawing.Point(301, 29);
            this.tpsLabel_intIndex.Multiline = true;
            this.tpsLabel_intIndex.Name = "tpsLabel_intIndex";
            this.tpsLabel_intIndex.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_intIndex.Size = new System.Drawing.Size(88, 24);
            this.tpsLabel_intIndex.TabIndex = 3;
            this.tpsLabel_intIndex.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_intIndex.Title = "Index";
            // 
            // numericUpDown_intIndex
            // 
            this.numericUpDown_intIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_intIndex.CaretVisible = false;
            this.numericUpDown_intIndex.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numericUpDown_intIndex.Location = new System.Drawing.Point(398, 29);
            this.numericUpDown_intIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intIndex.Multiline = true;
            this.numericUpDown_intIndex.Name = "numericUpDown_intIndex";
            this.numericUpDown_intIndex.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericUpDown_intIndex.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numericUpDown_intIndex.SelectionLength = 0;
            this.numericUpDown_intIndex.SelectionStart = 0;
            this.numericUpDown_intIndex.SelectionVisible = false;
            this.numericUpDown_intIndex.Size = new System.Drawing.Size(127, 40);
            this.numericUpDown_intIndex.TabIndex = 4;
            this.numericUpDown_intIndex.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericUpDown_intIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intIndex.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.numericUpDown_intIndex_PropertyChanged);
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pictureBox_Logo.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.pictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logo.Image")));
            this.pictureBox_Logo.Location = new System.Drawing.Point(531, 0);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.pictureBox_Logo.Size = new System.Drawing.Size(108, 32);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 6;
            // 
            // TpsFormWeldingParameter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.tabControl_WeldingParameter);
            this.Controls.Add(this.numericUpDown_intGroupIndex);
            this.Controls.Add(this.numericUpDown_intIndex);
            this.Controls.Add(this.tpsLabel_intIndex);
            this.Controls.Add(this.tpsLabel_intGroupIndex);
            // 
            // 
            // 
            this.MainMenu.MenuItems.Add(this.menuItem_Refresh);
            this.MainMenu.MenuItems.Add(this.menuItem_Apply);
            this.MainMenu.MenuItems.Add(this.menuItem_Close);
            this.Size = new System.Drawing.Size(640, 390);
            this.Text = "Welding Parameters";
            this.Controls.SetChildIndex(this.tpsLabel_intGroupIndex, 0);
            this.Controls.SetChildIndex(this.tpsLabel_intIndex, 0);
            this.Controls.SetChildIndex(this.numericUpDown_intIndex, 0);
            this.Controls.SetChildIndex(this.numericUpDown_intGroupIndex, 0);
            this.Controls.SetChildIndex(this.tabControl_WeldingParameter, 0);
            this.Controls.SetChildIndex(this.pictureBox_Logo, 0);
            this.tabControl_WeldingParameter.ResumeLayout(false);
            this.tabPage_Weld.ResumeLayout(false);
            this.tabPage_Weave.ResumeLayout(false);
            this.tabPage_Track.ResumeLayout(false);
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
                this.weldProcedure.RefreshData(this.rwSystem, Convert.ToInt32( this.numericUpDown_intGroupIndex.Value), Convert.ToInt32(this.numericUpDown_intIndex.Value));
                this.dataEditor_strWeldProcedureID.Text = this.weldProcedure.strWeldProcedureID;
                this.numEditor_numWeldSpeed.Value = this.weldProcedure.numWeldSpeed;
                this.numEditor_numPreFlow.Value = this.weldProcedure.numPreFlow;
                this.numEditor_numSche.Value = this.weldProcedure.numSche;
                this.numEditor_numTrackCurrent.Value = this.weldProcedure.numTrackCurrent;
                this.numEditor_numPostFlow.Value = this.weldProcedure.numPostFlow;

                this.comboBox_numWeaveShape.SelectedIndex = this.weldProcedure.numWeaveShape;
                this.comboBox_numWeaveType.SelectedIndex = this.weldProcedure.numWeaveType;
                this.numEditor_numWeaveLength.Value = this.weldProcedure.numWeaveLength;
                this.numEditor_numWeaveWidth.Value = this.weldProcedure.numWeaveWidth;
                this.numEditor_numWeaveHeigth.Value = this.weldProcedure.numWeaveHeigth;
                this.numEditor_numDwellLeft.Value = this.weldProcedure.numDwellLeft;
                this.numEditor_numDwellCenter.Value = this.weldProcedure.numDwellCenter;
                this.numEditor_numDwellRight.Value = this.weldProcedure.numDwellRight;
                this.numEditor_numWeaveDir.Value = this.weldProcedure.numWeaveDir;
                this.numEditor_numWeaveTilt.Value = this.weldProcedure.numWeaveTilt;
                this.numEditor_numWeaveOri.Value = this.weldProcedure.numWeaveOri;
                this.numEditor_numWeaveBias.Value = this.weldProcedure.numWeaveBias;

                this.comboBox_numTrackType.SelectedIndex = this.weldProcedure.numTrackType;
                this.numEditor_numGainY.Value = this.weldProcedure.numGainY;
                this.numEditor_numGainZ.Value = this.weldProcedure.numGainZ;
                this.numEditor_numPenetration.Value = this.weldProcedure.numPenetration;
                this.numEditor_numTrackBias.Value = this.weldProcedure.numTrackBias;
                this.numEditor_numWeaveWidth90.Value = this.weldProcedure.numWeaveWidth90;

                this.dataEditor_strRemark.Text = this.weldProcedure.strRemark;
                             
                this.menuItem_Apply.Enabled = false;
            }
            catch (Exception ex)
            {
                GTPUMessageBox.Show(this.Parent.Parent, null
                    , string.Format("An unexpected error occurred when reading RAPID data 'rweldProcedure'. Message {0}", ex.ToString())
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
                this.weldProcedure.strWeldProcedureID = this.dataEditor_strWeldProcedureID.Text;
                this.weldProcedure.numWeldSpeed = this.numEditor_numWeldSpeed.Value;
                this.weldProcedure.numPreFlow = this.numEditor_numPreFlow.Value;
                this.weldProcedure.numSche = this.numEditor_numSche.Value;
                this.weldProcedure.numTrackCurrent = this.numEditor_numTrackCurrent.Value;
                this.weldProcedure.numPostFlow = this.numEditor_numPostFlow.Value;

                this.weldProcedure.numWeaveShape = this.comboBox_numWeaveShape.SelectedIndex;
                this.weldProcedure.numWeaveType = this.comboBox_numWeaveType.SelectedIndex;

                this.weldProcedure.numWeaveLength = this.numEditor_numWeaveLength.Value;
                this.weldProcedure.numWeaveWidth = this.numEditor_numWeaveWidth.Value;
                this.weldProcedure.numWeaveHeigth = this.numEditor_numWeaveHeigth.Value;
                this.weldProcedure.numDwellLeft = this.numEditor_numDwellLeft.Value;
                this.weldProcedure.numDwellCenter = this.numEditor_numDwellCenter.Value;
                this.weldProcedure.numDwellRight = this.numEditor_numDwellRight.Value;
                this.weldProcedure.numWeaveDir = this.numEditor_numWeaveDir.Value;
                this.weldProcedure.numWeaveTilt = this.numEditor_numWeaveTilt.Value;
                this.weldProcedure.numWeaveOri = this.numEditor_numWeaveOri.Value;
                this.weldProcedure.numWeaveBias = this.numEditor_numWeaveBias.Value;

                this.weldProcedure.numTrackType = this.comboBox_numTrackType.SelectedIndex;
                this.weldProcedure.numGainY = this.numEditor_numGainY.Value;
                this.weldProcedure.numGainZ = this.numEditor_numGainZ.Value;
                this.weldProcedure.numPenetration = this.numEditor_numPenetration.Value;
                this.weldProcedure.numTrackBias = this.numEditor_numTrackBias.Value;
                this.weldProcedure.numWeaveWidth90 = this.numEditor_numWeaveWidth90.Value;
                this.weldProcedure.strRemark = this.dataEditor_strRemark.Text;

                if (this.weldProcedure.numWeaveShape != 0)
                {                    
                    if (this.weldProcedure.numWeaveWidth == 0)
                    {
                         this.weldProcedure.numWeaveWidth = 0.1M;
                    }
                    if (this.weldProcedure.numWeaveWidth90 == 0)
                    {
                        this.weldProcedure.numWeaveWidth90 = 0.1M;
                    }
                }
                this.numEditor_numWeaveWidth.Value = this.weldProcedure.numWeaveWidth;
                this.numEditor_numWeaveWidth90.Value = this.weldProcedure.numWeaveWidth90;

                this.weldProcedure.ApplyData(this.rwSystem);
                
                this.menuItem_Apply.Enabled = false;
            }
            catch (Exception ex)
            {
                GTPUMessageBox.Show(this.Parent.Parent, null
                    , string.Format("An unexpected error occurred when applying RAPID data 'rweldProcedure'. Message {0}", ex.ToString())
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
            this.Text = _tpsRm.GetString("TXT_TpsFormWeldingParameterTitle");
            this.tpsLabel_intGroupIndex.Text = _tpsRm.GetString("TXT_tpsLabel_intGroupIndex");
            this.tpsLabel_intIndex.Text = _tpsRm.GetString("TXT_tpsLabel_intIndex");
        }

        private void button_UpdateID_Click(object sender, EventArgs e)
        {
            double numWeaveWidth = Convert.ToDouble(this.numEditor_numWeaveWidth.Value);
            double numWeaveWidth90 = Convert.ToDouble(this.numEditor_numWeaveWidth90.Value);
            numWeaveWidth = numWeaveWidth==0.1 ? 0 : numWeaveWidth;
            numWeaveWidth90 = numWeaveWidth90 == 0.1 ? 0 : numWeaveWidth90;
            this.dataEditor_strWeldProcedureID.Text = string.Format("s{0}j{1}w{2}-{3}", this.numEditor_numWeldSpeed.Value, this.numEditor_numSche.Value, numWeaveWidth, numWeaveWidth90);
            this.menuItem_Apply.Enabled = true;
        }

        private void numericUpDown_intGroupIndex_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            this.Invoke(this.UpdateGUI);
            this.menuItem_Apply.Enabled = false;
        }

        private void numericUpDown_intIndex_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Invoke(this.UpdateGUI);
            this.menuItem_Apply.Enabled = false;
        }


        private void dataEditor_strWeldProcedureID_Click(object sender, EventArgs e)
        {
            this.menuItem_Apply.Enabled = true;
        }

        private void dataEditor_strRemark_Click(object sender, EventArgs e)
        {
            this.menuItem_Apply.Enabled = true;
        }


    }
}