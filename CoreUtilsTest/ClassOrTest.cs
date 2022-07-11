using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rem.CoreUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rem.CoreUtilsTest;

using TypeFlags2 = OrType2.TypeFlags;

/// <summary>
/// Tests of types representing a logical OR of two or more types.
/// </summary>
[TestClass]
public class ClassOrTest
{
    /// <summary>
    /// Tests the various methods of construction.
    /// </summary>
    [TestMethod]
    public void TestConstruction()
    {
        var justClass = new ClassOr<ClassA, IInterfaceA>(new ClassA());
        var justInterface = new ClassOr<ClassA, IInterfaceA>(new InterfaceAImpl());
        var both = ClassOr<ClassA, IInterfaceA>.FromChild(new ClassB());

        Assert.AreEqual(TypeFlags2.T1, justClass.TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, justInterface.TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, both.TypeFlags);
    }

    /// <summary>
    /// Tests the equality methods and functionality.
    /// </summary>
    [TestMethod]
    public void TestEquality()
    {
        var a = new ClassA();

        // Object-class OR comparisons
        Assert.IsTrue(new ClassOr<RecordA, ClassA>(new RecordB(4)).Equals(new RecordB(4)));
        Assert.IsFalse(new ClassOr<RecordA, ClassA>(new RecordB(4)).Equals(new RecordB(5)));
        
        // Class OR comparisons
        Assert.AreEqual(new ClassOr<RecordA, ClassA>(new RecordA(4)), new ClassOr<RecordA, ClassA>(new RecordA(4)));
        Assert.AreNotEqual(
            new ClassOr<RecordA, ClassA>(new RecordA(4)), new ClassOr<RecordA, ClassA>(new ClassA()));
        Assert.AreEqual(new ClassOr<RecordA, ClassA>(a), new ClassOr<RecordA, ClassA>(a));
        Assert.AreNotEqual(new ClassOr<RecordA, ClassA>(new ClassA()), new ClassOr<RecordA, ClassA>(a));

        // Class OR comparisons (switch type parameters)
        Assert.AreEqual(new ClassOr<RecordA, ClassA>(a), new ClassOr<ClassA, RecordA>(a));
        Assert.AreNotEqual(new ClassOr<RecordA, ClassA>(a), new ClassOr<ClassA, RecordA>(new ClassA()));

        // Class OR default comparisons
        Assert.IsTrue(default(ClassOr<RecordA, ClassA>).Equals(null as object));
    }

