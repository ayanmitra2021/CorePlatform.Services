using CorePlatform.Services.Core.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.UnitTests.Core.RuleLibrary
{
    public class RulesLibraryConstructor
    {
        private readonly string _testName = "Rules Library Constructor Test";
        private RulesLibrary? _library;

        private RulesLibrary CreateRulesLibrary()
        {
            return new RulesLibrary(_testName);
        }

        [Fact]
        public void InitializesName()
        {
            _library = CreateRulesLibrary();
            Assert.Equal(_testName, _library.RuleName);
        }

    }
}
