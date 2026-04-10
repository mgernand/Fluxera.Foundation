namespace Fluxera.Enumeration
{
	using System;
	using System.Runtime.CompilerServices;
	using Fluxera.Guards;
	using JetBrains.Annotations;

	internal static class GuardExtensions
	{
		public static T UnsupportedValueType<T>(this IGuard guard, T argument, [InvokerParameterName] [CallerArgumentExpression(nameof(argument))] string parameterName = null, string message = null)
		{
			argument = Guard.Against.Null(argument, parameterName);

			Type valueType = argument.GetType();

			if (valueType != typeof(byte) &&
				valueType != typeof(short) &&
				valueType != typeof(int) &&
				valueType != typeof(long))
			{
				throw new ArgumentException(message ?? $"Value cannot be an unsupported type ({valueType}).", parameterName);
			}

			return argument;
		}
	}
}
