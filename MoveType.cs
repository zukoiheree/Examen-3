using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    [TestFixture]
    public class TypeEffectivenessTests
    {
        [Test]
        public void TypeModifier_WaterVsFire_ReturnsDoubleDamage()
        {
            // Arrange
            var waterMove = new Move("Water Gun", PokemonType.Water, MoveType.Special);
            var charmanderTypes = new List<PokemonType> { PokemonType.Fire };

            // Act
            float modifier = DamageCalculator.GetModifier(waterMove.Type, charmanderTypes);

            // Assert
            Assert.That(modifier, Is.EqualTo(2.0f));
        }

        [Test]
        public void TypeModifier_ElectricVsGround_ReturnsZeroDamage()
        {
            // Arrange
            var electricMove = new Move("Thunderbolt", PokemonType.Electric, MoveType.Special);
            var groundTypes = new List<PokemonType> { PokemonType.Ground };

            // Act
            float modifier = DamageCalculator.GetModifier(electricMove.Type, groundTypes);

            // Assert
            Assert.That(modifier, Is.EqualTo(0.0f));
        }

        [Test]
        public void TypeModifier_DualType_CalculatesCorrectly()
        {
            // Arrange - Pokémon tipo Fuego/Volador vs movimiento tipo Agua
            var waterMove = new Move("Water Gun", PokemonType.Water, MoveType.Special);
            var charizardTypes = new List<PokemonType> { PokemonType.Fire, PokemonType.Flying };

            // Act
            float modifier = DamageCalculator.GetModifier(waterMove.Type, charizardTypes);

            // Assert - Agua vs Fuego (2x) * Agua vs Volador (1x) = 2x
            Assert.That(modifier, Is.EqualTo(2.0f));
        }

        [Test]
        public void TypeModifier_NeutralDamage_ReturnsOne()
        {
            // Arrange
            var normalMove = new Move("Tackle", PokemonType.Normal, MoveType.Physical);
            var normalTypes = new List<PokemonType> { PokemonType.Normal };

            // Act
            float modifier = DamageCalculator.GetModifier(normalMove.Type, normalTypes);

            // Assert
            Assert.That(modifier, Is.EqualTo(1.0f));
        }

        [Test]
        public void TypeModifier_GrassVsWater_ReturnsDoubleDamage()
        {
            // Arrange
            var grassMove = new Move("Vine Whip", PokemonType.Grass, MoveType.Physical);
            var waterTypes = new List<PokemonType> { PokemonType.Water };

            // Act
            float modifier = DamageCalculator.GetModifier(grassMove.Type, waterTypes);

            // Assert
            Assert.That(modifier, Is.EqualTo(2.0f));
        }
    }
}
