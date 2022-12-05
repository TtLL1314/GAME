using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadController : MonoBehaviour
{
 //创建Save对象并存储当前游戏状态
    private Save CreateSaveGo()
    {
        Save save = new Save();
        save.coins = PublicController.Instance.coins;

        return save;
    }

    private void setGame(Save save)
    {
        PublicController.Instance.coins = save.coins;
    }

    private void SaveByBin()
    {
        Save save = CreateSaveGo();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create(Application.dataPath + "/StreamingFile" + "/byBin.txt");
        bf.Serialize(fileStream, save);
        fileStream.Close();
    }

    private void LoadByBin()
    {
        if(File.Exists(Application.dataPath + "/StreamingFile" + "/byBin.txt")){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fileStream = File.Open(Application.dataPath + "/StreamingFile" + "/byBin.txt", FileMode.Open);
            Save save = (Save)bf.Deserialize(fileStream);
            fileStream.Close();
            setGame(save);
        }
      
    }

    public void SaveGame()
    {
        SaveByBin();

    }

    public void LoadGame()
    {
        LoadByBin();
    }
}
