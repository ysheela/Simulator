using System;
using System.Collections.Generic;
using inningssimulator;
using inningssimulator.rules.impl;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class WalkRuleTest
  {
    [Test]
    public void ruleShouldBeConfiguredCorrectly()
    {
      WalkRule rule = new WalkRule();
      Assert.IsTrue(rule.playType == InningsConstants.WALK);
      Assert.IsTrue(rule.playType == "bb");
    }

    [Test]
    public void batterShouldAdvanceOnePosition()
    {
      WalkRule rule = new WalkRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1"));

      rule.process(allPlayers, false);

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsNull(playerOnHomePlate);

      IPlayerDetails playerOnBase1 = allPlayers.Find(x => x.position == 1);
      Assert.NotNull(playerOnBase1);
    }

    [Test]
    public void allRunnersShouldAdvanceWhenDisplaced()
    {
      WalkRule rule = new WalkRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1") { position = 0 });
      allPlayers.Add(new PlayerDetails("P2") { position = 1 });
      allPlayers.Add(new PlayerDetails("P3") { position = 2 });
      allPlayers.Add(new PlayerDetails("P4") { position = 3 });

      rule.process(allPlayers, false);

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsNull(playerOnHomePlate);

      IPlayerDetails base1Player = allPlayers.Find(x => x.position == 1);
      Assert.IsTrue(base1Player.playerId == "P1");

      IPlayerDetails base2Player = allPlayers.Find(x => x.position == 2);
      Assert.IsTrue(base2Player.playerId == "P2");

      IPlayerDetails base3Player = allPlayers.Find(x => x.position == 3);
      Assert.IsTrue(base3Player.playerId == "P3");

      IPlayerDetails playerScoredrun = allPlayers.Find(x => x.scoredRun == true);
      Assert.IsTrue(playerScoredrun.playerId == "P4");
    }

    [Test]
    public void runnersShouldNotAdvanceWhenNotDisplaced()
    {
      WalkRule rule = new WalkRule();
      List<IPlayerDetails> allPlayers = new List<IPlayerDetails>();
      allPlayers.Add(new PlayerDetails("P1") { position = 0 });
      allPlayers.Add(new PlayerDetails("P3") { position = 2 });
      allPlayers.Add(new PlayerDetails("P4") { position = 3 });

      rule.process(allPlayers, false);

      IPlayerDetails playerOnHomePlate = allPlayers.Find(x => x.position == 0);
      Assert.IsNull(playerOnHomePlate);

      IPlayerDetails base1Player = allPlayers.Find(x => x.position == 1);
      Assert.IsTrue(base1Player.playerId == "P1");

      IPlayerDetails base2Player = allPlayers.Find(x => x.position == 2);
      Assert.IsTrue(base2Player.playerId == "P3");

      IPlayerDetails base3Player = allPlayers.Find(x => x.position == 3);
      Assert.IsTrue(base3Player.playerId == "P4");
    }
  }
}