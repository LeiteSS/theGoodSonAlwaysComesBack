using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using ProductApp.Models;
using ProductApi.Controllers;

namespace ProductTest
{
    public class CategoriesControllerTest
    {
        private readonly Mock<DbSet<Category>> _mockset;
        private readonly Mock<Context> _mockContext;
        private readonly Category _category;

        public CategoriesControllerTest()
        {
            _mockset = new Mock<DbSet<Category>>();
            _mockContext = new Mock<Context>();
            _category = new Category { id = 1, description = "Categoria de Teste"};

            _mockContext.Setup(m => m.categories)
                .Returns(_mockset.Object);

            _mockContext.Setup(m => m.categories.FindAsync(1))
                .ReturnsAsync(_category);
            
            _mockContext.Setup(m => m.SetModified(_category));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
        }

        [Fact]
        public async Task Get_Category()
        {
            var service = new CategoriesController(_mockContext.Object);

            await service.GetCategory(1);

            _mockset.Verify(m => m.FindAsync(1), Times.Once());

        }

        [Fact]
        public async Task Put_Category()
        {
        //Given
            var service = new CategoriesController(_mockContext.Object);
        //When
            await service.PutCategory(1, _category);
        //Then
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Post_Category()
        {
        //Given
            var service = new CategoriesController(_mockContext.Object);
        //When
            await service.PostCategory(_category);
        
        //Then
            _mockset.Verify(x => x.Add(_category), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Delete_Category()
        {
        //Given
            var service = new CategoriesController(_mockContext.Object);
        //When
            await service.DeleteCategory(1);
        
        //Then
            _mockset.Verify(m => m.FindAsync(1),
                Times.Once());
            
            _mockset.Verify(x => x.Remove(_category), Times.Once);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }
    }
}