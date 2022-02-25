using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    [Trait("Category", "Enemy")]
    public class EnemyFactoryShould
    {
        private readonly EnemyFactory _sut;
        private readonly ITestOutputHelper _output;

        public EnemyFactoryShould(ITestOutputHelper output)
        {
            _sut = new EnemyFactory();
            
            _output = output;
            _output.WriteLine("Creating new Enemy");
        }
        
        [Fact]        
        public void CreateNormalEnemyByDefault()
        {
            Enemy enemy = _sut.Create("Zombie");

            Assert.IsType<NormalEnemy>(enemy);
        }

        [Fact (Skip = "Dont need to run this.")]
        public void CreateNormalEnemyByDefault_NotTypeExample()
        {
            Enemy enemy = _sut.Create("Zombie");

            Assert.IsNotType<DateTime>(enemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            Enemy enemy = _sut.Create("Zombie King", true);

            Assert.IsType<BossEnemy>(enemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            Enemy enemy = _sut.Create("Zombie King", true);

            BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

            Assert.Equal("Zombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
           Enemy enemy = _sut.Create("Zombie King", true);

            Assert.IsAssignableFrom<Enemy>(enemy);
        }

        [Fact]
        public void CreateSepareteInstances()
        {
            Enemy enemy1 = _sut.Create("Zombie");
            Enemy enemy2 = _sut.Create("Zombie");

            Assert.NotSame(enemy1, enemy2);
            // Assert.Same(enemy1, enemy2);
        }

        [Fact]

        public void NotAllowNullName()
        {
            // Assert.Throws<ArgumentNullException>(() => _sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => _sut.Create(null));
        }

        [Fact]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => _sut.Create("Zombie", true));

            Assert.Equal("Zombie", ex.RequestedEnemyName);
        }
    }
}
