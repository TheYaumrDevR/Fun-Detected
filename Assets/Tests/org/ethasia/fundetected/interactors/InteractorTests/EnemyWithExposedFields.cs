using System.Collections.Generic;

using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Tests
{
    public class EnemyWithExposedFields : Enemy
    {
        public List<DropTable> DropTables
        {
            get { return dropTables; }
        }

        public float DropChance
        {
            get { return dropChance; }
        }

        public int DropLevelOfItems
        {
            get { return dropLevelOfItems; }
        }

        public EnemyWithExposedFields(Enemy enemy) : base(enemy) { }
    }
}