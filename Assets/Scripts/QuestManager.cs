using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager instance;

    void Awake()
    {
        if(instance == null)
            instance = this;
    }

}
