using CMSG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSG.BL.Interface
{

        public interface IDepartmentRep
        {
            IQueryable<DepartmentVM> Get();
            DepartmentVM GetById(int id);
            void Add(DepartmentVM dpt);
            void Edit(DepartmentVM dpt);
            void Delete(int id);

        }
}

