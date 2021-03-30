using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Db.DbOperation
{
    public class AddressRepository
    {
        #region AllAddressList
        public List<AddressModel> AllAddressList()
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var result = context.Address.Select(x => new AddressModel()
                {
                    AddressID = x.AddressID,
                    Details = x.Details,
                    State = x.State,
                    Country = x.Country
                }).ToList();

                return result;
            }
        }
        #endregion AllAddressList

        #region AddRecord
        public int AddAddress(AddressModel addressModel)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                Address address = new Address()
                {
                    Country = addressModel.Country,
                    State = addressModel.State,
                    Details = addressModel.Details
                };

                context.Address.Add(address);

                context.SaveChanges();

                return address.AddressID;
            }
        }
        #endregion AddRecord

        #region EditRecord
        public AddressModel UpdateAddress(int id)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var result = context.Address.Where(x => x.AddressID == id).Select(x => new AddressModel()
                {
                    Details = x.Details,
                    State = x.State,
                    Country = x.Country
                }).FirstOrDefault();

                return result;
            }
        }

        public bool UpdateAddress(AddressModel addressModel)
        {
            using (var context = new EmployeeDBEntitiesCS())
            {
                var address = new Address();

                if (address != null)
                {
                    address.AddressID = addressModel.AddressID;
                    address.Details = addressModel.Details;
                    address.State = addressModel.State;
                    address.Country = addressModel.Country;
                }

                context.Entry(address).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();  

                return true;
            }
        }
        #endregion EditRecord

    }
}
