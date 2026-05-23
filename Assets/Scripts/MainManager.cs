using UnityEngine;
using Unity.IO;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }
    public Color teamcolor;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }
    [System.Serializable]

    class saveData
    {
        public Color teamColor;
    }
    public void saveColor()
    {
        saveData data = new saveData();
        data.teamColor = teamcolor;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string text = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(text))
        {
            string json =File.ReadAllText(text);
            saveData data =JsonUtility.FromJson<saveData>(json);
            teamcolor = data.teamColor;
        }
    }
}
