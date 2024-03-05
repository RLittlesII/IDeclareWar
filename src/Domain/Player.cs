namespace War.Domain;

/// <summary>
/// Represents an Actor interacting with the program.
/// </summary>
public class Player
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Player"/> class.
    /// </summary>
    /// <param name="name">The name.</param>
    public Player(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets the list of cards.
    /// </summary>
    public IList<Card> Deck { get; }
}