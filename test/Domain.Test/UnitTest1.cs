using FluentAssertions;

namespace War.Domain.Test;

public class Tests
{
    [Test]
    public void Test1()
    {
        true.Should().BeFalse();
    }
}