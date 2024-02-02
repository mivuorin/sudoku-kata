module SudokuKata

open NUnit.Framework
open FsUnit

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    1 |> should equal 1
