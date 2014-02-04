using System;

using NUnit.Framework;

namespace KyivBeerNCode
{
	public class ThenAttribute : TestAttribute
	{}

	public class ContextAttribute : TestFixtureAttribute
	{}

	public class ExceptionalAttribute : Attribute
	{}

	public abstract class Specification
	{
		Type expectedException;
		Exception actualException;

		[TestFixtureSetUp]
		public virtual void Setup()
		{
			Given();
			TryWhen();
		}

		void TryWhen()
		{
			bool rethrow = false;

			try
			{
				if (IsExceptional() && expectedException == null)
				{
					string message = string.Format("Exceptional context is missing type of expected exception");
					rethrow = true;
					Assert.Fail(message);
				}

				When();

				if (IsExceptional())
				{
					string message = string.Format("Expected exception {0} has not been thrown", expectedException.FullName);
					rethrow = true;
					Assert.Fail(message);
				}
			}
			catch (Exception ex)
			{
				if (expectedException == null || rethrow)
					throw;

				if (ex.GetType() != expectedException)
				{
					string message = string.Format("Wrong type of exception has been thrown. Expected: {0}, Actual: {1} - {2}", expectedException.FullName, ex.GetType().FullName, ex.Message);
					Assert.Fail(message);
				}

				actualException = ex;
			}
		}

		protected void Expect<TException>() where TException : Exception
		{
			if (!IsExceptional())
				throw new InvalidOperationException("Please mark context as Exceptional");

			expectedException = typeof(TException);
		}

		bool IsExceptional()
		{
			return GetType().GetCustomAttributes(typeof(ExceptionalAttribute), true).Length != 0;
		}

		protected TException Thrown<TException>() where TException : Exception
		{
			return (TException)actualException;
		}

		protected virtual void Given()
		{
		}

		protected virtual void When()
		{
		}
	}
}
