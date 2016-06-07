using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mjollnir.Tests
{
    [TestClass]
    public class ThrowArgumentNullExceptionTest
    {
        [TestMethod]
        public void IfNullTest()
        {
            var param = "param";
            var paramName = "paramName";
            var innerException = new ApplicationException();
            var userMessage = "userMessage";

            {
                AssertEx.DoesNotThrow(() => Throw.ArgumentNullException.IfNull(param));
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string)));
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, default(string))).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), default(string))).ParamName.Is("paramName");

                AssertEx.DoesNotThrow(() => Throw.ArgumentNullException.IfNull(param, paramName));
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), paramName)).ParamName.Is(paramName);
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, default(string), default(Exception))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), default(string), default(Exception))).ParamName.Is("userMessage");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, userMessage, default(Exception))).ParamName.Is("innerException");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), userMessage, default(Exception))).ParamName.Is("innerException");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, default(string), innerException)).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), default(string), innerException)).ParamName.Is("userMessage");

                AssertEx.DoesNotThrow(() => Throw.ArgumentNullException.IfNull(param, userMessage, innerException));
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), userMessage, innerException)).Is(_ => _.Message == userMessage && _.InnerException == innerException);
            }

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, default(string), default(string))).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), default(string), default(string))).ParamName.Is("paramName");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, paramName, default(string))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), paramName, default(string))).ParamName.Is("userMessage");

                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(param, default(string), userMessage)).ParamName.Is("paramName");
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), default(string), userMessage)).ParamName.Is("paramName");

                AssertEx.DoesNotThrow(() => Throw.ArgumentNullException.IfNull(param, paramName, userMessage));
                AssertEx.Throws<ArgumentNullException>(() => Throw.ArgumentNullException.IfNull(default(string), paramName, userMessage)).Is(_ => _.ParamName == paramName && _.Message.Contains(userMessage));
            }
        }
    }
}
