using Moq;
using MyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTests
{
    public class MoqInvocation 
    {
        private readonly ITestOutputHelper output;

        public MoqInvocation(ITestOutputHelper output)
        {
            this.output = output;

        }
        [Fact]
        public void TestInvocationArguments()
        {
            output.WriteLine("TESTINVOCATIONARGUMENTS: called ...");
            var mock = new Mock<IFoo>();
            mock.Setup(x => x.DoSomethingStringy(It.IsAny<string>()))
                .Returns((string s) => s.ToLower());

            var r = mock.Object.DoSomethingStringy("HELP");
            output.WriteLine("TESTINVOCATIONARGUMENTS: r is {0}", r);
            Assert.Equal("help", r);
        }

    }
}
