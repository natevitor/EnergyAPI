using EnergyAPI.Services.IA;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using EnergyAPI.Controllers;
using EnergyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EnergyAPI.Tests.Controllers {
    public class DeviceControllerTests {
        private readonly Mock<IEnergyService> _mockEnergyService;
        private readonly DeviceController _controller;

        public DeviceControllerTests() {
            _mockEnergyService = new Mock<IEnergyService>();
            _controller = new DeviceController(_mockEnergyService.Object);
        }

        // Teste GET: api/device/{id} quando o dispositivo não for encontrado
        [Fact]
        public async Task GetDeviceByIdAsync_ReturnsNotFound_WhenDeviceIsNull() {
            // Arrange
            _mockEnergyService.Setup(service => service.GetDeviceByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Device)null);  // Retorna null para simular que o dispositivo não foi encontrado

            // Act
            var result = await _controller.GetDeviceByIdAsync(1);

            // Assert
            var actionResult = Assert.IsType<NotFoundResult>(result); // Espera um NotFound (404)
        }

        // Teste POST: api/device para adicionar um novo dispositivo
        [Fact]
        public async Task AddDeviceAsync_ReturnsCreated_WhenDeviceIsValid() {
            // Arrange
            var device = new Device { Name = "Device1", Type = "Type1", PowerRating = 100 };
            _mockEnergyService.Setup(service => service.AddDeviceAsync(It.IsAny<Device>()))
                .Returns(Task.CompletedTask);  // Simula a criação do dispositivo

            // Act
            var result = await _controller.AddDeviceAsync(device);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result); // Espera um CreatedAtActionResult (201)
            Assert.Equal(201, actionResult.StatusCode); // Verifica se o status code é 201
            var returnedDevice = Assert.IsType<Device>(actionResult.Value); // Verifica se o valor retornado é do tipo Device
            Assert.Equal(device.Name, returnedDevice.Name); // Verifica se os dados estão corretos
        }

        // Teste DELETE: api/device/{id} para excluir um dispositivo
        [Fact]
        public async Task DeleteDeviceAsync_ReturnsNoContent_WhenDeviceIsDeleted() {
            // Arrange
            var deviceToDelete = new Device { Id = 1, Name = "DeviceToDelete", Type = "Type1", PowerRating = 100 };
            _mockEnergyService.Setup(service => service.GetDeviceByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(deviceToDelete); // Retorna o dispositivo para simular que ele existe
            _mockEnergyService.Setup(service => service.DeleteDeviceAsync(It.IsAny<int>()))
                .Returns(Task.CompletedTask); // Simula a exclusão do dispositivo

            // Act
            var result = await _controller.DeleteDeviceAsync(1);

            // Assert
            var actionResult = Assert.IsType<NoContentResult>(result); // Espera um NoContent (204)
        }
    }
}
