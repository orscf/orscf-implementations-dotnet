using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace MedicalResearch.Workflow.Model {

  /// <summary>
  /// provides constants for specifying a (Re)SchedulingOffsetFixpoint
  /// </summary>
  public static class OffsetFixpoint {

    /// <summary>
    ///   SCHEDULING OF INDUCEMENTS: when the start of the parent Schedule (for the current cycle) was induced / 
    ///   RE-SCHEDULING OF CYLCLES: when the start of the last cycle was induced
    /// </summary>
    public const int InducementOfScheduleOrCycle = 0;

    /// <summary>
    ///   SCHEDULING OF INDUCEMENTS: when the direct predecessor procedure or subschedule (based on the 'Position') within the current schedule was induced / 
    ///   RE-SCHEDULING OF CYLCLES: when the last procedure or subschedule (based on the 'Position') of the previous cycle was induced.
    ///   *items of sub-schedules are not relevant - when addressing a sub-schedule as predecessor, then only its entry will be used
    ///   *this behaviour can be concretized via '(Re)SchedulingByEstimate'
    /// </summary>
    public const int InducementOfPredessessor = -1;

  }

}
