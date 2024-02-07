module Array2DTest

open NUnit.Framework
open FsUnit

[<Test>]
let array2d_contains () =
    let arr = array2D [ [ 0; 1 ]; [ 2; 3 ] ]
    arr |> Array2D.contains 0 |> should equal true
    arr |> Array2D.contains 1 |> should equal true
    arr |> Array2D.contains 2 |> should equal true
    arr |> Array2D.contains 3 |> should equal true
    arr |> Array2D.contains 4 |> should equal false
