using UnityEngine;

public enum EncounterActionType
{
    Talking,
    Greeting,
    // 기타 등등
}

[CreateAssetMenu(fileName = "EncounterQuestDataSO", menuName = "boot-camp-practice-2/EncounterQuestDataSO")]
public class EncounterQuestDataSO : QuestDataSO
{
    public EncounterActionType encounterAction;

    public override string GetQuestContent()
    {
        return $"{CharacterManager.Instance.Npcs[QuestNPC]}에게 {ConvertToString(encounterAction)}";
    }

    string ConvertToString(EncounterActionType type)
    {
        switch(type)
        {
            case EncounterActionType.Talking :
                return "대화하기";
            case EncounterActionType.Greeting :
                return "인사하기";
            default :
                return "대화하기";
        }
    }
}