using Autofac.Extras.Moq;
using AutoMapper;
using MansionRentBackend.Application.Repositories;
using MansionRentBackend.Application.Services;
using MansionRentBackend.Application.UnitOfWorks;
using MansionRentBackend.Domain.Repositories;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.Linq.Expressions;
using MansionBO = MansionRentBackend.Application.BusinessObjects.Mansion;
using MansionEO = MansionRentBackend.Application.Entities.Mansion;

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

    [Test, Category("unit test")]
    public void CreateMansion_MansionDoesNotExist_CreatesMansion()
    {
        var userId = Guid.NewGuid();

        var mansion = new MansionBO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = userId
        };

        var mansionEntity = new MansionEO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = userId
        };

        _applicationtUnitOfWork.Setup(x => x.Mansions).Returns(_mansionRepositoryMock.Object);

        _mansionRepositoryMock.Setup(x => x.GetCount(It.IsAny<Expression<Func<MansionEO, bool>>>())).ReturnsAsync(0);

        _mapperMock.Setup(x => x.Map<MansionEO>(mansion))
                .Returns(mansionEntity).Verifiable();

        _mansionRepositoryMock.Setup(x => x.Add(mansionEntity)).Returns(Task.CompletedTask)
                .Verifiable();

        _applicationtUnitOfWork.Setup(x => x.Save()).Verifiable();

        _mansionService.CreateMansion(mansion);

        this.ShouldSatisfyAllConditions(
            () => _applicationtUnitOfWork.VerifyAll(),
            () => _mansionRepositoryMock.VerifyAll()
        );
    }

    [Test, Category("unit test")]
    public void CreateMansion_MansionExists_ThrowsError()
    {
        var mansion = new MansionBO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false
        };

        _applicationtUnitOfWork.Setup(x => x.Mansions).Returns(_mansionRepositoryMock.Object);

        _mansionRepositoryMock.Setup(x => x.GetCount(It.IsAny<Expression<Func<MansionEO, bool>>>())).ReturnsAsync(1);

        Should.Throw<Exception>
        (
            () => _mansionService.CreateMansion(mansion)
        );
    }

    [Test, Category("unit test")]
    public void DeleteMansion_MansionExists_DeletesMansion()
    {
        var userId = Guid.NewGuid();

        var mansionEntity = new MansionEO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = userId
        };

        _mansionRepositoryMock.Setup(x => x.GetCount(It.IsAny<Expression<Func<MansionEO, bool>>>())).ReturnsAsync(1);

        _applicationtUnitOfWork.Setup(x => x.Mansions).Returns(_mansionRepositoryMock.Object);

        _mansionRepositoryMock.Setup(x => x.GetById(userId)).ReturnsAsync(mansionEntity);

        _applicationtUnitOfWork.Setup(x => x.Save()).Verifiable();

        _mansionService.DeleteMansion(userId);

        this.ShouldSatisfyAllConditions(
            () => _applicationtUnitOfWork.VerifyAll(),
            () => _mansionRepositoryMock.VerifyAll()
        );
    }

    [Test, Category("unit test")]
    public void DeleteMansion_MansionDoesNotExist_ThrowsError()
    {
        var userId = Guid.NewGuid();

        _mansionRepositoryMock.Setup(x => x.GetCount(It.IsAny<Expression<Func<MansionEO, bool>>>())).ReturnsAsync(0);

        Should.Throw<Exception>
        (
            () => _mansionService.DeleteMansion(userId)
        );
    }

    [Test, Category("unit test")]
    public void EditMansion_MansionDoesNotExist_ThrowsError()
    {
        var userId = Guid.NewGuid();

        var mansion = new MansionBO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = userId
        };

        _applicationtUnitOfWork.Setup(x => x.Mansions).Returns(_mansionRepositoryMock.Object);

        _mansionRepositoryMock.Setup(x => x.GetById(mansion.Id)).ReturnsAsync((MansionEO)null);

        Should.Throw<Exception>
        (
            () => _mansionService.EditMansion(mansion)
        );
    }

    [Test, Category("unit test")]
    public void EditMansion_MansionExisst_UpdatesMansion()
    {
        var userId = Guid.NewGuid();

        var mansion = new MansionBO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = userId
        };

        var mansionEntity = new MansionEO
        {
            Name = "Test",
            Details = "",
            Rate = 2,
            Sqft = 4,
            Occupancy = 6,
            Base64Image = "BASE64_STRING",
            CreatedDate = DateTime.Now,
            UpdatedDate = DateTime.Now,
            IsDeleted = false,
            UserId = userId
        };

        _applicationtUnitOfWork.Setup(x => x.Mansions).Returns(_mansionRepositoryMock.Object);

        _mansionRepositoryMock.Setup(x => x.GetById(mansion.Id)).ReturnsAsync(mansionEntity);

        _mapperMock.Setup(x => x.Map<MansionEO>(mansion))
                .Returns(mansionEntity).Verifiable();

        _applicationtUnitOfWork.Setup(x => x.Save()).Verifiable();

        _mansionService.EditMansion(mansion);

        this.ShouldSatisfyAllConditions(
            () => _applicationtUnitOfWork.VerifyAll(),
            () => _mansionRepositoryMock.VerifyAll()
        );
    }
}