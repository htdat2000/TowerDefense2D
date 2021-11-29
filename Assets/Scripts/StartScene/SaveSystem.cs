using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem saveSystem;

    PlayerStats instance;

    SaveData data;

    void Awake()
    {   
        if (saveSystem != null)
        {
            Debug.LogError("More than one SaveSystem in scene");
            return;
        }
        saveSystem = this;
        instance = PlayerStats.playerStats;

        string path = Application.persistentDataPath + "/player.data";
        if(File.Exists(path))
        {      
            LoadSaveData(path);        

            int numberOfTower = instance.towerArray.Length;
        
            for(int i = 0; i < numberOfTower; i++)
            {

                instance.towerStar[i] = data.towerStar[i];
                instance.towerStatus[i] = data.towerStatus[i];
            }   
            instance.gem = data.gem;
            instance.diamond = data.diamond;       
        }
        else
        return;
    }
    
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream file = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData();

        formatter.Serialize(file, data);
        file.Close();
    }
    
    public void LoadSaveData(string _path)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = new FileStream(_path, FileMode.Open);

        SaveData _data = formatter.Deserialize(file) as SaveData;
        file.Close();

        data = _data ;
    }
}
