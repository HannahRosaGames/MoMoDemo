

namespace Momo.OutOfSystem
{/*
    public static class People
    {
        public static readonly Dictionary<PeopleType, SinglePeople> specificPeople;

        static People()
        {
            specificPeople = CreatePeople();
        }
        #region Create
        private static Dictionary<PeopleType, SinglePeople> CreatePeople()
        {
            Dictionary<PeopleType, SinglePeople> people = new Dictionary<PeopleType, SinglePeople>();

            foreach (int i in Enum.GetValues(typeof(PeopleType)))
                people.Add((PeopleType)i, new SinglePeople((PeopleType)i));

            return people;
        }
        #endregion
    }

    public class SinglePeople
    {
        public readonly string name;
        public readonly string description;
        public readonly string hint;
        public readonly Color color;
        //places
        public readonly Perk perk;
        public readonly string boni;
        public readonly FruitTrade[] fruitTrade;
        public readonly EggTrade eggTrade;

        public SinglePeople(PeopleType people)
        {
            switch (people)
            {
                case PeopleType.TradeEggLow:
                    name = "Hilbert";
                    description = "A little man.";
                    hint = "no clue";
                    color = Color.yellow;
                    perk = Perk.EggTrade;
                    eggTrade = new EggTrade(BaseMonsterType.Duck, 3, BaseMonsterType.Goat, 1);
                    break;
                case PeopleType.TradeEggHigh:
                    name = "Susi";
                    description = "That's Susi. Obvious.";
                    hint = "no clue";
                    color = Color.white;
                    perk = Perk.EggTrade;
                    eggTrade = new EggTrade(BaseMonsterType.Goat, 5, BaseMonsterType.Bear, 1);
                    break;
                case PeopleType.TradeFruitsLow:
                    name = "HanHan";
                    description = "A little woman.";
                    hint = "no clue";
                    color = Color.magenta;
                    perk = Perk.FruitTrade;
                    fruitTrade = new[] { new FruitTrade(FruitType.Pear, 10, FruitType.Watermelon, 2), new FruitTrade(FruitType.Banana, 10, FruitType.Lemon, 2), new FruitTrade(FruitType.Strawberry, 10, FruitType.Orange, 2) };
                    break;
                case PeopleType.TradeFruitsHigh:
                    name = "Don";
                    description = "That's Susi. Obvious.";
                    hint = "no clue";
                    color = Color.blue;
                    perk = Perk.FruitTrade;
                    fruitTrade = new[] { new FruitTrade(FruitType.Watermelon, 10, FruitType.Apple, 1), new FruitTrade(FruitType.Lemon, 10, FruitType.Avocado, 1), new FruitTrade(FruitType.Orange, 10, FruitType.Cherry, 1) };
                    break;
                case PeopleType.BonusMoreLoot:
                    name = "Little Goblin";
                    description = "Also a little man.";
                    hint = "no clue";
                    color = Color.green;
                    perk = Perk.Boni;
                    boni = "You have a higher Chance, that spots will hold loot at all.";
                    break;
                case PeopleType.BonusBetterLoot:
                    name = "YouDon'tSeeMe";
                    description = "The 'Don't' is just filler.";
                    hint = "no clue";
                    color = Color.black;
                    perk = Perk.Boni;
                    boni = "You have a higher Chance, that spots will hold better loot.";
                    break;
            }
        }

        public enum Perk
        {
            FruitTrade,
            EggTrade,
            Boni
        }
        public class FruitTrade
        {
            public readonly FruitType fruitToGive;
            public readonly int amountToGive;
            public readonly FruitType fruitToGain;
            public readonly int amountToGain;

            public FruitTrade(FruitType fruitToGive, int amountToGive, FruitType fruitToGain, int amountToGain)
            {
                this.fruitToGive = fruitToGive;
                this.amountToGive = amountToGive;
                this.fruitToGain = fruitToGain;
                this.amountToGain = amountToGain;
            }
        }
        public class EggTrade
        {
            public readonly BaseMonsterType eggToGive;
            public readonly int amountToGive;
            public readonly BaseMonsterType eggToGain;
            public readonly int amountToGain;

            public EggTrade(BaseMonsterType eggToGive, int amountToGive, BaseMonsterType eggToGain, int amountToGain)
            {
                this.eggToGive = eggToGive;
                this.amountToGive = amountToGive;
                this.eggToGain = eggToGain;
                this.amountToGain = amountToGain;
            }
        }
    }*/
}