using Stylet;

namespace Models
{
    public class User : PropertyChangedBase
    {
        private string _id;
        private string _name;
        private string _pwd;
        private string _deptName;
        private string _tel;
        private string _email;

        public string Id
        {
            get { return _id; }
            set
            {
                SetAndNotify(ref _id, value);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                SetAndNotify(ref _name, value);
            }
        }

        public string Pwd
        {
            get { return _pwd; }
            set
            {
                SetAndNotify(ref _pwd, value);
            }
        }

        public string DeptName
        {
            get { return _deptName; }
            set
            {
                SetAndNotify(ref _deptName, value);
            }
        }

        public string Tel
        {
            get { return _tel; }
            set
            {
                SetAndNotify(ref _tel, value);
            }
        }

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
