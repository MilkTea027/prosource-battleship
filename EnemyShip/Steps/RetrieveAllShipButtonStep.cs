using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class RetrieveAllShipButtonStep : EnemyShipBaseStep, IRetrieveAllShipButtonStep
    {
        public override void Process(EnemyShipContext context)
        {
            context.PlayerButtons = this.GetButtonsByName(context, "btnA");
            context.EnemyButtons = this.GetButtonsByName(context, "btnB");

            this.Next(context);
        }

        private List<Button> GetButtonsByName(EnemyShipContext context, string name)
        {
            var buttons = new List<Button>();

            foreach (GroupBox groupBox in context.Form.Controls.OfType<GroupBox>())
            {
                foreach (Button button in groupBox.Controls.OfType<Button>())
                {
                    if (button.Name.Contains(name))
                    {
                        buttons.Add(button);
                    }
                }
            }

            return buttons;
        }
    }
}
