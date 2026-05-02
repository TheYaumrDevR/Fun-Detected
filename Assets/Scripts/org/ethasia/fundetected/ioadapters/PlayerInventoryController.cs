using System;
using System.Collections.Generic;

using Org.Ethasia.Fundetected.Interactors.Items;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class PlayerInventoryController
    {
        private Dictionary<EquipmentSlotPositionTypes, Action> slotActionBySlotPosition;

        private PlayerInventoryInteractor playerInventoryInteractor;

        public PlayerInventoryController()
        {
            playerInventoryInteractor = new PlayerInventoryInteractor();
            slotActionBySlotPosition = new Dictionary<EquipmentSlotPositionTypes, Action>
            {
                { EquipmentSlotPositionTypes.MAIN_HAND, playerInventoryInteractor.SwapCursorItemWithMainHandEquipment },
                { EquipmentSlotPositionTypes.OFF_HAND, playerInventoryInteractor.SwapCursorItemWithOffHandEquipment },
                { EquipmentSlotPositionTypes.BELT, playerInventoryInteractor.SwapCursorItemWithBeltEquipment },
                { EquipmentSlotPositionTypes.LEFT_RING, playerInventoryInteractor.SwapCursorItemWithLeftRingEquipment },
                { EquipmentSlotPositionTypes.RIGHT_RING, playerInventoryInteractor.SwapCursorItemWithRightRingEquipment }
            };
        }

        public void OnEquipmentSlotClicked(EquipmentSlotPositionTypes slotType)
        {
            if (slotActionBySlotPosition.TryGetValue(slotType, out Action action))
            {
                action.Invoke();
            }
        }
    }
}