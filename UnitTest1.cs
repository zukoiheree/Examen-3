using NUnit.Framework;
using Exam2;

using NUnit.Framework;
using System;

namespace Exam2.Tests
{
    using NUnit.Framework;

    namespace Exam2.Tests
    {
        public class Tests
        {
            [Test]
            public void Pokemon_DefaultValues_ShouldInitializeCorrectly()
            {
                var pikachu = new Pikachu();

                Assert.That(pikachu.Name, Is.EqualTo("Pikachu"));
                Assert.That(pikachu.Level, Is.EqualTo(1));
                Assert.That(pikachu.Attack, Is.EqualTo(10));
                Assert.That(pikachu.Defense, Is.EqualTo(10));
                Assert.That(pikachu.SpAttack, Is.EqualTo(15));
                Assert.That(pikachu.SpDefense, Is.EqualTo(10));
                Assert.That(pikachu.Types[0], Is.EqualTo(PokemonType.Electric));
                Assert.That(pikachu.Moves, Is.Not.Null);
            }

            [Test]
            public void Move_ShouldInitializeCorrectly()
            {
                var thunderbolt = new Move("Thunderbolt", 100, 1, PokemonType.Electric, MoveType.Special);

                Assert.That(thunderbolt.Name, Is.EqualTo("Thunderbolt"));
                Assert.That(thunderbolt.BasePower, Is.EqualTo(100));
                Assert.That(thunderbolt.Speed, Is.EqualTo(1));
                Assert.That(thunderbolt.Type, Is.EqualTo(PokemonType.Electric));
                Assert.That(thunderbolt.MoveType, Is.EqualTo(MoveType.Special));
            }

            [Test]
            public void Modifier_ShouldBe2_WhenWaterHitsFire()
            {
                var move = new Move("Surf", 90, 1, PokemonType.Water, MoveType.Special);
                var defender = new Charmander(); // Fire type

                double mod = DamageCalculator.GetModifier(move.Type, defender.Types);

                Assert.That(mod, Is.EqualTo(2.0));
            }

            [Test]
            public void Modifier_ShouldBe4_WhenWaterHitsFireGround()
            {
                var move = new Move("Surf", 90, 1, PokemonType.Water, MoveType.Special);
                var defender = new Geodude(); // Rock + Ground ? Water is 2x vs both

                double mod = DamageCalculator.GetModifier(move.Type, defender.Types);

                Assert.That(mod, Is.EqualTo(4.0));
            }

            [Test]
            public void Modifier_ShouldBe0_WhenElectricHitsGround()
            {
                var move = new Move("Thunderbolt", 90, 1, PokemonType.Electric, MoveType.Special);
                var defender = new Geodude(); // Rock/Ground ? Electric vs Ground is 0x

                double mod = DamageCalculator.GetModifier(move.Type, defender.Types);

                Assert.That(mod, Is.EqualTo(0.0));
            }

            [TestCase(50, 128, 128, 128, 128, 128, 128, PokemonType.Normal, PokemonType.Normal, 128, MoveType.Physical, 1, ExpectedResult = 58)]
            public int Damage_ShouldMatchExpected_WhenUsingFormula(
                int level, int atk, int def, int spAtk, int spDef,
                int atk2, int def2,
                PokemonType atkType, PokemonType defType,
                int movePower, MoveType moveType,
                double[TestFixture]
    public class IntegrationTests
            {
                [Test]
                public void CompleteBattleScenario_WorksCorrectly()
                {
                    // Arrange - Charmander vs Chikorita con movimiento de agua
                    var charmander = new Charmander();
                    var chikorita = new Chikorita();

                    var waterMove = new Move("Water Gun", PokemonType.Water, MoveType.Special, 40);

                    // Act - Calcular modificador y daño
                    float modifier = DamageCalculator.GetModifier(waterMove.Type,
                        new List<PokemonType> { chikorita.Type });

                    int damage = DamageCalculator.CalculateDamage(charmander, chikorita, waterMove, modifier);

                    // Assert
                    Assert.That(modifier, Is.GreaterThan(0));
                    Assert.That(damage, Is.GreaterThanOrEqualTo(0));
                }

                [Test]
                public void PokemonSpecies_CanBeUsedInDamageCalculation()
                {
                    // Arrange
                    var charmander = new Charmander();
                    var chikorita = new Chikorita();
                    var ember = new Move("Ember", PokemonType.Fire, MoveType.Special, 40);

                    // Act
                    float modifier = DamageCalculator.GetModifier(ember.Type,
                        new List<PokemonType> { chikorita.Type });

                    int damage = DamageCalculator.CalculateDamage(charmander, chikorita, ember, modifier);

                    // Assert
                    Assert.That(damage, Is.GreaterThanOrEqualTo(0));
                }
            }
        }

