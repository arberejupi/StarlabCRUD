using StarlabsCRUD.Model;
using StarlabsCRUD.Repositories;
using OpenQA.Selenium;
using AutoMapper;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace StarlabsCRUD.Services
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationException(List<string> errors) : base("Validation failed")
        {
            Errors = errors;
        }
    }
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PersonDto> _personDtoValidator;

        public PersonService(IPersonRepository personRepository, IMapper mapper, IValidator<PersonDto> personDtoValidator)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _personDtoValidator = personDtoValidator;
        }

        
        public PersonDto GetPerson(int personId)
        {
            var person = _personRepository.GetPerson(personId);
            return _mapper.Map<PersonDto>(person);
        }


        public IEnumerable<PersonDto> GetAllPersons()
        {
            var persons = _personRepository.GetAllPersons();
            return _mapper.Map<IEnumerable<PersonDto>>(persons);
        }

        public void CreatePerson(PersonDto personDto)
        {
            // Validate PersonDto using FluentValidation
            _personDtoValidator.ValidateAndThrow(personDto);

            var person = _mapper.Map<Person>(personDto);
            _personRepository.CreatePerson(person);
        }

        public void UpdatePerson(int personId, PersonDto personDto)
        {
            var existingPerson = _personRepository.GetPerson(personId);
            if (existingPerson == null)
                throw new NotFoundException("Person not found");

            // Validate PersonDto using FluentValidation
            _personDtoValidator.ValidateAndThrow(personDto);

            _mapper.Map(personDto, existingPerson);
            _personRepository.UpdatePerson(existingPerson);
        }

        public void DeletePerson(int personId)
        {
            var person = _personRepository.GetPerson(personId);
            if (person == null)
                throw new NotFoundException("Person not found");

            _personRepository.DeletePerson(person);
        }
    }

}
