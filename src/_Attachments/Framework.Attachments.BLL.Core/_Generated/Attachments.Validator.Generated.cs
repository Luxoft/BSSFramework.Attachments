﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Framework.Attachments.BLL
{
    
    
    public partial class AttachmentsValidatorBase : Framework.DomainDriven.BLL.BLLContextHandlerValidator<Framework.Attachments.BLL.IAttachmentsBLLContext, Framework.Attachments.Domain.AttachmentsOperationContext>
    {
        
        public AttachmentsValidatorBase(Framework.Attachments.BLL.IAttachmentsBLLContext context, Framework.Validation.ValidatorCompileCache cache) : 
                base(context, cache)
        {
            base.RegisterHandler<Framework.Attachments.Domain.Attachment>(this.GetAttachmentValidationResult);
            base.RegisterHandler<Framework.Attachments.Domain.AttachmentContainer>(this.GetAttachmentContainerValidationResult);
            base.RegisterHandler<Framework.Attachments.Domain.AttachmentContainerReference>(this.GetAttachmentContainerReferenceValidationResult);
            base.RegisterHandler<Framework.Attachments.Domain.AttachmentTag>(this.GetAttachmentTagValidationResult);
            base.RegisterHandler<Framework.Attachments.Domain.DomainType>(this.GetDomainTypeValidationResult);
            base.RegisterHandler<Framework.Attachments.Domain.TargetSystem>(this.GetTargetSystemValidationResult);
        }
        
        protected virtual Framework.Validation.ValidationResult GetAttachmentContainerReferenceValidationResult(Framework.Attachments.Domain.AttachmentContainerReference source, Framework.Attachments.Domain.AttachmentsOperationContext operationContext, Framework.Validation.IValidationState ownerState)
        {
            return base.GetValidationResult(source, operationContext, ownerState, false);
        }
        
        protected virtual Framework.Validation.ValidationResult GetAttachmentContainerValidationResult(Framework.Attachments.Domain.AttachmentContainer source, Framework.Attachments.Domain.AttachmentsOperationContext operationContext, Framework.Validation.IValidationState ownerState)
        {
            return base.GetValidationResult(source, operationContext, ownerState, false);
        }
        
        protected virtual Framework.Validation.ValidationResult GetAttachmentTagValidationResult(Framework.Attachments.Domain.AttachmentTag source, Framework.Attachments.Domain.AttachmentsOperationContext operationContext, Framework.Validation.IValidationState ownerState)
        {
            return base.GetValidationResult(source, operationContext, ownerState, false);
        }
        
        protected virtual Framework.Validation.ValidationResult GetAttachmentValidationResult(Framework.Attachments.Domain.Attachment source, Framework.Attachments.Domain.AttachmentsOperationContext operationContext, Framework.Validation.IValidationState ownerState)
        {
            return base.GetValidationResult(source, operationContext, ownerState, false);
        }
        
        protected virtual Framework.Validation.ValidationResult GetDomainTypeValidationResult(Framework.Attachments.Domain.DomainType source, Framework.Attachments.Domain.AttachmentsOperationContext operationContext, Framework.Validation.IValidationState ownerState)
        {
            return base.GetValidationResult(source, operationContext, ownerState, false);
        }
        
        protected virtual Framework.Validation.ValidationResult GetTargetSystemValidationResult(Framework.Attachments.Domain.TargetSystem source, Framework.Attachments.Domain.AttachmentsOperationContext operationContext, Framework.Validation.IValidationState ownerState)
        {
            return base.GetValidationResult(source, operationContext, ownerState, false);
        }
    }
    
    public partial class AttachmentsValidator : Framework.Attachments.BLL.AttachmentsValidatorBase
    {
        
        public AttachmentsValidator(Framework.Attachments.BLL.IAttachmentsBLLContext context, Framework.Validation.ValidatorCompileCache cache) : 
                base(context, cache)
        {
        }
    }
}
