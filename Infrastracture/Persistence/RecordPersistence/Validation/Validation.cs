using FluentValidation;
using Infrastracture.Persistence.RecordPersistence.Commands;
namespace Application.Common.Validation
{
    public class Validation : AbstractValidator<CreateRecordCommand>
    {
        public Validation()
        {
            RuleFor(command => command.RecordDTO.Password).MinimumLength(8).WithMessage("Пароль должен содержать минимум 8 символов");
            RuleFor(command => command.RecordDTO.Name).EmailAddress().WithMessage("Неверный ввод почты");
        }
    }
}
