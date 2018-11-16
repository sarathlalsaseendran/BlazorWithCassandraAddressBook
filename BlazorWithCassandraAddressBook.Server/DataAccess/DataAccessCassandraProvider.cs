using BlazorWithCassandraAddressBook.Shared.Models;
using Cassandra;
using Cassandra.Mapping;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWithCassandraAddressBook.Server.DataAccess
{
    public class DataAccessCassandraProvider : IDataAccessProvider
    {
        private readonly ILogger _logger;
        private readonly IMapper mapper;
        public DataAccessCassandraProvider(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("DataAccessCassandraProvider");
            mapper = new Mapper(CassandraInitializer.session);
        }

        public async Task AddRecord(AddressBook addressBook)
        {
            addressBook.Id = Guid.NewGuid().ToString();
            await mapper.InsertAsync(addressBook);
        }

        public async Task UpdateRecord(AddressBook addressBook)
        {
            var updateStatement = new SimpleStatement("UPDATE addressbook SET " +
                " firstname = ? " +
                ",lastname  = ? " +
                ",gender    = ? " +
                ",address   = ? " +
                ",zipcode   = ? " +
                ",country   = ? " +
                ",state     = ? " +
                ",phone     = ? " +
                " WHERE id  = ? ",
                addressBook.FirstName, addressBook.LastName, addressBook.Gender,
                addressBook.Address, addressBook.ZipCode, addressBook.Country,
                addressBook.State, addressBook.Phone, addressBook.Id);

            await CassandraInitializer.session.ExecuteAsync(updateStatement);
        }

        public async Task DeleteRecord(string id)
        {
            var deleteStatement = new SimpleStatement("DELETE FROM addressbook WHERE id = ? ", id);
            await CassandraInitializer.session.ExecuteAsync(deleteStatement);
        }

        public async Task<AddressBook> GetSingleRecord(string id)
        {
            AddressBook addressBook = await mapper.SingleOrDefaultAsync<AddressBook>("SELECT * FROM addressbook WHERE id = ?", id);
            return addressBook;
        }

        public async Task<IEnumerable<AddressBook>> GetAllRecords()
        {
            IEnumerable<AddressBook> addressBooks = await mapper.FetchAsync<AddressBook>("SELECT * FROM addressbook");
            return addressBooks;

        }
    }
}
