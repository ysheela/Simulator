using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace sample
{
  public interface IPlayerDetails
  {
    int position { get; set; }

    bool completedRun { get; set; }

    bool isHomeRun { get; set; }

    int totalOuts { get; set; }
  }
}