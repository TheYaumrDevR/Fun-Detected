Shader "Sprites/PlayerGhost"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Tint", Color) = (1,1,1,1)

        [Header(Orbit Motion)]
        _OrbitRadius ("Orbit Radius (object units)", Range(0, 1)) = 0.08
        _OrbitSpeed ("Orbit Speed (rad/s)", Range(-10, 10)) = 1.5
        _OrbitSqueeze ("Vertical Squeeze (1 = circle)", Range(0, 2)) = 0.6
        _PhaseOffset ("Phase Offset (radians)", Float) = 0

        [Header(Glow)]
        [Toggle] _GlowEnabled ("Glow Enabled", Float) = 1
        [HDR] _GlowColor ("Glow Color", Color) = (0.2, 0.85, 1, 1)
        _GlowSize ("Glow Size (texels)", Range(0, 64)) = 24
        _GlowIntensity ("Glow Intensity", Range(0, 4)) = 1.6
        _GlowFalloff ("Glow Falloff", Range(0.2, 6)) = 1.8
        _PulseSpeed ("Pulse Speed", Range(0, 10)) = 2
        _PulseAmount ("Pulse Amount", Range(0, 1)) = 0.15
    }

    SubShader
    {
        Tags
        {
            "Queue" = "Transparent"
            "RenderType" = "Transparent"
            "IgnoreProjector" = "True"
            "PreviewType" = "Plane"
            "CanUseSpriteAtlas" = "True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float4 color  : COLOR;
                float2 uv     : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos   : SV_POSITION;
                fixed4 color : COLOR;
                float2 uv    : TEXCOORD0;
                float phase  : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            fixed4 _Color;

            float _OrbitRadius;
            float _OrbitSpeed;
            float _OrbitSqueeze;
            float _PhaseOffset;

            float _GlowEnabled;
            fixed4 _GlowColor;
            float _GlowSize;
            float _GlowIntensity;
            float _GlowFalloff;
            float _PulseSpeed;
            float _PulseAmount;

            #define RINGS 4
            #define DIRECTIONS 16
            #define TWO_PI 6.2831853

            v2f vert(appdata v)
            {
                v2f o;

                // Move the whole sprite along a circle / ellipse around its resting position.
                float angle = _Time.y * _OrbitSpeed + _PhaseOffset;
                float2 orbit = float2(cos(angle), sin(angle) * _OrbitSqueeze) * _OrbitRadius;
                v.vertex.xy += orbit;

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color * _Color;
                o.phase = _PhaseOffset;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 sprite = tex2D(_MainTex, i.uv) * i.color;

                if (_GlowEnabled < 0.5)
                    return sprite;

                float pulse = 1.0 + sin(_Time.y * _PulseSpeed + i.phase) * _PulseAmount;
                float size = _GlowSize * pulse;

                float sum = 0;
                float weightSum = 0;

                [unroll]
                for (int r = 1; r <= RINGS; r++)
                {
                    float t = (float)r / RINGS;
                    float2 radius = _MainTex_TexelSize.xy * size * t;
                    float w = pow(1.0 - t * 0.85, _GlowFalloff);

                    [unroll]
                    for (int d = 0; d < DIRECTIONS; d++)
                    {
                        float a = (d + (r & 1) * 0.5) * (TWO_PI / DIRECTIONS);
                        float2 offset = float2(cos(a), sin(a)) * radius;
                        sum += tex2D(_MainTex, i.uv + offset).a * w;
                        weightSum += w;
                    }
                }

                float glow = sum / weightSum;
                glow = saturate(glow * _GlowIntensity * pulse);
                glow = pow(glow, 1.0 / max(_GlowFalloff * 0.5, 0.01));

                float glowAlpha = glow * _GlowColor.a * (1.0 - sprite.a);

                float outA = sprite.a + glowAlpha;
                float3 outRGB = (sprite.rgb * sprite.a + _GlowColor.rgb * glowAlpha) / max(outA, 0.0001);

                return fixed4(outRGB, saturate(outA));
            }
            ENDCG
        }
    }

    Fallback "Sprites/Default"
}
