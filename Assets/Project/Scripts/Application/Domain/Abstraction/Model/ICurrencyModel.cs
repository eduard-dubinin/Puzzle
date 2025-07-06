using Cysharp.Threading.Tasks;

namespace Project.Application.Domain.Abstraction
{
    public interface ICurrencyModel
    {
        IAsyncReactiveProperty<int> Gold { get; }
        
        void Increment(int increment);
        void Decrease(int increment);
    }
}