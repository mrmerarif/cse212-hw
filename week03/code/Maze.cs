/// <summary> 
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    private void CheckBounds(int x, int y)
    {
        if (x < 1 || x > 6 || y < 1 || y > 6)
            throw new InvalidOperationException("Can't go that way!");
    }

    // TODO Problem 4 - ADD YOUR CODE HERE
    public void MoveLeft()
    {
        // FILL IN CODE
        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[0])
            throw new InvalidOperationException("Can't go that way!");

        var newX = _currX - 1;
        var newY = _currY;

        CheckBounds(newX, newY);

        _currX = newX;
    }

    public void MoveRight()
    {
        // FILL IN CODE
        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[1])
            throw new InvalidOperationException("Can't go that way!");

        var newX = _currX + 1;
        var newY = _currY;

        CheckBounds(newX, newY);

        _currX = newX;
    }

    public void MoveUp()
    {
        // FILL IN CODE
        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[2])
            throw new InvalidOperationException("Can't go that way!");

        var newX = _currX;
        var newY = _currY - 1;

        CheckBounds(newX, newY);

        _currY = newY;
    }

    public void MoveDown()
    {
        // FILL IN CODE
        var moves = _mazeMap[(_currX, _currY)];

        if (!moves[3])
            throw new InvalidOperationException("Can't go that way!");

        var newX = _currX;
        var newY = _currY + 1;

        CheckBounds(newX, newY);

        _currY = newY;
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}