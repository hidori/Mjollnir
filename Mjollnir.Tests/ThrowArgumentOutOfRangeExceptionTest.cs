using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mjollnir.Tests
{
    [TestClass]
    public class ThrowArgumentOutOfRangeExceptionTest
    {
        [TestMethod]
        public void IfTest()
        {
            var paramName = "paramName";
            var innerException = new ApplicationException();
            var userMessage = "userMessage";
            var actualValue = "actualValue";

            {
                AssertEx.DoesNotThrow(() => Throw.ArgumentOutOfRangeException.If(false));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.ArgumentOutOfRangeException.If(true));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string))).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string))).ParamName.Is("paramName");

                AssertEx.DoesNotThrow(() => Throw.ArgumentOutOfRangeException.If(false, paramName));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName)).ParamName.Is(paramName);
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), default(Exception))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), default(Exception))).ParamName.Is("userMessage");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, userMessage, default(Exception))).ParamName.Is("innerException");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, userMessage, default(Exception))).ParamName.Is("innerException");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), innerException)).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), innerException)).ParamName.Is("userMessage");

                AssertEx.DoesNotThrow(() => Throw.ArgumentOutOfRangeException.If(false, userMessage, innerException));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.ArgumentOutOfRangeException.If(true, userMessage, innerException))
                    .Is(_ => _.Message == userMessage && _.InnerException == innerException);
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), default(string))).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), default(string))).ParamName.Is("paramName");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, paramName, default(string))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName, default(string))).ParamName.Is("userMessage");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), userMessage)).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), userMessage)).ParamName.Is("paramName");

                AssertEx.DoesNotThrow(() => Throw.ArgumentOutOfRangeException.If(false, paramName, userMessage));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName, userMessage))
                    .Is(_ => _.ParamName == paramName && _.Message.Contains(userMessage));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), default(object), default(string))).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), default(object), default(string))).ParamName.Is("paramName");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, paramName, default(object), default(string))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName, default(object), default(string))).ParamName.Is("userMessage");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), default(object), userMessage)).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), default(object), userMessage)).ParamName.Is("paramName");

                AssertEx.DoesNotThrow(() => Throw.ArgumentOutOfRangeException.If(false, paramName, default(object), userMessage));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName, default(object), userMessage))
                    .Is(_ => _.ParamName == paramName && _.ActualValue == default(object) && _.Message.Contains(userMessage));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), actualValue, default(string))).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), actualValue, default(string))).ParamName.Is("paramName");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, paramName, actualValue, default(string))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName, actualValue, default(string))).ParamName.Is("userMessage");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(false, default(string), actualValue, userMessage)).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentOutOfRangeException.If(true, default(string), actualValue, userMessage)).ParamName.Is("paramName");

                AssertEx.DoesNotThrow(() => Throw.ArgumentOutOfRangeException.If(false, paramName, actualValue, userMessage));
                AssertEx.Throws<ArgumentOutOfRangeException>(() => Throw.ArgumentOutOfRangeException.If(true, paramName, actualValue, userMessage))
                    .Is(_ => _.ParamName == paramName && _.ActualValue.Equals(actualValue) && _.Message.Contains(userMessage));
            }
        }
    }
}
