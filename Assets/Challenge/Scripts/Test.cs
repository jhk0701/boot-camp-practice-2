using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Challenge
{
    public class Test : MonoBehaviour
    {
        [ContextMenu("StartBgm")]
        public void StartBgm()
        {
            Debug.Log("Start bgm using singleton");
            // 싱글톤으로 호출 테스트
            AudioManager.Instance.PlayBgm();
        }

        
        [ContextMenu("StopBgm")]
        public void StopBgm()
        {
            Debug.Log("Stop bgm using singleton");
            // 싱글톤으로 호출 테스트
            AudioManager.Instance.StopBgm();
        }

    }
}