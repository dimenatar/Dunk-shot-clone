Shader "Unlit/ShadowSaturationColor"
{
    Properties
    {
        _Saturation("Saturation", Range(0.0, 5.0)) = 1
        _Color("Color", Color) = (1,1,1,1)
    }
        SubShader
    {
          Pass
        {
            Tags {"LightMode" = "ForwardBase"}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_fwdbase nolightmap nodirlightmap nodynlightmap novertexlight
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "AutoLight.cginc"

            float4 _Color;
            float _Saturation;

                struct v2f
                {
                    float2 uv : TEXCOORD0;
                    SHADOW_COORDS(1) // put shadows data into TEXCOORD1
                    fixed3 diff : COLOR0;
                    fixed3 ambient : COLOR1;
                    float4 pos : SV_POSITION;
                };
                v2f vert(appdata_base v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = v.texcoord;
                    half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                    half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                    o.diff = nl * _LightColor0.rgb;
                    o.ambient = ShadeSH9(half4(worldNormal,1));
                    // compute shadows data
                    TRANSFER_SHADOW(o)
                    return o;
                }



                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = _Color;


                    fixed shadow = SHADOW_ATTENUATION(i);
                    fixed3 lighting = i.diff * shadow + i.ambient;


                    col.rgb *= lighting * _Saturation;
                    return col * _Saturation;
                }
                ENDCG
            }

            // shadow casting support
            UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
        }
}
