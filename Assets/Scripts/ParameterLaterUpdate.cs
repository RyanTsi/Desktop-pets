using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Core;
public class ParameterLaterUpdate : MonoBehaviour
{
    private CubismModel cubismModel;

    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        cubismModel = this.FindCubismModel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        timeCount += Time.deltaTime * 4;
        float value = Mathf.Sin(timeCount) * 30f;
        CubismParameter cubismParameter = cubismModel.Parameters[2];
        cubismParameter.Value = value;



    }
}
