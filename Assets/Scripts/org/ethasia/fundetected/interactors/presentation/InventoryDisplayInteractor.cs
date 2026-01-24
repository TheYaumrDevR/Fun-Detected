using Org.Ethasia.Fundetected.Core.Equipment;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Interactors.Presentation
{
    public class InventoryDisplayInteractor
    {
        public virtual void ExtractAndShowInventory()
        {
            Area currentMap = Area.ActiveArea;

            if (null != currentMap)
            {
                PlayerCharacter player = currentMap.Player;

                if (null != player)
                {
                    PlayerEquipmentItemsExtractionVisitor itemsExtractionVisitor = player.CreateItemExtractionVisitor();
                    InventoryPresentationContext inventoryPresentationContext = CreateInventoryPresentationContext(itemsExtractionVisitor);

                    IGuiWindowsPresenter guiWindowsPresenter = IoAdaptersFactoryForInteractors.GetInstance().GetGuiWindowsPresenterInstance();
                    guiWindowsPresenter.OpenInventoryWindow(inventoryPresentationContext);
                }
            }
        }

        protected InventoryPresentationContext CreateInventoryPresentationContext(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            return new InventoryPresentationContext(CreateEquipmentSlotsPresentationContext(extractor));
        }

        protected EquipmentSlotsPresentationContext CreateEquipmentSlotsPresentationContext(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            return new EquipmentSlotsPresentationContext.Builder()
                .SetMainHand(ExtractMainHandEquipment(extractor))
                .SetOffHand(ExtractOffHandEquipment(extractor))
                .SetLeftRing(ExtractLeftRingEquipment(extractor))
                .SetRightRing(ExtractRightRingEquipment(extractor))
                .SetBelt(ExtractBeltEquipment(extractor))
                .Build();
        }

        protected EquipmentSlotPresentationContext ExtractMainHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractMainHandEquipment();

            return ExtractWeapon(extractor);
        }

        protected EquipmentSlotPresentationContext ExtractOffHandEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractOffHandEquipment();

            return ExtractWeapon(extractor);
        }

        protected EquipmentSlotPresentationContext ExtractWeapon(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            Weapon extractedWeapon = extractor.ExtractedWeapon;

            if (null != extractedWeapon)
            {
                return new EquipmentSlotPresentationContext.Builder()
                    .SetItemId(extractedWeapon.Name)
                    .SetIsLegallyEquipped(true)
                    .Build();
            }

            return EquipmentSlotPresentationContext.CreateEmpty();            
        }

        protected EquipmentSlotPresentationContext ExtractLeftRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractLeftRingEquipment();

            return ExtractJewelry(extractor);
        }

        protected EquipmentSlotPresentationContext ExtractRightRingEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractRightRingEquipment();

            return ExtractJewelry(extractor);
        }

        protected EquipmentSlotPresentationContext ExtractBeltEquipment(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            extractor.Reset();
            extractor.ExtractBeltEquipment();

            return ExtractJewelry(extractor);
        }

        protected EquipmentSlotPresentationContext ExtractJewelry(PlayerEquipmentItemsExtractionVisitor extractor)
        {
            Jewelry extractedJewelry = extractor.ExtractedJewelry;

            if (null != extractedJewelry)
            {
                return new EquipmentSlotPresentationContext.Builder()
                    .SetItemId(extractedJewelry.Name)
                    .SetIsLegallyEquipped(true)
                    .Build();
            }

            return EquipmentSlotPresentationContext.CreateEmpty();
        }
    }
}