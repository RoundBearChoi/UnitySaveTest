using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DebugManager : Singleton<DebugManager>
{
    readonly bool savelog = true;

    public string filepath;
    StreamWriter sw;

    private void Awake()
    {
        InitLogFile();
    }

    void InitLogFile()
    {
        filepath = Application.persistentDataPath + Path.DirectorySeparatorChar + "UnityConsoleLog.txt";
        File.WriteAllText(filepath, System.DateTime.Now.ToString() + "\n\n");
    }

    public void Log(object message)
    {
        if (savelog)
        {
            sw = File.AppendText(filepath);
            sw.WriteLine(message);
            sw.Close();
        }

        Debug.Log(message);
    }
}