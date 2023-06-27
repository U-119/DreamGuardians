using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DreamGuardian.Core;

namespace DreamGuardian.Maze
{
    public class MazeNode : MonoBehaviour
    {
        [SerializeField] private GameObject[] walls;

        public void RemoveWall(int wallToRemove)
        {
            walls[wallToRemove].gameObject.SetActive(false);
        }
    }
}