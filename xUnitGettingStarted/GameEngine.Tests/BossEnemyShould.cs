using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {
        private readonly BossEnemy _sut;
        private readonly ITestOutputHelper _output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            _sut = new BossEnemy();

            _output = output;
            _output.WriteLine("Creating new Boss Enemy");
        }

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCorrectPower()
        {         
            Assert.Equal(166.667, _sut.TotalSpecialAttackPower, 3);
        }
    }
}
