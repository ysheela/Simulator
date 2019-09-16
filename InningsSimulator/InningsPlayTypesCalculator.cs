using System;
using System.Collections.Generic;
using System.Linq;
using sample.rules;
using sample.rules.impl;

namespace sample
{
  public class InningsPlayTypesCalculator
  {
    private List<IPlayerDetails> allPlayers;

    private List<IRule> allRules;

    private static readonly log4net.ILog log =
     log4net.LogManager.GetLogger(typeof(InningsPlayTypesCalculator));

    public InningsPlayTypesCalculator()
    {
      initializeRules();
    }

    public void process(String[] playTypes)
    {
      log.Info("Processing Innings " + string.Join(", ", playTypes));

      initializeInnings();

      int playerId = 1;

      for (int i = 0; i < playTypes.Length; i++)
      {
        string playType = playTypes[i];
        IPlayerDetails batter = new PlayerDetails(string.Format("P{0}", playerId));
        allPlayers.Add(batter);

        IRule rule = allRules.Find(x => x.playType == playType.Trim());
        if (rule == null)
        {
          throw new Exception(String.Format("Cannot find the rule associated with play type {0}", playType));
        }

        List<IPlayerDetails> playersOnField = allPlayers.FindAll(x => x.completedRun == false);
        bool isLast = (i == playTypes.Length - 1);
        rule.process(playersOnField, isLast);

        processPlayers(allPlayers);
        playerId++;
      }

      calculateResults(allPlayers);
    }

    private void calculateResults(List<IPlayerDetails> allPlayers)
    {
      List<IPlayerDetails> playersOnField = allPlayers.FindAll(x => x.completedRun == false);
      int playerOnBaseOne = (playersOnField.Find(x => x.position == 1) != null) ? 1 : 0;
      int playerOnBaseTwo = (playersOnField.Find(x => x.position == 2) != null) ? 1 : 0;
      int playerOnBaseThree = (playersOnField.Find(x => x.position == 3) != null) ? 1 : 0;

      string bases = String.Format("{0}{1}{2}", playerOnBaseOne, playerOnBaseTwo, playerOnBaseThree);
      int runs = allPlayers.Count(x => x.completedRun);
      int outs = allPlayers.Sum(x => x.totalOuts);
      log.Info(String.Format("Results are : Bases: {0}; Runs {1}, Outs {2}", bases, runs, outs));
    }

    private void processPlayers(List<IPlayerDetails> allPlayersOnField)
    {
      foreach (IPlayerDetails details in allPlayersOnField)
      {
        if (details.position > 3)
        {
          details.completedRun = true;
        }
      }
    }

    private void initializeInnings()
    {
      allPlayers = new List<IPlayerDetails>();
    }


    private void initializeRules()
    {
      allRules = new List<IRule>();
      allRules.Add(new SingleBaseHitterRule());
      allRules.Add(new DoubleBaseHitterRule());
      allRules.Add(new TripleBaseHitterRule());
      allRules.Add(new ErrorRule());
      allRules.Add(new StrikeRule());
      allRules.Add(new WalkRule());
      allRules.Add(new HitByPitchRule());
      allRules.Add(new HomeRunRule());
      allRules.Add(new OutRule());
    }

  }
}