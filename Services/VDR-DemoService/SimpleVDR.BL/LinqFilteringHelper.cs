//using MedicalResearch.VisitData.Model;
//using System;
//using System.Collections.Generic;
//using System.Data.AccessControl;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;

//namespace MedicalResearch.VisitData {

//  internal  class LinqFilteringHelper {

//    public static Expression FilterObjectToLinqExpression<TEntity>(object obectWithFilterProperties) {
//      Type entityType = typeof(TEntity);
//      Type filterObjectType = obectWithFilterProperties.GetType();

//      if (obectWithFilterProperties == null) {
//        return null;
//      }

//      //required for dynamic linq
//      //MethodInfo stringContainsMethod = typeof(System.String).GetMethod(nameof(String.Contains));
//      //MethodInfo stringToLowerMethod = typeof(System.String).GetMethod(nameof(String.ToLower));
//      ParameterExpression parameterExpr = Expression.Parameter(entityType, "p");

//      Expression objectFilterExpression = Expression.IsTrue(Expression.Constant(true, typeof(bool)));

//      var stringFieldFilterProps = filterObjectType.GetProperties().Where(
//        (p) => p.PropertyType.IsAssignableFrom(typeof(StringFieldFilter))
//      ).ToArray();
//      foreach (var stringFieldFilterProp in stringFieldFilterProps) {
//        var targetProperty = entityType.GetProperty(stringFieldFilterProp.Name);
//        StringFieldFilter filter = (StringFieldFilter)stringFieldFilterProp.GetValue(obectWithFilterProperties);
//        var filterExpr = CreateLinqExpressionForStringFieldFilter(filter, targetProperty, parameterExpr);
//        if (filterExpr != null) {
//          objectFilterExpression = Expression.AndAlso(objectFilterExpression, filterExpr);
//        }
//      }

//      var numericFieldFilterProps = filterObjectType.GetProperties().Where(
//        (p) => p.PropertyType == typeof(NumericFieldFilter)
//      ).ToArray();
//      foreach (var numericFieldFilterProp in numericFieldFilterProps) {
//        var targetProperty = entityType.GetProperty(numericFieldFilterProp.Name);
//        NumericFieldFilter filter = (NumericFieldFilter)numericFieldFilterProp.GetValue(obectWithFilterProperties);
//        var filterExpr = CreateLinqExpressionForNumericFieldFilter(filter, targetProperty, parameterExpr);
//        if (filterExpr != null) {
//          objectFilterExpression = Expression.AndAlso(objectFilterExpression, filterExpr);
//        }
//      }

//      var dateFieldFilterProps = filterObjectType.GetProperties().Where(
//        (p) => p.PropertyType == typeof(DateFieldFilter)
//      ).ToArray();
//      foreach (var dateFieldFilterProp in dateFieldFilterProps) {
//        var targetProperty = entityType.GetProperty(dateFieldFilterProp.Name);
//        DateFieldFilter filter = (DateFieldFilter)dateFieldFilterProp.GetValue(obectWithFilterProperties);
//        var filterExpr = CreateLinqExpressionForDateFieldFilter(filter, targetProperty, parameterExpr);
//        if (filterExpr != null) {
//          objectFilterExpression = Expression.AndAlso(objectFilterExpression, filterExpr);
//        }
//      }

//      var uidFieldFilterProps = filterObjectType.GetProperties().Where(
//        (p) => p.PropertyType == typeof(UidFieldFilter)
//      ).ToArray();
//      foreach (var uidFieldFilterProp in uidFieldFilterProps) {
//        var targetProperty = entityType.GetProperty(uidFieldFilterProp.Name);
//        UidFieldFilter filter = (UidFieldFilter)uidFieldFilterProp.GetValue(obectWithFilterProperties);
//        var filterExpr = CreateLinqExpressionForUidFieldFilter(filter, targetProperty, parameterExpr);
//        if (filterExpr != null) {
//          objectFilterExpression = Expression.AndAlso(objectFilterExpression, filterExpr);
//        }
//      }

//      var predicate = Expression.Lambda<Func<TEntity, bool>>(objectFilterExpression, parameterExpr);
//      //var compiledPredicate = predicate.Compile();

//      return predicate;
//    }

//    #region " String "

//    private static Expression CreateLinqExpressionForStringFieldFilter(StringFieldFilter filter, PropertyInfo targetProperty, ParameterExpression entityParameter) {

//      if (filter == null) {
//        return null;
//      }

//      Expression propertyFilterExpression = null;

