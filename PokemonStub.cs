using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    public class PokemonStub : Pokemon
    {
        public PokemonStub(
            string name = "Stub",
            int level = 1,
            int atk = 10,
            int def = 10,
            int spAtk = 10,
            int spDef = 10,
            PokemonType type1 = PokemonType.Normal,
            PokemonType? type2 = null
        ) : base(name, level, atk, def, spAtk, spDef, type1, type2)
        {
            Attack = atk;
            Defense = def;
            SpAttack = spAtk;
            SpDefense = spDef;
        }
    }
}
