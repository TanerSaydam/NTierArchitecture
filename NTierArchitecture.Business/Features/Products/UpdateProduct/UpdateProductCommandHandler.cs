using MediatR;
using NTierArchitecture.Entities.Models;
using NTierArchitecture.Entities.Repositories;

namespace NTierArchitecture.Business.Features.Products.UpdateProduct;

internal sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateProductCommandHandler(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        Product product = await _productRepository.GetByIdAsync(p => p.Id == request.Id, cancellationToken);
        if (product is null)
        {
            throw new ArgumentException("Ürün bulunamadı!");
        }

        if(product.Name != request.Name)
        {
            bool isProductNameIsExists = await _productRepository.AnyAsync(p => p.Name == request.Name, cancellationToken);
            if (isProductNameIsExists)
            {
                throw new ArgumentException("Bu ürün adı daha önce kullanılmış!");
            }
        }

        product.Name = request.Name;
        product.Quantity = request.Quantity;
        product.CategoryId = request.CategoryId;
        product.Price = request.Price;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
