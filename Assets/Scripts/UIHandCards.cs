using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class UIHandCards : MonoBehaviour
{
    [Range(0f, 90f)]
    [SerializeField] private float maxCardRotation;
    [MinValue(1f)]
    [SerializeField] private int maxCardsForCentering = 6;

    [Space]
    [SerializeField] private Vector2 cardsAnchor;
    
    private readonly List<CardObject> cardsInHand = new List<CardObject>(10);

    private new RectTransform transform;

    private float centeringOffset;

    private void Awake()
    {
        transform = GetComponent<RectTransform>();
    }

    [Button]
    public void AddCard(CardObject card)
    {
        var g = Instantiate(card, transform);
        if (cardsInHand.Contains(g))
        {
            MoveCardToPosition(g, cardsInHand.IndexOf(g));
            return;
        }
        else
        {
            cardsInHand.Add(g);
            Refresh();
        }
    }

    [Button]
    public void RemoveCard(int index)
    {
        cardsInHand.RemoveAt(index);
        Refresh();
    }

    public void RemoveCard(CardObject card)
    {
        cardsInHand.Remove(card);
        Refresh();
    }

    public void MoveCardToPosition(CardObject card, int position)
    {
        float xPos = (position + centeringOffset) / Mathf.Max(maxCardsForCentering - 1, cardsInHand.Count - 1);
        Vector2 pos = new Vector2(xPos - cardsAnchor.x, 1 - Mathf.Pow(1 - 2 * xPos, 2) - cardsAnchor.y);
        
        pos *= transform.sizeDelta;
        card.transform.parent = transform;
        card.anchoredPosition = pos;
        card.rotation = Quaternion.Euler(0, 0, maxCardRotation * (0.5f - xPos) * 2);
    }

    [Button]
    public void Refresh()
    {
        centeringOffset = Mathf.Clamp((maxCardsForCentering - cardsInHand.Count) / 2f, 0f, Mathf.Infinity);
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            MoveCardToPosition(cardsInHand[i], i);
        }
    }
}
