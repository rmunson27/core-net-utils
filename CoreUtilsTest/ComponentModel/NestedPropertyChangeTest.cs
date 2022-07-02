using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rem.CoreUtils.ComponentModel;
using System.Collections.Immutable;
using System.ComponentModel;

namespace Rem.CoreUtilsTest.ComponentModel;

/// <summary>
/// Tests of the <see cref="INotifyNestedPropertyChanging"/> and <see cref="INotifyNestedPropertyChanged"/> interfaces,
/// particularly when using the <see cref="NestedObservableObject"/> base class.
/// </summary>
[TestClass]
public class NestedPropertyChangeTest
{
    private ImmutableStack<string> ChangingPath { get; set; } = ImmutableStack<string>.Empty;
    private ImmutableStack<string> ChangedPath { get; set; } = ImmutableStack<string>.Empty;

    /// <summary>
    /// Tests the nested property change events raised by instances of the <see cref="NestedObservableObject"/> class.
    /// </summary>
    [TestMethod]
    public void TestNestedObservableObjects()
    {
        var a = new A();
        a.NestedPropertyChanging += ANestedChanging;
        a.NestedPropertyChanged += ANestedChanged;

        var b = new B();
        a.BValue = b;
        Assert.IsTrue(ChangingPath.SequenceEqual(new[] { nameof(A.BValue) }));
        Assert.IsTrue(ChangedPath.SequenceEqual(new[] { nameof(A.BValue) }));

        b.CValue = new C();
        Assert.IsTrue(ChangingPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue) }));
        Assert.IsTrue(ChangedPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue) }));

        b.CValue.BoolValue = true;
        Assert.IsTrue(ChangingPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue), nameof(C.BoolValue) }));
        Assert.IsTrue(ChangedPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue), nameof(C.BoolValue) }));

        // The events should have been unsubscribed to, so the change in b should not be picked up
        a.BValue = new B();
        b.CValue.BoolValue = false;
        Assert.IsTrue(ChangingPath.SequenceEqual(new[] { nameof(A.BValue) }));
        Assert.IsTrue(ChangingPath.SequenceEqual(new[] { nameof(A.BValue) }));
    }

    /// <summary>
    /// Tests property change event argument methods.
    /// </summary>
    [TestMethod]
    public void TestEventArgs()
    {
        var parentChange = new NestedPropertyChangedEventArgs(new[] { "A", "B" });
        var childChange = new NestedPropertyChangedEventArgs(new[] { "A", "B", "C" });
        var somethingElseChange = new NestedPropertyChangedEventArgs(new[] { "D", "E" });

        Assert.IsTrue(parentChange.ImpliesChangeOf(childChange.PropertyPath));
        Assert.IsFalse(parentChange.ChangeImpliedBy(childChange.PropertyPath));
        Assert.IsTrue(childChange.ChangeImpliedBy(parentChange.PropertyPath));
        Assert.IsFalse(childChange.ImpliesChangeOf(parentChange.PropertyPath));

        Assert.IsTrue(parentChange.ImpliesChangeOf(parentChange.PropertyPath));
        Assert.IsTrue(parentChange.ChangeImpliedBy(parentChange.PropertyPath));

        Assert.IsFalse(parentChange.ImpliesChangeOf(somethingElseChange.PropertyPath));
        Assert.IsFalse(parentChange.ChangeImpliedBy(somethingElseChange.PropertyPath));
    }

    private void ANestedChanging(object sender, NestedPropertyChangingEventArgs e)
    {
        ChangingPath = e.PropertyPath;
    }

    private void ANestedChanged(object sender, NestedPropertyChangedEventArgs e)
    {
        ChangedPath = e.PropertyPath;
    }

    private sealed class A : NestedObservableObject
    {
        public B? BValue
        {
            get => _bValue;
            set => SetNestedChangeProperty(ref _bValue, value, BValueChanging, BValueChanged);
        }
        private B? _bValue;

        private void BValueChanged(object _, NestedPropertyChangedEventArgs e)
            => OnChildNestedPropertyChanged(nameof(BValue), e);
        private void BValueChanging(object _, NestedPropertyChangingEventArgs e)
            => OnChildNestedPropertyChanging(nameof(BValue), e);
    }

    private sealed class B : NestedObservableObject
    {
        public C? CValue
        {
            get => _cValue;
            set => SetChangeProperty(ref _cValue, value, CValueChanging, CValueChanged);
        }
        private C? _cValue;

        private void CValueChanging(object? _, PropertyChangingEventArgs e)
            => OnChildPropertyChanging(nameof(CValue), e);
        private void CValueChanged(object? _, PropertyChangedEventArgs e)
            => OnChildPropertyChanged(nameof(CValue), e);
    }

    private sealed class C : ObservableObject
    {
        public bool BoolValue
        {
            get => _boolValue;
            set => SetProperty(ref _boolValue, value);
        }
        private bool _boolValue;
    }
}