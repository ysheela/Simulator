
using System.Collections.Generic;

namespace inningssimulator.rules.impl
{
  public class ErrorRule : AbstractBaseRule
  {
    public ErrorRule() : base(InningsConstants.ERROR)
    {
    }

    public override void process(List<IPlayerDetails> allPlayersOnField, bool isLast)
    {
      List<IPlayerDetails> allRunners = allPlayersOnField.FindAll(x => x.position != 0);
      allRunners.ForEach(x =>
      {
        x.position += 1;
      });
    }
  }
}