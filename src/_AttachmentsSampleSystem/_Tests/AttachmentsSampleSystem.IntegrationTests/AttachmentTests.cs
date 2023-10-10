using System;
using System.Linq;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using AttachmentsSampleSystem.Domain;
using AttachmentsSampleSystem.IntegrationTests.__Support.TestData;
using AttachmentsSampleSystem.WebApiCore.Controllers;

using Framework.Attachments.Generated.DTO;
using Framework.SecuritySystem;

namespace AttachmentsSampleSystem.IntegrationTests
{
    [TestClass]
    public class AttachmentTests : TestBase
    {
        [TestMethod]
        public void SaveAttachment_AttachmentExists()
        {
            // Arrange
            var employeeIdent = this.DataHelper.SaveEmployee();

            var sourceAttachment = new AttachmentStrictDTO
            {
                Name = "TestFile",
                Content = new byte[] { 1, 2, 3 }
            };

            var attachmentController = this.GetControllerEvaluator<AttachmentController>();

            // Act
            var attachmentIdentity = attachmentController.Evaluate(c => c.SaveAttachment(nameof(Employee), employeeIdent.Id, sourceAttachment));

            var reloadedAttachment = attachmentController.Evaluate(c => c.GetRichAttachment(attachmentIdentity));

            // Assert
            reloadedAttachment.Name.SequenceEqual(sourceAttachment.Name).Should().Be(true);
            reloadedAttachment.Content.SequenceEqual(sourceAttachment.Content).Should().Be(true);
        }


        [TestMethod]
        public void SaveAttachmentWithoutCustomPermissions_ExceptionRaised()
        {
            // Arrange
            var testRole = this.AuthHelper.CreateRole(
                                                      "failRole",
                                                      AttachmentsSampleSystemSecurityOperation.LocationView,
                                                      AttachmentsSampleSystemSecurityOperation.LocationEdit);


            var testUserName = "failUser";

            this.AuthHelper.SetUserRole(testUserName, testRole);

            var locationIdent = this.DataHelper.SaveLocation();

            var sourceAttachment = new AttachmentStrictDTO
                                   {
                                           Name = "TestFile",
                                           Content = new byte[] { 1, 2, 3 }
                                   };

            var attachmentController = this.GetControllerEvaluator<AttachmentController>().WithImpersonate(testUserName);

            // Act
            Action action = () => attachmentController.Evaluate(c => c.SaveAttachment(nameof(Location), locationIdent.Id, sourceAttachment));

            // Assert
            action.Should().Throw<AccessDeniedException>();
        }


        [TestMethod]
        public void SaveAttachmentWithCustomPermissions_AttachmentExists()
        {
            // Arrange
            var testRole = this.AuthHelper.CreateRole(
                                                      "successRole",
                                                      AttachmentsSampleSystemSecurityOperation.LocationViewAttachment,
                                                      AttachmentsSampleSystemSecurityOperation.LocationEditAttachment);


            var testUserName = "successUser";

            this.AuthHelper.SetUserRole(testUserName, testRole);

            var locationIdent = this.DataHelper.SaveLocation();

            var sourceAttachment = new AttachmentStrictDTO
                                   {
                                           Name = "TestFile",
                                           Content = new byte[] { 1, 2, 3 }
                                   };

            var attachmentController = this.GetControllerEvaluator<AttachmentController>().WithImpersonate(testUserName);

            // Act
            var attachmentIdentity = attachmentController.Evaluate(c => c.SaveAttachment(nameof(Location), locationIdent.Id, sourceAttachment));

            var reloadedAttachment = attachmentController.Evaluate(c => c.GetRichAttachment(attachmentIdentity));

            // Assert
            reloadedAttachment.Name.SequenceEqual(sourceAttachment.Name).Should().Be(true);
            reloadedAttachment.Content.SequenceEqual(sourceAttachment.Content).Should().Be(true);
        }
    }
}
