using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Database;
using School.Database.Entities;

namespace School.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> FindAll();

        Task<Student> FindById(Guid guid);

        Task<int> Create(Student student);

        Task<int> Update(Student student);

        Task<int> Delete(Student student);
    }

    public class StudentService : IStudentService
    {
        private readonly DatabaseContext databaseContext;
        public StudentService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Student>> FindAll()
        {
             return await databaseContext.Students.ToListAsync();
        }

        public async Task<Student> FindById(Guid guid)
        {
            return (await databaseContext.Students.SingleOrDefaultAsync(s => s.StudentGUID == guid))!;
        }

        public async Task<int> Create(Student student)
        {
            databaseContext.Students.Add(student);

            return await databaseContext.SaveChangesAsync();
        }

        public async Task<int> Update(Student student)
        {
            databaseContext.Students.Update(student);

            return await databaseContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Student student)
        {
            databaseContext.Students.Remove(student);

            return await databaseContext.SaveChangesAsync();
        }
    }
}