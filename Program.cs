using MySql.Data.MySqlClient;
using System;
using System.Threading;

namespace SistemaMonitoramento
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Login()) return;
            ExibirMenu();
        }

        static bool Login()
        {
            int tentativas = 0;
            while (tentativas < 3)
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("     Tela de Login      ");
                Console.WriteLine("========================");
                
                Console.Write("Usuário: ");
                string usuario = Console.ReadLine();
                Console.Write("Senha: ");
                string senha = ReadPassword();

                if (usuario == "Pablin" && senha == "306090")
                {
                    Console.WriteLine("\nAcesso concedido! Redirecionando...");


                     
                    Thread.Sleep(2000);
                    return true;
                }
                else
                {
                    tentativas++;
                    Console.WriteLine("\nAcesso negado! Tente novamente.");
                    Thread.Sleep(2000);
                }
            }
            Console.WriteLine("\nNúmero máximo de tentativas atingido! Saindo...");
            return false;
        }

        static string ReadPassword()
        {
            string senha = "";
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey(intercept: true);
                if (tecla.Key != ConsoleKey.Enter && tecla.Key != ConsoleKey.Backspace)
                {
                    senha += tecla.KeyChar;
                    Console.Write("*");
                }
                else if (tecla.Key == ConsoleKey.Backspace && senha.Length > 0)
                {
                    senha = senha.Substring(0, senha.Length - 1);
                    Console.Write("\b \b");
                }
            } while (tecla.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return senha;
        }

        static void ExibirMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================");
                Console.WriteLine("  Menu Principal  ");
                Console.WriteLine("=====================");
                Console.WriteLine("1 - Iniciar Sensores");
                Console.WriteLine("2 - Banco de Dados");
                Console.WriteLine("3 - Sair");
                Console.Write("Escolha uma opção: ");
                
                string escolha = Console.ReadLine();
                if (escolha == "1") new SistemaMonitoramento().Iniciar();
                else if (escolha == "2") ExibirBancoDeDados();
                else if (escolha == "3") break;
            }
        }

        static void ExibirBancoDeDados()
        {
            Console.Clear();
            Console.WriteLine("=====================");
            Console.WriteLine("  Dados do Banco  ");
            Console.WriteLine("=====================");
            
            string connStr = "Server=localhost;Database=Monitoramento;Uid=pablin;Pwd=;";
            using (var conexao = new MySqlConnection(connStr))
            {
                conexao.Open();
                string query = "SELECT * FROM Monitoramento";
                var comando = new MySqlCommand(query, conexao);
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Leitura"].ToString());
                }
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
    }

    public class SistemaMonitoramento
    {
        private bool alertaAtivo = false;
        private Random random = new Random();

        public void Iniciar()
        {
            Console.Clear();
            Console.WriteLine("Iniciando Sensores...");
            Thread.Sleep(2000);
            while (true)
            {
                if (!alertaAtivo)
                {
                    decimal temperatura = GerarTemperatura();
                    string dataHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    
                    if (temperatura >= 80)
                    {
                        alertaAtivo = true;
                        Console.Clear();
                        Console.WriteLine($"⚠ ALERTA CRÍTICO! {temperatura}°C");
                        Console.WriteLine("Pressione 'U' para parar o alerta!");
                        SalvarDados($"ALERTA! {temperatura}°C - {dataHora}");
                        Thread beepThread = new Thread(TocarAlarme);
                        beepThread.Start();
                    }
                    else
                    {
                        Console.WriteLine($"Temperatura: {temperatura}°C - {dataHora}");
                    }
                }
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.U)
                {
                    alertaAtivo = false;
                    Console.Clear();
                    Console.WriteLine("Alerta encerrado!");
                    Thread.Sleep(2000);
                }
                Thread.Sleep(2000);
            }
        }

        private decimal GerarTemperatura()
        {
            if (random.Next(1, 101) <= 35) return random.Next(80, 90) + random.Next(0, 99) / 100m;
            return random.Next(30, 79) + random.Next(0, 99) / 100m;
        }

        private void SalvarDados(string leitura)
        {
            string connStr = "Server=localhost;Database=Monitoramento;Uid=pablin;Pwd=;";
            using (var conexao = new MySqlConnection(connStr))
            {
                conexao.Open();
                var comando = new MySqlCommand("INSERT INTO Monitoramento (Leitura) VALUES (@Leitura);", conexao);
                comando.Parameters.AddWithValue("@Leitura", leitura);
                comando.ExecuteNonQuery();
            }
            Console.WriteLine("📌 Relatório salvo no banco de dados.");
        }

        private void TocarAlarme()
        {
            while (alertaAtivo)
            {
                Console.Beep(1000, 500);
                Thread.Sleep(500);
            }
        }
    }
}
