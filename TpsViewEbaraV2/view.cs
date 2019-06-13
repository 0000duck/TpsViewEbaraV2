using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

// ABB namespaces
using ABB.Robotics.Controllers;
using ABB.Robotics.Tps.Taf;
using ABB.Robotics.Tps.Windows.Forms;
using ABB.Robotics.Tps.Resources;
using ABB.Robotics.Diagnostics;

using ABB.Robotics.ProductionScreen;
using ABB.Robotics.ProductionScreen.Base;

using TpsViewEbaraV2NameSpace.Robot;
using TpsViewEbaraV2NameSpace.Ebara;

//
// The ProductionScreenApp attribute is used by the SetupEditor to help the user to 
// fill in the needed fields that may be a bit hard to find out otherwise.
//
// Note: The attribute is not needed to run the app
//

[module: ProductionScreenApp(
Assembly = "TpsViewEbaraV2.dll",							// Name of the assembly
Type = "TpsViewEbaraV2NameSpace.TpsViewEbaraV2",		// Name of the type, ie <namespace>.<class>
About = "Text about this widget.",							// Description of the widget (tooltip in SetupEditor)
IndataHelp = "Text about the indata.")]						// Help text for indata (tooltip in SetupEditor)

namespace TpsViewEbaraV2NameSpace
{
    /// <summary>
    /// Summary description of the view.
    /// </summary>
    public class TpsViewEbaraV2 : TpsForm, ITpsViewSetup, ITpsViewActivation
    {

        #region MultiView

        private enum ActiveView
        {
            Desktop = 0, // The view represented by this class, (first view with PipeGrooveModel and Setting buttons)
            PipeGrooveModel = 1,
            Setting = 2,
            WeldingParameter=3,
            WobjCurrent=4,
        }

        private PipeGrooveModel pipeGrooveModel = null;
        private WeldProcedure weldProcedure = null;
        private RWSystem rwSystem = null;

        //application views 
        private TpsFormPipeGrooveModel _viewPipeGrooveModel = null;
        private TpsFormSetting _viewSetting = null;
        private TpsFormWeldingParameter _viewWeldingParameter = null;
        private TpsFormWobjCurrent _viewWobjCurrent = null;

        //sets this first view to the currently active view
        private ActiveView _activeView = ActiveView.Desktop;

        //flags
        private bool _isExecuting = false;
        private bool _isInAuto = false;
        private bool _appInFocus = true;

        //needed to launch standard FP apps from this app.
        private ITpsViewLaunchServices _iTpsSite;

        //handles images
        private TpsResourceManager _tpsRm = null;

        #endregion
        private ABB.Robotics.Tps.Windows.Forms.Button button_PipeGrooveModel;
        private TpsLabel tpsLabel_EbaraUtility;
        private ABB.Robotics.Tps.Windows.Forms.PictureBox pictureBox_Logo;
        private ABB.Robotics.Tps.Windows.Forms.Button button_Setting;
        private ABB.Robotics.Tps.Windows.Forms.Button button_WeldingParameter;
        private ABB.Robotics.Tps.Windows.Forms.Button button_wobjCurrent;

        private const string CURRENT_MODULE_NAME = "TpsViewEbaraV2";

