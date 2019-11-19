using SuperSocket.ProtoBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    /// <summary>
    /// 客户端接收过滤器
    /// </summary>
    public class CLNTRecvFilter : SuperSocket.ProtoBase.TerminatorReceiveFilter<CLNTStringPackageInfo>
    {
        public CLNTRecvFilter()
            : base(Encoding.UTF8.GetBytes("<RESTMNT>"))
        {
            clntSp = new CLNTStringParse();
        }

        public override CLNTStringPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            return new CLNTStringPackageInfo(bufferStream.ReadString((int)bufferStream.Length, Encoding.UTF8), clntSp);
        }

        private CLNTStringParse clntSp;
    }

    /// <summary>
    /// 服务器响应字符串格式化类
    /// </summary>
    public class CLNTStringPackageInfo : IPackageInfo<string>
    {
        public API_ID apiId { get; protected set; }
        public RES_STATE resState { get; protected set; }
        public string Parameters { get; protected set; }
        public string Key { get; protected set; }

        protected CLNTStringPackageInfo()
        {

        }

        public CLNTStringPackageInfo(string source, ICLNTStringParse sourceParser)
        {
            InitializeData(source, sourceParser);
        }

        public CLNTStringPackageInfo(API_ID id, RES_STATE state, string para)
        {
            apiId = id;
            resState = state;
            Parameters = para;
        }

        protected void InitializeData(string source, ICLNTStringParse sourceParser)
        {
            API_ID _key;
            RES_STATE _body;
            string _parameters;

            sourceParser.Parse(source, out _key, out _body, out _parameters);

            apiId = _key;
            resState = _body;
            Parameters = _parameters;
        }
    }

    /// <summary>
    /// 解析字符串接口
    /// </summary>
    public interface ICLNTStringParse
    {
        void Parse(string source, out API_ID apiId, out RES_STATE resState, out string parameters);
    }

    /// <summary>
    /// 解析字符串接口实现
    /// </summary>
    public class CLNTStringParse : ICLNTStringParse
    {
        public void Parse(string source, out API_ID apiId, out RES_STATE resState, out string parameters)
        {
            source = source.Replace("\r\n", string.Empty);
            source = source.Replace("<RESTMNT>", string.Empty);
            source = source.Trim();
            string[] tmp = source.Split(' ');
            tmp = tmp.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            apiId = (API_ID)Enum.Parse(typeof(API_ID), tmp[0]);
            resState = (RES_STATE)Enum.Parse(typeof(RES_STATE), tmp[1]);
            parameters = tmp.CloneRange(2, tmp.Length - 2).ToString();
        }
    }
}
