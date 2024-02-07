module Array2D

/// Checks if given 2d array contains value
let contains (value: 'a) (array: 'a[,]) =
    let rec iterate row col =
        if row >= Array2D.length1 array then
            false
        else if col >= Array2D.length2 array then
            iterate (row + 1) 0
        else if value = array[col, row] then
            true
        else
            iterate row (col + 1)

    iterate 0 0
