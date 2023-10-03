using Models;
using System.Data;
using Dapper;

namespace RESTful_API.DAL.AddressDA
{
    public class AddressDB : IAddress
    {
        private readonly IDbConnection _connection;

        public AddressDB()
        {
            _connection = DBConnection.Instance().GetConnection();
        }

        public Address Create(Address obj)
        {
            string insertQuery = @"
                        INSERT INTO Address (Street, City, State, Zip, Country)
                        VALUES (@Street, @City, @State, @Zip, @Country);
                        SELECT CAST(SCOPE_IDENTITY() as bigint);";

            try
            {
                long generatedId = _connection.QuerySingle<long>(insertQuery, obj);
                obj.Id = generatedId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return obj;
        }

        public bool Delete(Address obj)
        {
            throw new NotImplementedException();
        }

        public Address? Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Address obj)
        {
            throw new NotImplementedException();
        }
    }
}
