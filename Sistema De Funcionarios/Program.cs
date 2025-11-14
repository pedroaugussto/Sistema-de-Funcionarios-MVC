namespace Sistema_de_Funcionarios;

class Program
{
    static void Main(string[] args)
    {
        // Gerente gerente1 = new Gerente("geraldo", 3050.00 );
        // Vendedor vendedor1 = new Vendedor("Pedro", 1000.00);

        // gerente1.CalcularSalario();
        // vendedor1.CalcularSalario();

        // gerente1.ExibirResumo();
        // vendedor1.ExibirResumo();
        List<Funcionario> funcionarios = new List<Funcionario>
        {
            new Gerente ("Kessia", 5000),
            new Vendedor("Thiago", 3000)
        };

        foreach(var funcionario in funcionarios)
        {
            funcionario.ExibirResumo();
        }
    }
}
