using AutoMapper;

namespace CEM.Web.API.Mappings
{
    /// <summary>
    /// Generic MapFrom Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
