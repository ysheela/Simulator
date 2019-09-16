using System;
using System.Collections.Generic;

namespace sample
{
  public class InningsConstants
  {
    public static readonly string SINGLE = "1b";
    public static readonly string DOUBLE = "2b";
    public static readonly string TRIPLE = "3b";
    public static readonly string HOMERUN = "hr";
    public static readonly string OUT = "out";
    public static readonly string STRIKE = "k";
    public static readonly string ERROR = "e";
    public static readonly string WALK = "bb";
    public static readonly string HIT_BY_PITCH = "hbp";

    public static readonly string[] VALID_PLAYTYPES =
     { InningsConstants.OUT,
       InningsConstants.STRIKE,
       SINGLE,
       DOUBLE,
       TRIPLE,
       HOMERUN,
       ERROR,
       WALK,
       HIT_BY_PITCH };

  }
}