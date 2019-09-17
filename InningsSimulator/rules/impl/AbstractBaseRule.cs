using System;
using System.Collections.Generic;

namespace inningssimulator.rules.impl
{
  public abstract class AbstractBaseRule : IRule
  {
    public AbstractBaseRule(string playTypeValue)
    {
      playType = playTypeValue;
    }

    public string playType { get; private set; }


    public abstract void process(List<IPlayerDetails> allPlayersOnField, bool isLast);

  }
}