using Newtonsoft.Json;
using Stylet;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class WellOutPut : PropertyChangedBase
    {

        private bool _isSelected;

        private string _name;

        private string _des;

        [JsonProperty]
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                SetAndNotify(ref _isSelected, value);
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
        public string Des
        {
            get { return _des; }
            set
            {
                SetAndNotify(ref _des, value);
            }
        }
    }
}