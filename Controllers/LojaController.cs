using AvaliacaoLp3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao3Lp3.Controllers;

public class LojaController : Controller
{
    public static List<LojasViewModel> lojas = new List<LojasViewModel>();

    public IActionResult Index()
    {
        return View(lojas);
    }

    public IActionResult Cadastramento()
    {
        return View();
    }

    public IActionResult Cadastro([FromForm] string piso, [FromForm] string nome, [FromForm] string descricao, [FromForm] string tipo, [FromForm] string email)
    {
        int id = 1;

        foreach (var loja in lojas)
        {
            if(nome == loja.Nome)
            {
                ViewData["Mensagem"] = "ERRO - Loja/Quiosque já cadastrado";
                return View();
            }
        }

        for(int i = 0; i < lojas.Count(); i++){
            i++;
        }

        lojas.Add(new LojasViewModel(id, piso, nome, descricao, tipo, email));

        ViewData["Mensagem"] = "Loja/Quiosque cadastrado com sucesso";

        return View();
    }

    public IActionResult Gerenciamento()
    {
        return View(lojas);
    }

    public IActionResult Detalhes(int id)
    {
        return View(lojas[id-1]);
    }

    public IActionResult Excluir(int id)
    {
        lojas.RemoveAt(id-1);
        return View();
    }
}