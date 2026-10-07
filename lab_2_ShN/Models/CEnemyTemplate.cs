using System.Text.Json.Serialization;

namespace lab_2_ShN.Models
{
    public class CEnemyTemplate
    {
        [JsonInclude]
        public string Name { get; private set; }

        [JsonInclude]
        public EnemyIcon Icon { get; private set; }

        [JsonInclude]
        public int Level { get; private set; }

        [JsonInclude]
        public int HP { get; private set; }

        [JsonInclude]
        public int Damage { get; private set; }

        [JsonInclude]
        public int Gold { get; private set; }

        [JsonInclude] public double SpawnChance { get; private set; }
        [JsonInclude] public double HealthModifier { get; private set; }
        [JsonInclude] public double GoldModifier { get; private set; }

        [JsonConstructor]
        public CEnemyTemplate(string name, EnemyIcon icon,
                              int level, int hp, int damage, int gold)
        {
            Name = name;
            Icon = icon;
            Level = level;
            HP = hp;
            Damage = damage;
            Gold = gold;
        }

        public override string ToString() => Name;
    }
}