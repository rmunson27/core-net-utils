﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rem.CoreUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rem.CoreUtilsTest;

/// <summary>
/// Tests for types representing a logical AND of two or more types.
/// </summary>
[TestClass]
public class ClassAndTest
{
    /// <summary>
    /// Tests equality methods.
    /// </summary>
    [TestMethod]
    public void TestEquality()
    {
        Assert.IsTrue(ClassAnd<RecordA, IInterfaceA>.FromChild(new RecordB(5)).EqualsChild(new RecordB(5)));
        Assert.IsFalse(ClassAnd<RecordA, IInterfaceA>.FromChild(new RecordB(5)).EqualsChild(new RecordB(2)));

        var b = new ClassB();
        Assert.IsTrue(ClassAnd<ClassA, IInterfaceA>.FromChild(b).EqualsChild(b));
        Assert.IsFalse(ClassAnd<ClassA, IInterfaceA>.FromChild(b).EqualsChild(new ClassB()));

        Assert.IsTrue(default(ClassAnd<ClassA, IInterfaceA>).Equals(null as object));

        Assert.AreEqual(ClassAnd<ClassA, IInterfaceA>.FromChild(b), ClassAnd<ClassA, IInterfaceA>.FromChild(b));
    }

    /// <summary>
    /// Tests conversions between types and class AND values.
    /// </summary>
    [TestMethod]
    public void TestConversions()
    {
        var defaultAnd = default(ClassAnd<ClassB, IInterfaceB>);
        var nonDefaultAnd = ClassAnd<ClassB, IInterfaceB>.FromChild(new ClassD());

        #region Class Value
        #region Component
        Assert.IsNull(defaultAnd.AsT1);
        Assert.IsNull(defaultAnd.AsT2);

        Assert.IsNotNull(nonDefaultAnd.AsT1);
        Assert.IsNotNull(nonDefaultAnd.AsT2);
        #endregion

        #region Common Parent
        Assert.IsNull(ClassAnd.FixParent<object>.FromChild(defaultAnd));
        Assert.IsNotNull(ClassAnd.FixParent<object>.FromChild(nonDefaultAnd));
        #endregion

        #region Common Child
        Assert.IsNull(defaultAnd.CastToChild<ClassE>());
        Assert.That.ThrowsCastException(() => nonDefaultAnd.CastToChild<ClassE>());
        Assert.IsNull(nonDefaultAnd.AsChild<ClassE>());
        Assert.IsNotNull(nonDefaultAnd.CastToChild<ClassD>());
        Assert.IsNotNull(nonDefaultAnd.AsChild<ClassD>());
        #endregion
        #endregion

        #region Class AND
        #region Parent
        Assert.That.IsDefault(ClassAnd.FixT1<ClassA>.FromChild(defaultAnd));
        Assert.That.IsNotDefault(ClassAnd.FixT1<ClassA>.FromChild(nonDefaultAnd));
        Assert.That.IsDefault(ClassAnd.FixT2<IInterfaceA>.FromChild(defaultAnd));
        Assert.That.IsNotDefault(ClassAnd.FixT2<IInterfaceA>.FromChild(nonDefaultAnd));
        Assert.That.IsDefault(ClassAnd<ClassA, IInterfaceA>.FromChildren(defaultAnd));
        Assert.That.IsNotDefault(ClassAnd<ClassA, IInterfaceA>.FromChildren(nonDefaultAnd));
        #endregion

        #region Child
        #region Cast T1 Only
        Assert.That.IsDefault(defaultAnd.CastT1ToChild<ClassE>());
        Assert.That.IsDefault(defaultAnd.T1AsChild<ClassE>());
        Assert.That.IsNotDefault(nonDefaultAnd.CastT1ToChild<ClassD>());
        Assert.That.IsNotDefault(nonDefaultAnd.T1AsChild<ClassD>());
        Assert.That.ThrowsCastException(() => nonDefaultAnd.CastT1ToChild<ClassE>());
        Assert.That.IsDefault(nonDefaultAnd.T1AsChild<ClassE>());
        #endregion

        #region Cast T2 Only
        Assert.That.IsDefault(defaultAnd.CastT2ToChild<IInterfaceC>());
        Assert.That.IsDefault(defaultAnd.T2AsChild<IInterfaceC>());
        Assert.That.IsNotDefault(nonDefaultAnd.CastT2ToChild<IInterfaceC>());
        Assert.That.IsNotDefault(nonDefaultAnd.T2AsChild<IInterfaceC>());
        Assert.That.ThrowsCastException(() => nonDefaultAnd.CastT2ToChild<IInterfaceD>());
        Assert.That.IsDefault(nonDefaultAnd.T2AsChild<IInterfaceD>());
        #endregion

        #region Cast Both T1 And T2
        Assert.That.IsDefault(defaultAnd.CastToChildren<ClassD, IInterfaceD>());
        Assert.That.IsDefault(defaultAnd.AsChildren<ClassD, IInterfaceD>());
        Assert.That.IsNotDefault(nonDefaultAnd.CastToChildren<ClassD, IInterfaceC>());
        Assert.That.ThrowsCastException(() => nonDefaultAnd.CastToChildren<ClassD, IInterfaceD>());
        Assert.That.ThrowsCastException(() => nonDefaultAnd.CastToChildren<ClassE, IInterfaceC>());
        Assert.That.IsDefault(nonDefaultAnd.AsChildren<ClassD, IInterfaceD>());
        Assert.That.IsDefault(nonDefaultAnd.AsChildren<ClassE, IInterfaceC>());
        #endregion
        #endregion
        #endregion
    }

    #region Classes
    private record class RecordB(int I) : RecordA(I), IInterfaceA;
    private record class RecordA(int I) { }
    private class ClassE : ClassD, IInterfaceD { }
    private class ClassD : ClassC, IInterfaceC { }
    private class ClassC : ClassB, IInterfaceB { }
    private class ClassB : ClassA, IInterfaceA { }
    private class ClassA { }
    private interface IInterfaceD : IInterfaceC { }
    private interface IInterfaceC : IInterfaceB { }
    private interface IInterfaceB : IInterfaceA { }
    private interface IInterfaceA { }
    #endregion
}
