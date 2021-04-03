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
            CreateMap<VideoForCreationDto, Videos>()
            .ForMember(dest =>dest.SubjectForClassId, opt => {
                opt.MapFrom( src => src.SubjectIdInClass);
            });
            CreateMap<SubjectForUpdateDto, Subjects>();
            CreateMap<SubjectForClassUpdateDto, SubjectForClass>();
            CreateMap<ChapterForUpdateDto, Chapters>();
            CreateMap<TopicForUpdateDto, Topics>();
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