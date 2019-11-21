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
        private string Id { get; set; }
        [JsonProperty]
        private string OldPwd { get; set; }
        [JsonProperty]
        private string NewPwd { get; set; }
    }
}