//      //var targetProperty = entityParameter.Type.GetProperty(filter.Name);
//      MemberExpression propertyExpr = Expression.Property(entityParameter, targetProperty.Name);
//      //StringFieldFilter filterObje = (StringFieldFilter)stringFieldFilterProp.GetValue(obectWithFilterProperties);

//      bool includeAll = false;
//      if (filter.IncludedValues == null) {
//        includeAll = true;
//      }
//      else if (filter.IncludedValues.Length > 0) {
//        propertyFilterExpression = CreateLinqExpressionForStringValueCriterias(propertyExpr, filter.IncludedValues, filter.IgnoreCasing);
//      }

//      //include GIVEN
//      Expression orLinkedValuesExpressionToExclude = null;
//      if (filter.ExcludedValues != null) {
//        orLinkedValuesExpressionToExclude = CreateLinqExpressionForStringValueCriterias(propertyExpr, filter.ExcludedValues, filter.IgnoreCasing);
//        if (orLinkedValuesExpressionToExclude != null) {
//          if (includeAll) {
//            //propertyFilterExpression is also null in this case
//            propertyFilterExpression = Expression.Not(orLinkedValuesExpressionToExclude);
//          }
//          else if (propertyFilterExpression == null) {
//            //if there is nothing included, we dont need to exclude something
//          }
//          else {
//            propertyFilterExpression = Expression.AndAlso(
//              propertyFilterExpression,
//              Expression.Not(orLinkedValuesExpressionToExclude)
//            );
//          }
//        }
//      }

//      var constantStrNull = Expression.Constant(null, typeof(string));
//      if (filter is NullableStringFieldFilter) {
//        bool matchNull = ((NullableStringFieldFilter)filter).IncludeNull;

//        if (propertyFilterExpression != null) {
//          if (matchNull) {
//            var strNull = Expression.Equal(propertyExpr, constantStrNull);
//            propertyFilterExpression = Expression.OrElse(strNull, propertyFilterExpression);
//          }
//          else {
//            //just protect against evaulating previous expression against null values 
//            //because this would crash the string.contains method...
//            var strNotNull = Expression.NotEqual(propertyExpr, constantStrNull);
//            propertyFilterExpression = Expression.AndAlso(strNotNull, propertyFilterExpression);
//          }
//        }
//        else {
//          if (matchNull) {
//            propertyFilterExpression = Expression.Equal(propertyExpr, constantStrNull);
//          }
//          else {
//            propertyFilterExpression = Expression.NotEqual(propertyExpr, constantStrNull);
//          }
//        }
//      }
//      else if (propertyFilterExpression != null) {
//        propertyFilterExpression = Expression.IsTrue(Expression.Constant(true, typeof(bool)));
//      }

//      if (filter.Negate) {
//        propertyFilterExpression = Expression.Not(propertyFilterExpression);
//      }

//      return propertyFilterExpression;
//    }

//    private static Expression CreateLinqExpressionForStringValueCriterias(Expression propertyExpr, StringValueCriteria[] criterias, bool ignoreCasing) {

//      MethodInfo stringContainsMethod = typeof(System.String).GetMethod(nameof(String.Contains));
//      MethodInfo stringToLowerMethod = typeof(System.String).GetMethod(nameof(String.ToLower));

//      Expression filterExpression = null;
//      foreach (StringValueCriteria criteria in criterias) {
//        Expression valueIncludeExpression = null;
//        ConstantExpression constantValueExpr;
//        Expression targetExpr;
//        if (ignoreCasing) {
//          constantValueExpr = Expression.Constant(criteria.Value.ToLower(), typeof(string));
//          targetExpr = Expression.Call(propertyExpr, stringToLowerMethod);
//        }
//        else {
//          constantValueExpr = Expression.Constant(criteria.Value, typeof(string));
//          targetExpr = propertyExpr;
//        }

//        if (criteria.MatchSubstring) {
//          valueIncludeExpression = Expression.Call(targetExpr, stringContainsMethod, constantValueExpr);
//        }
//        else {
//          valueIncludeExpression = Expression.Equal(targetExpr, constantValueExpr);
//        }

//        //APPEND to the include list
//        if (filterExpression == null) {
//          filterExpression = valueIncludeExpression;
//        }
//        else {
//          filterExpression = Expression.OrElse(filterExpression, valueIncludeExpression);
//        }

//      }

//      return filterExpression;
//    }

//    #endregion

//    #region " Number "

//    private static Expression CreateLinqExpressionForNumericFieldFilter(NumericFieldFilter filter, PropertyInfo targetProperty, ParameterExpression entityParameter) {

//      if (filter == null) {
//        return null;
//      }

