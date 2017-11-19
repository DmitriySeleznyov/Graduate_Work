﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPortal_Music.Contracts.DataContracts;

namespace WebPortal_Music.Contracts.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAll();

        Users GetById(int id);

        void Add(Users report);

        void Update(Users reportWithChanges);

        void Delete(int id);

    }
}