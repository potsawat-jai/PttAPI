using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Pttapi.Models
{
    public class DataMockup
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            // use context to store oil data
            using (var context = new ApiContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApiContext>>()))
            {
                // Look for any board games.
                if (context.OilDetailTBl.Any())
                {
                    return;   // Data was already seeded
                }
                if (context.OilPriceTBl.Any())
                {
                    return;   // Data was already seeded
                }

                var ThaiDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH"));
                string[] DatetimeSplit = ThaiDate.Split(' ');
                context.OilDetailTBl.AddRange(
                    new OilDetail
                    {
                        detail_id = 1,
                        Description = "วันที่ 16 มกราคม 2563 เวลา 11:59 น.",
                        ChangeDate = "16/1/2563",
                        ChangeTime = "11:59"
                    });

                context.OilPriceTBl.AddRange(
                    new OilPrice
                    {
                        oil_id = 1,
                        detail_id = 1,
                        MAT_NAME = "GASOHOL 95 E-10 WITH ADD.",
                        DIVISION_ID = 10,
                        DIVISION_NAME = "Light oil",
                        MAT_NAME2 = "GSH95",
                        TYPE_NAME = 2,
                        MAT_ID = "500018",
                        PRICE0 = "25.85",
                        PRICE1 = "26.05"
                    });



                context.SaveChanges();
            }
        }
    }
}
