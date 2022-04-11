using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GeekShopping.ProductAPI.DTO;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using GeekShopping.ProductAPI.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;

        public ProductRepository(MySQLContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<List<ProductDTO>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> FindById(long id)
        {
            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Create(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Update(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (product == null) return false;

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}