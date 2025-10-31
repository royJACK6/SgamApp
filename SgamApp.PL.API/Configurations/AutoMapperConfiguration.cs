namespace SgamApp.PL.API.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            //CreateMap<Author, AuthorModel>()
            //    .ForMember(dest => dest.nome di arrivo(entity),
            //    opt => opt.MapFrom(
            //    scr => scr.nome di partenza(model)));
            //    .ReverseMap();
            CreateMap<Glossary, GlossaryModel>().ReverseMap();
        }
    }
}
