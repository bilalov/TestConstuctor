using AutoMapper;
using System.IO;
using System.Web;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.ViewModels;
using TestGenerator.Core.ViewModels.Test;
using TestGenerator.Core.ViewModels.Test.Passing;
using TestGenerator.Helpers;

namespace TestGenerator.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            AutoMapper.Mapper.CreateMap<Test, TestFormViewModel>();
            AutoMapper.Mapper.CreateMap<Test, TestPassingViewModel>();
            AutoMapper.Mapper.CreateMap<Question, QuestionFormViewModel>();
            AutoMapper.Mapper.CreateMap<Question, QuestionPassingViewModel>();
            AutoMapper.Mapper.CreateMap<Answer, AnswerFormViewModel>();

            AutoMapper.Mapper.CreateMap<TestFormViewModel, Test>();
            AutoMapper.Mapper.CreateMap<QuestionFormViewModel, Question>();
               
            AutoMapper.Mapper.CreateMap<AnswerFormViewModel, Answer>();

            AutoMapper.Mapper.CreateMap<HttpPostedFileWrapper, byte[]>()
           .ConstructUsing(fb =>
           {
               MemoryStream target = new MemoryStream();
               fb.InputStream.CopyTo(target);
               return target.ToArray();
           });

            AutoMapper.Mapper.CreateMap<byte[], MemoryPostedFile>()
                .ConstructUsing(db => new MemoryPostedFile(db));

            AutoMapper.Mapper.CreateMap<TestResult, TestResultViewModel>()
                .ForMember(x=>x.UserName, y=>y.MapFrom(t=>t.User.NickName));
        }
    }
}