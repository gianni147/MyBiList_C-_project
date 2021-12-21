using ASPNET.Models;

namespace ASPNET.Repositories
{
    public interface IRepo
    {
        IEnumerable<BiList> GetAllBiList();
        BiList GetBiListById(int id);

        void AddBiList(BiList t);

        void UpdateBiList(BiList t);

        void DeleteBiList(BiList t);

        void SaveChanges();
    }
}