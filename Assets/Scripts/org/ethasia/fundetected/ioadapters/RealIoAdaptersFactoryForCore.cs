using Org.Ethasia.Fundetected.Core;

namespace Org.Ethasia.Fundetected.Ioadapters
{
    public class RealIoAdaptersFactoryForCore : IoAdaptersFactoryForCore
    {
        private RandomNumberGenerator randomNumberGenerator;
        private DamageTextPresenter damageTextPresenter;

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
    }
}