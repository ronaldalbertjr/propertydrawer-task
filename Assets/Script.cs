using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Script : MonoBehaviour
{
    [TagSelector]
    public string MyTag;

    [LayerSelector]
    public int MyLayer;

    private void Update()
    {
        gameObject.tag = MyTag;
        gameObject.layer = MyLayer;
        
    }
}
