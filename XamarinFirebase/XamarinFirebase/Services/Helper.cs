using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
