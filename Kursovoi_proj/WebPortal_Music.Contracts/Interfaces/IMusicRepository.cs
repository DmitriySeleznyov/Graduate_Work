using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.Contracts.Interfaces
{
    public interface IMusicRepository
    {
        IEnumerable<Music> GetAll();

        Music GetById(int id);

        void Add(Music report);

        void Update(Music reportWithChanges);

        void Delete(int id);
    }
}
