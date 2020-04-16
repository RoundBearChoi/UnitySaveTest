using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{
    public UnityEngine.UI.Text uitext1;
    public UnityEngine.UI.Text uitext2;
    int simpleint = 0;

    IEnumerator Start()
    {
        //try
        //{
        //    DebugManager.Instance.Log("application started");
        //}
        //catch (System.Exception e)
        //{
        //    uitext1.text = e.ToString();
        //}
        
        DebugManager.Instance.Log("application started");
        uitext1.text = DebugManager.Instance.filepath;

        while(true)
        {
            yield return new WaitForSeconds(1f);
            RaiseNumber();
        }
    }

    void RaiseNumber()
    {
        simpleint++;
        uitext2.text = simpleint.ToString();
    }
}