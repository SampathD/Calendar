using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

using Octet.Calendar.Dto;
using Octet.Calendar.Enums;

namespace Octet.Calendar.WebUI.Controllers
{
    /// <summary>
    /// Controller to access calendar details. 
    /// </summary>
    public class CalendarController : Controller
    {
        static string serviceURL = ConfigurationManager.AppSettings["CalendarServiceUrl"];

        /// <summary>
        /// Provide all the calendar details. 
        /// </summary>
        /// <param name="pageNumber">The start index of the list.</param>
        /// <param name="pageSize">The page size of the list.</param>
        /// <returns></returns>
        public async Task<ActionResult> Index(int pageNumber = 1, int pageSize = 15)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var inputParams = String.Format("?pageNumber={0}&pageSize={1}", pageNumber, pageSize);

                    var response =
                        await
                            client.GetAsync(string.Format("{0}{1}{2}", serviceURL, "/Calendar/GetAllCalendars",
                                inputParams));

                    var calendarDetails = await response.Content.ReadAsAsync<Response<List<CalendarBasicInfoDto>>>();
                    if (calendarDetails.StatusCode == StatusCode.Success)
                    {
                        return View(calendarDetails.Data);
                    }
                    
                    //TODO: Return specific error messages.
                    return View("Error");
                }
            }
            catch (Exception)
            {
                //TODO: Log this error.
                return View("Error");
            }

        }

    }
}