        public TpsViewEbaraV2()
        {
            //
            // Required for Windows Form Designer support
            //
               
            try
            {
                //_tpsRm = new TpsResourceManager();
                _tpsRm = new ABB.Robotics.Tps.Resources.TpsResourceManager("TpsViewEbaraV2NameSpace.strings", ABB.Robotics.Taf.Base.TafAssembly.Load("TpsViewEbaraV2Texts.dll"));
                InitializeComponent();
                InitializeTexts();
 
                // The Install method, which runs after the constructor, creates the robot controller instance and 
                // starts the controller subscriptions needed in this view.
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

            //
            // ToDo: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// This is where you clean up any remaining resources used by your application before 
        /// the application itself is disposed of by the host (TAF - TeachPendant Application Framework). 
        /// The method is called by the host when the application is closed down.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed)
            {
                try
                {
                    if (disposing)
                    {
                        //ToDo: Call the Dispose method of all FP SDK instances that may otherwise cause memory leak
  
                        if (this.rwSystem != null)
                        {
                            this.rwSystem.Dispose();
                            this.rwSystem = null;
                        }
                        if (this._viewPipeGrooveModel != null)
                        {
                            this._viewPipeGrooveModel.Dispose();
                            this._viewPipeGrooveModel = null;
                        }
                        if (this._viewSetting != null)
                        {
                            this._viewSetting.Dispose();
                            this._viewSetting = null;
                        }
                        if (this._viewWeldingParameter != null)
                        {
                            this._viewWeldingParameter.Dispose();
                            this._viewWeldingParameter = null;
                        }
                        if (this._viewWobjCurrent != null)
                        {
                            this._viewWobjCurrent.Dispose();
                            this._viewWobjCurrent = null;
                        }

                        if (this.pipeGrooveModel != null)
                        {
                            this.pipeGrooveModel.Dispose();
                            this.pipeGrooveModel = null;
                        }
                        if (this.weldProcedure != null)
                        {
                            this.weldProcedure.Dispose();
                            this.weldProcedure = null;
                        }       

                        if (this._tpsRm != null)
                        {
                            this._tpsRm = null;
                        }
                    }

                }
                catch (System.Exception ex)
                {
                    GTPUMessageBox.Show(this.Parent.Parent, null
                        , "An unexpected error occurred while closing down the application.\n\nError message: " + ex.Message
                        , "Application Error"
                        , MessageBoxIcon.Hand, MessageBoxButtons.OK);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TpsViewEbaraV2));
            this.button_PipeGrooveModel = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.tpsLabel_EbaraUtility = new ABB.Robotics.Tps.Windows.Forms.TpsLabel();
            this.pictureBox_Logo = new ABB.Robotics.Tps.Windows.Forms.PictureBox();
            this.button_Setting = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.button_WeldingParameter = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.button_wobjCurrent = new ABB.Robotics.Tps.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_PipeGrooveModel
            // 
            this.button_PipeGrooveModel.BackColor = System.Drawing.Color.White;
            this.button_PipeGrooveModel.BackgroundImage = null;
            this.button_PipeGrooveModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_PipeGrooveModel.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_PipeGrooveModel.Image = null;
            this.button_PipeGrooveModel.Location = new System.Drawing.Point(34, 160);
            this.button_PipeGrooveModel.Name = "button_PipeGrooveModel";
            this.button_PipeGrooveModel.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_PipeGrooveModel.Size = new System.Drawing.Size(120, 120);
            this.button_PipeGrooveModel.TabIndex = 2;
            this.button_PipeGrooveModel.Text = "Model";
            this.button_PipeGrooveModel.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_PipeGrooveModel.Click += new System.EventHandler(this.button_PipeGrooveModel_Click);
            // 
            // tpsLabel_EbaraUtility
            // 
            this.tpsLabel_EbaraUtility.BackColor = System.Drawing.Color.LightGray;
            this.tpsLabel_EbaraUtility.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tpsLabel_EbaraUtility.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font18b;
            this.tpsLabel_EbaraUtility.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.tpsLabel_EbaraUtility.Location = new System.Drawing.Point(94, 70);
            this.tpsLabel_EbaraUtility.Multiline = true;
            this.tpsLabel_EbaraUtility.Name = "tpsLabel_EbaraUtility";
            this.tpsLabel_EbaraUtility.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.tpsLabel_EbaraUtility.Size = new System.Drawing.Size(414, 61);
            this.tpsLabel_EbaraUtility.TabIndex = 3;
            this.tpsLabel_EbaraUtility.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.tpsLabel_EbaraUtility.Title = "Ebara Utility";
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
            this.pictureBox_Logo.TabIndex = 6;
            // 
            // button_Setting
            // 
            this.button_Setting.BackColor = System.Drawing.Color.White;
            this.button_Setting.BackgroundImage = null;
            this.button_Setting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_Setting.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_Setting.Image = null;
            this.button_Setting.Location = new System.Drawing.Point(188, 160);
            this.button_Setting.Name = "button_Setting";
            this.button_Setting.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_Setting.Size = new System.Drawing.Size(120, 120);
            this.button_Setting.TabIndex = 7;
            this.button_Setting.Text = "Setting";
            this.button_Setting.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_Setting.Click += new System.EventHandler(this.button_Setting_Click);
            // 
            // button_WeldingParameter
            // 
            this.button_WeldingParameter.BackColor = System.Drawing.Color.White;
            this.button_WeldingParameter.BackgroundImage = null;
            this.button_WeldingParameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_WeldingParameter.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_WeldingParameter.Image = null;
            this.button_WeldingParameter.Location = new System.Drawing.Point(343, 160);
            this.button_WeldingParameter.Name = "button_WeldingParameter";
            this.button_WeldingParameter.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_WeldingParameter.Size = new System.Drawing.Size(120, 120);
            this.button_WeldingParameter.TabIndex = 8;
            this.button_WeldingParameter.Text = "Welding";
            this.button_WeldingParameter.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_WeldingParameter.Click += new System.EventHandler(this.button_WeldingParameter_Click);
            // 
            // button_wobjCurrent
            // 
            this.button_wobjCurrent.BackColor = System.Drawing.Color.White;
            this.button_wobjCurrent.BackgroundImage = null;
            this.button_wobjCurrent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.button_wobjCurrent.Font = ABB.Robotics.Tps.Windows.Forms.TpsFont.Font12b;
            this.button_wobjCurrent.Image = null;
            this.button_wobjCurrent.Location = new System.Drawing.Point(501, 160);
            this.button_wobjCurrent.Name = "button_wobjCurrent";
            this.button_wobjCurrent.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(172)))), ((int)(((byte)(182)))));
            this.button_wobjCurrent.Size = new System.Drawing.Size(120, 120);
            this.button_wobjCurrent.TabIndex = 9;
            this.button_wobjCurrent.Text = "wobjCurrent";
            this.button_wobjCurrent.TextAlign = ABB.Robotics.Tps.Windows.Forms.ContentAlignmentABB.MiddleCenter;
            this.button_wobjCurrent.Click += new System.EventHandler(this.button_wobjCurrent_Click);
            // 
            // TpsViewEbaraV2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.button_wobjCurrent);
            this.Controls.Add(this.button_WeldingParameter);
            this.Controls.Add(this.button_Setting);
            this.Controls.Add(this.pictureBox_Logo);
            this.Controls.Add(this.tpsLabel_EbaraUtility);
            this.Controls.Add(this.button_PipeGrooveModel);
            this.Size = new System.Drawing.Size(640, 390);
            this.Text = "Ebara Utility";
            this.Controls.SetChildIndex(this.button_PipeGrooveModel, 0);
            this.Controls.SetChildIndex(this.tpsLabel_EbaraUtility, 0);
            this.Controls.SetChildIndex(this.pictureBox_Logo, 0);
            this.Controls.SetChildIndex(this.button_Setting, 0);
            this.Controls.SetChildIndex(this.button_WeldingParameter, 0);
            this.Controls.SetChildIndex(this.button_wobjCurrent, 0);
            this.ResumeLayout(false);

        }
        #endregion

        #region ITpsViewSetup Members

        /// <summary>
        /// This method is called by TAF when the control is closed down (before Dispose is called).
        /// </summary>	
        void ITpsViewSetup.Uninstall()
        {
            try
            {
                // Do uninstall

            }
            catch (Exception ex)
            {
                // Add error message to "ProdScr.log" file
                ErrorHandler.AddErrorMessage(CURRENT_MODULE_NAME, ex.ToString());
            }
        }

        /// <summary>
        /// This method is called by TAF when the control is installed in the framework (after the constructor is called).
        /// </summary>				
        bool ITpsViewSetup.Install(object sender, object data)
        {        
            try
            {
                // Do install
                this.rwSystem = new RWSystem();
                this.pipeGrooveModel = new PipeGrooveModel();
                this.weldProcedure = new WeldProcedure();

                if (sender is ITpsViewLaunchServices)
                {
                    this._iTpsSite = sender as ITpsViewLaunchServices;
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                // Add error message to "ProdScr.log" file
                ErrorHandler.AddErrorMessage(CURRENT_MODULE_NAME, ex.ToString());
                ExceptionHandler.ReThrowException("TpsViewEbaraV2", "ITpsViewActivation.Install", ex);
                return false;
            }
        }

        #endregion

        #region ITpsViewActivation Members

        /// <summary>
        /// This method is called by TAF when the control goes from the active state to the passive state, 
        /// and is no longer visible in the client view. This happens when the user presses another application button 
        /// on the task bar, or closes the application. Normally, any subscriptions to controller events are removed here.
        /// </summary>				
        void ITpsViewActivation.Deactivate()
        {
            try
            {
                if (_activeView == ActiveView.PipeGrooveModel)
                {
                    // this._viewPipeGrooveModel.UnSubscribe();
                }
                else if (_activeView == ActiveView.Setting)
                {
                    // this._viewPipeGrooveModel.UnSubscribe();
                }
                else if (_activeView == ActiveView.WeldingParameter)
                {
                    // this._viewWeldingParameter.UnSubscribe();
                }
                else if (_activeView == ActiveView.WobjCurrent)
                {
                    // this._viewWobjCurrent.UnSubscribe();
                }

                _appInFocus = false;
            }
            catch (Exception ex)
            {
                // Add error message to "ProdScr.log" file
                ErrorHandler.AddErrorMessage(CURRENT_MODULE_NAME, ex.ToString());
            }
        }

        /// <summary>
        /// This method is called by TAF when the control goes from the passive state to the active state, 
        /// i.e. becomes visible in the client view. Normally, this is where subscriptions to controller events are set up.
        /// </summary>				
        void ITpsViewActivation.Activate()
        {
            try
            {
                if (_activeView == ActiveView.Desktop) // If first view is active
                {
                    //this.pictureBox_Logo.Image = Properties.Resources.Logo;
                }
                else if (_activeView == ActiveView.PipeGrooveModel)
                {
                    _viewPipeGrooveModel.Activate();
                }
                else if (_activeView == ActiveView.Setting)
                {
                    _viewSetting.Activate();
                }
                else if (_activeView == ActiveView.WeldingParameter)
                {
                    _viewWeldingParameter.Activate();
                }
                else if (_activeView == ActiveView.WobjCurrent)
                {
                    _viewWobjCurrent.Activate();
                }

                _appInFocus = true;

            }
            catch (Exception ex)
            {
                // Add error message to "ProdScr.log" file
                ErrorHandler.AddErrorMessage(CURRENT_MODULE_NAME, ex.ToString());
                ExceptionHandler.ReThrowException("TpsViewEbara", "ITpsViewActivation.Activate", ex);
            }
        }

        #endregion

        private void button_PipeGrooveModel_Click(object sender, EventArgs e)
        {
            try
            {
                // Wait cursor if it is performance demanding to open the view...
                Cursor.Current = Cursors.WaitCursor;

                // Set active view 
                _activeView = ActiveView.PipeGrooveModel;

                // Create view
                _viewPipeGrooveModel = new TpsFormPipeGrooveModel(this._tpsRm, this.rwSystem, this.pipeGrooveModel);

                // Set up subscription to Closing event of Production view
                _viewPipeGrooveModel.Closing += new System.ComponentModel.CancelEventHandler(_onViewClosing);
                _viewPipeGrooveModel.Closed += new EventHandler(_viewClosed);
                _viewPipeGrooveModel.ShowMe(this);

                // Ask Production view to set up its subscriptions to controller events
                _viewPipeGrooveModel.Activate();
            }
            catch (System.Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void DisplayErrorMessage(string message)
        {
            // Show GTPUMessageBox on exception
            GTPUMessageBox.Show(this.Parent.Parent, null
                , string.Format("Unable to open {0} view. \n\nDo the preparations described in 'Prepare signals and RAPID data.doc' and try open the view again.\n\nError message: {1}", "", message)
                , string.Format("{0}Start-up Error", "")
                , System.Windows.Forms.MessageBoxIcon.Hand, System.Windows.Forms.MessageBoxButtons.OK);
        }

        /// <summary>
        /// Executes when Close button of Production/Test view is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void _onViewClosing(object sender, System.ComponentModel.CancelEventArgs args)
        {
            try
            {
                // Set active view

                _activeView = ActiveView.Desktop;
 

            }
            catch (System.Exception ex)
            {
                Debug.Assert(false, "_onViewClosing failed with message: ", ex.ToString());
            }
        }

        void _viewClosed(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                ((Control)sender).Dispose();
            }
        }

        void InitializeTexts()
        {
            this.tpsLabel_EbaraUtility.Text = _tpsRm.GetString("TXT_EbaraUtility");
            this.Text = _tpsRm.GetString("TXT_EbaraUtilityTitle");
            this.button_PipeGrooveModel.Text = _tpsRm.GetString("TXT_PipeGrooveModelButton");
            this.button_Setting.Text = _tpsRm.GetString("TXT_button_Setting");
            this.button_WeldingParameter.Text = _tpsRm.GetString("TXT_button_WeldingParameter");

        }

        private void button_Setting_Click(object sender, EventArgs e)
        {
            try
            {
                // Wait cursor if it is performance demanding to open the view...
                Cursor.Current = Cursors.WaitCursor;

                // Set active view 
                _activeView = ActiveView.Setting;

                // Create view
                _viewSetting = new TpsFormSetting(this._tpsRm, this.rwSystem);

                // Set up subscription to Closing event of Production view
                _viewSetting.Closing += new System.ComponentModel.CancelEventHandler(_onViewClosing);
                _viewSetting.Closed += new EventHandler(_viewClosed);
                _viewSetting.ShowMe(this);

                // Ask Production view to set up its subscriptions to controller events
                _viewSetting.Activate();
            }
            catch (System.Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button_WeldingParameter_Click(object sender, EventArgs e)
        {
            try
            {
                // Wait cursor if it is performance demanding to open the view...
                Cursor.Current = Cursors.WaitCursor;

                // Set active view 
                _activeView = ActiveView.WeldingParameter;

                // Create view
                _viewWeldingParameter = new TpsFormWeldingParameter(this._tpsRm, this.rwSystem, this.weldProcedure);

                // Set up subscription to Closing event of Production view
                _viewWeldingParameter.Closing += new System.ComponentModel.CancelEventHandler(_onViewClosing);
                _viewWeldingParameter.Closed += new EventHandler(_viewClosed);
                _viewWeldingParameter.ShowMe(this);

                // Ask Production view to set up its subscriptions to controller events
                _viewWeldingParameter.Activate();
            }
            catch (System.Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button_wobjCurrent_Click(object sender, EventArgs e)
        {
            try
            {
                // Wait cursor if it is performance demanding to open the view...
                Cursor.Current = Cursors.WaitCursor;

                // Set active view 
                _activeView = ActiveView.WobjCurrent;

                // Create view
                _viewWobjCurrent = new TpsFormWobjCurrent(this._tpsRm, this.rwSystem, this.pipeGrooveModel);

                // Set up subscription to Closing event of Production view
                _viewWobjCurrent.Closing += new System.ComponentModel.CancelEventHandler(_onViewClosing);
                _viewWobjCurrent.Closed += new EventHandler(_viewClosed);
                _viewWobjCurrent.ShowMe(this);

                // Ask Production view to set up its subscriptions to controller events
                _viewWobjCurrent.Activate();
            }
            catch (System.Exception ex)
            {
                DisplayErrorMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }


    }
}
