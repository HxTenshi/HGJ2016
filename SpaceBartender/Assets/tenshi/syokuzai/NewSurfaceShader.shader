Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Hineri("Hineri", Float) = 0
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert //tessellate:tes addshadow

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		float _Hineri;

		struct appdata {
			float4 vertex :POSITION;
			float4 tangent :TANGENT;
			float3 normal :NORMAL;
			float2 texcoord :TEXCOORD0;
		};

		void vert(inout appdata v)
		{


			v.vertex.xyz = mul((float3x3)_Object2World,v.vertex.xyz);

			float h = _Hineri * v.vertex.x;
			//x
			float3 x = float3(1, 0, 0);
			float3 y = float3(0, cos(h), -sin(h));
			float3 z = float3(0, sin(h), cos(h));

			//y
			//float3 x = float3(cos(h), 0, sin(h));
			//float3 y = float3(0, 1, 0);
			//float3 z = float3(-sin(h),0, cos(h));

			float3x3 rot = float3x3(x, y, z);

			v.vertex.xyz = mul(rot, v.vertex.xyz);
			v.vertex.xyz = mul((float3x3)_World2Object, v.vertex.xyz);

			v.normal = mul(rot, v.normal);
		}


		//float4 tes() {
		//	return 16;
		//}

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
