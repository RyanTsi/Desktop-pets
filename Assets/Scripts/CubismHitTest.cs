using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.Raycasting;
public class CubismHitTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }

        CubismRaycaster cubismRaycaster = GetComponent<CubismRaycaster>();
        CubismRaycastHit[] cubismRaycastHits = new CubismRaycastHit[4];
        

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        int hitCount = cubismRaycaster.Raycast(ray,cubismRaycastHits);
        string resultsText = hitCount.ToString();
        for (int i = 0; i < hitCount; i++)
        {
            
        }
    }
}
