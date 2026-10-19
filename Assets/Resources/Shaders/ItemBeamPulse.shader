Shader "Sprites/ItemBeamPulse"
{
    Properties
    {
        [PerRendererData] _MainTex ("Beam Sprite", 2D) = "white" {}
        _Color ("Tint (rarity colour)", Color) = (1,1,1,1)

        [Header(Pulsing)]
        _PulseSpeed ("Pulse Speed (cycles/sec)", Float) = 1.0
        _PulseMin ("Min Brightness", Range(0, 2)) = 0.6
        _PulseMax ("Max Brightness", Range(0, 4)) = 1.4
        _PulsePhase ("Phase Offset (0-1)", Range(0, 1)) = 0.0
        [Toggle] _PhaseFromWorldPos ("Desync by World X", Float) = 1

        [Header(Blending)]
        [Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend ("Src Blend", Float) = 5 // SrcAlpha
        [Enum(UnityEngine.Rendering.BlendMode)] _DstBlend ("Dst Blend", Float) = 1 // One (additive glow)
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
        Blend [_SrcBlend] [_DstBlend]

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _Color;
            float _PulseSpeed;
            float _PulseMin;
            float _PulseMax;
            float _PulsePhase;
            float _PhaseFromWorldPos;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv     : TEXCOORD0;
                fixed4 color  : COLOR;   // SpriteRenderer.color
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 pos   : SV_POSITION;
                float2 uv    : TEXCOORD0;
                fixed4 color : COLOR;
                float  phase : TEXCOORD1;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            v2f vert (appdata v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_OUTPUT(v2f, o);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);

                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.color = v.color * _Color;

                // Per-beam phase so several beams don't pulse in lockstep.
                float3 worldOrigin = mul(unity_ObjectToWorld, float4(0, 0, 0, 1)).xyz;
                o.phase = _PulsePhase + _PhaseFromWorldPos * frac(worldOrigin.x * 0.37);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 tex = tex2D(_MainTex, i.uv) * i.color;

                // Smooth 0..1 sine wave over time
                float wave = sin((_Time.y * _PulseSpeed + i.phase) * 6.2831853) * 0.5 + 0.5;
                float brightness = lerp(_PulseMin, _PulseMax, wave);

                // Scale colour only; alpha (shape) stays intact
                tex.rgb *= brightness;
                return tex;
            }
            ENDCG
        }
    }

    Fallback "Sprites/Default"
}
