using AtividadeRPiatec.Interface;
using AtividadeRPiatec.Models;
using AtividadeRPiatec.Services;
using Microsoft.IdentityModel.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinal.test.LivroTeste
{
    public class MockLivroTeste
    {
        [Fact]
        public void testandoGetcomLivroInexistente()
        {
            //Arrange
            Mock<ILivroRepository> mockLivroRepository = new Mock<ILivroRepository>();
            mockLivroRepository.Setup(a => a.GetById(It.IsAny<int>())).Returns(LivroMock);

            Mock<IRepository<Livro>> mockRepository = new Mock<IRepository<Livro>>();


            LivroService service = new LivroService(mockRepository.Object);

            var myLivro = new Livro()
            {
                Id = 555555555,
                Titulo = "Chapeuzinho Vermelho",
                Autor = "Luidy",
                AnoPublicacao = 2024,
            };

            //Act
            var GetLivroByIdMethod = () => service.GetLivroById(myLivro.Id);

            //Assert
            Assert.Throws<ArgumentException>(() => GetLivroByIdMethod());
        }

        private Livro LivroMock()
        {
            return new Livro()
            {
                Id = 7777777,
                Titulo = "A volta dos que não foram",
                Autor = "Pepe Moreno",
                AnoPublicacao = 2024,

            };
        }
    }
}


