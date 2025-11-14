using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_De_Funcionarios_MVC.Data;
using Sistema_De_Funcionarios_MVC.Models;

namespace Sistema_De_Funcionarios_MVC.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly AppDbContext _context;

        public FuncionarioController(AppDbContext contextConstrutor)
        {
            _context = contextConstrutor;
        }

        //* Listar
        //async / await -> executa a funcao de listar dentro do banco, mas permite que o sistema continue rodando enquanto isso acontece.
        public async Task<IActionResult> Index()
        {
            //ToList - lista as informacoes dentro da tabela funcionario.
            var lista = await _context.TabelaFuncionario.ToListAsync();

            // retorna a view com a lista de funcionarios no index.
            return View(lista);
        }

        //* Formulario de criacao - retorna a lista de formulario vazia
        [HttpGet] //GET - Listar (Como se fose um SELECT no banco) 
        public IActionResult Criar() => View();

        //* Cadastrar as informacoes do formulario no banco de dados.
        [HttpPost]
        public async Task<IActionResult> Criar(string NomeConstrutor, double SalarioBaseConstrutor, string CargoConstrutor)
        {
            Funcionario? novoFuncionario = null;

            if(CargoConstrutor == "Gerente")
            {
                novoFuncionario = new Gerente(NomeConstrutor, SalarioBaseConstrutor);
            }
            else if (CargoConstrutor == "Vendedor")
            {
                novoFuncionario = new Vendedor(NomeConstrutor, SalarioBaseConstrutor);
            }
            else
            {
                return BadRequest("Cargo Invalido");
            }

            _context.TabelaFuncionario.Add(novoFuncionario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        //! Excluir

        public async Task<IActionResult> Deletar(int id)
        {
            // Variavel que vai armazenar o registro de funcionario encontrado pelo id.
            //Find(id) -> Busca o registro pelo id
            var funcionario = await _context.TabelaFuncionario.FindAsync(id);

            if(funcionario == null) return NotFound();

            //* Remove() -> remove o registro do banco
            _context.TabelaFuncionario.Remove(funcionario);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