    /// <summary>
    /// Tests conversions between types and class OR values.
    /// </summary>
    [TestMethod]
    public void TestConversions()
    {
        var defaultOr = default(ClassOr<ClassA, IInterfaceA>);
        var t2Or = new ClassOr<ClassA, IInterfaceA>(new InterfaceAImpl());
        ClassOr<IInterfaceA, ClassA> t1Or = t2Or;
        var bothOr = ClassOr<ClassA, IInterfaceA>.FromChild(new ClassB());

        #region Class Value
        #region Component
        #region Default
        Assert.IsNull(defaultOr.CastToT1());
        Assert.IsNull(defaultOr.CastToT2());
        Assert.IsNull(defaultOr.AsT1);
        Assert.IsNull(defaultOr.AsT2);
        #endregion

        #region T1 Only
        Assert.IsNotNull(t1Or.CastToT1());
        Assert.That.ThrowsCastException(() => t1Or.CastToT2());
        Assert.IsNotNull(t1Or.AsT1);
        Assert.IsNull(t1Or.AsT2);
        #endregion

        #region T2 Only
        Assert.That.ThrowsCastException(() => t2Or.CastToT1());
        Assert.IsNotNull(t2Or.CastToT2());
        Assert.IsNull(t2Or.AsT1);
        Assert.IsNotNull(t2Or.AsT2);
        #endregion

        #region Both
        Assert.IsNotNull(bothOr.CastToT1());
        Assert.IsNotNull(bothOr.CastToT2());
        Assert.IsNotNull(bothOr.AsT1);
        Assert.IsNotNull(bothOr.AsT2);
        #endregion
        #endregion

        #region Common Parent
        Assert.IsNull(ClassOr.FixParent<object>.From(defaultOr));
        Assert.IsNotNull(ClassOr.FixParent<object>.From(t1Or));
        Assert.IsNotNull(ClassOr.FixParent<object>.From(t2Or));
        Assert.IsNotNull(ClassOr.FixParent<object>.From(bothOr));
        #endregion

        #region Common Child
        #region Default
        Assert.IsNull(defaultOr.CastTo<ClassB>());
        Assert.IsNull(defaultOr.As<ClassB>());
        #endregion

        #region T1 Only
        Assert.That.ThrowsCastException(() => t1Or.CastTo<ClassB>());
        Assert.IsNull(t1Or.As<ClassB>());
        #endregion

        #region T2 Only
        Assert.That.ThrowsCastException(() => t2Or.CastTo<ClassB>());
        Assert.IsNull(t2Or.As<ClassB>());
        #endregion

        #region Both T1 And T2
        // Cast could succeed or fail depending on type
        Assert.IsNotNull(bothOr.CastTo<ClassB>());
        Assert.That.ThrowsCastException(() => bothOr.CastTo<ClassC>());
        Assert.IsNotNull(bothOr.As<ClassB>());
        Assert.IsNull(bothOr.As<ClassC>());
        #endregion
        #endregion
        #endregion

        #region Class OR
        #region Parent
        #region Default
        Assert.That.IsDefault(ClassOr.FixT1<object>.From(defaultOr));
        Assert.That.IsDefault(ClassOr.FixT2<object>.From(defaultOr));
        Assert.That.IsDefault(ClassOr<object, object>.FromChildren(defaultOr));
        #endregion

        #region T1 Only
        Assert.AreEqual(TypeFlags2.T1, ClassOr.FixT1<object>.From(t1Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT2<object>.From(t1Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr<object, object>.FromChildren(t1Or).TypeFlags);
        #endregion

        #region T2 Only
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT1<object>.From(t2Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, ClassOr.FixT2<object>.From(t2Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr<object, object>.FromChildren(t2Or).TypeFlags);
        #endregion

        #region Both T1 And T2
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT1<object>.From(bothOr).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT2<object>.From(bothOr).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr<object, object>.FromChildren(bothOr).TypeFlags);
        #endregion
        #endregion

        #region Child
        #region Default
        Assert.That.IsDefault(defaultOr.CastT1To<ClassB>());
        Assert.That.IsDefault(defaultOr.T1As<ClassB>());
        Assert.That.IsDefault(defaultOr.CastT2To<ClassB>());
        Assert.That.IsDefault(defaultOr.T2As<ClassB>());
        Assert.That.IsDefault(defaultOr.CastToChildren<ClassC, InterfaceAImpl>());
        Assert.That.IsDefault(defaultOr.AsChildren<ClassC, InterfaceAImpl>());
        #endregion

        #region T1 Only
        #region To T1 Child
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T1, t1Or.CastT1To<InterfaceAImpl>().TypeFlags);
        Assert.That.ThrowsCastException(() => t1Or.CastT1To<ClassB>());
        Assert.AreEqual(TypeFlags2.T1, t1Or.T1As<InterfaceAImpl>().TypeFlags);
        Assert.That.IsDefault(t1Or.T1As<ClassB>());
        #endregion

        #region To T2 Child
        Assert.AreEqual(TypeFlags2.T1, t1Or.CastT2To<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T1, t1Or.T2As<ClassB>().TypeFlags);
        #endregion

        #region To Children
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T1, t1Or.CastToChildren<InterfaceAImpl, ClassC>().TypeFlags);
        Assert.That.ThrowsCastException(() => t1Or.CastToChildren<ClassB, ClassC>());
        Assert.AreEqual(TypeFlags2.T1, t1Or.AsChildren<InterfaceAImpl, ClassC>().TypeFlags);
        Assert.That.IsDefault(t1Or.AsChildren<ClassB, ClassC>());
        #endregion
        #endregion

        #region T2 Only
        #region To T1 Child
        Assert.AreEqual(TypeFlags2.T2, t2Or.CastT1To<ClassC>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, t2Or.T1As<ClassC>().TypeFlags);
        #endregion

        #region To T2 Child
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T2, t2Or.CastT2To<InterfaceAImpl>().TypeFlags);
        Assert.That.ThrowsCastException(() => t2Or.CastT2To<ClassB>());
        Assert.AreEqual(TypeFlags2.T2, t2Or.T2As<InterfaceAImpl>().TypeFlags);
        Assert.That.IsDefault(t2Or.T2As<ClassB>());
        #endregion

        #region To Children
        Assert.AreEqual(TypeFlags2.T2, t2Or.CastToChildren<ClassC, InterfaceAImpl>().TypeFlags);
        Assert.That.ThrowsCastException(() => t2Or.CastToChildren<ClassC, ClassB>());
        Assert.AreEqual(TypeFlags2.T2, t2Or.AsChildren<ClassC, InterfaceAImpl>().TypeFlags);
        Assert.That.IsDefault(t2Or.AsChildren<ClassC, ClassB>());
        #endregion
        #endregion

        #region Both T1 And T2
        #region To T1 Child
        // Cast could succeed or fail depending on type normally, but will all succeed with bothOr since it wraps an
        // instance of both types
        Assert.AreEqual(TypeFlags2.Both, bothOr.CastT1To<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.CastT1To<ClassC>().TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, bothOr.T1As<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.T1As<ClassC>().TypeFlags);
        #endregion

        #region To T2 Child
        // Cast could succeed or fail depending on type normally, but will all succeed with bothOr since it wraps an
        // instance of both types
        Assert.AreEqual(TypeFlags2.Both, bothOr.CastT2To<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T1, bothOr.CastT2To<InterfaceAImpl>().TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, bothOr.T2As<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T1, bothOr.T2As<InterfaceAImpl>().TypeFlags);
        #endregion

        #region To Children
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T1, bothOr.CastToChildren<ClassB, IInterfaceB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.CastToChildren<ClassC, IInterfaceA>().TypeFlags);
        Assert.That.ThrowsCastException(() => bothOr.CastToChildren<ClassC, IInterfaceB>());
        Assert.AreEqual(TypeFlags2.T1, bothOr.AsChildren<ClassB, IInterfaceB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.CastToChildren<ClassC, IInterfaceA>().TypeFlags);
        Assert.That.ThrowsCastException(() => bothOr.CastToChildren<ClassC, IInterfaceB>());
        #endregion
        #endregion
        #endregion
        #endregion
    }

    #region Classes
    private class ClassC : ClassB { }

    private class ClassB : ClassA, IInterfaceA { }

    private class ClassA { }

    private record class RecordB(short S) : RecordA(S);

    private record class RecordA(short S);

    private class InterfaceAImpl : IInterfaceA { }

    private interface IInterfaceB : IInterfaceA { }

    private interface IInterfaceA { }
    #endregion
}
