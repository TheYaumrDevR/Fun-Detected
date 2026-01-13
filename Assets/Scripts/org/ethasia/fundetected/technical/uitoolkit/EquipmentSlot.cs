using UnityEngine;
using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public partial class EquipmentSlot : VisualElement
    {
        private const string PATH_TO_BACKGROUND_IMAGES = "UI/Images/Inventory/";
        private const string LARGE_IMAGE_NAME = "EquipmentSlotBGWeapon.png";
        private const string BIG_IMAGE_NAME = "EquipmentSlotBGArmor.png";
        private const string MEDIUM_IMAGE_NAME = "EquipmentSlotBGTwoByTwo.png";
        private const string BELT_IMAGE_NAME = "EquipmentSlotBGBelt.png";
        private const string JEWELRY_IMAGE_NAME = "EquipmentSlotBGJewelry.png";
        private const string POTION_IMAGE_NAME = "EquipmentSlotBGPotion.png";

        private const string CONTAINER_NAME = "equipment-slot";
        private const string BACKGROUND_IMAGE_NAME = "background-image";
        private const string OVERLAY_NAME = "overlay-element";
        private const string ITEM_IMAGE_NAME = "item-image";

        private VisualElement container;
        private VisualElement backgroundImage;
        private VisualElement overlay;
        private VisualElement itemImage;

        private UiEquipmentSlotTypes slotType;

        [UxmlAttribute]
        public UiEquipmentSlotTypes SlotType
        {
            get => slotType;
            set
            {
                slotType = value;
                RenderElementBasedOnSlotType();
            }
        }

        public EquipmentSlot()
        {
            var visualTree = Resources.Load<VisualTreeAsset>("UIElements/EquipmentSlot");
            visualTree.CloneTree(this);

            container = this.Q<VisualElement>(CONTAINER_NAME);
            backgroundImage = this.Q<VisualElement>(BACKGROUND_IMAGE_NAME);
            overlay = this.Q<VisualElement>(OVERLAY_NAME);
            itemImage = this.Q<VisualElement>(ITEM_IMAGE_NAME);
        }

        private void RenderElementBasedOnSlotType()
        {
            SetElementDimensionsBasedOnSlotType();
            LoadBackGroundImageBasedOnSlotType();
        }

        private void SetElementDimensionsBasedOnSlotType()
        {
            switch (slotType)
            {
                case UiEquipmentSlotTypes.LARGE:
                    container.style.width = 72;
                    container.style.height = 140;

                    break;
                case UiEquipmentSlotTypes.BIG:
                    container.style.width = 72;
                    container.style.height = 106;

                    break;
                case UiEquipmentSlotTypes.MEDIUM:
                    container.style.width = 72;
                    container.style.height = 72;

                    break;
                case UiEquipmentSlotTypes.BELT:
                    container.style.width = 72;
                    container.style.height = 38;   

                    break;
                case UiEquipmentSlotTypes.JEWELRY:
                    container.style.width = 38;
                    container.style.height = 38;

                    break;
                case UiEquipmentSlotTypes.POTION:
                    container.style.width = 38;
                    container.style.height = 72;   

                    break;
            }
        }

        private void LoadBackGroundImageBasedOnSlotType()
        {
            string imagePath = string.Empty;

            switch (slotType)
            {
                case UiEquipmentSlotTypes.LARGE:
                    imagePath = PATH_TO_BACKGROUND_IMAGES + LARGE_IMAGE_NAME;
                    break;
                case UiEquipmentSlotTypes.BIG:
                    imagePath = PATH_TO_BACKGROUND_IMAGES + BIG_IMAGE_NAME;
                    break;
                case UiEquipmentSlotTypes.MEDIUM:
                    imagePath = PATH_TO_BACKGROUND_IMAGES + MEDIUM_IMAGE_NAME;
                    break;
                case UiEquipmentSlotTypes.BELT:
                    imagePath = PATH_TO_BACKGROUND_IMAGES + BELT_IMAGE_NAME;
                    break;
                case UiEquipmentSlotTypes.JEWELRY:
                    imagePath = PATH_TO_BACKGROUND_IMAGES + JEWELRY_IMAGE_NAME;
                    break;
                case UiEquipmentSlotTypes.POTION:
                    imagePath = PATH_TO_BACKGROUND_IMAGES + POTION_IMAGE_NAME;
                    break;
            }

            var image = Resources.Load<Texture2D>(imagePath);
            backgroundImage.style.backgroundImage = new StyleBackground(image);
        }
    }
}