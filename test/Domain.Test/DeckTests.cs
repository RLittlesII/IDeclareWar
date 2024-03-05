using System.Collections;
using DryIoc.ImTools;
using FluentAssertions;
using Rocket.Surgery.Extensions.Testing.Fixtures;
using Xunit;

namespace War.Domain.Test;

public class DeckTests
{
    [Fact]
    public void GivenInitial_WhenDeal_ThenDeckIsHalved()
    {
        // Given
        Deck sut = new DeckFixture().WithCards(new Card(Rank.Ace, Suit.Spade), new Card(Rank.Ace, Suit.Spade));

        // When
        var result = sut.Deal();

        // Then
        result[0].Count.Should().Be(result[1].Count);
    }
}

public class Deck : IReadOnlyCollection<Card>
{
    public Deck(params Card[] cards)
        : this(cards.ToList())
    {
    }

    public Deck(IEnumerable<Card> cards)
    {
        Cards = cards.ToList();
    }

    public Deck[] Deal()
    {
        var deck1 = Cards[0];
        var deck2 = Cards[1];

        return new Deck[] { new Deck(deck1), deck2 };
    }

    public void EndRound(IEnumerable<Card> cards)
    {
        Cards.AddRange(cards);
    }

    public List<Card> Cards { get; }

    public IEnumerator<Card> GetEnumerator() => Cards.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int Count => Cards.Count;
}

internal class DeckFixture : ITestFixtureBuilder
{
    public static implicit operator Deck(DeckFixture fixture) => fixture.Build();
    public DeckFixture WithCards(params Card[] cards) => this.With(ref _cards, cards);

    private Deck Build()
    {
        return new Deck(_cards);
    }

    private IEnumerable<Card> _cards = Enumerable.Empty<Card>();
}