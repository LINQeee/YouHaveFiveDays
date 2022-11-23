// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Glass/Glass Specular" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)

		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Specular ("Specular", Color) = (1,1,1,1)

		 _NormalMap ("Normal Map", 2D) = "bump" {}

		_FresnelColor ("Fresnel Color", Color) = (0.26,0.19,0.16,0.0)
        _FresnelPower ("Fresnel Power", Range(0.5,30)) = 3.0
	}
	SubShader {
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf StandardSpecular fullforwardshadows alpha:fade

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NormalMap;

		struct Input {
			float2 uv_MainTex;
			float2 uv_NormalMap;
			float3 viewDir;
		};

		half _Glossiness;
		float3 _Specular;
		fixed4 _Color;
		float4 _FresnelColor;
   		float _FresnelPower;
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandardSpecular o) {
			// Albedo comes from a texture tinted by color
			o.Albedo = _Color.rgb;
			// Metallic and smoothness come from slider variables
			o.Specular = _Specular;
			o.Smoothness = _Glossiness;
			o.Alpha = _Color.a;

			o.Normal = UnpackNormal (tex2D (_NormalMap, IN.uv_NormalMap));
            half rim = 1.0 - saturate(dot (normalize(IN.viewDir), o.Normal));
            o.Emission = _FresnelColor.rgb * pow (rim, _FresnelPower);
		}
		ENDCG
	}
	FallBack "Diffuse"
}
