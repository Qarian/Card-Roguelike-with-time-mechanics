using System;

namespace UI.Cards
{
    public interface ICardHolder
    {
        public bool ReceiveCard(CardUI card);

        public void ReturnCard(CardUI card);
    }
}