[<Measure>] type Sec

let constSec :float<Sec> = 1.0<Sec>
let duree = 12.0
let dureeSec = duree*constSec

type TestDiscrimated =
    | TOne of float
    | TTwo of int

let a = 2.0
let b = TOne a