using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DreamGuardian.Core;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace DreamGuardian.Maze
{
    public class MazeGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject groundPrefab;
        [SerializeField] private MazeNode nodePrefab;
        [SerializeField] private Vector2Int mazeSize;
        
        [Button("Create Maze")]
        private void GenerateMazeInstant()
        {
            ClearMaze();

            GameObject parentObject = new GameObject();
            Transform parentTransform = parentObject.transform;
            parentTransform.parent = transform;
            parentObject.name = $"Maze {mazeSize.x}x{mazeSize.y}";
            
            GameObject ground = PrefabUtility.InstantiatePrefab(groundPrefab, parentTransform) as GameObject;
            ground.transform.parent = parentTransform;
            ground.transform.localScale = new Vector3(mazeSize.x, 1, mazeSize.y) / 10f;
            ground.transform.localPosition = Vector3.zero;
            
            List<MazeNode> nodes = new List<MazeNode>();

            // Create nodes
            for (int x = 0; x < mazeSize.x; x++)
            {
                for (int y = 0; y < mazeSize.y; y++)
                {
                    Vector3 nodePos = new Vector3(x - (mazeSize.x / 2f) + 0.5f, 0, y - (mazeSize.y / 2f) + 0.5f);
                    MazeNode newNode = PrefabUtility.InstantiatePrefab(nodePrefab, parentTransform) as MazeNode;
                    newNode.transform.position = nodePos;
                    nodes.Add(newNode);
                }
            }

            List<MazeNode> currentPath = new List<MazeNode>();
            List<MazeNode> completedNodes = new List<MazeNode>();

            // Choose starting node
            currentPath.Add(nodes[Random.Range(0, nodes.Count)]);

            while (completedNodes.Count < nodes.Count)
            {
                // Check nodes next to the current node
                List<int> possibleNextNodes = new List<int>();
                List<int> possibleDirections = new List<int>();

                int currentNodeIndex = nodes.IndexOf(currentPath[^1]);
                int currentNodeX = currentNodeIndex / mazeSize.y;
                int currentNodeY = currentNodeIndex % mazeSize.y;

                if (currentNodeX < mazeSize.x - 1)
                {
                    // Check node to the right of the current node
                    if (!completedNodes.Contains(nodes[currentNodeIndex + mazeSize.y]) &&
                        !currentPath.Contains(nodes[currentNodeIndex + mazeSize.y]))
                    {
                        possibleDirections.Add(1);
                        possibleNextNodes.Add(currentNodeIndex + mazeSize.y);
                    }
                }
                if (currentNodeX > 0)
                {
                    // Check node to the left of the current node
                    if (!completedNodes.Contains(nodes[currentNodeIndex - mazeSize.y]) &&
                        !currentPath.Contains(nodes[currentNodeIndex - mazeSize.y]))
                    {
                        possibleDirections.Add(2);
                        possibleNextNodes.Add(currentNodeIndex - mazeSize.y);
                    }
                }
                if (currentNodeY < mazeSize.y - 1)
                {
                    // Check node above the current node
                    if (!completedNodes.Contains(nodes[currentNodeIndex + 1]) &&
                        !currentPath.Contains(nodes[currentNodeIndex + 1]))
                    {
                        possibleDirections.Add(3);
                        possibleNextNodes.Add(currentNodeIndex + 1);
                    }
                }
                if (currentNodeY > 0)
                {
                    // Check node below the current node
                    if (!completedNodes.Contains(nodes[currentNodeIndex - 1]) &&
                        !currentPath.Contains(nodes[currentNodeIndex - 1]))
                    {
                        possibleDirections.Add(4);
                        possibleNextNodes.Add(currentNodeIndex - 1);
                    }
                }

                // Choose next node
                if (possibleDirections.Count > 0)
                {
                    int chosenDirection = Random.Range(0, possibleDirections.Count);
                    MazeNode chosenNode = nodes[possibleNextNodes[chosenDirection]];

                    switch (possibleDirections[chosenDirection])
                    {
                        case 1:
                            chosenNode.RemoveWall(1);
                            currentPath[^1].RemoveWall(0);
                            break;
                        case 2:
                            chosenNode.RemoveWall(0);
                            currentPath[^1].RemoveWall(1);
                            break;
                        case 3:
                            chosenNode.RemoveWall(3);
                            currentPath[^1].RemoveWall(2);
                            break;
                        case 4:
                            chosenNode.RemoveWall(2);
                            currentPath[^1].RemoveWall(3);
                            break;
                    }

                    currentPath.Add(chosenNode);
                }
                else
                {
                    completedNodes.Add(currentPath[^1]);

                    currentPath.RemoveAt(currentPath.Count - 1);
                }
            }
        }

        [Button("Clear Maze")]
        private void ClearMaze()
        {
            List<Transform> childrenTransforms = GetComponentsInChildren<Transform>().ToList();

            childrenTransforms.Remove(transform);
            
            foreach (Transform childrenTransform in childrenTransforms)
            {
                if (childrenTransform != null)
                {
                    DestroyImmediate(childrenTransform.gameObject);
                }
            }
        }
    }
}
