using Agenda_Repository.Entities.Base;
using Agenda_Repository.Entities.Enums;

namespace Agenda_Repository.Entities
{
    internal class Contact : EntityBase
    {
        public Contact()
        {

        }


        public Contact(string name, int phone, int age, Gender gender)
        {
            Name = name;
            Phone = phone;
            Age = age;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }

        public string Get()
        {
            return $"ID: {Id} \nNome: {Name} \nTelefone: {Phone} \nIdade: {Age} \nSexo: {Gender}\n";
        }


    }
}
