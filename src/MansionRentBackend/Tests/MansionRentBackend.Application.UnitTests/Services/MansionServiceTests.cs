using Autofac.Extras.Moq;
using AutoMapper;
using MansionRentBackend.Application.Services;
using MansionRentBackend.Domain.IUnitOfWorks;
using MansionRentBackend.Domain.Repositories;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Linq.Expressions;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Domain.Entities.Mansion;

namespace MansionRentBackend.Application.UnitTests.Services;

public class MansionServiceTests
{
    private AutoMock _mock;
    private Mock<IApplicationUnitOfWork> _applicationtUnitOfWork;
    private Mock<IMansionRepository> _mansionRepositoryMock;
    private Mock<IMapper> _mapperMock;
    private IMansionService _mansionService;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _mock = AutoMock.GetLoose();
    }

    [SetUp]
    public void Setup()
    {
        _applicationtUnitOfWork = _mock.Mock<IApplicationUnitOfWork>();
        _mansionRepositoryMock = _mock.Mock<IMansionRepository>();
        _mapperMock = _mock.Mock<IMapper>();
        _mansionService = _mock.Create<MansionService>();
    }

    [TearDown]
    public void TearDown()
    {
        _applicationtUnitOfWork.Reset();
        _mansionRepositoryMock.Reset();
        _mapperMock.Reset();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _mock?.Dispose();
    }

    [Test]
    public void CreateMansion_MansionExists_ThrowsError()
    {
        var mansion = new MansionBO
        {
            Name= "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate= DateTime.Now,
            IsDeleted = false
        };

        _applicationtUnitOfWork.Setup(x => x.Mansions).Returns(_mansionRepositoryMock.Object);

        _mansionRepositoryMock.Setup(x => x.GetCount(It.IsAny<Expression<Func<MansionEO, bool>>>())).ReturnsAsync(1);

        Should.Throw<Exception>
        (
            () => _mansionService.CreateMansion(mansion)
        );
    }
}