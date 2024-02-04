using StarlabsCRUD.Data;
using StarlabsCRUD.Model;

namespace StarlabsCRUD.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext _context;

        public PersonRepository(DataContext context)
        {
            _context = context;
        }

        public Person GetPerson(int personId)
        {
            return _context.Person.FirstOrDefault(p => p.PersonId == personId);
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Person.ToList();
        }

        public void CreatePerson(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public void UpdatePerson(Person person)
        {
            _context.Person.Update(person);
            _context.SaveChanges();
        }

        public void DeletePerson(Person person)
        {
            _context.Person.Remove(person);
            _context.SaveChanges();
        }
    }

}
