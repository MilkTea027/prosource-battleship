using System;
using System.Linq;
using System.Windows.Forms;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.Enums;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Interfaces;

namespace ProSource.Robles.Battleship
{
    public partial class BattleshipForm : Form
    {
        private ShipPlacementContext shipPlacementContext;

        private readonly IShipDisplayChainFactory shipDisplayChainFactory;
        private readonly IShipHideChainFactory shipHideChainFactory;
        private readonly IShipPlaceChainFactory shipPlaceChainFactory;

        public BattleshipForm(
            IShipDisplayChainFactory shipDisplayChainFactory,
            IShipHideChainFactory shipHideChainFactory,
            IShipPlaceChainFactory shipPlaceChainFactory)
        {
            this.shipDisplayChainFactory = shipDisplayChainFactory;
            this.shipHideChainFactory = shipHideChainFactory;
            this.shipPlaceChainFactory = shipPlaceChainFactory;

            this.InitializeComponent();
            this.SetupDefaultValues();
        }

        private EnemyShipContext EnemyContext
        {
            get
            {
                return this.shipPlacementContext.EnemyShipContext;
            }
        }

        private void SetupDefaultValues()
        {
            this.gbxEnemyShips.Text = "Enemy Ships (Disabled) - Set up yours first";
            this.shipPlacementContext = new ShipPlacementContext(this);
        }

        private void DisplayShipOnMouseEnter(object sender, EventArgs e)
        {
            var button = sender as Button;
            this.shipPlacementContext.ShipDisplayName = button.Name.Replace("btn", string.Empty);

            var displayChain = this.shipDisplayChainFactory.GetChain();
            displayChain.Process(this.shipPlacementContext);
        }

        private void HideDisplayedShipOnMouseLeave(object sender, EventArgs e)
        {
            var hideChan = this.shipHideChainFactory.GetChain();
            hideChan.Process(this.shipPlacementContext);
        }

        private void PlaceShipOnClick(object sender, EventArgs e)
        {
            var placeChain = this.shipPlaceChainFactory.GetChain();
            placeChain.Process(this.shipPlacementContext);
        }

        private void EnemyShipClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var enemyButton = this.EnemyContext.PlacedShipButtons.Where(eb => eb.Name == button.Name).FirstOrDefault();
            var isHit = enemyButton != null;

            button.Text = isHit ? "O" : "X";
            button.ForeColor = isHit ? this.EnemyContext.HitColor : this.EnemyContext.MissColor;

            if (isHit)
            {
                this.EnemyContext.PlacedShipButtons.Remove(enemyButton);
            }

            if (this.EnemyContext.PlacedShipButtons.Any())
            {
                this.AttackPlayer();
            }
            else
            {
                this.PlayerWins("Player");
            }
        }

        private void AttackPlayer()
        {
            var randomizer = new Random();
            var randomIndex = randomizer.Next(this.EnemyContext.PlayerButtons.Count);
            var selectedButton = this.EnemyContext.PlayerButtons[randomIndex];
            var isHit = selectedButton.BackColor != this.EnemyContext.NoShipColor;

            selectedButton.Text = isHit ? "O" : "X";
            selectedButton.ForeColor = isHit ? this.EnemyContext.HitColor : this.EnemyContext.MissColor;

            this.EnemyContext.PlayerButtons.RemoveAt(randomIndex);

            var PlayerShips = this.EnemyContext.PlayerButtons
                .Where(pb => pb.BackColor != this.EnemyContext.NoShipColor).Any();

            if (!PlayerShips)
            {
                this.PlayerWins("Enemy");
            }
        }

        private void RotateShipVerticalDirectionClicked(object sender, EventArgs e)
        {
            this.shipPlacementContext.ShipDirection = ShipDirection.Vertical;
        }

        private void RotateShipHorizontalDirectionClicked(object sender, EventArgs e)
        {
            this.shipPlacementContext.ShipDirection = ShipDirection.Horizontal;
        }

        private void PlayerWins(string name)
        {
            this.lblInstructions.Text = $"{name} Won!";
            this.gbxEnemyShips.Enabled = false;
            this.gbxYourShips.Enabled = false;
        }
    }
}
