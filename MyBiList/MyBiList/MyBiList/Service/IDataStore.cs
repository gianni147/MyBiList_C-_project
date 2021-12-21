using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyBiList.Model;

namespace MyBiList.Service
{
    public interface IDataStore
    {
        Task<List<BiList>> GetAllBiList();
        Task<bool> AddBiList(BiList bilist);

        Task<bool> DeleteBiList(BiList bilist);

        Task<bool> UpdateBiList(BiList bilist);

    }
}
