using FluentAssertions;
using WPFSipBiteUnite.ViewModel;

namespace WPFSipBiteUniteTest
{
    [TestClass]
    public class RegistrationViewModelTests
    {
        [TestMethod]
        public void CanExecuteRegisterCommand_ValidEmailAndPassword_ReturnsTrue()
        {
            // Arrange
            var viewModel = new RegistrationViewModel
            {
                Username = "test@example.com",
                Password = "Password123"
            };

            // Act
            var result = viewModel.CanExecuteRegisterCommand(null);

            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void CanExecuteRegisterCommand_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            var viewModel = new RegistrationViewModel
            {
                Username = "invalid_email",
                Password = "Password123"
            };

            // Act
            var result = viewModel.CanExecuteRegisterCommand(null);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void CanExecuteRegisterCommand_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            var viewModel = new RegistrationViewModel
            {
                Username = "test@example.com",
                Password = "short"
            };

            // Act
            var result = viewModel.CanExecuteRegisterCommand(null);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void CanExecuteRegisterCommand_NullUsername_ReturnsFalse()
        {
            // Arrange
            var viewModel = new RegistrationViewModel
            {
                Username = null,
                Password = "Password123"
            };

            // Act
            var result = viewModel.CanExecuteRegisterCommand(null);

            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void CanExecuteRegisterCommand_NullPassword_ReturnsFalse()
        {
            // Arrange
            var viewModel = new RegistrationViewModel
            {
                Username = "test@example.com",
                Password = null
            };

            // Act
            var result = viewModel.CanExecuteRegisterCommand(null);

            // Assert
            result.Should().BeFalse();
        }
    }
}
