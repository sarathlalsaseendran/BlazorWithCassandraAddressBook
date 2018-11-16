using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWithCassandraAddressBook.Shared.Models
{
    public interface IDataAccessProvider
    {
        Task AddRecord(AddressBook addressBook);
        Task UpdateRecord(AddressBook addressBook);
        Task DeleteRecord(string id);
        Task<AddressBook> GetSingleRecord(string id);
        Task<IEnumerable<AddressBook>> GetAllRecords();
    }
}
