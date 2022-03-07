using Agenda_Repository.Entities;
using Agenda_Repository.Repository.Base;

namespace Agenda_Repository.Repository
{
    class AgendaRepository : IRepository<Contact>
    {
        Contact[] agenda = new Contact[5];
        public int count = 0;
        public Contact Add(Contact entity)
        {
            entity.Id = count + 1;
            agenda[count++] = entity;
            SortContacts(agenda);

            return entity;
        }

        public Contact[] GetAll()
        {
            return agenda;
        }

        public Contact[] GetAllSorted()
        {
            return agenda;
        }

        public Contact[] GetByName(string where)
        {
            Contact[] searchContact = new Contact[5];
            int countSearch = 0;

            foreach (Contact c in agenda)
            {
                if (c != null)
                    if (c.Id != 0 && c.Name.ToLower().Contains(where) || c.Id.ToString().Contains(where))
                    {

                        searchContact[countSearch] = c;
                        countSearch++;
                    }
            }

            return searchContact;
        }

        public void Remove(int id)
        {
            Contact[] agendaResult = new Contact[4];

            int countSearch = 0;

            SortContacts(agenda);

            foreach (Contact c in agenda)
            {
                if (c != null)
                    if (c.Id != id)
                    {
                        c.Id = countSearch + 1;
                        agendaResult[countSearch++] = c;
                    }
            }


            agenda = agendaResult;
            count--;

        }

        private Contact[] SortContacts(Contact[] contact)
        {
            Contact auxiliary = new Contact();
            for (int i = 0; i <= count - 2; i++)
            {
                for (int j = 0; j <= count - 2 - i; j++)
                {
                    if (contact[j + 1] != null)
                        if (IsOrdened(contact[j].Name, contact[j + 1].Name) > 0)
                        {
                            auxiliary = contact[j];
                            contact[j] = contact[j + 1];
                            contact[j + 1] = auxiliary;
                        }
                }
            }

            return contact;
        }
        private int IsOrdened(string name1, string name2)
        {
            return name1.CompareTo(name2);
        }
    }
}
