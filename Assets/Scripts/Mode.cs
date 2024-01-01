using System.Collections;
using System.Collections.Generic;
using Live2D.Cubism.Framework.Expression;
using Live2D.Cubism.Framework.LookAt;
using Live2D.Cubism.Framework.Motion;
using UnityEngine;
using UnityEngine.UI;

public class Mode : MonoBehaviour
{
    // Start is called before the first frame update
    public Dropdown statusDrop;
    public Button feedButton;
    public Button touchButton;
    private CubismMotionController cubismMotionController;
    public AnimationClip sleepAnimationClip;
    public AnimationClip sceneAnimationClip;
    void Start()
    {
        cubismMotionController = GetComponent<CubismMotionController>();
    }

    // Update is called once per frame
    void Update()
    {
        //睡觉
        //没有表情反馈，不能喂食和触摸
        //不能目光追踪
        if (statusDrop.value == 1)
        {
            this.gameObject.GetComponent<ExpressionTest>().enabled = false;
            this.gameObject.GetComponent<CubismLookController>().enabled = false;
            // GetComponent<CubismExpressionController>().CurrentExpressionIndex = 
            cubismMotionController.PlayAnimation(sleepAnimationClip,isLoop:true);
            feedButton.enabled = true;
            touchButton.enabled = true;
        }
        //常态
        //所有功能正常使用
        else if(statusDrop.value == 2)
        {
            cubismMotionController.StopAllAnimation();
            this.gameObject.GetComponent<ExpressionTest>().enabled = true;
            this.gameObject.GetComponent<CubismLookController>().enabled = true;
            // GetComponent<CubismExpressionController>().CurrentExpressionIndex = 
            // cubismMotionController.PlayAnimation(sceneAnimationClip,isLoop:true);
            ExpressionTest.isPlayExpression = false;
            feedButton.enabled = true;
            touchButton.enabled = true;
        }
        //专注模式
        //没有目光追踪
        //同睡觉，但没有睡觉动画
        else
        {
            this.gameObject.GetComponent<ExpressionTest>().enabled = false;
            this.gameObject.GetComponent<CubismLookController>().enabled = false;
            feedButton.enabled = false;
            touchButton.enabled = false;
            cubismMotionController.StopAllAnimation();
        }
    }
}
