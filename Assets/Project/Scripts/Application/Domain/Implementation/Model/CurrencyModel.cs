using Cysharp.Threading.Tasks;
using Project.Application.Domain.Abstraction;

namespace Project.Application.Domain.Implementation
{
    public class CurrencyModel : ICurrencyModel
    {
        public IAsyncReactiveProperty<int> Gold => _gold;

        private readonly AsyncReactiveProperty<int> _gold = new(0);

        public void Increment(int increment)
        {
            _gold.Value += increment;
        }

        public void Decrease(int increment)
        {
            _gold.Value -= increment;
        }
    }
}