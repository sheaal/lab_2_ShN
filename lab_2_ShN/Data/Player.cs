using lab_2_ShN.Data;

namespace lab_2_ShN.Models
{
    public class Player
    {
        public BigNumber Gold { get; private set; }
        public BigNumber Damage { get; private set; }
        public BigNumber UpgradeCost { get; private set; }
        public int UpgradeLevel { get; private set; }

        public Player()
        {
            Gold = new BigNumber(0);
            Damage = new BigNumber(1);
            UpgradeCost = new BigNumber(100);
            UpgradeLevel = 1;
        }

        public void AddGold(BigNumber amount)
        {
            if (amount < BigNumber.Zero) return;
            Gold = Gold + amount;
        }

        public bool TryUpgrade()
        {
            if (Gold < UpgradeCost) return false;

            Gold = Gold - UpgradeCost;
            UpgradeLevel++;

            Damage = BigNumber.MultiplyPercent(Damage, 120);

            UpgradeCost = BigNumber.MultiplyPercent(UpgradeCost, 120) * UpgradeLevel;

            return true;
        }
    }
}