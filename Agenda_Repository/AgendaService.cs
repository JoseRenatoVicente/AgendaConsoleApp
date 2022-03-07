using Agenda_Repository.Entities;
using Agenda_Repository.Entities.Enums;
using Agenda_Repository.Repository;
using System;

namespace Agenda_Repository
{
    public class AgendaService
    {
        AgendaRepository repository = new AgendaRepository();

        public void GetAllContacts()
        {
            Contact[] contact = repository.GetAll();

            if (contact[0] == null)
                Console.WriteLine("Agenda vazia. Adicione um contato primeiro");
            else
            {
                foreach (Contact c in contact)
                {
                    if (c != null) Console.WriteLine(c.Get());
                }
            }
        }

        public void GetContactByName()
        {
            if (repository.GetAll()[0] == null)
            {
                Console.WriteLine("Agenda vazia. Adicione um contato primeiro");
                Program.BackMenu();
            }
            Console.WriteLine("Digite o nome do contato: ");
            string name = Console.ReadLine().ToLower();

            if (name.Length < 1)
            {
                Console.WriteLine("O Nome digitado é inválido");
                GetContactByName();
            }

            Contact[] contact = repository.GetByName(name);

            if (contact[0] == null)
            {
                Console.WriteLine("Nenhum contato encontrado");
            }

            foreach (Contact c in contact)
            {
                if (c != null) Console.WriteLine(c.Get());
            }
        }

        public void AddContact()
        {

            if (repository.count > 4)
            {
                Console.WriteLine("Agenda cheia! já possui 5 contatos cadastrados");
                Program.BackMenu();
            }

            Console.WriteLine(repository.Add(InputInfo(new Contact())).Get());

            Console.WriteLine("Contato adicionado com sucesso");
        }


        private Contact InputInfo(Contact contact)
        {
            Contact Contact = contact;

            if (contact.Name == null || contact.Name == "")
            {
                Console.Write("Digite o nome do contato: ");
                Contact.Name = Console.ReadLine();

                if (string.Empty == Contact.Name)
                {
                    Console.WriteLine($"O nome está vazio");
                    InputInfo(contact);
                }
            }
            if (contact.Phone == 0)
            {
                Console.Write("Digite o telefone do contato: ");
                if (Int32.TryParse(Console.ReadLine(), out int numValue))
                    Contact.Phone = numValue;
                else
                {
                    Console.WriteLine($"Formato incorreto digite um número de telefone válido");
                    InputInfo(contact);
                }

            }
            if (contact.Age == 0)
            {
                Console.Write("Digite a idade do contato: ");
                if (Int32.TryParse(Console.ReadLine(), out int numValue))
                    if (numValue >= 1)
                        Contact.Age = numValue;
                    else
                    {
                        Console.WriteLine($"Formato incorreto digite uma idade válida");
                        InputInfo(contact);
                    }
            }
            if (contact.Gender == 0)
            {
                Console.Write("Digite o sexo do contato: ");
                Console.Write(@"
 1- Masculino
 2- Feminino
 3- InterSexo
");

                if (Int32.TryParse(Console.ReadLine(), out int numValue))
                    if (numValue >= 1 && numValue <= 3)
                        Contact.Gender = (Gender)numValue;
                    else
                    {
                        Console.WriteLine($"Formato incorreto digite uma idade válida");
                        InputInfo(contact);
                    }
            }

            Console.Clear();

            return Contact;

        }

        public void Remove()
        {
            CheckIsEmpty();

            Console.WriteLine("Digite o nome ou id do contato: ");
            string where = Console.ReadLine().ToLower();

            if (where.Length < 1)
            {
                Console.WriteLine("O Nome digitado é inválido");
                GetContactByName();
            }

            Contact[] contact = repository.GetByName(where);

            if (contact[0] == null)
            {
                Console.WriteLine("Nenhum contato encontrado");
                Remove();
            }


            int countSearch = 0;
            foreach (Contact c in contact)
            {
                if (c != null)
                {
                    countSearch++;
                    Console.WriteLine(c.Get());
                }
            }

            if (countSearch==1)
            {
                repository.Remove(contact[0].Id);

                Console.WriteLine("Contato Removido com sucesso");
            }
            else
                Remove();

        }

        public void CheckIsEmpty()
        {
            if (repository.GetAll()[0] == null)
            {
                Console.WriteLine("Agenda vazia. Adicione um contato primeiro");
                Program.BackMenu();
            }
        }


    }
}
