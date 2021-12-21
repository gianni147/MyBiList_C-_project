using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyBiList.Model;
using Newtonsoft.Json;

namespace MyBiList.Service
{
    internal class MysqlDataStore : IDataStore
    {
        string ipAdresEmulator = "http://10.0.2.2:8000/api/biList/";
        string ipAdresGSM = "http://192.168.0.250:8000/api/biList/";
        
        //public static List<BiList> globalbilist = new List<BiList>();
        HttpClient client = new HttpClient();

        public async Task<List<BiList>> GetAllBiList()
        {

            string response = await client.GetStringAsync(ipAdresEmulator);
            //10.0.2.2

            return JsonConvert.DeserializeObject<List<BiList>>(response);


            //return globalbilist;
        }

        public async Task<bool> AddBiList(BiList bilist)
        {
            //globalbilist.Add(todo);

            var stringContent = new StringContent(JsonConvert.SerializeObject(bilist), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(ipAdresEmulator, stringContent);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteBiList(BiList bilist)
        {

            HttpResponseMessage response = await client.DeleteAsync(ipAdresEmulator + bilist.ID);

            //10.0.2.2
            return response.IsSuccessStatusCode;


            //globalbilist.Remove(todo);
        }

        public async Task<bool> UpdateBiList(BiList bilist)
        {

            var stringContent = new StringContent(JsonConvert.SerializeObject(bilist), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync(ipAdresEmulator + bilist.ID, stringContent);
            Console.WriteLine("Update transaction:" + response);
            return response.IsSuccessStatusCode;

        }
    }
}

