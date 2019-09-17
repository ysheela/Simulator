using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace inningssimulator
{
  public class InningsResults
  {
    public InningsResults(List<IPlayerDetails> allPlayers)
    {
      List<IPlayerDetails> playersOnField = allPlayers.FindAll(x => x.scoredRun == false);
      int playerOnBaseOne = (playersOnField.Find(x => x.position == 1) != null) ? 1 : 0;
      int playerOnBaseTwo = (playersOnField.Find(x => x.position == 2) != null) ? 1 : 0;
      int playerOnBaseThree = (playersOnField.Find(x => x.position == 3) != null) ? 1 : 0;

      bases = String.Format("{0}{1}{2}", playerOnBaseOne, playerOnBaseTwo, playerOnBaseThree);
      totalRuns = allPlayers.Count(x => x.scoredRun);
      totalOuts = allPlayers.Sum(x => x.totalOuts);
    }

    public string bases { get; private set; }

    public int totalOuts { get; private set; }

    public int totalRuns { get; private set; }

  }
}