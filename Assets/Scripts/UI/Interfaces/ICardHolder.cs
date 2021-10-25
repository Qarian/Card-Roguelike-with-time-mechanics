namespace UI.Cards
{
    public interface ICardHolder
    {
        public bool CanReceiveCard(CardUI card);
        
        public void ReceiveCard(CardUI card);

        public void DragCard(CardUI card);

        public void RemoveCard(CardUI card);

        public void ReturnCard(CardUI card);
    }
}