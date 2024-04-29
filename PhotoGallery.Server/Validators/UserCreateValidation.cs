using FluentValidation;
using FluentValidation.Results;
using PhotoGallery.Server.Models.RequestModels;

namespace PhotoGallery.Server.Validators;

public class UserCreateValidation : AbstractValidator<UserCreateRequestModel>
{
    public UserCreateValidation()
    {
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Must be a valid email address")
            .StringValidation(50, stringName: "Email");


        RuleFor(user => user.FirstName)
            .StringValidation(50, stringName: "First name");

        RuleFor(user => user.LastName)
            .StringValidation(50, stringName: "Last name");

    }
}