using Org.Ethasia.Fundetected.Ioadapters.Animation;

namespace Org.Ethasia.Fundetected.Ioadapters.Technical
{
    public struct GameObjectProxy
    {
        public string Name
        {
            get;
            private set;
        }

        public float PosX
        {
            get;
            private set;
        }

        public float PosY
        {
            get;
            private set;
        }   

        public float ScaleX
        {
            get;
            private set;
        }   

        public float ScaleY
        {
            get;
            private set;
        }  

        public Animation2dGraphNodeProperties animation2DGraphNodeProperties
        {
            get;
            private set;
        }

        public class Builder
        {
            private string name;
            private float posX;
            private float posY; 
            private float scaleX; 
            private float scaleY;  
            private Animation2dGraphNodeProperties animationProperties;    

            public Builder SetName(string value)
            {
                name = value;
                return this;
            } 

            public Builder SetPosX(float value)
            {
                posX = value;
                return this;
            }  

            public Builder SetPosY(float value)
            {
                posY = value;
                return this;
            }   

            public Builder SetScaleX(float value)
            {
                scaleX = value;
                return this;
            }  

            public Builder SetScaleY(float value)
            {
                scaleY = value;
                return this;
            }  

            public Builder SetAnimationProperties(Animation2dGraphNodeProperties value)
            {
                animationProperties = value;
                return this;
            }

            public GameObjectProxy Build()
            {
                GameObjectProxy result = new GameObjectProxy();

                result.Name = name;
                result.PosX = posX;
                result.PosY = posY;
                result.ScaleX = scaleX;
                result.ScaleY = scaleY;
                result.animation2DGraphNodeProperties = animationProperties;

                return result;
            }                                                   
        }                              
    }
}