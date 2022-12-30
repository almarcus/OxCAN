using OxCAN.Shared.Models;

namespace OxCAN.Shared.Services;

public interface IContactService
{
    void Submit(Contact contact);

    IEnumerable<Contact> Get();
}