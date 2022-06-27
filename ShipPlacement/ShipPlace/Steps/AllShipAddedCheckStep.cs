using System.Windows.Forms;
using ProSource.Robles.Battleship.Consts;
using ProSource.Robles.Battleship.Enums;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps
{
    public class AllShipAddedCheckStep : ShipPlacementBaseStep, IAllShipAddedCheckStep
    {
        public override void Process(ShipPlacementContext context)
        {
            //// CARRIER IS THE LAST AND LONGEST SHIP
            if (context.ShipType == ShipType.Carrier)
            {
                this.DisableYourShipFunctionalities(context);
                this.Next(context);
            }
            else
            {
                context.ShipType++;
                this.ShowNextShipDetails(context);
            }
        }

        private void DisableYourShipFunctionalities(ShipPlacementContext context)
        {
            var directionGroupBox = this.GetFormValue<GroupBox>(context, FormControlName.GroupBoxShipDirection);
            var yourShipGroupBox = this.GetFormValue<GroupBox>(context, FormControlName.GroupBoxYourShips);
            var enemyShipGroupBox = this.GetFormValue<GroupBox>(context, FormControlName.GroupBoxEnemyShips);

            directionGroupBox.Hide();
            yourShipGroupBox.Enabled = false;
            enemyShipGroupBox.Enabled = true;

        }

        private void ShowNextShipDetails(ShipPlacementContext context)
        {
            var instructionLabel = this.GetFormValue<Label>(context, FormControlName.LabelInstruction);
            instructionLabel.Text = $"Place Ship: {context.ShipType.ToString()} (1x{this.GetShipLength(context)})";
        }
    }
}
