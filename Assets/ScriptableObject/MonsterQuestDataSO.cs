using UnityEngine;

[CreateAssetMenu(fileName = "MonsterQuestDataSO", menuName = "boot-camp-practice-2/MonsterQuestDataSO")]
public class MonsterQuestDataSO : QuestDataSO
{
    public int QuestMonster; // 처치할 몬스터의 ID
    public int KillCount;
}