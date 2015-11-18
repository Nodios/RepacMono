namespace Lost.Repository.Common
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Factory pattern. Interface for creating UoW
        /// https://github.com/ninject/Ninject.Extensions.Factory/wiki/Factory-interface
        /// </summary>
        IUnitOfWork CreateUnitOfWork();
    }
}
