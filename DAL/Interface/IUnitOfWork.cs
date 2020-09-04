using KASSSATestTask.Models.Entities;
using KASSSATestTask.Models.Interface;
using System;
using System.Threading.Tasks;

namespace KASSSATestTask.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Objective> Objective { get; }
        Task<int> SaveAsync();
    }
}
