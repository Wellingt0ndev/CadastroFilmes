using CadastroFilmes.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFilmes.Web.Controllers
{
    public class FilmeController : Controller
    {
        private List<Filme> filmes = new List<Filme>();

        public FilmeController() 
        {
            CarregarFilmes();
        }

        private void CarregarFilmes()
        {
            Filme filme1 = new Filme(1, "Titanic", "Drama");
            Filme filme2 = new Filme(2, "Top Gun", "Ação");
            Filme filme3 = new Filme(3, "Avatar", "Fantasia");
            filmes.Add(filme1);
            filmes.Add(filme2);
            filmes.Add(filme3);
        }
        public IActionResult Index()
        {           
            return View(filmes);
        }

        public IActionResult Details(int id)
        {
            Filme filmePesquisado = filmes.FirstOrDefault(p => p.Id == id);
            return View(filmePesquisado);
        }

    }
}
