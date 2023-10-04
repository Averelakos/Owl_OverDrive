using Owl.Overdrive.Domain.Entities;

namespace Owl.Overdrive.Infrastructure.Contracts
{
    public interface ITokenProviderService
    {
        public string Create(User user);
    }
}
