using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTest : MonoBehaviour
{
    public UnityEngine.UI.Text uitext1;
    public UnityEngine.UI.Text uitext2;
    public UnityEngine.UI.Text uitext3;
    int simpleint = 0;

    IEnumerator Start()
    {
        DebugManager.Instance.Log("application started");
        uitext1.text = DebugManager.Instance.filepath;

        simpleint = SaveManager.Instance.LoadInt();
        ShowInt();
        uitext3.text = SaveManager.Instance.filepath;

        while (true)
        {
            yield return new WaitForSeconds(1f);
            RaiseNumber();
            SaveManager.Instance.SaveInt(simpleint);
        }
    }

    void RaiseNumber()
    {
        simpleint++;
        ShowInt();
    }

    void ShowInt()
    {
        uitext2.text = simpleint.ToString();
    }
}