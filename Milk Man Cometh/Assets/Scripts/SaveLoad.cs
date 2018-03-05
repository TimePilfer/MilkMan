using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

    [Serializable]
    class PlayerData
    {
        // TODO: see about making gets and sets.
        // TODO: automate the generation of this data structure.  See:
        // http://for ums.devx.com/showthread.php?170650-How-to-dynamically-add-property-to

        // Add new variables for loading and saving here.
        //public int experiencePoints;
        public int playerLevel;
        public int playerHealth;
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat",
                                    FileMode.OpenOrCreate);

        PlayerData data = new PlayerData();
        //data.experiencePoints = experiencePoints;
        data.playerHealth = Damage.player.health;
        data.playerLevel = SceneManager.GetActiveScene().buildIndex;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log(Application.persistentDataPath + "/gameInfo.dat");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat",
                                        FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            
            //experiencePoints = data.experiencePoints;
            SceneManager.SetActiveScene(SceneManager.GetSceneAt( data.playerLevel));
            //sceneIndex = data.playerLevel;
            Damage.player.health = data.playerHealth;
        }
    } 
}
