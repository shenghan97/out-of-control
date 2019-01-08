Shader "Custom/BlendShader"
 {
 Properties {
     //_Color ("Main Color", Color) = (1,1,1,1)
     _MainTex1 ("Base (RGB) Trans (A)", 2D) = "white" {}
     _MainTex2 ("Base (RGB) Trans (A)", 2D) = "white" {}
     _MainTex3 ("Base (RGB) Trans (A)", 2D) = "white" {}
     _MainTex4 ("Base (RGB) Trans (A)", 2D) = "white" {}
     _MainTex5 ("Base (RGB) Trans (A)", 2D) = "white" {}

 }
  
 SubShader {
     Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
     Blend SrcAlpha OneMinusSrcAlpha, One One
     LOD 200

  
 CGPROGRAM
 #pragma surface surf Lambert alpha 
 #pragma target 4.0
 #pragma debug

 sampler2D _MainTex1;
 sampler2D _MainTex2;
 sampler2D _MainTex3;
 sampler2D _MainTex4;
 sampler2D _MainTex5;
 //float4 _Color;
  
 struct Input {
     float2 uv_MainTex1;
	 //float2 uv_AlphaMap;
     float2 uv_MainTex2;
     float2 uv_MainTex3;
     float2 uv_MainTex4;
     float2 uv_MainTex5;

 };
  

 void surf (Input IN, inout SurfaceOutput o) {
     half4 bg = tex2D(_MainTex1, IN.uv_MainTex1);
     half4 obj1 = tex2D(_MainTex2, IN.uv_MainTex2);
     half4 obj2 = tex2D(_MainTex3, IN.uv_MainTex3);
     half4 obj3 = tex2D(_MainTex4, IN.uv_MainTex4);
     half4 obj4 = tex2D(_MainTex5, IN.uv_MainTex5);

    
     //half3 result = merge(bg,obj1);
     //result = merge(result,obj2);

   // o.Albedo = result;
    // o.Albedo = merge(merge(merge(bg,obj1),obj2),obj3);
     o.Albedo = bg.rgb*(1-obj1.a)*(1-obj2.a)*(1-obj3.a)*(1-obj4.a) + obj1.rgb + obj2.rgb + obj3.rgb + obj4.rgb;
     o.Alpha = bg.a;
 }
 ENDCG
 }
  
 }