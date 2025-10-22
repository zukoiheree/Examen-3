using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Exam2
{{
    [TestFixture]
    public class PokemonCreationTests
    {
        [Test]
        public void PokemonCreation_DefaultValues_AreCorrect()
        {
            // Arrange & Act
            var charmander = new Charmander();

            // Assert
            Assert.That(charmander.Name, Is.EqualTo("Charmander"));
            Assert.That(charmander.Level, Is.EqualTo(1));
            Assert.That(charmander.Attack, Is.EqualTo(50));
            Assert.That(charmander.Defense, Is.EqualTo(53));
            Assert.That(charmander.SpAttack, Is.EqualTo(70));
            Assert.That(charmander.SpDefense, Is.EqualTo(65));
            Assert.That(charmander.Type, Is.EqualTo(PokemonType.Fire));
        }

        [Test]
        public void ChikoritaCreation_DefaultValues_AreCorrect()
        {
            // Arrange & Act
            var chikorita = new Chikorita();

            // Assert
            Assert.That(chikorita.Name, Is.EqualTo("Chikorita"));
            Assert.That(chikorita.Type, Is.EqualTo(PokemonType.Grass));
            Assert.That(chikorita.Level, Is.EqualTo(1));
        }

        [Test]
        public void Pokemon_MinimumOneMove_Validation()
        {
            // Arrange
            var pikachu = new Pikachu();
            var thunderbolt = new Move("Thunderbolt", PokemonType.Electric, MoveType.Special, 90);

            // Act
            pikachu.Moves[0] = thunderbolt;

            // Assert
            Assert.That(pikachu.Moves[0], Is.Not.Null);
            Assert.That(pikachu.Moves[0].Name, Is.EqualTo("Thunderbolt"));
        }
    }

}







