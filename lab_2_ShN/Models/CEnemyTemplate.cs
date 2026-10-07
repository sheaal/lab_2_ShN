using System.Text.Json.Serialization;
using lab_2_ShN.Data;

namespace lab_2_ShN.Models
{
    public class CEnemyTemplate
    {
        [JsonInclude] public string Name { get; private set; }
        [JsonInclude] public EnemyIcon Icon { get; private set; }
        [JsonInclude] public int Level { get; private set; }
        [JsonInclude] public BigNumber HP { get; private set; }
        [JsonInclude] public BigNumber Damage { get; private set; }
        [JsonInclude] public BigNumber Gold { get; private set; }
        [JsonInclude] public double SpawnChance { get; private set; }
        [JsonInclude] public double HealthModifier { get; private set; }
        [JsonInclude] public double GoldModifier { get; private set; }

        [JsonConstructor]
        public CEnemyTemplate(
            string name,
            EnemyIcon icon,
            int level,
            BigNumber hp,
            BigNumber damage,
            BigNumber gold,
            double spawnChance,
            double healthModifier,
            double goldModifier)
        {
            Name = name;
            Icon = icon;
            Level = level;
            HP = hp;
            Damage = damage;
            Gold = gold;
            SpawnChance = spawnChance;
            HealthModifier = healthModifier;
            GoldModifier = goldModifier;
        }

        public override string ToString() => Name;
    }
}