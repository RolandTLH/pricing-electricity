module Functions.FormatLoadCurves

open Models.Measures
open Models.LoadCurves

type ConvertLoadCurve = Input.LoadCurve -> Output.SettlementPeriod -> Output.LoadCurve

let convertToPricingLoadCurve (in_ldc:Input.LoadCurve) (ou_sep:Output.SettlementPeriod) :int =
    let pts = in_ldc.ListOfPoints
    match in_ldc.ListOfPoints, in_ldc.TypeOfTimeStamp, in_ldc.TypeOfIntervall with
    | Input.TypedPointsList.EnergyPoints x, Input.TimeStampTypes.StartTime, _ -> 0 // ERROR : Energy + startTime not possible (energy is accumulation of power during a period, cannot be set start time)
    | Input.TypedPointsList.EnergyPoints x, Input.TimeStampTypes.EndTime, Input.IntervallTypes.PointOfMeasure -> 1 // Convert to Power > ConvertToTimeStep on spe > Convert to Energy > Convert to start time
    | Input.TypedPointsList.EnergyPoints x, Input.TimeStampTypes.EndTime, Input.IntervallTypes.TimeStep tse -> 2 // Convert to Power > ConvertToTimeStep on spe > Convert to Energy > Convert to start time 
    | Input.TypedPointsList.PowerPoints x, Input.TimeStampTypes.EndTime, Input.IntervallTypes.PointOfMeasure -> 3 // Convert to TimeStep on spe > Convert to Energy > Convert to start time
    | Input.TypedPointsList.PowerPoints x, Input.TimeStampTypes.EndTime, Input.IntervallTypes.TimeStep tse -> 4 // Convert to TimeStep on spe > Convert to Energy > Convert to start time
    | Input.TypedPointsList.PowerPoints x, Input.TimeStampTypes.StartTime, Input.IntervallTypes.PointOfMeasure -> 5 // Convert to TimeStep on spe > Convert to Energy
    | Input.TypedPointsList.PowerPoints x, Input.TimeStampTypes.StartTime, Input.IntervallTypes.TimeStep tse -> 6 // Convert to TimeStep on spe > Convert to Energy

