using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mjollnir
{
	[TestClass]
	public class ThrowTest
	{
		[TestMethod]
		public void IfTest()
		{
			var factory = ((Func<Exception>)(() => new ApplicationException()));

			AssertEx.Throws<ArgumentNullException>(() => Throw.If(false, default(Func<Exception>))).ParamName.Is("factory");
			AssertEx.Throws<ArgumentNullException>(() => Throw.If(true, default(Func<Exception>))).ParamName.Is("factory");
			AssertEx.DoesNotThrow(() => Throw.If(false, factory));
			AssertEx.Throws<ApplicationException>(() => Throw.If(true, factory));
		}

		[TestMethod]
		public void IfNullTest()
		{
			var param = "param";
			var paramName = "paramName";
			var innerException = new ApplicationException();
			var userMessage = "userMessage";

			{
				AssertEx.DoesNotThrow(() => Throw.IfNull(param));
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string)));
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, default(string))).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), default(string))).ParamName.Is("paramName");

				AssertEx.DoesNotThrow(() => Throw.IfNull(param, paramName));
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), paramName)).ParamName.Is(paramName);
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, default(string), default(Exception))).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), default(string), default(Exception))).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, userMessage, default(Exception))).ParamName.Is("innerException");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), userMessage, default(Exception))).ParamName.Is("innerException");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, default(string), innerException)).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), default(string), innerException)).ParamName.Is("userMessage");

				AssertEx.DoesNotThrow(() => Throw.IfNull(param, userMessage, innerException));
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), userMessage, innerException)).Is(_ => _.Message == userMessage && _.InnerException == innerException);
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, default(string), default(string))).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), default(string), default(string))).ParamName.Is("paramName");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, paramName, default(string))).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), paramName, default(string))).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(param, default(string), userMessage)).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), default(string), userMessage)).ParamName.Is("paramName");

				AssertEx.DoesNotThrow(() => Throw.IfNull(param, paramName, userMessage));
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfNull(default(string), paramName, userMessage)).Is(_ => _.ParamName == paramName && _.Message.Contains(userMessage));
			}
		}

		[TestMethod]
		public void IfOutOfRangeTest()
		{
			var paramName = "paramName";
			var innerException = new ApplicationException();
			var userMessage = "userMessage";
			var actualValue = "actualValue";

			{
				AssertEx.DoesNotThrow(() => Throw.IfOutOfRange(false));
				AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(true));
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string))).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string))).ParamName.Is("paramName");

				AssertEx.DoesNotThrow(() => Throw.IfOutOfRange(false, paramName));
				AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(true, paramName)).ParamName.Is(paramName);
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), default(Exception))).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), default(Exception))).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, userMessage, default(Exception))).ParamName.Is("innerException");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, userMessage, default(Exception))).ParamName.Is("innerException");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), innerException)).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), innerException)).ParamName.Is("userMessage");

				AssertEx.DoesNotThrow(() => Throw.IfOutOfRange(false, userMessage, innerException));
				AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(true, userMessage, innerException))
					.Is(_ => _.Message == userMessage && _.InnerException == innerException);
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), default(string))).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), default(string))).ParamName.Is("paramName");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, paramName, default(string))).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, paramName, default(string))).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), userMessage)).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), userMessage)).ParamName.Is("paramName");

				AssertEx.DoesNotThrow(() => Throw.IfOutOfRange(false, paramName, userMessage));
				AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(true, paramName, userMessage))
					.Is(_ => _.ParamName == paramName && _.Message.Contains(userMessage));
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), default(object), default(string))).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), default(object), default(string))).ParamName.Is("paramName");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, paramName, default(object), default(string))).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, paramName, default(object), default(string))).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), default(object), userMessage)).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), default(object), userMessage)).ParamName.Is("paramName");

				AssertEx.DoesNotThrow(() => Throw.IfOutOfRange(false, paramName, default(object), userMessage));
				AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(true, paramName, default(object), userMessage))
					.Is(_ => _.ParamName == paramName && _.ActualValue == default(object) && _.Message.Contains(userMessage));
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), actualValue, default(string))).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), actualValue, default(string))).ParamName.Is("paramName");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, paramName, actualValue, default(string))).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, paramName, actualValue, default(string))).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(false, default(string), actualValue, userMessage)).ParamName.Is("paramName");
				AssertEx.Throws<ArgumentNullException>(() => Throw.IfOutOfRange(true, default(string), actualValue, userMessage)).ParamName.Is("paramName");

				AssertEx.DoesNotThrow(() => Throw.IfOutOfRange(false, paramName, actualValue, userMessage));
				AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.IfOutOfRange(true, paramName, actualValue, userMessage))
					.Is(_ => _.ParamName == paramName && _.ActualValue.Equals(actualValue) && _.Message.Contains(userMessage));
			}
		}

        [TestMethod]
        public void IfInvalidOperationTest()
        {
            var userMessage = "userMessage";
            var innerException = new ApplicationException();

            {
                AssertEx.DoesNotThrow(() => Throw.IfInvalidOperation(false));
                AssertEx.Throws<InvalidOperationException>(() => Throw.IfInvalidOperation(true));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(false, null));
                AssertEx.DoesNotThrow(() => Throw.IfInvalidOperation(false, userMessage));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(true, null));
                AssertEx.Throws<InvalidOperationException>(() => Throw.IfInvalidOperation(true, userMessage));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(false, null, null));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(false, null, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(false, userMessage, null));
                AssertEx.DoesNotThrow(() => Throw.IfInvalidOperation(false, userMessage, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(true, null, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfInvalidOperation(true, userMessage, null));
                AssertEx.Throws<InvalidOperationException>(() => Throw.IfInvalidOperation(true, userMessage, innerException));
            }
        }

        [TestMethod]
        public void IfNotSupportedTest()
        {
            var userMessage = "userMessage";
            var innerException = new ApplicationException();

            {
                AssertEx.DoesNotThrow(() => Throw.IfNotSupported(false));
                AssertEx.Throws<NotSupportedException>(() => Throw.IfNotSupported(true));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(false, null));
                AssertEx.DoesNotThrow(() => Throw.IfNotSupported(false, userMessage));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(true, null));
                AssertEx.Throws<NotSupportedException>(() => Throw.IfNotSupported(true, userMessage));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(false, null, null));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(false, null, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(false, userMessage, null));
                AssertEx.DoesNotThrow(() => Throw.IfNotSupported(false, userMessage, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(true, null, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.IfNotSupported(true, userMessage, null));
                AssertEx.Throws<NotSupportedException>(() => Throw.IfNotSupported(true, userMessage, innerException));
            }
        }
    }

	[TestClass]
	public class ThrowTExceptionTest
	{
		[TestMethod]
		public void IfTest()
		{
			var userMessage = "UserMessage";
			var innerException = new ApplicationException();

			{
				AssertEx.Throws<ApplicationException>(() => Throw<ApplicationException>.If(true));
				AssertEx.DoesNotThrow(() => Throw<ApplicationException>.If(false));
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(true, null)).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(false, null)).ParamName.Is("userMessage");

				AssertEx.Throws<ApplicationException>(() => Throw<ApplicationException>.If(true, userMessage));
				AssertEx.DoesNotThrow(() => Throw<ApplicationException>.If(false, userMessage));
			}

			{
				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(true, null, null)).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(false, null, null)).ParamName.Is("userMessage");

				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(true, userMessage, null)).ParamName.Is("innerException");
				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(false, userMessage, null)).ParamName.Is("innerException");

				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(true, null, innerException)).ParamName.Is("userMessage");
				AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(false, null, innerException)).ParamName.Is("userMessage");

				AssertEx.Throws<ApplicationException>(() => Throw<ApplicationException>.If(true, userMessage, innerException));
				AssertEx.DoesNotThrow(() => Throw<ApplicationException>.If(false, userMessage, innerException));
			}
		}
	}
}
