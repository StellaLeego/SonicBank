﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Open.Core
{
    public interface IObjectsRepository<T>
    {



        Task<T> GetObject(string id);

        Task<PaginatedList<T>> GetObjectsList(string searchString = null, int? page = null, int? pageSize = null);

        Task<T> AddObject(T o);

        void UpdateObject(T o);

        void DeleteObject(T o);

        bool IsInitialized();
    }
    
}
