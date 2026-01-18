using UnityEngine;
using UnityEngine.UIElements;

using Org.Ethasia.Fundetected.Ioadapters.Technical;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class EquipmentSlotsPanel : VisualElement
    {
        private const string MAINHAND_SLOT_NAME = "mainhand-slot";
        private const string OFFHAND_SLOT_NAME = "offhand-slot";
        private const string CHEST_SLOT_NAME = "chest-slot";
        private const string HEAD_SLOT_NAME = "head-slot";
        private const string FEET_SLOT_NAME = "feet-slot";
        private const string HANDS_SLOT_NAME = "hands-slot";
        private const string BELT_SLOT_NAME = "belt-slot";
        private const string LEFT_RING_SLOT_NAME = "left-ring-slot";
        private const string RIGHT_RING_SLOT_NAME = "right-ring-slot";
        private const string NECK_SLOT_NAME = "neck-slot";
        private const string LEFTMOST_POTION_SLOT_NAME = "leftmost-potion-slot";
        private const string LEFTMIDDLE_POTION_SLOT_NAME = "leftmiddle-potion-slot";
        private const string MIDDLE_POTION_SLOT_NAME = "middle-potion-slot";
        private const string RIGHTMIDDLE_POTION_SLOT_NAME = "rightmiddle-potion-slot";
        private const string RIGHTMOST_POTION_SLOT_NAME = "rightmost-potion-slot";

        private EquipmentSlot mainHandSlot;
        private EquipmentSlot offHandSlot;
        private EquipmentSlot headSlot;
        private EquipmentSlot chestSlot;
        private EquipmentSlot beltSlot;
        private EquipmentSlot footSlot;
        private EquipmentSlot handSlot;
        private EquipmentSlot leftRingSlot;
        private EquipmentSlot rightRingSlot;
        private EquipmentSlot neckSlot;
        private EquipmentSlot leftMostPotionSlot;
        private EquipmentSlot leftMiddlePotionSlot;
        private EquipmentSlot middlePotionSlot;
        private EquipmentSlot rightMiddlePotionSlot;
        private EquipmentSlot rightMostPotionSlot;

        public EquipmentSlotsPanel()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/EquipmentSlotsPanel");
            visualTree.CloneTree(this);

            mainHandSlot = this.Q<EquipmentSlot>(MAINHAND_SLOT_NAME);
            offHandSlot = this.Q<EquipmentSlot>(OFFHAND_SLOT_NAME);
            chestSlot = this.Q<EquipmentSlot>(CHEST_SLOT_NAME);
            headSlot = this.Q<EquipmentSlot>(HEAD_SLOT_NAME);
            footSlot = this.Q<EquipmentSlot>(FEET_SLOT_NAME);
            handSlot = this.Q<EquipmentSlot>(HANDS_SLOT_NAME);
            leftRingSlot = this.Q<EquipmentSlot>(LEFT_RING_SLOT_NAME);
            rightRingSlot = this.Q<EquipmentSlot>(RIGHT_RING_SLOT_NAME);
            neckSlot = this.Q<EquipmentSlot>(NECK_SLOT_NAME);
            leftMostPotionSlot = this.Q<EquipmentSlot>(LEFTMOST_POTION_SLOT_NAME);
            leftMiddlePotionSlot = this.Q<EquipmentSlot>(LEFTMIDDLE_POTION_SLOT_NAME);
            middlePotionSlot = this.Q<EquipmentSlot>(MIDDLE_POTION_SLOT_NAME);
            rightMiddlePotionSlot = this.Q<EquipmentSlot>(RIGHTMIDDLE_POTION_SLOT_NAME);
            rightMostPotionSlot = this.Q<EquipmentSlot>(RIGHTMOST_POTION_SLOT_NAME);
        }

        public void RenderEquippedItems(EquipmentSlotsRenderContext renderContext)
        {
            if (mainHandSlot != null)
            {
                mainHandSlot.RenderEquippedItem(renderContext.MainHand);
            }

            if (offHandSlot != null)
            {
                offHandSlot.RenderEquippedItem(renderContext.OffHand);
            }

            if (chestSlot != null)
            {
                chestSlot.RenderEquippedItem(renderContext.Chest);
            }

            if (headSlot != null)
            {
                headSlot.RenderEquippedItem(renderContext.Head);
            }

            if (footSlot != null)
            {
                footSlot.RenderEquippedItem(renderContext.Feet);
            }

            if (handSlot != null)
            {
                handSlot.RenderEquippedItem(renderContext.Hands);
            }

            if (leftRingSlot != null)
            {
                leftRingSlot.RenderEquippedItem(renderContext.LeftRing);
            }

            if (rightRingSlot != null)
            {
                rightRingSlot.RenderEquippedItem(renderContext.RightRing);
            }

            if (neckSlot != null)
            {
                neckSlot.RenderEquippedItem(renderContext.Neck);
            }

            if (leftMostPotionSlot != null)
            {
                leftMostPotionSlot.RenderEquippedItem(renderContext.LeftMostPotion);
            }

            if (leftMiddlePotionSlot != null)
            {
                leftMiddlePotionSlot.RenderEquippedItem(renderContext.LeftMiddlePotion);
            }

            if (middlePotionSlot != null)
            {
                middlePotionSlot.RenderEquippedItem(renderContext.MiddlePotion);
            }

            if (rightMiddlePotionSlot != null)
            {
                rightMiddlePotionSlot.RenderEquippedItem(renderContext.RightMiddlePotion);
            }

            if (rightMostPotionSlot != null)
            {
                rightMostPotionSlot.RenderEquippedItem(renderContext.RightMostPotion);
            }
        }
    }
}