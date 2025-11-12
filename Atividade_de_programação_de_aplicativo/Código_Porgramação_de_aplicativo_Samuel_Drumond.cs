
using System;

namespace P_A
{
	class Cliente
	{
		public string Nome;
		public int Idade;
		public string Gmail;
		public string Telefone;
		public string Cep;
	}
	
	class veiculo
	{
		public string nome;
		public double valor;
	}
	
	class vendedor
	{
		public string gmail;
		public string senha;
	}
	

	class Program
	{
		const int MAX = 100;

		static string[] gmail = new string[MAX];
		static string[] senha = new string[MAX];
		static int totalContas = 0;

		
		static Cliente[] clientes = new Cliente[MAX];
		static int totalClientes = 0;

		
		static string[] carros = new string[MAX];
		static string[] carrosPreços = new string[MAX];
		static bool[] carroEmprestado = new bool[MAX];
		static int totalCarros = 0;

		static string[] motos = new string[MAX];
		static string[] motosPreços = new string[MAX];
		static bool[] motoEmprestada = new bool[MAX];
		static int totalMotos = 0;


		public static void Main(string[] args)
		{
			bool continuar = true;

			while (continuar)
			{
				Console.WriteLine("----------------------------------------------------------------");
				Console.WriteLine("Digite o número de acordo com a sua escolha!");
				Console.WriteLine("1 : Fazer Login");
				Console.WriteLine("2 : Criar cadastro (Conta de Acesso)");
				Console.WriteLine("3 : Seleção de ações (Veículos)");
				Console.WriteLine("4 : Cadastrar Cliente");
				Console.WriteLine("5 : Sair");
				Console.WriteLine("----------------------------------------------------------------");


				
				int escolha = int.Parse(Console.ReadLine());

				switch (escolha)
				{
					case 1:
						FazerLogin();
						break;

					case 2:
						CriarCadastro();
						break;

					case 3:
						SelecionarAções();
						break;

					case 4:
						CadastrarCliente();
						break;

					case 5:
						Console.WriteLine("Saindo...");
						continuar = false;
						break;

					default:
						Console.WriteLine("Opção inválida!");
						break;
				}


				if (continuar)
				{
					Console.WriteLine("\nPressione qualquer tecla para continuar o menu ou digite 'sair' para finalizar a aplicação.");
					string resposta = Console.ReadLine();
					if (resposta.ToLower() == "sair")
					{
						continuar = false;
					}
					Console.Clear();
				}
			}
		}


		public static void FazerLogin()
		{
			Console.WriteLine("Fazer Login");
			Console.Write("Escreva seu gmail: ");
			string gmailLogin = Console.ReadLine();

			Console.Write("Escreva sua senha: ");
			string senhaLogin = Console.ReadLine();

			bool loginOk = false;
			for (int i = 0; i < totalContas; i++)
			{
				if (gmail[i] == gmailLogin && senha[i] == senhaLogin)
				{
					loginOk = true;
					break;
				}
			}

			if (loginOk)
				Console.WriteLine("Login efetuado! Seja bem-vindo de volta!");
			else
				Console.WriteLine("Email ou senha incorretos!");
		}


		public static void CriarCadastro()
		{
			Console.WriteLine("Criar Cadastro (Conta de Acesso)");
			if (totalContas >= MAX)
			{
				Console.WriteLine("Limite de cadastros de contas atingido!");
				return;
			}

			Console.Write("Escreva seu nome: ");
			string nome = Console.ReadLine();


			Console.Write("Escreva sua idade: ");
			int idade = int.Parse(Console.ReadLine());
			
			if (idade <= 17)
			{
				Console.WriteLine("Você não pode se cadastrar pois é menor de idade.");
				return;
			}


			Console.Write("Escreva seu gmail: ");
			gmail[totalContas] = Console.ReadLine();


			Console.Write("Escreva sua senha: ");
			senha[totalContas] = Console.ReadLine();


			totalContas++;
			Console.WriteLine("Cadastro de conta efetuado!");
		}


		public static void SelecionarAções()
		{
			Console.Clear();
			Console.WriteLine("Veículos e Ações");
			Console.WriteLine("------------------------- Veículos a Venda --------------------------");
			ExibirCarrosDisponiveis();
			ExibirMotosDisponiveis();
			Console.WriteLine("--------------------------------------------------------------------");
			Console.WriteLine("Digite o número correspondente a ação que deseja fazer:");
			Console.WriteLine("1: Cadastrar algum produto (Carro/Moto)");
			Console.WriteLine("2: Vender algum produto");
			Console.WriteLine("3: Emprestar algum produto");


			int escolhaAção = int.Parse(Console.ReadLine());

			switch (escolhaAção)
			{
				case 1:
					CadastrarProduto();
					break;

				case 2:
					VenderProduto();
					break;

				case 3:
					EmprestarProduto();
					break;


				default:
					Console.WriteLine("Opção inválida!");
					break;
			}
		}


