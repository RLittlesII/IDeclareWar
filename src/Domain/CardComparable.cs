namespace War.Domain;

public class CardComparable : IComparable<Card>
{
    public CardComparable(Card card)
    {
        Card = card;
    }

    public Card Card { get; }

    public int CompareTo(Card? other)
    {
        throw new NotImplementedException();
    }
}