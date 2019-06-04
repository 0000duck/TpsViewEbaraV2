using System;

using System.Collections.Generic;
using System.Text;

using ABB.Robotics.Controllers.RapidDomain;

using TpsViewEbaraV2NameSpace.Robot;
using ABB.Robotics.ProductionScreen.Base;

namespace TpsViewEbaraV2NameSpace.Ebara
{
    public class WeldProcedure : IDisposable
    {
        private const string strTaskName = "T_ROB1";
        private const string strDataModuleName = "GlobalDataModule";
        private const string strDataName = "rWeldProcedures";
        private const string strDataTypeModuleName = "GeneralModule";
        private const string strDataType = "RECORDWeldProcedure";
        
        #region Fields

        private int groupIndex;
        public int intGroupIndex
        {
            get { return groupIndex; }
            set { groupIndex = value; }
        }

        private int index;
        public int intIndex
        {
            get { return index; }
            set { index = value; }
        }    

        private string weldProcedureID;
        public string strWeldProcedureID
        {
            get { return weldProcedureID; }
            set { weldProcedureID = value; }
        }

        private decimal weldSpeed;
        public decimal numWeldSpeed
        {
            get { return weldSpeed; }
            set { weldSpeed = value; }
        }

        private decimal preFlow;
        public decimal numPreFlow
        {
            get { return preFlow; }
            set { preFlow = value; }
        }

        private decimal sche;
        public decimal numSche
        {
            get { return sche; }
            set { sche = value; }
        }

        private decimal trackCurrent;
        public decimal numTrackCurrent
        {
            get { return trackCurrent; }
            set { trackCurrent = value; }
        }

        private decimal postFlow;
        public decimal numPostFlow
        {
            get { return postFlow; }
            set { postFlow = value; }
        }

        private int weaveShape;
        public int numWeaveShape
        {
            get { return weaveShape; }
            set { weaveShape = value; }
        }

        private int weaveType;
        public int numWeaveType
        {
            get { return weaveType; }
            set { weaveType = value; }
        }

        private decimal weaveLength;
        public decimal numWeaveLength
        {
            get { return weaveLength; }
            set { weaveLength = value; }
        }

        private decimal weaveWidth;
        public decimal numWeaveWidth
        {
            get { return weaveWidth; }
            set { weaveWidth = value; }
        }

        private decimal weaveHeigth;
        public decimal numWeaveHeigth
        {
            get { return weaveHeigth; }
            set { weaveHeigth = value; }
        }

        private decimal dwellLeft;
        public decimal numDwellLeft
        {
            get { return dwellLeft; }
            set { dwellLeft = value; }
        }

        private decimal dwellCenter;
        public decimal numDwellCenter
        {
            get { return dwellCenter; }
            set { dwellCenter = value; }
        }

        private decimal dwellRight;
        public decimal numDwellRight
        {
            get { return dwellRight; }
            set { dwellRight = value; }
        }

        private decimal weaveDir;
        public decimal numWeaveDir
        {
            get { return weaveDir; }
            set { weaveDir = value; }
        }

        private decimal weaveTilt;
        public decimal numWeaveTilt
        {
            get { return weaveTilt; }
            set { weaveTilt = value; }
        }

        private decimal weaveOri;
        public decimal numWeaveOri
        {
            get { return weaveOri; }
            set { weaveOri = value; }
        }

        private decimal weaveBias;
        public decimal numWeaveBias
        {
            get { return weaveBias; }
            set { weaveBias = value; }
        }

        private int trackType;
        public int numTrackType
        {
            get { return trackType; }
            set { trackType = value; }
        }

        private decimal gainY;
        public decimal numGainY
        {
            get { return gainY; }
            set { gainY = value; }
        }

        private decimal gainZ;
        public decimal numGainZ
        {
            get { return gainZ; }
            set { gainZ = value; }
        }

        private decimal penetration;
        public decimal numPenetration
        {
            get { return penetration; }
            set { penetration = value; }
        }

