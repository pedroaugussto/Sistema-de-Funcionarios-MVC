namespace Sistema_de_Funcionarios
{
    public class Gerente : Funcionario 
    {
        public double Bonus 
        {
            get
            {
                return 0.50;
            }
            set
            {
                Bonus = value;
            }
        }
        public override double CalcularSalario()
        {
            return SalarioBase + (SalarioBase * Bonus);
        }
        public Gerente (string NomeConstrutor, double SalarioBaseConstrutor)
        {
            Nome = NomeConstrutor;
            SalarioBase = SalarioBaseConstrutor;
        }
    }
}