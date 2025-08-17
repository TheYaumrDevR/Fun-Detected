using Org.Ethasia.Fundetected.Core;
using Org.Ethasia.Fundetected.Core.Combat;
using Org.Ethasia.Fundetected.Core.Map;

namespace Org.Ethasia.Fundetected.Ioadapters.Mocks
{

    public class MockedIoAdaptersFactoryForCore : IoAdaptersFactoryForCore
    {
        private IRandomNumberGenerator rngInstance;
        private IEnemyAnimationPresenter enemyAnimationPresenterInstance;

        public void SetRngInstance(IRandomNumberGenerator value)
        {
            rngInstance = value;
        }

        public override IRandomNumberGenerator GetRandomNumberGeneratorInstance()
        {
            if (null == rngInstance)
            {
                int[] randomNumbersToGenerate = {};
                float[] randomFloatsToGenerate = {};
                double[] randomDoublesToGenerate = {};

                rngInstance = new RandomNumberGeneratorMock(randomNumbersToGenerate, randomFloatsToGenerate, randomDoublesToGenerate);
            }

            return rngInstance;
        }

        public override IDamageTextPresenter GetDamageTextPresenterInstance()
        {
            return new DamagePresenterMock();
        }

        public override IHitboxPresenter GetHitboxPresenterInstance()
        {
            return new HitboxPresenterMock();
        }

        public override IEnemyAnimationPresenter GetEnemyAnimationPresenterInstance()
        {
            if (null == enemyAnimationPresenterInstance)
            {
                enemyAnimationPresenterInstance = new EnemyAnimationPresenterMock();
            }

            return enemyAnimationPresenterInstance;
        }

        public override ISoundPresenter GetSoundPresenterInstance()
        {
            return new SoundPresenterMock();
        }
    }
}