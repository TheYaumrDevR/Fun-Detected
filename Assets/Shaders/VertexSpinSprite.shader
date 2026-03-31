Shader "Unlit/VertexSpinSprite"
{
    Properties
    {
        _MainTex ("Sprite Texture", 2D) = "white" {}
        _Speed ("Rotation Speed", Float) = 1.0
    }

    SubShader
    {
        Tags 
        { 
            "Queue" = "Transparent" 
            "RenderType" = "Transparent"
            "CanUseSpriteAtlas" = "True"
        }

		Cull Off
		ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _Speed;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;

                // Object space position
                float3 pos = v.vertex.xyz;

                // Rotate around Z axis
                float angle = _Time.y * _Speed;
                float s = sin(angle);
                float c = cos(angle);

                float2 rotated;
                rotated.x = pos.x * c - pos.y * s;
                rotated.y = pos.x * s + pos.y * c;

                pos.xy = rotated;

                o.vertex = UnityObjectToClipPos(float4(pos, 1.0));
                o.uv = v.uv;

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return tex2D(_MainTex, i.uv);
            }
            ENDCG
        }
    }
}
