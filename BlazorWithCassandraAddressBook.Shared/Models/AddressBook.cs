using Cassandra.Mapping.Attributes;

namespace BlazorWithCassandraAddressBook.Shared.Models
{
    [Table("addressbook")]
    public class AddressBook
    {
        [Column("id")]
        public string Id
        {
            get;
            set;
        }
        [Column("firstname")]
        public string FirstName
        {
            get;
            set;
        }
        [Column("lastname")]
        public string LastName
        {
            get;
            set;
        }
        [Column("gender")]
        public string Gender
        {
            get;
            set;
        }
        [Column("address")]
        public string Address
        {
            get;
            set;
        }
        [Column("zipcode")]
        public string ZipCode
        {
            get;
            set;
        }
        [Column("country")]
        public string Country
        {
            get;
            set;
        }
        [Column("state")]
        public string State
        {
            get;
            set;
        }
        [Column("phone")]
        public string Phone
        {
            get;
            set;
        }
    }
}
