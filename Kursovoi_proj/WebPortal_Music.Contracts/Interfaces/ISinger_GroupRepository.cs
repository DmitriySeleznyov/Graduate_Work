using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.Contracts.Interfaces
{
    public interface ISinger_GroupRepository
    {
        IEnumerable<Singer_Group> GetAll();

        Singer_Group GetById(int id);

        void Add(Singer_Group report);

        void Update(Singer_Group reportWithChanges);

        void Delete(int id);

    }
}
