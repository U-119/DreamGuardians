using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public class MapPartCreator : MonoBehaviour
{
    [SerializeField] private GameObject partObject;
    [SerializeField] private Vector2 size;
    [SerializeField] private float scale;
    [SerializeField] private float orderPositionRange;
    
    [Button]
    private void Create()
    {
        Clear();
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newPartObject = Instantiate(partObject, transform);
                newPartObject.transform.localScale = Vector3.one * scale;
                float x = (i - (size.x / 2f) + 0.5f) * orderPositionRange;
                float z = (j - (size.y / 2f) + 0.5f) * orderPositionRange;

                newPartObject.transform.localPosition = new Vector3(x, 0f, z );
            }
        }
    }
    
    [Button("Clear")]
    private void Clear()
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