//      Expression propertyFilterExpression = null;
//      MemberExpression propertyExpr = Expression.Property(entityParameter, targetProperty.Name);
//      MemberExpression propertyExprForValueEval = propertyExpr;
//      if (filter is NullableNumericFieldFilter) {
//        propertyExprForValueEval = Expression.Property(propertyExpr, nameof(Nullable<int>.Value));
//      }

//      TYPEN!!!!



//      bool includeAll = false;
//      if (filter.IncludedValues == null) {
//        includeAll = true;
//      }
//      else if (filter.IncludedValues.Length > 0) {
//        propertyFilterExpression = CreateLinqExpressionForNumericValueCriterias(propertyExprForValueEval, filter.IncludedValues);
//      }

//      //include GIVEN
//      Expression orLinkedValuesExpressionToExclude = null;
//      if (filter.ExcludedValues != null) {
//        orLinkedValuesExpressionToExclude = CreateLinqExpressionForNumericValueCriterias(propertyExprForValueEval, filter.ExcludedValues);
//        if (orLinkedValuesExpressionToExclude != null) {
//          if (includeAll) {
//            //propertyFilterExpression is also null in this case
//            propertyFilterExpression = Expression.Not(orLinkedValuesExpressionToExclude);
//          }
//          else if (propertyFilterExpression == null) {
//            //if there is nothing included, we dont need to exclude something
//          }
//          else {
//            propertyFilterExpression = Expression.AndAlso(
//              propertyFilterExpression,
//              Expression.Not(orLinkedValuesExpressionToExclude)
//            );
//          }
//        }
//      }

//      var constantIntNull = Expression.Constant(null, typeof(Nullable<int>));
//      if (filter is NullableNumericFieldFilter) {
//        bool matchNull = ((NullableNumericFieldFilter)filter).IncludeNull;

//        if (propertyFilterExpression != null) {
//          if (matchNull) {
//            var intNull = Expression.Equal(propertyExpr, constantIntNull);
//            propertyFilterExpression = Expression.OrElse(intNull, propertyFilterExpression);
//          }
//          else {
//            //just protect against evaulating previous expression against null values 
//            //because this would crash the string.contains method...
//            var intNotNull = Expression.NotEqual(propertyExpr, constantIntNull);
//            propertyFilterExpression = Expression.AndAlso(intNotNull, propertyFilterExpression);
//          }
//        }
//        else {
//          if (matchNull) {
//            propertyFilterExpression = Expression.Equal(propertyExpr, constantIntNull);
//          }
//          else {
//            propertyFilterExpression = Expression.NotEqual(propertyExpr, constantIntNull);
//          }
//        }
//      }
//      else if (propertyFilterExpression != null) {
//        propertyFilterExpression = Expression.IsTrue(Expression.Constant(true, typeof(bool)));
//      }

//      if (filter.Negate) {
//        propertyFilterExpression = Expression.Not(propertyFilterExpression);
//      }

//      return propertyFilterExpression;
//    }

//    private static Expression CreateLinqExpressionForNumericValueCriterias(Expression propertyExpr, NumericValueCriteria[] criterias) {

//      Expression filterExpression = null;
//      foreach (NumericValueCriteria criteria in criterias) {
//        Expression valueIncludeExpression = null;
//        ConstantExpression constantValueExpr;

//        constantValueExpr = Expression.Constant(criteria.Value, typeof(int));
//        //TODO ex sit nicht immer int!!!

//        if (criteria.MatchingBehaviour == RangeMatchingBehaviour.Less) {
//          valueIncludeExpression = Expression.LessThan(propertyExpr, constantValueExpr);
//        }
//        else if (criteria.MatchingBehaviour == RangeMatchingBehaviour.LessOrEqual) {
//          valueIncludeExpression = Expression.LessThanOrEqual(propertyExpr, constantValueExpr);
//        }
//        else if (criteria.MatchingBehaviour == RangeMatchingBehaviour.More) {
//          valueIncludeExpression = Expression.GreaterThan(propertyExpr, constantValueExpr);
//        }
//        else if (criteria.MatchingBehaviour == RangeMatchingBehaviour.MoreOrEqual) {
//          valueIncludeExpression = Expression.GreaterThanOrEqual(propertyExpr, constantValueExpr);
//        }
//        else { //if (criteria.MatchingBehaviour == RangeMatchingBehaviour.Equal) {
//          valueIncludeExpression = Expression.Equal(propertyExpr, constantValueExpr);
//        }

//        //APPEND to the include list
//        if (filterExpression == null) {
//          filterExpression = valueIncludeExpression;
//        }
//        else {
//          filterExpression = Expression.OrElse(filterExpression, valueIncludeExpression);
//        }

