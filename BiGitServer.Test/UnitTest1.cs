using System;
using Xunit;
using BiGitServer.Data;
namespace BiGitServer.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.NotEqual(42, new Thing().Get(19, 23));
        }
    }
}
