namespace UI.Cards
{
    public interface ICardReceiver
    {
        public bool CanReceiveCard(CardUI card);
        
        public void ReceiveCard(CardUI card);
    }
}