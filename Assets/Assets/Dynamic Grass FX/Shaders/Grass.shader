Shader "Custom/URPGrass"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (0.57, 0.84, 0.32, 1)
        _BottomColor ("Bottom Color", Color) = (0.0625, 0.375, 0.07, 1)

        _WindStrength ("Wind Strength", Range(0,1)) = 0.3
        _BladeHeight ("Blade Height", Float) = 1.0
        _BladeWidth ("Blade Width", Float) = 0.1
    }

    SubShader
    {
        Tags { "RenderPipeline"="UniversalRenderPipeline" "Queue"="Geometry" }

        Pass
        {
            Name "UniversalForward"
            Tags { "LightMode"="UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
            };

            float4 _TopColor;
            float4 _BottomColor;

            float _WindStrength;
            float _BladeHeight;
            float _BladeWidth;

            float rand(float3 co)
            {
                return frac(sin(dot(co, float3(12.9898,78.233,45.543))) * 43758.5453);
            }

            Varyings vert (Attributes v)
            {
                Varyings o;

                float3 pos = v.positionOS.xyz;

                // 🌪 ветер
                float noise = sin(_Time.y + pos.x * 2 + pos.z * 2);
                float wind = noise * _WindStrength;

                // 🌿 изгиб (чем выше — тем сильнее)
                float heightFactor = v.uv.y;
                pos.x += wind * heightFactor;

                // 📏 масштаб травы
                pos.y *= _BladeHeight;
                pos.x *= _BladeWidth;

                float3 worldPos = TransformObjectToWorld(pos);
                o.positionHCS = TransformWorldToHClip(worldPos);
                o.worldPos = worldPos;
                o.uv = v.uv;

                return o;
            }

            half4 frag (Varyings i) : SV_Target
            {
                // 🎨 градиент как у тебя
                float4 col = lerp(_BottomColor, _TopColor, i.uv.y);
                return col;
            }

            ENDHLSL
        }
    }
}