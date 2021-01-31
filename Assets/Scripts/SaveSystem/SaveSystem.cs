using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem<T>
    where T: class
{
    public const string PATH = "\\data\\UserInfo.bin";
    public bool IsLoaded => _isLoaded;
    private bool _isLoaded = false;

    public void SaveInfo(object[] infoToSave)
    {
        using (var fileStream = new FileStream(Application.dataPath + PATH, FileMode.OpenOrCreate))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(fileStream, infoToSave);
        }
    }

    public T LoadInfo()
    {
        T result = default;

        if (File.Exists(Application.dataPath + PATH))
        {
            using (var fileStream = new FileStream(Application.dataPath + PATH, FileMode.OpenOrCreate))
            {
                if (fileStream.Length > 0)
                {
                    var formatter = new BinaryFormatter();
                    result = formatter.Deserialize(fileStream) as T;
                    _isLoaded = true;
                }
            }
        }

        return result;
    }
}
