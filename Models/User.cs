using Newtonsoft.Json;
using Stylet;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : PropertyChangedBase
    {

        private string _id;

        private string _name;

        private string _pwd;

        private string _deptName;

        private string _tel;
        private string _email;

        [JsonProperty]
        public string Id
        {
            get { return _id; }
            set
            {
                SetAndNotify(ref _id, value);
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

        [JsonProperty]
        public string Pwd
        {
            get { return _pwd; }
            set
            {
                SetAndNotify(ref _pwd, value);
            }
        }

        [JsonProperty]
        public string DeptName
        {
            get { return _deptName; }
            set
            {
                SetAndNotify(ref _deptName, value);
            }
        }

        [JsonProperty]
        public string Tel
        {
            get { return _tel; }
            set
            {
                SetAndNotify(ref _tel, value);
            }
        }

        [JsonProperty]
        public string Email
        {
            get { return _email; }
            set
            {
                SetAndNotify(ref _email, value);
            }
        }
    }
}