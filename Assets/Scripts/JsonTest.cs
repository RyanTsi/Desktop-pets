using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using Live2D.Cubism.Framework.Json;
using Live2D.Cubism.Core;
using Live2D.Cubism.Framework.Physics;

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // cubismmodel3json
         string path = Application.dataPath + "/mine/桌宠.model3.json";
         CubismModel3Json cubismModel3Json = CubismModel3Json.LoadAtPath(path,initModel.BuiltInLoadAssetAtPath);
         CubismModel cubismModel = cubismModel3Json.ToModel();
        
         //.moc
         string mocPath = cubismModel3Json.FileReferences.Moc;
         Debug.Log("mocPath:"+mocPath);
        
         //.physics3.json
         string physicsPath = cubismModel3Json.FileReferences.Physics;
         Debug.Log("physicsPath:"+physicsPath);
        
        ////motion3.json
        // string json = Resources.Load<TextAsset>("mine/Scene1.motion3.motion3").text;
        // CubismMotion3Json cubismMotion3Json = CubismMotion3Json.LoadFrom(json);
        // AnimationClip animationClip = cubismMotion3Json.ToAnimationClip();
        // Debug.Log(animationClip);
        
        //userdata3json
        
        
        // //physcis.json
        // string json = Resources.Load<TextAsset>("mine/桌宠.physics3").text;
        // CubismPhysics3Json cubismPhysics3Json = CubismPhysics3Json.LoadFrom(json);
        // CubismPhysicsController cubismPhysicsController = cubismModel.GetComponent<CubismPhysicsController>();
        // cubismPhysicsController.Initialize(cubismPhysics3Json.ToRig());
        
        //cubismexp3.json
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
