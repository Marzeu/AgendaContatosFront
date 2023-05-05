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
using System.Text;

namespace AgendaContatos.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public PessoaContatoViewModel Pessoa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                var request = await client.GetAsync($"http://localhost:5183/api/v1/pessoas/{id}");
                var response = await request.Content.ReadAsStringAsync();
                var pessoa = JsonConvert.DeserializeObject<ResultViewModel<PessoaContatoViewModel>>(response);

                if (pessoa.Data == null)
                {
                    return NotFound();
                }
                else
                {
                    Pessoa = pessoa.Data;
                }
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || Pessoa == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {                
                var response = await client.DeleteAsync($"http://localhost:5183/api/v1/pessoa/{id}");
                string result = await response.Content.ReadAsStringAsync();
            }    

            return RedirectToPage("./Index");
        }
    }
}
