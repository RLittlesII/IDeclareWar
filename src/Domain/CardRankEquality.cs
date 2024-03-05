namespace War.Domain;

public class CardRankEquality : IEqualityComparer<Card>
{
    public bool Equals(Card? x, Card? y)
    {
        if (ReferenceEquals(x, y))
        {
            return true;
        }

        if (ReferenceEquals(x, null))
        {
            return false;
        }

        if (ReferenceEquals(y, null))
        {
            return false;
        }

        if (x.GetType() != y.GetType())
        {
            return false;
        }

        return x.Rank == y.Rank;
    }

    public int GetHashCode(Card obj)
    {
        return HashCode.Combine((int)obj.Rank, obj.Suit);
    }
}