using Newtonsoft.Json;

namespace AgendaContatos.ViewModel
{
    public class ResultViewModel<T>
    {
        [JsonProperty("data")]
        public T Data { get; private set; }
        [JsonProperty("errors")]
        public List<string> Errors { get; private set; } = new();
    }
}
