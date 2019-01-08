Shader "Custom/AlphaShade" {
    Properties {
        //_Color ("Main Color", Color) = (1,1,1,1)
        _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
        _AlphaMap ("Additional Alpha Map (Greyscale)", 2D) = "white" {}
    }
    
    SubShader {
        Tags { "RenderType"="Opaque"  "Queue" = "Transparent" }
        LOD 200

            //ZWrite Off
        // Blend SrcAlpha OneMinusSrcAlpha
    
    CGPROGRAM
    #pragma surface surf Lambert alpha


    
    sampler2D _MainTex; 
    sampler2D _AlphaMap; 
    //float4 _Color;
    
        struct Input {
            float2 uv_MainTex; 
            float2 uv_AlphaMap; 
        }; 
    
        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D (_MainTex, IN.uv_MainTex); 
            half4 d = tex2D (_AlphaMap, IN.uv_AlphaMap);
            o.Albedo = c.rgb; 
            o.Alpha = d.r;
        }
    ENDCG
    }
    FallBack "Diffuse"
 }
