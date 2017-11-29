using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.Contracts.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetAll();

        User GetById(int id);

        void Add(User report);

        void Update(User reportWithChanges);

        void Delete(int id);

    }
}
