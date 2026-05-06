public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Create a new array of doubles with size equal to 'length'.
        // 2. Loop from i = 0 up to i < length.
        // 3. For each index i, compute the (i + 1)-th multiple of 'number':
        // value = number * (i + 1).
        // 4. Store that value in the array at index i.
        // 5. After the loop, return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;

       
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // PLAN:
        // 1. Find the index where the list should be split for rotation.
        //    Rotating right by 'amount' that means the last 'amount' items move to the front.
        //    So the split index is data.Count - amount.
        // 2. Use GetRange to get the right slice: the last 'amount' elements.
        // 3. Use GetRange to get the left slice: the elements before that split index.
        // 4. Clear the original list.
        // 5. Add the right slice first (these go to the front).
        // 6. Add the left slice after that.
        // 7. The original list 'data' is now rotated in place.

        int splitIndex = data.Count - amount;

        List<int> rightSlice = data.GetRange(splitIndex, amount);
        List<int> leftSlice = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightSlice);
        data.AddRange(leftSlice);
    }
}