		public static void CadastrarProduto()
		{
			Console.WriteLine("Cadastrar Produto");
			Console.WriteLine("1: Cadastrar um carro");
			Console.WriteLine("2: Cadastrar uma moto");


			int escolhaCadastro = int.Parse(Console.ReadLine());

			switch (escolhaCadastro)
			{
				case 1:
					CadastrarCarro();
					break;


				case 2:
					CadastrarMoto();
					break;


				default:
					Console.WriteLine("Opção inválida!");
					break;
			}
		}


		public static void CadastrarCarro()
		{
			if (totalCarros >= MAX)
			{
				Console.WriteLine("Limite de carros atingido!");
				return;
			}


			Console.WriteLine("--- Cadastro de Carro ---");
			Console.Write("Qual o nome do seu carro? ");
			carros[totalCarros] = Console.ReadLine();


			Console.Write("Qual o valor do seu carro? ");
			carrosPreços[totalCarros] = Console.ReadLine();

			carroEmprestado[totalCarros] = false;
			totalCarros++;
			Console.WriteLine("Cadastro de carro efetuado!");
		}


		public static void CadastrarMoto()
		{
			if (totalMotos >= MAX)
			{
				Console.WriteLine("Limite de motos atingido!");
				return;
			}


			Console.WriteLine("--- Cadastro de Moto ---");
			Console.Write("Qual o nome da sua moto? ");
			motos[totalMotos] = Console.ReadLine();


			Console.Write("Qual o valor da sua moto? ");
			motosPreços[totalMotos] = Console.ReadLine();

			motoEmprestada[totalMotos] = false;
			totalMotos++;
			Console.WriteLine("Cadastro de moto efetuado!");
		}


		public static void ExibirCarrosDisponiveis()
		{
			Console.WriteLine("Carros disponíveis:");
			bool encontrou = false;
			for (int i = 0; i < totalCarros; i++)
			{
				if (carros[i] != null)
				{
					encontrou = true;
					string status = carroEmprestado[i] ? " (Alugado)" : " (Disponível)";
					Console.WriteLine((i + 1) + " : " + carros[i] + " | Preço: " + carrosPreços[i] + status);
				}
			}
			if (!encontrou)
			{
				Console.WriteLine("Nenhum carro disponível.");
			}
		}


		public static void ExibirMotosDisponiveis()
		{
			Console.WriteLine("Motos disponíveis:");
			bool encontrou = false;
			for (int i = 0; i < totalMotos; i++)
			{
				if (motos[i] != null)
				{
					encontrou = true;
					string status = motoEmprestada[i] ? " (alugada)" : " (Disponível)";
					Console.WriteLine((i + 1) + " : " + motos[i] + " | Preço: " + motosPreços[i] + status);
				}
			}
			if (!encontrou)
			{
				Console.WriteLine("Nenhuma moto disponível.");
			}
		}


		public static void VenderProduto()
		{
			Console.WriteLine("Vender Produto");
			Console.WriteLine("Escolha o produto para vender:");
			Console.WriteLine("1 : Carros");
			Console.WriteLine("2 : Motos");


			int escolhaVenda = int.Parse(Console.ReadLine());


			switch (escolhaVenda)
			{
				case 1:
					Console.WriteLine("Escolha o carro para vender (Digite o número):");
					ExibirCarrosDisponiveis();
					int carroEscolhido = int.Parse(Console.ReadLine());
					int indiceCarro = carroEscolhido - 1;

					if (indiceCarro >= 0 && indiceCarro < totalCarros && carros[indiceCarro] != null)
					{
						string nomeCarroVendido = carros[indiceCarro];
						string precoCarroVendido = carrosPreços[indiceCarro];

						for (int i = indiceCarro; i < totalCarros - 1; i++)
						{
							carros[i] = carros[i + 1];
							carrosPreços[i] = carrosPreços[i + 1];
							carroEmprestado[i] = carroEmprestado[i + 1];
						}

						carros[totalCarros - 1] = null;
						carrosPreços[totalCarros - 1] = null;
						carroEmprestado[totalCarros - 1] = false;
						totalCarros--;

						
						Console.WriteLine("Você vendeu o " + nomeCarroVendido + " por " + precoCarroVendido + ".");
					}
					else
					{
						Console.WriteLine("Carro inválido ou não disponível para venda!");
					}
					break;


				case 2:
					Console.WriteLine("Escolha a moto para vender (Digite o número):");
					ExibirMotosDisponiveis();
					int motoEscolhida = int.Parse(Console.ReadLine());
					int indiceMoto = motoEscolhida - 1;

					if (indiceMoto >= 0 && indiceMoto < totalMotos && motos[indiceMoto] != null)
					{
						string nomeMotoVendida = motos[indiceMoto];
						string precoMotoVendida = motosPreços[indiceMoto];

						for (int i = indiceMoto; i < totalMotos - 1; i++)
						{
							motos[i] = motos[i + 1];
							motosPreços[i] = motosPreços[i + 1];
							motoEmprestada[i] = motoEmprestada[i + 1];
						}

						motos[totalMotos - 1] = null;
						motosPreços[totalMotos - 1] = null;
						motoEmprestada[totalMotos - 1] = false;
						totalMotos--;
						Console.WriteLine("Você vendeu a " + nomeMotoVendida + " por " + precoMotoVendida + ".");
					}
					else
					{
						Console.WriteLine("Moto inválida ou não disponível para venda!");
					}
					break;


				default:
					Console.WriteLine("Opção inválida!");
					break;
			}
		}

