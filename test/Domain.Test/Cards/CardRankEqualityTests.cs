using FluentAssertions;
using Xunit;

namespace War.Domain.Test.Cards;

public class CardRankEqualityTests
{
    [Fact]
    public void GivenTwoCards_WhenEqualityCompared_ThenAreEqual()
    {
        // Given
        var right = new Card(Rank.Two, Suit.Spade);
        var left = new Card(Rank.Three, Suit.Spade);

        // When
        new CardRankEquality()
            .Equals(right, left)
            .Should()
            .BeTrue();

        // Then
    }

    [Fact]
    public void GivenTwoCardsWithDifferentSuit_WhenEqualityCompared_ThenAreEqual()
    {
        // Given
        var right = new Card(Rank.Two, Suit.Spade);
        var left = new Card(Rank.Two, Suit.Club);

        // When, Then
        new CardRankEquality()
            .Equals(right, left)
            .Should()
            .BeTrue();
    }

    [Fact]
    public void GivenTwoCardsWithDifferentRanks_WhenEqualityCompared_ThenAreNotEqual()
    {
        // Given
        var right = new Card(Rank.Two, Suit.Spade);
        var left = new Card(Rank.Three, Suit.Spade);

        // When, Then
        new CardRankEquality()
            .Equals(right, left)
            .Should()
            .BeFalse();
    }

    [Fact]
    public void GivenTwoCardsWithDifferentRanks_WhenCompared_ThenHigherValueExpected()
    {
        // Given
        var right = new Card(Rank.King, Suit.Spade);
        var left = new Card(Rank.Three, Suit.Spade);

        // When, Then
        (right.Rank > left.Rank)
            .Should()
            .BeTrue();
    }

    [Fact]
    public void GivenAnAce_WhenCompared_ThenAceIsHigh()
    {
        // Given
        var right = new Card(Rank.Ace, Suit.Spade);
        var left = new Card(Rank.King, Suit.Spade);

        // When, Then
        (right.Rank > left.Rank)
            .Should()
            .BeTrue();
    }
}