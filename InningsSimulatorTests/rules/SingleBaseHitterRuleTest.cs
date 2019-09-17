using System;
using System.Collections.Generic;
using inningssimulator;
using inningssimulator.rules.impl;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class SingleBaseHitterRuleTest
  {
    [Test]
    public void ruleShouldBeConfiguredCorrectly()
    {
      SingleBaseHitterRule rule = new SingleBaseHitterRule();
      Assert.IsTrue(rule.playType == InningsConstants.SINGLE);
      Assert.IsTrue(rule.playType == "1b");
    }

    [Test]
    public void batterShouldMoveOnePosition()
    {
      SingleBaseHitterRule rule = new SingleBaseHitterRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1"));

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.NotNull(playerOnHomePlate);

      IPlayerDetails playerOnBase1 = allPlayers.Find(x => x.position == 1);
      Assert.IsNull(playerOnBase1);

      rule.process(allPlayers, false);

      playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsNull(playerOnHomePlate);

      playerOnBase1 = allPlayers.Find(x => x.position == 1);
      Assert.NotNull(playerOnBase1);
    }

    [Test]
    public void allPlayersShouldMoveOnePosition()
    {
      SingleBaseHitterRule rule = new SingleBaseHitterRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1") { position = 0 });
      allPlayers.Add(new PlayerDetails("P2") { position = 1 });
      allPlayers.Add(new PlayerDetails("P3") { position = 2 });
      allPlayers.Add(new PlayerDetails("P4") { position = 3 });

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsTrue(playerOnHomePlate.playerId == "P1");

      IPlayerDetails base1Player = allPlayers.Find(x => x.position == 1);
      Assert.IsTrue(base1Player.playerId == "P2");

      IPlayerDetails base2Player = allPlayers.Find(x => x.position == 2);
      Assert.IsTrue(base2Player.playerId == "P3");

      IPlayerDetails base3Player = allPlayers.Find(x => x.position == 3);
      Assert.IsTrue(base3Player.playerId == "P4");

      rule.process(allPlayers, false);

      playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsNull(playerOnHomePlate);

      base1Player = allPlayers.Find(x => x.position == 1);
      Assert.IsTrue(base1Player.playerId == "P1");

      base2Player = allPlayers.Find(x => x.position == 2);
      Assert.IsTrue(base2Player.playerId == "P2");

      base3Player = allPlayers.Find(x => x.position == 3);
      Assert.IsTrue(base3Player.playerId == "P3");

      IPlayerDetails playerScoredrun = allPlayers.Find(x => x.scoredRun == true);
      Assert.IsTrue(playerScoredrun.playerId == "P4");
    }
  }
}