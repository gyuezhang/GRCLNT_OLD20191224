using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class API_Login_Req
    {
        public API_Login_Req(string name, string pwd)
        {
            this.name = name;
            this.pwd = pwd;
        }
        [JsonProperty]
        private string name { get; set; }
        [JsonProperty]
        private string pwd { get; set; }
    }
}
