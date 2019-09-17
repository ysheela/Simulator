using System;
using System.Collections.Generic;
using System.Linq;
using inningssimulator;
using inningssimulator.rules.impl;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class OutRuleTest
  {
    [Test]
    public void ruleShouldBeConfiguredCorrectly()
    {
      OutRule rule = new OutRule();
      Assert.IsTrue(rule.playType == InningsConstants.OUT);
      Assert.IsTrue(rule.playType == "out");
    }

    [Test]
    public void runnersShouldMoveIfOutIsNotLastPlayType()
    {
      OutRule rule = new OutRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1") { position = 0 });
      allPlayers.Add(new PlayerDetails("P2") { position = 1 });
      allPlayers.Add(new PlayerDetails("P3") { position = 3 });

      rule.process(allPlayers, false);

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.playerId == "P1");
      Assert.IsTrue(playerOnHomePlate.position == 0);
      Assert.IsFalse(playerOnHomePlate.scoredRun);
      Assert.IsTrue(playerOnHomePlate.totalOuts == 1);

      IPlayerDetails player2Details = allPlayers.Find(x => x.playerId == "P2");
      Assert.IsTrue(player2Details.position == 2);
      Assert.IsFalse(player2Details.scoredRun);

      IPlayerDetails player3Details = allPlayers.Find(x => x.playerId == "P3");
      Assert.IsTrue(player3Details.scoredRun);
    }

    [Test]
    public void runnersShouldNotMoveIfOutIsLastPlayType()
    {
      OutRule rule = new OutRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1") { position = 0 });
      allPlayers.Add(new PlayerDetails("P2") { position = 1 });
      allPlayers.Add(new PlayerDetails("P3") { position = 3 });

      rule.process(allPlayers, true);

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.playerId == "P1");
      Assert.IsTrue(playerOnHomePlate.position == 0);
      Assert.IsFalse(playerOnHomePlate.scoredRun);
      Assert.IsTrue(playerOnHomePlate.totalOuts == 1);

      IPlayerDetails player2Details = allPlayers.Find(x => x.playerId == "P2");
      Assert.IsTrue(player2Details.position == 1);
      Assert.IsFalse(player2Details.scoredRun);

      IPlayerDetails player3Details = allPlayers.Find(x => x.playerId == "P3");
      Assert.IsTrue(player3Details.position == 3);
      Assert.IsFalse(player3Details.scoredRun);
    }
  }
}