using System;
using System.Collections.Generic;
using inningssimulator;
using NUnit.Framework;

namespace inningssimulatortests
{
  [TestFixture]
  public class InningsPlayTypesCalculatorTest
  {
    [Test]
    public void shouldProcessSingle()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "1b" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "100");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessDouble()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "2b" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "010");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessTriple()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "3b" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "001");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessHomeRun()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "hr" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "000");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 1);
    }

    [Test]
    public void shouldProcessStrike()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "k" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "000");
      Assert.IsTrue(results.totalOuts == 1);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessWalk()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "bb" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "100");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessHitByPitch()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "hbp" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "100");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessOut()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "out" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "000");
      Assert.IsTrue(results.totalOuts == 1);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessScenario1()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "1b", "2b", "2b" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "010");
      Assert.IsTrue(results.totalOuts == 0);
      Assert.IsTrue(results.totalRuns == 2);
    }

    [Test]
    public void shouldProcessScenario2()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "3b", "hbp", "bb", "k", "k", "out" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "111");
      Assert.IsTrue(results.totalOuts == 3);
      Assert.IsTrue(results.totalRuns == 0);
    }

    [Test]
    public void shouldProcessScenario3()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "1b", "1b", "2b", "k", "k", "3b", "bb", "out" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "101");
      Assert.IsTrue(results.totalOuts == 3);
      Assert.IsTrue(results.totalRuns == 3);
    }

    [Test]
    public void shouldProcessScenario4()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "2b", "out", "out", "k" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "000");
      Assert.IsTrue(results.totalOuts == 3);
      Assert.IsTrue(results.totalRuns == 1);
    }

    [Test]
    public void shouldbeCaseInsensitive()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "2B", "OuT", "OUT", "K" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "000");
      Assert.IsTrue(results.totalOuts == 3);
      Assert.IsTrue(results.totalRuns == 1);
    }

    [Test]
    public void shouldIgnoreSpaces()
    {
      InningsPlayTypesCalculator calculator = new InningsPlayTypesCalculator();

      String[] playTypes = { "2B       ", "    OuT      ", "    OUT", "K" };
      InningsResults results = calculator.process(playTypes);

      Assert.IsTrue(results.bases == "000");
      Assert.IsTrue(results.totalOuts == 3);
      Assert.IsTrue(results.totalRuns == 1);
    }
  }
}