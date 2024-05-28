//using NSubstitute;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using CorePlatform.Services.UseCases.CommandQueries.Rule.Create;
//using CorePlatform.Services.Infrastructure.Data;
//using CorePlatform.RuleEvaluation;
//using CorePlatform.Services.Core.Rule;
//using FluentAssertions;

//namespace CorePlatform.Services.UnitTests.UseCases.Rule
//{
//    public class CreateRuleHandlerHandle
//    {
//        private readonly string _testRuleName = "TestRuleName";
//        private readonly string _testExpression = "TestExpression";
//        private readonly AppDbContext _dbContext = Substitute.For<AppDbContext>();
//        private CreateRuleHandler _handler;

//        public CreateRuleHandlerHandle()
//        {
//            _handler = new CreateRuleHandler(_dbContext, new NoOpMediator());
//        }

//        [Fact]
//        public async Task ReturnsSuccessGivenValidName()
//        {
//            var result = await _handler.Handle(new CreateRuleCommand(_testRuleName, _testExpression), CancellationToken.None);
//            result.IsSuccess.Should().BeTrue();
//        }

//    }
//}
