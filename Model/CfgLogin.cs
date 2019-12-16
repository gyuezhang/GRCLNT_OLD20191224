using Stylet;

namespace Model
{
    public class CfgLogin : PropertyChangedBase
    {
        private string _usrName;
        private string _usrPwd;
        private bool _recordPwd;
        private bool _autoLogin;
        private string _svrIp;

        public string UsrName
        {
            get { return _usrName; }
            set
            {
                SetAndNotify(ref _usrName, value);
            }
        }

        public string UsrPwd
        {
            get { return _usrPwd; }
            set
            {
                SetAndNotify(ref _usrPwd, value);
            }
        }

        public bool RecordPwd
        {
            get { return _recordPwd; }
            set
            {
                SetAndNotify(ref _recordPwd, value);
                if (!value)
                {
                    AutoLogin = value;
                }
            }
        }

        public bool AutoLogin
        {
            get { return _autoLogin; }
            set
            {
                SetAndNotify(ref _autoLogin, value);
                if (value)
                {
                    RecordPwd = value;
                }
            }
        }

        public string SvrIp
        {
            get { return _svrIp; }
            set
            {
                SetAndNotify(ref _svrIp, value);
            }
        }
    }

}
