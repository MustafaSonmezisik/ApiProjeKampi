using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator :AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz");
            RuleFor(x => x.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır");
            RuleFor(x => x.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır");
            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyatı boş olamaz").GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz")
                                 .LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz");
            RuleFor(RuleFor => RuleFor.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş olamaz");


        }
    }
}
