using System;

using System.Collections.Generic;
using System.Text;
using System.Data;

using ABB.Robotics.Controllers.RapidDomain;
using TpsViewEbaraV2NameSpace.Robot;
using ABB.Robotics.ProductionScreen.Base;

namespace TpsViewEbaraV2NameSpace.Ebara
{
    public class LayerParameter : IDisposable
    {     
        private const string strTaskName = "T_ROB1";
        private const string strDataModuleName = "GlobalDataModule";
        private const string strDataName = "rLayerParameter";
        private const string strDataTypeModuleName = "GeneralModule";
        private const string strDataType = "RECORDLayerParameter";

        public DataTable CircleTable = new DataTable("Circles");
        public DataView CircleView = null;

        #region Fields

        private int layerNo;
        public int intLayerNo
        {
            get { return layerNo; }
            set { layerNo = value; }
        }

        private int workAngleDeclination;
        public int numWorkAngleDeclination
        {
            get { return workAngleDeclination; }
            set { workAngleDeclination = value; }
        }

        private Circle circleOffsetX;
        public Circle rCircleOffsetX
        {
            get { return circleOffsetX; }
            set { circleOffsetX = value; }
        }

        private Circle circleOffsetY;
        public Circle rCircleOffsetY
        {
            get { return circleOffsetY; }
            set { circleOffsetY = value; }
        }

        private Circle circleRotationX;
        public Circle rCircleRotationX
        {
            get { return circleRotationX; }
            set { circleRotationX = value; }
        }

        private Circle circleRotationY;
        public Circle rCircleRotationY
        {
            get { return circleRotationY; }
            set { circleRotationY = value; }
        }

        private Circle circleRotationZ;
        public Circle rCircleRotationZ
        {
            get { return circleRotationZ; }
            set { circleRotationZ = value; }
        }

        private string LayerParameterID;
        public string strLayerParameterID
        {
            get { return LayerParameterID; }
            set { LayerParameterID = value; }
        }

        #endregion

        public LayerParameter()
        {
            this.intLayerNo = 1;
            this.circleOffsetX = new Circle();
            this.circleOffsetY = new Circle();
            this.circleRotationX = new Circle();
            this.circleRotationY = new Circle();
            this.circleRotationZ = new Circle();

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "optimizationType";
            column.AutoIncrement = false;
            column.Caption = "optimizationType";
            column.ReadOnly = true;
            column.Unique = true;
            CircleTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "numDegree0";
            column.AutoIncrement = false;
            column.Caption = "numDegree0";
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = 0;
            CircleTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "numDegree90";
            column.AutoIncrement = false;
            column.Caption = "numDegree90";
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = 0;
            CircleTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "numDegree180";
            column.AutoIncrement = false;
            column.Caption = "numDegree180";
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = 0;
            CircleTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Decimal");
            column.ColumnName = "numDegree270";
            column.AutoIncrement = false;
            column.Caption = "numDegree270";
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = 0;
            CircleTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "numCurveType";
            column.AutoIncrement = false;
            column.Caption = "numCurveType";
            column.ReadOnly = false;
            column.Unique = false;
            column.DefaultValue = 1;
            CircleTable.Columns.Add(column);

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = CircleTable.Columns["OptimizationType"];
            CircleTable.PrimaryKey = PrimaryKeyColumns;

            DataRow row;

            row = CircleTable.NewRow();
            row["OptimizationType"] = "OffsetX";
            //row["numDegree0"] = this.rCircleOffsetX.numDegree0;
            //row["numDegree90"] = this.rCircleOffsetX.numDegree90;
            //row["numDegree180"] = this.rCircleOffsetX.numDegree180;
            //row["numDegree270"] = this.rCircleOffsetX.numDegree270;
            //row["numCurveType"] = this.rCircleOffsetX.numCurveType;
            CircleTable.Rows.Add(row);

            row = CircleTable.NewRow();
            row["OptimizationType"] = "OffsetY";
            //row["numDegree0"] = this.rCircleOffsetY.numDegree0;
            //row["numDegree90"] = this.rCircleOffsetY.numDegree90;
            //row["numDegree180"] = this.rCircleOffsetY.numDegree180;
            //row["numDegree270"] = this.rCircleOffsetY.numDegree270;
            //row["numCurveType"] = this.rCircleOffsetY.numCurveType;
            CircleTable.Rows.Add(row);

            row = CircleTable.NewRow();
            row["OptimizationType"] = "RotationX";
            //row["numDegree0"] = this.rCircleRotationX.numDegree0;
            //row["numDegree90"] = this.rCircleRotationX.numDegree90;
            //row["numDegree180"] = this.rCircleRotationX.numDegree180;
            //row["numDegree270"] = this.rCircleRotationX.numDegree270;
            //row["numCurveType"] = this.rCircleRotationX.numCurveType;
            CircleTable.Rows.Add(row);

            row = CircleTable.NewRow();
            row["OptimizationType"] = "RotationY";
            //row["numDegree0"] = this.rCircleRotationY.numDegree0;
            //row["numDegree90"] = this.rCircleRotationY.numDegree90;
            //row["numDegree180"] = this.rCircleRotationY.numDegree180;
            //row["numDegree270"] = this.rCircleRotationY.numDegree270;
            //row["numCurveType"] = this.rCircleRotationY.numCurveType;
            CircleTable.Rows.Add(row);

            row = CircleTable.NewRow();
            row["OptimizationType"] = "RotationZ";
            //row["numDegree0"] = this.rCircleRotationZ.numDegree0;
            //row["numDegree90"] = this.rCircleRotationZ.numDegree90;
            //row["numDegree180"] = this.rCircleRotationZ.numDegree180;
            //row["numDegree270"] = this.rCircleRotationZ.numDegree270;
            //row["numCurveType"] = this.rCircleRotationZ.numCurveType;
            CircleTable.Rows.Add(row);

            this.CircleView = new DataView(this.CircleTable);
            this.CircleView.AllowNew = false;
        }
        
