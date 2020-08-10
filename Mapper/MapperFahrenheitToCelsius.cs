using AutoMapper;
using HelloMapper.CrossCutting;
using HelloMapper.Domain.Core;

namespace HelloMapper.Mapper
{
    public class MapperFahrenheitToCelsius : Profile
    {
        public MapperFahrenheitToCelsius()
        {

            CreateMap<WeatherFromAPIService, WeatherForecast>()
                .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => (src.TemperatureFahrenheit - 32) * 5 / 9))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForAllOtherMembers(opt => opt.Ignore());

        }
        
    }
}