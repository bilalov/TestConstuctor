using AutoMapper;
using TestGenerator.Core.Models.Test;
using TestGenerator.Core.ViewModels;

namespace TestGenerator.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            AutoMapper.Mapper.CreateMap<Test, TestFormViewModel>();
            AutoMapper.Mapper.CreateMap<Question, QuestionFormViewModel>();
            AutoMapper.Mapper.CreateMap<Answer, AnswerFormViewModel>();

            AutoMapper.Mapper.CreateMap<TestFormViewModel, Test>();
            AutoMapper.Mapper.CreateMap<QuestionFormViewModel, Question>();
            AutoMapper.Mapper.CreateMap<AnswerFormViewModel, Answer>();
        }
    }
}