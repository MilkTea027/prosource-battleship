using System.Windows.Forms;
using ProSource.Robles.Battleship.Consts;
using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class ShowEnemyShipProgressStep : EnemyShipBaseStep, IShowEnemyShipProgressStep
    {
        public override void Process(EnemyShipContext context)
        {
            var instructionLabel = this.GetFormValue<Label>(context, FormControlName.LabelInstruction);
            instructionLabel.Text = $"Attack Enemy Until One Wins";

            this.Next(context);
        }
    }
}