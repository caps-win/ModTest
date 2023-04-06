using System.Threading.Tasks;

namespace ModularisTest.Interfaces
{
    public interface IDbContext
    {
        void RunQuery(string query, object parameters);
    }
}