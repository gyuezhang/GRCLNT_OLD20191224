using Newtonsoft.Json;
using Stylet;
using System.Collections.Generic;

namespace Models
{
    public enum WellParaType
    {
        UnitCat,
        Loc,
        TubeMat,
        PumpModel,
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class WellPara : PropertyChangedBase
    {
        public WellPara()
        {

        }

        public WellPara(WellParaType type,string v)
        {
            Type = type;
            Value = v;
        }
        private WellParaType _type;
        private string _value;

        [JsonProperty]
        public WellParaType Type
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

    [JsonObject(MemberSerialization.OptIn)]
    public class WellParas : PropertyChangedBase
    {
        public void ResetAllPara()
        {
            AllParas = new List<WellPara>();
            AllParas.AddRange(UnitCat);
            AllParas.AddRange(Loc);
            AllParas.AddRange(TubeMat);
            AllParas.AddRange(PumpModel);
        }
        public WellParas()
        {        
            UnitCat = new List<WellPara>();
            Loc = new List<WellPara>();
            TubeMat = new List<WellPara>();
            PumpModel = new List<WellPara>();
            AllParas = new List<WellPara>();

        }
        public WellParas(List<WellPara> iWellParas)
        {
            UnitCat = new List<WellPara>();
            Loc = new List<WellPara>();
            TubeMat = new List<WellPara>();
            PumpModel = new List<WellPara>();
            AllParas = iWellParas;

            foreach (WellPara node in iWellParas)
            {
                switch(node.Type)
                {
                    case WellParaType.Loc:
                        Loc.Add(node);
                        break;
                    case WellParaType.UnitCat:
                        UnitCat.Add(node);
                        break;
                    case WellParaType.TubeMat:
                        TubeMat.Add(node);
                        break;
                    case WellParaType.PumpModel:
                        PumpModel.Add(node);
                        break;
                    default:
                        break;
                }
            }
            if (UnitCat.Count != 0)
            {
                CurUnitCat = UnitCat[0];
            }
            if (Loc.Count != 0)
            {
                CurLoc = Loc[0];
            }
            if (PumpModel.Count != 0)
            {
                CurPumpModel = PumpModel[0];
            }
            if (TubeMat.Count != 0)
            {
                CurTubeMat = TubeMat[0];
            }
        }

        private List<WellPara> _unitCat;
        private List<WellPara> _loc;
        private List<WellPara> _tubeMat;
        private List<WellPara> _pumpModel;
        private List<WellPara> _allParas;

        private WellPara _curUnitCat =new WellPara();
        private WellPara _curLoc = new WellPara();
        private WellPara _curTubeMat = new WellPara();
        private WellPara _curPumpModel = new WellPara();

        public WellPara CurUnitCat
        {
            get { return _curUnitCat; }
            set
            {
                SetAndNotify(ref _curUnitCat, value);
            }
        }
        public WellPara CurLoc
        {
            get { return _curLoc; }
            set
            {
                SetAndNotify(ref _curLoc, value);
            }
        }
        public WellPara CurTubeMat
        {
            get { return _curTubeMat; }
            set
            {
                SetAndNotify(ref _curTubeMat, value);
            }
        }
        public WellPara CurPumpModel
        {
            get { return _curPumpModel; }
            set
            {
                SetAndNotify(ref _curPumpModel, value);
            }
        }

        [JsonProperty]
        public List<WellPara> UnitCat
        {
            get { return _unitCat; }
            set
            {
                SetAndNotify(ref _unitCat, value);
            }
        }

        [JsonProperty]
        public List<WellPara> Loc
        {
            get { return _loc; }
            set
            {
                SetAndNotify(ref _loc, value);
            }
        }

        [JsonProperty]
        public List<WellPara> TubeMat
        {
            get { return _tubeMat; }
            set
            {
                SetAndNotify(ref _tubeMat, value);
            }
        }

        [JsonProperty]
        public List<WellPara> PumpModel
        {
            get { return _pumpModel; }
            set
            {
                SetAndNotify(ref _pumpModel, value);
            }
        }

        [JsonProperty]
        public List<WellPara> AllParas
        {
            get { return _allParas; }
            set
            {
                SetAndNotify(ref _allParas, value);
            }
        }
    }


    public enum E_WellParaType
    {
        UnitCat,
        Loc,
        TubeMat,
        PumpModel,
        UseFor,
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