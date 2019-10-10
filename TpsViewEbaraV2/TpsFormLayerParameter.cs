using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data;
using ABB.Robotics.Tps.Windows.Forms;
using TpsViewEbaraV2NameSpace.Robot;
using TpsViewEbaraV2NameSpace.Ebara;
using ABB.Robotics.Tps.Taf;
using ABB.Robotics.Tps.Resources;
using System.Text.RegularExpressions;
using ABB.Robotics.ProductionScreen.Base;

namespace TpsViewEbaraV2NameSpace
{
    public class TpsFormLayerParameter : TpsForm, ITpsViewActivation
    {
        private TpsResourceManager _tpsRm = null;
        private RWSystem rwSystem = null;
        private LayerParameter layerParameter = null;

        private ABB.Robotics.Tps.Windows.Forms.PictureBox pictureBox_Logo;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Refresh;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Apply;
        private ABB.Robotics.Tps.Windows.Forms.MenuItem menuItem_Close;
        private TpsLabel tpsLabel_intLayerNo;
        private DataEditor dataEditor_strWeldProcedureID;
        private CompactAlphaPad compactAlphaPad1;
        private TpsLabel tpsLabel_rCircleOffsetX;
        private TpsLabel tpsLabel_rCircleOffsetZ;
        private TpsLabel tpsLabel_rCircleRotationX;
        private TpsLabel tpsLabel_rCircleRotationY;
        private TpsLabel tpsLabel_rCircleRotationZ;
        private TpsLabel tpsLabel_numDegree0;
        private TpsLabel tpsLabel_numDegree90;
        private TpsLabel tpsLabel_numDegree180;
        private TpsLabel tpsLabel_numDegree270;
        private NumEditor numEditor_rCircleOffsetX0;
        private NumEditor numEditor_rCircleOffsetX90;
        private NumEditor numEditor_rCircleOffsetX180;
        private NumEditor numEditor_rCircleOffsetX270;
        private NumEditor numEditor_rCircleOffsetZ0;
        private NumEditor numEditor_rCircleOffsetZ90;
        private NumEditor numEditor_rCircleOffsetZ180;
        private NumEditor numEditor_rCircleOffsetZ270;
        private NumEditor numEditor_rCircleRotationX0;
        private NumEditor numEditor_rCircleRotationX90;
        private NumEditor numEditor_rCircleRotationX180;
        private NumEditor numEditor_rCircleRotationX270;
        private NumEditor numEditor_rCircleRotationY0;
        private NumEditor numEditor_rCircleRotationY90;
        private NumEditor numEditor_rCircleRotationY180;
        private NumEditor numEditor_rCircleRotationY270;
        private NumEditor numEditor_rCircleRotationZ0;
        private NumEditor numEditor_rCircleRotationZ90;
        private NumEditor numEditor_rCircleRotationZ180;
        private NumEditor numEditor_rCircleRotationZ270;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolRefreshbyLayerParameters;
        private ABB.Robotics.Tps.Windows.Forms.CheckBox checkBox_boolRefreshWeldProcedureID;
        private NumEditor numEditor_intLayerNo;
        private NumEditor numEditor_numWorkAngleDeclination;
        private TpsLabel tpsLabel_numWorkAngleDeclination;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        public TpsFormLayerParameter(TpsResourceManager rM, RWSystem rwSystem, LayerParameter layerParameter)
        {
            try
            {
                InitializeComponent();
                this._tpsRm = rM;
                this.rwSystem = rwSystem;
                this.layerParameter = layerParameter;
                //this.numericUpDown_intLayerNo.Value = this.layerParameter.intLayerNo;
                this.numEditor_intLayerNo.Value = this.layerParameter.intLayerNo;

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
                        //if (this.layerParameter != null)
                        //{
                        //    this.layerParameter.Dispose();
                        //    this.layerParameter = null;
                        //}

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TpsFormLayerParameter));
            this.pictureBox_Logo = new ABB.Robotics.Tps.Windows.Forms.PictureBox();
            this.menuItem_Refresh = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Apply = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.menuItem_Close = new ABB.Robotics.Tps.Windows.Forms.MenuItem();
            this.tpsLabel_intLayerNo = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.dataEditor_strWeldProcedureID = new ABB.Robotics.Tps.Windows.Forms.DataEditor();
            this.compactAlphaPad1 = new ABB.Robotics.Tps.Windows.Forms.CompactAlphaPad();
            this.tpsLabel_rCircleOffsetX = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_rCircleOffsetZ = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_rCircleRotationX = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_rCircleRotationY = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_rCircleRotationZ = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numDegree0 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numDegree90 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numDegree180 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.tpsLabel_numDegree270 = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.numEditor_rCircleOffsetX0 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetX90 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetX180 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetX270 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetZ0 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetZ90 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetZ180 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleOffsetZ270 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationX0 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationX90 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationX180 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationX270 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationY0 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationY90 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationY180 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationY270 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationZ0 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationZ90 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationZ180 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_rCircleRotationZ270 = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.checkBox_boolRefreshbyLayerParameters = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.checkBox_boolRefreshWeldProcedureID = new ABB.Robotics.Tps.Windows.Forms.CheckBox();
            this.numEditor_intLayerNo = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.numEditor_numWorkAngleDeclination = new ABB.Robotics.Tps.Windows.Forms.NumEditor();
            this.tpsLabel_numWorkAngleDeclination = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.SuspendLayout();
            // 
            // pictureBox_Logo
            // 
            this.pictureBox_Logo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pictureBox_Logo.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.pictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Logo.Image")));
            this.pictureBox_Logo.Location = new System.Drawing.Point(530, 0);
            this.pictureBox_Logo.Name = "pictureBox_Logo";
            this.pictureBox_Logo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.pictureBox_Logo.Size = new System.Drawing.Size(108, 32);
            this.pictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Logo.TabIndex = 7;
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
            // tpsLabel_intLayerNo
            // 
            this.tpsLabel_intLayerNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_intLayerNo.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_intLayerNo.Location = new System.Drawing.Point(11, 41);
            this.tpsLabel_intLayerNo.Multiline = true;
            this.tpsLabel_intLayerNo.Name = "tpsLabel_intLayerNo";
            this.tpsLabel_intLayerNo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_intLayerNo.Size = new System.Drawing.Size(88, 24);
            this.tpsLabel_intLayerNo.TabIndex = 8;
            this.tpsLabel_intLayerNo.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_intLayerNo.Title = "Layer No";
            // 
            // dataEditor_strWeldProcedureID
            // 
            this.dataEditor_strWeldProcedureID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataEditor_strWeldProcedureID.CaretVisible = false;
            this.dataEditor_strWeldProcedureID.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.dataEditor_strWeldProcedureID.Location = new System.Drawing.Point(456, 41);
            this.dataEditor_strWeldProcedureID.Multiline = true;
            this.dataEditor_strWeldProcedureID.Name = "dataEditor_strWeldProcedureID";
            this.dataEditor_strWeldProcedureID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataEditor_strWeldProcedureID.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.dataEditor_strWeldProcedureID.SelectionLength = 0;
            this.dataEditor_strWeldProcedureID.SelectionStart = 0;
            this.dataEditor_strWeldProcedureID.SelectionVisible = false;
            this.dataEditor_strWeldProcedureID.Size = new System.Drawing.Size(159, 30);
            this.dataEditor_strWeldProcedureID.TabIndex = 32;
            this.dataEditor_strWeldProcedureID.Text = "";
            this.dataEditor_strWeldProcedureID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.dataEditor_strWeldProcedureID.Click += new System.EventHandler(this.dataEditor_strWeldProcedureID_Click);
            // 
            // compactAlphaPad1
            // 
            this.compactAlphaPad1.ActiveCharPanel = ABB.Robotics.Tps.Windows.Forms.CharSet.Characters;
            this.compactAlphaPad1.Location = new System.Drawing.Point(0, 0);
            this.compactAlphaPad1.Name = "compactAlphaPad1";
            this.compactAlphaPad1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.compactAlphaPad1.Size = new System.Drawing.Size(293, 167);
            this.compactAlphaPad1.TabIndex = 0;
            this.compactAlphaPad1.Target = null;
            // 
            // tpsLabel_rCircleOffsetX
            // 
            this.tpsLabel_rCircleOffsetX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_rCircleOffsetX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_rCircleOffsetX.Location = new System.Drawing.Point(11, 115);
            this.tpsLabel_rCircleOffsetX.Multiline = true;
            this.tpsLabel_rCircleOffsetX.Name = "tpsLabel_rCircleOffsetX";
            this.tpsLabel_rCircleOffsetX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_rCircleOffsetX.Size = new System.Drawing.Size(102, 24);
            this.tpsLabel_rCircleOffsetX.TabIndex = 8;
            this.tpsLabel_rCircleOffsetX.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_rCircleOffsetX.Title = "Offset X";
            // 
            // tpsLabel_rCircleOffsetZ
            // 
            this.tpsLabel_rCircleOffsetZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_rCircleOffsetZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_rCircleOffsetZ.Location = new System.Drawing.Point(11, 161);
            this.tpsLabel_rCircleOffsetZ.Multiline = true;
            this.tpsLabel_rCircleOffsetZ.Name = "tpsLabel_rCircleOffsetZ";
            this.tpsLabel_rCircleOffsetZ.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_rCircleOffsetZ.Size = new System.Drawing.Size(102, 24);
            this.tpsLabel_rCircleOffsetZ.TabIndex = 8;
            this.tpsLabel_rCircleOffsetZ.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_rCircleOffsetZ.Title = "Offset Z";
            // 
            // tpsLabel_rCircleRotationX
            // 
            this.tpsLabel_rCircleRotationX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_rCircleRotationX.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_rCircleRotationX.Location = new System.Drawing.Point(11, 207);
            this.tpsLabel_rCircleRotationX.Multiline = true;
            this.tpsLabel_rCircleRotationX.Name = "tpsLabel_rCircleRotationX";
            this.tpsLabel_rCircleRotationX.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_rCircleRotationX.Size = new System.Drawing.Size(102, 24);
            this.tpsLabel_rCircleRotationX.TabIndex = 8;
            this.tpsLabel_rCircleRotationX.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_rCircleRotationX.Title = "Rotation X";
            // 
            // tpsLabel_rCircleRotationY
            // 
            this.tpsLabel_rCircleRotationY.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_rCircleRotationY.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_rCircleRotationY.Location = new System.Drawing.Point(11, 253);
            this.tpsLabel_rCircleRotationY.Multiline = true;
            this.tpsLabel_rCircleRotationY.Name = "tpsLabel_rCircleRotationY";
            this.tpsLabel_rCircleRotationY.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_rCircleRotationY.Size = new System.Drawing.Size(102, 24);
            this.tpsLabel_rCircleRotationY.TabIndex = 8;
            this.tpsLabel_rCircleRotationY.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_rCircleRotationY.Title = "Rotation Y";
            // 
            // tpsLabel_rCircleRotationZ
            // 
            this.tpsLabel_rCircleRotationZ.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_rCircleRotationZ.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_rCircleRotationZ.Location = new System.Drawing.Point(11, 299);
            this.tpsLabel_rCircleRotationZ.Multiline = true;
            this.tpsLabel_rCircleRotationZ.Name = "tpsLabel_rCircleRotationZ";
            this.tpsLabel_rCircleRotationZ.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_rCircleRotationZ.Size = new System.Drawing.Size(102, 24);
            this.tpsLabel_rCircleRotationZ.TabIndex = 8;
            this.tpsLabel_rCircleRotationZ.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_rCircleRotationZ.Title = "Rotation Z";
            this.tpsLabel_rCircleRotationZ.Visible = false;
            // 
            // tpsLabel_numDegree0
            // 
            this.tpsLabel_numDegree0.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDegree0.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDegree0.Location = new System.Drawing.Point(153, 85);
            this.tpsLabel_numDegree0.Multiline = true;
            this.tpsLabel_numDegree0.Name = "tpsLabel_numDegree0";
            this.tpsLabel_numDegree0.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDegree0.Size = new System.Drawing.Size(36, 24);
            this.tpsLabel_numDegree0.TabIndex = 8;
            this.tpsLabel_numDegree0.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDegree0.Title = "0";
            // 
            // tpsLabel_numDegree90
            // 
            this.tpsLabel_numDegree90.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDegree90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDegree90.Location = new System.Drawing.Point(243, 85);
            this.tpsLabel_numDegree90.Multiline = true;
            this.tpsLabel_numDegree90.Name = "tpsLabel_numDegree90";
            this.tpsLabel_numDegree90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDegree90.Size = new System.Drawing.Size(54, 24);
            this.tpsLabel_numDegree90.TabIndex = 8;
            this.tpsLabel_numDegree90.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDegree90.Title = "90";
            // 
            // tpsLabel_numDegree180
            // 
            this.tpsLabel_numDegree180.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDegree180.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDegree180.Location = new System.Drawing.Point(340, 85);
            this.tpsLabel_numDegree180.Multiline = true;
            this.tpsLabel_numDegree180.Name = "tpsLabel_numDegree180";
            this.tpsLabel_numDegree180.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDegree180.Size = new System.Drawing.Size(48, 24);
            this.tpsLabel_numDegree180.TabIndex = 8;
            this.tpsLabel_numDegree180.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDegree180.Title = "180";
            // 
            // tpsLabel_numDegree270
            // 
            this.tpsLabel_numDegree270.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numDegree270.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numDegree270.Location = new System.Drawing.Point(440, 85);
            this.tpsLabel_numDegree270.Multiline = true;
            this.tpsLabel_numDegree270.Name = "tpsLabel_numDegree270";
            this.tpsLabel_numDegree270.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numDegree270.Size = new System.Drawing.Size(57, 24);
            this.tpsLabel_numDegree270.TabIndex = 8;
            this.tpsLabel_numDegree270.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numDegree270.Title = "270";
            // 
            // numEditor_rCircleOffsetX0
            // 
            this.numEditor_rCircleOffsetX0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetX0.CaretVisible = false;
            this.numEditor_rCircleOffsetX0.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetX0.Location = new System.Drawing.Point(119, 115);
            this.numEditor_rCircleOffsetX0.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetX0.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetX0.Multiline = true;
            this.numEditor_rCircleOffsetX0.Name = "numEditor_rCircleOffsetX0";
            this.numEditor_rCircleOffsetX0.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetX0.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetX0.SelectionLength = 0;
            this.numEditor_rCircleOffsetX0.SelectionStart = 0;
            this.numEditor_rCircleOffsetX0.SelectionVisible = false;
            this.numEditor_rCircleOffsetX0.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetX0.TabIndex = 34;
            this.numEditor_rCircleOffsetX0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetX0.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetX90
            // 
            this.numEditor_rCircleOffsetX90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetX90.CaretVisible = false;
            this.numEditor_rCircleOffsetX90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetX90.Location = new System.Drawing.Point(218, 115);
            this.numEditor_rCircleOffsetX90.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetX90.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetX90.Multiline = true;
            this.numEditor_rCircleOffsetX90.Name = "numEditor_rCircleOffsetX90";
            this.numEditor_rCircleOffsetX90.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetX90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetX90.SelectionLength = 0;
            this.numEditor_rCircleOffsetX90.SelectionStart = 0;
            this.numEditor_rCircleOffsetX90.SelectionVisible = false;
            this.numEditor_rCircleOffsetX90.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetX90.TabIndex = 34;
            this.numEditor_rCircleOffsetX90.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetX90.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetX180
            // 
            this.numEditor_rCircleOffsetX180.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetX180.CaretVisible = false;
            this.numEditor_rCircleOffsetX180.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetX180.Location = new System.Drawing.Point(317, 115);
            this.numEditor_rCircleOffsetX180.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetX180.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetX180.Multiline = true;
            this.numEditor_rCircleOffsetX180.Name = "numEditor_rCircleOffsetX180";
            this.numEditor_rCircleOffsetX180.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetX180.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetX180.SelectionLength = 0;
            this.numEditor_rCircleOffsetX180.SelectionStart = 0;
            this.numEditor_rCircleOffsetX180.SelectionVisible = false;
            this.numEditor_rCircleOffsetX180.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetX180.TabIndex = 34;
            this.numEditor_rCircleOffsetX180.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetX180.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetX270
            // 
            this.numEditor_rCircleOffsetX270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetX270.CaretVisible = false;
            this.numEditor_rCircleOffsetX270.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetX270.Location = new System.Drawing.Point(417, 115);
            this.numEditor_rCircleOffsetX270.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetX270.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetX270.Multiline = true;
            this.numEditor_rCircleOffsetX270.Name = "numEditor_rCircleOffsetX270";
            this.numEditor_rCircleOffsetX270.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetX270.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetX270.SelectionLength = 0;
            this.numEditor_rCircleOffsetX270.SelectionStart = 0;
            this.numEditor_rCircleOffsetX270.SelectionVisible = false;
            this.numEditor_rCircleOffsetX270.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetX270.TabIndex = 34;
            this.numEditor_rCircleOffsetX270.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetX270.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetZ0
            // 
            this.numEditor_rCircleOffsetZ0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetZ0.CaretVisible = false;
            this.numEditor_rCircleOffsetZ0.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetZ0.Location = new System.Drawing.Point(119, 161);
            this.numEditor_rCircleOffsetZ0.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetZ0.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetZ0.Multiline = true;
            this.numEditor_rCircleOffsetZ0.Name = "numEditor_rCircleOffsetZ0";
            this.numEditor_rCircleOffsetZ0.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetZ0.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetZ0.SelectionLength = 0;
            this.numEditor_rCircleOffsetZ0.SelectionStart = 0;
            this.numEditor_rCircleOffsetZ0.SelectionVisible = false;
            this.numEditor_rCircleOffsetZ0.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetZ0.TabIndex = 34;
            this.numEditor_rCircleOffsetZ0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetZ0.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetZ90
            // 
            this.numEditor_rCircleOffsetZ90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetZ90.CaretVisible = false;
            this.numEditor_rCircleOffsetZ90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetZ90.Location = new System.Drawing.Point(218, 161);
            this.numEditor_rCircleOffsetZ90.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetZ90.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetZ90.Multiline = true;
            this.numEditor_rCircleOffsetZ90.Name = "numEditor_rCircleOffsetZ90";
            this.numEditor_rCircleOffsetZ90.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetZ90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetZ90.SelectionLength = 0;
            this.numEditor_rCircleOffsetZ90.SelectionStart = 0;
            this.numEditor_rCircleOffsetZ90.SelectionVisible = false;
            this.numEditor_rCircleOffsetZ90.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetZ90.TabIndex = 34;
            this.numEditor_rCircleOffsetZ90.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetZ90.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetZ180
            // 
            this.numEditor_rCircleOffsetZ180.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetZ180.CaretVisible = false;
            this.numEditor_rCircleOffsetZ180.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetZ180.Location = new System.Drawing.Point(317, 161);
            this.numEditor_rCircleOffsetZ180.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetZ180.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetZ180.Multiline = true;
            this.numEditor_rCircleOffsetZ180.Name = "numEditor_rCircleOffsetZ180";
            this.numEditor_rCircleOffsetZ180.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetZ180.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetZ180.SelectionLength = 0;
            this.numEditor_rCircleOffsetZ180.SelectionStart = 0;
            this.numEditor_rCircleOffsetZ180.SelectionVisible = false;
            this.numEditor_rCircleOffsetZ180.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetZ180.TabIndex = 34;
            this.numEditor_rCircleOffsetZ180.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetZ180.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleOffsetZ270
            // 
            this.numEditor_rCircleOffsetZ270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleOffsetZ270.CaretVisible = false;
            this.numEditor_rCircleOffsetZ270.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleOffsetZ270.Location = new System.Drawing.Point(417, 161);
            this.numEditor_rCircleOffsetZ270.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleOffsetZ270.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleOffsetZ270.Multiline = true;
            this.numEditor_rCircleOffsetZ270.Name = "numEditor_rCircleOffsetZ270";
            this.numEditor_rCircleOffsetZ270.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleOffsetZ270.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleOffsetZ270.SelectionLength = 0;
            this.numEditor_rCircleOffsetZ270.SelectionStart = 0;
            this.numEditor_rCircleOffsetZ270.SelectionVisible = false;
            this.numEditor_rCircleOffsetZ270.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleOffsetZ270.TabIndex = 34;
            this.numEditor_rCircleOffsetZ270.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleOffsetZ270.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationX0
            // 
            this.numEditor_rCircleRotationX0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationX0.CaretVisible = false;
            this.numEditor_rCircleRotationX0.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationX0.Location = new System.Drawing.Point(119, 207);
            this.numEditor_rCircleRotationX0.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationX0.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationX0.Multiline = true;
            this.numEditor_rCircleRotationX0.Name = "numEditor_rCircleRotationX0";
            this.numEditor_rCircleRotationX0.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationX0.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationX0.SelectionLength = 0;
            this.numEditor_rCircleRotationX0.SelectionStart = 0;
            this.numEditor_rCircleRotationX0.SelectionVisible = false;
            this.numEditor_rCircleRotationX0.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationX0.TabIndex = 34;
            this.numEditor_rCircleRotationX0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationX0.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationX90
            // 
            this.numEditor_rCircleRotationX90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationX90.CaretVisible = false;
            this.numEditor_rCircleRotationX90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationX90.Location = new System.Drawing.Point(218, 207);
            this.numEditor_rCircleRotationX90.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationX90.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationX90.Multiline = true;
            this.numEditor_rCircleRotationX90.Name = "numEditor_rCircleRotationX90";
            this.numEditor_rCircleRotationX90.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationX90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationX90.SelectionLength = 0;
            this.numEditor_rCircleRotationX90.SelectionStart = 0;
            this.numEditor_rCircleRotationX90.SelectionVisible = false;
            this.numEditor_rCircleRotationX90.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationX90.TabIndex = 34;
            this.numEditor_rCircleRotationX90.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationX90.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationX180
            // 
            this.numEditor_rCircleRotationX180.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationX180.CaretVisible = false;
            this.numEditor_rCircleRotationX180.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationX180.Location = new System.Drawing.Point(317, 207);
            this.numEditor_rCircleRotationX180.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationX180.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationX180.Multiline = true;
            this.numEditor_rCircleRotationX180.Name = "numEditor_rCircleRotationX180";
            this.numEditor_rCircleRotationX180.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationX180.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationX180.SelectionLength = 0;
            this.numEditor_rCircleRotationX180.SelectionStart = 0;
            this.numEditor_rCircleRotationX180.SelectionVisible = false;
            this.numEditor_rCircleRotationX180.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationX180.TabIndex = 34;
            this.numEditor_rCircleRotationX180.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationX180.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationX270
            // 
            this.numEditor_rCircleRotationX270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationX270.CaretVisible = false;
            this.numEditor_rCircleRotationX270.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationX270.Location = new System.Drawing.Point(417, 207);
            this.numEditor_rCircleRotationX270.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationX270.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationX270.Multiline = true;
            this.numEditor_rCircleRotationX270.Name = "numEditor_rCircleRotationX270";
            this.numEditor_rCircleRotationX270.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationX270.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationX270.SelectionLength = 0;
            this.numEditor_rCircleRotationX270.SelectionStart = 0;
            this.numEditor_rCircleRotationX270.SelectionVisible = false;
            this.numEditor_rCircleRotationX270.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationX270.TabIndex = 34;
            this.numEditor_rCircleRotationX270.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationX270.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationY0
            // 
            this.numEditor_rCircleRotationY0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationY0.CaretVisible = false;
            this.numEditor_rCircleRotationY0.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationY0.Location = new System.Drawing.Point(119, 253);
            this.numEditor_rCircleRotationY0.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationY0.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationY0.Multiline = true;
            this.numEditor_rCircleRotationY0.Name = "numEditor_rCircleRotationY0";
            this.numEditor_rCircleRotationY0.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationY0.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationY0.SelectionLength = 0;
            this.numEditor_rCircleRotationY0.SelectionStart = 0;
            this.numEditor_rCircleRotationY0.SelectionVisible = false;
            this.numEditor_rCircleRotationY0.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationY0.TabIndex = 34;
            this.numEditor_rCircleRotationY0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationY0.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationY90
            // 
            this.numEditor_rCircleRotationY90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationY90.CaretVisible = false;
            this.numEditor_rCircleRotationY90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationY90.Location = new System.Drawing.Point(218, 253);
            this.numEditor_rCircleRotationY90.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationY90.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationY90.Multiline = true;
            this.numEditor_rCircleRotationY90.Name = "numEditor_rCircleRotationY90";
            this.numEditor_rCircleRotationY90.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationY90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationY90.SelectionLength = 0;
            this.numEditor_rCircleRotationY90.SelectionStart = 0;
            this.numEditor_rCircleRotationY90.SelectionVisible = false;
            this.numEditor_rCircleRotationY90.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationY90.TabIndex = 34;
            this.numEditor_rCircleRotationY90.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationY90.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationY180
            // 
            this.numEditor_rCircleRotationY180.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationY180.CaretVisible = false;
            this.numEditor_rCircleRotationY180.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationY180.Location = new System.Drawing.Point(317, 253);
            this.numEditor_rCircleRotationY180.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationY180.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationY180.Multiline = true;
            this.numEditor_rCircleRotationY180.Name = "numEditor_rCircleRotationY180";
            this.numEditor_rCircleRotationY180.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationY180.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationY180.SelectionLength = 0;
            this.numEditor_rCircleRotationY180.SelectionStart = 0;
            this.numEditor_rCircleRotationY180.SelectionVisible = false;
            this.numEditor_rCircleRotationY180.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationY180.TabIndex = 34;
            this.numEditor_rCircleRotationY180.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationY180.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationY270
            // 
            this.numEditor_rCircleRotationY270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationY270.CaretVisible = false;
            this.numEditor_rCircleRotationY270.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationY270.Location = new System.Drawing.Point(417, 253);
            this.numEditor_rCircleRotationY270.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationY270.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationY270.Multiline = true;
            this.numEditor_rCircleRotationY270.Name = "numEditor_rCircleRotationY270";
            this.numEditor_rCircleRotationY270.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationY270.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationY270.SelectionLength = 0;
            this.numEditor_rCircleRotationY270.SelectionStart = 0;
            this.numEditor_rCircleRotationY270.SelectionVisible = false;
            this.numEditor_rCircleRotationY270.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationY270.TabIndex = 34;
            this.numEditor_rCircleRotationY270.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationY270.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationZ0
            // 
            this.numEditor_rCircleRotationZ0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationZ0.CaretVisible = false;
            this.numEditor_rCircleRotationZ0.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationZ0.Location = new System.Drawing.Point(119, 299);
            this.numEditor_rCircleRotationZ0.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationZ0.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationZ0.Multiline = true;
            this.numEditor_rCircleRotationZ0.Name = "numEditor_rCircleRotationZ0";
            this.numEditor_rCircleRotationZ0.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationZ0.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationZ0.SelectionLength = 0;
            this.numEditor_rCircleRotationZ0.SelectionStart = 0;
            this.numEditor_rCircleRotationZ0.SelectionVisible = false;
            this.numEditor_rCircleRotationZ0.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationZ0.TabIndex = 34;
            this.numEditor_rCircleRotationZ0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationZ0.Visible = false;
            this.numEditor_rCircleRotationZ0.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationZ90
            // 
            this.numEditor_rCircleRotationZ90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationZ90.CaretVisible = false;
            this.numEditor_rCircleRotationZ90.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationZ90.Location = new System.Drawing.Point(218, 299);
            this.numEditor_rCircleRotationZ90.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationZ90.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationZ90.Multiline = true;
            this.numEditor_rCircleRotationZ90.Name = "numEditor_rCircleRotationZ90";
            this.numEditor_rCircleRotationZ90.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationZ90.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationZ90.SelectionLength = 0;
            this.numEditor_rCircleRotationZ90.SelectionStart = 0;
            this.numEditor_rCircleRotationZ90.SelectionVisible = false;
            this.numEditor_rCircleRotationZ90.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationZ90.TabIndex = 34;
            this.numEditor_rCircleRotationZ90.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationZ90.Visible = false;
            this.numEditor_rCircleRotationZ90.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationZ180
            // 
            this.numEditor_rCircleRotationZ180.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationZ180.CaretVisible = false;
            this.numEditor_rCircleRotationZ180.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationZ180.Location = new System.Drawing.Point(317, 299);
            this.numEditor_rCircleRotationZ180.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationZ180.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationZ180.Multiline = true;
            this.numEditor_rCircleRotationZ180.Name = "numEditor_rCircleRotationZ180";
            this.numEditor_rCircleRotationZ180.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationZ180.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationZ180.SelectionLength = 0;
            this.numEditor_rCircleRotationZ180.SelectionStart = 0;
            this.numEditor_rCircleRotationZ180.SelectionVisible = false;
            this.numEditor_rCircleRotationZ180.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationZ180.TabIndex = 34;
            this.numEditor_rCircleRotationZ180.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationZ180.Visible = false;
            this.numEditor_rCircleRotationZ180.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_rCircleRotationZ270
            // 
            this.numEditor_rCircleRotationZ270.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_rCircleRotationZ270.CaretVisible = false;
            this.numEditor_rCircleRotationZ270.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_rCircleRotationZ270.Location = new System.Drawing.Point(417, 299);
            this.numEditor_rCircleRotationZ270.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_rCircleRotationZ270.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_rCircleRotationZ270.Multiline = true;
            this.numEditor_rCircleRotationZ270.Name = "numEditor_rCircleRotationZ270";
            this.numEditor_rCircleRotationZ270.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_rCircleRotationZ270.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_rCircleRotationZ270.SelectionLength = 0;
            this.numEditor_rCircleRotationZ270.SelectionStart = 0;
            this.numEditor_rCircleRotationZ270.SelectionVisible = false;
            this.numEditor_rCircleRotationZ270.Size = new System.Drawing.Size(80, 40);
            this.numEditor_rCircleRotationZ270.TabIndex = 34;
            this.numEditor_rCircleRotationZ270.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_rCircleRotationZ270.Visible = false;
            this.numEditor_rCircleRotationZ270.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_boolRefreshbyLayerParameters
            // 
            this.checkBox_boolRefreshbyLayerParameters.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolRefreshbyLayerParameters.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolRefreshbyLayerParameters.Location = new System.Drawing.Point(525, 115);
            this.checkBox_boolRefreshbyLayerParameters.Name = "checkBox_boolRefreshbyLayerParameters";
            this.checkBox_boolRefreshbyLayerParameters.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolRefreshbyLayerParameters.Size = new System.Drawing.Size(103, 24);
            this.checkBox_boolRefreshbyLayerParameters.TabIndex = 42;
            this.checkBox_boolRefreshbyLayerParameters.Text = "Refresh";
            this.checkBox_boolRefreshbyLayerParameters.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // checkBox_boolRefreshWeldProcedureID
            // 
            this.checkBox_boolRefreshWeldProcedureID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkBox_boolRefreshWeldProcedureID.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.checkBox_boolRefreshWeldProcedureID.Location = new System.Drawing.Point(260, 41);
            this.checkBox_boolRefreshWeldProcedureID.Name = "checkBox_boolRefreshWeldProcedureID";
            this.checkBox_boolRefreshWeldProcedureID.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.checkBox_boolRefreshWeldProcedureID.Size = new System.Drawing.Size(190, 24);
            this.checkBox_boolRefreshWeldProcedureID.TabIndex = 42;
            this.checkBox_boolRefreshWeldProcedureID.Text = "Weld Procedure ID";
            this.checkBox_boolRefreshWeldProcedureID.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // numEditor_intLayerNo
            // 
            this.numEditor_intLayerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_intLayerNo.CaretVisible = false;
            this.numEditor_intLayerNo.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_intLayerNo.Location = new System.Drawing.Point(119, 41);
            this.numEditor_intLayerNo.Maximum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numEditor_intLayerNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEditor_intLayerNo.Multiline = true;
            this.numEditor_intLayerNo.Name = "numEditor_intLayerNo";
            this.numEditor_intLayerNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_intLayerNo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_intLayerNo.SelectionLength = 0;
            this.numEditor_intLayerNo.SelectionStart = 0;
            this.numEditor_intLayerNo.SelectionVisible = false;
            this.numEditor_intLayerNo.ShowDecimalPoint = false;
            this.numEditor_intLayerNo.Size = new System.Drawing.Size(80, 40);
            this.numEditor_intLayerNo.TabIndex = 43;
            this.numEditor_intLayerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_intLayerNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numEditor_intLayerNo.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.numEditor_intLayerNo_PropertyChanged);
            // 
            // numEditor_numWorkAngleDeclination
            // 
            this.numEditor_numWorkAngleDeclination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEditor_numWorkAngleDeclination.CaretVisible = false;
            this.numEditor_numWorkAngleDeclination.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numEditor_numWorkAngleDeclination.Location = new System.Drawing.Point(535, 253);
            this.numEditor_numWorkAngleDeclination.Maximum = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.numEditor_numWorkAngleDeclination.Minimum = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.numEditor_numWorkAngleDeclination.Multiline = true;
            this.numEditor_numWorkAngleDeclination.Name = "numEditor_numWorkAngleDeclination";
            this.numEditor_numWorkAngleDeclination.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numEditor_numWorkAngleDeclination.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numEditor_numWorkAngleDeclination.SelectionLength = 0;
            this.numEditor_numWorkAngleDeclination.SelectionStart = 0;
            this.numEditor_numWorkAngleDeclination.SelectionVisible = false;
            this.numEditor_numWorkAngleDeclination.Size = new System.Drawing.Size(80, 40);
            this.numEditor_numWorkAngleDeclination.TabIndex = 34;
            this.numEditor_numWorkAngleDeclination.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numEditor_numWorkAngleDeclination.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.dataControl_PropertyChanged);
            // 
            // tpsLabel_numWorkAngleDeclination
            // 
            this.tpsLabel_numWorkAngleDeclination.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_numWorkAngleDeclination.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_numWorkAngleDeclination.Location = new System.Drawing.Point(526, 207);
            this.tpsLabel_numWorkAngleDeclination.Multiline = true;
            this.tpsLabel_numWorkAngleDeclination.Name = "tpsLabel_numWorkAngleDeclination";
            this.tpsLabel_numWorkAngleDeclination.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_numWorkAngleDeclination.Size = new System.Drawing.Size(102, 24);
            this.tpsLabel_numWorkAngleDeclination.TabIndex = 8;
            this.tpsLabel_numWorkAngleDeclination.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_numWorkAngleDeclination.Title = "Work Angle";
            // 
            // TpsFormLayerParameter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.numEditor_intLayerNo);
            this.Controls.Add(this.checkBox_boolRefreshWeldProcedureID);
            this.Controls.Add(this.checkBox_boolRefreshbyLayerParameters);
            this.Controls.Add(this.numEditor_rCircleRotationZ270);
            this.Controls.Add(this.numEditor_numWorkAngleDeclination);
            this.Controls.Add(this.numEditor_rCircleRotationY270);
            this.Controls.Add(this.numEditor_rCircleRotationX270);
            this.Controls.Add(this.numEditor_rCircleOffsetZ270);
            this.Controls.Add(this.numEditor_rCircleOffsetX270);
            this.Controls.Add(this.numEditor_rCircleRotationZ180);
            this.Controls.Add(this.numEditor_rCircleRotationY180);
            this.Controls.Add(this.numEditor_rCircleRotationX180);
            this.Controls.Add(this.numEditor_rCircleOffsetZ180);
            this.Controls.Add(this.numEditor_rCircleOffsetX180);
            this.Controls.Add(this.numEditor_rCircleRotationZ90);
            this.Controls.Add(this.numEditor_rCircleRotationY90);
            this.Controls.Add(this.numEditor_rCircleRotationX90);
            this.Controls.Add(this.numEditor_rCircleOffsetZ90);
            this.Controls.Add(this.numEditor_rCircleOffsetX90);
            this.Controls.Add(this.numEditor_rCircleRotationZ0);
            this.Controls.Add(this.numEditor_rCircleRotationY0);
            this.Controls.Add(this.numEditor_rCircleRotationX0);
            this.Controls.Add(this.numEditor_rCircleOffsetZ0);
            this.Controls.Add(this.numEditor_rCircleOffsetX0);
            this.Controls.Add(this.dataEditor_strWeldProcedureID);
            this.Controls.Add(this.tpsLabel_rCircleRotationZ);
            this.Controls.Add(this.tpsLabel_numWorkAngleDeclination);
            this.Controls.Add(this.tpsLabel_rCircleRotationY);
            this.Controls.Add(this.tpsLabel_rCircleRotationX);
            this.Controls.Add(this.tpsLabel_rCircleOffsetZ);
            this.Controls.Add(this.tpsLabel_numDegree270);
            this.Controls.Add(this.tpsLabel_numDegree180);
            this.Controls.Add(this.tpsLabel_numDegree90);
            this.Controls.Add(this.tpsLabel_numDegree0);
            this.Controls.Add(this.tpsLabel_rCircleOffsetX);
            this.Controls.Add(this.tpsLabel_intLayerNo);
            this.Controls.Add(this.pictureBox_Logo);
            // 
            // 
            // 
            this.MainMenu.MenuItems.Add(this.menuItem_Refresh);
            this.MainMenu.MenuItems.Add(this.menuItem_Apply);
            this.MainMenu.MenuItems.Add(this.menuItem_Close);
            this.Size = new System.Drawing.Size(640, 390);
            this.Text = "Layer Parameter";
            this.Controls.SetChildIndex(this.pictureBox_Logo, 0);
            this.Controls.SetChildIndex(this.tpsLabel_intLayerNo, 0);
            this.Controls.SetChildIndex(this.tpsLabel_rCircleOffsetX, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numDegree0, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numDegree90, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numDegree180, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numDegree270, 0);
            this.Controls.SetChildIndex(this.tpsLabel_rCircleOffsetZ, 0);
            this.Controls.SetChildIndex(this.tpsLabel_rCircleRotationX, 0);
            this.Controls.SetChildIndex(this.tpsLabel_rCircleRotationY, 0);
            this.Controls.SetChildIndex(this.tpsLabel_numWorkAngleDeclination, 0);
            this.Controls.SetChildIndex(this.tpsLabel_rCircleRotationZ, 0);
            this.Controls.SetChildIndex(this.dataEditor_strWeldProcedureID, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetX0, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetZ0, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationX0, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationY0, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationZ0, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetX90, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetZ90, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationX90, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationY90, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationZ90, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetX180, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetZ180, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationX180, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationY180, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationZ180, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetX270, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleOffsetZ270, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationX270, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationY270, 0);
            this.Controls.SetChildIndex(this.numEditor_numWorkAngleDeclination, 0);
            this.Controls.SetChildIndex(this.numEditor_rCircleRotationZ270, 0);
            this.Controls.SetChildIndex(this.checkBox_boolRefreshbyLayerParameters, 0);
            this.Controls.SetChildIndex(this.checkBox_boolRefreshWeldProcedureID, 0);
            this.Controls.SetChildIndex(this.numEditor_intLayerNo, 0);
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
                //this.layerParameter.RefreshData(this.rwSystem, Convert.ToInt32(this.numericUpDown_intLayerNo.Value));
                this.layerParameter.RefreshData(this.rwSystem, Convert.ToInt32(this.numEditor_intLayerNo.Value));
                this.dataEditor_strWeldProcedureID.Text = this.layerParameter.strLayerParameterID;
                this.numEditor_numWorkAngleDeclination.Value=this.layerParameter.numWorkAngleDeclination;
                this.numEditor_rCircleOffsetX0.Value = this.layerParameter.rCircleOffsetX.numDegree0;
                this.numEditor_rCircleOffsetX90.Value = this.layerParameter.rCircleOffsetX.numDegree90;
                this.numEditor_rCircleOffsetX180.Value = this.layerParameter.rCircleOffsetX.numDegree180;
                this.numEditor_rCircleOffsetX270.Value = this.layerParameter.rCircleOffsetX.numDegree270;

                this.numEditor_rCircleOffsetZ0.Value = this.layerParameter.rCircleOffsetZ.numDegree0;
                this.numEditor_rCircleOffsetZ90.Value = this.layerParameter.rCircleOffsetZ.numDegree90;
                this.numEditor_rCircleOffsetZ180.Value = this.layerParameter.rCircleOffsetZ.numDegree180;
                this.numEditor_rCircleOffsetZ270.Value = this.layerParameter.rCircleOffsetZ.numDegree270;

                this.numEditor_rCircleRotationX0.Value = this.layerParameter.rCircleRotationX.numDegree0;
                this.numEditor_rCircleRotationX90.Value = this.layerParameter.rCircleRotationX.numDegree90;
                this.numEditor_rCircleRotationX180.Value = this.layerParameter.rCircleRotationX.numDegree180;
                this.numEditor_rCircleRotationX270.Value = this.layerParameter.rCircleRotationX.numDegree270;

                this.numEditor_rCircleRotationY0.Value = this.layerParameter.rCircleRotationY.numDegree0;
                this.numEditor_rCircleRotationY90.Value = this.layerParameter.rCircleRotationY.numDegree90;
                this.numEditor_rCircleRotationY180.Value = this.layerParameter.rCircleRotationY.numDegree180;
                this.numEditor_rCircleRotationY270.Value = this.layerParameter.rCircleRotationY.numDegree270;

                this.numEditor_rCircleRotationZ0.Value = this.layerParameter.rCircleRotationZ.numDegree0;
                this.numEditor_rCircleRotationZ90.Value = this.layerParameter.rCircleRotationZ.numDegree90;
                this.numEditor_rCircleRotationZ180.Value = this.layerParameter.rCircleRotationZ.numDegree180;
                this.numEditor_rCircleRotationZ270.Value = this.layerParameter.rCircleRotationZ.numDegree270;

                ABB.Robotics.Controllers.RapidDomain.RapidData boolRapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "WeldSyncModule", "boolRefreshbyLayerParameters");
                ABB.Robotics.Controllers.RapidDomain.Bool bData = new ABB.Robotics.Controllers.RapidDomain.Bool();
                bData.FillFromString(boolRapidData.Value.ToString());
                this.checkBox_boolRefreshbyLayerParameters.Checked = bData;
                boolRapidData.Dispose();

                boolRapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "WeldSyncModule", "boolRefreshWeldProcedureID");
                bData = new ABB.Robotics.Controllers.RapidDomain.Bool();
                bData.FillFromString(boolRapidData.Value.ToString());
                this.checkBox_boolRefreshWeldProcedureID.Checked = bData;
                boolRapidData.Dispose();
                
                this.menuItem_Apply.Enabled = false;
            }
            catch (Exception ex)
            {
                GTPUMessageBox.Show(this.Parent.Parent, null
                    , string.Format("An unexpected error occurred when reading RAPID data 'rLayerParameter'. Message {0}", ex.ToString())
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
                this.layerParameter.strLayerParameterID = this.dataEditor_strWeldProcedureID.Text;
                this.layerParameter.numWorkAngleDeclination = this.numEditor_numWorkAngleDeclination.Value;

                this.layerParameter.rCircleOffsetX.numDegree0 = this.numEditor_rCircleOffsetX0.Value;
                this.layerParameter.rCircleOffsetX.numDegree90 = this.numEditor_rCircleOffsetX90.Value;
                this.layerParameter.rCircleOffsetX.numDegree180 = this.numEditor_rCircleOffsetX180.Value;
                this.layerParameter.rCircleOffsetX.numDegree270 = this.numEditor_rCircleOffsetX270.Value;

                this.layerParameter.rCircleOffsetZ.numDegree0 = this.numEditor_rCircleOffsetZ0.Value;
                this.layerParameter.rCircleOffsetZ.numDegree90 = this.numEditor_rCircleOffsetZ90.Value;
                this.layerParameter.rCircleOffsetZ.numDegree180 = this.numEditor_rCircleOffsetZ180.Value;
                this.layerParameter.rCircleOffsetZ.numDegree270 = this.numEditor_rCircleOffsetZ270.Value;

                this.layerParameter.rCircleRotationX.numDegree0 = this.numEditor_rCircleRotationX0.Value;
                this.layerParameter.rCircleRotationX.numDegree90 = this.numEditor_rCircleRotationX90.Value;
                this.layerParameter.rCircleRotationX.numDegree180 = this.numEditor_rCircleRotationX180.Value;
                this.layerParameter.rCircleRotationX.numDegree270 = this.numEditor_rCircleRotationX270.Value;

                this.layerParameter.rCircleRotationY.numDegree0 = this.numEditor_rCircleRotationY0.Value;
                this.layerParameter.rCircleRotationY.numDegree90 = this.numEditor_rCircleRotationY90.Value;
                this.layerParameter.rCircleRotationY.numDegree180 = this.numEditor_rCircleRotationY180.Value;
                this.layerParameter.rCircleRotationY.numDegree270 = this.numEditor_rCircleRotationY270.Value;

                this.layerParameter.rCircleRotationZ.numDegree0 = this.numEditor_rCircleRotationZ0.Value;
                this.layerParameter.rCircleRotationZ.numDegree90 = this.numEditor_rCircleRotationZ90.Value;
                this.layerParameter.rCircleRotationZ.numDegree180 = this.numEditor_rCircleRotationZ180.Value;
                this.layerParameter.rCircleRotationZ.numDegree270 = this.numEditor_rCircleRotationZ270.Value;

                this.layerParameter.ApplyData(this.rwSystem);

                ABB.Robotics.Controllers.RapidDomain.RapidData boolRapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "WeldSyncModule", "boolRefreshbyLayerParameters");
                ABB.Robotics.Controllers.RapidDomain.Bool bData = new ABB.Robotics.Controllers.RapidDomain.Bool(this.checkBox_boolRefreshbyLayerParameters.Checked);
                boolRapidData.Value = bData;
                boolRapidData.Dispose();

                boolRapidData = rwSystem.Controller.Rapid.GetRapidData("T_ROB1", "WeldSyncModule", "boolRefreshWeldProcedureID");
                bData = new ABB.Robotics.Controllers.RapidDomain.Bool(this.checkBox_boolRefreshWeldProcedureID.Checked);
                boolRapidData.Value = bData;
                boolRapidData.Dispose();

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
            //this.Text = _tpsRm.GetString("TXT_TpsFormWeldingParameterTitle");
            //this.tpsLabel_intGroupIndex.Text = _tpsRm.GetString("TXT_tpsLabel_intGroupIndex");
            //this.tpsLabel_intIndex.Text = _tpsRm.GetString("TXT_tpsLabel_intIndex");
        }

        private void dataEditor_strWeldProcedureID_Click(object sender, EventArgs e)
        {
            this.menuItem_Apply.Enabled = true;
        }

        private void numEditor_intLayerNo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ErrorHandler.AddErrorMessage("MichaelLog", string.Format("numEditor_intLayerNo={0}", this.numEditor_intLayerNo.Value));
            this.Invoke(this.UpdateGUI);
            this.menuItem_Apply.Enabled = false;
        }

    }
}