namespace UI.Cards
{
    public interface ICardProvider : ICardReceiver
    {
        public void DragAwayCard(CardUI card);

        public void RemoveCard(CardUI card);

        public void ReturnCard(CardUI card);
    }
}