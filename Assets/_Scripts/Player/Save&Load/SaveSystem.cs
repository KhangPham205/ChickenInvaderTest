using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    //public static void SavePlayer (Player player)
    //{
    //    BinaryFormatter formatter = new BinaryFormatter();

    //    string path = Application.persistentDataPath + "/plaer.func";
    //    FileStream stream = new FileStream(path, FileMode.Create);

    //    Player_Data data = new Player_Data(player);

    //    formatter.Serialize(stream, data);
    //    stream.Close();
    //}

    //public static Player_Data LoadPlayer()
    //{
    //    string path = Application.persistentDataPath + "/plaer.func";
    //    if (File.Exists(path))
    //    {
    //        BinaryFormatter formatter = new BinaryFormatter();
    //        FileStream stream = new FileStream (path, FileMode.Open);

    //        Player_Data data = formatter.Deserialize(stream) as Player_Data;
    //        stream.Close();

    //        return data;
    //    }
    //    else
    //    {
    //        Debug.LogError("Save file not found in " + path);
    //        return null;
    //    }
    //}
}
