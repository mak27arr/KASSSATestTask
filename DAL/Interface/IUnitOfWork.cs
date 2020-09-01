using KASSSATestTask.Models.Entities;
using KASSSATestTask.Models.Interface;
using System;

namespace KASSSATestTask.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Objective> Objective { get; }
        void Save();
    }
}
