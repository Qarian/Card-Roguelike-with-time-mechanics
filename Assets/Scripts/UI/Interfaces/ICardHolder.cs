namespace UI.Cards
{
    public interface ICardHolder
    {
        /// <summary>
        /// Called then card was dropped on CardHolder
        /// </summary>
        /// <param name="card"></param>
        /// <returns>Did object want to receive the card</returns>
        public bool ReceiveCard(CardUI card);

        public void ReturnCard(CardUI card);
    }
}