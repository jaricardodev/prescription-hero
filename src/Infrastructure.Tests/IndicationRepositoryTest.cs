using Core.Aggregates;
using Core.Entities;
using Cosmos.Abstracts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;

namespace Infrastructure.Tests
{
    public class IndicationRepositoryTest
    {
        private readonly Mock<IOptions<CosmosRepositoryOptions>> _optionsMock;
        private readonly Mock<ICosmosFactory> _cosmosFactoryMock;
        private readonly Mock<CosmosClient> _cosmosClientMock;
        private readonly Mock<Container> _containerMock;
        private readonly Mock<Database> _databaseMock;


        public IndicationRepositoryTest()
        {
            _optionsMock = new Mock<IOptions<CosmosRepositoryOptions>>();
            _cosmosFactoryMock = new Mock<ICosmosFactory>();
            _cosmosClientMock = new Mock<CosmosClient>();
            _containerMock = new Mock<Container>();
            _databaseMock = new Mock<Database>();


            _cosmosFactoryMock.Setup(x => x.GetCosmosClient()).Returns(_cosmosClientMock.Object);
            _cosmosFactoryMock.Setup(x => x.GetDatabaseAsync()).ReturnsAsync(_databaseMock.Object);
            _cosmosClientMock.Setup(x => x.GetContainer(It.IsAny<string>(), It.IsAny<string>())).Returns(_containerMock.Object);
            _databaseMock.Setup(x=>x.CreateContainerIfNotExistsAsync(It.IsAny<ContainerProperties>(), It.IsAny<int?>(), null, default))
                .ReturnsAsync(new Mock<ContainerResponse>().Object);
        }


        [Fact]
        public async Task IndicationRepository_Should_CreateIndication()
        {
            var indication = new Indication(
                new Prescriber(Guid.NewGuid(), "test@email.com"), 
                new PatientPrescription(
                    new Patient(Guid.NewGuid(), "test@email.com", 10), 
                    new Prescription(Guid.NewGuid(), "some indications",  "some dose")));

            _containerMock
                .Setup(x => x.CreateItemAsync(It.IsAny<IndicationDBEntity>(), It.IsAny<PartitionKey?>(), It.IsAny<ItemRequestOptions>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Mock<ItemResponse<IndicationDBEntity>>().Object)
                .Verifiable();

            var sut = new IndicationRepository(new NullLoggerFactory(), _optionsMock.Object, _cosmosFactoryMock.Object);

            await sut.Create(indication);

            _containerMock.Verify();
        }

        [Fact]
        public void IndicationRepository_Should_DeleteIndication()
        {

        }

        [Fact]
        public void IndicationRepository_Should_GeIndications()
        {

        }
    }
}