using FluentValidation;
using SocialMedia.Core.DTOs;

namespace SocialMedia.Infrasture.Validators
{
    public  class PostValidators : AbstractValidator<PostDto>
    {

        public PostValidators()
        {

            RuleFor(post => post.Description).NotNull().Length(10, 500);

            RuleFor(post => post.Date).NotNull();

        }

    }
}
