using AutoMapper;
using SimpleBank.Communication.Requests;

namespace SimpleBank.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestCreateUserJson, Domain.Entities.User>()
                .ForMember(domainClass => domainClass.Password, opt => opt.Ignore());
        }


        // criar domaintoresponse
    }
}
