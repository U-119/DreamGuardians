using System;
using DreamGuardian.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DreamGuardian.Core
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private int maxLevel;
        
        public int Level
        {
            get => PlayerPrefs.GetInt("Level", 1) > maxLevel ? maxLevel : PlayerPrefs.GetInt("Level", 1);
            set => PlayerPrefs.SetInt("Level", value);
        }

        private void Start()
        {
            LoadCurrentLevel();
        }

        public void LoadCurrentLevel()
        {
            SceneManager.LoadScene(Level);
        }
    }
}
