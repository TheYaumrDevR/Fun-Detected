using Org.Ethasia.Fundetected.Core.Maths;

namespace Org.Ethasia.Fundetected.Interactors
{
    public interface IPlayerAnimationPresenter
    {
        void SetStateMachine(StateMachine value);
        void StartWalkAnimation();
        void StartIdleAnimation();      
        void StartRightArmSwingAnimation();
        void StartLeftArmSwingAnimation(); 
    }
}