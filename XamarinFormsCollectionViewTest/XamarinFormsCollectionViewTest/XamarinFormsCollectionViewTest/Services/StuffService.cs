using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsCollectionViewTest.Models;

namespace XamarinFormsCollectionViewTest.Services
{
    public class StuffService
    {
        public async Task<List<StuffModel>> GetHugeStuffAsync(int page, int pageSize = 10)
        {
            var result = new List<StuffModel>();

            for (int i = page * pageSize; i < (page + 1) * pageSize; i++)
            {
                var newStuff = GenerateStuff(i % 5 == 0 && i != 0, i.ToString());

                result.Add(newStuff);
            }

            await Task.Delay(1000);

            return result;
        }

        public async Task<StuffModel> AddSingleStuffAsync()
        {
            await Task.Delay(500);

            return GenerateRandomStuff();
        }

        private StuffModel GenerateRandomStuff()
        {
            var rand = new Random();
            var val = rand.Next(2);

            if (val == 0)
            {
                return new StuffModel()
                {
                    Title = "Good stuff",
                };
            }
            else
            {
                return new StuffModel()
                {
                    Title = "Pepe stuff",
                    ImageUrl = "https://pbs.twimg.com/profile_images/1213081022230913028/N8LMkSd7_400x400.jpg",
                };
            }
        }

        public StuffModel GenerateStuff(bool shouldBeBetter, string title)
        {
            if (shouldBeBetter)
            {
                return new StuffModel()
                {
                    Title = "Pepe stuff",
                    ImageUrl = "https://pbs.twimg.com/profile_images/1213081022230913028/N8LMkSd7_400x400.jpg",
                };
            }
            else
            {
                return new StuffModel()
                {
                    Title = title,
                };
            }
        }
    }
}
