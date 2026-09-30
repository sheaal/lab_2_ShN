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
            string json = File.ReadAllText(path);
            var loaded = JsonSerializer.Deserialize<List<CEnemyTemplate>>(json);
            if (loaded != null) enemies.AddRange(loaded);
        }
    }
}