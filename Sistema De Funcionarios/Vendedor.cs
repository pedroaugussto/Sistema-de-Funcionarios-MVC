namespace Sistema_de_Funcionarios
{
    public class Vendedor : Funcionario
    {
        public double Bonus 
        {
            get
            {
                return 0.20;
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
            public Vendedor (string NomeConstrutor, double SalarioBaseConstrutor)
        {
            Nome = NomeConstrutor;
            SalarioBase = SalarioBaseConstrutor;
        }
    }
}