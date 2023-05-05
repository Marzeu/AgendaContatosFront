using Newtonsoft.Json;

namespace AgendaContatos.ViewModel
{
    public class PessoaContatoViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nome")]
        public string? Nome { get; set; }
        [JsonProperty("contatos")]
        public List<dynamic> Contatos { get; set; }
    }
}
