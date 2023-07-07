namespace Swolfkrow.Impl;

internal static partial class ActionExtensions
{
    public static Action<TArg1> BindLast<TArg1, TArg2>(
        this Action<TArg1, TArg2> action, TArg2 arg2)
        => arg1 => action(arg1, arg2);

    public static Action<TArg1, TArg2> BindLast<TArg1, TArg2, TArg3>(
        this Action<TArg1, TArg2, TArg3> action, TArg3 arg3)
        => (arg1, arg2) => action(arg1, arg2, arg3);

    public static Action<TArg1> BindLast<TArg1, TArg2, TArg3>(
        this Action<TArg1, TArg2, TArg3> action, TArg2 arg2, TArg3 arg3)
        => arg1 => action(arg1, arg2, arg3);

    public static Action<TArg1, TArg2, TArg3> BindLast<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg4 arg4)
        => (arg1, arg2, arg3) => action(arg1, arg2, arg3, arg4);

    public static Action<TArg1, TArg2> BindLast<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg3 arg3, TArg4 arg4)
        => (arg1, arg2) => action(arg1, arg2, arg3, arg4);

    public static Action<TArg1> BindLast<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => arg1 => action(arg1, arg2, arg3, arg4);

    public static Action<TArg1, TArg2, TArg3, TArg4> BindLast<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg5 arg5)
        => (arg1, arg2, arg3, arg4) => action(arg1, arg2, arg3, arg4, arg5);

    public static Action<TArg1, TArg2, TArg3> BindLast<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg4 arg4, TArg5 arg5)
        => (arg1, arg2, arg3) => action(arg1, arg2, arg3, arg4, arg5);

    public static Action<TArg1, TArg2> BindLast<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => (arg1, arg2) => action(arg1, arg2, arg3, arg4, arg5);

    public static Action<TArg1> BindLast<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg2 arg2, TArg3 arg3, TArg4 arg4, TArg5 arg5)
        => arg1 => action(arg1, arg2, arg3, arg4, arg5);
}