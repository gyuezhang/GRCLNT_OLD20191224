using Newtonsoft.Json;

namespace Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class API_ResetPwd
    {
        public API_ResetPwd(string id, string oldPwd,string newPwd)
        {
            this.Id = id;
            this.OldPwd = oldPwd;
            this.NewPwd = newPwd;
        }
        [JsonProperty]
        public string Id { get; set; }
        [JsonProperty]
        public string OldPwd { get; set; }
        [JsonProperty]
        public string NewPwd { get; set; }
    }
}
