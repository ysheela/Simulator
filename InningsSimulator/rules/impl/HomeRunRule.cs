using System;
using System.Collections.Generic;
using System.Linq;

namespace sample.rules.impl
{
  public class HomeRunRule : BaseHitterRule
  {
    public HomeRunRule() : base(InningsConstants.HOMERUN, 4)
    {
    }

    public override void process(List<IPlayerDetails> allPlayersOnField, bool isLast)
    {
      IPlayerDetails player = allPlayersOnField.Find(x => x.position == 0);
      player.isHomeRun = true;

      allPlayersOnField.ForEach(x =>
      {
        x.position += 4;
      });
    }
  }
}