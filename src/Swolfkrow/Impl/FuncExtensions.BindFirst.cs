namespace Swolfkrow.Impl;

internal static partial class FuncExtensions
{
    public static Func<TArg2, TResult> BindFirst<TArg1, TArg2, TResult>(
        this Func<TArg1, TArg2, TResult> func, TArg1 arg1)
        => arg2 => func(arg1, arg2);

    public static Func<TArg2, TArg3, TResult> BindFirst<TArg1, TArg2, TArg3, TResult>(
        this Func<TArg1, TArg2, TArg3, TResult> func, TArg1 arg1)
        => (arg2, arg3) => func(arg1, arg2, arg3);

    public static Func<TArg3, TResult> BindFirst<TArg1, TArg2, TArg3, TResult>(
        this Func<TArg1, TArg2, TArg3, TResult> func, TArg1 arg1, TArg2 arg2)
        => arg3 => func(arg1, arg2, arg3);

    public static Func<TArg2, TArg3, TArg4, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TResult> func, TArg1 arg1)
        => (arg2, arg3, arg4) => func(arg1, arg2, arg3, arg4);

    public static Func<TArg3, TArg4, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TResult> func, TArg1 arg1, TArg2 arg2)
        => (arg3, arg4) => func(arg1, arg2, arg3, arg4);

    public static Func<TArg4, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => arg4 => func(arg1, arg2, arg3, arg4);

    public static Func<TArg2, TArg3, TArg4, TArg5, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, TArg1 arg1)
        => (arg2, arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);

    public static Func<TArg3, TArg4, TArg5, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, TArg1 arg1, TArg2 arg2)
        => (arg3, arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);

    public static Func<TArg4, TArg5, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => (arg4, arg5) => func(arg1, arg2, arg3, arg4, arg5);

    public static Func<TArg5, TResult> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5, TResult>(
        this Func<TArg1, TArg2, TArg3, TArg4, TArg5, TResult> func, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => arg5 => func(arg1, arg2, arg3, arg4, arg5);
}