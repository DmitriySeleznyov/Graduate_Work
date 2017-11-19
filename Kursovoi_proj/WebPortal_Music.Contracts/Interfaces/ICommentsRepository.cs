using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.Contracts.Interfaces
{
    public interface ICommentsRepository
    {
        IEnumerable<Comments> GetAll();

        Comments GetById(int id);

        void Add(Comments report);

        void Update(Comments reportWithChanges);

        void Delete(int id);
    }
}
