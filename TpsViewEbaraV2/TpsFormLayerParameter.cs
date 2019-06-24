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
        private ABB.Robotics.Tps.Windows.Forms.NumericUpDown numericUpDown_intLayerNo;
        private TpsLabel tpsLabel_intLayerNo;
        private DataEditor dataEditor_strWeldProcedureID;
        private TpsLabel tpsLabel_strWeldProcedureID;
        private DataGrid dataGrid_Circle;
        private DataGridTextBoxColumn dataGridTextBoxColumn_numDegree270;
        private DataGridTextBoxColumn dataGridTextBoxColumn_numDegree180;
        private DataGridTextBoxColumn dataGridTextBoxColumn_numDegree90;
        private DataGridTextBoxColumn dataGridTextBoxColumn_numDegree0;
        private DataGridTextBoxColumn dataGridTextBoxColumn_OptimizationType;
        private DataGridTableStyle dataGridTableStyle_Circles;
        private CompactAlphaPad compactAlphaPad1;
        private AlphaPad alphaPad_Circle;
        private DataGridTextBoxColumn dataGridTextBoxColumn5;
        private DataGridTextBoxColumn dataGridTextBoxColumn4;
        private DataGridTextBoxColumn dataGridTextBoxColumn3;
        private DataGridTextBoxColumn dataGridTextBoxColumn2;
        private DataGridTextBoxColumn dataGridTextBoxColumn1;
        private DataGridTableStyle dataGridTableStyle1;
        private DataGridTableStyle dataGridTableStyle3;
        private DataGridTextBoxColumn dataGridTextBoxColumn11;
        private DataGridTextBoxColumn dataGridTextBoxColumn12;
        private DataGridTextBoxColumn dataGridTextBoxColumn13;
        private DataGridTextBoxColumn dataGridTextBoxColumn14;
        private DataGridTextBoxColumn dataGridTextBoxColumn15;
        private DataGridTextBoxColumn dataGridTextBoxColumn10;
        private DataGridTextBoxColumn dataGridTextBoxColumn9;
        private DataGridTextBoxColumn dataGridTextBoxColumn8;
        private DataGridTextBoxColumn dataGridTextBoxColumn7;
        private DataGridTextBoxColumn dataGridTextBoxColumn6;
        private DataGridTableStyle dataGridTableStyle2;

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
                this.numericUpDown_intLayerNo.Value = this.layerParameter.intLayerNo;

                //this.dataGrid_Circle.BackgroundColor = System.Drawing.Color.Red;
                //this.dataGrid_Circle.ForeColor = System.Drawing.Color.Pink;
                //this.dataGrid_Circle.BackColor = System.Drawing.Color.Green;
                //this.dataGrid_Circle.HeaderBackColor = System.Drawing.Color.Orange;
                //this.dataGrid_Circle.HeaderForeColor = System.Drawing.Color.Green;
                //this.dataGrid_Circle.GridLineColor = System.Drawing.Color.Green;
                //this.dataGrid_Circle.SelectionBackColor = System.Drawing.Color.Red;
                //this.dataGrid_Circle.SelectionForeColor = System.Drawing.Color.Violet;

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
                        this.alphaPad_Circle.Dispose();

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
            this.numericUpDown_intLayerNo = new ABB.Robotics.Tps.Windows.Forms.NumericUpDown();
            this.tpsLabel_intLayerNo = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.dataEditor_strWeldProcedureID = new ABB.Robotics.Tps.Windows.Forms.DataEditor();
            this.tpsLabel_strWeldProcedureID = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.dataGrid_Circle = new System.Windows.Forms.DataGrid();
            this.dataGridTextBoxColumn_numDegree270 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn_numDegree180 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn_numDegree90 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn_numDegree0 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn_OptimizationType = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle_Circles = new System.Windows.Forms.DataGridTableStyle();
            this.compactAlphaPad1 = new ABB.Robotics.Tps.Windows.Forms.CompactAlphaPad();
            this.alphaPad_Circle = new ABB.Robotics.Tps.Windows.Forms.AlphaPad();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn10 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn9 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn8 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTableStyle3 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn11 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn12 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn13 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn14 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn15 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            // numericUpDown_intLayerNo
            // 
            this.numericUpDown_intLayerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown_intLayerNo.CaretVisible = false;
            this.numericUpDown_intLayerNo.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.numericUpDown_intLayerNo.Location = new System.Drawing.Point(116, 41);
            this.numericUpDown_intLayerNo.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numericUpDown_intLayerNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intLayerNo.Multiline = true;
            this.numericUpDown_intLayerNo.Name = "numericUpDown_intLayerNo";
            this.numericUpDown_intLayerNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.numericUpDown_intLayerNo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.numericUpDown_intLayerNo.SelectionLength = 0;
            this.numericUpDown_intLayerNo.SelectionStart = 0;
            this.numericUpDown_intLayerNo.SelectionVisible = false;
            this.numericUpDown_intLayerNo.Size = new System.Drawing.Size(124, 40);
            this.numericUpDown_intLayerNo.TabIndex = 9;
            this.numericUpDown_intLayerNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.numericUpDown_intLayerNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intLayerNo.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.numericUpDown_intLayerNo_PropertyChanged);
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
            // tpsLabel_strWeldProcedureID
            // 
            this.tpsLabel_strWeldProcedureID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_strWeldProcedureID.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.tpsLabel_strWeldProcedureID.Location = new System.Drawing.Point(269, 41);
            this.tpsLabel_strWeldProcedureID.Multiline = true;
            this.tpsLabel_strWeldProcedureID.Name = "tpsLabel_strWeldProcedureID";
            this.tpsLabel_strWeldProcedureID.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_strWeldProcedureID.Size = new System.Drawing.Size(169, 24);
            this.tpsLabel_strWeldProcedureID.TabIndex = 31;
            this.tpsLabel_strWeldProcedureID.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.tpsLabel_strWeldProcedureID.Title = "Weld Procedure ID";
            // 
            // dataGrid_Circle
            // 
            this.dataGrid_Circle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid_Circle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular);
            this.dataGrid_Circle.Location = new System.Drawing.Point(13, 87);
            this.dataGrid_Circle.Name = "dataGrid_Circle";
            this.dataGrid_Circle.Size = new System.Drawing.Size(480, 254);
            this.dataGrid_Circle.TabIndex = 33;
            this.dataGrid_Circle.TableStyles.Add(this.dataGridTableStyle3);
            this.dataGrid_Circle.CurrentCellChanged += new System.EventHandler(this.dataGrid_Circle_CurrentCellChanged);
            // 
            // dataGridTextBoxColumn_numDegree270
            // 
            this.dataGridTextBoxColumn_numDegree270.Format = "";
            this.dataGridTextBoxColumn_numDegree270.FormatInfo = null;
            this.dataGridTextBoxColumn_numDegree270.HeaderText = "numDegree270";
            this.dataGridTextBoxColumn_numDegree270.MappingName = "numDegree270";
            // 
            // dataGridTextBoxColumn_numDegree180
            // 
            this.dataGridTextBoxColumn_numDegree180.Format = "";
            this.dataGridTextBoxColumn_numDegree180.FormatInfo = null;
            this.dataGridTextBoxColumn_numDegree180.HeaderText = "numDegree180";
            this.dataGridTextBoxColumn_numDegree180.MappingName = "numDegree180";
            // 
            // dataGridTextBoxColumn_numDegree90
            // 
            this.dataGridTextBoxColumn_numDegree90.Format = "";
            this.dataGridTextBoxColumn_numDegree90.FormatInfo = null;
            this.dataGridTextBoxColumn_numDegree90.HeaderText = "numDegree90";
            this.dataGridTextBoxColumn_numDegree90.MappingName = "numDegree90";
            // 
            // dataGridTextBoxColumn_numDegree0
            // 
            this.dataGridTextBoxColumn_numDegree0.Format = "";
            this.dataGridTextBoxColumn_numDegree0.FormatInfo = null;
            this.dataGridTextBoxColumn_numDegree0.HeaderText = "numDegree0";
            this.dataGridTextBoxColumn_numDegree0.MappingName = "numDegree0";
            // 
            // dataGridTextBoxColumn_OptimizationType
            // 
            this.dataGridTextBoxColumn_OptimizationType.Format = "";
            this.dataGridTextBoxColumn_OptimizationType.FormatInfo = null;
            this.dataGridTextBoxColumn_OptimizationType.HeaderText = "OptimizationType";
            this.dataGridTextBoxColumn_OptimizationType.MappingName = "OptimizationType";
            // 
            // dataGridTableStyle_Circles
            // 
            this.dataGridTableStyle_Circles.GridColumnStyles.Add(this.dataGridTextBoxColumn_OptimizationType);
            this.dataGridTableStyle_Circles.GridColumnStyles.Add(this.dataGridTextBoxColumn_numDegree0);
            this.dataGridTableStyle_Circles.GridColumnStyles.Add(this.dataGridTextBoxColumn_numDegree90);
            this.dataGridTableStyle_Circles.GridColumnStyles.Add(this.dataGridTextBoxColumn_numDegree180);
            this.dataGridTableStyle_Circles.GridColumnStyles.Add(this.dataGridTextBoxColumn_numDegree270);
            this.dataGridTableStyle_Circles.MappingName = "Circles";
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
            // alphaPad_Circle
            // 
            this.alphaPad_Circle.ControlBorderStyle = System.Windows.Forms.BorderStyle.None;
            this.alphaPad_Circle.EnableStringSelectorMenuItem = true;
            this.alphaPad_Circle.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.alphaPad_Circle.FormAppearance = false;
            this.alphaPad_Circle.Icon = null;
            this.alphaPad_Circle.Name = "AlphaPad";
            this.alphaPad_Circle.SelectedText = "";
            this.alphaPad_Circle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.alphaPad_Circle.Size = new System.Drawing.Size(639, 390);
            this.alphaPad_Circle.TabIndex = 0;
            this.alphaPad_Circle.Closing += new System.ComponentModel.CancelEventHandler(this.alphaPad_Circle_Closing);
            this.alphaPad_Circle.Closed += new System.EventHandler(this.alphaPad_Circle_Closed);
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "270";
            this.dataGridTextBoxColumn5.MappingName = "numDegree270";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "180";
            this.dataGridTextBoxColumn4.MappingName = "numDegree180";
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "90";
            this.dataGridTextBoxColumn3.MappingName = "numDegree90";
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "0";
            this.dataGridTextBoxColumn2.MappingName = "numDegree0";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "Type";
            this.dataGridTextBoxColumn1.MappingName = "OptimizationType";
            this.dataGridTextBoxColumn1.Width = 140;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.MappingName = "Circles";
            // 
            // dataGridTextBoxColumn10
            // 
            this.dataGridTextBoxColumn10.Format = "";
            this.dataGridTextBoxColumn10.FormatInfo = null;
            this.dataGridTextBoxColumn10.HeaderText = "270";
            this.dataGridTextBoxColumn10.MappingName = "numDegree270";
            // 
            // dataGridTextBoxColumn9
            // 
            this.dataGridTextBoxColumn9.Format = "";
            this.dataGridTextBoxColumn9.FormatInfo = null;
            this.dataGridTextBoxColumn9.HeaderText = "180";
            this.dataGridTextBoxColumn9.MappingName = "numDegree180";
            // 
            // dataGridTextBoxColumn8
            // 
            this.dataGridTextBoxColumn8.Format = "";
            this.dataGridTextBoxColumn8.FormatInfo = null;
            this.dataGridTextBoxColumn8.HeaderText = "90";
            this.dataGridTextBoxColumn8.MappingName = "numDegree90";
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "0";
            this.dataGridTextBoxColumn7.MappingName = "numDegree0";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "Type";
            this.dataGridTextBoxColumn6.MappingName = "OptimizationType";
            this.dataGridTextBoxColumn6.Width = 140;
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn8);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn9);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn10);
            this.dataGridTableStyle2.MappingName = "Circles";
            // 
            // dataGridTableStyle3
            // 
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn11);
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn12);
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn13);
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn14);
            this.dataGridTableStyle3.GridColumnStyles.Add(this.dataGridTextBoxColumn15);
            this.dataGridTableStyle3.MappingName = "Circles";
            // 
            // dataGridTextBoxColumn11
            // 
            this.dataGridTextBoxColumn11.Format = "";
            this.dataGridTextBoxColumn11.FormatInfo = null;
            this.dataGridTextBoxColumn11.HeaderText = "Type";
            this.dataGridTextBoxColumn11.MappingName = "OptimizationType";
            this.dataGridTextBoxColumn11.Width = 140;
            // 
            // dataGridTextBoxColumn12
            // 
            this.dataGridTextBoxColumn12.Format = "";
            this.dataGridTextBoxColumn12.FormatInfo = null;
            this.dataGridTextBoxColumn12.HeaderText = "0";
            this.dataGridTextBoxColumn12.MappingName = "numDegree0";
            // 
            // dataGridTextBoxColumn13
            // 
            this.dataGridTextBoxColumn13.Format = "";
            this.dataGridTextBoxColumn13.FormatInfo = null;
            this.dataGridTextBoxColumn13.HeaderText = "90";
            this.dataGridTextBoxColumn13.MappingName = "numDegree90";
            // 
            // dataGridTextBoxColumn14
            // 
            this.dataGridTextBoxColumn14.Format = "";
            this.dataGridTextBoxColumn14.FormatInfo = null;
            this.dataGridTextBoxColumn14.HeaderText = "180";
            this.dataGridTextBoxColumn14.MappingName = "numDegree180";
            // 
            // dataGridTextBoxColumn15
            // 
            this.dataGridTextBoxColumn15.Format = "";
            this.dataGridTextBoxColumn15.FormatInfo = null;
            this.dataGridTextBoxColumn15.HeaderText = "270";
            this.dataGridTextBoxColumn15.MappingName = "numDegree270";
            // 
            // TpsFormLayerParameter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.dataGrid_Circle);
            this.Controls.Add(this.dataEditor_strWeldProcedureID);
            this.Controls.Add(this.tpsLabel_strWeldProcedureID);
            this.Controls.Add(this.numericUpDown_intLayerNo);
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
            this.Controls.SetChildIndex(this.numericUpDown_intLayerNo, 0);
            this.Controls.SetChildIndex(this.tpsLabel_strWeldProcedureID, 0);
            this.Controls.SetChildIndex(this.dataEditor_strWeldProcedureID, 0);
            this.Controls.SetChildIndex(this.dataGrid_Circle, 0);
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
                this.layerParameter.RefreshData(this.rwSystem, Convert.ToInt32(this.numericUpDown_intLayerNo.Value));
                this.dataEditor_strWeldProcedureID.Text = this.layerParameter.strLayerParameterID;
                if (this.dataGrid_Circle.DataSource == null)
                {
                    this.dataGrid_Circle.DataSource = this.layerParameter.CircleView;
                }                
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

                this.layerParameter.ApplyData(this.rwSystem);

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

        private void dataGrid_Circle_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dataGrid_Circle.CurrentCell.ColumnNumber > 0)
            {
                string strOptimizationType = this.dataGrid_Circle[this.dataGrid_Circle.CurrentCell.RowNumber, this.dataGrid_Circle.CurrentCell.ColumnNumber].ToString();
                this.alphaPad_Circle.SelectedText = strOptimizationType;
                this.alphaPad_Circle.ShowMe(this);
            }
        }

        private void numericUpDown_intLayerNo_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Invoke(this.UpdateGUI);
            this.menuItem_Apply.Enabled = false;
        }

        private void alphaPad_Circle_Closed(object sender, EventArgs e)
        {
            string strOptimizationType = this.dataGrid_Circle[this.dataGrid_Circle.CurrentCell.RowNumber,0].ToString();
            DataRow row = this.layerParameter.CircleTable.Rows.Find(strOptimizationType);
            if (row != null)
            {
                if (this.alphaPad_Circle.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    row[this.dataGrid_Circle.CurrentCell.ColumnNumber] = this.alphaPad_Circle.SelectedText;
                    //this.dataGrid_Circle[this.dataGrid_Circle.CurrentCell.RowNumber, this.dataGrid_Circle.CurrentCell.ColumnNumber] = this.alphaPad_Circle.SelectedText;
                    this.menuItem_Apply.Enabled = true;
                }
            }
        }

        private void alphaPad_Circle_Closing(object sender, CancelEventArgs e)
        {
            if ((!Regex.IsMatch(this.alphaPad_Circle.SelectedText, @"^[+-]?\d*[.]?\d*$")) && (this.alphaPad_Circle.DialogResult == System.Windows.Forms.DialogResult.OK))
            {
                e.Cancel = true;
            }
        }


    }
}