using System;
using System.Collections.Generic;
using System.Linq;
using XamarinFirebase.Models;
using System.Threading.Tasks;

namespace XamarinFirebase.Services
{
    public class Helper
    {
        Firebase fb = new Firebase();

        public async Task<List<Person>> GetAllPersons()
        {
            var ps = new List<Person>();
            var test = await fb.GetData();

            return test;
        }

        public async Task AddPerson(int personId, string name)
        {
            await fb.AddData(new Dictionary<string, object>
            {
                {"ID", personId },
                { "Name",name }
            });
        }

        public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await fb.GetData();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }

        public async Task UpdatePerson(int personId, string name)
        {
            await fb.UpdateData(new Dictionary<string, object>
            {
                {"ID", personId },
                { "Name",name }
            });
        }

        public async Task DeletePerson(int personId)
        {
            await fb.DeleteData(new Dictionary<string, object>
            {
                {"ID", personId }
            });
        }
    }
}
