using Newtonsoft.Json;
using Stylet;
using System.Collections.Generic;

namespace Model
{
    /// <summary>
    /// 区划节点
    /// </summary>
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

    /// <summary>
    /// 宝坻区划
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class C_BdAreaCode : PropertyChangedBase
    {
        public C_BdAreaCode(){ }

        public C_BdAreaCode(List<C_AreaCode> ac)
        {
            if (ac.Count == 0)
                return;
            foreach (C_AreaCode node in ac)
            {
                if(node.Level == 4)
                {
                    AllL4AreaCodes.Add(node);
                }
                else if(node.Level == 5)
                {
                    AllL5AreaCodes.Add(node);
                }
            }
            if (AllL4AreaCodes.Count != 0)
                L4Index = AllL4AreaCodes[0];
        }

        private C_AreaCode _l4Index = new C_AreaCode();
        private C_AreaCode _l5Index = new C_AreaCode();
        private List<C_AreaCode> _allL4AreaCodes = new List<C_AreaCode>();
        private List<C_AreaCode> _allL5AreaCodes = new List<C_AreaCode>();
        private List<C_AreaCode> _curL5AreaCodes = new List<C_AreaCode>();

        [JsonProperty]
        public C_AreaCode L4Index
        {
            get { return _l4Index; }
            set
            {
                SetAndNotify(ref _l4Index, value);
                CurL5AreaCodes.Clear();
                if (AllL5AreaCodes.Count == 0)
                    return;
                foreach(C_AreaCode node in AllL5AreaCodes)
                {
                    if (node.PCode == L4Index.Code)
                        CurL5AreaCodes.Add(node);
                }
                if (CurL5AreaCodes.Count != 0)
                    L5Index = CurL5AreaCodes[0];
            }
        }

        [JsonProperty]
        public C_AreaCode L5Index
        {
            get { return _l5Index; }
            set
            {
                SetAndNotify(ref _l5Index, value);
            }
        }

        [JsonProperty]
        public List<C_AreaCode> AllL4AreaCodes
        {
            get { return _allL4AreaCodes; }
            set
            {
                SetAndNotify(ref _allL4AreaCodes, value);
            }
        }

        [JsonProperty]
        public List<C_AreaCode> AllL5AreaCodes
        {
            get { return _allL5AreaCodes; }
            set
            {
                SetAndNotify(ref _allL5AreaCodes, value);
            }
        }

        [JsonProperty]
        public List<C_AreaCode> CurL5AreaCodes
        {
            get { return _curL5AreaCodes; }
            set
            {
                SetAndNotify(ref _curL5AreaCodes, value);
            }
        }
    }
}
