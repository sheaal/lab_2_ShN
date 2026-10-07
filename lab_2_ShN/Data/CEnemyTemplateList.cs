using lab_2_ShN.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace lab_2_ShN.Data
{
    public class CEnemyTemplateList
    {
        // Список противников
        private List<CEnemyTemplate> enemies;

        public CEnemyTemplateList()
        {
            enemies = new List<CEnemyTemplate>();
        }

        public void AddEnemy(CEnemyTemplate enemy)
        {
            if (enemy != null) enemies.Add(enemy);
        }

        public List<CEnemyTemplate> Enemies => enemies;

        public CEnemyTemplate GetEnemyByName(string name)
        {
            foreach (CEnemyTemplate enemy in enemies)
            {
                if (enemy.Name == name)
                    return enemy;
            }

            return null;
        }
        public void DeleteEnemyByName(string name)
        {
            CEnemyTemplate found = GetEnemyByName(name);

            if (found != null)
            {
                enemies.Remove(found);
            }
        }
        public void SaveToJson(string path)
        {
            string jsonString = System.Text.Json.JsonSerializer.Serialize(enemies);
            System.IO.File.WriteAllText(path, jsonString);
        }
        public void LoadFromJson(string path)
        {
            enemies.Clear();

            if (!File.Exists(path))
                return;

            string json = File.ReadAllText(path);

            var legacy = JsonSerializer.Deserialize<List<CEnemyTemplateLegacy>>(json);
            if (legacy == null) return;

            foreach (var l in legacy)
            {
                enemies.Add(new CEnemyTemplate(
                    l.Name,
                    l.Icon,
                    l.Level,
                    new BigNumber(l.HP),
                    new BigNumber(l.Damage),
                    new BigNumber(l.Gold),
                    1.0,
                    1.0,
                    1.0 
                )
                    );
            }
        }
    }
}