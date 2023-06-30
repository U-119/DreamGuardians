using UnityEngine;

namespace DreamGuardian.DoorMechanic
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private int id;

        public int Id => id;

        public void KeyCollected()
        {
            gameObject.SetActive(false);
        }
    }
}
