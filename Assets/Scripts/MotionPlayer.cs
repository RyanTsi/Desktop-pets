using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.Motion;
using Live2D.Cubism.Framework.MotionFade;

public class MotionPlayer : MonoBehaviour
{
    private CubismMotionController cubismMotionController;

    public AnimationClip clip;
    // Start is called before the first frame update
    void Start()
    {
        cubismMotionController = GetComponent<CubismMotionController>();
        PlayMotion(clip);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            cubismMotionController.StopAnimation(0,0);
            // cubismMotionController.StopAllAnimation();
        }
    }

    public void PlayMotion(AnimationClip animationClip)
    {
        if (cubismMotionController == null || animationClip == null)
        {
            Debug.LogError("动画资源为空");
            return;
        }
        cubismMotionController.PlayAnimation(animationClip,isLoop:false);
    }
}
