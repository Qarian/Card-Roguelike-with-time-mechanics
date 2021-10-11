using Cards;
using UnityEngine;

namespace UI.Cards
{
    public class UICardPreview : MonoBehaviour
    {
        [SerializeField] private CardUI previewCard = default;

        private static CardUI staticPreviewCard;
        private static CardData currentDisplayedData;

        private void Awake()
        {
            staticPreviewCard = previewCard;
            staticPreviewCard.gameObject.SetActive(false);
        }

        public static void ShowPreview(CardData cardData)
        {
            staticPreviewCard.SetCard(cardData);
            currentDisplayedData = cardData;
            staticPreviewCard.gameObject.SetActive(true);
        }

        public static void HidePreview(CardData cardData)
        {
            if (currentDisplayedData != cardData)
                return;
            
            staticPreviewCard.gameObject.SetActive(false);
            currentDisplayedData = CardData.Empty;
        }
    }
}