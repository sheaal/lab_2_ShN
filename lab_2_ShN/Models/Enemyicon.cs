namespace lab_2_ShN.Models
{
    public class EnemyIcon
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public EnemyIcon(string name, string imagePath)
        {
            Name = name;
            ImagePath = imagePath;
        }

        public override string ToString() => Name;
    }
}