using Newtonsoft.Json;
using Stylet;
using System;

namespace Model
{
    /// <summary>
    /// 日志结构体
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class C_Log : PropertyChangedBase
    {

        public C_Log() { }
        public C_Log(E_LogType logType, E_UserType userType, int userId, E_OperType operType, string desc, string exContent)
        {
            LogType = logType;
            UserType = userType;
            UserId = userId;
            OperType = operType;
            Desc = desc;
            ExContent = exContent;
        }

        private int _id;
        private E_LogType _logType;
        private E_UserType _userType;
        private int _userId;
        private E_OperType _operType;
        private DateTime _recordTime = DateTime.UtcNow;
        private string _desc;
        private string _exContent;

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
        public E_LogType LogType
        {
            get { return _logType; }
            set
            {
                SetAndNotify(ref _logType, value);
            }
        }

        [JsonProperty]
        public E_UserType UserType
        {
            get { return _userType; }
            set
            {
                SetAndNotify(ref _userType, value);
            }
        }

        [JsonProperty]
        public int UserId
        {
            get { return _userId; }
            set
            {
                SetAndNotify(ref _userId, value);
            }
        }

        [JsonProperty]
        public E_OperType OperType
        {
            get { return _operType; }
            set
            {
                SetAndNotify(ref _operType, value);
            }
        }

        public DateTime RecordTime
        {
            get { return _recordTime; }
            set
            {
                SetAndNotify(ref _recordTime, value);
            }
        }

        [JsonProperty]
        public string Desc
        {
            get { return _desc; }
            set
            {
                SetAndNotify(ref _desc, value);
            }
        }

        [JsonProperty]
        public string ExContent
        {
            get { return _exContent; }
            set
            {
                SetAndNotify(ref _exContent, value);
            }
        }
    }
}
