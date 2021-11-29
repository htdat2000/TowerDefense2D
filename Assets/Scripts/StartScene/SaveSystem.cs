using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{   
    public static void Save(PlayerStats _playerStats)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream file = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(_playerStats);

        formatter.Serialize(file, data);
        file.Close();
    }
    
    public static SaveData LoadSaveData()
    {
        string path = Application.persistentDataPath + "/player.data";
        
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(file) as SaveData;
            file.Close();

            return data;
        }
        else
        {
            Debug.Log("No Data");
            return null;
        }
    }
}
