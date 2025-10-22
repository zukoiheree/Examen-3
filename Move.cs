using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    [TestFixture]
    public class MoveCreationTests
    {
        [Test]
        public void MoveCreation_Values_AreRespected()
        {
            // Arrange & Act
            var flamethrower = new Move("Flamethrower", PokemonType.Fire, MoveType.Special, 90);

            // Assert
            Assert.That(flamethrower.Name, Is.EqualTo("Flamethrower"));
            Assert.That(flamethrower.BasePower, Is.EqualTo(90));
            Assert.That(flamethrower.Type, Is.EqualTo(PokemonType.Fire));
            Assert.That(flamethrower.MoveType, Is.EqualTo(MoveType.Special));
        }

        [Test]
        public void MoveCreation_PowerClamping_Works()
        {
            // Test para validar que el poder se ajusta entre 1-255
            var weakMove = new Move("Weak", PokemonType.Normal, MoveType.Physical, 0);
            var strongMove = new Move("Strong", PokemonType.Normal, MoveType.Physical, 300);

            Assert.That(weakMove.BasePower, Is.EqualTo(1));
            Assert.That(strongMove.BasePower, Is.EqualTo(255));
        }

        [Test]
        public void MoveCreation_DefaultPower_Is100()
        {
            // Arrange & Act
            var move = new Move("Test", PokemonType.Normal, MoveType.Physical);

            // Assert
            Assert.That(move.BasePower, Is.EqualTo(100));
        }
    }
}
