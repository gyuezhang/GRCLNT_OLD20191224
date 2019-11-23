using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Stylet;

namespace Models
{

    [JsonObject(MemberSerialization.OptIn)]

    public class ZoningNode : PropertyChangedBase
    {
        [JsonProperty]
        public long code
        {
            get { return _code; }
            set
            {
                SetAndNotify(ref _code, value);
            }
        }

        [JsonProperty]
        public long pCode
        {
            get { return _pCode; }
            set
            {
                SetAndNotify(ref _pCode, value);
            }
        }

        [JsonProperty]
        public int level
        {
            get { return _level; }
            set
            {
                SetAndNotify(ref _level, value);
            }
        }

        [JsonProperty]
        public string name
        {
            get { return _name; }
            set
            {
                SetAndNotify(ref _name, value);
            }
        }

        private long _code;
        private long _pCode;
        private int _level;
        private string _name;
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class BDZoning : PropertyChangedBase
    {
        public BDZoning()
        {
            _allLevel4Nodes = new List<ZoningNode>();
            _allLevel5Nodes = new List<ZoningNode>();
            _curLevel5Nodes = new List<ZoningNode>();
        }
        private List<ZoningNode> _allLevel4Nodes;
        private List<ZoningNode> _allLevel5Nodes;
        private List<ZoningNode> _curLevel5Nodes;
        private ZoningNode _curLevel4Node;
        private ZoningNode _curLevel5Node;
        [JsonProperty]
        public List<ZoningNode> allLevel4Nodes
        {
            get { return _allLevel4Nodes; }
            set
            {
                SetAndNotify(ref _allLevel4Nodes, value);
            }
        }
        [JsonProperty]
        public List<ZoningNode> allLevel5Nodes
        {
            get { return _allLevel5Nodes; }
            set
            {
                SetAndNotify(ref _allLevel5Nodes, value);
            }
        }
        [JsonProperty]
        public List<ZoningNode> curlevel5Nodes
        {
            get { return _curLevel5Nodes; }
            set
            {
                SetAndNotify(ref _curLevel5Nodes, value);
            }
        }

        [JsonProperty]
        public ZoningNode curlevel4Node
        {
            get { return _curLevel4Node; }
            set
            {
                curlevel5Nodes.Clear();
                List<ZoningNode> tmp = new List<ZoningNode>();
                foreach (ZoningNode cnode in allLevel5Nodes)
                {
                    if (cnode.pCode == value.code)
                        tmp.Add(cnode);
                }
                curlevel5Nodes = tmp;
                if (curlevel5Nodes.Count > 0)
                    curlevel5Node = curlevel5Nodes[0];
                SetAndNotify(ref _curLevel4Node, value);
            }
        }

        [JsonProperty]
        public ZoningNode curlevel5Node
        {
            get { return _curLevel5Node; }
            set
            {
                SetAndNotify(ref _curLevel5Node, value);
            }
        }
        public void InitLevel4Nodes(List<ZoningNode> nodes)
        {
            allLevel4Nodes.Clear();
            allLevel4Nodes = nodes;
        }

        public void InitLevel5Nodes(List<ZoningNode> nodes)
        {
            allLevel5Nodes.Clear();
            allLevel5Nodes = nodes;
        }


        public void SelLevel5Node(ZoningNode node)
        {
            curlevel5Node = node;
        }
    }
}
