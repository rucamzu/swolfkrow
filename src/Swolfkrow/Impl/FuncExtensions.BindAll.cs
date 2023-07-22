namespace Swolfkrow.Impl;

internal static partial class FuncExtensions
{
    public static Func<TResult> BindAll<TArg1, TResult>(
        this Func<TArg1, TResult> func, TArg1 arg1)
        => () => func(arg1);

    public static Func<TResult> BindAll<TArg1, TArg2, TResult>(
        this Func<TArg1, TArg2, TResult> func, TArg1 arg1, TArg2 arg2)
        => () => func(arg1, arg2);

    public static Func<TResult> BindAll<TArg1, TArg2, TArg3, TResult>(
        this Func<TArg1, TArg2, TArg3, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => () => func(arg1, arg2, arg3);

    public static Func<TResult> BindAll<TArg1, TArg2, TArg3, TArg4, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => () => func(arg1, arg2, arg3, arg4);

    public static Func<TResult> BindAll<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => () => func(arg1, arg2, arg3, arg4, arg5);
}