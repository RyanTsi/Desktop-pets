using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    //鼠标输入
    private Vector3 _Mouse;
    //目标
    private Vector3 _Target;
    //差值
    private Vector3 effect;
    //当前 物件 位置
    private Transform _Transform;
    // //附件UI
    // public UnityEngine.UI.Text _Text;
    // private Vector3 Text_effect;
    // public UnityEngine.UI.Image _Image;
    // private Vector3 Image_effect;
    void Start()
    {
        _Transform = transform;
        //固定值 这个自己调试
        //Text_effect = new Vector3(140, 150, 0);
        //Image_effect = new Vector3(110, 150, 0);
    }
    //协程
    private IEnumerator OnMouseDown()
    {
        _Mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _Transform.position.z + 10f);
        //差值计算公式=物体中心坐标-鼠标输入坐标
        effect =  _Transform.position - Camera.main.ScreenToWorldPoint(_Mouse);
        // Text_effect = _Text.transform.position - _Mouse;
        // Image_effect = _Image.transform.position - _Mouse;
        while (Input.GetMouseButton(0))
        {
            _Mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _Transform.position.z+10f);
            //目标=差值+鼠标输入
            _Target = Camera.main.ScreenToWorldPoint(_Mouse) + effect;
            _Transform.position = _Target;
            // //让显示的文字和文本框也跟着移动
            // _Text.transform.position = _Mouse + Text_effect;
            // _Image.transform.position =_Mouse + Image_effect;
            //固定值对应公式
            // _Text.transform.position = Camera.main.WorldToScreenPoint(_Target) + Text_effect;
            // _Image.transform.position = Camera.main.WorldToScreenPoint(_Target) + Image_effect;
            yield return new WaitForFixedUpdate();
        }      
    }
}