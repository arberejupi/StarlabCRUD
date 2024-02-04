using StarlabsCRUD.Model;

namespace StarlabsCRUD.Services
{
    public interface IPersonService
    {
        PersonDto GetPerson(int personId);
        IEnumerable<PersonDto> GetAllPersons();
        void CreatePerson(PersonDto personDto);
        void UpdatePerson(int personId, PersonDto personDto);
        void DeletePerson(int personId);
    }

}
