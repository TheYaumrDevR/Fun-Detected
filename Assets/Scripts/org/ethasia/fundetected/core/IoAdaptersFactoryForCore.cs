using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Core
{

    public abstract class IoAdaptersFactoryForCore
    {
        private static IoAdaptersFactoryForCore instance;

        public static void SetInstance(IoAdaptersFactoryForCore value)
        {
            instance = value;
        }

        public static IoAdaptersFactoryForCore GetInstance()
        {
            return instance;
        } 

        public abstract IRandomNumberGenerator GetRandomNumberGeneratorInstance();
        public abstract IDamageTextPresenter GetDamageTextPresenterInstance();
        public abstract IDroppedItemPresenter GetDroppedItemPresenterInstance();
        public abstract IHitboxPresenter GetHitboxPresenterInstance();
        public abstract IEnemyAnimationPresenter GetEnemyAnimationPresenterInstance();
        public abstract ISoundPresenter GetSoundPresenterInstance();
    }
}
