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
        IEnumerable<Comment> GetAll();

        Comment GetById(int id);

        void Add(Comment report);

        void Update(Comment reportWithChanges);

        void Delete(int id);
    }
}
