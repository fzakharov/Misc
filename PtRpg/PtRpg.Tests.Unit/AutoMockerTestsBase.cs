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

        public TService Get<TService>()
        {
            return _autoMock.Get<TService>();
        }

        public Mock<TService> GetMock<TService>() where TService : class
        {
            return _autoMock.GetMock<TService>();
        }

        public void Use<TService>(TService service)
        {
            _autoMock.Use(service);
        }
    }
}