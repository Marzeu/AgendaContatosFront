using Newtonsoft.Json;

namespace AgendaContatos.ViewModel
{
    public class ContatoViewModel
    {
        [JsonProperty("valor")]
        public string? Valor { get; set; }
        [JsonProperty("tipo")]
        public int Tipo { get; set; }
    }
}
