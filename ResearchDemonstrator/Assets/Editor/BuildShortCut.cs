using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Diagnostics;
using System.IO;
using UnityEngine.SceneManagement;

public static class BuildShortCut {

    [MenuItem("IAT/BUILD")]
    public static void Build_SearchAndFind()
    {
        var path = EditorUtility.SaveFolderPanel("Choose Location of Built Game", System.Environment.CurrentDirectory, "");

        string[] levels = new string[] { "Assets/MainScene.unity" };

        var targetExecutable = path + "/" + "DemoBuild" + ".exe";

        BuildPipeline.BuildPlayer(levels, targetExecutable, BuildTarget.StandaloneWindows64, BuildOptions.None);

        // open the target directory
        Process.Start(path);
    }
}
