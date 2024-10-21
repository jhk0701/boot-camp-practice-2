using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;
    public static QuestManager Instance
    {
        get 
        {
            if (instance == null)
                instance = FindAnyObjectByType<QuestManager>();

            if (instance == null)
            {
                GameObject go = new GameObject("Quest Manager");
                instance = go.AddComponent<QuestManager>();
            }

            return instance; 
        }
        set
        {
            instance = value;
        }
    }

}
