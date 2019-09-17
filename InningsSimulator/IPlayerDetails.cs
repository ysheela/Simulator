using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace inningssimulator
{
  public interface IPlayerDetails
  {
    string playerId { get; set; }
    int position { get; set; }

    bool scoredRun { get; set; }

    bool isHomeRun { get; set; }

    int totalOuts { get; set; }
  }
}