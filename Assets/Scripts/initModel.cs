using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.Json;
using System;
using System.IO;
public class initModel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = Application.dataPath + "/hiyori_pro_zh/runtime/hiyori_pro_t11.model3.json";
        CubismModel3Json cubismModel3Json = CubismModel3Json.LoadAtPath(path,BuiltInLoadAssetAtPath);
        cubismModel3Json.ToModel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static object BuiltInLoadAssetAtPath(Type assetType,string absolutePath)
    {
        if (assetType == typeof(byte[]))
        {
            return File.ReadAllBytes(absolutePath);
        }else if (assetType == typeof(string))
        {
            return File.ReadAllText(absolutePath);
        }else if (assetType == typeof(Texture2D))
        {
            Texture2D texture2D = new Texture2D(1,1);
            texture2D.LoadImage(File.ReadAllBytes(absolutePath));
            return texture2D;
        }

        throw new NotSupportedException();
    }
}
