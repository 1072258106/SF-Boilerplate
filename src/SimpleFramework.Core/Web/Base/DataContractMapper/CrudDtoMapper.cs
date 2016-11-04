
using SimpleFramework.Core.Abstraction.Entitys;
using SimpleFramework.Core.Web.Base.Datatypes;

namespace SimpleFramework.Core.Web.Base.DataContractMapper
{
    /// <summary>
    /// ����ӳ���Զ�ӳ������ID���������޸�����
    /// </summary>
    public abstract class CrudDtoMapper<TEntity, TDto> : ICrudDtoMapper<TEntity, TDto>
    where TEntity : IEntityWithTypedId<long>, new()
    where TDto : EntityModelBase, new()
    {
        /// <summary>
        /// DTOת�������ʵ��
        /// </summary>
        /// <param name="dto">DTO����Դ</param>
        /// <returns></returns>
        public TEntity MapDtoToEntity(TDto dto)
        {
            var entity = OnMapDtoToEntity(dto, new TEntity());

            // Making sure the derived class doesn't change these values
            entity.Id = dto.Id;

            return entity;
        }

        /// <summary>
        /// �����ʵ��ת��DTO
        /// </summary>
        /// <param name="entity">�����ʵ��</param>
        /// <returns></returns>
        public TDto MapEntityToDto(TEntity entity)
        {
            var dto = OnMapEntityToDto(entity, new TDto());

            // Making sure the derived class doesn't change these values
            dto.Id = entity.Id;

            return OnMapEntityToDto(entity, dto);
        }

        /// <summary>
        /// �����ʵ��ת��DTO
        /// </summary>
        /// <param name="entity">�����ʵ��</param>
        /// <param name="existingDto">��ʵ������DTO</param>
        /// <returns></returns>
        public TDto MapEntityToDto(TEntity entity, TDto existingDto)
        {
            var dto = OnMapEntityToDto(entity, existingDto);

            // Making sure the derived class doesn't change these values
            dto.Id = entity.Id;


            return OnMapEntityToDto(entity, dto);
        }

        /// <summary>
        /// DTOת�������ʵ��
        /// </summary>
        /// <param name="dto">DTO����Դ</param>
        /// <param name="existingEntity">��ʵ�����������ʵ��</param>
        /// <returns></returns>
        public TEntity MapDtoToEntity(TDto dto, TEntity existingEntity)
        {
            var entity = OnMapDtoToEntity(dto, existingEntity);

            // Making sure the derived class doesn't change these values
            entity.Id = dto.Id;


            return entity;
        }

        /// <summary>
        /// �����ʵ��ת��DTOӳ��
        /// </summary>
        /// <param name="entity">ʵ��ӳ��</param>
        /// <param name="dto">DTOӳ��ʵ��</param>
        /// <returns>The dto</returns>
        protected abstract TDto OnMapEntityToDto(TEntity entity, TDto dto);

        /// <summary>
        /// DTOת�������ʵ��ӳ��
        /// </summary>
        /// <param name="dto">DTOʵ��ӳ��</param>
        /// <param name="entity">ʵ��ӳ��DTO</param>
        /// <returns>The entity</returns>
        protected abstract TEntity OnMapDtoToEntity(TDto dto, TEntity entity);

    }
}
