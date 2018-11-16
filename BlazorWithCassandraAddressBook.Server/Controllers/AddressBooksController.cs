using BlazorWithCassandraAddressBook.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorWithCassandraAddressBook.Server.Controllers
{
    public class AddressBooksController : Controller
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public AddressBooksController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/AddressBooks/Get")]
        public async Task<IEnumerable<AddressBook>> Get()
        {
            return await _dataAccessProvider.GetAllRecords();
        }

        [HttpPost]
        [Route("api/AddressBooks/Create")]
        public async Task Create([FromBody]AddressBook addressBook)
        {
            if (ModelState.IsValid)
            {

                await _dataAccessProvider.AddRecord(addressBook);
            }
        }

        [HttpGet]
        [Route("api/AddressBooks/Details/{id}")]
        public async Task<AddressBook> Details(string id)
        {
            return await _dataAccessProvider.GetSingleRecord(id);
        }

        [HttpPut]
        [Route("api/AddressBooks/Edit")]
        public async Task Edit([FromBody]AddressBook addressBook)
        {
            if (ModelState.IsValid)
            {
                await _dataAccessProvider.UpdateRecord(addressBook);
            }
        }

        [HttpDelete]
        [Route("api/AddressBooks/Delete/{id}")]
        public async Task Delete(string id)
        {
            await _dataAccessProvider.DeleteRecord(id);
        }
    }
}
