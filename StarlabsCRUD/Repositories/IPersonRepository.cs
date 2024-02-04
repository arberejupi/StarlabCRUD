using StarlabsCRUD.Model;

namespace StarlabsCRUD.Repositories
{
    public interface IPersonRepository
    {
        Person GetPerson(int personId);
        IEnumerable<Person> GetAllPersons();
        void CreatePerson(Person person);
        void UpdatePerson(Person person);
        void DeletePerson(Person person);
    }

}
