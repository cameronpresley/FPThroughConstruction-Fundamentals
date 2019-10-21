type Func<T, U> = (x: T) => U;

const compose = <T1, T2, T3>(a: Func<T1, T2>, b: Func<T2, T3>) => ((x: T1) => b(a(x))) as Func<T1, T3>;

export {Func, compose};
