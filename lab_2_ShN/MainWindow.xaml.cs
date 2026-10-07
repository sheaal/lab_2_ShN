using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using lab_2_ShN.Data;
using lab_2_ShN.Models;

namespace lab_2_ShN
{
    public partial class MainWindow : Window
    {
        private Player _player;
        private Enemy _currentEnemy;
        private EnemySpawner _spawner;
        private CEnemyTemplateList _templates;

        public MainWindow()
        {
            InitializeComponent();

            _player = new Player();
            _templates = new CEnemyTemplateList();
            _templates.LoadFromJson("enemies.json");

            if (_templates.Enemies.Count == 0)
            {
                MessageBox.Show("Нет шаблона противников!");
                return;
            }

            _spawner = new EnemySpawner(_templates.Enemies);
            SpawnNextEnemy();
            UpdateUI();
        }

        private void SpawnNextEnemy()
        {
            _currentEnemy = _spawner.SpawnEnemy(_player.UpgradeLevel);
        }

        private void UpdateUI()
        {
            EnemyNameText.Text = _currentEnemy.Name;
            EnemyHPText.Text = $"HP: {_currentEnemy.Health} / {_currentEnemy.MaxHealth}";
            EnemyRewardText.Text = $"Награда: {_currentEnemy.GoldReward}";

            PlayerGoldText.Text = _player.Gold.ToString();
            PlayerDamageText.Text = _player.Damage.ToString();
            UpgradeCostText.Text = _player.UpgradeCost.ToString();

            if (!string.IsNullOrEmpty(_currentEnemy.ImagePath) && File.Exists(_currentEnemy.ImagePath))
            {
                EnemyImage.Source = new BitmapImage(new Uri(_currentEnemy.ImagePath, UriKind.RelativeOrAbsolute));
            }
        }

        private void EnemyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            bool dead = _currentEnemy.TakeDamage(_player.Damage);

            if (dead)
            {
                _player.AddGold(_currentEnemy.GoldReward);
                SpawnNextEnemy();
            }

            UpdateUI();
        }

        private void UpgradeButton_Click(object sender, RoutedEventArgs e)
        {
            if (_player.TryUpgrade())
            {
                UpdateUI();
            }
        }
    }
}