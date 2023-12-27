using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AssetBundleBuilder : Editor
{
    [MenuItem("Custom Editor/Build AssetBundles")]
    // Start is called before the first frame update
    static void BuildAsset()
    {
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows);
    }
}
