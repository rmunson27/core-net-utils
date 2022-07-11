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
        Assert.AreEqual(new RecordA(4), new ClassOr<RecordA, ClassA>(new RecordA(4)));
        Assert.AreNotEqual(new RecordA(5), new ClassOr<RecordA, ClassA>(new RecordA(4)));
        
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
        Assert.AreEqual(default(ClassOr<RecordA, ClassA>), default(ClassA));
    }

    /// <summary>
    /// Tests conversions between types and class OR values.
    /// </summary>
    [TestMethod]
    public void TestCasting()
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
        AssertThrowsCastException(() => t1Or.CastToT2());
        Assert.IsNotNull(t1Or.AsT1);
        Assert.IsNull(t1Or.AsT2);
        #endregion

        #region T2 Only
        AssertThrowsCastException(() => t2Or.CastToT1());
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
        Assert.IsNull(ClassOr.FixParent<object>.FromChild(defaultOr));
        Assert.IsNotNull(ClassOr.FixParent<object>.FromChild(t1Or));
        Assert.IsNotNull(ClassOr.FixParent<object>.FromChild(t2Or));
        Assert.IsNotNull(ClassOr.FixParent<object>.FromChild(bothOr));
        #endregion

        #region Common Child
        #region Default
        Assert.IsNull(defaultOr.CastToChild<ClassB>());
        Assert.IsNull(defaultOr.AsChild<ClassB>());
        #endregion

        #region T1 Only
        AssertThrowsCastException(() => t1Or.CastToChild<ClassB>());
        Assert.IsNull(t1Or.AsChild<ClassB>());
        #endregion

        #region T2 Only
        AssertThrowsCastException(() => t2Or.CastToChild<ClassB>());
        Assert.IsNull(t2Or.AsChild<ClassB>());
        #endregion

        #region Both T1 And T2
        // Cast could succeed or fail depending on type
        Assert.IsNotNull(bothOr.CastToChild<ClassB>());
        AssertThrowsCastException(() => bothOr.CastToChild<ClassC>());
        Assert.IsNotNull(bothOr.AsChild<ClassB>());
        Assert.IsNull(bothOr.AsChild<ClassC>());
        #endregion
        #endregion
        #endregion

        #region Class OR
        #region Parent
        #region Default
        AssertIsDefault(ClassOr.FixT1<object>.FromChild(defaultOr));
        AssertIsDefault(ClassOr.FixT2<object>.FromChild(defaultOr));
        AssertIsDefault(ClassOr<object, object>.FromChildren(defaultOr));
        #endregion

        #region T1 Only
        Assert.AreEqual(TypeFlags2.T1, ClassOr.FixT1<object>.FromChild(t1Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT2<object>.FromChild(t1Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr<object, object>.FromChildren(t1Or).TypeFlags);
        #endregion

        #region T2 Only
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT1<object>.FromChild(t2Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, ClassOr.FixT2<object>.FromChild(t2Or).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr<object, object>.FromChildren(t2Or).TypeFlags);
        #endregion

        #region Both T1 And T2
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT1<object>.FromChild(bothOr).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr.FixT2<object>.FromChild(bothOr).TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, ClassOr<object, object>.FromChildren(bothOr).TypeFlags);
        #endregion
        #endregion

        #region Child
        #region Default
        AssertIsDefault(defaultOr.CastT1ToChild<ClassB>());
        AssertIsDefault(defaultOr.T1AsChild<ClassB>());
        AssertIsDefault(defaultOr.CastT2ToChild<ClassB>());
        AssertIsDefault(defaultOr.T2AsChild<ClassB>());
        AssertIsDefault(defaultOr.CastToChildren<ClassC, InterfaceAImpl>());
        AssertIsDefault(defaultOr.AsChildren<ClassC, InterfaceAImpl>());
        #endregion

        #region T1 Only
        #region To T1 Child
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T1, t1Or.CastT1ToChild<InterfaceAImpl>().TypeFlags);
        AssertThrowsCastException(() => t1Or.CastT1ToChild<ClassB>());
        Assert.AreEqual(TypeFlags2.T1, t1Or.T1AsChild<InterfaceAImpl>().TypeFlags);
        AssertIsDefault(t1Or.T1AsChild<ClassB>());
        #endregion

        #region To T2 Child
        Assert.AreEqual(TypeFlags2.T1, t1Or.CastT2ToChild<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T1, t1Or.T2AsChild<ClassB>().TypeFlags);
        #endregion

        #region To Children
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T1, t1Or.CastToChildren<InterfaceAImpl, ClassC>().TypeFlags);
        AssertThrowsCastException(() => t1Or.CastToChildren<ClassB, ClassC>());
        Assert.AreEqual(TypeFlags2.T1, t1Or.AsChildren<InterfaceAImpl, ClassC>().TypeFlags);
        AssertIsDefault(t1Or.AsChildren<ClassB, ClassC>());
        #endregion
        #endregion

        #region T2 Only
        #region To T1 Child
        Assert.AreEqual(TypeFlags2.T2, t2Or.CastT1ToChild<ClassC>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, t2Or.T1AsChild<ClassC>().TypeFlags);
        #endregion

        #region To T2 Child
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T2, t2Or.CastT2ToChild<InterfaceAImpl>().TypeFlags);
        AssertThrowsCastException(() => t2Or.CastT2ToChild<ClassB>());
        Assert.AreEqual(TypeFlags2.T2, t2Or.T2AsChild<InterfaceAImpl>().TypeFlags);
        AssertIsDefault(t2Or.T2AsChild<ClassB>());
        #endregion

        #region To Children
        Assert.AreEqual(TypeFlags2.T2, t2Or.CastToChildren<ClassC, InterfaceAImpl>().TypeFlags);
        AssertThrowsCastException(() => t2Or.CastToChildren<ClassC, ClassB>());
        Assert.AreEqual(TypeFlags2.T2, t2Or.AsChildren<ClassC, InterfaceAImpl>().TypeFlags);
        AssertIsDefault(t2Or.AsChildren<ClassC, ClassB>());
        #endregion
        #endregion

        #region Both T1 And T2
        #region To T1 Child
        // Cast could succeed or fail depending on type normally, but will all succeed with bothOr since it wraps an
        // instance of both types
        Assert.AreEqual(TypeFlags2.Both, bothOr.CastT1ToChild<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.CastT1ToChild<ClassC>().TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, bothOr.T1AsChild<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.T1AsChild<ClassC>().TypeFlags);
        #endregion

        #region To T2 Child
        // Cast could succeed or fail depending on type normally, but will all succeed with bothOr since it wraps an
        // instance of both types
        Assert.AreEqual(TypeFlags2.Both, bothOr.CastT2ToChild<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T1, bothOr.CastT2ToChild<InterfaceAImpl>().TypeFlags);
        Assert.AreEqual(TypeFlags2.Both, bothOr.T2AsChild<ClassB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T1, bothOr.T2AsChild<InterfaceAImpl>().TypeFlags);
        #endregion

        #region To Children
        // Cast could succeed or fail depending on type
        Assert.AreEqual(TypeFlags2.T1, bothOr.CastToChildren<ClassB, IInterfaceB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.CastToChildren<ClassC, IInterfaceA>().TypeFlags);
        AssertThrowsCastException(() => bothOr.CastToChildren<ClassC, IInterfaceB>());
        Assert.AreEqual(TypeFlags2.T1, bothOr.AsChildren<ClassB, IInterfaceB>().TypeFlags);
        Assert.AreEqual(TypeFlags2.T2, bothOr.CastToChildren<ClassC, IInterfaceA>().TypeFlags);
        AssertThrowsCastException(() => bothOr.CastToChildren<ClassC, IInterfaceB>());
        #endregion
        #endregion
        #endregion
        #endregion
    }

    #region Helpers
    private static void AssertIsDefault<T1, T2>(ClassOr<T1, T2> value) where T1 : class where T2 : class
        => Assert.IsTrue(value.IsDefault);

    private static InvalidCastException AssertThrowsCastException(Action a)
        => Assert.ThrowsException<InvalidCastException>(a);
    #endregion

    #region Classes
    private class ClassC : ClassB { }

    private class ClassB : ClassA, IInterfaceA { }

    private class ClassA { }

    private record class RecordA(short S);

    private class InterfaceAImpl : IInterfaceA { }

    private interface IInterfaceB : IInterfaceA { }

    private interface IInterfaceA { }
    #endregion
}
