using AutoMapper;

using Octet.Calendar.Data;
using Octet.Calendar.Dto;

namespace Octet.Calendar.Service
{
    /// <summary>
    /// Contains automapper related configs.
    /// </summary>
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            ConfigureSubscriberMapping();
            ConfigureCalendarMapping();
            ConfigureCalendarBaisicInfoMapping();
        }

        static void ConfigureCalendarMapping()
        {
            Mapper.CreateMap<CalendarDto, Data.Calendar>();
            Mapper.CreateMap<Data.Calendar, CalendarDto>();
        }

        static void ConfigureSubscriberMapping()
        {
            Mapper.CreateMap<SubscriberDto, Subscriber>();
            Mapper.CreateMap<Subscriber, SubscriberDto>();
        }

        static void ConfigureCalendarBaisicInfoMapping()
        {
            Mapper.CreateMap<CalendarBasicInfoDto, Data.Calendar>();
            Mapper.CreateMap<Data.Calendar, CalendarBasicInfoDto>()
                .ForMember(d => d.SubscriberCount, a => a.MapFrom(s => s.Subscribers.Count));
        }
    }
}