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
    #region Tests
    /// <summary>
    /// Tests the nested property change events raised by instances of the <see cref="NestedObservableObject"/> class.
    /// </summary>
    [TestMethod]
    public void TestNestedObservableObjects()
    {
        #region Variable Setup
        ImmutableStack<string> changingPath = ImmutableStack<string>.Empty, changedPath = ImmutableStack<string>.Empty;
        #endregion

        #region Event Setup
        var a = new A();
        a.NestedPropertyChanging += ANestedChanging;
        a.NestedPropertyChanged += ANestedChanged;
        #endregion

        #region Assertions
        var b = new B();
        a.BValue = b;
        Assert.IsTrue(changingPath.SequenceEqual(new[] { nameof(A.BValue) }));
        Assert.IsTrue(changedPath.SequenceEqual(new[] { nameof(A.BValue) }));

        b.CValue = new C();
        Assert.IsTrue(changingPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue) }));
        Assert.IsTrue(changedPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue) }));

        b.CValue.BoolValue = true;
        Assert.IsTrue(changingPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue), nameof(C.BoolValue) }));
        Assert.IsTrue(changedPath.SequenceEqual(new[] { nameof(A.BValue), nameof(B.CValue), nameof(C.BoolValue) }));

        // The events should have been unsubscribed to, so the change in b should not be picked up
        a.BValue = new B();
        b.CValue.BoolValue = false;
        Assert.IsTrue(changingPath.SequenceEqual(new[] { nameof(A.BValue) }));
        Assert.IsTrue(changingPath.SequenceEqual(new[] { nameof(A.BValue) }));
        #endregion

        #region Event Handlers
        void ANestedChanging(object sender, NestedPropertyChangingEventArgs e)
        {
            changingPath = e.PropertyPath;
        }

        void ANestedChanged(object sender, NestedPropertyChangedEventArgs e)
        {
            changedPath = e.PropertyPath;
        }
        #endregion
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

    /// <summary>
    /// Tests the utility event subscription and unsubscription methods supplied by the
    /// <see cref="GenericPropertyChange"/> class.
    /// </summary>
    [TestMethod]
    public void TestGenericPropertyChange()
    {
        #region Variable Setup
        const int changingFlag = 1;
        const int changedFlag = 2;
        const int nestedChangingFlag = 4;
        const int nestedChangedFlag = 8;

        int i;
        #endregion

        #region Assertions
        #region Changing Only
        var changingOnly = new ChangingOnly();

        i = 0;
        SubscribeToNonNested(changingOnly);
        changingOnly.I = 3;
        Assert.AreEqual(changingFlag, i);
        UnsubscribeFrom(changingOnly);
        #endregion

        #region Changed Only
        var changedOnly = new ChangedOnly();

        i = 0;
        SubscribeToNonNested(changedOnly);
        changedOnly.I = 3;
        Assert.AreEqual(changedFlag, i);
        UnsubscribeFrom(changedOnly);
        #endregion

        #region ObservableObject
        var observable = new C();

        i = 0;
        SubscribeToNonNested(observable);
        observable.BoolValue = true;
        Assert.AreEqual(changingFlag | changedFlag, i);
        UnsubscribeFrom(observable);
        #endregion

        #region Nested Changing Only
        var nestedChangingOnly = new NestedChangingOnly();

        i = 0;
        SubscribeTo(nestedChangingOnly, true);
        nestedChangingOnly.I = 3;
        Assert.AreEqual(nestedChangingFlag, i);
        UnsubscribeFrom(nestedChangingOnly);

        i = 0;
        SubscribeTo(nestedChangingOnly, false);
        nestedChangingOnly.I = 2;
        Assert.AreEqual(changingFlag | nestedChangingFlag, i);
        UnsubscribeFrom(nestedChangingOnly);
        #endregion

        #region Nested Changed Only
        var nestedChangedOnly = new NestedChangedOnly();

        i = 0;
        SubscribeTo(nestedChangedOnly, true);
        nestedChangedOnly.I = 3;
        Assert.AreEqual(nestedChangedFlag, i);
        UnsubscribeFrom(nestedChangedOnly);

        i = 0;
        SubscribeTo(nestedChangedOnly, false);
        nestedChangedOnly.I = 2;
        Assert.AreEqual(changedFlag | nestedChangedFlag, i);
        UnsubscribeFrom(nestedChangedOnly);
        #endregion

        #region ObservableObject Nested Changing Only
        var observableNestedChangingOnly = new ObservableNestedChangingOnly();

        i = 0;
        SubscribeTo(observableNestedChangingOnly, true);
        observableNestedChangingOnly.I = 4;
        Assert.AreEqual(changedFlag | nestedChangingFlag, i);
        UnsubscribeFrom(observableNestedChangingOnly);

        i = 0;
        SubscribeTo(observableNestedChangingOnly, false);
        observableNestedChangingOnly.I = 5;
        Assert.AreEqual(changingFlag | changedFlag | nestedChangingFlag, i);
        UnsubscribeFrom(observableNestedChangingOnly);
        #endregion

        #region ObservableObject Nested Changed Only
        var observableNestedChangedOnly = new ObservableNestedChangedOnly();

        i = 0;
        SubscribeTo(observableNestedChangedOnly, true);
        observableNestedChangedOnly.I = 1;
        Assert.AreEqual(changingFlag | nestedChangedFlag, i);
        UnsubscribeFrom(observableNestedChangedOnly);

        i = 0;
        SubscribeTo(observableNestedChangedOnly, false);
        observableNestedChangedOnly.I = 3;
        Assert.AreEqual(changingFlag | changedFlag | nestedChangedFlag, i);
        UnsubscribeFrom(observableNestedChangedOnly);
        #endregion

        #region NestedObservableObject
        var nestedObservable = new A();

        i = 0;
        SubscribeTo(nestedObservable, true);
        nestedObservable.BValue = new();
        Assert.AreEqual(nestedChangingFlag | nestedChangedFlag, i);
        UnsubscribeFrom(nestedObservable);

        i = 0;
        SubscribeTo(nestedObservable, false);
        nestedObservable.BValue = new();
        Assert.AreEqual(changingFlag | changedFlag | nestedChangingFlag | nestedChangedFlag, i);
        UnsubscribeFrom(nestedObservable);
        #endregion
        #endregion

        #region Methods
        #region Helpers
        void SubscribeToNonNested<T>(T value) where T : class
            => SubscribeTo(value, true);

        void SubscribeTo<T>(T value, bool ignoreSingularIfNested) where T : class
            => GenericPropertyChange.SubscribeTo(
                value, OnChanging, OnChanged, OnNestedChanging, OnNestedChanged, ignoreSingularIfNested);

        void UnsubscribeFrom<T>(T value) where T : class
            => GenericPropertyChange.UnsubscribeFrom(
                value, OnChanging, OnChanged, OnNestedChanging, OnNestedChanged);
        #endregion

        #region Event Handlers
        void OnChanging(object? _, PropertyChangingEventArgs e) { i |= changingFlag; }
        void OnChanged(object? _, PropertyChangedEventArgs e) { i |= changedFlag; }
        void OnNestedChanging(object? _, NestedPropertyChangingEventArgs e) { i |= nestedChangingFlag; }
        void OnNestedChanged(object? _, NestedPropertyChangedEventArgs e) { i |= nestedChangedFlag; }
        #endregion
        #endregion
    }
    #endregion

    #region Classes
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

    private sealed class ChangingOnly : INotifyPropertyChanging
    {
        public event PropertyChangingEventHandler? PropertyChanging;

        public int I
        {
            get => _i;
            set
            {
                PropertyChanging?.Invoke(this, new(nameof(I)));
                _i = value;
            }
        }
        private int _i;
    }

    private sealed class ChangedOnly : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int I
        {
            get => _i;
            set
            {
                _i = value;
                PropertyChanged?.Invoke(this, new(nameof(I)));
            }
        }
        private int _i;
    }

    private sealed class NestedChangingOnly : INotifyNestedPropertyChanging
    {
        public event NestedPropertyChangingEventHandler? NestedPropertyChanging;
        public event PropertyChangingEventHandler? PropertyChanging;

        public int I
        {
            get => _i;
            set
            {
                NestedPropertyChanging?.Invoke(this, new(nameof(I)));
                PropertyChanging?.Invoke(this, new(nameof(I)));
                _i = value;
            }
        }
        private int _i;
    }

    private sealed class NestedChangedOnly : INotifyNestedPropertyChanged
    {
        public event NestedPropertyChangedEventHandler? NestedPropertyChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        public int I
        {
            get => _i;
            set
            {
                _i = value;
                NestedPropertyChanged?.Invoke(this, new(nameof(I)));
                PropertyChanged?.Invoke(this, new(nameof(I)));
            }
        }
        private int _i;
    }

    private sealed class ObservableNestedChangingOnly : ObservableObject, INotifyNestedPropertyChanging
    {
        public event NestedPropertyChangingEventHandler? NestedPropertyChanging;

        public int I
        {
            get => _i;
            set
            {
                NestedPropertyChanging?.Invoke(this, new(nameof(I)));
                OnPropertyChanging();
                _i = value;
                OnPropertyChanged();
            }
        }
        private int _i;
    }

    private sealed class ObservableNestedChangedOnly : ObservableObject, INotifyNestedPropertyChanged
    {
        public event NestedPropertyChangedEventHandler? NestedPropertyChanged;

        public int I
        {
            get => _i;
            set
            {
                OnPropertyChanging();
                _i = value;
                OnPropertyChanged();
                NestedPropertyChanged?.Invoke(this, new(nameof(I)));
            }
        }
        private int _i;
    }
    #endregion
}