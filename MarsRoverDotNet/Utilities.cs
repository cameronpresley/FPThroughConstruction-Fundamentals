using System;

namespace MarsRoverDotNet
{
    public static class FunctionExtensions
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> a, Func<T2, T3> b)
            => (c) => b(a(c));
    }

    public static class Utilities
    {
        public static Func<T1, T3> Compose<T1, T2, T3>(Func<T1, T2> a, Func<T2, T3> b)
            => a.Compose(b);
    }
}