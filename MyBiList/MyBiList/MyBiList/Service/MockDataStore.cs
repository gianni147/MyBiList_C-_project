using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyBiList.Model;

namespace MyBiList.Service
{
    internal class MockDataStore : IDataStore
    {

        public static List<BiList> globalbilist = new List<BiList>();

        public MockDataStore()
        {
            globalbilist.Add(new BiList() { Name = "Gianni", Date = "27/12/2001", Idea = "Nintendo switch"});
            globalbilist.Add(new BiList() { Name = "Tarik", Date = "17/02/2001", Idea = "Nintendo switch"});
        }

        public List<BiList> GetAllBiList()
        {
            return globalbilist;
        }

        public void AddBiList(BiList todo)
        {
            globalbilist.Add(todo);
        }

        public void DeleteBiList(BiList todo)
        {
            globalbilist.Remove(todo);
        }

        Task<List<BiList>> IDataStore.GetAllBiList()
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore.DeleteBiList(BiList bilist)
        {
            throw new NotImplementedException();
        }

        Task<bool> IDataStore.AddBiList(BiList bilist)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBiList(BiList bilist)
        {
            throw new NotImplementedException();
        }
    }
}
