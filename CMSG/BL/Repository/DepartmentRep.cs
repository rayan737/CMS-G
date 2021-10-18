using AutoMapper;
using CMSG.BL.Interface;
using CMSG.DAL.DataBase;
using CMSG.DAL.Entities;
using CMSG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSG.BL.Repository
{
    public class DepartmentRep: IDepartmentRep
    {
        private readonly dbContainer db;
        private readonly IMapper mapper;

        public DepartmentRep(dbContainer db , IMapper _mapper)
        {
            this.db = db;
            mapper = _mapper;
        }
        ////private dbContainer db = new dbContainer();

        public IQueryable<DepartmentVM> Get()                 //refactoring
        {
            IQueryable<DepartmentVM> data = GetAllDepts();
            return data;
        }

 

        public DepartmentVM GetById(int id)                 //refactoring
        {
            DepartmentVM data = GetDepartmentById(id);
            return data;
        }



        public void Add(DepartmentVM dpt)
        {
            // Mapping
            //Department d = new Department();
            //d.DepartmentName = dpt.DepartmentName;
            //d.DepartmentCode = dpt.DepartmentCode;

            var data = mapper.Map<Department>(dpt);
            db.Department.Add(data);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dpt)
        {
            // Mapping
            //var OldData = db.Department.Find(dpt.Id);

            //OldData.DepartmentName = dpt.DepartmentName;
            //OldData.DepartmentCode = dpt.DepartmentCode;
            var data = mapper.Map<Department>(dpt);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;   // to replace by id reference

            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var DeletedObject = db.Department.Find(id);
            db.Department.Remove(DeletedObject);
            db.SaveChanges();
        }

        // ===================================================== // refactored methods
        private DepartmentVM GetDepartmentById(int id)         
        {
            return db.Department.Where(a => a.Id == id)
                                    .Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode })
                                    .FirstOrDefault();
        }

        private IQueryable<DepartmentVM> GetAllDepts()
        {
            return db.Department.Select(a => new DepartmentVM { Id = a.Id, DepartmentName = a.DepartmentName, DepartmentCode = a.DepartmentCode });
        }
    }
}
