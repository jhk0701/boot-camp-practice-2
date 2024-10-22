using UnityEngine;

public class QuestManager : Singleton<QuestManager>
{
    // private static QuestManager instance;
    // public static QuestManager Instance
    // {
    //     get 
    //     {
    //         if (instance == null)
    //         {
    //             instance = FindAnyObjectByType<QuestManager>();

    //             if (instance == null)
    //             {
    //                 GameObject go = new GameObject("Quest Manager");
    //                 instance = go.AddComponent<QuestManager>();
    //             }
    //         }

    //         return instance; 
    //     }
    // }

    public QuestDataSO[] Quests;

    // void Awake()
    // {
    //     if (instance == null)
    //         instance = this;        
    // }

    void Start()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            Debug.Log($"Quest {i + 1} - {Quests[i].QuestName} (최소 레벨 {Quests[i].QuestRequiredLevel})");
            Debug.Log($"{Quests[i].GetQuestContent()}");
        }
    }

}
