using ASPNET.Contexts;
using ASPNET.Models;

namespace ASPNET.Repositories
{
    public class MysqlRepo : IRepo
    {

        private readonly BiListContext _context;

        public MysqlRepo(BiListContext context)
        {
            _context = context;
        }

        public void AddBiList(BiList t)
        {
            _context.BiLists.Add(t);
        }

        public void DeleteBiList(BiList t)
        {
            _context.BiLists.Remove(t);
        }

        public IEnumerable<BiList> GetAllBiList()
        {
            return _context.BiLists;
        }

        public BiList GetBiListById(int id)
        {
            return _context.BiLists.FirstOrDefault<BiList>(t => t.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateBiList(BiList t)
        {

        }
    }
}