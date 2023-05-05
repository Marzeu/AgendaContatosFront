using Microsoft.EntityFrameworkCore;
using AgendaContatos.Data;
using AgendaContatos.Models;

namespace AgendaContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<PessoasContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection") ?? throw new InvalidOperationException("Connection string 'PessoasContext' not found.")));
           
            builder.Services.AddRazorPages();

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    SeedData.Initialize(services);
            //}
          
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}