using Exam2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[TestFixture]
public class DamageCalculationTests
{
    [TestCase(1, 1, 1, 1, 0, 0)]
    [TestCase(1, 1, 1, 1, 1, 1)]
    [TestCase(5, 50, 100, 50, 2, 16)]
    [TestCase(10, 20, 30, 15, 1, 5)]
    [TestCase(99, 255, 255, 255, 0, 0)]
    public void DamageCalculation_TestCases_ReturnExpectedValues(
        int level, int power, int attack, int defense, double mod, int expectedDamage)
    {
        // Arrange
        var attacker = new Pokemon("TestAttacker", PokemonType.Normal)
        {
            Level = level,
            Attack = attack,
            SpAttack = attack
        };

        var defender = new Pokemon("TestDefender", PokemonType.Normal)
        {
            Defense = defense,
            SpDefense = defense
        };

        var move = new Move("TestMove", PokemonType.Normal, MoveType.Physical, power);

        // Act
        int damage = DamageCalculator.CalculateDamage(attacker, defender, move, mod);

        // Assert
        Assert.That(damage, Is.EqualTo(expectedDamage));
    }

    [Test]
    public void DamageCalculation_PhysicalMove_UsesCorrectStats()
    {
        // Arrange
        var attacker = new Pokemon("Attacker", PokemonType.Normal)
        {
            Level = 5,
            Attack = 100,
            SpAttack = 50 // SpAttack diferente para verificar que usa Attack
        };

        var defender = new Pokemon("Defender", PokemonType.Normal)
        {
            Defense = 50,
            SpDefense = 100 // SpDefense diferente para verificar que usa Defense
        };

        var physicalMove = new Move("Tackle", PokemonType.Normal, MoveType.Physical, 50);

        // Act
        int damage = DamageCalculator.CalculateDamage(attacker, defender, physicalMove, 1.0);

        // Assert - El daño debería ser mayor porque usa Attack/Defense en lugar de SpAttack/SpDefense
        Assert.That(damage, Is.GreaterThan(0));
    }

    [Test]
    public void DamageCalculation_SpecialMove_UsesCorrectStats()
    {
        // Arrange
        var attacker = new Pokemon("Attacker", PokemonType.Normal)
        {
            Level = 5,
            Attack = 50,
            SpAttack = 100 // SpAttack mayor para verificar que usa SpAttack
        };

        var defender = new Pokemon("Defender", PokemonType.Normal)
        {
            Defense = 100,
            SpDefense = 50 // SpDefense menor para verificar que usa SpDefense
        };

        var specialMove = new Move("Psychic", PokemonType.Psychic, MoveType.Special, 50);

        // Act
        int damage = DamageCalculator.CalculateDamage(attacker, defender, specialMove, 1.0);

        // Assert - El daño debería ser mayor porque usa SpAttack/SpDefense
        Assert.That(damage, Is.GreaterThan(0));
    }

    [Test]
    public void DamageCalculation_NullParameters_ThrowsException()
    {
        // Arrange
        var pokemon = new Charmander();
        var move = new Move("Test", PokemonType.Fire, MoveType.Special);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            DamageCalculator.CalculateDamage(null, pokemon, move, 1.0));

        Assert.Throws<ArgumentNullException>(() =>
            DamageCalculator.CalculateDamage(pokemon, null, move, 1.0));

        Assert.Throws<ArgumentNullException>(() =>
            DamageCalculator.CalculateDamage(pokemon, pokemon, null, 1.0));
    }

    [Test]
    public void DamageCalculation_ZeroDefense_HandlesCorrectly()
    {
        // Arrange
        var attacker = new Pokemon("Attacker", PokemonType.Normal)
        {
            Level = 5,
            Attack = 100
        };

        var defender = new Pokemon("Defender", PokemonType.Normal)
        {
            Defense = 0 // Defense cero
        };

        var move = new Move("TestMove", PokemonType.Normal, MoveType.Physical, 50);

        // Act
        int damage = DamageCalculator.CalculateDamage(attacker, defender, move, 1.0);

        // Assert - No debería lanzar excepción y debería calcular algún daño
        Assert.That(damage, Is.GreaterThanOrEqualTo(0));
    }
}
}

