namespace War.Domain;

public class Card
{
    public Card(Rank rank, Suit suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public Rank Rank { get; set; }

    public Suit Suit { get; set; }
}