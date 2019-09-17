using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace inningssimulator
{
  public class PlayTypesValidator
  {
    public void validate(String[] playTypes)
    {
      bool isValid = playTypes.All(a => InningsConstants.VALID_PLAYTYPES.Contains(a.Trim()));
      if (isValid == false)
      {
        throw new Exception(String.Format("Invalid Play Types {0}", string.Join(",", playTypes)));
      }
    }
  }
}