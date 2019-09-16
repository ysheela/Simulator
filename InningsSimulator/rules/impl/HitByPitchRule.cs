
using System.Collections.Generic;
using System.Linq;

namespace sample.rules.impl
{
  public class HitByPitchRule : BaseRule
  {
    public HitByPitchRule() : base(InningsConstants.HIT_BY_PITCH)
    {
    }

    public override void process(List<IPlayerDetails> allPlayersOnField, bool isLast)
    {
      List<IPlayerDetails> allPlayers = allPlayersOnField.OrderBy(x => x.position).ToList();
      IPlayerDetails batter = allPlayersOnField.Find(x => x.position == 0);
      IPlayerDetails firstBasePlayer = allPlayersOnField.Find(x => x.position == 1);
      IPlayerDetails secondBasePlayer = allPlayersOnField.Find(x => x.position == 2);
      IPlayerDetails thirdBasePlayer = allPlayersOnField.Find(x => x.position == 3);

      batter.position += 1;
      if (firstBasePlayer != null)
      {
        firstBasePlayer.position += 1;
        if (secondBasePlayer != null)
        {
          secondBasePlayer.position += 1;
          if (thirdBasePlayer != null)
          {
            thirdBasePlayer.position += 1;
          }
        }
      }

    }
  }
}