using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeLogic;


public static class Directions
{
    public static Point[] WithoutDiagonals { get; } =
    [
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0),
    ];

    public static Point[] WithDiagonals { get; } =
    [
        (0, 1),
        (1, 0),
        (0, -1),
        (-1, 0),
        (1, 1),
        (-1, 1),
        (1, -1),
        (-1, -1)
    ];

    public static Point3d[] WithoutDiagonals3d { get; } =
    [
        (1, 0, 0),
        (0, 1, 0),
        (0, 0, 1),
        (-1, 0, 0),
        (0, -1, 0),
        (0, 0, -1),
    ];
}
