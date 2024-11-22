using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detachable : MonoBehaviour
{
    GameObject detachable_UI;

    private void Start()
    {
        detachable_UI = Managers.UI.CreateUI("detachable_UI");
    }

    private void Awake()
    {
        
    }
    protected virtual void Get_Order_Right()
    {
        
    }
}
