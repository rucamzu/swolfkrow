namespace Swolfkrow.Impl;

internal static partial class ActionExtensions
{
    public static Action<TArg2> BindFirst<TArg1, TArg2>(
        this Action<TArg1, TArg2> action, TArg1 arg1)
        => arg2 => action(arg1, arg2);

    public static Action<TArg2, TArg3> BindFirst<TArg1, TArg2, TArg3>(
        this Action<TArg1, TArg2, TArg3> action, TArg1 arg1)
        => (arg2, arg3) => action(arg1, arg2, arg3);

    public static Action<TArg3> BindFirst<TArg1, TArg2, TArg3>(
        this Action<TArg1, TArg2, TArg3> action, TArg1 arg1, TArg2 arg2)
        => arg3 => action(arg1, arg2, arg3);

    public static Action<TArg2, TArg3, TArg4> BindFirst<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg1 arg1)
        => (arg2, arg3, arg4) => action(arg1, arg2, arg3, arg4);

    public static Action<TArg3, TArg4> BindFirst<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg1 arg1, TArg2 arg2)
        => (arg3, arg4) => action(arg1, arg2, arg3, arg4);

    public static Action<TArg4> BindFirst<TArg1, TArg2, TArg3, TArg4>(
        this Action<TArg1, TArg2, TArg3, TArg4> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => arg4 => action(arg1, arg2, arg3, arg4);

    public static Action<TArg2, TArg3, TArg4, TArg5> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg1 arg1)
        => (arg2, arg3, arg4, arg5) => action(arg1, arg2, arg3, arg4, arg5);

    public static Action<TArg3, TArg4, TArg5> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg1 arg1, TArg2 arg2)
        => (arg3, arg4, arg5) => action(arg1, arg2, arg3, arg4, arg5);

    public static Action<TArg4, TArg5> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        => (arg4, arg5) => action(arg1, arg2, arg3, arg4, arg5);

    public static Action<TArg5> BindFirst<TArg1, TArg2, TArg3, TArg4, TArg5>(
        this Action<TArg1, TArg2, TArg3, TArg4, TArg5> action, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4)
        => arg5 => action(arg1, arg2, arg3, arg4, arg5);
}