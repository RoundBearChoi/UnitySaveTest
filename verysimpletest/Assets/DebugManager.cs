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
        try
        {
            filepath = Application.persistentDataPath + Path.DirectorySeparatorChar + "UnityConsoleLog.txt";

            Log("attempting writing log file: " + filepath);

            File.WriteAllText(filepath, System.DateTime.Now.ToString() + "\n\n");

            Log("log file created: " + filepath);
        }
        catch(System.Exception e)
        {
            Log("failed to create log file\n" + e);
        }
    }

    public void Log(object message)
    {
        if (savelog)
        {
            sw = File.AppendText(filepath);
            sw.WriteLine(message + "\n");
            sw.Close();
        }

        Debug.Log(message);
    }
}