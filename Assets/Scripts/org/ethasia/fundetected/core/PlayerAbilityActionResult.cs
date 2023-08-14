namespace Org.Ethasia.Fundetected.Core
{
    public struct PlayerAbilityActionResult
    {
        public string TargetName
        {
            get;
            private set;
        }

        public int TargetDamageTaken
        {
            get;
            private set;
        }

        public int TargetRemainingHealth
        {
            get;
            private set;
        } 

        public class Builder
        {
            private string targetName;
            private int targetDamageTaken;
            private int targetRemainingHealth;

            public Builder SetTargetName(string value)
            {
                targetName = value;
                return this;
            }

            public Builder SetTargetDamageTaken(int value)
            {
                targetDamageTaken = value;
                return this;
            }

            public Builder SetTargetRemainingHealth(int value)
            {
                targetRemainingHealth = value;
                return this;
            }  

            public PlayerAbilityActionResult Build()
            {
                PlayerAbilityActionResult result = new PlayerAbilityActionResult();

                result.TargetName = targetName;
                result.TargetDamageTaken = targetDamageTaken;
                result.TargetRemainingHealth = targetRemainingHealth;

                return result;
            }               
        }       
    }
}