using AutoMapper;
using AutoMapper.QueryableExtensions;
using Gymate.Application.Interfaces;
using Gymate.Domain.BOs.ExerciseTypeBOs;
using Gymate.Domain.BOs.General;
using Gymate.Infrastructure.Interfaces;
using Gymate.Infrastructure.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gymate.Application.Services
{
    public class ExerciseTypeService : IExerciseTypeService
    {
        private readonly IExerciseTypeRepository _exerciseTypeRepo;
        private readonly IMapper _mapper;

        public ExerciseTypeService(IExerciseTypeRepository exerciseTypeRepository, IMapper mapper)
        {
            _exerciseTypeRepo = exerciseTypeRepository;
            _mapper = mapper;
        }

        public async Task<int?> AddExerciseType(CreateExerciseTypeBo newExerciseType, CancellationToken cancellationToken)
        {
            var exerciseType = _mapper.Map<ExerciseType>(newExerciseType);

            if (string.IsNullOrEmpty(exerciseType.Name))                
            {
                return null;
            }

            int id = await _exerciseTypeRepo.AddExerciseType(exerciseType, cancellationToken);

            return id;
        }

        public void DeleteExerciseType(int id, CancellationToken cancellationToken)
        {
            _exerciseTypeRepo.DeleteExerciseType(id, cancellationToken);
        }

        public async Task<PagedResultBO<SingleExerciseTypeBO>> GetAllExerciseTypes(int pageSize, int pageNo, string searchString, CancellationToken cancellationToken)
        {
            var exerciseTypes = await _exerciseTypeRepo.GetExerciseTypes(pageSize, pageNo, searchString, cancellationToken);

            var noOfExerciseTypes = await _exerciseTypeRepo.GetNoOfExerciseTypes(cancellationToken);

            var exerciseTypesVm = _mapper.Map<List<SingleExerciseTypeBO>>(exerciseTypes);

            var exerciseTypesForList = new PagedResultBO<SingleExerciseTypeBO>
            {
                Items = exerciseTypesVm,
                CurentPage = pageNo,
                Count = noOfExerciseTypes,
                PageSize = pageSize
            };

            return exerciseTypesForList;
        }

        public UpdateExerciseTypeBO GetExerciseTypeForEdit(int id, CancellationToken cancellationToken)
        {
            var exerciseType = _exerciseTypeRepo.GetExerciseTypeById(id, cancellationToken);

            var newExerciseTypeVm = _mapper.Map<UpdateExerciseTypeBO>(exerciseType);

            return newExerciseTypeVm;
        }

        public async Task<bool> UpdateExerciseType(int id, UpdateExerciseTypeBO model, CancellationToken cancellationToken)
        {
            if (model is null)
            {
                return false;
            }

            ExerciseType exerciseType = _mapper.Map<ExerciseType>(model);

            exerciseType.Id = id;

            return await _exerciseTypeRepo.UpdateExerciseType(exerciseType, cancellationToken);
        }

/*        public ListOfExerciseTypesWithExercisesForRoutine GetAllExerciseTypesWithExercises()
        {
            var listOfExericeTypes = new ListOfExerciseTypesWithExercisesForRoutine();

            var exerciseTypes = _exerciseTypeRepo.GetExerciseTypesWithExercises()
                .ProjectTo<ExerciseTypeWithExercisesForRoutineVm>(_mapper.ConfigurationProvider).ToList();

            listOfExericeTypes.ListExerciseTypesForRoutine = exerciseTypes;
            listOfExericeTypes.Count = exerciseTypes.Count;

            return listOfExericeTypes;
        }*/
    }
}
