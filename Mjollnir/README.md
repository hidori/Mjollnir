Mjollnir Namespace
====

* [Classes](#Classes)

# <a name="Classes">Classes</a>

* Activator Class
* ByteArrayFactory Class
* StringFactory Class
* Throw.ArgumentNullException Class
* Throw.ArgumentOutOfRangeException Class
* Throw&lt;T&gt; Class

# <a name="Activator_Class">Activator Class</a>

* [Methods](#Actvator_Class_Mathods)

## <a name="Activator_Class_Methods">Methods</a>

* CreateInstance&lt;T&gt;() method
* CreateInstance&lt;T&gt;(params object[]) method

# <a name="ByteArrayFactory_Class">ByteArrayFactory Class</a>

* [Methods](#ByteArrayFactory_Class_Mathods)

## <a name="ByteArrayFactory_Class_Methods">Methods</a>

* Create(Action&lt;Stream&gt; action) method

# <a name="StringFactory_Class">StringFactory Class</a>

* [Methods](#StringFactory_Class_Mathods)

## <a name="StringFactory_Class_Methods">Methods</a>

* Create(Action&lt;StringBuilder&gt; action) method

# <a name="Throw_ArgumentNullException_Class">Throw.ArgumentNullException Class</a>

* [Methods](#Throw_ArgumentNullException_Class_Mathods)

## <a name="Throw_ArgumentNullException_Class_Methods">Methods</a>

* IfNull&lt;TParam&gt;(Tparam param) method
* IfNull&lt;TParam&gt;(Tparam param, string paramName) method
* IfNull&lt;TParam&gt;(Tparam param, string userMessage, Exception innerException) method
* IfNull&lt;TParam&gt;(Tparam param, string paramName, string userMessage) method

# <a name="Throw_ArgumentOutOfRangeException_Class">Throw.ArgumentOutOfRangeException Class</a>

* [Methods](#Throw_ArgumentOutOfRangeException_Class_Mathods)

## <a name="Throw_ArgumentOutOfRangeException_Class_Methods">Methods</a>

* IfNull&lt;TParam&gt;(Tparam param) method
* IfNull&lt;TParam&gt;(Tparam param, string paramName) method
* IfNull&lt;TParam&gt;(Tparam param, string userMessage, Exception innerException) method
* IfNull&lt;TParam&gt;(Tparam param, string paramName, string userMessage) method
* IfNull&lt;TParam&gt;(Tparam param, string paramName, object actualValue, string userMessage) method

# <a name="Throw&lt;T&gt;_Class">Throw&lt;T&gt; Class</a>

* [Methods](#Throw&lt;T&gt;_Class_Class_Mathods)

## <a name="Throw&lt;T&gt;_Class_Methods">Methods</a>

* If(bool condition) method
* If(bool condition, string userMessage) method
* If(bool condition, string userMessage, Exception innerException) method
* If(bool condition, Func&lt;TException&gt; factory) method
