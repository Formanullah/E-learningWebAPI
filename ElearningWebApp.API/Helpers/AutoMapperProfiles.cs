using System.Linq;
using AutoMapper;
using ElearningWebApp.API.Dtos;
using ELearningWebApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            CreateMap<SubjectForCreationDto, Subjects>();
            CreateMap<SubjectForClassCreationDto, SubjectForClass>();
            CreateMap<ChapterCreationDto, Chapters>();
            CreateMap<TopicCreationDto, Topics>();
            CreateMap<StudentForRegisterDto, Students>();
            CreateMap<AdminAddDto, Admins>();
            CreateMap<VideoForCreationDto, Videos>();
            CreateMap<SubjectForUpdateDto, Subjects>();
            CreateMap<SubjectForClassUpdateDto, SubjectForClass>();
            CreateMap<ChapterForUpdateDto, Chapters>();
            CreateMap<TopicForUpdateDto, Topics>();
            CreateMap<ClassCreationDto, Class>();
            CreateMap<Students, StudentForReturnDto>()
            .ForMember(dest =>  dest.RoleName, opt => {
                opt.MapFrom(src => src.Role.RoleName);
            });

            CreateMap<Admins, AdminForReturnDto>()
            .ForMember(dest =>  dest.RoleName, opt => {
                opt.MapFrom(src => src.Role.RoleName);
            });
            /* CreateMap<BookForCreationDto, Book>();
            CreateMap<CategoryForReturnDto, Category>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());
            CreateMap<Book, BookForReturnDto>()
            .ForMember(dest =>  dest.CategoryName, opt => {
                opt.MapFrom(src => src.Category.Categoryname);
            });
            CreateMap<OrderForCreationDto, Order>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<OrderDetails, OrderForReturnDto>()
            .ForMember(dest => dest.BookName,  opt => {
                opt.MapFrom(src => src.Book.Title);
            })
            .ForMember(dest => dest.OrderTime,  opt => {
                opt.MapFrom(src => src.Order.OrderTime);
            }); */


        }
        
    }
}