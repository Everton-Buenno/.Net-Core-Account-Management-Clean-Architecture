using Domain.Enums;

namespace Domain.Entities
{
    public class ContaPoupanca : ContaBancaria
    {
        public ContaPoupanca() : base( 0, null, TipoConta.Poupanca)
        {
        }
        public ContaPoupanca( decimal saldo, Cliente cliente):base(saldo,cliente, TipoConta.Poupanca)
        {
        }
        public override bool Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new Exception("O valor do saque deve ser positivo");
            if (Saldo >= valor)
            {
                Saldo -= valor;
                return true;
            }
            return false;
        }
        public void AplicarRendimento(decimal taxaJuros)
        {
            if (taxaJuros <= 0m)
                throw new Exception("A taxa de juros deve ser maior que 0.0");
            Saldo += Saldo * taxaJuros;
        }

      
    }
}
