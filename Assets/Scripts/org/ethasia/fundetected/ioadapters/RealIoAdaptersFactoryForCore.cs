using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealIoAdaptersFactoryForCore : IoAdaptersFactoryForCore
    {
        private RandomNumberGenerator randomNumberGenerator;
        private DamageTextPresenter damageTextPresenter;
        private HitboxPresenter hitboxPresenter;
        private EnemyAnimationPresenter enemyAnimationPresenter;

        public override IRandomNumberGenerator GetRandomNumberGeneratorInstance()
        {
            if (null == randomNumberGenerator)
            {
                randomNumberGenerator = new RandomNumberGenerator();
            }

            return randomNumberGenerator;
        }      

        public override IDamageTextPresenter GetDamageTextPresenterInstance()
        {
            if (null == damageTextPresenter)
            {
                damageTextPresenter = new DamageTextPresenter();
            }

            return damageTextPresenter;
        }  

        public override IHitboxPresenter GetHitboxPresenterInstance()
        {
            if (null == hitboxPresenter)
            {
                hitboxPresenter = new HitboxPresenter();
            }

            return hitboxPresenter;
        }

        public override IEnemyAnimationPresenter GetEnemyAnimationPresenterInstance()
        {
            if (null == enemyAnimationPresenter)
            {
                enemyAnimationPresenter = new EnemyAnimationPresenter();
            }

            return enemyAnimationPresenter;
        }
    }
}