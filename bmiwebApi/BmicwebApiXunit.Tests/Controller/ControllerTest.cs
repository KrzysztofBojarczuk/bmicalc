using AutoMapper;
using bmiwebApi;
using bmiwebApi.Controllers;
using bmiwebApi.Dtos;
using bmiwebApi.Repositories;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BmicwebApiXunit.Tests.Controller
{
    public class ControllerTest
    {
        private readonly IBodyRepository _bodyRepository;
        private readonly IMapper _mapper;

        public ControllerTest()
        {
            _bodyRepository = A.Fake<IBodyRepository>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public async Task Test_Get_All_Body_Data()
        {
            // Arrange
            var bmi = A.Fake<ICollection<BodyGetDto>>();
            var bmiList = A.Fake<List<BodyGetDto>>();

            A.CallTo(() => _mapper.Map<List<BodyGetDto>>(bmi)).Returns(bmiList);

            var controller = new BodyController(_bodyRepository, _mapper);

            // Act
            var result = await controller.GetAllBody();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
        [Fact]
        public async Task Test_Get_Body_Data_By_Id()
        {
            // Arrange

            int bmiId = 1;
            var bmiMap = A.Fake<Body>();
            var bmi = A.Fake<Body>();
            var bmiCreate = A.Fake<BodyCreateDto>();
            var bmis = A.Fake<ICollection<BodyGetDto>>();
            var bmiList = A.Fake<List<BodyGetDto>>();

            A.CallTo(() => _mapper.Map<Body>(bmiCreate)).Returns(bmi);
            A.CallTo(() => _bodyRepository.CreateBodyAsync(bmi)).Returns(bmi);

            var controller = new BodyController(_bodyRepository, _mapper);
            ///Act
            ///
            var result = controller.CrateBody(bmiCreate);

            //Assert

            result.Should().NotBeNull();

        }
    }
}
