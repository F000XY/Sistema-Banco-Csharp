using System;

namespace POOCsharp.models
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criar uma instância da classe Banco
            Banco minhaConta = new Banco("Nathy", 10000000);

            // Acessar as propriedades da instância
            Console.WriteLine($"Dono da conta: {minhaConta.Dono}");
            Console.WriteLine($"Saldo da conta: {minhaConta.Saldo}");
            Console.WriteLine($"Numero da conta: {minhaConta.Numero}");

            minhaConta.Depositar(1000, DateTime.Now, "Recebi um pagamento");
           
            try
            {
                minhaConta.Sacar(10, DateTime.Now, "Salgadinho");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                //  joga pra tras e retorna a msg de erro que esta no banco.cs Ln.49
            }
            catch (Exception ex)
            {
                Console.WriteLine("Operação não realizada");
            }

            minhaConta.Sacar(1500, DateTime.Now, "Aluguel");
            minhaConta.Sacar(2000, DateTime.Now, "Escola");
            Console.WriteLine($"Saldo da conta: {minhaConta.Saldo}");

            Console.WriteLine(minhaConta.pegarMovimentacao());
        }
    }
}