        private decimal trackBias;
        public decimal numTrackBias
        {
            get { return trackBias; }
            set { trackBias = value; }
        }

        private decimal weaveWidth90;
        public decimal numWeaveWidth90
        {
            get { return weaveWidth90; }
            set { weaveWidth90 = value; }
        }      

        private string remark;
        public string strRemark
        {
            get { return remark; }
            set { remark = value; }
        }

        #endregion


        public WeldProcedure()
        {
            this.intGroupIndex = 1;
            this.intIndex = 1;
        }

        #region Dispose

        private bool _disposed;

        ~WeldProcedure()
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
            return string.Format("[\"{0}\",{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},\"{24}\"]"
                , this.strWeldProcedureID, this.numWeldSpeed, this.numPreFlow, this.numSche
                , this.numTrackCurrent, this.numPostFlow, this.numWeaveShape, this.numWeaveType, this.numWeaveLength, this.numWeaveWidth
                , this.numWeaveHeigth, this.numDwellLeft, this.numDwellCenter, this.numDwellRight, this.numWeaveDir
                , this.numWeaveTilt, this.numWeaveOri, this.numWeaveBias, this.numTrackType
                , this.numGainY, this.numGainZ, this.numPenetration, this.numTrackBias, this.numWeaveWidth90, this.strRemark);
        }

        public void RefreshData(RWSystem rwSystem, int intGroupIndex, int intIndex)
        {
            this.intGroupIndex = intGroupIndex;
            this.intIndex = intIndex;

            RapidData rWeldProcedureArray = rwSystem.Controller.Rapid.GetRapidData(strTaskName, strDataModuleName, strDataName + this.intGroupIndex);
            //RapidDataType rWeldProcedureType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rWeldProcedure = (UserDefined)rWeldProcedureArray.ReadItem(this.intIndex);

            int i = 0;
            this.strWeldProcedureID = rWeldProcedure.Components[i++].ToString();
            this.strWeldProcedureID = this.strWeldProcedureID.Substring(1, this.strWeldProcedureID.Length - 2);

            this.numWeldSpeed = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numPreFlow = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.numSche = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numTrackCurrent = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.numPostFlow = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveShape = int.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveType = int.Parse(rWeldProcedure.Components[i++].ToString());

            this.numWeaveLength = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveWidth = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveHeigth = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.numDwellLeft = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numDwellCenter = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numDwellRight = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.numWeaveDir = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveTilt = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.numWeaveOri = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveBias = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numTrackType = int.Parse(rWeldProcedure.Components[i++].ToString());
            this.numGainY = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.numGainZ = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numPenetration = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numTrackBias = decimal.Parse(rWeldProcedure.Components[i++].ToString());
            this.numWeaveWidth90 = decimal.Parse(rWeldProcedure.Components[i++].ToString());

            this.strRemark = rWeldProcedure.Components[i++].ToString();
            this.strRemark = this.strRemark.Substring(1, this.strRemark.Length - 2);

            //rWeldProcedureType.Dispose();
            rWeldProcedure.Dispose();
            rWeldProcedureArray.Dispose();
        }

        public void ApplyData(RWSystem rwSystem)
        {
            RapidData rWeldProcedureArray = rwSystem.Controller.Rapid.GetRapidData(strTaskName, strDataModuleName, strDataName + this.intGroupIndex);
            //RapidDataType rWeldProcedureType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rWeldProcedure = (UserDefined)rWeldProcedureArray.ReadItem(this.intIndex);

            rWeldProcedure.FillFromString(this.ToString());
            ErrorHandler.AddErrorMessage("MichaelLog", this.ToString());
            rWeldProcedureArray.WriteItem(rWeldProcedure, this.intIndex);

            //rWeldProcedureType.Dispose();
            rWeldProcedure.Dispose();
            rWeldProcedureArray.Dispose();
        }
    }
}
