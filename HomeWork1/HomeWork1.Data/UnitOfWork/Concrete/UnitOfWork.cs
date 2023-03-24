namespace HomeWork1.Data;

public class UnitOfWork : IUnitOfWork
{

    public IGenericRepository<Staff> StaffRepository { get; private set; }
    private readonly AppDbContext context;
    private bool disposed;


    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
        StaffRepository = new GenericRepository<Staff>(context);
    }



    public void Complete()
    {
        context.SaveChanges();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

