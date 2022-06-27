using System;
using System.Collections.Generic;
using System.Text;
using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using System.Linq;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class EnemyAttackStartStep : EnemyShipBaseStep, IEnemyAttackStartStep
    {
        public override void Process(EnemyShipContext context)
        {
            this.AttackPlayer(context);
            this.Next(context);
        }

        private void AttackPlayer(EnemyShipContext context)
        {
            var randomizer = new Random();
            var randomIndex = randomizer.Next(context.PlayerButtons.Count);
            var selectedButton = context.PlayerButtons[randomIndex];
            var isHit = selectedButton.BackColor != context.NoShipColor;

            selectedButton.Text = isHit ? "O" : "X";
            selectedButton.ForeColor = isHit ? context.MissColor : context.MissColor;

            context.PlayerButtons.RemoveAt(randomIndex);
        }
    }
}