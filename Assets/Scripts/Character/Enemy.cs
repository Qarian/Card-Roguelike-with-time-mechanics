using UnityEngine;

namespace Entity
{
    [CreateAssetMenu(menuName = "Characters/Enemy")]
    public class Enemy : Character
    {
        [SerializeField] private Sprite sprite;
    }
}