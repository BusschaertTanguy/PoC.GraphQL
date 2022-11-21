using Common.Domain.Entities;
using Common.Domain.ValueObjects;

namespace Common.Domain.Repositories;

public interface IRepository<TRootEntity> where TRootEntity : RootEntity
{
    Task<TRootEntity> GetById(EntityId id);
    Task Save(TRootEntity rootEntity);
}