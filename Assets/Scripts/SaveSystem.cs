using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (UnityEngine.GameObject player, StateManager state)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        //PlayerInfo info = new PlayerInfo(player, state);
        PlayerData data = player.GetComponent<PlayerData>();


        formatter.Serialize(stream, data.serialize());
        stream.Close();
    }

    public static PlayerInfo LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            //PlayerInfo info = formatter.Deserialize(stream) as PlayerInfo;

            PlayerInfo data = formatter.Deserialize(stream) as PlayerInfo;
            stream.Close();

            return data;
        } else
        {
            Debug.LogError("Save file not found here " + path);
            return null;
        }
    }
}