//      }

//      return filterExpression;
//    }

//    #endregion

//    #region " Date "

//    private static Expression CreateLinqExpressionForDateFieldFilter(DateFieldFilter filter, PropertyInfo targetProperty, ParameterExpression entityParameter) {

//      if (filter == null) {
//        return null;
//      }

//      Expression propertyFilterExpression = null;
//      MemberExpression propertyExpr = Expression.Property(entityParameter, targetProperty.Name);
//      MemberExpression propertyExprForValueEval = propertyExpr;
//      if (filter is NullableDateFieldFilter) {
//        propertyExprForValueEval = Expression.Property(propertyExpr, nameof(Nullable<DateTime>.Value));
//      }

//      bool includeAll = false;
//      if (filter.IncludedValues == null) {
//        includeAll = true;
//      }
//      else if (filter.IncludedValues.Length > 0) {
//        propertyFilterExpression = CreateLinqExpressionForDateValueCriterias(propertyExprForValueEval, filter.IncludedValues);
//      }

//      //include GIVEN
//      Expression orLinkedValuesExpressionToExclude = null;
//      if (filter.ExcludedValues != null) {
//        orLinkedValuesExpressionToExclude = CreateLinqExpressionForDateValueCriterias(propertyExprForValueEval, filter.ExcludedValues);
//        if (orLinkedValuesExpressionToExclude != null) {
//          if (includeAll) {
//            //propertyFilterExpression is also null in this case
//            propertyFilterExpression = Expression.Not(orLinkedValuesExpressionToExclude);
//          }
//          else if (propertyFilterExpression == null) {
//            //if there is nothing included, we dont need to exclude something
//          }
//          else {
//            propertyFilterExpression = Expression.AndAlso(
//              propertyFilterExpression,
//              Expression.Not(orLinkedValuesExpressionToExclude)
//            );
//          }
//        }
//      }

//      var constantDateTimeNull = Expression.Constant(null, typeof(Nullable<DateTime>));
//      if (filter is NullableDateFieldFilter) {
//        bool matchNull = ((NullableDateFieldFilter)filter).IncludeNull;

//        if (propertyFilterExpression != null) {
//          if (matchNull) {
//            var dateTimeNull = Expression.Equal(propertyExpr, constantDateTimeNull);
//            propertyFilterExpression = Expression.OrElse(dateTimeNull, propertyFilterExpression);
//          }
//          else {
//            //just protect against evaulating previous expression against null values 
//            //because this would crash the string.contains method...
//            var dateTimeNotNull = Expression.NotEqual(propertyExpr, constantDateTimeNull);
//            propertyFilterExpression = Expression.AndAlso(dateTimeNotNull, propertyFilterExpression);
//          }
//        }
//        else {
//          if (matchNull) {
//            propertyFilterExpression = Expression.Equal(propertyExpr, constantDateTimeNull);
//          }
//          else {
//            propertyFilterExpression = Expression.NotEqual(propertyExpr, constantDateTimeNull);
//          }
//        }
//      }
//      else if (propertyFilterExpression != null) {
//        propertyFilterExpression = Expression.IsTrue(Expression.Constant(true, typeof(bool)));
//      }

//      if (filter.Negate) {
//        propertyFilterExpression = Expression.Not(propertyFilterExpression);
//      }

//      return propertyFilterExpression;
//    }

//    private static Expression CreateLinqExpressionForDateValueCriterias(Expression propertyExpr, DateValueCriteria[] criterias) {

//      Expression filterExpression = null;
//      foreach (DateValueCriteria criteria in criterias) {
//        Expression valueIncludeExpression = null;
//        ConstantExpression constantValueExpr;

//        constantValueExpr = Expression.Constant(criteria.Value, typeof(DateTime));
//        //TODO ex sit nicht immer int!!!

//        if (criteria.MatchingBehaviour == RangeMatchingBehaviour.Less) {
//          valueIncludeExpression = Expression.LessThan(propertyExpr, constantValueExpr);
//        }
//        else if (criteria.MatchingBehaviour == RangeMatchingBehaviour.LessOrEqual) {
//          valueIncludeExpression = Expression.LessThanOrEqual(propertyExpr, constantValueExpr);
//        }
//        else if (criteria.MatchingBehaviour == RangeMatchingBehaviour.More) {
//          valueIncludeExpression = Expression.GreaterThan(propertyExpr, constantValueExpr);
//        }
//        else if (criteria.MatchingBehaviour == RangeMatchingBehaviour.MoreOrEqual) {
//          valueIncludeExpression = Expression.GreaterThanOrEqual(propertyExpr, constantValueExpr);
//        }
//        else { //if (criteria.MatchingBehaviour == RangeMatchingBehaviour.Equal) {
//          valueIncludeExpression = Expression.Equal(propertyExpr, constantValueExpr);
//        }

