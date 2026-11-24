using System;
using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.Rendering;

public static class OpenMMORPGWebGLBuild
{
    private static readonly string[] ScenePaths =
    {
        "Assets/OpenMMORPG/Demo/Scenes/00Init-Singleplayer.unity",
        "Assets/OpenMMORPG/Demo/Scenes/01Home-Singleplayer.unity",
        "Assets/OpenMMORPG/Demo/Scenes/DemoMap.unity",
        "Assets/OpenMMORPG/Demo/Scenes/DemoDungeon.unity"
    };

    public static void Build()
    {
        foreach (var scene in ScenePaths)
        {
            if (!File.Exists(scene))
                throw new FileNotFoundException("Chybí originální OpenMMORPG demo scéna. Zkontrolujte Git submodule.", scene);
        }

        const string demoUrp = "Assets/OpenMMORPG/Demo/Settings/DemoURP.asset";
        var pipeline = AssetDatabase.LoadAssetAtPath<RenderPipelineAsset>(demoUrp);
        if (pipeline != null)
        {
            GraphicsSettings.defaultRenderPipeline = pipeline;
            for (int quality = 0; quality < QualitySettings.names.Length; quality++)
                QualitySettings.SetRenderPipelineAssetAt(quality, pipeline);
        }
        else
        {
            Debug.LogWarning("Demo URP asset nebyl nalezen. Zkontrolujte render pipeline a Unity package import.");
        }

        PlayerSettings.productName = "Tajná legenda Beskyd - OpenMMORPG TEST";
        PlayerSettings.companyName = "KamIva Games";

        var options = new BuildPlayerOptions
        {
            scenes = ScenePaths,
            locationPathName = "Build/WebGL",
            target = BuildTarget.WebGL,
            options = BuildOptions.StrictMode
        };
        BuildReport report = BuildPipeline.BuildPlayer(options);
        if (report.summary.result != BuildResult.Succeeded)
            throw new InvalidOperationException("WebGL build selhal: " + report.summary.result);
        Debug.Log("OpenMMORPG WebGL singleplayer demo build OK: " + options.locationPathName);
    }
}
