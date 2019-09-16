
using System.Collections.Generic;

namespace sample.rules.impl
{
  public class OutRule : BaseRule
  {
    public OutRule() : base(InningsConstants.OUT)
    {
    }

    public override void process(List<IPlayerDetails> allPlayersOnField, bool isLast)
    {
      IPlayerDetails batter = allPlayersOnField.Find(x => x.position == 0);
      batter.totalOuts++;

      if (isLast == false)
      {
        List<IPlayerDetails> allRunners = allPlayersOnField.FindAll(x => x.position != 0);
        allRunners.ForEach(x =>
        {
          x.position += 1;
        });
      }

    }
  }
}