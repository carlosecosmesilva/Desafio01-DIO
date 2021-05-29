using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        private static string Exc;

        static void Main(string[] args)
        {   
           string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X"){

            switch (opcaoUsuario)
            {
             case "1":
                ListarSeries();
             break;
             
             case "2":
                InserirSerie();
             break;
             
             case "3":
                AtualizarSerie();
             break;
             
             case "4":
                ExcluirSerie();
             break;
             
             case "5":
                VisualizarSerie();
             break;
             
             case "C":
                Console.Clear();
             break;
            
             case "X":
                Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
             break;
             
             default:
                throw new ArgumentOutOfRangeException("Insira uma opção válida.");
            }

            opcaoUsuario = ObterOpcaoUsuario();
        }
    }
     private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");

            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

                Console.WriteLine("#Id {0}: - {1} {2}",serie.retornaId(), serie.retornaTitulo(), (excluido ?"*Excluído*" : ""));
            }    
        }
        private static void InserirSerie()
        {
              foreach (int i in Enum.GetValues(typeof(Genero)))
              {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero),i));                  
              }

              Console.WriteLine();
              Console.WriteLine("Digite o gênero entre as opções acima: ");
              int entradaGenero = int.Parse(Console.ReadLine());

              Console.WriteLine("Digite o Titulo da Série: ");
              string entradaTitulo = Console.ReadLine();

              Console.WriteLine("Digite o Ano de Inicio da Série: ");
              int entradaAno = int.Parse(Console.ReadLine());

              Console.WriteLine("Digite a Descrição da Série: ");
              string entradaDescricao = Console.ReadLine();

              Serie novaSerie = new Serie( id: repositorio.ProximoId(),
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao:entradaDescricao);
                                           
              repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
             Console.Write("Digite o id da série: ");
             int indiceSerie = int.Parse(Console.ReadLine());

             foreach (int i in Enum.GetValues(typeof(Genero)))
             {
                 Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
             }
             Console.Write("Digite o genêro entre as opções acima: ");
             int entradaGenero = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite o Titulo da Série: ");
             string entradaTitulo = Console.ReadLine();

             Console.WriteLine("Digite o Ano de Inicio da Série: ");
             int entradaAno = int.Parse(Console.ReadLine());

             Console.WriteLine("Digite a Descrição da Série: ");
             string entradaDescricao = Console.ReadLine();

             Serie atualizaSerie = new Serie( id: repositorio.ProximoId(),
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao:entradaDescricao);
                                           
              repositorio.Atualiza(indiceSerie, atualizaSerie); 
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
                Console.WriteLine("Deseja excluir a série ?");
                Console.WriteLine("Digite (S) para sim, (N) para não ou (M) para menu inicial...");
                Exc = Console.ReadLine().ToUpper();
                
                while (Exc.ToUpper() != "M")
                {
                switch (Exc)
                {
                    case "S":
                    repositorio.Exclui(indiceSerie);
                    Console.WriteLine("Série excluída!");
                    return;
                    
                    case "N":
                    Console.WriteLine("Série não excluída!");
                    return;
                    
                    case "M":
                    ObterOpcaoUsuario();
                    break;
                    
                    default:
                    throw new ArgumentOutOfRangeException("Insira uma opção válida.");
                }

            } 
            
            

        }
        private static void VisualizarSerie()
        { 
              Console.Write("Digite o id da série: ");
              int indiceSerie = int.Parse(Console.ReadLine());
              
              var serie = repositorio.RetornaPorId(indiceSerie);

              Console.WriteLine(serie);
              
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }

}