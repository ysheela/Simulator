using System;
using System.Collections.Generic;
using System.Linq;
using inningssimulator.rules;
using inningssimulator.rules.impl;

namespace inningssimulator
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

    public InningsResults process(String[] playTypes)
    {
      log.Info("Processing Innings " + string.Join(", ", playTypes));

      allPlayers = new List<IPlayerDetails>();

      int playerId = 1;

      for (int i = 0; i < playTypes.Length; i++)
      {
        string playType = playTypes[i];
        IPlayerDetails batter = new PlayerDetails(string.Format("P{0}", playerId));
        allPlayers.Add(batter);

        IRule rule = allRules.Find(x => x.playType.ToLower() == playType.Trim().ToLower());
        if (rule == null)
        {
          throw new Exception(String.Format("Cannot find the rule associated with play type {0}", playType));
        }

        List<IPlayerDetails> playersOnField = allPlayers.FindAll(x => x.scoredRun == false);
        bool isLast = (i == playTypes.Length - 1);
        rule.process(playersOnField, isLast);
        playerId++;
      }

      InningsResults results = new InningsResults(allPlayers);
      log.Info(String.Format("Results are : Bases: {0}; Runs {1}, Outs {2}", results.bases, results.totalRuns, results.totalOuts));
      return results;
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