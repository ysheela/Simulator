
using System.Collections.Generic;

namespace inningssimulator.rules.impl
{
  public class StrikeRule : AbstractBaseRule
  {
    public StrikeRule() : base(InningsConstants.STRIKE)
    {
    }

    public override void process(List<IPlayerDetails> allPlayersOnField, bool isLast)
    {
      IPlayerDetails player = allPlayersOnField.Find(x => x.position == 0);
      player.totalOuts++;
    }
  }
}