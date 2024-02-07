module SudokuTest

open NUnit.Framework
open FsUnit

let unsolved =
    array2D
        [ [ 5; 6; 0; 0; 8; 0; 0; 0; 2 ]
          [ 0; 0; 2; 0; 0; 9; 0; 0; 0 ]
          [ 0; 9; 0; 0; 0; 0; 0; 4; 0 ]
          [ 8; 0; 0; 0; 0; 0; 4; 0; 1 ]
          [ 1; 0; 0; 0; 0; 0; 0; 6; 0 ]
          [ 0; 4; 6; 9; 0; 0; 0; 3; 8 ]
          [ 0; 0; 3; 0; 1; 0; 6; 0; 0 ]
          [ 0; 0; 1; 5; 9; 0; 0; 8; 0 ]
          [ 0; 8; 5; 4; 0; 0; 1; 0; 9 ] ]

let solved =
    array2D
        [ [ 5; 6; 4; 7; 8; 3; 9; 1; 2 ]
          [ 3; 1; 2; 6; 4; 9; 8; 7; 5 ]
          [ 7; 9; 8; 1; 2; 5; 3; 4; 6 ]
          [ 8; 5; 7; 3; 6; 2; 4; 9; 1 ]
          [ 1; 3; 9; 8; 5; 4; 2; 6; 7 ]
          [ 2; 4; 6; 9; 7; 1; 5; 3; 8 ]
          [ 9; 7; 3; 2; 1; 8; 6; 5; 4 ]
          [ 4; 2; 1; 5; 9; 6; 7; 8; 3 ]
          [ 6; 8; 5; 4; 3; 7; 1; 2; 9 ] ]

/// FsUnit equal does not handle 2d arrays
let equalCollection expected = Is.EqualTo(expected).AsCollection

[<Test>]
let solve_full_sudoku () =
    Sudoku.solve unsolved |> should equalCollection solved

[<Test>]
let vertical_rule () =
    let input = Array2D.copy solved
    input[0, *] <- [| 0; 0; 0; 0; 0; 0; 0; 0; 0 |]

    let actual = Sudoku.solve input
    actual |> should equalCollection solved

[<Test>]
let horizontal_rule () =
    let input = Array2D.copy solved
    input[*, 0] <- [| 0; 0; 0; 0; 0; 0; 0; 0; 0 |]

    let actual = Sudoku.solve input
    actual |> should equalCollection solved