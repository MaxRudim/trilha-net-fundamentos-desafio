using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string placa = Console.ReadLine();

#pragma warning disable SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.
            while (string.IsNullOrEmpty(placa) || !Regex.IsMatch(placa, @"^[A-Za-z]{3}-\d{4}$"))
            {
                Console.WriteLine("Placa inválida, digite novamente no formato ABC-1234:");
                placa = Console.ReadLine();
            }
#pragma warning restore SYSLIB1045 // Convert to 'GeneratedRegexAttribute'.

            veiculos.Add(placa.ToUpper());

            Console.WriteLine($"Veículo de placa {placa.ToUpper()} foi estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            while (string.IsNullOrEmpty(placa))
            {
                Console.WriteLine("Placa inválida, digite novamente:");
                placa = Console.ReadLine();
            }

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                bool validHours = int.TryParse(Console.ReadLine(), out int horas);

                while (validHours == false)
                {
                    Console.WriteLine("Horas inválidas, digite novamente:");
                    validHours = int.TryParse(Console.ReadLine(), out horas);
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas); 

                veiculos.Remove(placa.ToUpper());

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente!");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");

                foreach (var (veiculo, index) in veiculos.Select((veiculo, index) => (veiculo, index)))
                {
                    Console.WriteLine($"{index + 1} - " + veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
