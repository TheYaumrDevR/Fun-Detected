using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Equipment.Affixes;
using Org.Ethasia.Fundetected.Core.Items;

namespace Org.Ethasia.Fundetected.Core.Map
{
    public struct DropTableEntry
    {
        public double DropChance
        {
            get;
            private set;
        }

        public Item Item
        {
            get;
            private set;
        }

        public DropTableEntry(double dropChance, Item item)
        {
            DropChance = dropChance;
            Item = item;
        }

        public Item DropItem(int itemLevel)
        {
            Item result = Item.CloneWithItemLevel(itemLevel);
            result.RerollEntireItem();

            var rng = IoAdaptersFactoryForCore.GetInstance().GetRandomNumberGeneratorInstance();

            if (!rng.CheckProbabilityIsHit(0.2f))
            {
                return result;
            }

            return CreateAffixesBasedOnItemType(result);
        }

        private Item CreateAffixesBasedOnItemType(Item item)
        {
            var itemTypeExtractor = new ItemTypeCapturingVisitor();
            item.Accept(itemTypeExtractor);

            if (itemTypeExtractor.CapturedWeapon != null)
            {
                CreateWeaponAffixesBasedOnItemClass(itemTypeExtractor.CapturedWeapon);
            }
            else if (itemTypeExtractor.CapturedJewelry != null)
            {
                CreateJewelryAffixesBasedOnItemClass(itemTypeExtractor.CapturedJewelry);
            }

            return item;
        }

        private void CreateWeaponAffixesBasedOnItemClass(Weapon weapon)
        {
            var rollableAffixesProvider = IoAdaptersFactoryForCore.GetInstance().GetRollableAffixesPerItemGroupMasterDataProviderInstance();
            var affixRoller = new MagicAffixRoller();

            switch (weapon.ItemClass)
            {
                case ItemClass.ONE_HANDED_SWORD:
                    affixRoller.RollMagicAffixes(
                        weapon,
                        rollableAffixesProvider.CreateRollablePrefixesForOneHandedSwords(),
                        rollableAffixesProvider.CreateRollableSuffixesForOneHandedSwords());
                    break;
                default:
                    break;
            }
        }

        private void CreateJewelryAffixesBasedOnItemClass(Jewelry jewelry)
        {
            var rollableAffixesProvider = IoAdaptersFactoryForCore.GetInstance().GetRollableAffixesPerItemGroupMasterDataProviderInstance();
            var affixRoller = new MagicAffixRoller();

            switch (jewelry.ItemClass)
            {
                case ItemClass.RING:
                    affixRoller.RollMagicAffixes(
                        jewelry,
                        rollableAffixesProvider.CreateRollablePrefixesForRings(),
                        rollableAffixesProvider.CreateRollableSuffixesForRings());
                    break;
                case ItemClass.AMULET:
                    affixRoller.RollMagicAffixes(
                        jewelry,
                        rollableAffixesProvider.CreateRollablePrefixesForAmulets(),
                        rollableAffixesProvider.CreateRollableSuffixesForAmulets());
                    break;
                case ItemClass.BELT:
                    affixRoller.RollMagicAffixes(
                        jewelry,
                        rollableAffixesProvider.CreateRollablePrefixesForBelts(),
                        rollableAffixesProvider.CreateRollableSuffixesForBelts());
                    break;
                default:
                    break;
            }            
        }
    }
}