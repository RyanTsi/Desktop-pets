using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Live2D.Cubism.Framework.Json;
using System;
using System.IO;

public class loadModelPrefab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Resources
        // GameObject modelPrefab = Resources.Load<GameObject>("hiyori_pro_t11");
        // Instantiate(modelPrefab);
        //StreamingAssets
        // string path = Application.streamingAssetsPath + "/hiyori_pro_zh/hiyori_pro_zh/runtime/hiyori_pro_t11.model3.json";
        // CubismModel3Json cubismModel3Json = CubismModel3Json.LoadAtPath(path,initModel.BuiltInLoadAssetAtPath);
        // cubismModel3Json.ToModel();
        //AssetBundle
        string loadPath = Application.streamingAssetsPath + "/model.live2d";
        AssetBundle assetBundle=AssetBundle.LoadFromFile(loadPath);
        GameObject modelPrefab = assetBundle.LoadAsset<GameObject>("hiyori_pro_t11");
        Instantiate(modelPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
