using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AgendaContatos.Data;
using AgendaContatos.Models;
using AgendaContatos.ViewModel;
using Newtonsoft.Json;

namespace AgendaContatos.Pages
{
    public class DetailsModel : PageModel
    {
        public PessoaContatoViewModel Pessoa { get; set; } = default!;        

        public async Task OnGetAsync(int? id)
        {
            HttpClient client = new HttpClient();
            var m = await client.GetAsync($"http://localhost:5183/api/v1/pessoas/{id}");
            var response = await m.Content.ReadAsStringAsync();
            var ras = JsonConvert.DeserializeObject<ResultViewModel<PessoaContatoViewModel>>(response);

            if (ras.Data != null)
            {
                Pessoa = ras.Data;
            }           
        }
    }   
}
