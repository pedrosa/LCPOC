namespace LCPOC

{
    public class Operation : IOperationScoped, IOperationTransient, IOperationSingleton
    {
        public Guid Id { get; set; }

        public Operation()
        {
            Id = Guid.NewGuid();
        }
    }

    public interface IOperation
    {
        Guid Id { get; set; }
    }

    public interface IOperationScoped : IOperation
    {
    }

    public interface IOperationTransient : IOperation
    {
    }

    public interface IOperationSingleton : IOperation
    {
    }
}