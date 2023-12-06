namespace Restaurant.SharedKernel.Core;

public interface IUnitOfWork
{
    Task Commit(CancellationToken cancellationToken);
}
