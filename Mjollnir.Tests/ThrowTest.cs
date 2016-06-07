using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mjollnir
{
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
                AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(true, default(string))).ParamName.Is("userMessage");
                AssertEx.Throws<ArgumentNullException>(() => Throw<ApplicationException>.If(false, default(string))).ParamName.Is("userMessage");

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

            {
                AssertEx.Throws<ArgumentNullException>(() => Throw<Exception>.If(true, default(Func<Exception>))).ParamName.Is("factory");
                AssertEx.Throws<ArgumentNullException>(() => Throw<Exception>.If(false, default(Func<Exception>))).ParamName.Is("factory");

                AssertEx.Throws<ApplicationException>(() => Throw<ApplicationException>.If(true, () => new ApplicationException()));
                AssertEx.DoesNotThrow(() => Throw<ApplicationException>.If(false, () => new ApplicationException()));
            }
        }
    }
}
