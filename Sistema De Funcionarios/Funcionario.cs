namespace Sistema_de_Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; } = string.Empty;
        public double SalarioBase { get; set; }
        public double SalarioFinal { get; set; }

        public abstract double CalcularSalario();

        public void ExibirResumo()
        {
            Console.WriteLine($"Dados do funcionario: Nome - {Nome}, SalarioBase{SalarioBase}, SalarioFinal:{CalcularSalario():F2}");
        }
    }
}