module Models.LoadCurves

open System
open Models.Measures

module Input =

(*
    We describe here the models of load curve that can be sent to the pricer
    Load curves are defined considering
    - the type of measure (energy or power)
    - the type of time stamp (start time or end time)
    - the type of intervall (timestep or point of measure)
*)

    type MeasureTypes =
        | WattHour
        | KiloWattHour
        | MegaWattHour
        | Watt
        | KiloWatt
        | MegaWatt

    type TimeStampTypes = // Defines how the timestamps of the load curve should be used 
        | StartTime // defines the energy or the power after the timestamp and on the time step that defines the point
        | EndTime // defines the energy or the power measured before the timestamp and on the time step that defines the point

    type IntervallTypes = // Defines how the value of a given point should be used
        | PointOfMeasure // the value is valable between two successive time stamp
        | TimeStep of float // the value is valable on a fixed time step before (endtime) or after (startime) the timestamp

    type TypedPointsList = 
        | EnergyPoints of list<DateTime*float<MWh>>
        | PowerPoints of list<DateTime*float<MW>> 

    type PointsList = list<DateTime*float>

    type LoadCurve = {
        ListOfPoints:TypedPointsList
        TypeOfTimeStamp:TimeStampTypes
        TypeOfIntervall:IntervallTypes
    }

    let createLoadCurve (LoP:PointsList,
        ToM:MeasureTypes,
        ToTs:TimeStampTypes,
        ToI:IntervallTypes) =
        match ToM with
        | WattHour -> 
            LoP 
            |> List.map (fun x -> (fst x, snd x |> toWattHour |> WhtokWh |> kWhtoMWh )) 
            |> TypedPointsList.EnergyPoints
        | KiloWattHour -> 
            LoP 
            |> List.map (fun x -> (fst x, snd x |> toKiloWattHour |> kWhtoMWh )) 
            |> TypedPointsList.EnergyPoints
        | MegaWattHour -> 
            LoP 
            |> List.map (fun x -> (fst x, snd x |> toMetgaWattHour )) 
            |> TypedPointsList.EnergyPoints

module Output =

(*
    We describe here the loadcurve output that will be consumed by the pricer.
    Output Loadcurve will be of
    - Energy Measure
    - Timestep with the provided settlement period
*)

    type SettlementPeriod = 
        | FiveMinutes
        | TenMinutes
        | FifteenMinutes
        | ThirtyMinutes
        | SixtyMinutes

    let convertSettlementPeriodInMinutes = function
        | FiveMinutes -> 5.0<Minutes>
        | TenMinutes -> 10.0<Minutes>
        | FifteenMinutes -> 15.0<Minutes>
        | ThirtyMinutes -> 30.0<Minutes>
        | SixtyMinutes -> 60.0<Minutes>

    type PointsList = list<DateTime*float<MWh>>

    type LoadCurve = {
        ListOfPoints:PointsList
        Settlement:SettlementPeriod
    }