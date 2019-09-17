using System;

namespace inningssimulator
{
  public class InningsConsoleReader
  {
    private static readonly log4net.ILog log =
       log4net.LogManager.GetLogger(typeof(InningsConsoleReader));

    private InningsPlayTypesCalculator inningsCalculator;
    private PlayTypesValidator playTypesValidator;

    public InningsConsoleReader()
    {
      inningsCalculator = new InningsPlayTypesCalculator();
      playTypesValidator = new PlayTypesValidator();
    }
    public void Launch()
    {
      while (true)
      {
        log.Info("\nEnter play types for the inning. Use ',' as delimter. Example 1b,2b,2b");
        String readLine = Console.ReadLine();
        try
        {
          string[] playTypes = readLine.Split(",");
          playTypesValidator.validate(playTypes);
          inningsCalculator.process(playTypes);
        }
        catch (Exception ex)
        {
          log.Error("Error processing the play types ", ex);
        }
      }
    }
  }
}