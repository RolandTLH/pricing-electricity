module Models.Measures

(*
    Defines here the different types of measures used in the models
*)

[<Measure>] type Euro // Euros
[<Measure>] type W // Measure of power in Watt
[<Measure>] type kW // Measure of power in KiloWatt
[<Measure>] type MW // Measure of power in MegaWatt
[<Measure>] type Minutes // Measure of duration in minutes
[<Measure>] type Hours // Measure of duration in hour
[<Measure>] type Wh = W*Hours // Measure of energy in Watthours
[<Measure>] type kWh = kW*Hours// Measure of energy in KiloWatthours
[<Measure>] type MWh = MW*Hours// Measure of energy in MegaWatthours

// conversions between units
let wattPerKiloWatt : float<W/kW> = 1000.0<W/kW>
let WtokW (x:float<W>) = x/wattPerKiloWatt
let kWtoW (x:float<kW>) = x*wattPerKiloWatt

let kWperMegaWatt : float<kW/MW> = 1000.0<kW/MW>
let kWtoMW (x:float<kW>) = x/kWperMegaWatt
let MWtokW (x:float<MW>) = x*kWperMegaWatt

let kilowatthoursPerMegaWatthours : float<kWh/MWh> = 1000.0<kWh/MWh>
let kWhtoMWh (x:float<kWh>) = x/kilowatthoursPerMegaWatthours
let MWhtokWh (x:float<MWh>) = x*kilowatthoursPerMegaWatthours

let watthoursPerKiloWattHours :float<Wh/kWh> = 1000.0<Wh/kWh>
let WhtokWh (x:float<Wh>) = x/watthoursPerKiloWattHours
let kWhtoWh (x:float<kWh>) = x*watthoursPerKiloWattHours

let minutesPerhour : float<Minutes/Hours> = 60.0<Minutes/Hours>
let minToH (x:float<Minutes>) = x/minutesPerhour
let Htomin (x:float<Hours>) = x*minutesPerhour

// units
let unitEuro :float<Euro> = 1.0<Euro>
let unitWatt :float<W> = 1.0<W>
let unitKiloWatt :float<kW> = 1.0<kW>
let unitMegaWatt :float<MW> = 1.0<MW>
let unitMinutes :float<Minutes> = 1.0<Minutes>
let unitHours :float<Hours> = 1.0<Hours>
let unitWattHour :float<Wh> = 1.0<Wh>
let unitKiloWattHour :float<kWh> = 1.0<kWh>
let unitMegaWattHour :float<MWh> = 1.0<MWh>

// conversions from floats
let toEuro (x:float) = x*unitEuro
let toWatt (x:float) = x*unitWatt
let toKiloWatt (x:float) = x*unitKiloWatt
let toMegaWatt (x:float) = x*unitMegaWatt
let toMinutes (x:float) = x*unitMinutes
let toHours (x:float) = x*unitHours
let toWattHour (x:float) = x*unitWattHour
let toKiloWattHour (x:float) = x*unitKiloWattHour
let toMetgaWattHour (x:float) = x*unitMegaWattHour