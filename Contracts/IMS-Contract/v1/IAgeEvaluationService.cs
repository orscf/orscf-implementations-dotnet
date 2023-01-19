using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  public partial interface IAgeEvaluationService {

    /// <summary>
    /// Calculates the age (only the integer Year) of several persons for a given date.
    /// This is supporting the very common usecase to evaluate inclusion criteria for research studies where the date of birth is not present alongside of the medical data.
    /// It allows for minimalist access disclosing the date of birth information (as happening when unblinding).
    /// </summary>
    /// <param name="momentOfValuation"></param>
    /// <param name="pseudonymesToEvaluate"></param>
    /// <param name="ages">
    /// Returns an array with the same amount of fields as the given 'pseudonymesToEvaluate'-array.
    /// If it was not possible to evalute the age beacuse of not present data, then the corresponding array-field
    /// will contain a value of -1!
    /// </param>
    /// <remarks>
    /// NOTE: To improve security, is is recomended that any implementation of this method should 
    /// come with an programmatic protection against high-frequent, date-iterating calls
    /// (this will decrease chances to to discover too many exact birth-dates of the stored identities)!
    /// </remarks>
    void EvaluateAge(
      DateTime momentOfValuation,
      string[] pseudonymesToEvaluate,
      out int[] ages
    );

  }

}
