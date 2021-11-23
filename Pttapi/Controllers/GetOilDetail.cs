using System;
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Pttapi.Models;

namespace Pttapi.Controllers
{
    public class GetOilDetail : Controller
    {
        private ApiContext _context;

        public GetOilDetail(ApiContext context)
        {
            _context = context;
        }

        [Route("api/GetListOfPriceData")]
        [HttpGet]
        public OilPriceResult GetListOfPriceData(WebException request)
        {
            OilPriceResult resultAll = new OilPriceResult();
            try
            {
                var ThaiDate = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", new CultureInfo("th-TH"));
                string[] DatetimeSplit = ThaiDate.Split(' ');
                
                //Select OilDetailTBl into OilPriceResult
                resultAll = _context.OilDetailTBl.Select(d => new OilPriceResult()
                {
                    Code = "100",
                    Description = d.Description,
                    IsNotify = d.IsNotify,
                    IsChange = (d.ChangeDate.Equals(DatetimeSplit[0]) ? true : false), //IsChange Mean if changedate eual today IsChange = true Else IsChange = false
                    ChangeDate = d.ChangeDate,
                    ChangeTime = d.ChangeTime
                }).FirstOrDefault();

                //Select OilPriceTBl into OilPriceResult.ListOfPrice
                resultAll.ListOfPrice = _context.OilPriceTBl.Select(p => new
                {
                    p.MAT_NAME,
                    p.DIVISION_ID,
                    p.DIVISION_NAME,
                    p.MAT_NAME2,
                    p.TYPE_NAME,
                    p.MAT_ID,
                    PRICE = ((resultAll.IsChange) ? p.PRICE1 : p.PRICE0)
                });

            } catch (Exception ex)
            {
                resultAll.Code = ex.Message.ToString();
            }

            return resultAll;
        }
    }
}