		public static void EmprestarProduto()
		{
			Console.WriteLine("Alugar Produto");
			Console.WriteLine("Escolha o tipo de produto que deseja alugar:");
			Console.WriteLine("1 : Carros");
			Console.WriteLine("2 : Motos");


			
			int escolhaEmprestimo = int.Parse(Console.ReadLine());

			switch (escolhaEmprestimo)
			{
				case 1:
					Console.WriteLine("Escolha o carro que deseja alugar (Digite o número):");
					ExibirCarrosDisponiveis();

					int carroEscolhido = int.Parse(Console.ReadLine());
					int indiceCarro = carroEscolhido - 1;

					if (indiceCarro >= 0 && indiceCarro < totalCarros)
					{
						if (carros[indiceCarro] == null)
						{
							Console.WriteLine("Este carro não existe mais no estoque.");
						}
						else if (carroEmprestado[indiceCarro])
						{
							
							Console.WriteLine("O carro " + carros[indiceCarro] + " já está alugado.");
						}
						else
						{
							carroEmprestado[indiceCarro] = true;
							Console.WriteLine("Você alugou o carro " + carros[indiceCarro] + " com valor de " + carrosPreços[indiceCarro] + ".");
						}
					}
					else
					{
						Console.WriteLine("Carro inválido!");
					}
					break;


				case 2:
					Console.WriteLine("Escolha a moto que deseja alugar (Digite o número):");
					ExibirMotosDisponiveis();

					int motoEscolhida = int.Parse(Console.ReadLine());
					int indiceMoto = motoEscolhida - 1;

					if (indiceMoto >= 0 && indiceMoto < totalMotos)
					{
						if (motos[indiceMoto] == null)
						{
							Console.WriteLine("Esta moto não existe mais no estoque.");
						}
						else if (motoEmprestada[indiceMoto])
						{
							
							Console.WriteLine("A moto " + motos[indiceMoto] + " já está alugada.");
						}
						else
						{
							motoEmprestada[indiceMoto] = true;
							Console.WriteLine("Você alugou a moto " + motos[indiceMoto] + " com valor de " + motosPreços[indiceMoto] + ".");
						}
					}
					else
					{
						Console.WriteLine("Moto inválida!");
					}
					break;


				default:
					Console.WriteLine("Opção inválida!");
					break;
			}
		}
		
		public static void CadastrarCliente()
		{
			Console.Clear();

			if (totalClientes >= MAX)
			{
				Console.WriteLine("Limite de clientes atingido!");
				return;
			}


			Cliente cliente = new Cliente();


			Console.WriteLine("Vamos cadastrar um cliente dentro da nossa concessionária!");
			Console.WriteLine("----------------------------------------------------------------");
			Console.WriteLine("Vamos para as informações do cliente!");


			Console.Write("Nome: ");
			cliente.Nome = Console.ReadLine();


			Console.Write("Idade: ");
			cliente.Idade = int.Parse(Console.ReadLine());


			Console.Write("Gmail: ");
			cliente.Gmail = Console.ReadLine();


			Console.Write("Telefone: ");
			cliente.Telefone = Console.ReadLine();


			Console.Write("CEP: ");
			cliente.Cep = Console.ReadLine();

			clientes[totalClientes] = cliente;
			totalClientes++;


			Console.WriteLine("\n--- Dados do Cliente Cadastrado ---");
			Console.WriteLine("Nome: " + cliente.Nome);
			Console.WriteLine("Idade: " + cliente.Idade);
			Console.WriteLine("Gmail: " + cliente.Gmail);
			Console.WriteLine("Telefone: " + cliente.Telefone);
			Console.WriteLine("CEP: " + cliente.Cep);
			Console.WriteLine("**Cliente cadastrado com sucesso!**");
		}
	}
}