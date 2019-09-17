using System;
using System.Collections.Generic;
using inningssimulator;
using inningssimulator.rules.impl;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class HomeRunRuleTest
  {
    [Test]
    public void ruleShouldBeConfiguredCorrectly()
    {
      HomeRunRule rule = new HomeRunRule();
      Assert.IsTrue(rule.playType == InningsConstants.HOMERUN);
      Assert.IsTrue(rule.playType == "hr");
    }

    [Test]
    public void batterShouldMove4Positions()
    {
      HomeRunRule rule = new HomeRunRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1"));

      rule.process(allPlayers, false);

      IPlayerDetails player1 = allPlayers.Find(x => x.playerId == "P1");
      Assert.IsTrue(player1.scoredRun == true);
      Assert.IsTrue(player1.isHomeRun == true);
    }

    [Test]
    public void allPlayersShouldMove4Position()
    {
      HomeRunRule rule = new HomeRunRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1") { position = 0 });
      allPlayers.Add(new PlayerDetails("P2") { position = 1 });
      allPlayers.Add(new PlayerDetails("P3") { position = 2 });
      allPlayers.Add(new PlayerDetails("P4") { position = 3 });

      rule.process(allPlayers, false);

      List<IPlayerDetails> allPlayersWhoScoredRuns = allPlayers.FindAll(x => x.scoredRun == true);
      Assert.IsTrue(allPlayersWhoScoredRuns.Count == 4);

      IPlayerDetails playerWhoScoredHomeRun = allPlayers.Find(x => x.isHomeRun == true);
      Assert.IsTrue(playerWhoScoredHomeRun.playerId == "P1");
    }
  }
}