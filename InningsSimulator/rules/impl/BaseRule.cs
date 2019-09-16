using System;
using System.Collections.Generic;

namespace sample.rules.impl
{
  public abstract class BaseRule : IRule
  {
    public BaseRule(string playTypeValue)
    {
      playType = playTypeValue;
    }

    public string playType { get; private set; }


    public abstract void process(List<IPlayerDetails> allPlayersOnField, bool isLast);

  }
}