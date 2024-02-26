using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using Momo.Player;
using Momo.ScriptableObjects;

namespace Momo.MonsterManagerScene
{
    public delegate void grownMonsterEvent(GrownMonster grownMonster);
    public class MonsterManager : MonoBehaviour
    {
        #region Singleton
        public static MonsterManager Instance { get; private set; }
        public void Awake()
        {
            if (Instance == null) Instance = this;
            else DestroyImmediate(this);

        }
        public void OnDestroy()
        { }
        #endregion

        public event grownMonsterEvent OnNewActiveMonster;

        GrownMonster activeMonster;

        public void Start()
        {
            GetActiveMonster();
        }

        private void GetActiveMonster()
        {
            activeMonster = CentralPlayer.Instance.GetActiveMonster();
            OnNewActiveMonster?.Invoke(activeMonster);
        }

        public void DebugTest()
        {
            Debug.Log("Debug Test");
        }
    }
}
