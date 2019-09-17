using System;
using System.Collections.Generic;
using System.Linq;
using inningssimulator;
using inningssimulator.rules.impl;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class StrikeRuleTest
  {
    [Test]
    public void ruleShouldBeConfiguredCorrectly()
    {
      StrikeRule rule = new StrikeRule();
      Assert.IsTrue(rule.playType == InningsConstants.STRIKE);
      Assert.IsTrue(rule.playType == "k");
    }

    [Test]
    public void runnersShouldNotMove()
    {
      StrikeRule rule = new StrikeRule();
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
      Assert.IsTrue(player2Details.position == 1);
      Assert.IsFalse(player2Details.scoredRun);

      IPlayerDetails player3Details = allPlayers.Find(x => x.playerId == "P3");
      Assert.IsTrue(player3Details.position == 3);
      Assert.IsFalse(player2Details.scoredRun);
    }
  }
}