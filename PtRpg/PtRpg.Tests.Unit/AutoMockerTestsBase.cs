using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace PtRpg.Tests.Unit
{
    [TestFixture]
    public class AutoMockerTestsBase<T> where T : class
    {
        AutoMocker _autoMock;
        T _target = null;

        [SetUp]
        public void AmtSetUp()
        {
            _target = null;
            _autoMock = new AutoMocker();
            
        }

        public T Target
        {
            get
            {
                if (_target == null)
                    _target = _autoMock.CreateInstance<T>();

                return _target;
            }
        }

        public Mock<TMock> GetMock<TMock>() where TMock : class
        {
            return _autoMock.GetMock<TMock>();
        }

        public void Use<TService>(TService service)
        {
            _autoMock.Use<TService>(service);
        }
    }
}