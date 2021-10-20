using Monopoly.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monopoly.Game.Handlers
{
    public class Jailer
    {
        public List<Player> inmates;
        public Jailer(List<Player> inmates) {
            this.inmates = inmates;
        }

        public bool AddInmate(Player player) {
            if (!inmates.Contains(player))
            {
                inmates.Add(player);
                return true;
            }
            else {
                return false;
            }
        }

        public bool RemoveInmate(Player player) {
            if (inmates.Contains(player))
            {
                inmates.Remove(player);
                return true;
            }
            else {
                return false;
            }
        }
    }
}
