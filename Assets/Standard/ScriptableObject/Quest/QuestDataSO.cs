using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestDataSO", menuName = "boot-camp-practice-2/QuestDataSO")]
public class QuestDataSO : ScriptableObject
{
    public string QuestName;
    public int QuestRequiredLevel;
    public int QuestNPC;
    public List<int> QuestPrerequisites;

    public virtual string GetQuestContent()
    {
        return $"{ CharacterManager.Instance.Npcs[QuestNPC]}에게 말걸기.";
    }
}