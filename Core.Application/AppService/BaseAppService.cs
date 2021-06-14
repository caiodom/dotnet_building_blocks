using AutoMapper;
using Core.Application.ViewModel;
using Core.Domain;
using Core.Domain.Interfaces;
using Core.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application
{
    public class BaseAppService<TSrc, TDest> : IBaseAppService<TSrc, TDest> where TSrc : BaseEntityViewModel
                                                                            where TDest : BaseEntity, new()
    {
        private readonly IMapper _mapper;
        private readonly IBaseService<TDest> _baseService;
        public BaseAppService(IBaseService<TDest> baseService,
                              IMapper mapper)
        {
            this._baseService = baseService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<TSrc>> GetAsync(bool asNoTracking = true)
        {
            try
            {
                return GetMappedViewModel(await _baseService.GetAsync(asNoTracking));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TSrc> GetByIdAsync(int entityId, bool asNoTracking = true)
        {
            try
            {
                return GetMappedViewModel(await _baseService.GetByIdAsync(entityId, asNoTracking));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task AddAsync(TSrc entity)
        {
            try
            {
                return _baseService.AddAsync(SetMappedDomainEntity(entity));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Task AddCollectionAsync(IEnumerable<TSrc> entities)
        {
            try
            {
                return _baseService.AddCollectionAsync(SetMappedDomainEntity(entities));
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public Task RemoveAsync(TSrc entity)
        {
            try
            {
                return _baseService.RemoveAsync(SetMappedDomainEntity(entity));
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task UpdateAsync(TSrc entity)
        {
            try
            {
                return _baseService.UpdateAsync(SetMappedDomainEntity(entity));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task UpdateCollectionAsync(IEnumerable<TSrc> entities)
        {
            try
            {


                return _baseService.UpdateCollectionAsync(SetMappedDomainEntity(entities));

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        protected TSrc GetMappedViewModel(TDest domainEntity)
                => _mapper.Map<TSrc>(domainEntity);


        protected TDest SetMappedDomainEntity(TSrc viewModelEntity)
                    => _mapper.Map<TDest>(viewModelEntity);

        protected IEnumerable<TSrc> GetMappedViewModel(IEnumerable<TDest> lstDomainEntity)
            => _mapper.Map<IEnumerable<TSrc>>(lstDomainEntity);

        protected IEnumerable<TDest> SetMappedDomainEntity(IEnumerable<TSrc> lstViewModelEntity)
                    => _mapper.Map<IEnumerable<TDest>>(lstViewModelEntity);


    }
}
