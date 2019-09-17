using System;
using System.Collections.Generic;
using System.Linq;
using inningssimulator;
using inningssimulator.rules.impl;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class DoubleBaseHitterRuleTest
  {
    [Test]
    public void ruleShouldBeConfiguredCorrectly()
    {
      DoubleBaseHitterRule rule = new DoubleBaseHitterRule();
      Assert.IsTrue(rule.playType == InningsConstants.DOUBLE);
      Assert.IsTrue(rule.playType == "2b");
    }

    [Test]
    public void batterShouldMoveTwoPositions()
    {
      DoubleBaseHitterRule rule = new DoubleBaseHitterRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1"));

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.NotNull(playerOnHomePlate);

      IPlayerDetails playerOnBase1 = allPlayers.Find(x => x.position == 1);
      Assert.IsNull(playerOnBase1);

      IPlayerDetails playerOnBase2 = allPlayers.Find(x => x.position == 2);
      Assert.IsNull(playerOnBase2);

      rule.process(allPlayers, false);

      playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsNull(playerOnHomePlate);

      playerOnBase1 = allPlayers.Find(x => x.position == 1);
      Assert.IsNull(playerOnBase1);

      playerOnBase2 = allPlayers.Find(x => x.position == 2);
      Assert.NotNull(playerOnBase2);
    }

    [Test]
    public void allPlayersShouldMoveTwoPosition()
    {
      DoubleBaseHitterRule rule = new DoubleBaseHitterRule();
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
      Assert.IsNull(base1Player);

      base2Player = allPlayers.Find(x => x.position == 2);
      Assert.IsTrue(base2Player.playerId == "P1");

      base3Player = allPlayers.Find(x => x.position == 3);
      Assert.IsTrue(base3Player.playerId == "P2");

      IPlayerDetails player3 = allPlayers.Find(x => x.playerId == "P3");
      Assert.IsTrue(player3.scoredRun);

      IPlayerDetails player4 = allPlayers.Find(x => x.playerId == "P4");
      Assert.IsTrue(player4.scoredRun);
    }
  }
}