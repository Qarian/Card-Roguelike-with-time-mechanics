using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardObject : MonoBehaviour
{
    [SerializeField] private Image background = default;

    [Space]
    [NonSerialized] public CardStyle style;

    private new Transform transform;

    public Vector3 position
    {
        get => transform.position;
        set => transform.position = value;
    }
    
    public Quaternion rotation
    {
        get => transform.rotation;
        set => transform.rotation = value;
    }

    private void Awake()
    {
        transform = GetComponent<Transform>();
        background.color = Random.ColorHSV();
    }

    private void ApplyStyle()
    {
        background.sprite = style.background;
    }
}
