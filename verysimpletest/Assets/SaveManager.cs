using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : Singleton<SaveManager>
{
    public string filepath;
    BinaryFormatter formatter;
    SaveSlate slate;

    private void Awake()
    {
        filepath = Application.persistentDataPath + Path.DirectorySeparatorChar + "UnitySaveFile.anyletters";
        formatter = new BinaryFormatter();
    }

    void Load()
    {
        try
        {
            DebugManager.Instance.Log("attempting load file: " + filepath);

            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            slate = (SaveSlate)formatter.Deserialize(fs);
            fs.Close();

            DebugManager.Instance.Log("load success: " + filepath + "\n" + "integer is: " + slate.SimpleInt);
        }
        catch (System.Exception e)
        {
            DebugManager.Instance.Log("load failed\n" + e);
            Save();
        }
    }

    void Save()
    {
        if (slate == null)
        {
            slate = new SaveSlate();
        }

        try
        {
            DebugManager.Instance.Log("attempting save file: " + filepath);
            
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate);
            formatter.Serialize(fs, slate);
            fs.Close();

            DebugManager.Instance.Log("save success: " + filepath + "\n" + "integer is: " + slate.SimpleInt);
        }
        catch(System.Exception e)
        {
            DebugManager.Instance.Log("save failed\n" + e);
        }
    }

    public void SaveInt(int integer)
    {
        slate.SimpleInt = integer;
        Save();
    }

    public int LoadInt()
    {
        Load();
        return slate.SimpleInt;
    }
}