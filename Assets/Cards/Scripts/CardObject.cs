using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CardObject : MonoBehaviour
{
    [SerializeField] private Image background = default;

    [Space]
    [NonSerialized] public CardStyle style;

    public new RectTransform transform;

    public Vector2 anchoredPosition
    {
        get => transform.anchoredPosition;
        set => transform.anchoredPosition = value;
    }
    
    public Quaternion rotation
    {
        get => transform.rotation;
        set => transform.rotation = value;
    }

    public void SetParent(Transform newParent)
    {
        transform.SetParent(newParent);
    }

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        background.color = Random.ColorHSV();
    }

    private void ApplyStyle()
    {
        background.sprite = style.background;
    }
}
