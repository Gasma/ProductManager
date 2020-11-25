using AutoMapper;
using gasmaToolsProducts.Application.ViewModels;
using gasmaToolsProducts.Data;
using gasmaToolsProducts.Domain.Commands.Product;
using gasmaToolsProducts.Domain.Models;
using gasmaToolsProducts.Domain.Models.Base;
using gasmaToolsProducts.Domain.Notification;
using gasmaToolsProducts.Domain.Validators.Base;
using gasmaToolsProducts.Helper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace gasmaToolsProducts.Domain.CommandHandlers
{
    public class ProductCommandHandler :
        IRequestHandler<CreateProductCommand, ProductViewModel>,
        IRequestHandler<UpdateProductCommand, ProductViewModel>,
        IRequestHandler<DeleteProductCommand>
    {
        private readonly GasmaToolsContext _context;
        private readonly IPhotoAccessor _photoAccesor;
        private readonly IEntityValidator _entityValidator;
        private readonly NotificationContext _notification;
        private readonly IMapper _mapper;

        public ProductCommandHandler(GasmaToolsContext context,
            IPhotoAccessor photoAccesor,
            IEntityValidator entityValidator,
            NotificationContext notification, IMapper mapper)
        {
            _context = context;
            _photoAccesor = photoAccesor;
            _entityValidator = entityValidator;
            _notification = notification;
            _mapper = mapper;
        }
        public async Task<ProductViewModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var price = Convert.ToDecimal(request.Price);
            if (price < 0)
            {
                _notification.AddNotification("Preço", "Valor digitado é invalido");
                return null;
            }
            var product = new Product(request.Name, price);

            var photoUploadResult = _photoAccesor.AddPhoto(request.File);

            product.AddPhoto(photoUploadResult);

            _entityValidator.Validate(new Entity[] { product });

            if (_notification.HasNotifications)
            {
                _photoAccesor.DeletePhoto(photoUploadResult?.PublicId);
                return null;
            }

            _context.Products.Add(product);

            await _context.Commit();

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<ProductViewModel> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(g => g.Id == request.Id);

            if (product == null)
            {
                _notification.AddNotification("Produto", "Produto não encontrado");
                return null;
            }

            _photoAccesor.DeletePhoto(product.PhotoPublicId);

            var photoUploadResult = _photoAccesor.AddPhoto(request.File);

            product.Update(request.Name, request.Price, photoUploadResult);

            _entityValidator.Validate(new Entity[] { product });

            if (_notification.HasNotifications)
            {
                _photoAccesor.DeletePhoto(photoUploadResult?.PublicId);
                return null;
            }

            await _context.Commit();

            return _mapper.Map<ProductViewModel>(product);
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(g => g.Id == request.Id);

            if (product == null)
            {
                _notification.AddNotification("Produto", "Produto não encontrado");
                return Unit.Value;
            }

            _photoAccesor.DeletePhoto(product.PhotoPublicId);

            _context.Products.Remove(product);

            await _context.Commit();

            return Unit.Value;
        }
    }
}
