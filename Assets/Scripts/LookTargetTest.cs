using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.LookAt;
public class LookTargetTest : MonoBehaviour, ICubismLookTarget
{
    public Vector3 GetPosition()
    {
        // if (!Input.GetMouseButton(0))
        // {
        //     return Vector3.zero;
        //     
        // }

        Vector3 targetPosition = Input.mousePosition;
        targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(
            targetPosition.x,targetPosition.y,0-Camera.main.transform.position.z));
        return targetPosition;
    }
    

    public bool IsActive()
    {
        return gameObject.activeInHierarchy;
    }
}
