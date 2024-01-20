using System;
using System.Collections.Generic;
using System.Text;

namespace POOCsharp.models
{
    public class Banco
    {
        public string Numero { get; }
        public string Dono { get; set; }
        public decimal Saldo
        {
            get
            {
                decimal saldo = 0;
                foreach (var item in todasTrasancoes)
                {
                    saldo += item.Valor;
                }
                return saldo;
            }
        }
        public static int NumeroConta = 123456;
        private List<Transacao> todasTrasancoes = new List<Transacao>();

        public Banco(string nome, decimal valor)
        {
            this.Dono = nome;
            NumeroConta++;
            this.Numero = NumeroConta.ToString();
            Depositar(valor, DateTime.Now, "Saldo Inicial");
        }

        public void Depositar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não aceitamos depósito de 0 ou números negativos.");
            }
            Transacao trans = new Transacao(valor, data, obs);
            todasTrasancoes.Add(trans);
        }

        public void Sacar(decimal valor, DateTime data, string obs)
        {
            if (valor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(valor), "Não aceitamos saques de 0 ou números negativos.");
            }
            else if (Saldo - valor < 0)
            {
                throw new InvalidOperationException("Essa operação não é permitida");
            }
            Transacao trans = new Transacao(-valor, data, obs);
            todasTrasancoes.Add(trans);
        }

        public string pegarMovimentacao()
        {
            var movimentacoes = new StringBuilder();
            movimentacoes.AppendLine("Data --> Valor --> Obs");
            foreach (var item in todasTrasancoes)
            {
                movimentacoes.AppendLine($"{item.Data} {item.Valor} {item.Obs}");
            }
            return movimentacoes.ToString();
        }
    }
}