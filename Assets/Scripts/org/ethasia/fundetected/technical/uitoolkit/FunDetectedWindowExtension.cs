using System.Collections.Generic;

using UnityEngine.UIElements;

namespace Org.Ethasia.Fundetected.Technical.UIToolkit
{
    [UxmlElement]
    public abstract partial class FunDetectedWindowExtension : VisualElement
    {
        private FunDetectedWindow baseWindow;

        protected FunDetectedWindow BaseWindow
        {
            get
            {
                if (baseWindow == null)
                {
                    baseWindow = this.Q<FunDetectedWindow>(GetBaseWindowName());
                }

                return baseWindow;
            }
        }

        [UxmlAttribute]
        public bool IsOpen 
        { 
            get => this.visible && (BaseWindow?.visible ?? false);
            set 
            {
                this.visible = value;

                if (BaseWindow != null) BaseWindow.visible = value;
            }
        }   

        public FunDetectedWindowExtension()
        {
            Initialize();
            var childrenToMove = FindChildrenToMoveToContentArea();

            if (BaseWindow != null)
            {
                BaseWindow.MoveChildrenToContainer(childrenToMove);
            }
        }

        protected abstract void Initialize();
        protected abstract List<VisualElement> FindChildrenToMoveToContentArea();
        protected abstract string GetBaseWindowName();     
    }
}