namespace Lost.Repository.Common
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Factory pattern. Interface for creating UoW
        /// </summary>
        IUnitOfWork CreateUnitOfWork();
    }
}
