using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendaContatos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AgendaContatos.Data;
using AgendaContatos.Models;

namespace AgendaContatos.Pages
{
    public class IndexModel : PageModel
    {   
        public IList<PessoaContatoViewModel> Pessoa { get; set; } = default!;

        public async Task OnGetAsync()
        {
            HttpClient client = new HttpClient();
            var m = await client.GetAsync("http://localhost:5183/api/v1/pessoas");
            var response = await m.Content.ReadAsStringAsync();
            var ras = JsonConvert.DeserializeObject<ResultViewModel<List<PessoaContatoViewModel>>>(response);

            if (ras?.Data != null)
            {
                Pessoa = ras.Data;
            }
        }
    }
}
