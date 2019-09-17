using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace inningssimulator
{

  public class PlayerDetails : IPlayerDetails
  {
    private int positionValue;

    public PlayerDetails(string idValue)
    {
      position = 0;
      playerId = idValue;
    }
    public int position
    {
      get
      {
        return positionValue;
      }
      set
      {
        positionValue = value;
        if (positionValue > 3)
        {
          scoredRun = true;
        }
      }
    }

    public string playerId { get; set; }

    public bool scoredRun { get; set; }

    public int totalOuts { get; set; }

    public bool isHomeRun { get; set; }
  }
}