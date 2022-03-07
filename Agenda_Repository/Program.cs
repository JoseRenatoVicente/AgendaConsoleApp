using System;

namespace Agenda_Repository
{
    internal class Program
    {
        static AgendaService agendaService = new AgendaService();
        static void Main(string[] args)
        {
            /// <summary>
            /// Criar uma agenda de contatos:
            ///
            /// Contatos devem ter:
            ///
            /// - nome
            /// - telefone
            /// - idade
            /// - sexo
            ///
            /// A agenda deverá ter no máximo 05 contatos:
            /// Contato agenda = new Contato[5];

            /// MENU

            /// 1 – Inserir Contato
            /// 2 – Imprimir os contatos
            /// 3 – Busca de Contato por nome
            /// 4 - Remover contato
            /// </summary>
            /// 



            Menu();

            Console.ReadKey();
        }

        

        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine(@"
---------------------------------------Agenda------------------------------------------------

                                1 – Inserir Contato
                                2 – Imprimir os contatos
                                3 – Busca de Contato por nome
                                4 - Remover contato
                                ------------------------------
                                0 - Sair

---------------------------------------------------------------------------------------------
");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0": Environment.Exit(0); break;

                case "1":
                    Console.Clear();
                    agendaService.AddContact();
                    BackMenu();
                    break;

                case "2":
                    Console.Clear();
                    agendaService.GetAllContacts();
                    BackMenu(); break;

                case "3":
                    Console.Clear();
                    agendaService.GetContactByName();
                    BackMenu(); break;

                case "4":
                    Console.Clear();
                    agendaService.Remove();
                    BackMenu(); break;

                default:
                    Console.WriteLine("Opção digitada inválida! ");
                    BackMenu();
                    break;
            }

        }

        public static void BackMenu()
        {
            Console.WriteLine("\n Pressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Menu();
        }

    }
}
