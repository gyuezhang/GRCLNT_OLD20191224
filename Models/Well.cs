using Newtonsoft.Json;
using Stylet;
using System;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Well : PropertyChangedBase
    {
        public Well()
        {
            _ditTime = DateTime.UtcNow;
        }
        private int _id;//0
        private string _tsOrSt;             //所属乡镇（街道）              1
        private string _village;            //所属村                2
        private string _loc;                //位置                3
        private string _lng;                //东经                4
        private string _lat;                //北纬                5
        private string _unitCat;            //权属单位              6
        private string _usefor;             //用途                    7
        private DateTime _ditTime;          //成井时间              8
        private float _wellDepth;           //井深（m）                9 米
        private string _tubeMat;            //管材                10
        private float _tubeIr;              //井管内径（mm）                  11 毫米
        private float _stanWaterDepth;      //止水深度（m）              12 米
        private float _saltWaterFloorDepth; //咸水底板深度（m）            13 米
        private float _filterLocLow;        //过滤器低位（m）             14 米
        private float _filterLocHigh;       //过滤器高位（m）             15 米
        private float _stillWaterLoc;       //静水位（m）               16 //米
        private string _pumpMode;           //水泵型号              17
        private float _pumpPower;           //水泵功率（kw）              18 //kw
        private float _coverArea;           //井控面积（亩）              19
        private int _supPeopleNum;          //供水人口（人）              20
        private bool _isWaterLevelOp;       //是否为水位观测点               21
        private bool _isMfInstalled;        //是否安装计量设备              22
        private int _linkWellNo;            //连接机井眼数                23
        private bool _isSeepChnLinked;      //装防渗渠道                 24
        private float _seepChnLength;       //防渗渠道长度（km）                25              //千米 float
        private string _remark;             //备注                        26

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


    [JsonObject(MemberSerialization.OptIn)]
    public class C_AreaCode : PropertyChangedBase
    {
        private int _id;
        private long _code;
        private long _pCode;
        private int _level;
        private string _name;

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
        public long Code
        {
            get { return _code; }
            set
            {
                SetAndNotify(ref _code, value);
            }
        }

        [JsonProperty]
        public long PCode
        {
            get { return _pCode; }
            set
            {
                SetAndNotify(ref _pCode, value);
            }
        }

        [JsonProperty]
        public int Level
        {
            get { return _level; }
            set
            {
                SetAndNotify(ref _level, value);
            }
        }

        [JsonProperty]
        public string Name
        {
            get { return _name; }
            set
            {
                SetAndNotify(ref _name, value);
            }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class C_EntWell : PropertyChangedBase
    {
        private int _id;                                     //0
        private string _tsOrSt;                             //所属乡镇（街道）                   1
        private string _entName;                            //所属村                            2
        private string _loc;                                //位置                              3
        private string _lng;                                //东经                              4
        private string _lat;                                //北纬                              5
        private string _unitCat;                            //权属单位                          6
        private string _usefor;                             //用途                              7
        private DateTime _ditTime = DateTime.UtcNow;        //成井时间                          8

        private string _fetchWaterId;                       //取水证号                          9                        
        private bool _isPaid;                               //是否正常缴费                      10

        private float _wellDepth;                           //井深（m）                         11 米
        private string _tubeMat;                            //管材                              12
        private float _tubeIr;                              //井管内径（mm）                     13 毫米
        private float _stanWaterDepth;                      //止水深度（m）                      14 米
        private float _saltWaterFloorDepth;                 //咸水底板深度（m）                  15 米
        private float _filterLocLow;                        //过滤器低位（m）                    16 米
        private float _filterLocHigh;                       //过滤器高位（m）                    17 米
        private float _stillWaterLoc;                       //静水位（m）                        18 //米
        private string _pumpMode;                           //水泵型号                           19
        private float _pumpPower;                           //水泵功率（kw）                     20 //kw
        private bool _isWaterLevelOp;                       //是否为水位观测点                   21
        private bool _isMfInstalled;                        //是否安装计量设备                   22
        private string _remark;                             //备注   


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
        public string EntName
        {
            get { return _entName; }
            set
            {
                SetAndNotify(ref _entName, value);
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
        public string FetchWaterId
        {
            get { return _fetchWaterId; }
            set
            {
                SetAndNotify(ref _fetchWaterId, value);
            }
        }

        [JsonProperty]
        public bool IsPaid
        {
            get { return _isPaid; }
            set
            {
                SetAndNotify(ref _isPaid, value);
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
        public string Remark
        {
            get { return _remark; }
            set
            {
                SetAndNotify(ref _remark, value);
            }
        }
    }
    [JsonObject(MemberSerialization.OptIn)]
    public class C_Well : PropertyChangedBase
    {
        private int _id;                                    //0
        private string _tsOrSt;                             //所属乡镇（街道）                   1
        private string _village;                            //所属村                            2
        private string _loc;                                //位置                              3
        private string _lng;                                //东经                              4
        private string _lat;                                //北纬                              5
        private string _unitCat;                            //权属单位                          6
        private string _usefor;                             //用途                              7
        private DateTime _ditTime = DateTime.UtcNow;        //成井时间                          8
        private float _wellDepth;                           //井深（m）                         9 米
        private string _tubeMat;                            //管材                              10
        private float _tubeIr;                              //井管内径（mm）                     11 毫米
        private float _stanWaterDepth;                      //止水深度（m）                      12 米
        private float _saltWaterFloorDepth;                 //咸水底板深度（m）                  13 米
        private float _filterLocLow;                        //过滤器低位（m）                    14 米
        private float _filterLocHigh;                       //过滤器高位（m）                    15 米
        private float _stillWaterLoc;                       //静水位（m）                        16 //米
        private string _pumpMode;                           //水泵型号                           17
        private float _pumpPower;                           //水泵功率（kw）                     18 //kw
        private float _coverArea;                           //井控面积（亩）                     19
        private int _supPeopleNum;                          //供水人口（人）                     20
        private bool _isWaterLevelOp;                       //是否为水位观测点                   21
        private bool _isMfInstalled;                        //是否安装计量设备                   22
        private int _linkWellNo;                            //连接机井眼数                       23
        private bool _isSeepChnLinked;                      //装防渗渠道                         24
        private float _seepChnLength;                       //防渗渠道长度（km）                 25              //千米 float
        private string _remark;                             //备注   


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
