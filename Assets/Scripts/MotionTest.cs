using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.Motion;
public class MotionTest : MonoBehaviour
{
    // Start is called before the first frame update
    private CubismMotionController cubismMotionController;

    public AnimationClip[] clip;

    private int animationIndex;
    // Start is called before the first frame update
    void Start()
    {
        cubismMotionController = GetComponent<CubismMotionController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            animationIndex++;
            if (animationIndex >= clip.Length)
            {
                animationIndex = 0;
            }
            cubismMotionController.PlayAnimation(clip[animationIndex],0,2,false);
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
