# Innings Simulator


InningsSimulator is console Application that will print out the number of outs, runs scored, and bases occupied 
after a sequence of input plays from one inning (or partial inning) of a game are entered.

It supports the following play types:
out, k, 1b, 2b, 3b, hr, e, bb, hbp. 

Assumptions:

* Runners advance the same number of bases as the batter on hits (2 for double, etc). 
* Runners advance one base on an ‘e’ or ‘out’ play (except on final out).

# How to build and run the project
* Folder contains 
  * InningsSimulator
  * InningsSimulatorTests
* To build, .net cli should be installed
* Execute following commands to run the application in InningsSimulator directory.
  * dotnet build
  * dotnet run
* Execute following commands to run the tests in InningsSimulatorTests directory.
  * dotnet test
  
