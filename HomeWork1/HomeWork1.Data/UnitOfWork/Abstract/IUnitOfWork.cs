using System;
namespace HomeWork1.Data;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Staff> StaffRepository { get; }

    void Complete();
}

