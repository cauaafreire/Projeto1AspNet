using Microsoft.AspNetCore.Mvc;
using Projeto1AspNet.Models;
using Projeto1AspNet.Repositorio;

namespace Projeto1AspNet.Controllers
{
    // classe usuariocontroller que esta herdando da classe pai controller 
    public class UsuarioController : Controller
    {
        // declara a variavel prvada e somente leitura do tipo usuariorepositorio que 
        //instancia o _usuarioController para ser atribuido no construtor e interagir com os dados
        private readonly UsuarioRepositorio _usuarioRepositorio;

        //define o construtor da classe UsuarioController 
        // recebe a instancia de usuariorepositorio com parametros
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            // o construtor é chamado quando uma nova instancia é criada
            _usuarioRepositorio = usuarioRepositorio;
        }

        //INTERFACE É UMA REPRESENTAÇAO DO RESULTADO (TELA)
        // [HttpGet]
        public IActionResult Login()
        {
            //RETORNA A PAGINA INDEX
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);

            if (usuario != null && usuario.Senha == senha)
            {
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "Email / senha Inválidos");


            //RETORNA A PAGINA LOGIN
            return View();
        }
    }
}
