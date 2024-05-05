using System;

namespace FantasyBaseball.PlayerService.Utility
{
  /// <summary>Provides mathematical helper methods.</summary>
  public static class MathHelper
  {
    private static readonly double epsilon = 0.0001d;

    /// <summary>Divides two numbers. Returns zero instead of throwing error if divisor is zero.</summary>
    /// <param name="dividend">The number to be divided (dividend).</param>
    /// <param name="divisor">The number to divide by (divisor).</param>
    /// <returns>The result of the division.</returns>
    public static double Divide(double dividend, double divisor) => IsEqual(divisor, 0) || IsEqual(dividend, 0) ? 0 : dividend / divisor;

    /// <summary>Checks if two numbers are approximately equal.</summary>
    /// <param name="value1">The first number to compare.</param>
    /// <param name="value2">The second number to compare.</param>
    /// <returns>True if the numbers are approximately equal; otherwise, false.</returns>
    public static bool IsEqual(double value1, double value2) => Math.Abs(value1 - value2) < epsilon;
  }
}