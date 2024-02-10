using System.Security.Cryptography;

namespace Api.Services
{
    public class RandomServices: IrandomServices
    {
        private readonly int _value;

        public int Value
        {
            get => _value;
        }

        public RandomServices()
        {
            _value = new Random().Next(10000);

        }
    }
}
