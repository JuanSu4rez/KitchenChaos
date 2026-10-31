using UnityEngine;

namespace _Project.Scripts
{
    [CreateAssetMenu(fileName = "KitchenObjectSO", menuName = "MY SCRIPTABLE OBJECTS/KitchenObjectSO")]
    public class KitchenObjectSO : ScriptableObject
    {
        public Transform prefab; 
        public Sprite sprite;
        public string objectName;
    }
}
