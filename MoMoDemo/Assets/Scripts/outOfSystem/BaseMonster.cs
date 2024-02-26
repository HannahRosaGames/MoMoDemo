

namespace Momo.OutOfSystem
{/*
    public static class BaseMonster
    {
        public static readonly Dictionary<BaseMonsterType, SingleBaseMonster> specificBaseMonster;

        static BaseMonster()
        {
            specificBaseMonster = CreateBaseMonster();
        }
        #region Create
        private static Dictionary<BaseMonsterType, SingleBaseMonster> CreateBaseMonster()
        {
            Dictionary<BaseMonsterType, SingleBaseMonster> baseMonster = new Dictionary<BaseMonsterType, SingleBaseMonster>();

            foreach (int i in Enum.GetValues(typeof(BaseMonsterType)))
                baseMonster.Add((BaseMonsterType)i, new SingleBaseMonster((BaseMonsterType)i));

            return baseMonster;
        }
        #endregion
    }

    public class SingleBaseMonster
    {
        public readonly Dictionary<AttributeScriptableObject, GrownMonsterType> evolutionBasedOnAttribute;

        public SingleBaseMonster(BaseMonsterType baseMonster)
        {
            evolutionBasedOnAttribute = CreateEvolution(baseMonster);
        }
        #region Create
        private Dictionary<AttributeScriptableObject, GrownMonsterType> CreateEvolution(BaseMonsterType baseMonster)
        {
            Dictionary<AttributeScriptableObject, GrownMonsterType> evolution = new Dictionary<AttributeScriptableObject, GrownMonsterType>();

            switch (baseMonster)
            {
                case BaseMonsterType.Goat:
                    evolution = CreateEvolutionGoat();
                    break;
                case BaseMonsterType.Duck:
                    evolution = CreateEvolutionDuck();
                    break;
                case BaseMonsterType.Bear:
                    evolution = CreateEvolutionBear();
                    break;
            }

            return evolution;
        }
        private Dictionary<AttributeScriptableObject, GrownMonsterType> CreateEvolutionGoat()
        {
            Dictionary<AttributeScriptableObject, GrownMonsterType> evolution = new Dictionary<AttributeScriptableObject, GrownMonsterType>();

            evolution.Add(AttributeType.None, GrownMonsterType.NormGoat);
            evolution.Add(AttributeType.Primordial, GrownMonsterType.PrimGoat);
            evolution.Add(AttributeType.Neon, GrownMonsterType.NeonGoat);
            evolution.Add(AttributeType.Camouflage, GrownMonsterType.CamoGoat);
            evolution.Add(AttributeType.Winged, GrownMonsterType.WingGoat);
            evolution.Add(AttributeType.Lowpoly, GrownMonsterType.PolyGoat);
            evolution.Add(AttributeType.Flower, GrownMonsterType.FlowGoat);
            evolution.Add(AttributeType.Ghost, GrownMonsterType.GhostGoat);
            evolution.Add(AttributeType.Alloyed, GrownMonsterType.AlloGoat);
            evolution.Add(AttributeType.Emo, GrownMonsterType.EmoGoat);

            return evolution;
        }
        private Dictionary<AttributeType, GrownMonsterType> CreateEvolutionDuck()
        {
            Dictionary<AttributeType, GrownMonsterType> evolution = new Dictionary<AttributeType, GrownMonsterType>();

            evolution.Add(AttributeType.None, GrownMonsterType.NormDuck);
            evolution.Add(AttributeType.Primordial, GrownMonsterType.PrimDuck);
            evolution.Add(AttributeType.Neon, GrownMonsterType.NeonDuck);
            evolution.Add(AttributeType.Camouflage, GrownMonsterType.CamoDuck);
            evolution.Add(AttributeType.Winged, GrownMonsterType.WingDuck);
            evolution.Add(AttributeType.Lowpoly, GrownMonsterType.PolyDuck);
            evolution.Add(AttributeType.Flower, GrownMonsterType.FlowDuck);
            evolution.Add(AttributeType.Ghost, GrownMonsterType.GhostGoat);
            evolution.Add(AttributeType.Alloyed, GrownMonsterType.AlloDuck);
            evolution.Add(AttributeType.Emo, GrownMonsterType.EmoDuck);

            return evolution;
        }
        private Dictionary<AttributeType, GrownMonsterType> CreateEvolutionBear()
        {
            Dictionary<AttributeType, GrownMonsterType> evolution = new Dictionary<AttributeType, GrownMonsterType>();

            evolution.Add(AttributeType.None, GrownMonsterType.NormBear);
            evolution.Add(AttributeType.Primordial, GrownMonsterType.PrimBear);
            evolution.Add(AttributeType.Neon, GrownMonsterType.NeonBear);
            evolution.Add(AttributeType.Camouflage, GrownMonsterType.CamoBear);
            evolution.Add(AttributeType.Winged, GrownMonsterType.WingBear);
            evolution.Add(AttributeType.Lowpoly, GrownMonsterType.PolyBear);
            evolution.Add(AttributeType.Flower, GrownMonsterType.FlowBear);
            evolution.Add(AttributeType.Ghost, GrownMonsterType.GhostBear);
            evolution.Add(AttributeType.Alloyed, GrownMonsterType.AlloBear);
            evolution.Add(AttributeType.Emo, GrownMonsterType.EmoBear);

            return evolution;
        }
        #endregion
    }*/
}
