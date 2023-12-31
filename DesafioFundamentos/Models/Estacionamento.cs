namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal _precoInicial = 0;
        private decimal _precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public decimal PrecoInicial{
            get{ return _precoInicial; }
            set{
                if (value > 0){
                    _precoInicial = value;
                }
                else{
                    throw new ArgumentException("O preço inicial tem que ser um valor númerico positivo.");
                }
            }
        }

        public decimal PrecoPorHora{
            get{ return _precoPorHora; }
            set{
                if(value > 0){
                    _precoPorHora = value;
                }
                else{
                    throw new ArgumentException("O preço por hora tem que ser um valor númerico positivo.");
                }
            }
        }

        public Estacionamento(decimal precoInicial, decimal precoPorHora){
            PrecoInicial = precoInicial;
            PrecoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo(){   
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            string novaPlaca = Console.ReadLine();

            veiculos.Add(novaPlaca);
        }

        public void RemoverVeiculo(decimal precoInicial, decimal precoPorHora){
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper())){
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                
                int horasEstacionado = 0;

                horasEstacionado = Convert.ToInt32(Console.ReadLine());

                if (horasEstacionado > 0){

                    decimal valorTotal = precoInicial + (precoPorHora * horasEstacionado); 

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else{
                    Console.WriteLine("O número de horas que o veículo permaneceu estacionado tem que ser um valor númerico positivo.");
                }
            }
            else{
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos(){
            if (veiculos.Any()){
                Console.WriteLine("Os veículos estacionados são:");

               foreach (string veiculo in veiculos){
                    Console.WriteLine(veiculo);
                }       
            }
            else{
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
