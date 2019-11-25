using Newtonsoft.Json;
using Stylet;
using System;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Well : PropertyChangedBase
    {
        private int _id;//0
        private string _tsOrSt;//乡镇街道1
        private string _village;//村庄2
        private string _loc;//位置3
        private string _lng;//东经4
        private string _lat;//北纬5
        private string _unitCat;//单位类型6
        private string _usefor;//用途7
        private DateTime _ditTime;//成井时间8
        private float _wellDepth;//井深9 米
        private string _tubeMat;//管材10
        private float _tubeIr;//井管内径11 毫米
        private float _stanWaterDepth;//止水深度12 米
        private float _saltWaterFloorDepth;//咸水底板深度13 米
        private float _filterLocLow;//过滤器低位14 米
        private float _filterLocHigh;//过滤器高位15 米
        private float _stillWaterLoc;//静水位16 //米
        private string _pumpMode;//水泵型号17
        private float _pumpPower;//水泵功率18 //kw
        private float _coverArea;//井控面积19
        private int _supPeopleNum;//供水人口20
        private bool _isWaterLevelOp;//是否水位观测点21
        private bool _isMfInstalled;//是否安装计量设备22
        private int _linkWellNo;//连接井眼眼数23
        private bool _isSeepChnLinked;//装防渗渠道24
        private float _seepChnLength;//防渗渠道长度25 //千米 float
        private string _remark;//备注26

        [JsonProperty]
        public int Id
        {
            get { return _id; }
            set
            {
                SetAndNotify(ref _id, value);
            }
        }

        [JsonProperty]
        public string TsOrSt
        {
            get { return _tsOrSt; }
            set
            {
                SetAndNotify(ref _tsOrSt, value);
            }
        }

        [JsonProperty]
        public string Village
        {
            get { return _village; }
            set
            {
                SetAndNotify(ref _village, value);
            }
        }

        [JsonProperty]
        public string Loc
        {
            get { return _loc; }
            set
            {
                SetAndNotify(ref _loc, value);
            }
        }

        [JsonProperty]
        public string Lng
        {
            get { return _lng; }
            set
            {
                SetAndNotify(ref _lng, value);
            }
        }

        [JsonProperty]
        public string Lat
        {
            get { return _lat; }
            set
            {
                SetAndNotify(ref _lat, value);
            }
        }

        [JsonProperty]
        public string UnitCat
        {
            get { return _unitCat; }
            set
            {
                SetAndNotify(ref _unitCat, value);
            }
        }

        [JsonProperty]
        public string Usefor
        {
            get { return _usefor; }
            set
            {
                SetAndNotify(ref _usefor, value);
            }
        }

        [JsonProperty]
        public DateTime DigTime
        {
            get { return _ditTime; }
            set
            {
                SetAndNotify(ref _ditTime, value);
            }
        }

        [JsonProperty]
        public float WellDepth
        {
            get { return _wellDepth; }
            set
            {
                SetAndNotify(ref _wellDepth, value);
            }
        }

        [JsonProperty]
        public string TubeMat
        {
            get { return _tubeMat; }
            set
            {
                SetAndNotify(ref _tubeMat, value);
            }
        }

        [JsonProperty]
        public float TubeIr
        {
            get { return _tubeIr; }
            set
            {
                SetAndNotify(ref _tubeIr, value);
            }
        }

        [JsonProperty]
        public float StanWaterDepth
        {
            get { return _stanWaterDepth; }
            set
            {
                SetAndNotify(ref _stanWaterDepth, value);
            }
        }

        [JsonProperty]
        public float SaltWaterFloorDepth
        {
            get { return _saltWaterFloorDepth; }
            set
            {
                SetAndNotify(ref _saltWaterFloorDepth, value);
            }
        }

        [JsonProperty]
        public float FilterLocLow
        {
            get { return _filterLocLow; }
            set
            {
                SetAndNotify(ref _filterLocLow, value);
            }
        }

        [JsonProperty]
        public float FilterLocHigh
        {
            get { return _filterLocHigh; }
            set
            {
                SetAndNotify(ref _filterLocHigh, value);
            }
        }

        [JsonProperty]
        public float StillWaterLoc
        {
            get { return _stillWaterLoc; }
            set
            {
                SetAndNotify(ref _stillWaterLoc, value);
            }
        }

        [JsonProperty]
        public string PumpMode
        {
            get { return _pumpMode; }
            set
            {
                SetAndNotify(ref _pumpMode, value);
            }
        }

        [JsonProperty]
        public float PumpPower
        {
            get { return _pumpPower; }
            set
            {
                SetAndNotify(ref _pumpPower, value);
            }
        }

        [JsonProperty]
        public float CoverArea
        {
            get { return _coverArea; }
            set
            {
                SetAndNotify(ref _coverArea, value);
            }
        }

        [JsonProperty]
        public int SupPeopleNum
        {
            get { return _supPeopleNum; }
            set
            {
                SetAndNotify(ref _supPeopleNum, value);
            }
        }

        [JsonProperty]
        public bool IsWaterLevelOp
        {
            get { return _isWaterLevelOp; }
            set
            {
                SetAndNotify(ref _isWaterLevelOp, value);
            }
        }

        [JsonProperty]
        public bool IsMfInstalled
        {
            get { return _isMfInstalled; }
            set
            {
                SetAndNotify(ref _isMfInstalled, value);
            }
        }

        [JsonProperty]
        public int LinkWellNo
        {
            get { return _linkWellNo; }
            set
            {
                SetAndNotify(ref _linkWellNo, value);
            }
        }

        [JsonProperty]
        public bool IsSeepChnLinked
        {
            get { return _isSeepChnLinked; }
            set
            {
                SetAndNotify(ref _isSeepChnLinked, value);
            }
        }

        [JsonProperty]
        public float SeepChnLength
        {
            get { return _seepChnLength; }
            set
            {
                SetAndNotify(ref _seepChnLength, value);
            }
        }

        [JsonProperty]
        public string Remark
        {
            get { return _remark; }
            set
            {
                SetAndNotify(ref _remark, value);
            }
        }
    }
}
