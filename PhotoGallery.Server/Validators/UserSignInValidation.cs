using FluentValidation;
using PhotoGallery.Server.Models.RequestModels;

namespace PhotoGallery.Server.Validators;

public class UserSignInValidation: AbstractValidator<UserSignInRequestModel>
{
    public UserSignInValidation()
    {
        RuleFor(user => user.Email)
            .EmailAddress()
            .WithMessage("Must be a valid email address")
            .StringValidation(50, stringName: "Email");

        RuleFor(user => user.Password)
            .StringValidation(50, 6, stringName: "Password");
    }
}