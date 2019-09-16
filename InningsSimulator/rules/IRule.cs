using System;
using System.Collections.Generic;

namespace sample.rules
{
  public interface IRule
  {
    string playType { get; }
    void process(List<IPlayerDetails> allPlayersOnField, bool isLast);

  }
}