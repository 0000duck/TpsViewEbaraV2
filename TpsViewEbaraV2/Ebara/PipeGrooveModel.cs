using System;

using System.Collections.Generic;
using System.Text;

using ABB.Robotics.Controllers.RapidDomain;

using TpsViewEbaraV2NameSpace.Robot;
using ABB.Robotics.ProductionScreen.Base;

namespace TpsViewEbaraV2NameSpace.Ebara
{
    public class PipeGrooveModel : IDisposable
    {
        private const string strTaskName = "T_ROB1";
        private const string strDataModuleName = "GlobalDataModule";
        private const string strDataName = "rPipeGrooveModel";
        private const string strDataTypeModuleName = "GeneralModule";
        private const string strDataType = "RECORDPipeGrooveModel";

        #region Fields

        private int index;
        public int numIndex
        {
            get { return index; }
            set { index = value; }
        }

        private int pipeGrooveType;
        public int numPipeGrooveType
        {
            get { return pipeGrooveType; }
            set { pipeGrooveType = value; }
        }

        private decimal weldLegWidth;
        public decimal numWeldLegWidth
        {
            get { return weldLegWidth; }
            set { weldLegWidth = value; }
        }

        private decimal grooveGap;
        public decimal numGrooveGap
        {
            get { return grooveGap; }
            set { grooveGap = value; }
        }

        private decimal branchGrooveRoot;
        public decimal numBranchGrooveRoot
        {
            get { return branchGrooveRoot; }
            set { branchGrooveRoot = value; }
        }

        private decimal branchGrooveAngle;
        public decimal numBranchGrooveAngle
        {
            get { return branchGrooveAngle; }
            set { branchGrooveAngle = value; }
        }


        private decimal branchGrooveAngle90;
        public decimal numBranchGrooveAngle90
        {
            get { return branchGrooveAngle90; }
            set { branchGrooveAngle90 = value; }
        }

        private decimal topHeight90;
        public decimal numTopHeight90
        {
            get { return topHeight90; }
            set { topHeight90 = value; }
        }

        private decimal bottomHeight90;
        public decimal numBottomHeight90
        {
            get { return bottomHeight90; }
            set { bottomHeight90 = value; }
        }

        private decimal profCosine;
        public decimal numProfCosine
        {
            get { return profCosine; }
            set { profCosine = value; }
        }

        private decimal layerHeight;
        public decimal numLayerHeight
        {
            get { return layerHeight; }
            set { layerHeight = value; }
        }

        private decimal layerPassTotalRoundType;
        public decimal numLayerPassTotalRoundType
        {
            get { return layerPassTotalRoundType; }
            set { layerPassTotalRoundType = value; }
        }

        private decimal seamCenterX;
        public decimal numSeamCenterX
        {
            get { return seamCenterX; }
            set { seamCenterX = value; }
        }

        private decimal seamNormalAngle;
        public decimal numSeamNormalAngle
        {
            get { return seamNormalAngle; }
            set { seamNormalAngle = value; }
        }


        private decimal headerDiameter;
        public decimal numHeaderDiameter
        {
            get { return headerDiameter; }
            set { headerDiameter = value; }
        }

        private decimal headerThickness;
        public decimal numHeaderThickness
        {
            get { return headerThickness; }
            set { headerThickness = value; }
        }

        private int headerMaterial;
        public int numHeaderMaterial
        {
            get { return headerMaterial; }
            set { headerMaterial = value; }
        }


        private decimal branchDiameter;
        public decimal numBranchDiameter
        {
            get { return branchDiameter; }
            set { branchDiameter = value; }
        }

        private decimal branchThickness;
        public decimal numBranchThickness
        {
            get { return branchThickness; }
            set { branchThickness = value; }
        }

        private int branchMaterial;
        public int numBranchMaterial
        {
            get { return branchMaterial; }
            set { branchMaterial = value; }
        }


        private int multiPassTotal;
        public int numMultiPassTotal
        {
            get { return multiPassTotal; }
            set { multiPassTotal = value; }
        }


        private int cooperativeRobots;
        public int numCooperativeRobots
        {
            get { return cooperativeRobots; }
            set { cooperativeRobots = value; }
        }

        private int pathSource;
        public int numPathSource
        {
            get { return pathSource; }
            set { pathSource = value; }
        }

        private int reviseScanBranchType;
        public int numReviseScanBranchType
        {
            get { return reviseScanBranchType; }
            set { reviseScanBranchType = value; }
        }

        private int reviseScanHeaderType;
        public int numReviseScanHeaderType
        {
            get { return reviseScanHeaderType; }
            set { reviseScanHeaderType = value; }
        }

        private int algorithmType;
        public int numAlgorithmType
        {
            get { return algorithmType; }
            set { algorithmType = value; }
        }

        private bool continuous;
        public bool boolContinuous
        {
            get { return continuous; }
            set { continuous = value; }
        }

        private bool useAlignedSTNbyFixedValue;
        public bool boolUseAlignedSTNbyFixedValue
        {
            get { return useAlignedSTNbyFixedValue; }
            set { useAlignedSTNbyFixedValue = value; }
        }

