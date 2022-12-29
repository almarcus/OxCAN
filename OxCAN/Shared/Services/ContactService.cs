using OxCAN.Shared.Models;
using OxCAN.Shared.Repositories;

namespace OxCAN.Shared.Services;

public class ContactService : IContactService
{

    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public void Submit(Contact contact)
    {
        _contactRepository.Save(contact);
    }
}