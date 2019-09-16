using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sample
{
  public class PlayerDetails : IPlayerDetails
  {
    public PlayerDetails(string idValue)
    {
      position = 0;
      id = idValue;
    }
    public int position { get; set; }

    public string id { get; set; }

    public bool completedRun { get; set; }

    public int totalOuts { get; set; }

    public bool isHomeRun { get; set; }
  }
}