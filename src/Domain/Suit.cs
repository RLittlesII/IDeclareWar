namespace War.Domain;

public struct Suit
{
    private Suit(string spadeName)
    {
        Value = spadeName;
    }

    public string Value;

    public static Suit Spade { get; } = new Suit(nameof(Spade));

    public static Suit Club { get; } = new Suit(nameof(Club));

    public static Suit Heart { get; } = new Suit(nameof(Heart));

    public static Suit Diamond { get; } = new Suit(nameof(Diamond));
}