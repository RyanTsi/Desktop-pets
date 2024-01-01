using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Live2D.Cubism.Framework.Expression;
using UnityEngine.EventSystems;
public class ExpressionTest : MonoBehaviour
{
    private CubismExpressionController expressionController;
    public static bool isPlayExpression = false;
    private int initIndex = -1;
    private int index;

    private int temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = PlayerPrefs.GetInt("exp");
        expressionController = GetComponent<CubismExpressionController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)&&!isPlayExpression)
        {
            index = 10;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.B) && !isPlayExpression)
        {
            index = 11;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.C) && !isPlayExpression)
        {
            index = 12;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.D) && !isPlayExpression)
        {
            index = 13;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.E) && !isPlayExpression)
        {
            index = 14;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.F) && !isPlayExpression)
        {
            index = 15;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.G) && !isPlayExpression)
        {
            index = 16;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.H) && !isPlayExpression)
        {
            index = 17;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.I) && !isPlayExpression)
        {
            index = 18;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.J) && !isPlayExpression)
        {
            index = 19;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.K) && !isPlayExpression)
        {
            index = 20;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.L) && !isPlayExpression)
        {
            index = 21;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.M) && !isPlayExpression)
        {
            index = 22;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.N) && !isPlayExpression)
        {
            index = 23;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.O) && !isPlayExpression)
        {
            index = 24;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.P) && !isPlayExpression)
        {
            index = 25;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Q) && !isPlayExpression)
        {
            index = 26;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.R) && !isPlayExpression)
        {
            index = 27;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.S) && !isPlayExpression)
        {
            index = 28;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.T) && !isPlayExpression)
        {
            index = 29;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.U) && !isPlayExpression)
        {
            index = 30;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.V) && !isPlayExpression)
        {
            index = 31;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.W) && !isPlayExpression)
        {
            index = 32;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.X) && !isPlayExpression)
        {
            index = 33;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Y) && !isPlayExpression)
        {
            index = 34;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Z) && !isPlayExpression)
        {
            index = 35;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha0) && !isPlayExpression)
        {
            index = 0;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha1) && !isPlayExpression)
        {
            index = 1;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha2) && !isPlayExpression)
        {
            index = 2;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha3) && !isPlayExpression)
        {
            index = 3;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha4) && !isPlayExpression)
        {
            index = 4;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha5) && !isPlayExpression)
        {
            index = 5;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha6) && !isPlayExpression)
        {
            index = 6;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha7) && !isPlayExpression)
        {
            index = 7;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha8) && !isPlayExpression)
        {
            index = 8;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Alpha9) && !isPlayExpression)
        {
            index = 9;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.UpArrow) && !isPlayExpression)
        {
            index = 36;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.DownArrow) && !isPlayExpression)
        {
            index = 37;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.RightArrow) && !isPlayExpression)
        {
            index = 38;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Escape) && !isPlayExpression)
        {
            index = 39;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Tab) && !isPlayExpression)
        {
            index = 40;
            StartCoroutine(PlayExpression(index));
        }else if ((Input.GetKey(KeyCode.LeftAlt)||Input.GetKey(KeyCode.RightAlt)) && !isPlayExpression)
        {
            index = 41;
            StartCoroutine(PlayExpression(index));
        }else if ((Input.GetKey(KeyCode.LeftShift)||Input.GetKey(KeyCode.RightShift)) && !isPlayExpression)
        {
            index = 42;
            StartCoroutine(PlayExpression(index));
        }else if ((Input.GetKey(KeyCode.LeftControl)||Input.GetKey(KeyCode.RightControl)) && !isPlayExpression)
        {
            index = 43;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetKey(KeyCode.Space) && !isPlayExpression)
        {
            index = 44;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetMouseButton(0) && !isPlayExpression&&!EventSystem.current.IsPointerOverGameObject())
        {
            index = 46;
            StartCoroutine(PlayExpression(index));
        }else if (Input.GetMouseButton(1) && !isPlayExpression)
        {
            index = 47;
            StartCoroutine(PlayExpression(index));
        }else if (temp != Favor.exp&&!isPlayExpression)
        {
            index = 51;
            StartCoroutine(PlayAddExp(index));
            temp = Favor.exp;
        }else if (Energy.energyNum < 15 && Energy.energyNum >= 5&&!isPlayExpression)
        {
            index = 52;
            StartCoroutine(PlayYun(index));
        }else if (Energy.energyNum < 5 && Energy.energyNum >= 0)
        {
            index = 53;
            isPlayExpression = true;
        }
        else if (Energy.energyNum >= 5 && isPlayExpression&&index !=-1)
        {
            index = -1;
            isPlayExpression = false;
        }
        
    }

    IEnumerator PlayExpression(int num)
    {
        isPlayExpression = true;
        expressionController.CurrentExpressionIndex = num;
        yield return new WaitForSecondsRealtime(0.01f);
        
        expressionController.CurrentExpressionIndex = initIndex;
        isPlayExpression = false;
    }
    IEnumerator PlayAddExp(int num)
    {
        isPlayExpression = true;
        expressionController.CurrentExpressionIndex = num;
        yield return new WaitForSecondsRealtime(1f);
        
        expressionController.CurrentExpressionIndex = initIndex;
        isPlayExpression = false;
    }
    IEnumerator PlayYun(int num)
    {
        isPlayExpression = true;
        expressionController.CurrentExpressionIndex = num;
        yield return new WaitForSecondsRealtime(5f);
        
        expressionController.CurrentExpressionIndex = initIndex;
        isPlayExpression = false;
    }
    
}
