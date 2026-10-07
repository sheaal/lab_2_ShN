using System;
using System.Collections.Generic;
using System.Linq;
using lab_2_ShN.Data;

namespace lab_2_ShN.Models
{
    public class EnemySpawner
    {
        private List<CEnemyTemplate> _templates;
        private Random _random = new Random();

        public EnemySpawner(List<CEnemyTemplate> templates)
        {
            _templates = templates;
            NormalizeChances();
        }

        private void NormalizeChances()
        {
            double total = _templates.Sum(t => t.SpawnChance);
            if (total <= 0) return;

            // Меняем шансы через рефлексию нельзя (private set),
            // поэтому храним нормализованные отдельно
            _normalized = _templates
                .Select(t => t.SpawnChance / total)
                .ToArray();
        }

        private double[] _normalized;

        public Enemy SpawnEnemy(int playerLevel)
        {
            CEnemyTemplate template = PickRandomTemplate();

            // Масштабирование: health * (1 + modifier * level)
            int healthPercent = (int)((1 + template.HealthModifier * playerLevel) * 100);
            int goldPercent = (int)((1 + template.GoldModifier * playerLevel) * 100);

            BigNumber health = BigNumber.MultiplyPercent(template.HP, healthPercent);
            BigNumber gold = BigNumber.MultiplyPercent(template.Gold, goldPercent);

            return new Enemy(template.Name, template.Icon.ImagePath, health, gold);
        }

        private CEnemyTemplate PickRandomTemplate()
        {
            double roll = _random.NextDouble();
            double cumulative = 0;

            for (int i = 0; i < _templates.Count; i++)
            {
                cumulative += _normalized[i];
                if (roll <= cumulative)
                    return _templates[i];
            }
            return _templates.Last();
        }
    }
}