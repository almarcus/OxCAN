using OxCAN.Shared.Models;

namespace OxCAN.Shared.Repositories;

public interface IContactRepository
{
    Contact Save(Contact contact);

    IEnumerable<Contact> Get();
}