using ASPNET.Models;

namespace ASPNET.Repositories
{
    public class MockRepo : IRepo
    {
        List<BiList> bipersonlist = new List<BiList>();

        public MockRepo()
        {
            bipersonlist.Add(new BiList() { Id = 1, Name = "Gianni van schoor", Date = "27/12/2001", Idea = "Nintendo switch" });
            bipersonlist.Add(new BiList() { Id = 2, Name = "Tarik Amrani", Date = "22/10/1968", Idea = "Nintendo switch" });
            bipersonlist.Add(new BiList() { Id = 3, Name = "Allison VDB", Date = "22/10/1714", Idea = "Niks" });

        }

        public void AddBiList(BiList t)
        {
            bipersonlist.Add(t);
        }

        public void DeleteBiList(BiList t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BiList> GetAllBiList()
        {
            return bipersonlist;
        }

        public BiList GetBiListById(int id)
        {
            BiList _bilist = bipersonlist.FirstOrDefault<BiList>(t => t.Id == id);
            return _bilist;
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateBiList(BiList t)
        {
            throw new NotImplementedException();
        }
    }
}