//        //APPEND to the include list
//        if (filterExpression == null) {
//          filterExpression = valueIncludeExpression;
//        }
//        else {
//          filterExpression = Expression.OrElse(filterExpression, valueIncludeExpression);
//        }

//      }

//      return filterExpression;
//    }

//    #endregion

//    #region " Uid "

//    private static Expression CreateLinqExpressionForUidFieldFilter(UidFieldFilter filter, PropertyInfo targetProperty, ParameterExpression entityParameter) {

//      if (filter == null) {
//        return null;
//      }

//      Expression propertyFilterExpression = null;
//      MemberExpression propertyExpr = Expression.Property(entityParameter, targetProperty.Name);
//      MemberExpression propertyExprForValueEval = propertyExpr;
//      if (filter is NullableUidFieldFilter) {
//        propertyExprForValueEval = Expression.Property(propertyExpr, nameof(Nullable<Guid>.Value));
//      }

//      bool includeAll = false;
//      if (filter.IncludedValues == null) {
//        includeAll = true;
//      }
//      else if (filter.IncludedValues.Length > 0) {
//        propertyFilterExpression = CreateLinqExpressionForUidValueCriterias(propertyExprForValueEval, filter.IncludedValues);
//      }

//      //include GIVEN
//      Expression orLinkedValuesExpressionToExclude = null;
//      if (filter.ExcludedValues != null) {
//        orLinkedValuesExpressionToExclude = CreateLinqExpressionForUidValueCriterias(propertyExprForValueEval, filter.ExcludedValues);
//        if (orLinkedValuesExpressionToExclude != null) {
//          if (includeAll) {
//            //propertyFilterExpression is also null in this case
//            propertyFilterExpression = Expression.Not(orLinkedValuesExpressionToExclude);
//          }
//          else if (propertyFilterExpression == null) {
//            //if there is nothing included, we dont need to exclude something
//          }
//          else {
//            propertyFilterExpression = Expression.AndAlso(
//              propertyFilterExpression,
//              Expression.Not(orLinkedValuesExpressionToExclude)
//            );
//          }
//        }
//      }

//      var constantGuidNull = Expression.Constant(null, typeof(Nullable<Guid>));
//      if (filter is NullableUidFieldFilter) {
//        bool matchNull = ((NullableUidFieldFilter)filter).IncludeNull;

//        if (propertyFilterExpression != null) {
//          if (matchNull) {
//            var guidNull = Expression.Equal(propertyExpr, constantGuidNull);
//            propertyFilterExpression = Expression.OrElse(guidNull, propertyFilterExpression);
//          }
//          else {
//            //just protect against evaulating previous expression against null values 
//            //because this would crash the string.contains method...
//            var guidNotNull = Expression.NotEqual(propertyExpr, constantGuidNull);
//            propertyFilterExpression = Expression.AndAlso(guidNotNull, propertyFilterExpression);
//          }
//        }
//        else {
//          if (matchNull) {
//            propertyFilterExpression = Expression.Equal(propertyExpr, constantGuidNull);
//          }
//          else {
//            propertyFilterExpression = Expression.NotEqual(propertyExpr, constantGuidNull);
//          }
//        }
//      }
//      else if (propertyFilterExpression != null) {
//        propertyFilterExpression = Expression.IsTrue(Expression.Constant(true, typeof(bool)));
//      }

//      if (filter.Negate) {
//        propertyFilterExpression = Expression.Not(propertyFilterExpression);
//      }

//      return propertyFilterExpression;
//    }

//    private static Expression CreateLinqExpressionForUidValueCriterias(Expression propertyExpr, UidValueCriteria[] criterias) {

//      Expression filterExpression = null;
//      foreach (UidValueCriteria criteria in criterias) {

//        Expression valueIncludeExpression = null;
//        ConstantExpression constantValueExpr;

//        constantValueExpr = Expression.Constant(criteria.Value, typeof(Guid));

//        valueIncludeExpression = Expression.Equal(propertyExpr, constantValueExpr);
        
//        //APPEND to the include list
//        if (filterExpression == null) {
//          filterExpression = valueIncludeExpression;
//        }
//        else {
//          filterExpression = Expression.OrElse(filterExpression, valueIncludeExpression);
//        }

//      }

//      return filterExpression;
//    }

//    #endregion

//  }

//}
