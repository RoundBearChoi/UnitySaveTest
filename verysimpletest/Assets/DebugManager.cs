using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DebugManager : Singleton<DebugManager>
{
    readonly bool savelog = true;

    public string path;
    StreamWriter sw;

    private void Awake()
    {
        path = Application.persistentDataPath + Path.DirectorySeparatorChar + "UnityConsoleLog.txt";
        File.WriteAllText(path, System.DateTime.Now.ToString() + "\n\n");
    }

    public void Log(object message)
    {
        if (savelog)
        {
            sw = File.AppendText(path);
            sw.WriteLine(message);
            sw.Close();
        }

        Debug.Log(message);
    }
}