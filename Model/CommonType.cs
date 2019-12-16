using Newtonsoft.Json;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 日志类型
    /// </summary>
    public enum E_LogType
    {
        Db,
        Svr,
    }

    /// <summary>
    /// 用户类型
    /// </summary>
    public enum E_UserType
    {
        Admin,
        User,
        Sys,
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum E_OperType
    {
        AreaCodeInitTab,
        AreaCodeInitData,
        AreaCodeGet,

        AdminUserInitTab,
        AdminUserGet,
        AdminUserInitPwd,

    }

    /// <summary>
    /// 机井参数类型
    /// </summary>
    public enum E_WellParaType
    {
        UnitCat,
        Loc,
        TubeMat,
        PumpModel,
        UseFor,
    }

    /// <summary>
    /// 数据库操作返回状态值
    /// </summary>
    public enum E_DbRState
    {
        //Db Return
        Success,
        Failed,
        //Other Return
        Created,
        Deleted,
        Changed,
        NoResult,
        GotSuccess,
        GramError,

        //LOGIN
        ErrorPwd,
    }

    public enum API_ID
    {
        API_ConnState,

        API_AddAreaCode,
        API_DeleteAreaCode,
        API_ChangeAreaCode,
        API_GetAreaCodes,

        API_AdminUserResetPwd,
        API_AdminUserLogin,

        API_AddDept,
        API_DeleteDept,
        API_ChangeDept,
        API_GetDepts,

        API_AddUser,
        API_DeleteUser,
        API_ChangeUser,
        API_GetUsers,
        API_Login,
        API_ResetPwd,

        API_AddEntWell,
        API_ChangeEntWell,
        API_DeleteEntWell,
        API_GetEntWells,

        API_AddEntWellPara,
        API_ChangeEntWellPara,
        API_DeleteEntWellPara,
        API_GetEntWellParas,

        API_AddWell,
        API_ChangeWell,
        API_DeleteWell,
        API_GetWells,

        API_AddWellPara,
        API_ChangeWellPara,
        API_DeleteWellPara,
        API_GetWellParas,



    }

    public enum RES_STATE
    {
        OK,         //成功
        FAILED,
        BAD_REQUEST,//请求参数（格式）错误
        INCORRECT,//请求参数（值）不正确
    }


    /// <summary>
    /// 机井参数
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class C_WellPara : PropertyChangedBase
    {
        public C_WellPara() { }
        public C_WellPara(E_WellParaType type, string value)
        {
            Type = type;
            Value = value;
        }

        private E_WellParaType _type;
        private string _value;

        [JsonProperty]
        public E_WellParaType Type
        {
            get { return _type; }
            set
            {
                SetAndNotify(ref _type, value);
            }
        }

        [JsonProperty]
        public string Value
        {
            get { return _value; }
            set
            {
                SetAndNotify(ref _value, value);
            }
        }
    }

    /// <summary>
    /// 机井参数列表
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class C_WellParas : PropertyChangedBase
    {
        public C_WellParas() { }

        public C_WellParas(List<C_WellPara> paras)
        {
            AllParas = paras;
            UnitCat.Clear();
            Loc.Clear();
            TubeMat.Clear();
            PumpModel.Clear();
            UseFor.Clear();

            if (paras == null)
                return;
            if (paras.Count == 0)
                return;

            foreach (C_WellPara node in paras)
            {
                switch (node.Type)
                {
                    case E_WellParaType.Loc:
                        Loc.Add(node);
                        break;
                    case E_WellParaType.PumpModel:
                        PumpModel.Add(node);
                        break;
                    case E_WellParaType.TubeMat:
                        TubeMat.Add(node);
                        break;
                    case E_WellParaType.UnitCat:
                        UnitCat.Add(node);
                        break;
                    case E_WellParaType.UseFor:
                        UseFor.Add(node);
                        break;
                    default:
                        break;
                }
            }

            if (UnitCat.Count != 0)
            {
                UnitCatIndex = UnitCat[0];
            }
            if (Loc.Count != 0)
            {
                LocIndex = Loc[0];
            }
            if (PumpModel.Count != 0)
            {
                PumpModelIndex = PumpModel[0];
            }
            if (TubeMat.Count != 0)
            {
                TubeMatIndex = TubeMat[0];
            }
            if (UseFor.Count != 0)
            {
                UseForIndex = UseFor[0];
            }
        }

        public void ResetAllPara()
        {
            AllParas.Clear();
            AllParas.AddRange(UnitCat);
            AllParas.AddRange(Loc);
            AllParas.AddRange(TubeMat);
            AllParas.AddRange(PumpModel);
            AllParas.AddRange(UseFor);
        }

        private List<C_WellPara> _allParas = new List<C_WellPara>();
        private List<C_WellPara> _unitCat = new List<C_WellPara>();
        private List<C_WellPara> _loc = new List<C_WellPara>();
        private List<C_WellPara> _tubeMat = new List<C_WellPara>();
        private List<C_WellPara> _pumpModel = new List<C_WellPara>();
        private List<C_WellPara> _useFor = new List<C_WellPara>();

        private C_WellPara _unitCatIndex = new C_WellPara();
        private C_WellPara _locIndex = new C_WellPara();
        private C_WellPara _tubeMatIndex = new C_WellPara();
        private C_WellPara _pumpModelIndex = new C_WellPara();
        private C_WellPara _useForIndex = new C_WellPara();

        [JsonProperty]
        public List<C_WellPara> AllParas
        {
            get { return _allParas; }
            set
            {
                SetAndNotify(ref _allParas, value);
            }
        }

        [JsonProperty]
        public List<C_WellPara> UnitCat
        {
            get { return _unitCat; }
            set
            {
                SetAndNotify(ref _unitCat, value);
            }
        }

        [JsonProperty]
        public List<C_WellPara> Loc
        {
            get { return _loc; }
            set
            {
                SetAndNotify(ref _loc, value);
            }
        }

        [JsonProperty]
        public List<C_WellPara> TubeMat
        {
            get { return _tubeMat; }
            set
            {
                SetAndNotify(ref _tubeMat, value);
            }
        }

        [JsonProperty]
        public List<C_WellPara> PumpModel
        {
            get { return _pumpModel; }
            set
            {
                SetAndNotify(ref _pumpModel, value);
            }
        }

        [JsonProperty]
        public List<C_WellPara> UseFor
        {
            get { return _useFor; }
            set
            {
                SetAndNotify(ref _useFor, value);
            }
        }

        public C_WellPara UnitCatIndex
        {
            get { return _unitCatIndex; }
            set
            {
                SetAndNotify(ref _unitCatIndex, value);
            }
        }

        public C_WellPara LocIndex
        {
            get { return _locIndex; }
            set
            {
                SetAndNotify(ref _locIndex, value);
            }
        }

        public C_WellPara TubeMatIndex
        {
            get { return _tubeMatIndex; }
            set
            {
                SetAndNotify(ref _tubeMatIndex, value);
            }
        }

        public C_WellPara PumpModelIndex
        {
            get { return _pumpModelIndex; }
            set
            {
                SetAndNotify(ref _pumpModelIndex, value);
            }
        }

        public C_WellPara UseForIndex
        {
            get { return _useForIndex; }
            set
            {
                SetAndNotify(ref _useForIndex, value);
            }
        }

    }

}
