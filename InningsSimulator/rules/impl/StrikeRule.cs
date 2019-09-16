
using System.Collections.Generic;

namespace sample.rules.impl
{
  public class StrikeRule : BaseRule
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