using AutoMapper;
using GymateMVC.Application.Services;
using GymateMVC.Application.ViewModels.ExerciseVm;
using GymateMVC.Domain.Interfaces;
using GymateMVC.Domain.Model;
using GymateMVC.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace GymateMVC.Tests
{    
    public class ExerciseServiceTests
    {
        [Fact]
        public void Should_RepositoryGetAllExercises_BeCalled_WhenServiceGetAllExercisesCalled()
        {
            var exerciseRepo = new Mock<IExerciseRepository>();
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var mapper = new Mock<IMapper>();

            var objectUnderTest = new ExerciseService(exerciseRepo.Object, exerciseTypeRepo.Object, mapper.Object);

            var result = objectUnderTest.GetAllExercises(1, 1, string.Empty);

            exerciseRepo.Verify(r => r.GetAllExercises(), Times.Once);
        }

        [Fact]
        public void Should_GetAllExercises_ReturnCorrectList_WhenRepoProvidesCorrectExercises()
        {
            var exercises = new List<Exercise>()
            {
                new Exercise() { Id = 1, Name = "dummy 1", ExerciseTypeId = 1, ExerciseType = new ExerciseType() {Id = 1, Name = "dummy"} },
                new Exercise() { Id = 2, Name = "dummy 2", ExerciseTypeId = 1, ExerciseType = new ExerciseType() {Id = 1, Name = "dummy"} },
                new Exercise() { Id = 3, Name = "dummy 3", ExerciseTypeId = 1, ExerciseType = new ExerciseType() {Id = 2, Name = "dummy 2"} },
                new Exercise() { Id = 4, Name = "dummy 4", ExerciseTypeId = 1, ExerciseType = new ExerciseType() {Id = 2, Name = "dummy 2"} }
            };

            var expectedExerciseList = new List<ExerciseForListVm>()
            {
                new ExerciseForListVm() { Id = 1, Name = "dummy 1", ExerciseTypeName = "dummy"},
                new ExerciseForListVm() { Id = 2, Name = "dummy 2", ExerciseTypeName = "dummy"},
                new ExerciseForListVm() { Id = 3, Name = "dummy 3", ExerciseTypeName = "dummy 2"},
                new ExerciseForListVm() { Id = 4, Name = "dummy 4", ExerciseTypeName = "dummy 2"}
            };

            var expectedResult = new ListForExerciseListVm()
            {
                ListExercisesForList = expectedExerciseList,
                Count = 4,
                CurrentPage = 1,
                PageSize = 4,
                SearchString = ""
            };

            var exercisesQuery = exercises.AsQueryable();
            var exerciseRepo = new Mock<IExerciseRepository>();
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var mapper = new Mock<IMapper>();

            exerciseRepo.Setup(r => r.GetAllExercises()).Returns(exercisesQuery);


            var objectUnderTest = new ExerciseService(exerciseRepo.Object, exerciseTypeRepo.Object, mapper.Object);

            var result = objectUnderTest.GetAllExercises(4, 1, string.Empty);

            Assert.True(AreListsForExerciseTypesEqual(result, expectedResult));
        }

        private bool AreListsForExerciseTypesEqual(ListForExerciseListVm result, ListForExerciseListVm expectedResult)
        {
            return AreListsEqual(result.ListExercisesForList, expectedResult.ListExercisesForList)
                && result.SearchString == expectedResult.SearchString
                && result.Count == expectedResult.Count
                && result.CurrentPage == expectedResult.CurrentPage
                && result.PageSize == expectedResult.PageSize;
        }

        private bool AreListsEqual(List<ExerciseForListVm> listForExerciseList1, List<ExerciseForListVm> listForExerciseList2)
        {
            bool AreEqual = listForExerciseList1.Count == listForExerciseList2.Count;

            for (int i = 0; i < listForExerciseList1.Count; i++)
            {
                if (listForExerciseList1[i].Id != listForExerciseList2[i].Id
                    || listForExerciseList1[i].Name != listForExerciseList2[i].Name
                    || listForExerciseList1[i].ExerciseTypeName != listForExerciseList2[i].ExerciseTypeName)
                {
                    AreEqual = false;
                }
            }

            return AreEqual;
        }


        [Fact]
        public void Should_RepoAddExercise_BeCalled_WhenServiceAddExerciseCalled()
        {
            var exerciseType = new ExerciseType() { Id = 1, Name = "dummy Exercise Type" };

            var exerciseVm = new NewExerciseVm()
            {
                Id = 1,
                Name = "Dummy",
                ExerciseTypeId = exerciseType.Id,
            };

            var exerciseRepo = new Mock<IExerciseRepository>();
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var mapper = new Mock<IMapper>();

            exerciseTypeRepo.Setup(r => r.GetExerciseTypeById(exerciseType.Id)).Returns(exerciseType);

            var objectUnderTest = new ExerciseService(exerciseRepo.Object, exerciseTypeRepo.Object, mapper.Object);

            var result = objectUnderTest.AddExercise(exerciseVm);

            exerciseRepo.Verify(r => r.AddExercise(It.IsAny<Exercise>()), Times.Once);

            Assert.Equal(exerciseType.Id, result);
        }

        [Fact]
        public void Should_GetExercise_ReturnCorrectExercise_WhenServiceGetExerciseCalled()
        {
            var exercise = new Exercise() { Id = 1, Name = "dummy Exercise", ExerciseType = new ExerciseType() { Id = 1, Name = "dummy exercise type"} };

            var expectedResult = new ExerciseForListVm()
            {
                Id = 1,
                Name = "dummy Exercise",
                ExerciseTypeName = exercise.ExerciseType.Name,                
            };

            var exerciseRepo = new Mock<IExerciseRepository>();
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var mapper = new Mock<IMapper>();

            exerciseRepo.Setup(r => r.GetExerciseById(exercise.Id)).Returns(exercise);

            var objectUnderTest = new ExerciseService(exerciseRepo.Object, exerciseTypeRepo.Object, mapper.Object);

            var result = objectUnderTest.GetExercise(exercise.Id);

            exerciseRepo.Verify(r => r.GetExerciseById(exercise.Id), Times.Once);

            Assert.Equal(expectedResult.Id, result.Id);
            Assert.Equal(expectedResult.Name, result.Name);
            Assert.Equal(expectedResult.ExerciseTypeName, result.ExerciseTypeName);
        }

        [Fact]
        public void Should_UpdateExercise_ReturnCorrectExercise_WhenServiceUpdateCalled()
        {
            var exerciseType = new ExerciseType() { Id = 1, Name = "dummy Exercise Type" };
            var exerciseVm = new NewExerciseVm()
            {
                Id = 1,
                Name = "dummy exercise",
                ExerciseTypeId = 1
            };

            var exerciseRepo = new Mock<IExerciseRepository>();
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var mapper = new Mock<IMapper>();

            exerciseTypeRepo.Setup(r => r.GetExerciseTypeById(exerciseType.Id)).Returns(exerciseType);

            var objectUnderTest = new ExerciseService(exerciseRepo.Object, exerciseTypeRepo.Object, mapper.Object);

            objectUnderTest.UpdateExercise(exerciseVm);

            exerciseRepo.Verify(r => r.UpdateExercise(It.IsAny<Exercise>()), Times.Once);
        }

        [Fact]
        public void Should_RepoDeleteExercise_BeCalled_WhenServiceDeleteCalled()
        {
            var exerciseRepo = new Mock<IExerciseRepository>();
            var exerciseTypeRepo = new Mock<IExerciseTypeRepository>();
            var mapper = new Mock<IMapper>();

            var objectUnderTest = new ExerciseService(exerciseRepo.Object, exerciseTypeRepo.Object, mapper.Object);

            var id = 1;

            objectUnderTest.DeleteExercise(id);

            exerciseRepo.Verify(r => r.DeleteExercise(id), Times.Once);
        }
    }
}