        #region Dispose

        private bool _disposed;

        ~LayerParameter()
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
                if (this.CircleView != null)
                {
                    this.CircleView.Dispose();
                    this.CircleView = null;
                }
                if (this.CircleTable != null)
                {
                    this.CircleTable.Clear();
                    //this.CircleTable.Reset();
                    this.CircleTable.Dispose();
                    this.CircleTable = null;
                }
                if (this.rCircleOffsetX != null)
                {
                    this.rCircleOffsetX.Dispose();
                    this.rCircleOffsetX = null;
                }
                if (this.rCircleOffsetY != null)
                {
                    this.rCircleOffsetY.Dispose();
                    this.rCircleOffsetY = null;
                }
                if (this.rCircleRotationX != null)
                {
                    this.rCircleRotationX.Dispose();
                    this.rCircleRotationX = null;
                }
                if (this.rCircleRotationY != null)
                {
                    this.rCircleRotationY.Dispose();
                    this.rCircleRotationY = null;
                }
                if (this.rCircleRotationZ != null)
                {
                    this.rCircleRotationZ.Dispose();
                    this.rCircleRotationZ = null;
                }
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

        /// <summary>
        /// [0,[1,3,1,6,1],[-5,3,-5,3,1],[0,0,0,0,1],[0,-15,0,-15,1],[0,0,0,0,1],"s7j46w0-0"]
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3},{4},{5},\"{6}\"]"
                , this.numWorkAngleDeclination, this.rCircleOffsetX, this.rCircleOffsetY
                , this.rCircleRotationX, this.rCircleRotationY, this.rCircleRotationZ, this.strLayerParameterID);
        }

        public void RefreshData(RWSystem rwSystem, int intLayerNo)
        {
            this.intLayerNo = intLayerNo;

            RapidData rLayerParameter = rwSystem.Controller.Rapid.GetRapidData(strTaskName, strDataModuleName, string.Format("{0}{1:00}", strDataName, this.intLayerNo));
            RapidDataType rLayerParameterType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rLayerParameterUserDefine = new UserDefined(rLayerParameterType);
            rLayerParameterUserDefine.FillFromString(rLayerParameter.Value.ToString());

            int i = 0;
            this.numWorkAngleDeclination =int.Parse(rLayerParameterUserDefine.Components[i++].ToString());
            //ErrorHandler.AddErrorMessage("MichaelLog", rLayerParameterUserDefine.Components[i].ToString());

            this.rCircleOffsetX.RefreshData(rwSystem, rLayerParameterUserDefine.Components[i++].ToString());
            this.rCircleOffsetY.RefreshData(rwSystem, rLayerParameterUserDefine.Components[i++].ToString());
            this.rCircleRotationX.RefreshData(rwSystem, rLayerParameterUserDefine.Components[i++].ToString());
            this.rCircleRotationY.RefreshData(rwSystem, rLayerParameterUserDefine.Components[i++].ToString());
            this.rCircleRotationZ.RefreshData(rwSystem, rLayerParameterUserDefine.Components[i++].ToString());

            this.strLayerParameterID = rLayerParameterUserDefine.Components[i++].ToString();
            this.strLayerParameterID = this.strLayerParameterID.Substring(1, this.strLayerParameterID.Length - 2);

            rLayerParameterUserDefine.Dispose();
            rLayerParameterType.Dispose();
            rLayerParameter.Dispose();

            DataRow row = this.CircleTable.Rows.Find("OffsetX");
            row[1] = this.circleOffsetX.numDegree0;
            row[2] = this.circleOffsetX.numDegree90;
            row[3] = this.circleOffsetX.numDegree180;
            row[4] = this.circleOffsetX.numDegree270;
            row[5] = this.circleOffsetX.numCurveType;

            row = this.CircleTable.Rows.Find("OffsetY");
            row[1] = this.circleOffsetY.numDegree0;
            row[2] = this.circleOffsetY.numDegree90;
            row[3] = this.circleOffsetY.numDegree180;
            row[4] = this.circleOffsetY.numDegree270;
            row[5] = this.circleOffsetY.numCurveType;

            row = this.CircleTable.Rows.Find("RotationX");
            row[1] = this.circleRotationX.numDegree0;
            row[2] = this.circleRotationX.numDegree90;
            row[3] = this.circleRotationX.numDegree180;
            row[4] = this.circleRotationX.numDegree270;
            row[5] = this.circleRotationX.numCurveType;

            row = this.CircleTable.Rows.Find("RotationY");
            row[1] = this.circleRotationY.numDegree0;
            row[2] = this.circleRotationY.numDegree90;
            row[3] = this.circleRotationY.numDegree180;
            row[4] = this.circleRotationY.numDegree270;
            row[5] = this.circleRotationY.numCurveType;

            row = this.CircleTable.Rows.Find("RotationZ");
            row[1] = this.circleRotationZ.numDegree0;
            row[2] = this.circleRotationZ.numDegree90;
            row[3] = this.circleRotationZ.numDegree180;
            row[4] = this.circleRotationZ.numDegree270;
            row[5] = this.circleRotationZ.numCurveType;
        }

        public void ApplyData(RWSystem rwSystem)
        {
            RapidData rLayerParameter = rwSystem.Controller.Rapid.GetRapidData(strTaskName, strDataModuleName, string.Format("{0}{1:00}", strDataName, this.intLayerNo));
            RapidDataType rLayerParameterType = rwSystem.Controller.Rapid.GetRapidDataType(strTaskName, strDataTypeModuleName, strDataType);
            UserDefined rLayerParameterUserDefine = new UserDefined(rLayerParameterType);

            rLayerParameterUserDefine.FillFromString(this.ToString());
            ErrorHandler.AddErrorMessage("MichaelLog", this.ToString());
            rLayerParameter.Value = rLayerParameterUserDefine;

            rLayerParameterUserDefine.Dispose();
            rLayerParameterType.Dispose();
            rLayerParameter.Dispose();
        }
        
    }
}
