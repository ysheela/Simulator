using System;
using System.Collections.Generic;
using System.Linq;

namespace inningssimulator.rules.impl
{
  public class BaseHitterRule : AbstractBaseRule
  {
    private int movePositions = 0;

    public BaseHitterRule(string playTypeValue, int positions) : base(playTypeValue)
    {
      movePositions = positions;
    }

    public override void process(List<IPlayerDetails> allPlayersOnField, bool isLast)
    {
      allPlayersOnField.ForEach(x =>
      {
        x.position += movePositions;
      });
    }
  }
}