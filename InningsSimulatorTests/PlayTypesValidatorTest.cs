using System;
using inningssimulator;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class PlayTypesValidatorTests
  {
    [Test]
    public void shouldThrowExceptionWithSinglePlayType()
    {
      PlayTypesValidator validator = new PlayTypesValidator();

      string[] playTypes = { "b1" };
      var ex = Assert.Throws<Exception>(() => validator.validate(playTypes));
      Assert.That(ex.Message, Is.EqualTo("Invalid Play Types b1"));
    }

    [Test]
    public void shouldThrowExceptionWithMultiplePlayType()
    {
      PlayTypesValidator validator = new PlayTypesValidator();

      string[] playTypes = { "1b", "2b", "kr " };
      var ex = Assert.Throws<Exception>(() => validator.validate(playTypes));
      Assert.That(ex.Message, Is.EqualTo("Invalid Play Types 1b,2b,kr "));
    }

    [Test]
    public void shouldNotThrowExceptionIfValidPlayType()
    {
      PlayTypesValidator validator = new PlayTypesValidator();

      string[] playTypes = { "1b", "2b", "k ", "out " };
      validator.validate(playTypes);
    }
  }
}