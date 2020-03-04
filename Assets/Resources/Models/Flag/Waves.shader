Shader "Custom/Waves" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Speed ("Animation speed", Float) = 0.1
		_Amplitude ("Amplitude", Float) = 1.0
		_Frequency ("Frequency", Float) = 1.0
		_Phase ("Phase", Float) = 1.0
		_Direction ("Direction", Vector) = (1.0, 1.0, 0.0, 0.0)
		_Amplitude2 ("Amplitude 2", Float) = 1.0
		_Frequency2 ("Frequency 2", Float) = 1.0
		_Phase2 ("Phase 2", Float) = 1.0
		_Direction2 ("Direction 2", Vector) = (0.5, 1.0, 0.0, 0.0)
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
			float3 normal;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _Speed;
		float _Amplitude;
		float _Frequency;
		float _Phase;
		float2 _Direction;
		float _Amplitude2;
		float _Frequency2;
		float _Phase2;
		float2 _Direction2;
		
		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void vert (inout appdata_full v, out Input o) {
		    UNITY_INITIALIZE_OUTPUT(Input,o);

			// Get 2D vector for vertex coordinates
			float2 ver = float2(v.vertex.x, v.vertex.y);

			// Collect and normalize wave directions
			float2 dir = _Direction;
			dir = normalize(dir);
			float2 dir2 = _Direction2;
			dir2 = normalize(dir2);

			// Set parameters used in simulation
			float t = _Time.y * _Speed;
			float k = 2.5;

			// Simulate first wave
			v.vertex.z += 2.0*_Amplitude*(pow(sin(_Frequency*dot(dir, ver) + t*_Phase) + 1.0, k)/2.0);

			// Simulate second wave
			if (length(dir2) > 0.0000001){
				v.vertex.z += 2.0*_Amplitude2*(pow(sin(_Frequency2*dot(dir2, ver) + t*_Phase2) + 1.0, k)/2.0);
			}

			// Get derivatives for waves
			float dt = k*_Frequency*_Amplitude*(pow(sin(_Frequency*dot(dir, ver) + t*_Phase) + 1.0, k)/2.0)*cos(_Frequency*dot(dir, ver) + t*_Phase);
			if (length(dir2) > 0.0000001){
				dt += k*_Frequency2*_Amplitude2*(pow(sin(_Frequency2*dot(dir2, ver) + t*_Phase2) + 1.0, k)/2.0)*cos(_Frequency2*dot(dir2, ver) + t*_Phase2);
			}
			float dx = dir.x*dt;
			float dy = dir.y*dt;

			// Set normal for fragment
			v.normal = float3(-dx, -dy, 1.0);
			v.normal = normalize(v.normal);
			o.normal = v.normal;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			// Assign normal defined in vertex shader
			o.Normal = IN.normal;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
