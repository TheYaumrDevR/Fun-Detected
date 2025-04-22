using System;

namespace Org.Ethasia.Fundetected.Core.Maths
{
    public class Formulas
    {
        public static int CalculatePhysicalDamageAfterReduction(int incomingDamage, int armor)
        {
            if (0 == armor)
            {
                return incomingDamage;
            }

            return (5 * (incomingDamage * incomingDamage)) / (armor + 5 * incomingDamage);
        }

        public static int CalculateNonPhysicalDamageAfterReduction(int incomingDamage, float resistanceValue)
        {
            if (0.0f == resistanceValue)
            {
                return incomingDamage;
            }

            return (int)FastMath.Round(incomingDamage * (1.0f - resistanceValue));
        }

        public static float CalculateChanceToHit(int attackerAccuracy, int defenderEvasion)
        {
            double uncappedHitChance = (1.25 * attackerAccuracy) / (attackerAccuracy + Math.Pow((defenderEvasion * 1.0) / 5.0, 0.9));

            double result = uncappedHitChance > 0.5 ? uncappedHitChance : 0.05;
            
            if (result > 1.0)
            {
                return 1.0f;
            }

            return (float)result;
        } 

        public static int GetExperiencePointsForNextLevel(int nextLevel)
        {
            switch (nextLevel)
            {
                case 2:
                    return 500;
                case 3:
                    return 1000;
                case 4:
                    return 2250;
                case 5:
                    return 4125;
                case 6:
                    return 6300;
                case 7:
                    return 8505;
                case 8:
                    return 10206;
                case 9:
                    return 11510;
                case 10:
                    return 13319;
                case 11:
                    return 14429;
                case 12:
                    return 18036;
                case 13:
                    return 22545;
                case 14:
                    return 28181;
                case 15:
                    return 35226;
                case 16:
                    return 44033;
                case 17:
                    return 55042;
                case 18:
                    return 68801;
                case 19:
                    return 86002;
                case 20:
                    return 107503;
                case 21:
                    return 134378;
                case 22:
                    return 167973;     
                case 23:
                    return 209966;
                case 24:
                    return 262457;
                case 25:
                    return 328072;
                case 26:
                    return 410090;
                case 27:
                    return 512612;
                case 28:
                    return 640765;
                case 29:
                    return 698434;
                case 30:
                    return 761293;
                case 31:
                    return 829810;
                case 32:
                    return 904492;
                case 33:
                    return 985900;    
                case 34:
                    return 1074624;
                case 35:
                    return 1171344;
                case 36:
                    return 1276765;
                case 37:
                    return 1391674;
                case 38:
                    return 1516924;
                case 39:
                    return 1653448;
                case 40:
                    return 1802257;
                case 41:
                    return 1964461;
                case 42:    
                    return 2141263;
                case 43:
                    return 2333976;
                case 44:
                    return 2544034;   
                case 45:
                    return 2772997;   
                case 46:
                    return 3022566;
                case 47:
                    return 3294598;
                case 48:
                     return 3591112;
                case 49:
                    return 3914311;
                case 50:
                    return 4266600;   
                case 51:
                    return 4650593;
                case 52:
                    return 5069147;
                case 53:
                    return 5525370;
                case 54:
                    return 6022654;
                case 55:
                    return 6564692;
                case 56:
                    return 7155515;
                case 57:
                    return 7799511;
                case 58:
                    return 8501467;       
                case 59:
                    return 9266598;
                case 60:
                    return 10100593;
                case 61:
                    return 11009646;
                case 62:
                    return 12000515;   
                case 63:
                    return 13080560;
                case 64:
                    return 14257811;
                case 65:    
                    return 15541015;
                case 66:
                    return 16939705;
                case 67:
                    return 18464279;
                case 68:
                    return 20126064;
                case 69:
                    return 21937409;
                case 70:
                    return 23911777;
                case 71:
                    return 26063836;
                case 72:
                    return 28409582;
                case 73:    
                    return 30966444;
                case 74:
                    return 33753424;
                case 75:
                    return 36791232;
                case 76:    
                    return 40102443;
                case 77:
                    return 43711663;
                case 78:
                    return 47645713;
                case 79:
                    return 51933826;
                case 80:
                    return 56607872;
                case 81:
                    return 61702579;
                case 82:
                    return 67255812;
                case 83:
                    return 73308835;
                case 84:
                    return 79906630;
                case 85:
                    return 87098226;
                case 86:
                    return 94937067;
                case 87:
                    return 103481403;
                case 88:
                    return 112794729;
                case 89:
                    return 122946255;
                case 90:
                    return 134011418;
                case 91:
                    return 146072446;
                case 92:
                    return 159218965;
                case 93:
                    return 173548673;
                case 94:
                    return 189168053;
                case 95:
                    return 206193177;
                case 96:
                    return 224750564;
                case 97:
                    return 244978115;
                case 98:
                    return 267026144;
                case 99:
                    return 291058498;
                case 100:
                    return 317149722;
                default:
                    return 0;
            }
        }       
    }
}