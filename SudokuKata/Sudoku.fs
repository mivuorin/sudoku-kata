module Sudoku

/// Splices 2d array into sub grid
let private subGrid (grid: int[,]) r c =
    let startR = r - r % 3
    let startC = c - c % 3

    let endR = startR + 2
    let endC = startC + 2

    grid[startR..endR, startC..endC]


/// Checks if given number is valid in grid.
/// Number is valid if its unique in row, column and sub grid.
let private isValid (grid: int[,]) r c number =
    let row = grid[r, *]
    let inRow = row |> Array.contains number

    let column = grid[*, c]
    let inColumn = column |> Array.contains number

    let sub = subGrid grid r c
    let inSubGrid = sub |> Array2D.contains number

    not (inRow || inColumn || inSubGrid)

/// Solve given Sudoku
let solve (input: int[,]) =
    let rec solveRec (grid: int[,]) (row: int) (column: int) : int[,] * bool =
        if row >= Array2D.length1 grid then
            (grid, true)    
        else if column >= Array2D.length2 grid then
            solveRec grid (row + 1) 0
        else
            let cell = grid[row, column]

            if cell <> 0 then
                solveRec grid row (column + 1)
            else
                let rec checkNumber numbers grid =
                    match numbers with
                    | [] -> (grid, false)
                    | number :: rest ->
                        if isValid grid row column number then
                            grid[row, column] <- number
                            let grid, solved = solveRec grid 0 0
                
                            if solved then
                                (grid, true)
                            else
                                grid[row, column] <- 0
                                checkNumber rest grid
                        else
                            checkNumber rest grid
                
                checkNumber [ 1..9 ] grid

    let grid, _ = solveRec input 0 0
    grid
