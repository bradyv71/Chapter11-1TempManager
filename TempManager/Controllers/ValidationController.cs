using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TempManager.Models;

namespace Ch11Ex1TempManager.Controllers
{
    public class ValidationController : Controller
    {
        private TempManagerContext _tempManagerContext;
        public ValidationController(TempManagerContext tempManagerContext)
        {
            _tempManagerContext = tempManagerContext;
        }

        public JsonResult CheckDate(string date)
        {
            var parsedDate = System.DateTime.Parse(date);
            var tempRecords = _tempManagerContext.Temps;

            var dateExists = false;

            foreach (var temp in tempRecords)
            { 
                if(temp.Date == parsedDate)
                {
                    dateExists = true;
                }
            }

            if(!dateExists)
            {
                return Json(true);
            }

            return Json("This date is already in use.");
            
        }
    }

}
