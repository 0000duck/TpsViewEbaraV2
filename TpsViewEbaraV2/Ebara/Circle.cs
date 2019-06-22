using System;

using System.Collections.Generic;
using System.Text;
using ABB.Robotics.Controllers.RapidDomain;
using TpsViewEbaraV2NameSpace.Robot;
using ABB.Robotics.ProductionScreen.Base;

namespace TpsViewEbaraV2NameSpace.Ebara
{
    public class Circle : IDisposable
    {
        private const string strTaskName = "T_ROB1";
        private const string strDataTypeModuleName = "GeneralModule";
        private const string strDataType = "RECORDCircle";

        #region Fields

        private decimal degree0;
        public decimal numDegree0
        {
            get { return degree0; }
            set { degree0 = value; }
        }

        private decimal degree90;
        public decimal numDegree90
        {
            get { return degree90; }
            set { degree90 = value; }
        }

        private decimal degree180;
        public decimal numDegree180
        {
            get { return degree180; }
            set { degree180 = value; }
        }

        private decimal degree270;
        public decimal numDegree270
        {
            get { return degree270; }
            set { degree270 = value; }
        }

        private int curveType;
        public int numCurveType
        {
            get { return curveType; }
            set { curveType = value; }
        }

        #endregion

        /// <summary>
        /// [-5,3,-5,3,1]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3},{4}]"
                , this.numDegree0, this.numDegree90, this.numDegree180, this.numDegree270, this.numCurveType);
        }

        public void RefreshData(RWSystem rwSystem, string strCircle)
        {
            RapidDataType rCircleType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rCircleUserDefine = new UserDefined(rCircleType);
            rCircleUserDefine.FillFromString(strCircle);
           
            int i = 0;
            this.numDegree0 = decimal.Parse(rCircleUserDefine.Components[i++].ToString());
            //ErrorHandler.AddErrorMessage("MichaelLog", rCircleUserDefine.Components[i].ToString());
            this.numDegree90 = decimal.Parse(rCircleUserDefine.Components[i++].ToString());
            this.numDegree180 = decimal.Parse(rCircleUserDefine.Components[i++].ToString());
            this.numDegree270 = decimal.Parse(rCircleUserDefine.Components[i++].ToString());
            this.numCurveType = int.Parse(rCircleUserDefine.Components[i++].ToString());
            
            rCircleUserDefine.Dispose();
            rCircleType.Dispose();
        }

        #region IDisposable Members

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