        private string id;
        public string strID
        {
            get { return id; }
            set { id = value; }
        }

        private string remark;
        public string strRemark
        {
            get { return remark; }
            set { remark = value; }
        }

        #endregion

        public PipeGrooveModel()
        {

        }

        #region Dispose

        private bool _disposed;

        ~PipeGrooveModel()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {

            }
            _disposed = true;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        public override string ToString()
        {
            //return string.Format("[{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},\"{28}\",\"{29}\"]"
            //    , this.numIndex, this.numPipeGrooveType, this.numSeamCenterX, this.numSeamNormalAngle
            //    , this.numHeaderDiameter, this.numHeaderThickness, this.numHeaderMaterial, this.numBranchDiameter, this.numBranchThickness, this.numBranchMaterial
            //    , this.numMultiPassTotal, this.numCooperativeRobots, this.numPathSource, this.numReviseScanBranchType, this.numReviseScanHeaderType
            //    , this.numWeldLegWidth, this.numGrooveGap, this.numBranchGrooveRoot, this.numBranchGrooveAngle
            //    , this.numBranchGrooveAngle90, this.numTopHeight90, this.numBottomHeight90, this.numProfCosine, this.numLayerHeight, this.numLayerPassTotalRoundType
            //    , this.boolContinuous.ToString().ToUpper(), this.boolUseAlignedSTNbyFixedValue.ToString().ToUpper(), this.strID, this.strRemark);

            //For a string, don't need quotes "" 
            return string.Format("[{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29}]"
                , this.numIndex, this.numPipeGrooveType, this.numSeamCenterX, this.numSeamNormalAngle
                , this.numHeaderDiameter, this.numHeaderThickness, this.numHeaderMaterial, this.numBranchDiameter, this.numBranchThickness, this.numBranchMaterial
                , this.numMultiPassTotal, this.numCooperativeRobots, this.numPathSource, this.numReviseScanBranchType, this.numReviseScanHeaderType
                , this.numWeldLegWidth, this.numGrooveGap, this.numBranchGrooveRoot, this.numBranchGrooveAngle
                , this.numBranchGrooveAngle90, this.numTopHeight90, this.numBottomHeight90, this.numProfCosine, this.numLayerHeight, this.numLayerPassTotalRoundType, this.numAlgorithmType
                , this.boolContinuous.ToString().ToUpper(), this.boolUseAlignedSTNbyFixedValue.ToString().ToUpper(), this.strID, this.strRemark);
        }

        public void RefreshData(RWSystem rwSystem)
        {
            RapidData rPipeGrooveModel = rwSystem.Controller.Rapid.GetRapidData(strTaskName, strDataModuleName, strDataName);
            RapidDataType rPipeGrooveModelType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rPipeGrooveModelUserDefine = new UserDefined(rPipeGrooveModelType);

            rPipeGrooveModelUserDefine.FillFromString(rPipeGrooveModel.Value.ToString());

            int i = 0;
            this.numIndex = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numPipeGrooveType = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numSeamCenterX = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numSeamNormalAngle = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numHeaderDiameter = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numHeaderThickness = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numHeaderMaterial = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numBranchDiameter = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numBranchThickness = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numBranchMaterial = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numMultiPassTotal = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numCooperativeRobots = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numPathSource = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numReviseScanBranchType = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numReviseScanHeaderType = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numWeldLegWidth = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numGrooveGap = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numBranchGrooveRoot = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numBranchGrooveAngle = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numBranchGrooveAngle90 = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numTopHeight90 = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numBottomHeight90 = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numProfCosine = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.numLayerHeight = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numLayerPassTotalRoundType = decimal.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.numAlgorithmType = int.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.boolContinuous = bool.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());
            this.boolUseAlignedSTNbyFixedValue = bool.Parse(rPipeGrooveModelUserDefine.Components[i++].ToString());

            this.strID = rPipeGrooveModelUserDefine.Components[i++].ToString();
            this.strRemark = rPipeGrooveModelUserDefine.Components[i++].ToString();

            rPipeGrooveModelUserDefine.Dispose();
            rPipeGrooveModelType.Dispose();
            rPipeGrooveModel.Dispose();
        }

        public void ApplyData(RWSystem rwSystem)
        {
            RapidData rPipeGrooveModel = rwSystem.Controller.Rapid.GetRapidData(strTaskName, strDataModuleName, strDataName);
            RapidDataType rPipeGrooveModelType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rPipeGrooveModelUserDefine = new UserDefined(rPipeGrooveModelType);

            rPipeGrooveModelUserDefine.FillFromString(this.ToString());
            ErrorHandler.AddErrorMessage("MichaelLog", this.ToString());
            rPipeGrooveModel.Value = rPipeGrooveModelUserDefine;

            rPipeGrooveModelUserDefine.Dispose();
            rPipeGrooveModelType.Dispose();
            rPipeGrooveModel.Dispose();
        }
    }
}
