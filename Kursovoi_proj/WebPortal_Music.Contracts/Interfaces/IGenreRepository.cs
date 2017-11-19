using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.Contracts.Interfaces
{
    public interface IGenreRepository
    {
        IEnumerable<Genre> GetAll();

        Genre GetById(int id);

        void Add(Genre report);

        void Update(Genre reportWithChanges);

        void Delete(int id);

    }
}
