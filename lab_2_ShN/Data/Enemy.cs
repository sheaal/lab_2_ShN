using lab_2_ShN.Data;

namespace lab_2_ShN.Models
{
    public class Enemy
    {
        public string Name { get; private set; }
        public string ImagePath { get; private set; }
        public BigNumber Health { get; private set; }
        public BigNumber MaxHealth { get; private set; }
        public BigNumber GoldReward { get; private set; }
        public bool IsDead => Health == BigNumber.Zero;

        public Enemy(string name, string imagePath, BigNumber health, BigNumber goldReward)
        {
            Name = name;
            ImagePath = imagePath;
            MaxHealth = health;
            Health = health;
            GoldReward = goldReward;
        }

        public bool TakeDamage(BigNumber damage)
        {
            if (IsDead) return true;

            if (Health <= damage)
            {
                Health = new BigNumber(0);
                return true;
            }

            Health = Health - damage;
            return false;
        }
    }
}