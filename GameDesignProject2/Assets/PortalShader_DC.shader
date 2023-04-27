Shader "Unlit/Hologram"
{
    Properties
    {
        _MainTex("Texture", 2D) = "purple" {}

        _TintColor("Tint Color", Color) = (1,0,1,1)
        _Transparency("Transparency", Range(0.0,0.5)) = 0.25
        _CutoutThresh("Cutout Threshold", Range(0.0,1.0)) = 0.2
        _Distance("Distance", Float) = 1
        _Amplitude("Amplitude", Float) = 1
        _Speed("Speed", Float) = 1
        _Amount("Amount", Range(0.0,1.0)) = 1

    }
        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            Pass
            {
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // make fog work
               // #pragma multi_compile_fog

                #include "UnityCG.cginc"

                struct appdata
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    //UNITY_FOG_COORDS(1)
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
            float _Transparency;
                float _CutoutThresh;
                float _Distance;
                float _Amplitude;
                float _Speed;
                float _Amount;

                v2f vert(appdata v)
                {
                    v2f o;
                    v.vertex.x += 2 * sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
                    //v.vertex.y += _Distance;
                   v.vertex.y += cos(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
 v.vertex.z += sin(_Time.y * _Speed + v.vertex.y * _Amplitude) * _Distance * _Amount;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    //UNITY_TRANSFER_FOG(o,o.vertex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    // sample the texture
                    fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
        float c = col.r + col.g + col.b;
        c /= 3;
        fixed4 n = float4(c,c,c,1);
        n.a = _Transparency;
                return n * 1.5;
            }
            ENDCG
        }
        }
}