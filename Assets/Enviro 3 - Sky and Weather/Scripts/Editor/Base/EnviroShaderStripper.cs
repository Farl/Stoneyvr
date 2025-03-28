﻿using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering; 

namespace Enviro
{
public class ShaderStripper : IPreprocessShaders
{
		private const string LOG_FILE_PATH = "Library/Shader Compilation Results.txt";

		private static readonly ShaderKeyword[] SKIPPED_VARIANTS = new ShaderKeyword[]
		{
			new ShaderKeyword( "ENVIROHDRP" ),
			new ShaderKeyword( "ENVIROURP" ),
		};

		public int callbackOrder { get { return 0; } }

		public void OnProcessShader( Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data )
		{
			string shaderName = shader.name;
 
		//URP Shader
		#if !ENVIRO_URP
			if(shaderName == "Hidden/EnviroBlitThrough")
				data.Clear();

			if(shaderName == "Hidden/VolumetricsURP")
				data.Clear();
		#endif 

		//URP 17+ Shader
		#if !ENVIRO_URP || !UNITY_6000_0_OR_NEWER
		if(shaderName == "Hidden/EnviroBlitThroughURP17")
			data.Clear();

		if(shaderName == "Hidden/EnviroBlurURP")
			data.Clear();

		if(shaderName == "Hidden/EnviroHeightFogURP")
			data.Clear();

		if(shaderName == "Hidden/EnviroApplyShadowsURP")
			data.Clear();

		if(shaderName == "Hidden/EnviroVolumetricCloudsBlendURP")
			data.Clear();
		
		if(shaderName == "Hidden/EnviroVolumetricCloudsDepthURP")
			data.Clear();

		if(shaderName == "Hidden/EnviroCloudsRaymarchURP")
			data.Clear();

		if(shaderName == "Hidden/EnviroVolumetricCloudsReprojectURP")
			data.Clear();

		#endif

		//HDRP Shaders
		#if !ENVIRO_HDRP
			if(shaderName == "Hidden/Enviro/BlitTroughHDRP")
				data.Clear();
	
			if(shaderName == "Hidden/EnviroApplyShadowsHDRP")
				data.Clear();

			if(shaderName == "Hidden/EnviroCloudsRaymarchHDRP")
				data.Clear();

			if(shaderName == "Hidden/EnviroVolumetricCloudsBlendHDRP")
				data.Clear();

			if(shaderName == "Hidden/EnviroVolumetricCloudsDepthHDRP")
				data.Clear();

			if(shaderName == "Hidden/EnviroVolumetricCloudsReprojectHDRP")
				data.Clear();

			if(shaderName == "Hidden/EnviroHeightFogHDRP")
				data.Clear();

			if(shaderName == "Enviro/HDRP/Sky")
				data.Clear();
		#endif
		}
	}
}

