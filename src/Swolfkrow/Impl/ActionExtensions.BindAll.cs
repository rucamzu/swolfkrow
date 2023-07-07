namespace Swolfkrow.Impl;

internal static partial class ActionExtensions
{
    public static Action BindAll<TArg1>(
        this Action<TArg1> action, TArg1 arg1)
        => () => action(arg1);

    public static Action BindAll<TArg1, TArg2>(
        this Action<TArg1, TArg2> action, TArg1 arg1, TArg2 arg2)
        => () => action(arg1, arg2);

    public static Action BindAll<TArg1, TArg2, TArg3>(
        this Action<TArg1, TArg2, TArg3> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => () => action(arg1, arg2, arg3);

    public static Action BindAll<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => () => action(arg1, arg2, arg3, arg4);

    public static Action BindAll<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => () => action(arg1, arg2, arg3, arg4, arg5);
}