Shader "Custom/GridTransparency"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Radius ("Radius", Float) = 1.0
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            ZWrite Off
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            sampler2D _MainTex;
            float4 _Points[2];
            float _PointCount;
            float _Radius;
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD1;
            };
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                float distance = _Radius;

                for (int j = 0; j < _PointCount; j++) 
                {
                    distance = min(distance, length(i.worldPos - _Points[j].xyz));
                }

                float alpha = smoothstep(_Radius, _Radius * 0.8, distance);
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a *= alpha;
                return col;
            }
            ENDCG
        }
    }
}