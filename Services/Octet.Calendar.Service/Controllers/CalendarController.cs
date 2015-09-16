using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

using AutoMapper;
using Octet.Calendar.Data;
using Octet.Calendar.Dto;
using Octet.Calendar.Service.Resources;

namespace Octet.Calendar.Service.Controllers
{
    /// <summary>
    /// Provides APIs access calendars. 
    /// </summary>
    public class CalendarController : ApiController
    {
        /// <summary>
        /// Provide all the calendar details.
        /// </summary>
        /// <param name="pageNumber">The start index of the list.</param>
        /// <param name="pageSize">The page size of the list.</param>
        /// <returns>List of calendar basic info.</returns>
        [HttpGet]
        public async Task<Response<List<CalendarBasicInfoDto>>> GetAllCalendars(int pageNumber = 1, int pageSize = 15)
        {
            if (pageNumber < 1)
            {
                return new Response<List<CalendarBasicInfoDto>>(Enums.StatusCode.InvalidPageNumber,
                    Resource.InvalidPageNumber, null);
            }

            if (pageSize < 0 || pageSize > 100)
            {
                return new Response<List<CalendarBasicInfoDto>>(Enums.StatusCode.InvalidPageSize,
                    Resource.InvalidPageSizeNumber, null);
            }

            try
            {
                var calendarDtoList = new List<CalendarBasicInfoDto>();
                using (var calendarContext = new CalendarContext())
                {
                    var calendarList =
                        await
                            calendarContext.Calendars.Where(c => c.IsActive)
                                .Include(c => c.Subscribers)
                                .OrderBy(c => c.Id)
                                .Skip(pageSize * (pageNumber - 1))
                                .Take(pageSize)
                                .ToListAsync();

                    //TODO: Get the subcriber count without loading subscribers. 

                    calendarDtoList = Mapper.Map(calendarList, calendarDtoList);
                }

                return new Response<List<CalendarBasicInfoDto>>(Enums.StatusCode.Success, Resource.SuccessMessage, calendarDtoList);
            }
            catch (Exception ex)
            {
                //TODO: Log this error.
                return new Response<List<CalendarBasicInfoDto>>(Enums.StatusCode.Error, Resource.ErrorMessage, null);
            }
        }
    }
}
