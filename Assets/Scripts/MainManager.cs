 using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance { get; private set; }
    public Color teamColor;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
